﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="AppropriationDocument.cs" company="Terry D. Eppler">
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
//   AppropriationDocument.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:BudgetExecution.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class AppropriationDocument : ControlDocument
    {
        /// <summary>
        /// Gets or sets the last document date.
        /// </summary>
        /// <value>
        /// The last document date.
        /// </value>
        public DateOnly LastActivityDate
        {
            get
            {
                return _lastActivityDate;
            }
            private protected set
            {
                _lastActivityDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the budgeted.
        /// </summary>
        /// <value>
        /// The budgeted.
        /// </value>
        public double Budgeted
        {
            get
            {
                return _budgeted;
            }
            private protected set
            {
                _budgeted = value;
            }
        }

        /// <summary>
        /// Gets or sets the posted.
        /// </summary>
        /// <value>
        /// The posted.
        /// </value>
        public double Posted
        {
            get
            {
                return _posted;
            }
            private protected set
            {
                _posted = value;
            }
        }

        /// <summary>
        /// Gets or sets the carryover out.
        /// </summary>
        /// <value>
        /// The carryover out.
        /// </value>
        public double CarryoverOut
        {
            get
            {
                return _carryoverOut;
            }
            private protected set
            {
                _carryoverOut = value;
            }
        }

        /// <summary>
        /// Gets or sets the carryover in.
        /// </summary>
        /// <value>
        /// The carryover in.
        /// </value>
        public double CarryoverIn
        {
            get
            {
                return _carryoverIn;
            }
            private protected set
            {
                _carryoverIn = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursements.
        /// </summary>
        /// <value>
        /// The reimbursements.
        /// </value>
        public double Reimbursements
        {
            get
            {
                return _reimbursements;
            }
            private protected set
            {
                _reimbursements = value;
            }
        }

        /// <summary>
        /// Gets or sets the recoveries.
        /// </summary>
        /// <value>
        /// The recoveries.
        /// </value>
        public double Recoveries
        {
            get
            {
                return _recoveries;
            }
            private protected set
            {
                _recoveries = value;
            }
        }

        /// <summary>
        /// Gets or sets the budgeting controls.
        /// </summary>
        /// <value>
        /// The budgeting controls.
        /// </value>
        public string BudgetingControls
        {
            get
            {
                return _budgetingControls;
            }
            private protected set
            {
                _budgetingControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the posting controls.
        /// </summary>
        /// <value>
        /// The posting controls.
        /// </value>
        public string PostingControls
        {
            get
            {
                return _postingControls;
            }
            private protected set
            {
                _postingControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the pre commitment controls.
        /// </summary>
        /// <value>
        /// The pre commitment controls.
        /// </value>
        public string PreCommitmentControls
        {
            get
            {
                return _preCommitmentControls;
            }
            private protected set
            {
                _preCommitmentControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the commitment controls.
        /// </summary>
        /// <value>
        /// The commitment controls.
        /// </value>
        public string CommitmentControls
        {
            get
            {
                return _commitmentControls;
            }
            private protected set
            {
                _commitmentControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the obligation controls.
        /// </summary>
        /// <value>
        /// The obligation controls.
        /// </value>
        public string ObligationControls
        {
            get
            {
                return _obligationControls;
            }
            private protected set
            {
                _obligationControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the accrual controls.
        /// </summary>
        /// <value>
        /// The accrual controls.
        /// </value>
        public string AccrualControls
        {
            get
            {
                return _accrualControls;
            }
            private protected set
            {
                _accrualControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the expenditure controls.
        /// </summary>
        /// <value>
        /// The expenditure controls.
        /// </value>
        public string ExpenditureControls
        {
            get
            {
                return _expenditureControls;
            }
            private protected set
            {
                _expenditureControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the expense controls.
        /// </summary>
        /// <value>
        /// The expense controls.
        /// </value>
        public string ExpenseControls
        {
            get
            {
                return _expenseControls;
            }
            private protected set
            {
                _expenseControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursement controls.
        /// </summary>
        /// <value>
        /// The reimbursement controls.
        /// </value>
        public string ReimbursementControls
        {
            get
            {
                return _reimbursementControls;
            }
            private protected set
            {
                _reimbursementControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursable agreement controls.
        /// </summary>
        /// <value>
        /// The reimbursable agreement controls.
        /// </value>
        public string ReimbursableAgreementControls
        {
            get
            {
                return _reimbursableAgreementControls;
            }
            private protected set
            {
                _reimbursableAgreementControls = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.AppropriationDocument" /> class.
        /// </summary>
        public AppropriationDocument( )
        {
            Source = Source.AppropriationDocuments;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public AppropriationDocument( IQuery query )
            : this( )
        {
            _id = int.Parse( _record[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public AppropriationDocument( IDataModel builder )
            : base( builder )
        {
            _id = int.Parse( _record[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public AppropriationDocument( DataRow dataRow ) 
            : base( dataRow )
        {
            _id = int.Parse( dataRow[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fund = dataRow[ "Fund" ].ToString( );
            _fundCode = dataRow[ "FundName" ].ToString( );
            _budgeted = double.Parse( dataRow[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( dataRow[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( dataRow[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( dataRow[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( dataRow[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( dataRow[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BudgetExecution.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="document">The document.</param>
        public AppropriationDocument( AppropriationDocument document )
        {
            ID = document.ID;
            BFY = document.BFY;
            EFY = document.EFY;
            Fund = document.Fund;
            FundCode = document.FundCode;
            DocumentType = document.DocumentType;
            DocumentNumber = document.DocumentNumber;
            ProcessedDate = document.ProcessedDate;
            BudgetingControls = document.BudgetingControls;
            PostingControls = document.PostingControls;
            PreCommitmentControls = document.PreCommitmentControls;
            CommitmentControls = document.CommitmentControls;
            ObligationControls = document.ObligationControls;
            AccrualControls = document.AccrualControls;
            ExpenditureControls = document.ExpenditureControls;
            Budgeted = document.Budgeted;
            Posted = document.Posted;
            CarryoverOut = document.CarryoverOut;
            CarryoverIn = document.CarryoverIn;
            Recoveries = document.Recoveries;
            Reimbursements = document.Reimbursements;
            TreasuryAccountCode = document.TreasuryAccountCode;
            TreasuryAccountName = document.TreasuryAccountName;
            BudgetAccountCode = document.BudgetAccountCode;
            BudgetAccountName = document.BudgetAccountName;
        }
    }
}