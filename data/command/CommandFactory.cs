// <copyright file = "CommandFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class CommandFactory : CommandBase, ICommandFactory
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The command builder
        /// </summary>
        private readonly ICommandBuilder CommandBuilder;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        /// <param name="commandbuilder">The command builder.</param>
        public CommandFactory( ICommandBuilder commandbuilder )
        {
            CommandBuilder = commandbuilder;
            SqlStatement = CommandBuilder?.GetSqlStatement();
            ConnectionFactory = new ConnectionFactory( SqlStatement?.GetConnectionBuilder() );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <value>
        /// The connection manager.
        /// </value>
        private IConnectionFactory ConnectionFactory { get; }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Gets the create tablename command.
        /// </summary>
        /// <param name = "tablename" >
        /// The tablename.
        /// </param>
        /// <param name = "columns" >
        /// The columns.
        /// </param>
        /// <returns>
        /// </returns>
        public DbCommand GetCreateTableCommand( string tablename, IEnumerable<DataColumn> columns )
        {
            if( Verify.Input( tablename )
                && Verify.Sequence( columns ) )
            {
                try
                {
                    var connectionbuilder = GetConnectionBuilder();
                    var provider = connectionbuilder.GetProvider();
                    var sql = $"CREATE TABLE {tablename}";

                    if( Verify.Provider( provider )
                        && Verify.Input( sql ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default;
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default;
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default;
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
                                    : default;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the create viewname command.
        /// </summary>
        /// <param name = "viewname" >
        /// The tablename.
        /// </param>
        /// <param name = "columns" >
        /// The columns.
        /// </param>
        /// <returns>
        /// </returns>
        public DbCommand GetCreateViewCommand( string viewname, IEnumerable<DataColumn> columns )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( Verify.Input( viewname )
                && columns?.Any() == true
                && connectionbuilder != null
                && connectionbuilder.GetProvider() != Provider.SqlCe )
            {
                try
                {
                    var provider = connectionbuilder.GetProvider();
                    var sql = $"CREATE VIEW {viewname};";

                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql )
                                : default;
                        }

                        case Provider.SqlServer:
                        {
                            return Verify.Input( sql )
                                ? new SqlCommand( sql )
                                : default;
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            return Verify.Input( sql )
                                ? new OleDbCommand( sql )
                                : default;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the drop tablename command.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        /// <returns>
        /// </returns>
        public DbCommand GetDropTableCommand( DataTable table )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( table != null
                && connectionbuilder != null )
            {
                try
                {
                    var sql = $"DROP {table.TableName};";
                    var provider = connectionbuilder.GetProvider();

                    if( Verify.Input( sql )
                        && Enum.IsDefined( typeof( Provider ), provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default;
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default;
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default;
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
                                    : default;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <returns>
        /// </returns>
        public DbCommand GetAlterCommand( DataTable table, DataColumn column )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( table != null
                && column != null
                && connectionbuilder != null )
            {
                try
                {
                    var provider = connectionbuilder?.GetProvider();
                    var sql = $"ALTER TABLE {table.TableName} ADD COLUMN {column.ColumnName};";

                    if( Verify.Input( sql )
                        && Enum.IsDefined( typeof( Provider ), provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default;
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default;
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default;
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
                                    : default;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        public DbCommand GetAlterCommand( DataTable table, string name )
        {
            if( table != null
                && Verify.Input( name )
                && CommandBuilder != null )
            {
                try
                {
                    var provider = CommandBuilder?.GetProvider();
                    var sql = $"ALTER TABLE {table.TableName} RENAME {name};";

                    if( Enum.IsDefined( typeof( Provider ), provider )
                        && Verify.Input( sql ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default;
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default;
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default;
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
                                    : default;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the select command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetSelectCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetInsertCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetUpdateCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetDeleteCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
