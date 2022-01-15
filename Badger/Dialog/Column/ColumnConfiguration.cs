﻿// <copyright file = "ColumnConfiguration.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

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
    /// <seealso cref = "MetroForm"/>
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public partial class ColumnConfiguration : MetroForm
    {
        //    

        /// <summary>
        /// Sets Basic Properties Initializes a new instance of the
        /// <see cref = "ColumnConfiguration"/> class.
        /// </summary>
        public ColumnConfiguration()
        {
            InitializeComponent();
            Enabled = true;
            Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ColumnConfiguration"/> class.
        /// </summary>
        /// <param name = "dgv" >
        /// The DGV.
        /// </param>
        public ColumnConfiguration( DataGridView dgv )
            : this()
        {
            Grid = dgv;
            PopUp = new ToolStripDropDown();
            ColumnListBox.CheckOnClick = true;
        }

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
        public ToolStripDropDown PopUp { get; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public ToolStripControlHost Host { get; set; }
        
        /// <summary>
        /// Gets the control host.
        /// </summary>
        /// <param name = "listbox" >
        /// The listbox.
        /// </param>
        /// <returns>
        /// </returns>
        private ToolStripControlHost GetControlHost( Control listbox )
        {
            if( listbox != null )
            {
                try
                {
                    var _controlHost = new ToolStripControlHost( this )
                    {
                        AutoSize = true,
                        Margin = Padding.Empty,
                        Padding = Padding.Empty
                    };

                    return _controlHost;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ToolStripControlHost );
                }
            }

            return default( ToolStripControlHost );
        }

        /// <summary>
        /// Called when [datagrid right click].
        /// </summary>
        /// <param name = "sender" >
        /// The sender.
        /// </param>
        /// <param name = "e" >
        /// The <see cref = "DataGridViewCellMouseEventArgs"/> instance containing the
        /// event data.
        /// </param>
        public void OnDatagridRightClick( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.Button         == MouseButtons.Right
                && Grid?.Columns != null )
            {
                try
                {
                    ColumnListBox?.Items?.Clear();

                    foreach( DataGridViewColumn c in Grid?.Columns )
                    {
                        ColumnListBox?.Items.Add( c.HeaderText, c.Visible );
                    }

                    using var colconfig = new ColumnConfiguration( Grid )
                    {
                        Location = Grid.PointToScreen( new Point( e.X, e.Y ) )
                    };

                    colconfig?.ShowDialog();
                    colconfig.TopMost = true;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [data grid item checked].
        /// </summary>
        /// <param name = "sender" >
        /// The sender.
        /// </param>
        /// <param name = "e" >
        /// The <see cref = "ItemCheckEventArgs"/> instance containing the event data.
        /// </param>
        private void OnDataGridItemChecked( object sender, ItemCheckEventArgs e )
        {
            if( e != null )
            {
                try
                {
                    Grid.Columns[ e.Index ].Visible = e.NewValue == CheckState.Checked;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}