// <copyright file = "HoverData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using Syncfusion.Windows.Forms.Tools;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HoverBase" />
    /// <seealso cref="IHover" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    public class HoverInfo : HoverBase, IHover
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The header information
        /// </summary>
        public readonly ToolTipInfo headerInfo;

        /// <summary>
        /// The body information
        /// </summary>
        public readonly ToolTipInfo bodyInfo;

        /// <summary>
        /// The footer information
        /// </summary>
        public readonly ToolTipInfo footerInfo;

        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HoverInfo" />
        /// class.
        /// </summary>
        public HoverInfo()
        {
            // Basic Control Properties
            InitialDelay = 750;
            MaxWidth = 700;
            ToolTipDuration = 5;
            Style = SuperToolTipStyle.Office2013Style;
            VisualStyle = Appearance.Metro;
            UseFading = FadingType.Blend;
            GradientBackGround = true;
            MetroColor = ColorConfig.BackColorBlack;

            // Header Properties
            headerInfo = new ToolTipInfo();
            headerInfo.BackColor = ColorConfig.BackColorBlack;
            headerInfo.BorderColor = ColorConfig.BorderColorLight;
            headerInfo.ForeColor = ColorConfig.ForeColorGray;
            headerInfo.Separator = true;
            headerInfo.Header.ForeColor = ColorConfig.ForeColorGray;
            headerInfo.Header.Font = FontConfig.FontSizeMedium;
            headerInfo.Header.TextAlign = ContentAlignment.MiddleCenter;
            headerInfo.Header.TextMargin = ControlConfig.Margin;
            headerInfo.Header.ImageAlign = ContentAlignment.MiddleLeft;
            headerInfo.Header.TextImageRelation = ToolTipTextImageRelation.ImageBeforeText;
            HeaderItems = new List<string>();

            // Body Properties
            bodyInfo = new ToolTipInfo();
            bodyInfo.BackColor = ColorConfig.BackColorBlack;
            bodyInfo.BorderColor = ColorConfig.BorderColorLight;
            bodyInfo.ForeColor = ColorConfig.ForeColorGray;
            bodyInfo.Separator = true;
            bodyInfo.Body.ForeColor = ColorConfig.ForeColorGray;
            bodyInfo.Body.Font = FontConfig.FontSizeMedium;
            bodyInfo.Body.TextAlign = ContentAlignment.MiddleCenter;
            bodyInfo.Body.TextMargin = ControlConfig.Margin;
            BodyItems = new List<string>();

            // Footer Properties
            footerInfo = new ToolTipInfo();
            footerInfo.BackColor = ColorConfig.BackColorBlack;
            footerInfo.BorderColor = ColorConfig.BorderColorLight;
            footerInfo.ForeColor = ColorConfig.ForeColorGray;
            footerInfo.Separator = true;
            footerInfo.Footer.ForeColor = ColorConfig.ForeColorGray;
            footerInfo.Footer.Font = FontConfig.FontSizeSmall;
            footerInfo.Footer.TextAlign = ContentAlignment.MiddleCenter;
            footerInfo.Footer.TextMargin = ControlConfig.Margin;
            FooterItems = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HoverInfo" />
        /// class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="info">The information.</param>
        public HoverInfo( Component control, Info info )
            : this()
        {
            headerInfo.Header.Text = ControlConfig.GetText( info.Header );
            bodyInfo.Body.Text = ControlConfig.GetText( info.Body );
            footerInfo.Footer.Text = ControlConfig.GetText( info.Footer );
        }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the fading.
        /// </summary>
        /// <param name="fade">The fade.</param>
        public void SetFading( FadingType fade = FadingType.Blend )
        {
            if( Enum.IsDefined( typeof( FadingType ), fade ) )
            {
                try
                {
                    UseFading = fade;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the duration.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public void SetDuration( int seconds = 5 )
        {
            if( seconds > 0 )
            {
                try
                {
                    ToolTipDuration = seconds;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the tool tip style.
        /// </summary>
        /// <param name="style">The style.</param>
        public void SetToolTipStyle( SuperToolTipStyle style = SuperToolTipStyle.Office2013Style )
        {
            if( Enum.IsDefined( typeof( SuperToolTipStyle ), style ) )
            {
                try
                {
                    Style = style;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the visual style.
        /// </summary>
        /// <param name="visualstyle">The visualstyle.</param>
        public void SetVisualStyle( Appearance visualstyle = Appearance.Metro )
        {
            if( Enum.IsDefined( typeof( Appearance ), visualstyle ) )
            {
                try
                {
                    VisualStyle = visualstyle;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the header information.
        /// </summary>
        /// <returns></returns>
        public ToolTipInfo GetHeaderInfo()
        {
            try
            {
                return headerInfo;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ToolTipInfo );
            }
        }

        /// <summary>
        /// Adds the header item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddHeaderItem( string item )
        {
            if( Verify.Input( item ) )
            {
                try
                {
                    HeaderItems?.Add( item );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the body information.
        /// </summary>
        /// <returns></returns>
        public ToolTipInfo GetBodyInfo()
        {
            try
            {
                return bodyInfo;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ToolTipInfo );
            }
        }

        /// <summary>
        /// Adds the body item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddBodyItem( string item )
        {
            if( Verify.Input( item ) )
            {
                try
                {
                    BodyItems?.Add( item );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the footer information.
        /// </summary>
        /// <returns></returns>
        public ToolTipInfo GetFooterInfo()
        {
            try
            {
                return footerInfo;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ToolTipInfo );
            }
        }

        /// <summary>
        /// Adds the footer item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddFooterItem( string item )
        {
            if( Verify.Input( item ) )
            {
                try
                {
                    FooterItems?.Add( item );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the tool tip information.
        /// </summary>
        /// <param name="control">The control.</param>
        public void SetText( Component control )
        {
            if( control != null )
            {
                try
                {
                    if( Verify.Input( headerInfo?.Header?.Text ) )
                    {
                        SetToolTip( control, headerInfo );
                    }

                    if( Verify.Input( bodyInfo?.Body?.Text ) )
                    {
                        SetToolTip( control, bodyInfo );
                    }

                    if( Verify.Input( footerInfo?.Footer?.Text ) )
                    {
                        SetToolTip( control, footerInfo );
                    }
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
            if( Enum.IsDefined( typeof( Field ), field ) )
            {
                try
                {
                    Field = field;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
