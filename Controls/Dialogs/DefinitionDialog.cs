﻿//  ******************************************************************************************
//      Assembly:                Budget Execution
//      Filename:                DefinitionDialog.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="DefinitionDialog.cs" company="Terry D. Eppler">
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
//    DefinitionDialog.cs
//  </summary>
//  ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms.Tools;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:BudgetExecution.EditBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public partial class DefinitionDialog : EditBase
    {
        /// <summary>
        /// Gets or sets the type of the selected.
        /// </summary>
        /// <value>
        /// The type of the selected.
        /// </value>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the SQL query.
        /// </summary>
        /// <value>
        /// The SQL query.
        /// </value>
        public string SqlQuery { get; set; }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.DefinitionDialog"/>
        /// class.
        /// </summary>
        public DefinitionDialog( )
        {
            InitializeComponent( );

            // Basic Properties
            Size = new Size( 1340, 674 );
            MaximumSize = new Size( 1340, 674 );
            MinimumSize = new Size( 1340, 674 );
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb( 20, 20, 20 );
            ForeColor = Color.FromArgb( 106, 189, 252 );
            Font = new Font( "Roboto", 9 );
            ShowMouseOver = false;
            MinimizeBox = false;
            MaximizeBox = false;

            // Populate Controls
            TabPages = GetTabPages( );
            Panels = GetPanels( );
            ListBoxes = GetListBoxes( );
            RadioButtons = GetRadioButtons( );
            ComboBoxes = GetComboBoxes( );

            // Wire Events
            Load += OnLoad;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.DefinitionDialog"/>
        /// class.
        /// </summary>
        /// <param name="tool"> Type of the tool. </param>
        public DefinitionDialog( ToolType tool )
            : this( )
        {
            Tool = tool;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:BudgetExecution.DefinitionDialog"/>
        /// class.
        /// </summary>
        /// <param name="tool"> Type of the tool. </param>
        /// <param name="bindingSource"> The binding source. </param>
        public DefinitionDialog( ToolType tool, BindingSource bindingSource )
            : this( tool )
        {
            BindingSource = bindingSource;
            DataTable = (DataTable)bindingSource.DataSource;
            BindingSource.DataSource = DataTable;
            Source = (Source)Enum.Parse( typeof( Source ), DataTable.TableName );
            Columns = DataTable.GetColumnNames( );
        }

        /// <summary>
        /// Initializes the tab control.
        /// </summary>
        private void InitializeTabControl( )
        {
            try
            {
                TabPage.TabFont = new Font( "Roboto", 8, FontStyle.Regular );
                TabPage.TabForeColor = Color.FromArgb( 106, 189, 252 );
                TabControl.TabPanelBackColor = Color.FromArgb( 20, 20, 20 );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the text boxes.
        /// </summary>
        private void InitializeTextBoxes( )
        {
            try
            {
                TableNameTextBox.Font = new Font( "Roboto", 8, FontStyle.Regular );
                TableNameTextBox.ForeColor = Color.FromArgb( 106, 189, 252 );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeButtons( )
        {
            try
            {
                // Command Buttons
                DeleteColumnButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                AddColumnButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                AddTableButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                DeleteTableButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                SelectButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                CloseButton.ForeColor = Color.FromArgb( 106, 189, 252 );
                ClearButton.ForeColor = Color.FromArgb( 106, 189, 252 );

                // Radio Buttons
                SqliteRadioButton.Tag = "SQLite";
                SqlServerRadioButton.Tag = "SqlServer";
                AccessRadioButton.Tag = "Access";
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the combo boxes.
        /// </summary>
        private void InitializeComboBoxes( )
        {
            try
            {
                DataTypeComboBox.BackgroundColor = Color.FromArgb( 40, 40, 40 );
                TableNameComboBox.BackgroundColor = Color.FromArgb( 40, 40, 40 );
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
                AccessRadioButton.CheckedChanged += OnProviderButtonChecked;
                SqlServerRadioButton.CheckedChanged += OnProviderButtonChecked;
                SqliteRadioButton.CheckedChanged += OnProviderButtonChecked;
                CloseButton.Click += OnCloseButtonClicked;
                TabPage.MouseClick += OnRightClick;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Populates the table ComboBox items.
        /// </summary>
        private void PopulateTableComboBoxItems( )
        {
            try
            {
                TableNameComboBox.Items?.Clear( );
                TableNameComboBox.SelectedItem = string.Empty;
                var _model = new DataBuilder( Source.ApplicationTables, Provider.Access );
                var _data = _model.GetData( );
                var _names = _data
                    ?.Where( dr => dr.Field<string>( "Model" ).Equals( "EXECUTION" ) )
                    ?.Select( dr => dr.Field<string>( "TableName" ) )
                    ?.ToList( );

                for( var _i = 0; _i < _names?.Count - 1; _i++ )
                {
                    var _name = _names[ _i ];
                    TableNameComboBox.Items.Add( _name );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Populates the data type ComboBox items.
        /// </summary>
        public void PopulateDataTypeComboBoxItems( IEnumerable<string> dataTypes )
        {
            try
            {
                ThrowIf.Null( dataTypes, nameof( dataTypes ) );
                DataTypeComboBox.Items?.Clear( );
                DataTypeComboBox.SelectedText = string.Empty;
                var _types = dataTypes.ToArray( );
                for( var _i = 0; _i < _types?.Length; _i++ )
                {
                    if( !string.IsNullOrEmpty( _types[ _i ] ) )
                    {
                        DataTypeComboBox.Items.Add( _types[ _i ] );
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sets the active tab.
        /// </summary>
        private void SetActiveTab( )
        {
            if( Enum.IsDefined( typeof( ToolType ), Tool ) )
            {
                try
                {
                    switch( Tool )
                    {
                        case ToolType.AddDatabaseButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        case ToolType.AddTableButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        case ToolType.EditColumnButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        case ToolType.DeleteColumnButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        case ToolType.DeleteTableButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        case ToolType.DeleteDatabaseButton:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                        default:
                        {
                            ActiveTab = TabPage;
                            AccessRadioButton.Checked = true;
                            break;
                        }
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary> Called when [load]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnLoad( object sender, EventArgs e )
        {
            try
            {
                InitializeCallbacks( );
                InitializeButtons( );
                InitializeTabControl( );
                InitializeComboBoxes( );
                DataArgs = new DataArgs( );
                Fields = new List<string>( );
                Columns = new List<string>( );
                Dates = new List<DateTime>( );
                CloseButton.Text = "Exit";
                DataTypes = GetDataTypes( Provider );
                PopulateDataTypeComboBoxItems( DataTypes );
                SetActiveTab( );
                PopulateTableComboBoxItems( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [provider button checked].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        private void OnProviderButtonChecked( object sender )
        {
            if( sender is RadioButton _button )
            {
                try
                {
                    var _name = _button.Tag?.ToString( );
                    if( !string.IsNullOrEmpty( _name ) )
                    {
                        Provider = (Provider)Enum.Parse( typeof( Provider ), _name );
                        DataTypes = GetDataTypes( Provider );
                        PopulateDataTypeComboBoxItems( DataTypes );
                        PopulateTableComboBoxItems( );
                    }
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }

        /// <summary> Called when [close button clicked]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnCloseButtonClicked( object sender, EventArgs e )
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

        /// <summary> Called when [right click]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="MouseEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnRightClick( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                try
                {
                    //FormMenu.Show( this, e.Location );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                }
            }
        }
    }
}