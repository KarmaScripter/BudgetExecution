﻿// // <copyright file = "BudgetInfo.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>
//

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using VisualPlus.Enumerators;
    using VisualPlus.Models;

    public class BudgetInfo : InfoBase
    {
        public BudgetInfo()
        {
            // Basic Properties
            Font = BudgetFont.FontSizeSmall;
            ForeColor = BudgetColor.LightBlue;
            BackColor = BudgetColor.ControlInteriorDark;
            Background = BudgetColor.ControlInteriorDark;
            Active = true;
            UseAnimation = true;
            UseFading = true;
            AutomaticDelay = 500;
            AutoPopDelay = 5000;
            IconSize = BudgetSize.ImageSizeSmall;
            InitialDelay = 500;
            AutoSize = true;
            LineColor = BudgetColor.LightBlue;
            IsBalloon = false;
            ReshowDelay = 100;
            SeparatorThickness = 1;
            ShowAlways = true;
            Spacing = 2;
            TipType = TipInfo.ToolTipType.Text;
            TextRendering = TextRenderingHint.ClearTypeGridFit;
            TitleFont = new Font( "Roboto", 10, FontStyle.Bold  );
            TitleColor = BudgetColor.White;
            TipIcon = ToolTipIcon.None;

            // Border Properties
            Border.HoverColor = BudgetColor.LightBlue;
            Border.Color = BudgetColor.SteelBlue;
            Border.HoverVisible = true;
            Border.Rounding = 6;
            Border.Thickness = 1;
            Border.Type = ShapeTypes.Rounded;
            Border.Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetInfo"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        public BudgetInfo( string text, string title ) 
            : this()
        {
            // Basic Properties
            Text = text;
            TipTitle = title;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetInfo"/> class.
        /// </summary>
        /// <param name = "control" > </param>
        /// <param name="text">The text.</param>
        public BudgetInfo( Control control, string text ) 
            : this()
        {
            // Basic Properties
            Text = text;
            TipTitle = control.Tag.ToString();
        }
    }
}
