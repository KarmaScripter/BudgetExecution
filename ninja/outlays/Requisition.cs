// <copyright file = "Requisition.cs" company = "Terry D. Eppler">
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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Commitment"/>
    public class Requisition : RequisitionData
    {
        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        public Requisition()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Requisition( IQuery query )
            : base( query )
        {
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.RequisitionId );
            DCN = new Element( Record, Field.DCN );
            RequestNumber = new Element( Record, Field.RequestNumber );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            RequestDate = new Time( Record, EventDate.RequestDate );
            DocumentDate = new Time( Record, EventDate.DocumentDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Requested = new Amount( Record, Numeric.Requested );
            Closed = new Amount( Record, Numeric.Closed );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The builder.
        /// </param>
        public Requisition( IBuilder db )
            : base( db )
        {
            Record = db.GetRecord();
            ID = new Key( Record, PrimaryKey.RequisitionId );
            DCN = new Element( Record, Field.DCN );
            RequestNumber = new Element( Record, Field.RequestNumber );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            RequestDate = new Time( Record, EventDate.RequestDate );
            DocumentDate = new Time( Record, EventDate.DocumentDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Requested = new Amount( Record, Numeric.Requested );
            Closed = new Amount( Record, Numeric.Closed );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Requisition( DataRow data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.RequisitionId );
            DCN = new Element( Record, Field.DCN );
            RequestNumber = new Element( Record, Field.RequestNumber );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            RequestDate = new Time( Record, EventDate.RequestDate );
            DocumentDate = new Time( Record, EventDate.DocumentDate );
            ClosedDate = new Time( Record, EventDate.ClosedDate );
            Requested = new Amount( Record, Numeric.Requested );
            Closed = new Amount( Record, Numeric.Closed );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.Requisitions;

        /// <summary>
        /// Gets the requisition identifier.
        /// </summary>
        /// <value>
        /// The requisition identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the requisition identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the requisition code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRequisitionCode()
        {
            try
            {
                return Verify.Input( AccountCode.GetValue() )
                    ? AccountCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetModifiedBy()
        {
            try
            {
                return Verify.Input( ModifiedBy.GetValue() )
                    ? ModifiedBy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectCode()
        {
            try
            {
                return Verify.Input( ProjectCode.GetValue() )
                    ? ProjectCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the request date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetRequestDate()
        {
            try
            {
                return RequestDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCreatedBy()
        {
            try
            {
                return Verify.Input( CreatedBy.GetValue() )
                    ? CreatedBy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetDocumentDate()
        {
            try
            {
                return DocumentDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetClosedDate()
        {
            try
            {
                return ClosedDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the requested amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetRequestedAmount()
        {
            try
            {
                return Requested.GetFunding() > -1
                    ? Requested
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the closed amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetClosedAmount()
        {
            try
            {
                return Closed.GetFunding() > -1
                    ? Closed
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the outstanding amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetOutstandingAmount()
        {
            try
            {
                return Outstanding.GetFunding() > -1
                    ? Outstanding
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the expended amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetExpendedAmount()
        {
            try
            {
                return Expended.GetFunding() > -1
                    ? Expended
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the reversal amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetReversalAmount()
        {
            try
            {
                return Reversed.GetFunding() > -1
                    ? Reversed
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public new IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}
