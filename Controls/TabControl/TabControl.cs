﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="TabControl.cs" company="Terry D. Eppler">
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
//   TabControl.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.Tools.TabControlAdv" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class TabControl : TabControlAdv
    {
        /// <summary>
        /// Gets or sets the binding source.
        /// </summary>
        /// <value>
        /// The binding source.
        /// </value>
        public BindingSource BindingSource { get; set; }

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>
        /// The tool tip.
        /// </value>
        public SmallTip ToolTip { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabControl"/> class.
        /// </summary>
        public TabControl( )
        {
            TabStyle = typeof( TabRendererMetro );
            BackColor = Color.FromArgb( 20, 20, 20 );
            Size = new Size( 350, 500 );
            Font = new Font( "Roboto", 9 );
            ForeColor = Color.LightGray;
            BorderStyle = BorderStyle.None;
            CloseButtonBackColor = Color.FromArgb( 20, 20, 20 );
            CloseButtonForeColor = Color.FromArgb( 20, 20, 20 );
            CloseButtonHoverForeColor = Color.FromArgb( 20, 20, 20 );
            CloseButtonPressedForeColor = Color.FromArgb( 20, 20, 20 );
            SeparatorColor = Color.FromArgb( 20, 20, 20 );
            ShowSeparator = false;
            ItemSize = new Size( 100, 30 );
            TabPanelBackColor = Color.FromArgb( 20, 20, 20 );
            CanOverrideStyle = true;
            CanApplyTheme = true;
            ActiveTabColor = Color.FromArgb( 20, 20, 20 );
            ActiveTabFont = new Font( "Roboto", 8 );
            ActiveTabForeColor = Color.DarkGray;
            InActiveTabForeColor = Color.FromArgb( 20, 20, 20 );
            InactiveCloseButtonForeColor = Color.FromArgb( 20, 20, 20 );
            InactiveTabColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.BackColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.BorderFillColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.BorderColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.TabPanelBackColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.TabStyle.ActiveBackColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.TabStyle.ActiveFont = new Font( "Roboto", 8 );
            ThemeStyle.TabStyle.ActiveForeColor = Color.DarkGray;
            ThemeStyle.TabStyle.SeparatorColor = Color.FromArgb( 20, 20, 20 );
            ThemeStyle.TabStyle.ActiveBackColor = Color.FromArgb( 20, 20, 20 );
        }
    }
}