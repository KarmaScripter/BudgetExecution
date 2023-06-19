﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ColumnConfiguration.cs" company="Terry D. Eppler">
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
//   ColumnConfiguration.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm" />
    [SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public partial class ColumnConfiguration : MetroForm
    {
        /// <summary>
        /// Gets the grid.
        /// </summary>
        /// <value>
        /// The grid.
        /// </value>
        public DataGridView Grid { get; }

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        /// <value>
        /// The column names.
        /// </value>
        public IEnumerable<string> ColumnNames { get; set; }

        /// <summary>
        /// Gets the pop up.
        /// </summary>
        /// <value>
        /// The pop up.
        /// </value>
        public System.Windows.Forms.ToolStripDropDown PopUp { get; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public ToolStripControlHost Host { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnConfiguration"/> class.
        /// </summary>
        public ColumnConfiguration( )
        {
            InitializeComponent( );
            BorderColor = Color.FromArgb( 0, 120, 212 );
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BorderThickness = 2;
            Size = new Size( 250, 350 );
            MaximumSize = new Size( 250, 350 );
            MinimumSize = new Size( 250, 350 );
            BackColor = Color.FromArgb( 20, 20, 20 );
            ForeColor = Color.LightGray;
            Font = new Font( "Roboto", 9 );
            CaptionBarHeight = 5;
            CaptionForeColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = Color.FromArgb( 20, 20, 20 );
            SizeGripStyle = SizeGripStyle.Auto;
            ShowMouseOver = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Enabled = true;
            Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnConfiguration"/> class.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        public ColumnConfiguration( DataGridView dataGrid )
            : this( )
        {
            Grid = dataGrid;
            PopUp = new System.Windows.Forms.ToolStripDropDown( );
            ColumnListBox.CheckOnClick = true;
            ColumnListBox.ItemCheck += OnListItemChecked;
            CloseButton.Click += OnCloseButtonClick;
            HeaderLabel.Font = new Font( "Roboto", 10 );
            HeaderLabel.ForeColor = Color.FromArgb( 0, 120, 212 );
            Load += OnLoad;
        }

        /// <summary>
        /// Called when [data grid right click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        public void OnDataGridRightClick( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( ( e.Button == MouseButtons.Right )
               && ( Grid?.Columns != null ) )
            {
                try
                {
                    ColumnListBox?.Items?.Clear( );
                    if( Grid?.Columns != null )
                    {
                        foreach( DataGridViewColumn _c in Grid.Columns )
                        {
                            ColumnListBox?.Items.Add( _c.HeaderText, _c.Visible );
                        }
                    }

                    var _columnConfiguration = new ColumnConfiguration( Grid );
                    if( Grid != null )
                    {
                        _columnConfiguration.Location = Grid.PointToScreen( new Point( e.X, e.Y ) );
                    }

                    _columnConfiguration?.ShowDialog( );
                    _columnConfiguration.TopMost = true;
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        protected static void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnLoad( object sender, EventArgs e )
        {
            try
            {
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Gets the control host.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        /// <returns></returns>
        private ToolStripControlHost GetControlHost( Control listBox )
        {
            if( listBox != null )
            {
                try
                {
                    var _controlHost = new ToolStripControlHost( this );
                    _controlHost.AutoSize = true;
                    _controlHost.Margin = Padding.Empty;
                    _controlHost.Padding = Padding.Empty;
                    return _controlHost;
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( ToolStripControlHost );
                }
            }

            return default( ToolStripControlHost );
        }

        /// <summary>
        /// Called when [list item checked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void OnListItemChecked( object sender, ItemCheckEventArgs e )
        {
            if( e != null )
            {
                try
                {
                    Grid.Columns[ e.Index ].Visible = e.NewValue == CheckState.Checked;
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Called when [close button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCloseButtonClick( object sender, EventArgs e )
        {
            if( sender is Button )
            {
                try
                {
                    Close( );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }
    }
}