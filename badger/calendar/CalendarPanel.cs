﻿// <copyright file = "CalendarPanel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Drawing;
    using Syncfusion.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    public class CalendarPanel : MonthCalendarAdv
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "CalendarPanel"/>
        /// class.
        /// </summary>
        public CalendarPanel()
        {
            Size = SizeConfig.GetSize( 530, 375 );
            Location = ControlConfig.GetLocation();
            Font = FontConfig.FontSizeSmall;
            Margin = ControlConfig.Margin;
            ForeColor = ColorConfig.ForeGray;
            BackColor = ColorConfig.FormDarkBackColor;
            Dock = ControlConfig.GetDockStyle();
            Anchor = ControlConfig.GetAnchorStyle();
            Visible = true;
            Enabled = true;
            Style = VisualStyle.Office2010;
            Office2010Theme = Office2010Theme.Blue;
            Border3DStyle = Border3DStyle.Flat;
            BorderColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            FirstDayOfWeek = Day.Monday;
            BottomHeight = 30;
            DayNamesColor = ColorConfig.FormDarkBackColor;
            DayNamesFont = new Font( "Roboto", 10, FontStyle.Bold );
            DaysFont = FontConfig.FontSizeMedium;
            DaysColor = ColorConfig.FormDarkBackColor;
            DaysHeaderInterior = new BrushInfo( SystemColors.ControlDark );
            HeadForeColor = Color.White;
            HeaderHeight = 40;
            HeadGradient = false;
            HeaderFont = new Font( "Roboto", 12, FontStyle.Bold );
            HeaderStartColor = Color.FromArgb( 70, 70, 70 );
        }

        /// <summary> Gets or sets the binding source. </summary>
        /// <value> The binding source. </value>
        public BudgetBinding BindingSource { get; set; }

        /// <summary> Gets or sets the tool tip. </summary>
        /// <value> The tool tip. </value>
        public ToolTip ToolTip { get; set; }
    }
}