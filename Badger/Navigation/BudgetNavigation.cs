﻿//  <copyright file = "BudgetNavigation.cs" company = "Terry D. Eppler">
//  Copyright (c) Terry D. Eppler. All rights reserved.
//  copyright>
//

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Drawing;
    using Syncfusion.Windows.Forms;

    public partial class BudgetNavigation : MetroForm
    {   
         /// <summary>
         /// Gets or sets the settings.
         /// </summary>
         /// <value>
         /// The settings.
         /// </value>
         public virtual NameValueCollection Settings { get; set; } = ConfigurationManager.AppSettings;

         public BudgetNavigation()
         {
             InitializeComponent();
             BackColor = BudgetColor.FormDark;
             BorderThickness = BudgetBorder.Thin;
             BorderColor = BudgetColor.SteelBlue;
             Size = BudgetSize.FormSizeNormal;
             Font = BudgetFont.FontSizeSmall;
             CaptionBarColor = BudgetColor.FormDark;
             CaptionBarHeight = BudgetSize.CaptionSizeNormal;
             CaptionButtonColor = BudgetColor.CaptionButtonDefaultColor;
             CaptionButtonHoverColor = BudgetColor.White;
             CaptionAlign = BudgetAlign.HorizontalLeft;
             CaptionFont = BudgetFont.FontSizeMedium;
             MetroColor = BudgetColor.FormDark;
             FormBorderStyle = BudgetBorder.Sizeable;
             Icon = new Icon( Settings[ "BudgetExecutionIcon" ], 16, 16 );
             ShowIcon = false;
             ShowInTaskbar = true;
             Padding = BudgetControl.Padding;
             Text = string.Empty;
         }
    }
}