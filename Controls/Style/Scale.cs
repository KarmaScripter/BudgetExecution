﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 12-10-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-10-2023
// ******************************************************************************************
// <copyright file="Scale.cs" company="Terry D. Eppler">
//    Budget Execution is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    Contact at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Scale.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class Scale
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Scale" />
        /// class.
        /// </summary>
        public Scale( )
        {
        }

        /// <summary>
        /// The form normal
        /// </summary>
        public readonly Size FormNormal = new Size( 1350, 750 );

        /// <summary>
        /// The form maximum
        /// </summary>
        public readonly Size FormMaximum = new Size( 1350, 750 );

        /// <summary>
        /// The form minimum
        /// </summary>
        public readonly Size FormMinimum = new Size( 1340, 740 );

        /// <summary>
        /// The dialog normal
        /// </summary>
        public readonly Size ScreenNormal = new Size( 1340, 648 );

        /// <summary>
        /// The dialog minimum
        /// </summary>
        public readonly Size ScreenMinimum = new Size( 1330, 638 );

        /// <summary>
        /// The dialog maximum
        /// </summary>
        public readonly Size ScreenMaximum = new Size( 1340, 648 );

        /// <summary>
        /// The context menu normal
        /// </summary>
        public readonly Size ContextMenuNormal = new Size( 250, 350 );

        /// <summary>
        /// The context menu small
        /// </summary>
        public readonly Size ContextMenuSmall = new Size( 199, 158 );

        /// <summary>
        /// The image small
        /// </summary>
        public readonly Size ImageSmall = new Size( 16, 16 );

        /// <summary>
        /// The image medium
        /// </summary>
        public readonly Size ImageMedium = new Size( 18, 18 );

        /// <summary>
        /// The image large
        /// </summary>
        public readonly Size ImageLarge = new Size( 20, 20 );

        /// <summary>
        /// The image huge
        /// </summary>
        public readonly Size ImageExtra = new Size( 250, 250 );

        /// <summary>
        /// The guidance dialog
        /// </summary>
        public readonly Size GuidanceDialog = new Size( 568, 483 );

        /// <summary>
        /// The program project dialog
        /// </summary>
        public readonly Size ProgramProjectDialog = new Size( 1066, 614 );

        /// <summary>
        /// The message dialog
        /// </summary>
        public readonly Size MessageDialog = new Size( 700, 400 );

        /// <summary>
        /// The error dialog
        /// </summary>
        public readonly Size ErrorDialog = new Size( 700, 450 );

        /// <summary>
        /// The text dialog
        /// </summary>
        public readonly Size TextDialog = new Size( 650, 250 );

        /// <summary>
        /// The email dialog
        /// </summary>
        public readonly Size EmailDialog = new Size( 981, 742 );

        /// <summary>
        /// The calculator dialog
        /// </summary>
        public readonly Size Calculator = new Size( 0, 0 );

        /// <summary>
        /// The calendar dialog
        /// </summary>
        public readonly Size CalendarDialog = new Size( 0, 0 );

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public Size Create( int width = 1, int height = 1 )
        {
            try
            {
                return ( width > 0 ) && ( height > 0 )
                    ? new Size( width, height )
                    : Size.Empty;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( Size );
            }
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