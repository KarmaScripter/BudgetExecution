﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="FullTimeEquivalent.cs" company="Terry D. Eppler">
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
//   FullTimeEquivalent.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Full-time equivalent (FullTimeEquivalents) or whole time equivalent (WTE) is a unit that indicates
    /// the workload of an employed person (or student) in a way that makes workloads or class loads
    /// comparable across various contexts. FullTimeEquivalent is often used to measure a worker's or
    /// student's involvement in a project, or to track cost reductions in an organization. An
    /// FullTimeEquivalent of 1.0 is equivalent to a full-time worker or student, while an
    /// FullTimeEquivalent of 0.5 signals half of a full work or school load.
    /// </summary>
    /// <seealso cref="ProgramResultsCode"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class FullTimeEquivalent : OperatingPlan
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.FullTimeEquivalent"/>
        /// class.
        /// </summary>
        public FullTimeEquivalent( )
        {
            Source = Source.FullTimeEquivalents;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public FullTimeEquivalent( IQuery query )
            : base( query )
        {
            Source = Source.FullTimeEquivalents;
            Record = new DataBuilder( query ).Record;
            ID = int.Parse( Record[ "FullTimeEquivalentsId" ].ToString( ) );
            Data = Record.ToDictionary( );
            BFY = Record[ "BFY" ].ToString( );
            Efy = Record[ "EFY" ].ToString( );
            FundCode = Record[ "FundCode" ].ToString( );
            FundName = Record[ "FundName" ].ToString( );
            RpioCode = Record[ "RpioCode" ].ToString( );
            RpioName = Record[ "RpioName" ].ToString( );
            AhCode = Record[ "AhCode" ].ToString( );
            AhName = Record[ "AhName" ].ToString( );
            OrgCode = Record[ "OrgCode" ].ToString( );
            OrgName = Record[ "OrgName" ].ToString( );
            AccountCode = Record[ "AccountCode" ].ToString( );
            BocCode = Record[ "BocCode" ].ToString( );
            BocName = Record[ "BocName" ].ToString( );
            Amount = double.Parse( Record[ "Amount" ].ToString( ) ?? "0" );
            ProgramProjectCode = Record[ "ProgramProjectCode" ].ToString( );
            ProgramProjectName = Record[ "ProgramProjectName" ].ToString( );
            ProgramAreaCode = Record[ "ProgramAreaCode" ].ToString( );
            ProgramAreaName = Record[ "ProgramAreaName" ].ToString( );
            NpmCode = Record[ "NpmCode" ].ToString( );
            NpmName = Record[ "NpmName" ].ToString( );
            GoalCode = Record[ "GoalCode" ].ToString( );
            GoalName = Record[ "GoalName" ].ToString( );
            ObjectiveCode = Record[ "ObjectiveCode" ].ToString( );
            ObjectiveName = Record[ "ObjectiveName" ].ToString( );
            TreasuryAccountCode = Record[ "TreasuryAccountCode" ].ToString( );
            TreasuryAccountName = Record[ "TreasuryAccountName" ].ToString( );
            BudgetAccountCode = Record[ "BudgetAccountCode" ].ToString( );
            BudgetAccountName = Record[ "BudgetAccountName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The databuilder. </param>
        public FullTimeEquivalent( IDataModel builder )
            : base( builder )
        {
            Source = Source.FullTimeEquivalents;
            Record = builder.Record;
            ID = int.Parse( Record[ "FullTimeEquivalentsId" ].ToString( ) );
            Data = Record.ToDictionary( );
            BFY = Record[ "BFY" ].ToString( );
            Efy = Record[ "EFY" ].ToString( );
            FundCode = Record[ "FundCode" ].ToString( );
            FundName = Record[ "FundName" ].ToString( );
            RpioCode = Record[ "RpioCode" ].ToString( );
            RpioName = Record[ "RpioName" ].ToString( );
            AhCode = Record[ "AhCode" ].ToString( );
            AhName = Record[ "AhName" ].ToString( );
            OrgCode = Record[ "OrgCode" ].ToString( );
            OrgName = Record[ "OrgName" ].ToString( );
            AccountCode = Record[ "AccountCode" ].ToString( );
            BocCode = Record[ "BocCode" ].ToString( );
            BocName = Record[ "BocName" ].ToString( );
            Amount = double.Parse( Record[ "Amount" ].ToString( ) ?? "0" );
            ProgramProjectCode = Record[ "ProgramProjectCode" ].ToString( );
            ProgramProjectName = Record[ "ProgramProjectName" ].ToString( );
            ProgramAreaCode = Record[ "ProgramAreaCode" ].ToString( );
            ProgramAreaName = Record[ "ProgramAreaName" ].ToString( );
            NpmCode = Record[ "NpmCode" ].ToString( );
            NpmName = Record[ "NpmName" ].ToString( );
            GoalCode = Record[ "GoalCode" ].ToString( );
            GoalName = Record[ "GoalName" ].ToString( );
            ObjectiveCode = Record[ "ObjectiveCode" ].ToString( );
            ObjectiveName = Record[ "ObjectiveName" ].ToString( );
            TreasuryAccountCode = Record[ "TreasuryAccountCode" ].ToString( );
            TreasuryAccountName = Record[ "TreasuryAccountName" ].ToString( );
            BudgetAccountCode = Record[ "BudgetAccountCode" ].ToString( );
            BudgetAccountName = Record[ "BudgetAccountName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public FullTimeEquivalent( DataRow dataRow )
            : base( dataRow )
        {
            Source = Source.FullTimeEquivalents;
            Record = dataRow;
            ID = int.Parse( dataRow[ "FullTimeEquivalentsId" ].ToString( ) );
            Data = dataRow.ToDictionary( );
            BFY = dataRow[ "BFY" ].ToString( );
            Efy = dataRow[ "EFY" ].ToString( );
            FundCode = dataRow[ "FundCode" ].ToString( );
            FundName = dataRow[ "FundName" ].ToString( );
            RpioCode = dataRow[ "RpioCode" ].ToString( );
            RpioName = dataRow[ "RpioName" ].ToString( );
            AhCode = dataRow[ "AhCode" ].ToString( );
            AhName = dataRow[ "AhName" ].ToString( );
            OrgCode = dataRow[ "OrgCode" ].ToString( );
            OrgName = dataRow[ "OrgName" ].ToString( );
            AccountCode = dataRow[ "AccountCode" ].ToString( );
            BocCode = dataRow[ "BocCode" ].ToString( );
            BocName = dataRow[ "BocName" ].ToString( );
            Amount = double.Parse( dataRow[ "Amount" ].ToString( ) ?? "0" );
            ProgramProjectCode = dataRow[ "ProgramProjectCode" ].ToString( );
            ProgramProjectName = dataRow[ "ProgramProjectName" ].ToString( );
            ProgramAreaCode = dataRow[ "ProgramAreaCode" ].ToString( );
            ProgramAreaName = dataRow[ "ProgramAreaName" ].ToString( );
            NpmCode = dataRow[ "NpmCode" ].ToString( );
            NpmName = dataRow[ "NpmName" ].ToString( );
            GoalCode = dataRow[ "GoalCode" ].ToString( );
            GoalName = dataRow[ "GoalName" ].ToString( );
            ObjectiveCode = dataRow[ "ObjectiveCode" ].ToString( );
            ObjectiveName = dataRow[ "ObjectiveName" ].ToString( );
            TreasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            TreasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            BudgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            BudgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }

        public FullTimeEquivalent( IAllocation allocation )
        {
            ID = allocation.ID;
            BudgetLevel = allocation.BudgetLevel;
            BFY = allocation.BFY;
            Efy = allocation.Efy;
            FundCode = allocation.FundCode;
            FundName = allocation.FundName;
            RpioCode = allocation.RpioCode;
            RpioName = allocation.RpioName;
            AhCode = allocation.AhCode;
            AhName = allocation.AhName;
            OrgCode = allocation.OrgCode;
            OrgName = allocation.OrgName;
            AccountCode = allocation.AccountCode;
            BocCode = allocation.BocCode;
            BocName = allocation.BocName;
            Amount = allocation.Amount;
            ProgramProjectCode = allocation.ProgramProjectCode;
            ProgramProjectName = allocation.ProgramProjectName;
            ProgramAreaCode = allocation.ProgramAreaCode;
            ProgramAreaName = allocation.ProgramAreaName;
            NpmCode = allocation.NpmCode;
            NpmName = allocation.NpmName;
            TreasuryAccountCode = allocation.TreasuryAccountCode;
            TreasuryAccountName = allocation.TreasuryAccountName;
            BudgetAccountCode = allocation.BudgetAccountCode;
            BudgetAccountName = allocation.BudgetAccountName;
        }

        /// <summary> Gets the ProgramResultCodes identifier. </summary>
        /// <returns> </returns>
        public override int GetId( DataRow dataRow )
        {
            try
            {
                return dataRow != null
                    ? int.Parse( dataRow[ 0 ].ToString( ) )
                    : -1;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( int );
            }
        }
    }
}