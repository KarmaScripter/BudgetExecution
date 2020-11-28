// // <copyright file = "IExcelBudget.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public interface IExcelBudget
    {
        /// <summary>
        /// Gets the control number.
        /// </summary>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "fy" >
        /// The fy.
        /// </param>
        /// <returns>
        /// </returns>
        IControlNumber GetControlNumber( IFund fund, IBudgetFiscalYear fy );

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        IAllocation GetAllocation();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Hides the worksheet.
        /// </summary>
        void HideWorksheet();

        /// <summary>
        /// Sets the name of the worksheet.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        void SetWorksheetName( string name );

        /// <summary>
        /// Gets the work sheet.
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelWorksheet GetWorkSheet();

        /// <summary>
        /// Sets the budget header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetBudgetHeaderFormat( Grid grid );

        /// <summary>
        /// Sets the non site header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "org" >
        /// The org.
        /// </param>
        void SetNonSiteHeaderFormat( Grid grid, IFund fund, IOrganization org = null );

        /// <summary>
        /// Sets the data configuration.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "org" >
        /// The org.
        /// </param>
        void SetDataConfiguration( Grid grid, IFund fund, IOrganization org );

        /// <summary>
        /// Sets the allocation table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "ah" >
        /// The ah.
        /// </param>
        void SetAllocationTableFormat( Grid grid, IFund fund, IAllowanceHolder ah = null );

        /// <summary>
        /// Sets the awards header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetAwardsHeaderFormat( Grid grid );

        /// <summary>
        /// Sets the budget header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        void SetBudgetHeaderFormat( Grid grid, IFund fund, IBudgetFiscalYear bfy );

        /// <summary>
        /// Sets the summary format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetSummaryFormat( Grid grid );

        /// <summary>
        /// Sets the award rows format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "fund" >
        /// The fund.
        /// </param>
        void SetAwardRowsFormat( Grid grid, IFund fund );

        /// <summary>
        /// Calculates the boc total.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <param name = "filter" >
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        double CalculateBocTotal( IEnumerable<DataRow> data, Field column, BOC filter );

        /// <summary>
        /// Populates the account rows.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <param name = "kvp" >
        /// The KVP.
        /// </param>
        void PopulateAccountRows( Grid grid, ILookup<string, DataRow> code,
            IGrouping<string, DataRow> kvp );

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name = "grid" >
        /// </param>
        /// <param name = "text" >
        /// The text.
        /// </param>
        void AddComment( Grid grid, string text );

        /// <summary>
        /// Sets the caption text.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetCaptionText( Grid grid );

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "text" >
        /// The text.
        /// </param>
        void SetText( Grid grid, IEnumerable<string> text );

        /// <summary>
        /// Sets the worksheet properties.
        /// </summary>
        /// <param name = "worksheet" >
        /// The worksheet.
        /// </param>
        void SetWorksheetProperties( ExcelWorksheet worksheet );

        /// <summary>
        /// Sets the worksheet header text.
        /// </summary>
        /// <param name = "headertext" >
        /// The headertext.
        /// </param>
        void SetHeaderFooterText( string headertext );

        /// <summary>
        /// Sets the table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetTableFormat( Grid grid );

        /// <summary>
        /// Sets the caption format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetCaptionFormat( Grid grid );

        /// <summary>
        /// Sets the dark row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetDarkRowFormat( Grid grid );

        /// <summary>
        /// Sets the light row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetLightRowFormat( Grid grid );

        /// <summary>
        /// Sets the alternating color format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetAlternatingColorFormat( Grid grid );

        /// <summary>
        /// Sets the numeric row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetNumericRowFormat( Grid grid );

        /// <summary>
        /// Sets the table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "font" >
        /// The font.
        /// </param>
        /// <param name = "borderstyle" >
        /// The borderstyle.
        /// </param>
        void SetTableFormat( Grid grid, Font font,
            ExcelBorderStyle borderstyle = ExcelBorderStyle.Thin );

        /// <summary>
        /// Sets the total row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void SetTotalRowFormat( Grid grid );

        /// <summary>
        /// Sets the width of the column.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "width" >
        /// The width.
        /// </param>
        void SetColumnWidth( Grid grid, double width );

        /// <summary>
        /// Sets the color of the backgroud.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "color" >
        /// The color.
        /// </param>
        void SetBackgroudColor( Grid grid, Color color );

        /// <summary>
        /// Sets the range font.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "font" >
        /// The font.
        /// </param>
        void SetRangeFont( Grid grid, Font font );

        /// <summary>
        /// Sets the color of the font.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "color" >
        /// The color.
        /// </param>
        void SetFontColor( Grid grid, Color color );

        /// <summary>
        /// Sets the border style.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "side" >
        /// The side.
        /// </param>
        /// <param name = "style" >
        /// The style.
        /// </param>
        void SetBorderStyle( Grid grid, ExcelSettings.BorderSide side, ExcelBorderStyle style );

        /// <summary>
        /// Sets the horizontal aligment.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "align" >
        /// The align.
        /// </param>
        void SetHorizontalAligment( Grid grid, ExcelHorizontalAlignment align );

        /// <summary>
        /// Sets the vertical aligment.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "align" >
        /// The align.
        /// </param>
        void SetVerticalAligment( Grid grid, ExcelVerticalAlignment align );

        /// <summary>
        /// Merges the cells.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        void MergeCells( Grid grid );
    }
}