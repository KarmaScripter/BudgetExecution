﻿//  ******************************************************************************************
//      Assembly:                Budget Execution
//      Filename:                Notification.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="Notification.cs" company="Terry D. Eppler">
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
//    Notification.cs
//  </summary>
//  ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;
    using static System.Drawing.Region;
    using static System.Windows.Forms.Screen;
    using static FormAnimator;
    using static NativeMethods;
    using Timer = System.Windows.Forms.Timer;

    /// <summary>
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm"/>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    [SuppressMessage( "ReSharper", "ReplaceAutoPropertyWithComputedProperty" )]
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    public partial class Notification : MetroForm
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value> The seconds. </value>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow focus].
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if [allow focus]; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public bool AllowFocus { get; set; }

        /// <summary>
        /// Gets a value indicating whether [shown without activation].
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if [shown without activation]; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public bool ShownWithoutActivation { get; } = true;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.Notification" />
        /// class.
        /// </summary>
        public Notification( )
        {
            InitializeComponent( );

            // Form Properties
            DoubleBuffered = true;
            Size = new Size( 400, 190 );
            MinimumSize = new Size( 400, 190 );
            MaximumSize = new Size( 400, 190 );
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            ShowIcon = false;
            ShowMouseOver = false;
            ShowInTaskbar = true;
            FormBorderStyle = FormBorderStyle.None;
            SizeGripStyle = SizeGripStyle.Hide;
            Padding = new Padding( 0 );
            Layout.BackColor = Color.FromArgb( 0, 73, 112 );
            Layout.BorderColor = Color.FromArgb( 0, 73, 112 );
            Title.ForeColor = Color.White;
            BorderColor = Color.FromArgb( 0, 73, 112 );
            BackColor = Color.FromArgb( 0, 73, 112 );
            CaptionBarColor = Color.FromArgb( 0, 73, 112 );
            Message.BackColor = Color.FromArgb( 0, 73, 112 );
            Message.ForeColor = Color.White;

            // Event Wiring
            Resize += OnResized;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.Notification" />
        /// class.
        /// </summary>
        /// <param name="body"> The body. </param>
        /// <param name="duration"> The duration. </param>
        /// <param name="animation"> The animation. </param>
        /// <param name="direction"> The direction. </param>
        public Notification( string body, int duration = 5,
            AnimationMethod animation = AnimationMethod.Fade,
            AnimationDirection direction = AnimationDirection.Up )
            : this( )
        {
            Load += OnLoad;
            Time = 0;
            Seconds = duration;
            Timer.Interval = duration * 1000;
            Title.Text = "Notification";
            Message.Text = body;
            Click += ( s, e ) => Close( );
            Message.Click += ( s, e ) => Close( );
            Title.Click += ( s, e ) => Close( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.Notification" />
        /// class.
        /// </summary>
        /// <param name="title"> The title. </param>
        /// <param name="body"> The body. </param>
        /// <param name="duration"> The duration. </param>
        /// <param name="animation"> The animation. </param>
        /// <param name="direction"> The direction. </param>
        public Notification( string title, string body, int duration = 5,
            AnimationMethod animation = AnimationMethod.Fade,
            AnimationDirection direction = AnimationDirection.Up )
            : this( )
        {
            Load += OnLoad;
            Time = 0;
            Seconds = duration;
            Timer.Interval = duration * 1000;
            Title.Text = title;
            Message.Text = body;
            Click += ( s, e ) => Close( );
            Message.Click += ( s, e ) => Close( );
            Title.Click += ( s, e ) => Close( );
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show( )
        {
            try
            {
                Opacity = 0;
                if( Seconds != 0 )
                {
                    Timer = new Timer( );
                    Timer.Interval = 1000;
                    Timer.Tick += ( sender, args ) =>
                    {
                        Time++;
                        if( Time == Seconds )
                        {
                            Timer.Stop( );
                            FadeOut( );
                        }
                    };
                }

                base.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnLoad( object sender, EventArgs e )
        {
            try
            {
                Location = new Point( PrimaryScreen.WorkingArea.Width - Width - 5,
                    PrimaryScreen.WorkingArea.Height - Height - 5 );

                FadeIn( );
                Timer.Start( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Notifications the close.
        /// </summary>
        public void OnClose( )
        {
            try
            {
                FadeOut( );
                Close( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Fades the in.
        /// </summary>
        private void FadeIn( )
        {
            try
            {
                var _timer = new Timer( );
                _timer.Interval = 10;
                _timer.Tick += ( sender, args ) =>
                {
                    if( Opacity == 1d )
                    {
                        _timer.Stop( );
                    }

                    Opacity += 0.02d;
                };

                _timer.Start( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Fades the out and close.
        /// </summary>
        private void FadeOut( )
        {
            try
            {
                var _timer = new Timer( );
                _timer.Interval = 10;
                _timer.Tick += ( sender, args ) =>
                {
                    if( Opacity == 0d )
                    {
                        _timer.Stop( );
                        Close( );
                    }

                    Opacity -= 0.02d;
                };

                _timer.Start( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [resized].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnResized( object sender, EventArgs e )
        {
            try
            {
                if( WindowState == FormWindowState.Minimized )
                {
                    WindowState = FormWindowState.Normal;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Get ErrorDialog Dialog.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        private protected void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}