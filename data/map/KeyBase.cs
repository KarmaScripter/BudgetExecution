﻿// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Unit" />
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class KeyBase : Unit
    {
        /// <summary>
        /// The primary key
        /// </summary>
        public PrimaryKey PrimaryKey { get; set; }

        /// <summary>
        /// The index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( string keyName )
        {
            if( Verify.Input( keyName ) )
            {
                try
                {
                    var _key = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyName );

                    PrimaryKey = Enum.IsDefined( typeof( PrimaryKey ), _key )
                        ? PrimaryKey
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        private protected void SetPrimaryKey( DataRow dataRow )
        {
            if( Verify.Row( dataRow ) )
            {
                try
                {
                    var _columns = Enum.GetNames( typeof( PrimaryKey ) );

                    if( _columns?.Contains( dataRow[ 0 ]?.ToString() ) == true )
                    {
                        var _field = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), dataRow[ 0 ].ToString() );

                        var _names = dataRow.Table
                            ?.GetColumnNames();

                        PrimaryKey = _names?.Contains( _field.ToString() ) == true
                            ? _field
                            : PrimaryKey.NS;
                    }
                    else
                    {
                        PrimaryKey = PrimaryKey.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( PrimaryKey keyName )
        {
            try
            {
                PrimaryKey = Validate.Field( keyName )
                    ? keyName
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( DataRow dataRow, PrimaryKey keyName )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( keyName ) )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    PrimaryKey = _names?.Contains( keyName.ToString() ) == true
                        ? keyName
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the index.
        /// </summary>
        /// <param name="value">The value.</param>
        private protected void SetIndex( int value )
        {
            try
            {
                Index = value > -1
                    ? value
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the index.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="key">The key.</param>
        private protected void SetIndex( DataRow dataRow, PrimaryKey key )
        {
            if( Verify.Input( dataRow?.ItemArray )
                && Validate.PrimaryKey( key ) )
            {
                try
                {
                    var _names = dataRow?.Table
                        ?.GetColumnNames();

                    Index = _names?.Contains( key.ToString() ) == true
                        ? int.Parse( dataRow[ $"{key}" ].ToString() )
                        : (int)PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}