// <copyright file = "ColorConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OfficeOpenXml.Style;
    using Syncfusion.XlsIO;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class ColorConfig
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The orange border
        /// </summary>
        public static readonly Color BorderColorLight = Color.FromArgb( 128, 64, 0 );

        /// <summary>
        /// The gray border
        /// </summary>
        public static readonly Color BorderColorDark = Color.FromArgb( 40, 40, 41 );

        /// <summary>
        /// The red border
        /// </summary>
        public static readonly Color BorderColorRed = Color.FromArgb( 192, 0, 0 );

        /// <summary>
        /// The black background
        /// </summary>
        public static readonly Color BackColorBlack = Color.FromArgb( 10, 10, 11 );

        /// <summary>
        /// The red foreground
        /// </summary>
        public static readonly Color ForeColorRed = Color.FromArgb( 192, 0, 0 );

        /// <summary>
        /// The gray foreground
        /// </summary>
        public static readonly Color ForeColorGray = Color.LightGray;

        /// <summary>
        /// The white foreground
        /// </summary>
        public static readonly Color ForeColorWhite = Color.White;

        /// <summary>
        /// The black foreground
        /// </summary>
        public static readonly Color ForeColorBlack = Color.Black;

        /// <summary>
        /// The clear background
        /// </summary>
        public static readonly Color BackColorClear = Color.Transparent;

        /// <summary>
        /// The gray background
        /// </summary>
        public static readonly Color ControlInteriorBlack = Color.FromArgb( 20, 20, 21 );

        /// <summary>
        /// The gray back hover
        /// </summary>
        public static readonly Color ControlHoverGray = Color.FromArgb( 28, 28, 29 );

        /// <summary>
        /// The blue back hover
        /// </summary>
        public static readonly Color ControlHoverBlue = Color.SteelBlue;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorConfig" /> class.
        /// </summary>
        public ColorConfig()
        {
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Color GetColor( Color color )
        {
            try
            {
                return color != Color.Empty
                    ? color
                    : Color.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Color.Empty;
            }
        }

        /// <summary>
        /// Gets the excel fill style.
        /// </summary>
        /// <param name="fillstyle">The fillstyle.</param>
        /// <returns></returns>
        public static ExcelFillStyle GetExcelFillStyle( ExcelFillStyle fillstyle = ExcelFillStyle.None )
        {
            try
            {
                return Enum.IsDefined( typeof( ExcelFillStyle ), fillstyle )
                    ? fillstyle
                    : ExcelFillStyle.None;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ExcelFillStyle.None;
            }
        }

        /// <summary>
        /// Gets the type of the excel fill gradient.
        /// </summary>
        /// <param name="gradient">The gradient.</param>
        /// <returns></returns>
        public static ExcelFillGradientType GetExcelFillGradientType( ExcelFillGradientType gradient = 
            ExcelFillGradientType.None )
        {
            try
            {
                return Enum.IsDefined( typeof( ExcelFillGradientType ), gradient )
                    ? gradient
                    : ExcelFillGradientType.None;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ExcelFillGradientType.None;
            }
        }

        /// <summary>
        /// Gets the type of the spreadsheet fill.
        /// </summary>
        /// <param name="filltype">The filltype.</param>
        /// <returns></returns>
        public static ExcelFillType GetSpreadsheetFillType( ExcelFillType filltype =
            ExcelFillType.UnknownGradient )
        {
            try
            {
                return Enum.IsDefined( typeof( ExcelFillType ), filltype )
                    ? filltype
                    : ExcelFillType.UnknownGradient;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ExcelFillType.UnknownGradient;
            }
        }

        /// <summary>
        /// Gets the spreadsheet gradient style.
        /// </summary>
        /// <param name="gradient">The gradient.</param>
        /// <returns></returns>
        public static ExcelGradientStyle GetSpreadsheetGradientStyle( ExcelGradientStyle gradient =
            ExcelGradientStyle.Horizontal )
        {
            try
            {
                return Enum.IsDefined( typeof( ExcelGradientStyle ), gradient )
                    ? gradient
                    : ExcelGradientStyle.Horizontal;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ExcelGradientStyle.Horizontal;
            }
        }

        // **************************************************************************************************************************
        // ********************************************      EVENTS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Called when [color changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void OnColorChanged( object sender, EventArgs e )
        {
            if( sender != null
                && e != null )
            {
                try
                {
                    using var message = new Message( "NOT YET IMPLEMENTED" );
                    message?.ShowDialog();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
