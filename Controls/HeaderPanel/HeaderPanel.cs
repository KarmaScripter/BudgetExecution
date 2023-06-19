﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="HeaderPanel.cs" company="Terry D. Eppler">
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
//   HeaderPanel.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using CBComponents;

    /// <summary>
    /// </summary>
    /// <seealso cref="CBComponents.HeaderTableLayoutPanel"/>
    public class HeaderPanel : HeaderTableLayoutPanel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HeaderPanel"/>
        /// class.
        /// </summary>
        public HeaderPanel( )
        {
            BackColor = Color.FromArgb( 20, 20, 20 );
            ForeColor = Color.DarkGray;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            Font = new Font( "Roboto", 9 );
            ColumnCount = 1;
            RowCount = 1;
            CaptionStyle = HighlightCaptionStyle.NavisionAxaptaStyle;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HeaderPanel"/>
        /// class.
        /// </summary>
        /// <param name="header"> The header. </param>
        public HeaderPanel( string header )
            : this( )
        {
            CaptionText = header;
        }
    }
}