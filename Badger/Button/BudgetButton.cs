﻿// <copyright file = "BudgetButton.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using VisualPlus.Enumerators;
    using VisualPlus.Models;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ButtonBase" />
    /// <seealso cref="IBudgetButton" />
    /// <seealso cref="VisualPlus.Toolkit.Controls.Interactivity.VisualButton" />
    /// <seealso cref="IDisposable" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class BudgetButton : ButtonBase, IBudgetButton
    {
        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>
        /// The tool tip.
        /// </value>
        public override ToolTip ToolTip { get; set; }

        /// <summary>
        /// Gets or sets the hover text.
        /// </summary>
        /// <value>
        /// The hover text.
        /// </value>
        public override string HoverText { get; set; }

        /// <summary>
        /// Gets or sets the binding source.
        /// </summary>
        /// <value>
        /// The binding source.
        /// </value>
        public override BindingSource BindingSource { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public override Field Field { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public override IDictionary<string, object> DataFilter { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public override NameValueCollection Setting { get; set; } = ConfigurationManager.AppSettings;
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        public BudgetButton()
        {
            // Basic SeriesConfiguration
            Font = new Font( "Roboto", 9 );
            ForeColor = Color.LightSteelBlue;
            Margin = new Padding( 3 );
            Padding = new Padding( 1 );
            Size = new Size( 140, 40 );
            Location = new Point( 1, 1 );
            Dock = DockStyle.None;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Animation = true;
            Visible = true;
            Enabled = true;
            Text = string.Empty;

            // BackColor SeriesConfiguration
            BackColor = Color.FromArgb( 10, 10, 10 );
            BackColorState.Disabled = Color.FromArgb( 10, 10, 10 );
            BackColorState.Enabled = Color.FromArgb( 10, 10, 10 );
            BackColorState.Hover = Color.FromArgb( 20, 20, 20 );
            BackColorState.Pressed = Color.SteelBlue;

            // BorderColor SeriesConfiguration
            Border.Color = Color.FromArgb( 10, 10, 10 );
            Border.HoverColor = Color.SteelBlue;
            Border.HoverVisible = true;
            Border.Type = ShapeTypes.Rounded;
            Border.Thickness = 1;

            // BudgetImage SeriesConfiguration
            TextImageRelation = TextImageRelation.Overlay;

            // Text SeriesConfiguration
            TextStyle.Pressed = Color.White;
            TextStyle.Disabled = Color.FromArgb( 10, 10, 10 );
            TextStyle.Enabled = Color.LightGray;
            TextStyle.Hover = Color.White;
            TextStyle.TextAlignment = StringAlignment.Center;
            TextStyle.TextLineAlignment = StringAlignment.Center;

            // Event-Wiring
            MouseHover += OnMouseOver;
            MouseLeave += OnMouseLeave;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        public BudgetButton( Size size, Point location )
            : this()
        {
            Size = size;
            Location = location;
            Field = Field.NS;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        public BudgetButton( Size size, Point location, Control parent )
            : this( size, location )
        {
            Parent = parent;
            Field = Field.NS;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="text">The text.</param>
        public BudgetButton( Size size, Point location, Control parent,
            string text )
            : this( size, location, parent )
        {
            Text = text;
            Field = Field.NS;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="text">The text displayed by the control.</param>
        public BudgetButton( Control parent, string text )
            : this()
        {
            Parent = parent;
            Text = text;
            Field = Field.NS;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public BudgetButton( Control parent )
            : this()
        {
            Parent = parent;
            Field = Field.NS;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="field">The field.</param>
        public BudgetButton( Control parent, Field field )
            : this()
        {
            Parent = parent;
            Field = field;
            Tag = Field;
        }
        
        /// <summary>
        /// Sets the color of the fore. Required Attributes: ForeColor
        /// </summary>
        /// <param name="format">The format.</param>
        public void SetForeColor( Color format )
        {
            try
            {
                ForeColor = format;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the state of the back color. Required Attributes: BackColor, DisableColor,
        /// EnabledColor, HoverColor, and PressedColor
        /// </summary>
        /// <param name="normal">The format.</param>
        /// <param name = "hover" > </param>
        public void SetBackColorStyle( Color normal, Color hover )
        {
            try
            {
                BackColor = normal;
                BackColorState.Disabled = normal;
                BackColorState.Enabled = normal;
                BackColorState.Hover = hover;
                BackColorState.Pressed = hover;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the border configuration. Required Attributes: BorderColor, and HoverColor
        /// </summary>
        /// <param name="normal">The format.</param>
        /// <param name = "hover" > </param>
        public void SetBorderStyle( Color normal, Color hover )
        {
            try
            {
                Border.Color = normal;
                Border.HoverColor = hover;
                Border.HoverVisible = true;
                Border.Type = ShapeTypes.Rounded;
                Border.Thickness = 1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the text style configuration. Required Attributes: PressedColor,
        /// DisabledColor, EnabledColor, and HoverColor
        /// </summary>
        /// <param name="normal">The format.</param>
        /// <param name = "hover" > </param>
        public void SetTextStyle( Color normal, Color hover )
        {
            try
            {
                TextImageRelation = TextImageRelation.ImageBeforeText;
                
                TextStyle = new TextStyle
                {
                    TextLineAlignment = StringAlignment.Center,
                    TextAlignment = StringAlignment.Center,
                    Hover = hover,
                    Enabled = normal,
                    Disabled = normal,
                    Pressed = normal
                };
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        /// <param name="image">The image.</param>
        public override void SetImage( Image image )
        {
            if( image != null )
            {
                try
                {
                    Image = image;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
        
        /// <summary>
        /// Called when [mouse over].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnMouseOver( object sender, EventArgs e )
        {
            var _button = sender as BudgetButton;

            try
            {
                if( _button != null 
                    && !string.IsNullOrEmpty( HoverText ) )
                {
                    if( Verify.IsInput( HoverText ) )
                    {
                        var _hoverText = _button?.HoverText;
                        var _ = new ToolTip( _button, _hoverText );
                    }
                    else
                    {
                        if( Verify.IsInput( Tag?.ToString() ) )
                        {
                            var _text = Tag?.ToString()?.SplitPascal();
                            var _ = new ToolTip( _button, _text );
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [mouse leave].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.
        /// </param>
        public override void OnMouseLeave( object sender, EventArgs e )
        {
            var _button = sender as BudgetButton;

            try
            {
                if( _button != null  )
                {
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public virtual void OnClick( object sender, EventArgs e )
        {
        }
    }
}