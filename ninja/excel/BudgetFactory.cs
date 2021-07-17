// <copyright file = "BudgetFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // **********************************************************   ASSEMBLIES   ************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedVariable" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class BudgetFactory
    {
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The budget
        /// </summary>
        private readonly ExcelBudget _budget;

        /// <summary>
        /// The worksheet
        /// </summary>
        private readonly ExcelWorksheet _worksheet;

        // ***************************************************************************************************************************
        // *******************************************************   CONSTRUCTORS ****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetFactory"/> class.
        /// </summary>
        /// <param name = "excelbudget" >
        /// The excelbudget.
        /// </param>
        public BudgetFactory( ExcelBudget excelbudget )
        {
            _budget = excelbudget;
            _worksheet = _budget.GetWorkSheet();
            Allocation = _budget.GetAllocation();
            Authority = Allocation.GetAuthority();
        }

        // ***************************************************************************************************************************
        // *******************************************************  PROPERTIES  ******************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <value>
        /// The allocation.
        /// </value>
        private IAllocation Allocation { get; }

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        private IAuthority Authority { get; }

        // **************************************************************************************************************************
        // ******************************************************     METHODS   *****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the epm worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetEpmWorksheet()
        {
            var funds = Allocation.GetFunds();
            var awards = Allocation.GetAwards();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.B}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var hdr = grid.From.Row - 1;
                    var fund = new Fund( $"{FundCode.B}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var prcdata = Allocation.GetData()
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.B}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( f => f.Field<string>( $"{Field.AccountCode}" ), f => f );

                    var start = grid.From.Row;

                    foreach( var kvp in prcdata )
                    {
                        _budget.SetAllocationTableFormat( grid, fund );
                        _budget.PopulateAccountRows( grid, prcdata, kvp );
                        start++;
                    }

                    var endrow = start;

                    var query = awards.Where( a => a.GetFundCode().Equals( $"{FundCode.B}" ) )
                        .Select( a => a );

                    if( query.Any() )
                    {
                        _budget.SetAwardsHeaderFormat( grid );
                        _budget.SetAwardRowsFormat( grid, fund );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.B}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the stag worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetStagWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.E}" ) ) )
            {
                try
                {
                    var code = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.E}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.E}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the lust worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetLustWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.F}" ) ) )
            {
                try
                {
                    var code = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.F}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.F}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.Equals( $"{FundCode.F}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the oil worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetOilWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.H}" ) ) )
            {
                try
                {
                    var fund = new Fund( $"{FundCode.H}" );

                    var code = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.H}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.H}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.H}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the deep water horizon worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetDeepWaterHorizonWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.ZL}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var i = grid.From.Row;
                    var hdr = i - 1;
                    var fund = new Fund( $"{FundCode.ZL}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var code = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.ZL}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .Select( f => f )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    foreach( var kvp in code )
                    {
                        _budget.SetAllocationTableFormat( grid, fund );
                        _budget.PopulateAccountRows( grid, code, kvp );
                        i++;
                    }

                    _budget.SetSummaryFormat( grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.ZL}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the superfund worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetSuperfundWorksheet()
        {
            var prc = Allocation.GetData();
            var awards = Allocation.GetAwards();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.T}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var i = grid.From.Row;
                    var hdr = i - 1;
                    var fund = new Fund( $"{FundCode.T}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var sfcodes = prc.Where( p => p.Field<string>( $"{Field.AhCode}" ).Equals( "06" ) )
                        .Where( p => p.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.T}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    foreach( var kvv in sfcodes )
                    {
                        _budget.SetAllocationTableFormat( grid, fund );
                        _budget.PopulateAccountRows( grid, sfcodes, kvv );
                        i++;
                    }

                    var endrow = i;
                    _budget.SetSummaryFormat( grid );

                    if( awards.Where( a => a.GetFundCode().Equals( $"{FundCode.H}" ) )
                        .Select( a => a )
                        .Any() )
                    {
                        _budget.SetAwardsHeaderFormat( grid );
                        _budget.SetAwardRowsFormat( grid, fund );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().StartsWith( $"{FundCode.T}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the s f6 a worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetSF6AWorksheet()
        {
            var prc = Allocation.GetData();
            var ahquery = Allocation.GetBuilder().ProgramElements[ Field.AhCode.ToString() ];

            if( ahquery.Any( f => f.Equals( "6A" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var i = grid.From.Row;
                    var hdr = i - 1;
                    var fund = new Fund( $"{FundCode.T}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var code = prc.Where( p => p.Field<string>( $"{Field.AhCode}" ).Equals( "6A" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.OrgCode}" ), p => p );

                    foreach( var kvp in code )
                    {
                        var dict = new Dictionary<string, object>
                        {
                            [ $"{Field.AhCode}" ] = "6A"
                        };

                        var connectbuilder =
                            new ConnectionBuilder( Source.AllowanceHolders, Provider.SQLite );

                        var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                        var query = new Query( connectbuilder, sqlstatement );
                        _budget.SetAllocationTableFormat( grid, fund, new AllowanceHolder( query ) );
                        _budget.PopulateAccountRows( grid, code, kvp );
                        i++;
                    }

                    _budget.SetSummaryFormat( grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !ahquery.Any( f => f.Equals( "6A" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the special accounts worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetSpecialAccountsWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().GetValue().Contains( $"{FundCode.TR}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var row = grid.From.Row;
                    var hdr = row - 1;

                    var codes = prc
                        .Where( p => p.Field<string>( $"{Field.FundCode}" ).Contains( $"{FundCode.TR}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .Select( p => p )
                        .ToArray();

                    var fund = new Fund( $"{FundCode.TR}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    for( var i = 0; i < codes.Length; i++ )
                    {
                        var _ = codes[ i ];

                        var accounts = prc
                            .Where( p =>
                                p.Field<string>( $"{Field.FundCode}" ).StartsWith( $"{FundCode.TR}" ) )
                            .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                            .Select( p => p )
                            .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                        foreach( var kvp in accounts )
                        {
                            _budget.SetAllocationTableFormat( grid, fund );
                            _budget.PopulateAccountRows( grid, accounts, kvp );
                            row++;
                        }

                        var endrow = row;
                        _budget.SetSummaryFormat( grid );
                    }

                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().GetValue().Contains( $"{FundCode.TR}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the superfund supplement worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetSuperfundSupplementWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds.Any( p => p.GetCode().Equals( $"{FundCode.TS3}" ) ) )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var i = grid.From.Row;
                    var hdr = i - 1;
                    var fund = new Fund( $"{FundCode.TS3}" );
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    _budget.SetBudgetHeaderFormat( grid, fund, Allocation.GetBudgetFiscalYear() );

                    var code = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.TS3}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    foreach( var kvp in code )
                    {
                        _budget.SetNonSiteHeaderFormat( grid, fund );
                        _budget.PopulateAccountRows( grid, code, kvp );
                        i++;
                    }

                    _budget.SetSummaryFormat( grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds.Any( p => p.GetCode().Equals( $"{FundCode.TS3}" ) ) )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Gets the lust supplemental worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetLustSupplementalWorksheet()
        {
            var prc = Allocation.GetData();
            var funds = Allocation.GetFunds();

            if( funds?.Any( p => p.GetCode().Equals( $"{FundCode.FS3}" ) ) == true )
            {
                try
                {
                    var grid = new Grid( _worksheet, ( 10, 2 ) );
                    var i = grid.From.Row;
                    var hdr = i - 1;
                    _budget.SetWorksheetProperties( grid.GetWorksheet() );
                    var fund = new Fund( $"{FundCode.FS3}" );

                    var data = prc
                        .Where( f => f.Field<string>( $"{Field.FundCode}" ).Equals( $"{FundCode.FS3}" ) )
                        .Where( f => f.Field<string>( $"{Field.BocCode}" ) != $"{BOC.FTE}" )
                        .Select( f => f )
                        .ToArray();

                    var lookup = data.ToLookup( p => p.Field<string>( $"{Field.AccountCode}" ), p => p );

                    foreach( var group in lookup )
                    {
                        _budget.SetNonSiteHeaderFormat( grid, fund );
                        _budget.PopulateAccountRows( grid, lookup, group );
                        i++;
                    }

                    _budget.SetSummaryFormat( grid );
                    return _worksheet;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelWorksheet );
                }
            }

            if( !funds?.Any( p => p.GetCode().Equals( $"{FundCode.FS3}" ) ) == true )
            {
                _budget.HideWorksheet();
            }

            return default( ExcelWorksheet );
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
