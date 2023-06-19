﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 04-22-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="IGrid.cs" company="Terry D. Eppler">
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
//   IGrid.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using OfficeOpenXml;

    public interface IGrid
    {
        /// <summary> The range </summary>
        ExcelRange Range { get; set; }

        /// <summary> The workSheet </summary>
        ExcelWorksheet Worksheet { get; set; }

        /// <summary> The address </summary>
        ExcelAddress Address { get; set; }

        /// <summary> Gets or sets from. </summary>
        /// <value> From. </value>
        ( int Row, int Column ) From { get; set; }

        /// <summary> Gets or sets to. </summary>
        /// <value> To. </value>
        ( int Row, int Column ) To { get; set; }

        /// <summary> Counts the cells. </summary>
        /// <param name = "range" > The range. </param>
        /// <returns> </returns>
        int CountCells( ExcelRange range );

        /// <summary> Gets the row count. </summary>
        /// <returns> </returns>
        int GetRowCount( );

        /// <summary> Gets the column count. </summary>
        /// <returns> </returns>
        int GetColumnCount( );
    }
}