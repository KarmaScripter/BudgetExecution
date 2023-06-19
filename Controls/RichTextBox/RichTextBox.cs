﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="RichTextBox.cs" company="Terry D. Eppler">
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
//   RichTextBox.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using MetroSet_UI.Controls;
    using MetroSet_UI.Enums;

    /// <summary> </summary>
    public class RichTextBox : MetroSetRichTextBox
    {
        /// <summary> Gets or sets the binding source. </summary>
        /// <value> The binding source. </value>
        public virtual BindingSource BindingSource { get; set; }

        /// <summary> Gets or sets the tool tip. </summary>
        /// <value> The tool tip. </value>
        public virtual SmallTip ToolTip { get; set; }

        /// <summary> Gets or sets the hover text. </summary>
        /// <value> The hover text. </value>
        public virtual string HoverText { get; set; }

        /// <summary> Gets or sets the filter. </summary>
        /// <value> The filter. </value>
        public virtual IDictionary<string, object> DataFilter { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        public RichTextBox( )
        {
            // Basic Properties
            Style = Style.Custom;
            ThemeAuthor = "Terry D. Eppler";
            ThemeName = "Budget Execution";
            Size = new Size( 140, 30 );
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Dock = DockStyle.None;
            Margin = new Padding( 3 );
            Padding = new Padding( 1 );
            Font = new Font( "Roboto", 8 );
            ForeColor = Color.LightGray;
            BackColor = Color.FromArgb( 30, 30, 30 );
            Enabled = true;
            Visible = true;

            // BackColor SeriesConfiguration

            // Border SeriesConfiguration
            BorderColor = Color.FromArgb( 65, 65, 65 );
            HoverColor = Color.FromArgb( 0, 120, 212 );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="location"> The location. </param>
        public RichTextBox( Size size, Point location )
            : this( )
        {
            Size = size;
            Location = location;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        /// <param name="location"> The location. </param>
        /// <param name="parent"> The parent. </param>
        public RichTextBox( Point location, Control parent = null )
            : this( )
        {
            Location = location;
            if( parent != null )
            {
                Parent = parent;
                Parent.Controls.Add( this );
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="parent"> The parent. </param>
        public RichTextBox( Size size, Control parent = null )
            : this( )
        {
            Size = size;
            if( parent != null )
            {
                Parent = parent;
                Parent.Controls.Add( this );
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="location"> The location. </param>
        /// <param name="parent"> The parent. </param>
        public RichTextBox( Size size, Point location, Control parent )
            : this( )
        {
            Size = size;
            Location = location;
            Parent = parent;
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RichTextBox"/>
        /// class.
        /// </summary>
        /// <param name="title"> The title. </param>
        public RichTextBox( string title )
            : this( )
        {
            Text = title;
        }

        /// <summary> Sets the text. </summary>
        /// <param name="text"> The text. </param>
        public void SetText( string text )
        {
            if( !string.IsNullOrEmpty( text ) )
            {
                try
                {
                    Text = text;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the font style. </summary>
        /// <param name="fontFamily"> The font family. </param>
        /// <param name="fontColor"> The backColor. </param>
        /// <param name="fontSize"> Size of the font. </param>
        public void SetFontStyle( string fontFamily, Color fontColor, int fontSize = 10 )
        {
            if( !string.IsNullOrEmpty( fontFamily )
               && ( fontColor != Color.Empty ) )
            {
                try
                {
                    Font = new Font( fontFamily, fontSize );
                    ForeColor = fontColor;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the backColor of the back. </summary>
        /// <param name="backColor"> The backColor. </param>
        public void SetBackColor( Color backColor )
        {
            if( backColor != Color.Empty )
            {
                try
                {
                    BackColor = backColor;
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