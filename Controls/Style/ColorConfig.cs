﻿//  ******************************************************************************************
//      Assembly:                Budget Execution
//      Filename:                ColorConfig.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="ColorConfig.cs" company="Terry D. Eppler">
// 
//     This is a Federal Budget, Finance, and Accounting application for the
//     US Environmental Protection Agency (US EPA).
//     Copyright ©  2023  Terry Eppler
// 
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the “Software”),
//     to deal in the Software without restriction,
//     including without limitation the rights to use,
//     copy, modify, merge, publish, distribute, sublicense,
//     and/or sell copies of the Software,
//     and to permit persons to whom the Software is furnished to do so,
//     subject to the following conditions:
// 
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//     INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//     IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//     DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//     ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//     DEALINGS IN THE SOFTWARE.
// 
//     You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// 
//  </copyright>
//  <summary>
//    ColorConfig.cs
//  </summary>
//  ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using DocumentFormat.OpenXml.Drawing;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ColorConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public Color DarkGreen { get; }

        /// <summary>
        /// 
        /// </summary>
        public Color LightGreen { get; }

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>
        /// The blue.
        /// </value>
        public Color Blue { get; }

        /// <summary>
        /// Gets the red.
        /// </summary>
        /// <value>
        /// The red.
        /// </value>
        public Color Red { get; }

        /// <summary>
        /// Gets the gray.
        /// </summary>
        /// <value>
        /// The gray.
        /// </value>
        public Color Gray { get; }

        /// <summary>
        /// Gets the white.
        /// </summary>
        /// <value>
        /// The white.
        /// </value>
        public Color White { get; }

        /// <summary>
        /// Gets the black.
        /// </summary>
        /// <value>
        /// The black.
        /// </value>
        public Color Black { get; }

        /// <summary>
        /// Gets the transparent.
        /// </summary>
        /// <value>
        /// The transparent.
        /// </value>
        public Color Transparent { get; }

        /// <summary>
        /// Gets the hover gray.
        /// </summary>
        /// <value>
        /// The hover gray.
        /// </value>
        public Color HoverGray { get; }

        /// <summary>
        /// Gets the hover blue.
        /// </summary>
        /// <value>
        /// The hover blue.
        /// </value>
        public Color HoverBlue { get; }

        /// <summary>
        /// Gets the steel blue.
        /// </summary>
        /// <value>
        /// The steel blue.
        /// </value>
        public Color SteelBlue { get; }

        /// <summary>
        /// Gets the maroon.
        /// </summary>
        /// <value>
        /// The maroon.
        /// </value>
        public Color Maroon { get; }

        /// <summary>
        /// Gets the light blue.
        /// </summary>
        /// <value>
        /// The light blue.
        /// </value>
        public Color LightBlue { get; }

        /// <summary>
        /// Gets the dark interior.
        /// </summary>
        /// <value>
        /// The dark interior.
        /// </value>
        public Color DarkInterior { get; }

        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>
        /// The dark border.
        /// </value>
        public Color DarkBorder { get; }

        /// <summary>
        /// Gets the dark background.
        /// </summary>
        /// <value>
        /// The dark background.
        /// </value>
        public Color DarkBackground { get; }

        /// <summary>
        /// Gets the hover dark blue.
        /// </summary>
        /// <value>
        /// The hover dark blue.
        /// </value>
        public Color HoverDarkBlue { get; }

        /// <summary>
        /// Gets the dodger blue.
        /// </summary>
        /// <value>
        /// The dodger blue.
        /// </value>
        public Color DodgerBlue { get; }

        /// <summary>
        /// Gets the metro blue.
        /// </summary>
        /// <value>
        /// The metro blue.
        /// </value>
        public Color MetroBlue { get; }

        /// <summary>
        /// Gets the blue highlight.
        /// </summary>
        /// <value>
        /// The blue highlight.
        /// </value>
        public Color BlueHighlight { get; }

        /// <summary>
        /// Gets the color of the notification.
        /// </summary>
        /// <value>
        /// The color of the notification.
        /// </value>
        public Color NotificationColor { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ColorConfig"/> class.
        /// </summary>
        public ColorConfig( )
        {
            Blue = Color.FromArgb( 0, 120, 212 );
            BlueHighlight = Color.FromArgb( 106, 189, 252 );
            HoverBlue = Color.FromArgb( 50, 93, 129 );
            MetroBlue = Color.FromArgb( 65, 177, 225 );
            HoverDarkBlue = Color.FromArgb( 24, 47, 66 );
            Transparent = Color.Transparent;
            HoverGray = Color.FromArgb( 70, 70, 70 );
            DarkInterior = Color.FromArgb( 70, 70, 70 );
            Black = Color.Black;
            White = Color.White;
            Red = Color.FromArgb( 192, 0, 0 );
            DarkBorder = Color.FromArgb( 65, 65, 65 );
            DarkBackground = Color.FromArgb( 20, 20, 20 );
            Gray = Color.DarkGray;
            SteelBlue = Color.SteelBlue;
            DodgerBlue = Color.DodgerBlue;
            Maroon = Color.Maroon;
            LightBlue = Color.LightSteelBlue;
            NotificationColor = Color.FromArgb( 0, 73, 112 );
            DarkGreen = Color.ForestGreen;
            LightGreen = Color.LimeGreen;
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}