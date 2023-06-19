﻿// ******************************************************************************************
//     Assembly:                Budget Enumerations
//     Author:                  Terry D. Eppler
//     Created:                 06-08-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-08-2023
// ******************************************************************************************
// <copyright file="TextDialog.cs" company="Terry D. Eppler">
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
//   TextDialog.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using Syncfusion.Drawing;
    using Syncfusion.Windows.Forms;
    using Syncfusion.Windows.Forms.Edit;
    using Syncfusion.Windows.Forms.Edit.Enums;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public partial class TextDialog : MetroForm
    {
        public TextDialog( )
        {
            InitializeComponent( );
            Size = new Size( 650, 250 );
            MinimumSize = new Size( 650, 250 );
            MaximumSize = new Size( 650, 250 );
            BorderColor = Color.FromArgb( 0, 120, 212 );
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BorderThickness = 1;
            BackColor = Color.FromArgb( 20, 20, 20 );
            StartPosition = FormStartPosition.CenterScreen;
            CaptionBarHeight = 5;
            CaptionForeColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = Color.FromArgb( 20, 20, 20 );
            ShowMouseOver = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Enabled = true;

            // Editor SettingsEditor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Editor.AlwaysShowScrollers = true;
            Editor.BackColor = SystemColors.ControlLight;
            Editor.ForeColor = Color.Black;
            Editor.BackgroundColor = new BrushInfo( SystemColors.ControlLight );
            Editor.BorderStyle = BorderStyle.FixedSingle;
            Editor.CanOverrideStyle = true;
            Editor.CanApplyTheme = true;
            Editor.ColumnGuidesMeasuringFont = new Font( "Roboto", 8 );
            Editor.ContextChoiceFont = new Font( "Roboto", 8 );
            Editor.ContextChoiceForeColor = Color.Black;
            Editor.ContextChoiceBackColor = SystemColors.ControlLight;
            Editor.ContextPromptBorderColor = Color.FromArgb( 0, 120, 212 );
            Editor.ContextPromptBackgroundBrush =
                new BrushInfo( Color.FromArgb( 233, 166, 50 ) );

            Editor.ContextTooltipBackgroundBrush =
                new BrushInfo( Color.FromArgb( 233, 166, 50 ) );

            Editor.ContextTooltipBorderColor = Color.FromArgb( 0, 120, 212 );
            Editor.EndOfLineBackColor = SystemColors.ControlLight;
            Editor.EndOfLineForeColor = SystemColors.ControlLight;
            Editor.HighlightCurrentLine = true;
            Editor.IndentationBlockBorderColor = Color.FromArgb( 0, 120, 212 );
            Editor.IndentLineColor = Color.FromArgb( 50, 93, 129 );
            Editor.IndicatorMarginBackColor = SystemColors.ControlLight;
            Editor.CurrentLineHighlightColor = Color.FromArgb( 0, 120, 212 );
            Editor.Font = new Font( "Roboto", 9 );
            Editor.LineNumbersColor = Color.Black;
            Editor.LineNumbersFont = new Font( "Roboto", 8, FontStyle.Bold );
            Editor.ScrollVisualStyle = ScrollBarCustomDrawStyles.Office2016;
            Editor.ScrollColorScheme = Office2007ColorScheme.Black;
            Editor.SelectionTextColor = Color.FromArgb( 50, 93, 129 );
            Editor.ShowEndOfLine = false;
            Editor.Style = EditControlStyle.Office2016Black;
            Editor.TabSize = 4;
            Editor.WordWrap = true;
            Editor.WordWrapMarginVisible = true;
            Editor.WordWrapMode = WordWrapMode.WordWrapMargin;
            Editor.TextAreaWidth = 550;
            Editor.UseXPStyle = false;
            Editor.WordWrapColumn = 25;

            // Wire Events
            Load += OnLoad;
            CloseButton.Click += OnCloseButtonClick;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextDialog"/> class.
        /// </summary>
        /// <param name="text">The text displayed by the control.</param>
        public TextDialog( string text )
            : this( )
        {
            Editor.Text = text;
        }

        /// <summary>
        /// Sets the editor configuration.
        /// </summary>
        private void SetEditorConfiguration( )
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
        /// Sets the title properties.
        /// </summary>
        private void SetTitleProperties( )
        {
            try
            {
                Title.Font = new Font( "Roboto", 9, FontStyle.Bold );
                Title.ForeColor = Color.FromArgb( 0, 120, 212 );
                Title.TextAlign = ContentAlignment.TopLeft;
                Title.Text = "Text Editor";
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
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
                SetTitleProperties( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary> Called when [close button clicked]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public virtual void OnCloseButtonClick( object sender, EventArgs e )
        {
            if( sender is Button _button
               && !string.IsNullOrEmpty( _button?.Name ) )
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

        /// <summary> Get ErrorDialog Dialog. </summary>
        /// <param name="ex"> The ex. </param>
        private void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}