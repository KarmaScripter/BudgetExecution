// <copyright file = "BadgerMain.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using Syncfusion.Windows.Forms;

    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public partial class BadgerMain : MetroForm
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        public BadgerMain()
        {
            InitializeComponent();
            FormClosing += OnClose;
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        private Image GetImage()
        {
            try
            {
                var img = new BudgetImage( "SqlCe", ImageSource.DatabaseImages );
                Label.Text = img?.GetBuilder()?.GetFilePath();
                return img?.GetBitmap();
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }

        // ***************************************************************************************************************************
        // ****************************************************     EVENTS    ********************************************************
        // ***************************************************************************************************************************

        private void OnExcelButtonClick( object sender, EventArgs e )
        {
            var path = Resource.Settings[ "Report" ];
            using var excel = new ExcelForm( path );
            excel?.ShowDialog();
        }

        private void OnClose( object sender, EventArgs e )
        {
            PictureBox?.Image?.Dispose();
            PictureBox?.InitialImage?.Dispose();
        }
    }
}
