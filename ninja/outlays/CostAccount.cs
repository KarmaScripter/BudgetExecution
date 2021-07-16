// <copyright file = "CostAccount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Cost"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class CostAccount : Cost, ICostAccount
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The PRC
        /// </summary>
        private protected readonly IProgramResultsCode prc;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "CostAccount"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public CostAccount( DataRow data )
        {
            Record = data;
            prc = new ProgramResultsCode( data );
            ID = new Key( Record, PrimaryKey.PrcId );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DocumentType = new Element( Record, Field.DocumentType );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DCN = new Element( Record, Field.DocumentType );
            OriginalActionDate = new Time( Record, EventDate.OriginalActionDate );
            ObligatingDocumentNumber = new Element( Record, Field.ObligatingDocumentNumber );
            System = new Element( Record, Field.System );
            TransactionNumber = new Element( Record, Field.TransactionNumber );
            GrantNumber = new Element( Record, Field.GrantNumber );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            ULO = new Amount( Record, Numeric.ULO );
            Balance = new Amount( Record, Numeric.Balance );
            Data = Record?.ToDictionary();
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the PRC identifier.
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
        /// Gets the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFinanceObjectClass GetFinanceObjectClass()
        {
            try
            {
                var code = FocCode?.GetValue();

                return Verify.Input( code )
                    ? new FinanceObjectClass( code )
                    : default( FinanceObjectClass );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IFinanceObjectClass );
            }
        }

        /// <summary>
        /// Gets the national program.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                return Verify.Input( NpmCode?.GetValue() )
                    ? new NationalProgram( NpmCode?.GetValue() )
                    : default( NationalProgram );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( INationalProgram );
            }
        }

        /// <summary>
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramResultsCode GetProgramResultsCode()
        {
            try
            {
                return prc?.GetAmount()?.GetFunding() > 0.0
                    ? prc
                    : default( IProgramResultsCode );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramResultsCode );
            }
        }

        /// <summary>
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramProject GetProgramProject()
        {
            try
            {
                return Verify.Input( ProgramProjectCode?.GetValue() )
                    ? new ProgramProject( ProgramProjectCode?.GetValue() )
                    : default( ProgramProject );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramProject );
            }
        }

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramArea GetProgramArea()
        {
            try
            {
                return Verify.Input( ProgramAreaCode?.GetValue() )
                    ? new ProgramArea( ProgramAreaCode?.GetValue() )
                    : default( ProgramArea );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramArea );
            }
        }
    }
}
