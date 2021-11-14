﻿// <copyright file = "TextBoxPanel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using VisualPlus.Enumerators;

    /// <summary>
    /// Defines the
    /// <see cref="TextBoxPanel" />
    /// </summary>
    /// <seealso cref="VisualPlus.Toolkit.Controls.Editors.VisualTextBox" />
    /// <seealso/>
    public class TextBoxPanel : TextBoxData, ITextBox
    {
        //    

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        public TextBoxPanel()
        {
            // Basic Properties
            ForeColor = ColorConfig.ForeGray;
            Margin = ControlConfig.Margin;
            Font = FontConfig.FontSizeSmall;
            Padding = ControlConfig.Padding;
            Size = SizeConfig.GetSize( 160, 23 );
            Location = ControlConfig.GetLocation();
            Dock = ControlConfig.GetDockStyle();
            Anchor = ControlConfig.GetAnchorStyle();
            Visible = true;
            Enabled = true;

            // Style Configuration
            BackColorState.Disabled = ColorConfig.FormDarkBackColor;
            BackColorState.Enabled = ColorConfig.ControlDarkInterior;
            BackColor = ColorConfig.ControlDarkInterior;
            Border.Type = ShapeTypes.Rounded;
            Border.Color = ColorConfig.BorderDark;
            Border.HoverVisible = true;
            Border.HoverColor = ColorConfig.BorderBlue;
            Border.Thickness = BorderConfig.Thin;
            TextAlign = HorizontalAlignment.Center;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="point">The point.</param>
        public TextBoxPanel( Size size, Point point )
            : this()
        {
            Size = ControlConfig.GetSize( size );
            Location = ControlConfig.GetLocation( point.X, point.Y );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="point">The point.</param>
        /// <param name="parent">The parent.</param>
        public TextBoxPanel( Size size, Point point, Control parent )
            : this( size, point )
        {
            Parent = ControlConfig.GetParent( parent );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="parent">The parent.</param>
        public TextBoxPanel( Size size, Control parent )
            : this()
        {
            Size = SizeConfig.GetSize( size );
            Parent = ControlConfig.GetParent( parent );
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="location">The location
        /// <see cref="Point" /></param>
        /// <param name="parent">The parent.</param>
        public TextBoxPanel( Point location, Control parent )
            : this()
        {
            Location = ControlConfig.GetLocation( location.X, location.Y );
            Parent = ControlConfig.GetParent( parent );
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public TextBoxPanel( Control parent )
            : this()
        {
            Parent = ControlConfig.GetParent( parent );
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="parent">The
        /// <see cref="T:System.Windows.Forms.Control" />
        /// to be the parent of the control.</param>
        /// <param name="text">The text displayed by the control.</param>
        public TextBoxPanel( Control parent, string text )
            : this( parent )
        {
            Text = ControlConfig.GetText( text );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextBoxPanel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location
        /// <see cref="Point" /></param>
        /// <param name="parent">The parent.</param>
        /// <param name="text">The items.</param>
        public TextBoxPanel( Size size, Point location, Control parent,
            string text )
            : this( size, location, parent )
        {
            Text = ControlConfig.GetText( text );
        }

        /// <summary>
        /// Gets or sets the tip.
        /// </summary>
        /// <value>
        /// The tip.
        /// </value>
        public ToolTip ToolTip { get; set; }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name="numeric">The numeric.</param>
        public void SetNumeric( Numeric numeric )
        {
            if( Enum.IsDefined( typeof( Numeric ), numeric ) )
            {
                try
                {
                    Numeric = numeric;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetText( string text )
        {
            try
            {
                Text = ControlConfig.GetText( text );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        public void SetTextAlignment( HorizontalAlignment alignment = HorizontalAlignment.Center )
        {
            if( Enum.IsDefined( typeof( HorizontalAlignment ), alignment ) )
            {
                try
                {
                    TextAlign = alignment;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the hover information.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetHoverText( string text )
        {
            if( Verify.Input( text ) )
            {
                try
                {
                    var _ = new ToolTip( this, text );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public void SetTag( object tag )
        {
            try
            {
                Tag = ControlConfig.GetTag( tag );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Adds the control item.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Control> GetChildren()
        {
            if( Controls?.Count > 0 )
            {
                try
                {
                    var children = new List<Control>();

                    foreach( var item in Controls )
                    {
                        if( item != null )
                        {
                            children?.Add( item as Control );
                        }
                    }

                    return children?.Any() == true
                        ? children
                        : default( List<Control> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<Control> );
                }
            }

            return default( IEnumerable<Control> );
        }

        /// <summary>
        /// Called when [mouse hover].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnMouseHover( object sender, EventArgs e )
        {
            if( sender is TextBoxPanel textbox
                && textbox.Tag != null )
            {
                try
                {
                    SetHoverText( textbox.Tag.ToString() );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}