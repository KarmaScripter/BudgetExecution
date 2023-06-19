﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="CommandFactory.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   CommandFactory.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <summary> </summary>
    /// <seealso cref="ICommand"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CommandFactory : CommandBase, ICommandFactory
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        public CommandFactory( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        /// <param name="commandType"> Type of the command. </param>
        public CommandFactory( Source source, Provider provider, string sqlText, SQL commandType )
            : base( source, provider, sqlText, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="where"> The dictionary. </param>
        /// <param name="commandType"> </param>
        public CommandFactory( Source source, Provider provider, IDictionary<string, object> where, SQL commandType = SQL.Selectall )
            : base( source, provider, where, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="update"> The updates. </param>
        /// <param name="where"> The criteria. </param>
        /// <param name="commandType"> </param>
        public CommandFactory( Source source, Provider provider, IDictionary<string, object> update, IDictionary<string, object> where,
            SQL commandType = SQL.UPDATE )
            : base( source, provider, update, where, commandType )
        {
        }

        /// <summary> </summary>
        /// <param name="source"> </param>
        /// <param name="provider"> </param>
        /// <param name="columns"> </param>
        /// <param name="where"> </param>
        /// <param name="commandType"> </param>
        public CommandFactory( Source source, Provider provider, IEnumerable<string> columns, IDictionary<string, object> where,
            SQL commandType = SQL.SELECT )
            : base( source, provider, columns, where, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="having"> The having. </param>
        /// <param name="commandType"> Type of the command. </param>
        public CommandFactory( Source source, Provider provider, IEnumerable<string> fields, IEnumerable<string> numerics,
            IDictionary<string, object> having, SQL commandType = SQL.SELECT )
            : base( source, provider, fields, numerics, having,
                commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CommandFactory"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The SQL statement. </param>
        public CommandFactory( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetCommand( )
        {
            if( SqlStatement != null )
            {
                try
                {
                    switch( SqlStatement.Provider )
                    {
                        case Provider.SQLite:
                        {
                            return GetSQLiteCommand( );
                        }
                        case Provider.SqlCe:
                        {
                            return GetSqlCeCommand( );
                        }
                        case Provider.SqlServer:
                        {
                            return GetSqlCommand( );
                        }
                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            return GetOleDbCommand( );
                        }
                        default:
                        {
                            return default( DbCommand );
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }
    }
}