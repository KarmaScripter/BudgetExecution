﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 05-27-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="IConnectionFactory.cs" company="Terry D. Eppler">
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
//   IConnectionFactory.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Data.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets or sets the connection path.
        /// </summary>
        /// <value>
        /// The connection path.
        /// </value>
        ConnectionStringSettingsCollection ConnectionPath { get; set; }

        /// <summary>
        /// Gets or sets the database client path.
        /// </summary>
        /// <value>
        /// The database client path.
        /// </value>
        NameValueCollection DbClientPath { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        DbConnection Connection { get; set; }

        /// <summary>
        /// Gets or sets the database path.
        /// </summary>
        /// <value>
        /// The database path.
        /// </value>
        string DbPath { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        Source Source { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        Provider Provider { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        EXT Extension { get; set; }

        /// <summary>
        /// Gets or sets the path extension.
        /// </summary>
        /// <value>
        /// The path extension.
        /// </value>
        string PathExtension { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        string TableName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        DbConnection GetConnection( );
    }
}