﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 07-14-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-14-2023
// ******************************************************************************************
// <copyright file="AsyncData.cs" company="Terry D. Eppler">
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
//
// </copyright>
// <summary>
//   AsyncData.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Exception = System.Exception;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:BudgetExecution.ISource" />
    /// <seealso cref="T:BudgetExecution.IProvider" />
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class AsyncState : AsyncBase
    {
        /// <summary>
        /// The query
        /// </summary>
        private protected IQuery _query;

        /// <summary>
        /// The record
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The keys
        /// </summary>
        private protected IList<int> _keys;

        /// <summary>
        /// The map
        /// </summary>
        private protected IDictionary<string, object> _map;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public IQuery Query
        {
            get
            {
                return _query;
            }
            private protected set
            {
                _query = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record
        {
            get
            {
                return _record;
            }
            private protected set
            {
                _record = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public IList<int> Keys
        {
            get
            {
                return _keys;
            }
            private protected set
            {
                _keys = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public IDictionary<string, object> Map
        {
            get
            {
                return _map;
            }
            private protected set
            {
                _map = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<DataTable> GetDataTableAsync( )
        {
            if( _query != null )
            {
                var _async = new TaskCompletionSource<DataTable>( );
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    _async.SetResult( _table );
                    return _table.Rows.Count > 0
                        ? _async.Task
                        : default( Task<DataTable> );
                }
                catch( Exception _ex )
                {
                    _async.SetException( _ex );
                    Fail( _ex );
                    return default( Task<DataTable> );
                }
            }

            return default( Task<DataTable> );
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the record asynchronous.
        /// </summary>
        /// <returns></returns>
        public DataRow GetRecord( )
        {
            try
            {
                var _table = GetDataTable( );
                var _data = _table.AsEnumerable( );
                var _row = _data.FirstOrDefault( );
                return _row?.ItemArray?.Length > 0
                    ? _row
                    : default( DataRow );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( DataRow );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable( )
        {
            if( _query != null )
            {
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    return _table?.Rows?.Count > 0
                        ? _table
                        : default( DataTable );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data set asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<DataSet> GetDataSetAsync( )
        {
            if( _query != null )
            {
                var _task = new TaskCompletionSource<DataSet>( );
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    _task.SetResult( _set );
                    return _set.Tables?.Count > 0
                        ? _task.Task
                        : default( Task<DataSet> );
                }
                catch( Exception _ex )
                {
                    _task.SetException( _ex );
                    Fail( _ex );
                    return default( Task<DataSet> );
                }
            }

            return default( Task<DataSet> );
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void SetColumnCaptions( DataTable dataTable )
        {
            if( dataTable?.Rows?.Count > 0 )
            {
                try
                {
                    foreach( DataColumn _column in dataTable.Columns )
                    {
                        if( _column != null )
                        {
                            var _caption = _column.ColumnName.SplitPascal( );
                            _column.Caption = _caption;
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the fields asynchronous.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetFields( )
        {
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( _col.DataType == typeof( string ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the numerics asynchronous.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetNumerics( )
        {
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( ( !_col.ColumnName.EndsWith( "Id" )
                           && ( _col.Ordinal > 0 )
                           && ( _col.DataType == typeof( double ) ) )
                       || ( _col.DataType == typeof( short ) )
                       || ( _col.DataType == typeof( long ) )
                       || ( _col.DataType == typeof( decimal ) )
                       || ( _col.DataType == typeof( float ) ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the dates asynchronous.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetDates( )
        {
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( ( _col.Ordinal > 0 )
                       && ( ( _col.DataType == typeof( DateTime ) )
                           || ( _col.DataType == typeof( DateOnly ) )
                           || ( _col.DataType == typeof( DateTimeOffset ) )
                           || _col.ColumnName.EndsWith( nameof( Day ) )
                           || _col.ColumnName.EndsWith( "Date" ) ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the primary keys asynchronous.
        /// </summary>
        /// <returns></returns>
        public IList<int> GetPrimaryKeys( )
        {
            try
            {
                var _table = GetDataTable( );
                var _values = _table?.AsEnumerable( )
                    ?.Select( c => c.Field<int>( 0 ) )
                    ?.Distinct( );

                var _list = _values?.ToList( );
                return _list?.Any( ) == true
                    ? _list
                    : default( IList<int> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<int> );
            }
        }
    }
}