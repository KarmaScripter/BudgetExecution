﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="CarouselForm.cs" company="Terry D. Eppler">
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
//   CarouselForm.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary> </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    public partial class CarouselForm : MetroForm
    {
        /// <summary> Gets or sets the image path. </summary>
        /// <value> The image path. </value>
        public string ImagePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CarouselForm"/>
        /// class.
        /// </summary>
        public CarouselForm( )
        {
            InitializeComponent( );

            // Basic Properties
            Size = new Size( 1400, 750 );
            MaximumSize = new Size( 1400, 800 );
            BackColor = Color.FromArgb( 20, 20, 20 );
            ForeColor = Color.LightGray;
            Font = new Font( "Roboto", 9 );
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BorderColor = Color.FromArgb( 0, 120, 212 );
            Dock = DockStyle.None;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            ShowIcon = false;
            ShowInTaskbar = true;
            ShowMouseOver = true;
            MetroColor = Color.FromArgb( 20, 20, 20 );
            CaptionFont = new Font( "Roboto", 11 );
            CaptionBarColor = Color.FromArgb( 20, 20, 20 );
            CaptionForeColor = Color.LightSteelBlue;
            CaptionButtonColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = Color.Red;
            MinimizeBox = false;
            MaximizeBox = false;

            // Header Properties
            Header.Font = new Font( "Roboto", 16, FontStyle.Bold );
            Header.ForeColor = Color.FromArgb( 0, 120, 212 );

            // Event Wiring
            Carousel.OnCarouselItemSelectionChanged += OnItemSelected;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CarouselForm"/>
        /// class.
        /// </summary>
        /// <param name="directoryPath"> The directory path. </param>
        public CarouselForm( string directoryPath )
            : this( )
        {
            ImagePath = directoryPath;
            Header.Text = string.Empty;
            Load += OnLoad;
        }

        /// <summary> Called when [load]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnLoad( object sender, EventArgs e )
        {
            if( !string.IsNullOrEmpty( ImagePath ) )
            {
                try
                {
                    var _files = Directory.GetFiles( ImagePath );
                    foreach( var _file in _files )
                    {
                        var _name = Path.GetFileNameWithoutExtension( _file );
                        var _stream = File.Open( _file, FileMode.Open );
                        var _image = new Bitmap( _stream );
                        _image.Tag = _name;
                        var _carouselImage = new CarouselImage( );
                        _carouselImage.ItemImage = _image;
                        Carousel.ImageListCollection.Add( _carouselImage );
                    }

                    Carousel.FilePath = ImagePath;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Called when [item selected]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnItemSelected( object sender, EventArgs e )
        {
            if( sender is Selector _carousel )
            {
                try
                {
                    var _tag = _carousel.ActiveImage?.Tag?.ToString( );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Fails the specified ex. </summary>
        /// <param name="ex"> The ex. </param>
        private protected void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}