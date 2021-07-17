// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterFactory : IDisposable
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        private readonly AdapterBuilder _adapterBuilder;

        /// <summary> Gets the connection. </summary>
        /// <value> The connection. </value>
        private readonly DbConnection _connection;

        /// <summary> Gets the SQL statement. </summary>
        /// <value> The SQL statement. </value>
        private readonly ISqlStatement _sqlStatement;

        /// <summary> Gets the commander. </summary>
        /// <value> The commander. </value>
        private readonly ICommandBuilder _commandBuilder;

        /// <summary> Gets the connection manager. </summary>
        /// <value> The connection manager. </value>
        private readonly IConnectionBuilder _connectionBuilder;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "AdapterFactory"/>
        /// class.
        /// </summary>
        public AdapterFactory( AdapterBuilder adapterBuilder )
        {
            _adapterBuilder = adapterBuilder;
            _connectionBuilder = _adapterBuilder.GetConnectionBuilder();
            _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _sqlStatement = new SqlStatement( _connectionBuilder );
            _commandBuilder = new CommandBuilder( _connectionBuilder, _sqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "AdapterFactory"/>
        /// class.
        /// </summary>
        /// <param name = "connectionBuilder" > The connectionmanager. </param>
        /// <param name = "sqlStatement" > The sqlStatement. </param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            _connectionBuilder = connectionBuilder;
            _sqlStatement = sqlStatement;
            _adapterBuilder = new AdapterBuilder( _connectionBuilder, _sqlStatement );
            _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _commandBuilder = new CommandBuilder( _connectionBuilder, _sqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "AdapterFactory"/>
        /// class.
        /// </summary>
        /// <param name = "connectionBuilder" > The connectionBuilder. </param>
        /// <param name = "commandBuilder" > The commandBuilder. </param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ICommandBuilder commandBuilder )
        {
            _connectionBuilder = connectionBuilder;
            _commandBuilder = commandBuilder;
            _sqlStatement = _commandBuilder.GetSqlStatement();
            _adapterBuilder = new AdapterBuilder( _connectionBuilder, _sqlStatement );
            _connection = new ConnectionFactory( _connectionBuilder ).GetConnection();
        }
        
        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <summary> Creates this instance. </summary>
        /// <returns> </returns>
        public DbDataAdapter GetAdapter()
        {
            if( !Verify.Input( _connectionBuilder.GetConnectionString() )
                || !Verify.Input( _sqlStatement.GetSelectStatement() ) )
            {
                return default;
            }

            try
            {
                var provider = _connectionBuilder.GetProvider();

                if( Validate.Provider( provider ) )
                {
                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            return GetSQLiteAdapter() ?? default( SQLiteDataAdapter );
                        }

                        case Provider.SqlCe:
                        {
                            return GetSqlCeAdapter() ?? default( SqlCeDataAdapter );
                        }

                        case Provider.SqlServer:
                        {
                            return GetSqlAdapter() ?? default( SqlDataAdapter );
                        }

                        case Provider.CSV:
                        case Provider.OleDb:
                        case Provider.Access:
                        case Provider.Excel:
                        {
                            return GetOleDbDataAdapter() ?? default( OleDbDataAdapter );
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }

            return default;
        }

        /// <summary> Gets the OLE database data adapter. </summary>
        /// <returns> </returns>
        private OleDbDataAdapter GetOleDbDataAdapter()
        {
            if( Verify.Input( _sqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var connection = _connectionBuilder?.GetConnectionString();

                    return Verify.Input( connection )
                        ? new OleDbDataAdapter( _sqlStatement.GetSelectStatement(), connection )
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the SQL server adapter. </summary>
        /// <returns> </returns>
        private SqlDataAdapter GetSqlAdapter()
        {
            if( !Verify.Ref( _sqlStatement ) )
            {
                return default;
            }

            try
            {
                var connection = _connectionBuilder?.GetConnectionString();

                return Verify.Input( connection )
                    ? new SqlDataAdapter( _sqlStatement.GetSelectStatement(), connection )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the SQL ce adapter. </summary>
        /// <returns> </returns>
        private SqlCeDataAdapter GetSqlCeAdapter()
        {
            if( Verify.Input( _connection?.ConnectionString )
                && Verify.Input( _sqlStatement?.GetSelectStatement() ) )
            {
                try
                {
                    var adapter = new SqlCeDataAdapter( _sqlStatement?.GetSelectStatement(),
                        _connection as SqlCeConnection );

                    return adapter;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the sq lite adapter. </summary>
        /// <returns> </returns>
        private SQLiteDataAdapter GetSQLiteAdapter()
        {
            if( _sqlStatement != null )
            {
                try
                {
                    var adapter = new SQLiteDataAdapter( _sqlStatement.GetSelectStatement(),
                        _connection as SQLiteConnection );

                    return adapter;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Releases unmanaged and - optionally - managed resources. </summary>
        /// <param name = "disposing" >
        /// <c> true </c>
        /// to release both managed and unmanaged resources;
        /// <c> false </c>
        /// to release only unmanaged resources.
        /// </param>
        private protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                try
                {
                    _adapterBuilder?.Dispose();
                    _connection?.Dispose();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Get Error Dialog. </summary>
        /// <param name = "ex" > The ex. </param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error.SetText();
            error.ShowDialog();
        }
    }
}