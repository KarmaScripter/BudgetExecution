﻿// <copyright file = "TileConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Drawing;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TileBase" />
    /// <seealso cref="Syncfusion.Windows.Forms.Tools.HubTile" />
    public class TileConfig : TileBase, ITile
    {
        /// <summary>
        /// Sets the border configuration.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="size">The size.</param>
        /// <param name="enablehover">if set to
        /// <c> true </c>
        /// [enablehover].</param>
        public void SetBorderStyle( Color color, int size = 1, bool enablehover = true )
        {
            try
            {
                if( enablehover
                    && size  > 0
                    && color != Color.Empty )
                {
                    EnableHoverColor = true;
                    HoverBorderLength = size;
                    HoveredBorderColor = color;
                }

                if( !enablehover
                    && size  > 0
                    && color != Color.Empty )
                {
                    EnableHoverColor = false;
                    HoverBorderLength = size;
                    HoveredBorderColor = color;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the banner configuration.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="bannercolor">The bannercolor.</param>
        /// <param name="textcolor">The textcolor.</param>
        /// <param name="font">The font.</param>
        public void SetBannerStyle( int height, Color bannercolor, Color textcolor,
            Font font )
        {
            if( height         > 0
                && height      < 40
                && bannercolor != Color.Empty
                && textcolor   != Color.Empty
                && font        != null )
            {
                try
                {
                    if( !ShowBanner )
                    {
                        ShowBanner = true;
                    }

                    BannerHeight = height;
                    BannerColor = bannercolor;

                    Banner = new TextItem
                    {
                        TextColor = textcolor,
                        Font = font
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the hover text.
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
        /// Sets the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void SetField( Field field )
        {
            try
            {
                Field = FormConfig.GetField( field );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetToolTip( string text )
        {
            try
            {
                var _ = ControlConfig.GetToolTip( this, text );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
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
            if( sender is TileConfig tile )
            {
                try
                {
                    tile.BackColor = ColorConfig.HoverGray;
                    SetHoverText( "Tile Message Information" );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [mouse out].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnMouseOut( object sender, EventArgs e )
        {
            if( sender is TileConfig tile )
            {
                try
                {
                    tile.BackColor = ColorConfig.FormDarkBackColor;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}