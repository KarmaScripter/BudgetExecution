﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ProgramResultsCode.cs" company="Terry D. Eppler">
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
//   ProgramResultsCode.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// Program Results Codes (PRCs) were established to account for and relate resources to the Agency's
    /// Strategic Plan goals and objectives, national program offices and responsibilities, and
    /// governmental functions. PRCs are created when the annual EPA Budget is submitted to Congress each
    /// February and then formally established in IFMS with the enactment of EPA's appropriation act. PRCs
    /// may be updated at any time.
    /// </summary>
    /// <seealso cref="T:BudgetExecution.IProgramResultsCode" />
    /// <seealso cref="T:BudgetExecution.IProgramResultsCode" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    public class ProgramResultsCode : StatusOfFunds 
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCode" />
        /// class.
        /// </summary>
        public ProgramResultsCode( )
        {
            _source = Source.StatusOfFunds;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCode" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public ProgramResultsCode( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _id = int.Parse( _record[ "StatusOfFundsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );

            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCode"/>
        /// class.
        /// </summary>
        /// <param name="dataBuilder"> The builder. </param>
        public ProgramResultsCode( IDataModel dataBuilder )
            : base( dataBuilder )
        {
            _record = dataBuilder.Record;
            _id = int.Parse( _record[ "StatusOfFundsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );

            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCodes" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public ProgramResultsCode( DataRow dataRow )
        {
            Record = dataRow;
            _id = int.Parse( dataRow[ "StatusOfFundsId" ].ToString( ) ?? "0" );
            _budgetLevel = dataRow[ "BudgetLevel" ].ToString( );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _rpioCode = dataRow[ "RpioCode" ].ToString( );
            _rpioName = dataRow[ "RpioName" ].ToString( );
            _ahCode = dataRow[ "AhCode" ].ToString( );
            _ahName = dataRow[ "AhName" ].ToString( );
            _orgCode = dataRow[ "OrgCode" ].ToString( );
            _orgName = dataRow[ "OrgName" ].ToString( );
            _accountCode = dataRow[ "AccountCode" ].ToString( );
            _bocCode = dataRow[ "BocCode" ].ToString( );
            _bocName = dataRow[ "BocName" ].ToString( );
            _amount = double.Parse( dataRow[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( dataRow[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( dataRow[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( dataRow[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _unliquidatedObligations =
                double.Parse( dataRow[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );

            _obligations = double.Parse( dataRow[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( dataRow[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( dataRow[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( dataRow[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = dataRow[ "ProgramProjectCode" ].ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ].ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ].ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ].ToString( );
            _npmCode = dataRow[ "NpmCode" ].ToString( );
            _npmName = dataRow[ "NpmName" ].ToString( );
            _goalCode = dataRow[ "GoalCode" ].ToString( );
            _goalName = dataRow[ "GoalName" ].ToString( );
            _objectiveCode = dataRow[ "ObjectiveCode" ].ToString( );
            _objectiveName = dataRow[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCodes" />
        /// class.
        /// </summary>
        /// <param name="dict"> </param>
        public ProgramResultsCode( IDictionary<string, object> dict ) 
            : this( )
        {
            _record = new DataBuilder( _source, dict )?.Record;
            _id = int.Parse( _record[ "StatusOfFundsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );

            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.ProgramResultsCodes" /> class.
        /// </summary>
        /// <param name="prc">The PRC.</param>
        public ProgramResultsCode( ProgramResultsCode prc )
        {
            ID = prc.ID;
            BFY = prc.BFY;
            EFY = prc.EFY;
            FundCode = prc.FundCode;
            FundName = prc.FundName;
            RpioCode = prc.RpioCode;
            RpioName = prc.RpioName;
            AhCode = prc.AhCode;
            AhName = prc.AhName;
            OrgCode = prc.OrgCode;
            OrgName = prc.OrgName;
            AccountCode = prc.AccountCode;
            BocCode = prc.BocCode;
            BocName = prc.BocName;
            ProgramProjectCode = prc.ProgramProjectCode;
            ProgramProjectName = prc.ProgramProjectName;
            ProgramAreaCode = prc.ProgramAreaCode;
            ProgramAreaName = prc.ProgramAreaName;
            Amount = prc.Amount;
            NpmCode = prc.NpmCode;
            NpmName = prc.NpmName;
            GoalCode = prc.GoalCode;
            GoalName = prc.GoalName;
            ObjectiveCode = prc.ObjectiveCode;
            ObjectiveName = prc.ObjectiveName;
        }
        
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString( )
        {
            return !string.IsNullOrEmpty( _accountCode )
                ? _accountCode
                : string.Empty;
        }
    }
}