﻿// <copyright file = "FinanceObjectClass.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.IFinanceObjectClass" />
    /// <seealso cref="IProgram" />
    /// <seealso cref="BudgetExecution.ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedReadonlyField" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class FinanceObjectClass : DataUnit, IFinanceObjectClass, ISource
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; } = Source.FinanceObjectClass;

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public IKey ID { get; set; }
        
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public BOC Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceObjectClass"/> class.
        /// </summary>
        public FinanceObjectClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceObjectClass"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public FinanceObjectClass( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.FinanceObjectClassId );
            Name = new Element( Record, Field.Name ).Name;
            Code = new Element( Record, Field.Code ).Code;
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceObjectClass"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public FinanceObjectClass( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.FinanceObjectClassId );
            Name = new Element( Record, Field.Name ).Name;
            Code = new Element( Record, Field.Code ).Code;
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceObjectClass"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public FinanceObjectClass( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.FinanceObjectClassId );
            Name = new Element( Record, Field.Name ).Name;
            Code = new Element( Record, Field.Code ).Code;
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceObjectClass"/> class.
        /// </summary>
        /// <param name="focCode">The foc code.</param>
        public FinanceObjectClass( string focCode )
        {
            Record = new DataBuilder( Source, GetArgs( focCode ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.FinanceObjectClassId );
            Name = new Element( Record, Field.Name ).Name;
            Code = new Element( Record, Field.Code ).Code;
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            if( Verify.IsInput( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = code
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.IsInput( Code )
                    ? Code
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.IsMap( Data )
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
        
        /// <summary>
        /// Gets the finance object class.
        /// </summary>
        /// <returns></returns>
        public IFinanceObjectClass GetFinanceObjectClass()
        {
            try
            {
                return MemberwiseClone() as FinanceObjectClass;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FinanceObjectClass );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        Source ISource.GetSource()
        {
            try
            {
                return Verify.IsSource( Source )
                    ? Source
                    : Source.NS;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }
    }
}
