﻿// <copyright file = "TitleInfo.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using Syncfusion.Windows.Forms.Chart;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.ITitleInfo" />
    [ SuppressMessage( "ReSharper", "GCSuppressFinalizeForTypeWithoutDestructor" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class TitleInfo : ITitleInfo
    {
        /// <summary>
        /// Gets the main.
        /// </summary>
        /// <value>
        /// The main.
        /// </value>
        public string Main { get; }

        /// <summary>
        /// Gets the axis.
        /// </summary>
        /// <value>
        /// The axis.
        /// </value>
        public string Axis { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleInfo"/> class.
        /// </summary>
        /// <param name="main">The main.</param>
        public TitleInfo( string main )
        {
            Main = main;
            Axis = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleInfo"/> class.
        /// </summary>
        /// <param name="main">The main.</param>
        /// <param name="axis">The axis.</param>
        public TitleInfo( string main, string axis )
        {
            Main = main;
            Axis = axis;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleInfo"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public TitleInfo( IDictionary<string, string> title )
        {
            Main = title.ContainsKey( "Main" )
                ? title[ "Main" ]
                : default;

            Axis = title.ContainsKey( "Axis" )
                ? title[ "Main" ]
                : default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleInfo"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public TitleInfo( IReadOnlyList<string> title )
        {
            Main = title[ 0 ] ?? string.Empty;
            Axis = title[ 1 ] ?? string.Empty;
        }

        /// <summary>
        /// Sets the main title.
        /// </summary>
        /// <returns></returns>
        public string GetMainText()
        {
            if( Verify.Input( Main ) )
            {
                try
                {
                    return Main;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the axis title.
        /// </summary>
        /// <returns></returns>
        public string GetAxisText()
        {
            if( Verify.Input( Axis ) )
            {
                try
                {
                    return Axis;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="main">The main.</param>
        /// <param name="axis">The axis.</param>
        /// <returns></returns>
        public IDictionary<string, string> SetData( string main, string axis )
        {
            if( Verify.Input( main )
                && Verify.Input( axis ) )
            {
                try
                {
                    var data = new Dictionary<string, string>
                    {
                        [ "Main" ] = main,
                        [ "Axis" ] = axis
                    };

                    return data;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the main title.
        /// </summary>
        /// <returns></returns>
        public ChartTitle GetChartMainTitle()
        {
            if( Verify.Input( Main ) )
            {
                try
                {
                    using var _title = new ChartTitle();
                    _title.Text = Main;
                    _title.ForeColor = ColorConfig.ForeGray;
                    _title.Visible = true;
                    _title.Font = FontConfig.FontSizeSmall;
                    _title.BackColor = ColorConfig.FormDarkBackColor;
                    return _title;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the axis title.
        /// </summary>
        /// <returns></returns>
        public ChartTitle GetChartAxisTitle()
        {
            if( Verify.Input( Axis ) )
            {
                try
                {
                    using var _title = new ChartTitle();
                    _title.Text = Main;
                    _title.ForeColor = ColorConfig.ForeGray;
                    _title.Visible = true;
                    _title.Font = FontConfig.FontSizeSmall;
                    _title.BackColor = ColorConfig.FormDarkBackColor;
                    return _title;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the main title.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public ChartTitle GetChartMainTitle( Color color, Font font )
        {
            if( !color.IsEmpty
                && font != null )
            {
                try
                {
                    using var _title = new ChartTitle();
                    _title.Text = Main;
                    _title.Visible = true;
                    _title.Font = font;
                    _title.ForeColor = color;
                    _title.BackColor = ColorConfig.FormDarkBackColor;
                    return _title;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the axis title.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public ChartTitle GetChartAxisTitle( Color color, Font font )
        {
            if( !color.IsEmpty
                && font != null )
            {
                try
                {
                    using var _title = new ChartTitle();
                    _title.Text = Main;
                    _title.Visible = true;
                    _title.Font = font;
                    _title.ForeColor = color;
                    _title.BackColor = ColorConfig.FormDarkBackColor;
                    return _title;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Fails the specified ex.
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