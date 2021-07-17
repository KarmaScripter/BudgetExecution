// <copyright file = "ExcelSettings.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OfficeOpenXml.Style;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public abstract class ExcelSettings
    {
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The index
        /// </summary>
        private protected readonly int index = 10;

        /// <summary>
        /// The file path
        /// </summary>
        private protected readonly string filePath =
            ConfigurationManager.AppSettings[ Document.Budget.ToString() ];

        /// <summary>
        /// The file name
        /// </summary>
        private protected readonly string fileName = @"\<Source>\<name>";

        /// <summary>
        /// The background color
        /// </summary>
        private protected readonly Color primaryBackColor = Color.FromArgb( 255, 242, 242, 242 );

        /// <summary>
        /// The secondary back color
        /// </summary>
        private protected readonly Color secondaryBackColor = Color.FromArgb( 255, 221, 235, 247 );

        /// <summary>
        /// The left
        /// </summary>
        private protected readonly ExcelHorizontalAlignment left = ExcelHorizontalAlignment.Left;

        /// <summary>
        /// The center
        /// </summary>
        private protected readonly ExcelHorizontalAlignment center =
            ExcelHorizontalAlignment.CenterContinuous;

        /// <summary>
        /// The right
        /// </summary>
        private protected readonly ExcelHorizontalAlignment right = ExcelHorizontalAlignment.Right;

        /// <summary>
        /// The row height
        /// </summary>
        private protected readonly double rowHeight = 0.22;

        /// <summary>
        /// The column width
        /// </summary>
        private protected readonly double columnWidth = 0.75;

        /// <summary>
        /// The top margin
        /// </summary>
        private protected readonly int topMargin = 1;

        /// <summary>
        /// The bottom marging
        /// </summary>
        private protected readonly int bottomMarging = 1;

        /// <summary>
        /// The left margin
        /// </summary>
        private protected readonly decimal leftMargin = 0.25m;

        /// <summary>
        /// The right margin
        /// </summary>
        private protected readonly decimal rightMargin = 0.25m;

        /// <summary>
        /// The header margin
        /// </summary>
        private protected readonly decimal headerMargin = 0.25m;

        /// <summary>
        /// The footer margin
        /// </summary>
        private protected readonly decimal footerMargin = 0.25m;

        /// <summary>
        /// The column count
        /// </summary>
        private protected readonly int columnCount = 12;

        /// <summary>
        /// The row count
        /// </summary>
        private protected readonly int rowCount = 55;

        /// <summary>
        /// The zoom level
        /// </summary>
        private protected readonly int zoomLevel = 100;

        /// <summary>
        /// 
        /// </summary>
        public enum BorderSide
        {
            Top,

            Bottom,

            Left,

            Right
        };
    }
}
