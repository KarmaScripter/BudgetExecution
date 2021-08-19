﻿// <copyright file = "_awards.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    #region

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class Awards : Supplemental
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Awards;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        public Awards()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Awards( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.AwardsId );
            _fundCode = new Element( _records, Field.FundCode );
            _boc = new Element( _records, Field.BocCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "dataBuilder" >
        /// The databuilder.
        /// </param>
        public Awards( IBuilder dataBuilder )
        {
            _records = dataBuilder?.GetRecord();
            _id = new Key( _records, PrimaryKey.AwardsId );
            _fundCode = new Element( _records, Field.FundCode );
            _boc = new Element( _records, Field.BocCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Awards"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Awards( DataRow dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.AwardsId );
            _fundCode = new Element( _records, Field.FundCode );
            _boc = new Element( _records, Field.BocCode );
            _amount = GetAmount();
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return _type + _amount?.GetFunding().ToString( "c" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the awards dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( _data ) )
            {
                try
                {
                    var _rows = new Builder( _source, _data )
                        ?.GetData();

                    return _rows?.Any() == true
                        ? _rows
                        : default( IEnumerable<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetName()
        {
            try
            {
                return Enum.IsDefined( typeof( AwardType ), _type )
                    ? _type
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
    }
}
