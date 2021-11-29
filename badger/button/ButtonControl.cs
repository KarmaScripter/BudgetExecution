﻿// // <copyright file = "ButtonControl.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public partial class ButtonControl : ControlBase, IButton
    {
        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
        public new string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonControl"/> class.
        /// </summary>
        public ButtonControl()
        {
            InitializeComponent();
            Name = Button.Name;
        }
        
        /// <summary>
        /// Sets the color of the fore. Required Attributes: ForeColor
        /// </summary>
        /// <param name="format">The format.</param>
        public void SetForeColor( ColorFormat format )
        {
            Button.SetForeColor( format );
        }

        /// <summary>
        /// Sets the state of the back color.
        /// </summary>
        /// <param name="format">The format.</param>
        public void SetBackColorStyle( ColorFormat format )
        {
            Button.SetBackColorStyle( format );
        }

        /// <summary>
        /// Sets the border configuration. Required Attributes: BorderColor, and HoverColor
        /// </summary>
        /// <param name="format">The format.</param>
        public void SetBorderStyle( ColorFormat format )
        {
            Button.SetBorderStyle( format );
        }

        /// <summary>
        /// Sets the text style configuration. Required Attributes: PressedColor, DisabledColor,
        /// EnabledColor, and HoverColor
        /// </summary>
        /// <param name="format">The format.</param>
        public void SetTextStyle( ColorFormat format )
        {
            Button.SetTextStyle( format );
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        /// <param name="image">The image.</param>
        public void SetImage( Image image )
        {
            Button.SetImage( image );
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnClick( object sender, EventArgs e )
        {
            Button.OnClick( sender, e );
        }
    }
}