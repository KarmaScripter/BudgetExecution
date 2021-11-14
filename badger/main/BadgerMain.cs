﻿// <copyright file = "BadgerMain.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using Syncfusion.Windows.Forms;

    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public partial class BadgerMain : MetroForm
    {
        public BadgerMain()
        {
            InitializeComponent();
            FormClosing += OnClose;
            BorderColor = ColorConfig.BorderBlue;
        }

        private Image GetImage()
        {
            try
            {
                var _image = new BudgetImage( "SqlCe", ImageSource.DatabaseImages );
                var path = _image?.Builder?.GetFilePath();
                Label.Text = path;
                return _image?.GetBitmap();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Image );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }

        /// <summary>
        /// Called when [excel button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnExcelButtonClick( object sender, EventArgs e )
        {
            var _path = Resource.Settings[ "Report" ];
            using var _excel = new ExcelForm( _path );
            _excel?.ShowDialog();
        }

        /// <summary>
        /// Raises the Close event.
        /// </summary>
        /// <param name="sender">The sender.
        /// </param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnClose( object sender, EventArgs e )
        {
            PictureBox?.Image?.Dispose();
            PictureBox?.InitialImage?.Dispose();
        }
    }
}