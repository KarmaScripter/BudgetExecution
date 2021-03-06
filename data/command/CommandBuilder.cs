// <copyright file = "CommandBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref = "T:BudgetExecution.ICommandBuilder"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CommandBuilder : CommandBase, ICommandBuilder
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "CommandBuilder"/>
        /// class.
        /// </summary>
        public CommandBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "CommandBuilder"/>
        /// class.
        /// </summary>
        /// <param name = "sql" > The SQL. </param>
        public CommandBuilder( ISqlStatement sql )
        {
            SqlStatement = sql;
            ConnectionBuilder = SqlStatement.GetConnectionBuilder();
            Command = SetCommand( SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "CommandBuilder"/>
        /// class.
        /// </summary>
        /// <param name = "connectionbuilder" > The connectionmanager. </param>
        /// <param name = "sql" > The SQL. </param>
        public CommandBuilder( IConnectionBuilder connectionbuilder, ISqlStatement sql )
        {
            SqlStatement = sql;
            ConnectionBuilder = connectionbuilder;
            Command = SetCommand( SqlStatement );
        }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <summary> Sets the command. </summary>
        /// <param name = "sqlstatement" > The sqlstatement. </param>
        /// <returns> </returns>
        public DbCommand SetCommand( ISqlStatement sqlstatement )
        {
            if( Verify.Ref( sqlstatement ) )
            {
                try
                {
                    var provider = ConnectionBuilder?.GetProvider();

                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            Command = GetSQLiteCommand( sqlstatement );
                            return Command;
                        }

                        case Provider.SqlCe:
                        {
                            Command = GetSQLiteCommand( sqlstatement );
                            return Command;
                        }

                        case Provider.SqlServer:
                        {
                            Command = GetSQLiteCommand( sqlstatement );
                            return Command;
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            Command = GetSQLiteCommand( sqlstatement );
                            return Command;
                        }

                        default:
                        {
                            return default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    CommandBuilder.Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary> Gets the command. </summary>
        /// <returns> </returns>
        public DbCommand GetCommand()
        {
            try
            {
                return Verify.Ref( Command )
                    ? Command
                    : default( DbCommand );
            }
            catch( Exception ex )
            {
                CommandBuilder.Fail( ex );
                return default( DbCommand );
            }
        }
    }
}