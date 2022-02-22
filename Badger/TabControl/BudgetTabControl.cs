﻿// <copyright file = "BudgetTabControl.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>
//

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    public class BudgetTabControl : TabControlBase
    {
        /// <summary>
        /// Initializes a new instance
        /// of the <see cref="BudgetTabControl"/> class.
        /// </summary>
        public BudgetTabControl()
        {
            Alignment = TabAlignment.Top;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Dock = DockStyle.None;
            Margin = new Padding( 3 );
            Font = new Font( "Roboto", 9  );
            ForeColor = Color.LightSteelBlue;
            BackColor = Color.FromArgb( 15, 15, 15 );
            TabPanelBackColor = Color.FromArgb( 15, 15, 15 );
            BorderStyle = BorderStyle.None;
            BorderColor = Color.FromArgb( 15, 15, 15 );
            BorderVisible = false;
            ThemesEnabled = true;
            ActiveTabColor = Color.SteelBlue;
            ActiveTabFont = new Font( "Roboto", 8, FontStyle.Regular  );
            ActiveTabForeColor = Color.White;
            InActiveTabForeColor = Color.FromArgb( 15, 15, 15 );
            InactiveTabColor = Color.FromArgb( 15, 15, 15 );
            SeparatorColor = Color.FromArgb( 64, 64, 64 );
            TextAlignment = StringAlignment.Center;
            VerticalAlignment = TabVerticalAlignment.Default;
            ThemesEnabled = false;
            ThemeStyle.BackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.DisabledBackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabPanelBackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.BorderColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.BorderFillColor = Color.FromArgb( 64, 64, 64 );
            ThemeStyle.TabStyle.DisabledBackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabStyle.ActiveBorderColor = Color.SteelBlue;
            ThemeStyle.TabStyle.ActiveBackColor = Color.SteelBlue;
            ThemeStyle.TabStyle.ActiveFont = new Font( "Roboto", 8, FontStyle.Regular );
            ThemeStyle.TabStyle.ActiveForeColor = Color.White;
            ThemeStyle.TabStyle.ActiveCloseButtonBackColor = Color.FromArgb( 64, 64, 64 );
            ThemeStyle.TabStyle.HoverActiveBorderColor = Color.SteelBlue;
            ThemeStyle.TabStyle.HoverActiveCloseButtonForeColor = Color.White;
            ThemeStyle.TabStyle.HoverInactiveCloseButtonForeColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabStyle.HoverInactiveForeColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabStyle.InactiveCloseButtonBackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabStyle.InactiveBackColor = Color.FromArgb( 15, 15, 15 );
            ThemeStyle.TabStyle.InactiveForeColor = Color.FromArgb( 15, 15, 15 );
            ShowSeparator = true;
            LabelEdit = false;
            Multiline = false;
            MultilineText = false;
            HotTrack = true;
            Enabled = true;
            Visible = true;
            ShowTabCloseButton = false;
            TextLineAlignment = StringAlignment.Center;
            UserMoveTabs = true;
        }
    }
}
