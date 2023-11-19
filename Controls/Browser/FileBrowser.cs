﻿//  ******************************************************************************************
//      Assembly:                Budget Execution
//      Filename:                FileBrowser.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="FileBrowser.cs" company="Terry D. Eppler">
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
//    FileBrowser.cs
//  </summary>
//  ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Collections;
    using System.Windows.Forms;
    using static System.Configuration.ConfigurationManager;
    using static System.Environment;
    using static System.IO.Directory;
    using CheckState = MetroSet_UI.Enums.CheckState;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public partial class FileBrowser
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
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public EXT Extension { get; set; }

        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
        public string FileExtension { get; set; }

        /// <summary>
        /// Gets or sets the initial dir paths.
        /// </summary>
        /// <value>
        /// The initial dir paths.
        /// </value>
        public IEnumerable<string> InitialDirPaths { get; set; }

        /// <summary>
        /// Gets or sets the file paths.
        /// </summary>
        /// <value>
        /// The file paths.
        /// </value>
        public IEnumerable<string> FilePaths { get; set; }

        /// <summary>
        /// Gets or sets the radio buttons.
        /// </summary>
        /// <value>
        /// The radio buttons.
        /// </value>
        public IEnumerable<RadioButton> RadioButtons { get; set; }

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>
        /// The selected path.
        /// </value>
        public string SelectedPath { get; set; }

        /// <summary>
        /// Gets or sets the selected file.
        /// </summary>
        /// <value>
        /// The selected file.
        /// </value>
        public string SelectedFile { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.FileBrowser" /> class.
        /// </summary>
        public FileBrowser( )
        {
            InitializeComponent( );
            Font = new Font( "Roboto", 9 );
            ForeColor = Color.FromArgb( 106, 189, 252 );
            Margin = new Padding( 3 );
            Padding = new Padding( 1 );
            Size = new Size( 700, 480 );
            MaximumSize = new Size( 700, 480 );
            MinimumSize = new Size( 700, 480 );
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BorderColor = Color.FromArgb( 0, 120, 212 );
            BorderThickness = 1;
            BackColor = Color.FromArgb( 20, 20, 20 );
            InitialDirPaths = GetInitialDirPaths( );
            RadioButtons = GetRadioButtons( );
            FileExtension = "xlsx";
            Extension = EXT.XLSX;
            PictureBox.Image = GetImage( );
            FilePaths = GetListViewPaths( );
            FileList.BackColor = Color.FromArgb( 40, 40, 40 );
            CaptionBarHeight = 5;
            CaptionBarColor = Color.FromArgb( 20, 20, 20 );
            CaptionForeColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonColor = Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = Color.FromArgb( 20, 20, 20 );
            ShowMouseOver = false;
            MinimizeBox = false;
            MaximizeBox = false;

            // Event Wiring
            Load += OnLoad;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.FileBrowser" /> class.
        /// </summary>
        /// <param name="extension">The extension.</param>
        public FileBrowser( EXT extension )
            : this( )
        {
            Extension = extension;
            FileExtension = Extension.ToString( ).ToLower( );
        }

        /// <summary>
        /// Populates the ListBox.
        /// </summary>
        /// <param name="filePaths">The file paths.</param>
        public virtual void PopulateListBox( IEnumerable<string> filePaths )
        {
            try
            {
                if( filePaths?.Any( ) == true )
                {
                    FileList.Items?.Clear( );
                    var _paths = filePaths.ToArray( );
                    for( var _i = 0; _i < _paths.Length; _i++ )
                    {
                        var _path = _paths[ _i ];
                        if( !string.IsNullOrEmpty( _path ) )
                        {
                            FileList?.Items?.Add( _path );
                        }
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns></returns>
        private protected Image GetImage( )
        {
            if( !string.IsNullOrEmpty( FileExtension ) )
            {
                try
                {
                    var _path = AppSettings[ "Extensions" ];
                    if( _path != null )
                    {
                        var _files = GetFiles( _path );
                        if( _files?.Any( ) == true )
                        {
                            var _extension = FileExtension.TrimStart( '.' ).ToUpper( );
                            var _file = _files
                                ?.Where( f => f.Contains( _extension ) )
                                ?.First( );

                            using var _stream = File.Open( _file, FileMode.Open );
                            var _img = Image.FromStream( _stream );
                            return new Bitmap( _img, 22, 22 );
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( Bitmap );
                }
            }

            return default( Bitmap );
        }

        /// <summary>
        /// Clears the radio buttons.
        /// </summary>
        private protected void ClearRadioButtons( )
        {
            try
            {
                foreach( var _radioButton in RadioButtons )
                {
                    _radioButton.CheckedChanged += null;
                    _radioButton.CheckState = CheckState.Unchecked;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sets the RadioButton events.
        /// </summary>
        private protected void SetRadioButtonEvents( )
        {
            try
            {
                foreach( var _radioButton in RadioButtons )
                {
                    _radioButton.CheckedChanged += OnRadioButtonSelected;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Gets the ListView paths.
        /// </summary>
        /// <returns></returns>
        private protected IEnumerable<string> GetListViewPaths( )
        {
            if( InitialDirPaths?.Any( ) == true )
            {
                try
                {
                    var _list = new List<string>( );
                    foreach( var _filePath in InitialDirPaths )
                    {
                        var _first = GetFiles( _filePath )
                            ?.Where( f => f.EndsWith( FileExtension ) )
                            ?.Select( f => Path.GetFullPath( f ) )
                            ?.ToList( );

                        _list.AddRange( _first );
                        var _dirs = GetDirectories( _filePath );
                        foreach( var _dir in _dirs )
                        {
                            if( !_dir.Contains( "My " ) )
                            {
                                var _second = GetFiles( _dir )
                                    ?.Where( s => s.EndsWith( FileExtension ) )
                                    ?.Select( s => Path.GetFullPath( s ) )
                                    ?.ToList( );

                                if( _second?.Any( ) == true )
                                {
                                    _list.AddRange( _second );
                                }

                                var _subDir = GetDirectories( _dir );
                                for( var _i = 0; _i < _subDir.Length; _i++ )
                                {
                                    var _path = _subDir[ _i ];
                                    if( !string.IsNullOrEmpty( _path ) )
                                    {
                                        var _last = GetFiles( _path )
                                            ?.Where( l => l.EndsWith( FileExtension ) )
                                            ?.Select( l => Path.GetFullPath( l ) )
                                            ?.ToList( );

                                        if( _last?.Any( ) == true )
                                        {
                                            _list.AddRange( _last );
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return _list?.Any( ) == true
                        ? _list
                        : default( IEnumerable<string> );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// Gets the radio buttons.
        /// </summary>
        /// <returns></returns>
        private protected virtual IEnumerable<RadioButton> GetRadioButtons( )
        {
            try
            {
                var _list = new List<RadioButton>
                {
                    PdfRadioButton,
                    AccessRadioButton,
                    SQLiteRadioButton,
                    SqlCeRadioButton,
                    SqlServerRadioButton,
                    ExcelRadioButton,
                    CsvRadioButton,
                    TextRadioButton,
                    PowerPointRadioButton,
                    WordRadioButton,
                    ExecutableRadioButton,
                    LibraryRadioButton
                };

                return _list?.Any( ) == true
                    ? _list
                    : default( IEnumerable<RadioButton> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IEnumerable<RadioButton> );
            }
        }

        /// <summary>
        /// Gets the initial dir paths.
        /// </summary>
        /// <returns></returns>
        private protected virtual IEnumerable<string> GetInitialDirPaths( )
        {
            try
            {
                var _current = CurrentDirectory;
                var _list = new List<string>
                {
                    GetFolderPath( SpecialFolder.DesktopDirectory ),
                    GetFolderPath( SpecialFolder.Personal ),
                    GetFolderPath( SpecialFolder.Recent ),
                    @"C:\Users\terry\source\repos\BudgetExecution\Resources\Documents",
                    _current
                };

                return _list?.Any( ) == true
                    ? _list
                    : default( IEnumerable<string> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Populates the ListBox.
        /// </summary>
        private protected virtual void PopulateListBox( )
        {
            if( FilePaths?.Any( ) == true )
            {
                try
                {
                    foreach( var _path in FilePaths )
                    {
                        FileList.Items.Add( _path );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }
        
        /// <summary>
        /// Invokes if needed.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public void InvokeIf( Action action )
        {
            if( InvokeRequired )
            {
                BeginInvoke( action );
            }
            else
            {
                action.Invoke( );
            }
        }

        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
                // Title Properties
                Title.ForeColor = Color.FromArgb( 106, 189, 252 );
                Title.TextAlign = ContentAlignment.TopLeft;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void InitializeCallbacks( )
        {
            try
            {
                CloseButton.Click += OnCloseButtonClicked;
                FileList.SelectedValueChanged += OnPathSelected;
                FindButton.Click += OnFindButtonClicked;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the timers.
        /// </summary>
        private void InitializeTimers( )
        {
            try
            {
                // Timer Properties
                Time = 0;
                Seconds = 5;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        private void InitializeButtons( )
        {
            try
            {
                CloseButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                FindButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                SelectButton.ForeColor = Color.FromArgb( 106, 189, 252 );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
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
        /// Gets the controls.
        /// </summary>
        /// <returns>
        /// </returns>
        private IEnumerable<Control> GetControls( )
        {
            var _list = new List<Control>( );
            var _queue = new Queue( );
            try
            {
                _queue.Enqueue( Controls );
                while( _queue.Count > 0 )
                {
                    var _collection = (Control.ControlCollection)_queue.Dequeue( );
                    if( _collection?.Count > 0 )
                    {
                        foreach( Control _control in _collection )
                        {
                            _list.Add( _control );
                            _queue.Enqueue( _control.Controls );
                        }
                    }
                }

                return _list?.Any( ) == true
                    ? _list.ToArray( )
                    : default( Control[ ] );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( Control[ ] );
            }
        }

        /// <summary>
        /// Called when [RadioButton selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private protected virtual void OnRadioButtonSelected( object sender )
        {
            if( sender is RadioButton _radioButton
               && !string.IsNullOrEmpty( _radioButton.Tag?.ToString( ) ) )
            {
                try
                {
                    FileExtension = _radioButton?.Result;
                    var _ext = _radioButton.Tag?.ToString( )
                        ?.Trim( ".".ToCharArray( ) )
                        ?.ToUpper( );

                    Title.Text = $"{_ext} File Search";
                    MessageLabel.Text = string.Empty;
                    FoundLabel.Text = string.Empty;
                    var _paths = GetListViewPaths( );
                    PopulateListBox( _paths );
                    PictureBox.Image = GetImage( );
                    FoundLabel.Text = "Found: " + _paths?.ToList( )?.Count ?? "0";
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnLoad( object sender, EventArgs e )
        {
            if( FilePaths?.Any( ) == true )
            {
                try
                {
                    InitializeLabels( );
                    InitializeButtons( );
                    InitializeCallbacks( );
                    PopulateListBox( );
                    FoundLabel.Text = "Found : " + FilePaths?.Count( );
                    Title.Text = $"{Extension} File Search";
                    ClearRadioButtons( );
                    SetRadioButtonEvents( );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Called when [path selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private protected virtual void OnPathSelected( object sender )
        {
            if( sender is ListBox _listBox
               && !string.IsNullOrEmpty( _listBox.SelectedItem?.ToString( ) ) )
            {
                try
                {
                    SelectedPath = _listBox.SelectedItem?.ToString( );
                    MessageLabel.Text = SelectedPath;
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Called when [find button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private protected virtual void OnFindButtonClicked( object sender, EventArgs e )
        {
            if( sender is Button )
            {
                try
                {
                    FileDialog = new OpenFileDialog( );
                    FileDialog.DefaultExt = FileExtension;
                    FileDialog.CheckFileExists = true;
                    FileDialog.CheckPathExists = true;
                    FileDialog.Multiselect = false;
                    var _ext = FileExtension.ToLower( );
                    FileDialog.Filter = $@"File Extension | *{_ext}";
                    FileDialog.Title = $@"Search Directories for *{_ext} files...";
                    FileDialog.InitialDirectory = GetFolderPath( SpecialFolder.DesktopDirectory );
                    FileDialog.ShowDialog( );
                    var _selectedPath = FileDialog.FileName;
                    if( !string.IsNullOrEmpty( _selectedPath ) )
                    {
                        SelectedPath = _selectedPath;
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary>
        /// Called when [close button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private protected virtual void OnCloseButtonClicked( object sender, EventArgs e )
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