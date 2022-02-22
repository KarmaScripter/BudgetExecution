﻿// <copyright file = "BudgetCurrencyTextBox.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>
//

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    public class BudgetCurrencyTextBox : CurrencyBoxBase
    {
        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="BudgetCurrencyTextBox"/> class.
        /// </summary>
        /// <remarks>
        /// The CurrencyEdit class also creates
        /// the controls that it hosts such
        /// as the
        /// <see cref="T:Syncfusion.Windows.Forms.Tools.CurrencyTextBox" />
        /// control and the
        /// <see cref="T:Syncfusion.Windows.Forms.Tools.PopupCalculator" />
        /// control.
        /// </remarks>
        public BudgetCurrencyTextBox()
        {
            // Basic Properties
            Size = new Size( 140, 30 );
            Location = new Point( 1, 1 );
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Dock = DockStyle.None;
            Margin = new Padding( 3 );
            Padding = new Padding( 1 );
            Font = new Font( "Roboto", 9 );
            ForeColor = Color.LightSteelBlue;
            Enabled = true;
            Visible = true;
            Text = string.Empty;
            Border3DStyle = Border3DStyle.Flat;
            PopupCalculatorAlignment = CalculatorPopupAlignment.Right;
            FlatStyle = FlatStyle.Flat;
            ShowCalculator = true;
            TextAlign = HorizontalAlignment.Center;

            // TextBox Properties
            TextBox.CurrencyDecimalDigits = 2;
            TextBox.NegativeColor = Color.Red;
            TextBox.PositiveColor = Color.LightSteelBlue;
            TextBox.BackGroundColor = Color.FromArgb( 18, 18, 18 );
            TextBox.Border3DStyle = Border3DStyle.Flat;
            TextBox.ThemeStyle = CurrencyTextBoxVisualStyle.DefaultStyle;
            TextBox.BorderColor = Color.FromArgb( 64, 64, 64 );
            TextBox.BorderStyle = BorderStyle.Fixed3D;
            TextBox.CurrencyDecimalSeparator = ".";
            TextBox.CurrencyGroupSeparator = ",";
            TextBox.FocusBorderColor = Color.SteelBlue;
            TransferFromCalculator = true;
            TransferToCalculator = true;

            // TextBox ThemeStyle Properties
            ThemeStyle.BackColor = Color.FromArgb( 18, 18, 18 );
            ThemeStyle.BorderColor = Color.FromArgb( 64, 64, 64 );
            ThemeStyle.DisabledBackColor = Color.FromArgb( 18, 18, 18 );
            ThemeStyle.DisabledBorderColor  = Color.FromArgb( 18, 18, 18 );
            ThemeStyle.HoverBorderColor = Color.SteelBlue;
            ThemeStyle.FocusedBorderColor = Color.SteelBlue;
            ThemeStyle.PressedBorderColor = Color.SteelBlue;
        }
    }
}
