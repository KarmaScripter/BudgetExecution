﻿// ******************************************************************************************
//     Assembly:                Sherpa
//     Author:                  Terry D. Eppler
//     Created:                 05-16-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-16-2024
// ******************************************************************************************
// <copyright file="ErrorDialog.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   ErrorDialog.cs
// </summary>
// ******************************************************************************************

namespace Sherpa
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;

    /// <summary>
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm"/>
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public partial class ErrorDialog : MetroForm
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;
        
        /// <summary>
        /// The busy
        /// </summary>
        private bool _busy;
        
        /// <summary>
        /// The exception
        /// </summary>
        private protected Exception _exception;
        
        /// <summary>
        /// The title
        /// </summary>
        private protected string _titleText;
        
        /// <summary>
        /// The message
        /// </summary>
        private protected string _errorMessage;
        
        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;
        
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            private protected set
            {
                _exception = value;
            }
        }
        
        /// <summary>
        /// Gets the title text.
        /// </summary>
        /// <value>
        /// The title text.
        /// </value>
        public string TitleText
        {
            get
            {
                return _titleText;
            }
            private protected set
            {
                _titleText = value;
            }
        }
        
        /// <summary>
        /// Gets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            private protected set
            {
                _errorMessage = value;
            }
        }
        
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Sherpa.ErrorDialog"/>
        /// class.
        /// </summary>
        public ErrorDialog( )
        {
            InitializeComponent( );
            InitializeDelegates( );
            RegisterCallbacks( );
            
            // Form Property Values
            BackColor = Color.FromArgb( 20, 20, 20 );
            BorderThickness = 1;
            BorderColor = Color.Red;
            Size = new Size( 700, 450 );
            MaximumSize = new Size( 700, 450 );
            MinimumSize = new Size( 700, 450 );
            Font = new Font( "Roboto", 10 );
            CaptionBarColor = Color.FromArgb( 20, 20, 20 );
            CaptionBarHeight = 5;
            CaptionButtonColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = Color.FromArgb( 20, 20, 20 );
            CaptionAlign = HorizontalAlignment.Left;
            CaptionFont = new Font( "Roboto", 10, FontStyle.Bold );
            MetroColor = Color.FromArgb( 20, 20, 20 );
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ShowIcon = false;
            ShowMouseOver = false;
            ShowInTaskbar = true;
            Padding = new Padding( 1 );
            Text = string.Empty;
            
            // Event Wiring
            Load += OnLoad;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Sherpa.ErrorDialog" />
        /// class.
        /// </summary>
        /// <param name="exception"> The exception. </param>
        public ErrorDialog( Exception exception )
            : this( )
        {
            _exception = exception;
            _errorMessage = exception.ToLogString( Exception?.Message );
            _titleText = "There has been an error!";
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Sherpa.ErrorDialog" /> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="title">The title.</param>
        public ErrorDialog( Exception exception, string title )
            : this( )
        {
            _exception = exception;
            _errorMessage = exception.ToLogString( Exception?.Message );
            _titleText = title;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Sherpa.ErrorDialog" />
        /// class.
        /// </summary>
        /// <param name="errorMessage"> The message. </param>
        public ErrorDialog( string errorMessage )
            : this( )
        {
            _exception = new Exception( errorMessage );
            _errorMessage = _exception.ToLogString( errorMessage );
            _titleText = "There has been an error!";
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Sherpa.ErrorDialog" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        public ErrorDialog( string title, string message )
            : this( )
        {
            _exception = new Exception( message );
            _errorMessage = _exception.ToLogString( message );
            _titleText = title;
        }
        
        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                CloseButton.Click += OnCloseButtonClick;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the delegates.
        /// </summary>
        private void InitializeDelegates( )
        {
            try
            {
                _statusUpdate += UpdateStatus;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
                // Header Label Properties
                Title.ForeColor = Color.Red;
                Title.Font = new Font( "Roboto", 10 );
                Title.TextAlign = ContentAlignment.MiddleCenter;
                StatusLabel.Font = new Font( "Roboto", 8 );
                StatusLabel.TextAlign = ContentAlignment.MiddleRight;
                StatusLabel.ForeColor = Color.Red;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the text box.
        /// </summary>
        private void InitializeTextBox( )
        {
            try
            {
                // TextBox Properties
                TextBox.Font = new Font( "Roboto", 10 );
                TextBox.ForeColor = Color.White;
                TextBox.BackColor = Color.FromArgb( 40, 40, 40 );
                TextBox.BorderColor = Color.Maroon;
                TextBox.HoverColor = Color.Maroon;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer( )
        {
            try
            {
                // Timer Properties
                Timer.Interval = 80;
                Timer.Tick += OnTimerTick;
                Timer.Enabled = true;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Invokes if needed.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeIf( Action action )
        {
            try
            {
                ThrowIf.Null( action, nameof( action ) );
                if( InvokeRequired )
                {
                    BeginInvoke( action );
                }
                else
                {
                    action.Invoke( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private void BeginInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private void EndInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText( )
        {
            try
            {
                var _logString = _exception.ToLogString( "" );
                TextBox.Text = _logString;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
        {
            try
            {
                var _now = DateTime.Now;
                var _date = _now.ToShortDateString( );
                var _status = _now.ToLongTimeString( );
                StatusLabel.Text = $"{_date} - {_status}";
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary> Called when [load]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnLoad( object sender, EventArgs e )
        {
            try
            {
                InitializeLabels( );
                InitializeTextBox( );
                InitializeTimer( );
                if( !string.IsNullOrEmpty( _titleText )
                   && !string.IsNullOrEmpty( _errorMessage ) )
                {
                    TextBox.Text = _errorMessage;
                    Title.Text = _titleText;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary> Called when [close button click]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnCloseButtonClick( object sender, EventArgs e )
        {
            if( sender is Button )
            {
                try
                {
                    Close( );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }
        
        /// <summary>
        /// Called when [timer tick].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTimerTick( object sender, EventArgs e )
        {
            try
            {
                InvokeIf( _statusUpdate );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        private void Fail( Exception ex )
        {
            Console.WriteLine( ex.Message );
        }
    }
}