﻿// <copyright file = "BudgetLabel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using VisualPlus.Toolkit.Controls.Interactivity;

    /// <summary>
    /// Defines the
    /// <see cref="BudgetLabel" />
    /// </summary>
    /// <seealso cref="VisualPlus.Toolkit.Controls.Interactivity.VisualLabel" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class BudgetLabel : LabelBase, ILabel
    {
        /// <summary>
        /// Gets or sets the tip.
        /// </summary>
        /// <value>
        /// The tip.
        /// </value>
        public ToolTip ToolTip { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        public BudgetLabel()
        {
            Size = BudgetSize.GetSize( 165, 23 );
            Location = BudgetControl.GetLocation();
            BackColor = BudgetColor.FormDark;
            ForeColor = BudgetColor.ForeColorGray;
            Font = BudgetFont.FontSizeSmall;
            Margin = BudgetControl.Margin;
            Padding = BudgetControl.Padding;
            Anchor = BudgetControl.GetAnchorStyle();
            Dock = BudgetControl.GetDockStyle();
            Enabled = true;
            Visible = true;
            TextAlignment = BudgetAlign.StringAlignCenter;
            TextLineAlignment = BudgetAlign.StringAlignCenter;
            OutlineColor = BudgetColor.FormDark;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        public BudgetLabel( Size size, Point location )
            : this()
        {
            Size = BudgetSize.GetSize( size );
            Location = BudgetControl.GetLocation( location );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        /// <param name="label">The label.</param>
        [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
        public BudgetLabel( VisualLabel label )
            : this( label.Size, label.Location )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        public BudgetLabel( Size size, Point location, Control parent )
            : this( size, location )
        {
            Parent = BudgetControl.GetParent( parent );
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="text">The text.</param>
        public BudgetLabel( Size size, Point location, Control parent,
            string text )
            : this( size, location, parent )
        {
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetLabel" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="bindingSource">The bindingSource.</param>
        public BudgetLabel( Size size, Point location, Control parent,
            BudgetBinding bindingSource )
            : this( size, location, parent )
        {
            BindingSource = bindingSource;
        }
        
        /// <summary>
        /// Sets the color of the border.
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetOutlineColor( Color color )
        {
            if( color != Color.Empty )
            {
                try
                {
                    OutlineColor = color;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        public void SetTextAlignment( StringAlignment alignment )
        {
            if( Enum.IsDefined( typeof( StringAlignment ), alignment ) )
            {
                try
                {
                    TextAlignment = alignment;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the line alignment.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        public void SetLineAlignment( StringAlignment alignment )
        {
            if( Enum.IsDefined( typeof( StringAlignment ), alignment ) )
            {
                try
                {
                    TextLineAlignment = alignment;
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
            if( Verify.IsInput( text ) )
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

        /// <summary>
        /// Sets the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public void SetTag( object tag )
        {
            if( tag != null )
            {
                try
                {
                    Tag = tag;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

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
    }
}