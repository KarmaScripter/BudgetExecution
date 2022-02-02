﻿// <copyright file = "ClosePanel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using MetroSet_UI.Design;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using MetroSet_UI.Controls;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="VisualPlus.Toolkit.Controls.Interactivity.VisualControlBox" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    public class ClosePanel : MetroSetControlBox
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
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        public ClosePanel()
        {
            // Prologue
            ForeColor = ColorConfig.ForeColorGray;
            Font = FontConfig.FontSizeSmall;
            Margin = new Padding( 0 );
            Padding = new Padding( 0 );
            Size = SizeConfig.GetSize( 300, 25 );
            Anchor = AnchorStyles.Top & AnchorStyles.Right;
            Visible = true;
            Enabled = true;
            CloseHoverBackColor = Color.Red;
            CloseHoverForeColor = Color.White;
            CloseNormalForeColor = ColorConfig.FormBackColorDark;
            MaximizeHoverBackColor = Color.Blue;
            MaximizeHoverForeColor = Color.White;
            MaximizeNormalForeColor = ColorConfig.FormBackColorDark;
            MinimizeHoverBackColor = Color.Blue;
            MinimizeHoverForeColor = Color.White;
            MinimizeNormalForeColor = ColorConfig.FormBackColorDark;
            Style = Style.Custom;
            ThemeAuthor = "Terry D. Eppler";
            ThemeName = "Budget Execution";
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        public ClosePanel( Size size, Point location )
            : this()
        {
            Size = SizeConfig.GetSize( size.Width, size.Height );
            Location = ControlConfig.GetLocation( location.X, location.Y );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="location">The location.</param>
        public ClosePanel( Point location )
            : this()
        {
            Location = ControlConfig.GetLocation( location.X, location.Y );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The parent.</param>
        public ClosePanel( Size size, Point location, Control parent )
            : this( size, location )
        {
            Parent = ControlConfig.GetParent( parent );
            Parent.Controls.Add( this );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetButton" />
        /// class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ClosePanel( Control parent )
            : this()
        {
            Parent = ControlConfig.GetParent( parent );
            Parent.Controls.Add( this );
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
    }
}