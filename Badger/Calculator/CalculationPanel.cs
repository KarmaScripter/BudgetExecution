﻿// <copyright file = "CalculationPanel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Drawing;
    using Syncfusion.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.Tools.CalculatorControl" />
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    public class CalculationPanel : CalculatorBase, ICalculator
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        /// <remarks>
        /// The Value property is a shadow of the Calculator Engine's Value property.
        /// </remarks>
        public CalculatorValue Result { get; set; }

        /// <summary>
        /// Gets or sets the calculator text.
        /// </summary>
        /// <value>
        /// The calculator text.
        /// </value>
        public LabelPanel Label { get; set; }

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>
        /// The tool tip.
        /// </value>
        public ToolTip ToolTip { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CalculationPanel" />
        /// class.
        /// </summary>
        public CalculationPanel()
        {
            Size = SizeConfig.GetSize( 400, 400 );
            Location = ControlConfig.GetLocation();
            BackColor = ColorConfig.FormBackColorDark;
            ForeColor = ColorConfig.ForeColorGray;
            Margin = ControlConfig.Margin;
            Padding = ControlConfig.Padding;
            Font = FontConfig.FontSizeMedium;
            Anchor = ControlConfig.GetAnchorStyle();
            Visible = true;
            Enabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationPanel"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        public CalculationPanel( Size size, Point location )
            : this()
        {
            Size = SizeConfig.GetSize( size );
            Location = ControlConfig.GetLocation( location );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CalculationPanel" />
        /// class.
        /// </summary>
        /// <param name="value">The value.</param>
        public CalculationPanel( string value )
            : this()
        {
            Result.SetValue( value );
        }
        
        /// <summary>
        /// Called when [equal button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnCalculate( object sender, EventArgs e )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }
    }
}