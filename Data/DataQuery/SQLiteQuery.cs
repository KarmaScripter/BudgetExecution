﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="SQLiteQuery.cs" company="Terry D. Eppler">
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
//   SQLiteQuery.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SQLite;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Query" />
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    public class SQLiteQuery : Query
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ColDataType
        {
            /// <summary>
            /// The default
            /// </summary>
            Default,

            /// <summary>
            /// The text
            /// </summary>
            Text,

            /// <summary>
            /// The date time
            /// </summary>
            DateTime,

            /// <summary>
            /// The integer
            /// </summary>
            Integer,

            /// <summary>
            /// The decimal
            /// </summary>
            Decimal,

            /// <summary>
            /// The BLOB
            /// </summary>
            Blob
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        public SQLiteQuery( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public SQLiteQuery( Source source )
            : base( source, Provider.SQLite, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="updates">The updates.</param>
        public SQLiteQuery( Source source, IDictionary<string, object> updates )
            : base( source, Provider.SQLite, updates, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict">The dictionary.</param>
        /// <param name="commandType">Type of the command.</param>
        public SQLiteQuery( Source source, IDictionary<string, object> dict, SQL commandType )
            : base( source, Provider.SQLite, dict, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="updates">The updates.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public SQLiteQuery( Source source, IDictionary<string, object> updates, 
            IDictionary<string, object> where, SQL commandType = SQL.UPDATE )
            : base( source, Provider.SQLite, updates, where, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="criteria">The criteria.</param>
        /// <param name="commandType">Type of the command.</param>
        public SQLiteQuery( Source source, IEnumerable<string> columns, 
            IDictionary<string, object> criteria, SQL commandType = SQL.SELECT )
            : base( source, Provider.SQLite, columns, criteria, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="sqlStatement">The sqlStatement.</param>
        public SQLiteQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="sqlText">The SQL text.</param>
        public SQLiteQuery( Source source, string sqlText )
            : base( source, Provider.SQLite, sqlText )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="fullPath">The fullpath.</param>
        /// <param name="sqlText"></param>
        /// <param name="commandType">The commandType.</param>
        public SQLiteQuery( string fullPath, string sqlText, SQL commandType = SQL.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="fullPath">The fullpath.</param>
        /// <param name="commandType">The commandType.</param>
        /// <param name="dict"></param>
        public SQLiteQuery( string fullPath, SQL commandType, IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }

        /// <summary>
        /// Gets the data adapter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public SQLiteDataAdapter GetDataAdapter( SQLiteCommand command )
        {
            try
            {
                return new SQLiteDataAdapter( command );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( SQLiteDataAdapter );
            }
        }

        /// <summary>
        /// Gets the data reader.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public SQLiteDataReader GetDataReader( SQLiteCommand command )
        {
            try
            {
                return command.ExecuteReader( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( SQLiteDataReader );
            }
        }

        /// <summary>
        /// Creates the table from excel file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable CreateTableFromExcelFile( string filePath, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( filePath )
               && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _dataSet = new DataSet( );
                    var _filePath = GetExcelFilePath( );
                    var _sql = $"SELECT * FROM [{sheetName}]";
                    var _msg = "Sheet Does Not Exist!";
                    var _excelQuery = new ExcelQuery( _filePath, _sql );
                    var _connection = _excelQuery.DataConnection as OleDbConnection;
                    _connection?.Open( );
                    var _table = _connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                    if( ( _table?.Rows.Count > 0 )
                       && CheckIfSheetNameExists( sheetName, _table ) )
                    {
                        var _message = new Message( _msg );
                        _message?.ShowDialog( );
                    }
                    else
                    {
                        sheetName = _table?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                    }

                    var _adapter = new OleDbDataAdapter( _sql, _connection );
                    if( sheetName != null )
                    {
                        _adapter.Fill( _dataSet, sheetName );
                    }

                    return _dataSet.Tables[ 0 ];
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable CreateTableFromCsvFile( string fileName, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( fileName )
               && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _dataSet = new DataSet( );
                    var _dataTable = new DataTable( );
                    _dataSet.DataSetName = fileName;
                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var _sql = $"SELECT * FROM [{sheetName}]";
                    var _fullPath = GetExcelFilePath( );
                    if( !string.IsNullOrEmpty( _fullPath ) )
                    {
                        var _csvQuery = new CsvQuery( _fullPath, _sql );
                        var _connection = _csvQuery.DataConnection as OleDbConnection;
                        var _adapter = new OleDbDataAdapter( _sql, _connection );
                        _adapter?.Fill( _dataSet, sheetName );
                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public IEnumerable<DbParameter> GetParameters( Dictionary<string, object> dict )
        {
            if( dict?.Any( ) == true )
            {
                try
                {
                    return dict.Keys.Any( )
                        ? dict.ToSqlDbParameters( Provider )
                        : default( IEnumerable<DbParameter> );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<DbParameter> );
                }
            }

            return default( IEnumerable<DbParameter> );
        }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <param name="adapter">The adapter.</param>
        /// <returns></returns>
        private SQLiteCommandBuilder GetCommandBuilder( SQLiteDataAdapter adapter )
        {
            try
            {
                return new SQLiteCommandBuilder( adapter );
            }
            catch( SystemException _ex )
            {
                Fail( _ex );
                return default( SQLiteCommandBuilder );
            }
        }

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns></returns>
        private string GetExcelFilePath( )
        {
            try
            {
                var _fileName = "";
                var _fileDialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"C:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( _fileDialog.ShowDialog( ) == DialogResult.OK )
                {
                    _fileName = _fileDialog.FileName;
                }

                return _fileName;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( string );
            }
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="dataSchema">The data schema.</param>
        /// <returns></returns>
        private bool CheckIfSheetNameExists( string sheetName, DataTable dataSchema )
        {
            if( !string.IsNullOrEmpty( sheetName )
               && ( dataSchema != null )
               && ( dataSchema.Columns.Count > 0 ) )
            {
                for( var _i = 0; _i < dataSchema.Rows.Count; _i++ )
                {
                    var _dataRow = dataSchema.Rows[ _i ];
                    if( sheetName == _dataRow[ "TABLENAME" ].ToString( ) )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the database.
        /// </summary>
        private void CreateDatabase( )
        {
            var _commandText = @"CREATE TABLE IF NOT EXISTS [MyTable] 
                                    ( [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [Key] NVARCHAR(2048)  NULL,
                                      [Value] VARCHAR(2048)  NULL )";

            using var _connection = new SQLiteConnection( "Data source=databaseFile.db" );
            var _cmd = new SQLiteCommand( _connection );
            _connection.Open( );
            _cmd.CommandText = _commandText;
            _cmd.ExecuteNonQuery( );
            _cmd.CommandText = "INSERT INTO MyTable ( Key,Value ) VALUES ( 'key one','value one' )";
            _cmd.ExecuteNonQuery( );
            _cmd.CommandText = "INSERT INTO MyTable ( Key,Value ) VALUES ( 'key two','value value' )";
            _cmd.ExecuteNonQuery( );
            _cmd.CommandText = "SELECT * FROM MyTable";
            _cmd.ExecuteReader( );
            _connection.Close( );
        }
        
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c> true </c>
        /// to release both managed and unmanaged resources;
        /// <c> false </c>
        /// to release only unmanaged resources.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                base.Dispose( disposing );
            }

            IsDisposed = true;
        }
    }
}