﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="DataBuilder.cs" company="Terry D. Eppler">
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
//   DataBuilder.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:BudgetExecution.DataModel" />
    /// <seealso cref="T:BudgetExecution.IDataModel" />
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class DataBuilder : DataModel, IDataModel
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        public DataBuilder( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public DataBuilder( Source source, Provider provider = Provider.Access )
            : base( source, provider )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="where">The dictionary.</param>
        public DataBuilder( Source source, Provider provider, IDictionary<string, object> where )
            : base( source, provider, where )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict"></param>
        public DataBuilder( Source source, IDictionary<string, object> dict )
            : base( source, dict )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="updates">The updates.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataBuilder( Source source, Provider provider, IDictionary<string, object> updates, 
            IDictionary<string, object> where, SQL commandType = SQL.UPDATE )
            : base( source, provider, updates, where, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The criteria.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataBuilder( Source source, Provider provider, IEnumerable<string> columns, 
            IDictionary<string, object> where, SQL commandType = SQL.SELECT )
            : base( source, provider, columns, where, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="fields">The columns.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataBuilder( Source source, Provider provider, IEnumerable<string> fields, 
            IEnumerable<string> numerics, IDictionary<string, object> where, SQL commandType )
            : base( source, provider, fields, numerics, where,
                commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="sqlText">The SQL text.</param>
        public DataBuilder( Source source, Provider provider, string sqlText )
            : base( source, provider, sqlText )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public DataBuilder( IQuery query )
            : base( query )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="sqlText">The SQL text.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataBuilder( string fullPath, string sqlText, SQL commandType = SQL.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.DataBuilder" /> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public DataBuilder( DataRow row )
        {
            Record = row;
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IEnumerable<DataRow> FilterData( string name, string value )
        {
            if( ( DataTable != null )
               && !string.IsNullOrEmpty( name )
               && !string.IsNullOrEmpty( value ) )
            {
                try
                {
                    var _query = DataTable.AsEnumerable( )
                        ?.Where( r => r.Field<string>( name ).Equals( value ) )
                        ?.Select( r => r );
                    
                    return _query?.Any( ) == true
                        ? _query.ToArray( )
                        : default( DataRow[ ] );
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
        /// Gets the series.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [ SuppressMessage( "ReSharper", "BadParensLineBreaks" ) ]
        public IDictionary<string, IEnumerable<string>> GetSeries( string name, string value )
        {
            if( ( DataTable != null )
               && !string.IsNullOrEmpty( name )
               && !string.IsNullOrEmpty( value ) )
            {
                try
                {
                    var _columns = DataTable.Columns;
                    var _rows = DataTable.AsEnumerable( );
                    var _dictionary = new Dictionary<string, IEnumerable<string>>( );
                    var _values = GetValues( _rows, name, value );
                    if( _values?.Any( ) == true )
                    {
                        for( var _i = 0; _i < _columns?.Count; _i++ )
                        {
                            var _columnName = _columns[ _i ].ColumnName;
                            if( !string.IsNullOrEmpty( _columnName )
                               && ( _columns[ _i ]?.DataType == typeof( string ) ) )
                            {
                                _dictionary.Add( _columns[ _i ].ColumnName, _values );
                            }
                        }

                        return _dictionary?.Any( ) == true
                            ? _dictionary
                            : default( Dictionary<string, IEnumerable<string>> );
                    }

                    return default( IDictionary<string, IEnumerable<string>> );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IDictionary<string, IEnumerable<string>> );
                }
            }

            return default( IDictionary<string, IEnumerable<string>> );
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Provider GetProvider( string provider )
        {
            if( !string.IsNullOrEmpty( provider ) )
            {
                try
                {
                    if( Enum.IsDefined( typeof( Provider ), provider ) )
                    {
                        return (Provider)Enum.Parse( typeof( Provider ), provider );
                    }
                    else if( Path.HasExtension( provider ) )
                    {
                        var _path = Path.GetExtension( provider );
                        var _ext = (EXT)Enum.Parse( typeof( EXT ), _path );
                        switch( _ext )
                        {
                            case EXT.MDB:
                            case EXT.XLS:
                            case EXT.XLSX:
                            case EXT.CSV:
                            case EXT.ACCDB:
                            {
                                return Provider.Access;
                            }
                            case EXT.SDF:
                            {
                                return Provider.SqlCe;
                            }
                            case EXT.MDF:
                            {
                                return Provider.SqlServer;
                            }
                            case EXT.DB:
                            {
                                return Provider.SQLite;
                            }
                            default:
                            {
                                return Provider.Access;
                            }
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( Provider );
                }
            }

            return default( Provider );
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="ext">The ext.</param>
        /// <returns></returns>
        public static Provider GetProvider( EXT ext )
        {
            if( Enum.IsDefined( typeof( EXT ), ext ) )
            {
                try
                {
                    switch( ext )
                    {
                        case EXT.MDB:
                        case EXT.ACCDB:
                        {
                            return Provider.Access;
                        }
                        case EXT.SDF:
                        {
                            return Provider.SqlCe;
                        }
                        case EXT.MDF:
                        {
                            return Provider.SqlServer;
                        }
                        case EXT.DB:
                        {
                            return Provider.SQLite;
                        }
                        default:
                        {
                            return Provider.Access;
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( Provider );
                }
            }

            return default( Provider );
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public static Source GetSource( string tableName )
        {
            if( !string.IsNullOrEmpty( tableName ) )
            {
                try
                {
                    var _names = Enum.GetNames( typeof( Source ) );
                    foreach( var _name in _names )
                    {
                        if( _name.Equals( tableName ) )
                        {
                            return (Source)Enum.Parse( typeof( Source ), tableName );
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( Source );
                }
            }

            return default( Source );
        }

        /// <inheritdoc />
        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="where">The dictionary.</param>
        /// <returns></returns>
        public IEnumerable<DataRow> FilterData( IDictionary<string, object> where )
        {
            if( ( where?.Any( ) == true )
               && ( DataTable != null ) )
            {
                try
                {
                    var _criteria = where.ToCriteria( );
                    var _data = DataTable.Select( _criteria );
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
    }
}