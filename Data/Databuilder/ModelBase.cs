﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ModelBase.cs" company="Terry D. Eppler">
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
//   ModelBase.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:BudgetExecution.DataAccess" />
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    public abstract class ModelBase : DataAccess
    {
        /// <summary>
        /// Gets the ordinals.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<int> GetOrdinals( )
        {
            if( DataTable?.Columns?.Count > 0 )
            {
                try
                {
                    var _columns = DataTable.Columns;
                    var _values = new List<int>( );
                    if( _columns?.Count > 0 )
                    {
                        foreach( DataColumn _column in _columns )
                        {
                            _values?.Add( _column.Ordinal );
                        }
                    }

                    return _values?.Any( ) == true
                        ? _values
                        : default( IEnumerable<int> );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<int> );
                }
            }

            return default( IEnumerable<int> );
        }

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Type> GetColumnSchema( )
        {
            if( DataTable?.Columns?.Count > 0 )
            {
                try
                {
                    var _columns = DataTable?.Columns;
                    if( _columns?.Count > 0 )
                    {
                        var _schema = new Dictionary<string, Type>( );
                        foreach( DataColumn _col in _columns )
                        {
                            _schema.Add( _col.ColumnName, _col.DataType );
                        }

                        return _schema?.Any( ) == true
                            ? _schema
                            : default( IDictionary<string, Type> );
                    }
                    else
                    {
                        return default( IDictionary<string, Type> );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IDictionary<string, Type> );
                }
            }

            return default( IDictionary<string, Type> );
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public IEnumerable<DataRow> FilterData( IEnumerable<DataRow> dataRows, 
            IDictionary<string, object> dict )
        {
            if( ( dict?.Any( ) == true )
               && ( dataRows?.Any( ) == true ) )
            {
                try
                {
                    var _criteria = dict.ToCriteria( );
                    var _dataTable = dataRows.CopyToDataTable( );
                    var _data = _dataTable.Select( _criteria );
                    return _data?.Length > 0
                        ? _data
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the data columns.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataColumn> GetDataColumns( )
        {
            if( DataTable?.Columns?.Count > 0 )
            {
                try
                {
                    var _dataColumns = new List<DataColumn>( );
                    var _data = DataTable?.Columns;
                    if( _data?.Count > 0 )
                    {
                        foreach( DataColumn _column in _data )
                        {
                            if( _column != null )
                            {
                                _dataColumns.Add( _column );
                            }
                        }

                        return _dataColumns?.Any( ) == true
                            ? _dataColumns
                            : default( IEnumerable<DataColumn> );
                    }
                    else
                    {
                        return default( IEnumerable<DataColumn> );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<DataColumn> );
                }
            }

            return default( IEnumerable<DataColumn> );
        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetColumnNames( )
        {
            if( DataTable?.Columns?.Count > 0 )
            {
                try
                {
                    var _names = new List<string>( );
                    var _data = DataTable?.Columns;
                    if( _data?.Count > 0 )
                    {
                        foreach( DataColumn _column in _data )
                        {
                            if( !string.IsNullOrEmpty( _column?.ColumnName ) )
                            {
                                _names.Add( _column.ColumnName );
                            }
                        }

                        return _names?.Any( ) == true
                            ? _names
                            : default( IEnumerable<string> );
                    }
                    else
                    {
                        return default( IEnumerable<string> );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }
    }
}