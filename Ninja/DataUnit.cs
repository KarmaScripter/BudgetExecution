﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 05-04-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="DataUnit.cs" company="Terry D. Eppler">
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
//   DataUnit.cs
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
    /// <seealso cref="T:BudgetExecution.IDataUnit" />
    /// <seealso cref="T:BudgetExecution.ISource" />
    /// <seealso cref="T:BudgetExecution.IProvider" />
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToReturnStatement" ) ]
    public abstract class DataUnit : IDataUnit
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private protected int _id;

        /// <summary>
        /// The name
        /// </summary>
        private protected string _name;

        /// <summary>
        /// The code
        /// </summary>
        private protected string _code;

        /// <summary>
        /// The record
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The value
        /// </summary>
        private protected object _value;

        /// <summary>
        /// </summary>
        /// <inheritdoc />
        public int ID
        {
            get
            {
                return _id;
            }
            private protected set
            {
                _id = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the field.
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            private protected set
            {
                _code = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            private protected set
            {
                _name = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get
            {
                return _value;
            }
            private protected set
            {
                _value = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
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
        /// </summary>
        public Provider Provider
        {
            get
            {
                return _provider;
            }
            private protected set
            {
                _provider = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the source.
        /// </summary>
        public Source Source
        {
            get
            {
                return _source;
            }
            private protected set
            {
                _source = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IDictionary<string, object> Data
        {
            get
            {
                return _data;
            }
            private protected set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        protected DataUnit( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="dataBuilder">The query.</param>
        protected DataUnit( IDataModel dataBuilder )
        {
            _source = dataBuilder.Source;
            _provider = dataBuilder.Provider;
            _record = dataBuilder.Record;
            _id = int.Parse( _record[ 0 ].ToString( ) ?? "0" );
            _data = _record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected DataUnit( IQuery query ) 
        {
            _source = query.Source;
            _provider = query.Provider;
            _record = new DataBuilder( query ).Record;
            _id = int.Parse( _record[ 0 ].ToString( ) ?? "0" );
            _data = _record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected DataUnit( DataRow dataRow ) 
        {
            _record = dataRow;
            _data = _record.ToDictionary( );
            _id = int.Parse( _record[ 0 ].ToString( ) ?? "0" );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="unit">The element.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public virtual bool IsMatch( IDataUnit unit )
        {
            try
            {
                ThrowIf.Null( unit, nameof( unit ) );
                if( ( unit.Code?.Equals( Code ) == true )
                   && unit.Name.Equals( Name ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified dictionary is match.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified dictionary is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public virtual bool IsMatch( IDictionary<string, object> dict )
        {
            try
            {
                ThrowIf.Null( dict, nameof( dict ) );
                var _keys = dict.Keys?.First( );
                var _vals = dict[ _keys ];
                return _vals.Equals( Code ) && _keys.Equals( Name );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified primary is match.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        ///   <c>true</c> if the specified primary is match;
        /// otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsMatch( IDataUnit primary, IDataUnit secondary )
        {
            try
            {
                ThrowIf.Null( primary, nameof( primary ) );
                ThrowIf.Null( secondary, nameof( secondary ) );
                if( primary.Code.Equals( secondary.Code )
                   && primary.Name.Equals( secondary.Name ) )
                {
                    return true;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }

            return false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns></returns>
        public virtual int GetId( )
        {
            try
            {
                return _record != null 
                    ? int.Parse( _record[ 0 ].ToString( ) ?? "0" )
                    : -1;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( int );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        public virtual int GetId( DataRow dataRow )
        {
            try
            {
                ThrowIf.Null( dataRow, nameof( dataRow ) );
                return int.Parse( dataRow[ 0 ].ToString( ) ?? "0" );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( int );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        protected static void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}