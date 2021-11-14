﻿// <copyright file = "ComboBoxControl.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    public partial class ComboBoxControl : ControlBase, IComboBox
    {
        public ComboBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetToolTip( string text )
        {
            ComboBox.SetToolTip( text );
        }

        /// <summary>
        /// Called when [hover].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnMouseHover( object sender, EventArgs e )
        {
            ComboBox.OnMouseHover( sender, e );
        }
    }
}