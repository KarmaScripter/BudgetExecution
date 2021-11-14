﻿// <copyright file = "ConversionForm.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [ SuppressMessage( "ReSharper", "BadListLineBreaks" ) ]
    public partial class ConversionForm : MetroForm
    {
        /// <summary>
        /// The access connect
        /// </summary>
        private AccessConnect _accessConnect;

        /// <summary>
        /// The count
        /// </summary>
        private int _count;

        /// <summary>
        /// The selected
        /// </summary>
        private int _selected;

        /// <summary>
        /// 
        /// </summary>
        private delegate void UpdateStatusDelegate();

        /// <summary>
        /// The updater
        /// </summary>
        private UpdateStatusDelegate _updater;

        /// <summary>
        /// The worker
        /// </summary>
        private Thread _worker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionForm"/> class.
        /// </summary>
        public ConversionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the tables.
        /// </summary>
        private void GetTables()
        {
            _accessConnect = new AccessConnect( AccessPath.Text );
            var tables = _accessConnect.GetTableNames();

            foreach( var s in tables )
            {
                CheckTableNames.Items.Add( s );
            }
        }

        /// <summary>
        /// Gets the selected tables.
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectedTables()
        {
            var result = new List<string>();

            for( var i = 0; i < CheckTableNames.Items.Count; i++ )
            {
                if( CheckTableNames.GetItemChecked( i ) )
                {
                    result.Add( CheckTableNames.Items[ i ].ToString() );
                }
            }

            _selected = result.Count;
            return result;
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus()
        {
            _count++;
            lblstatus.Text = _count + "/" + _selected;

            if( _count >= _selected )
            {
                MessageBox.Show( "Operation completed" );
            }
        }

        /// <summary>
        /// Converts this instance.
        /// </summary>
        private void Convert()
        {
            var tables = GetSelectedTables();

            if( tables.Count == 0 )
            {
                return;
            }

            var db = new AccessConversion();

            for( var i = 0; i < tables.Count; i++ )
            {
                var table = tables[ i ];
                db.CreateTable( table );
                var dt = _accessConnect.GetTable( table );

                for( var j = 0; j < dt.Rows.Count; j++ )
                {
                    var word = dt.Rows[ j ][ "word" ].ToString();
                    var image = dt.Rows[ j ][ "image" ].ToString();
                    db.InsertRow( word, image, table );
                }

                //sending operation status to update current status
                Invoke( _updater );
            }
        }

        /// <summary>
        /// Converts the button on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ConvertButtonOnClick( object sender, EventArgs e )
        {
            if( AccessPath.Text == string.Empty )
            {
                MessageBox.Show( "please select database to convert", "error" );
                return;
            }

            _updater = UpdateStatus;

            //running conversation in a thread to prevent windows from freezing! because of heavy operation
            _worker = new Thread( Convert );
            _worker.Start();
        }

        /// <summary>
        /// Handles the ItemCheck event of the checkTableNames control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void TableNamesOnItemCheck( object sender, ItemCheckEventArgs e )
        {
        }

        /// <summary>
        /// Handles the Click event of the btnCheckAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckAllOnClick( object sender, EventArgs e )
        {
            for( var i = 0; i < CheckTableNames.Items.Count; i++ )
            {
                CheckTableNames.SetItemChecked( i, true );
            }
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtoOnClick( object sender, EventArgs e )
        {
            for( var i = 0; i < CheckTableNames.Items.Count; i++ )
            {
                CheckTableNames.SetItemChecked( i, false );
            }
        }

        /// <summary>
        /// Selects the button on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectButtonOnClick( object sender, EventArgs e )
        {
            var openfiledialog = new OpenFileDialog();
            openfiledialog.Multiselect = false;
            openfiledialog.Filter = "Access database|*.mdb";
            openfiledialog.Title = "Select Access database...";

            if( openfiledialog.ShowDialog() == DialogResult.OK )
            {
                AccessPath.Text = openfiledialog.FileName;
                GetTables();
            }
        }
    }
}