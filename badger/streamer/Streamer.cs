﻿// <copyright file = "Streamer.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.Tools.ImageStreamer" />
    public class Streamer : StreamerBase, IStreamer
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Streamer" />
        /// class.
        /// </summary>
        public Streamer()
        {
            // Basic Properties
            Size = SizeConfig.GetSize( 120, 120 );
            Anchor = ControlConfig.GetAnchorStyle();
            Location = ControlConfig.GetLocation();
            Visible = true;
            Enabled = true;
            BackColor = Color.Transparent;
            Margin = ControlConfig.Margin;
            Padding = ControlConfig.Padding;

            // Slide Properties
            ShowNavigator = true;
            SlideShow = true;
            AnimationSpeed = SetAnimationSpeed();
            SliderSpeed = SetSliderSpeed();
            ImageStreamDirection = StreamDirection.RightToLeft;
            TextAnimationDirection = TextStreamDirection.RightToLeft;
            InternalBackColor = Color.Transparent;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Streamer" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        public Streamer( Size size, Point location )
            : this()
        {
            Size = SizeConfig.GetSize( size );
            Location = ControlConfig.GetLocation( location );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Streamer" />
        /// class.
        /// </summary>
        /// <param name="streamer">The streamer.</param>
        public Streamer( ImageStreamer streamer )
            : this( streamer.Size, streamer.Location )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Streamer" />
        /// class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="location">The location.</param>
        /// <param name="image">The image.</param>
        public Streamer( Size size, Point location, IEnumerable<Image> image )
            : this()
        {
            Size = size;
            Location = location;
            Images = SetImages( image );
        }

        /// <summary>
        /// Gets or sets the budget images.
        /// </summary>
        /// <value>
        /// The budget images.
        /// </value>
        public IEnumerable<Image> BudgetImages { get; set; }

        /// <summary>
        /// Gets or sets the image list.
        /// </summary>
        /// <value>
        /// The image list.
        /// </value>
        public ImageList ImageList { get; set; }

        /// <summary>
        /// Sets the images.
        /// </summary>
        /// <param name="images">The images.</param>
        /// <returns></returns>
        public List<Image> SetImages( IEnumerable<Image> images )
        {
            if( images.Any() )
            {
                try
                {
                    if( Images.Count > 0 )
                    {
                        Images.Clear();
                    }

                    foreach( var bmp in images )
                    {
                        if( bmp != null )
                        {
                            Images.Add( bmp );
                        }
                    }

                    return Images.Any()
                        ? Images.ToList()
                        : default( List<Image> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( List<Image> );
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="image">The image.</param>
        public void AddImage( Bitmap image )
        {
            if( image != null )
            {
                try
                {
                    Images.Add( image );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the stream direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public void SetImageSlideDirection(
            StreamDirection direction = StreamDirection.RightToLeft )
        {
            if( Enum.IsDefined( typeof( StreamDirection ), direction ) )
            {
                try
                {
                    SlideShow = true;
                    ImageStreamDirection = direction;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the text animation direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public void SetTextAnimationDirection(
            TextStreamDirection direction = TextStreamDirection.RightToLeft )
        {
            if( Enum.IsDefined( typeof( TextStreamDirection ), direction ) )
            {
                try
                {
                    TextAnimation = true;
                    TextAnimationDirection = direction;
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
        /// Called when [hover].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="EventArgs" />
        /// instance containing the event data.</param>
        public void OnHover( object sender, EventArgs e )
        {
            if( sender != null
                && e   != null )
            {
                try
                {
                    using var message = new Message( "NOT YET IMPLEMENTED" );
                    message.ShowDialog();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}