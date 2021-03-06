// <copyright file = "TimeOff.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class TimeOff : Supplemental
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        public TimeOff()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public TimeOff( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.TimeOffId );
            FundCode = new Element( Record, Field.FundCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public TimeOff( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.TimeOffId );
            FundCode = new Element( Record, Field.FundCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TimeOff"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public TimeOff( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.TimeOffId );
            FundCode = new Element( Record, Field.FundCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        private protected override IElement Type { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.TimeOff;

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Map( Data ) )
            {
                try
                {
                    var data = new DataBuilder( Source, Data )?.GetData();

                    return Verify.Input( data )
                        ? data
                        : default( IEnumerable<DataRow> );
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
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
                return Verify.Input( Type?.GetValue() )
                    ? Type
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
