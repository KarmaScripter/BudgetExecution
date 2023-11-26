﻿namespace BudgetExecution
{


    partial class ExcelDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            components = new System.ComponentModel.Container( );
            var spreadsheetCopyPaste1 = new Syncfusion.Windows.Forms.Spreadsheet.SpreadsheetCopyPaste( );
            var formulaRangeSelectionController1 = new Syncfusion.Windows.Forms.Spreadsheet.FormulaRangeSelectionController( );
            var resources = new System.ComponentModel.ComponentResourceManager( typeof( ExcelDataForm ) );
            Ribbon = new Syncfusion.Windows.Forms.Spreadsheet.SpreadsheetRibbon( );
            Spreadsheet = new Syncfusion.Windows.Forms.Spreadsheet.Spreadsheet( );
            BindingSource = new System.Windows.Forms.BindingSource( components );
            ToolStrip = new ToolStrip( );
            CloseButton = new ToolStripButton( );
            ToolTip = new SmallTip( );
            Separator1 = new ToolSeparator( );
            StripSeparator = new ToolSeparator( );
            StatusLabel = new Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt( );
            Separator2 = new ToolSeparator( );
            ToolStripTextBox = new ToolStripTextBox( );
            Separator3 = new ToolSeparator( );
            Label3 = new Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt( );
            FunctionLabel = new ToolStripLabel( );
            Separator5 = new ToolSeparator( );
            BrowseButton = new ToolStripButton( );
            Separator7 = new ToolSeparator( );
            SaveButton = new ToolStripButton( );
            FilterSpacer = new ToolStripLabel( );
            FilterLabel = new ToolStripLabel( );
            DataSourceSeparator = new ToolSeparator( );
            LookupButton = new ToolStripButton( );
            FilterSeparator = new ToolSeparator( );
            FiltersButton = new ToolStripButton( );
            SqlSeparator = new ToolSeparator( );
            BackButtonSeparator = new ToolSeparator( );
            Separator10 = new ToolSeparator( );
            MenuButton = new ToolStripButton( );
            Label4 = new Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt( );
            Label6 = new Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt( );
            Separator9 = new ToolSeparator( );
            Separator11 = new ToolSeparator( );
            ContextMenu = new ContextMenu( );
            HeaderPanel = new System.Windows.Forms.TableLayoutPanel( );
            Header = new Label( );
            PictureBox = new System.Windows.Forms.PictureBox( );
            LabelSeparator = new ToolSeparator( );
            Timer = new System.Windows.Forms.Timer( components );
            ToolStripTable = new System.Windows.Forms.TableLayoutPanel( );
            ( (System.ComponentModel.ISupportInitialize)Ribbon ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize)BindingSource ).BeginInit( );
            ToolStrip.SuspendLayout( );
            HeaderPanel.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)PictureBox ).BeginInit( );
            ToolStripTable.SuspendLayout( );
            SuspendLayout( );
            // 
            // Ribbon
            // 
            Ribbon.CaptionFont = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            Ribbon.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top;
            Ribbon.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            Ribbon.HideMenuButtonToolTip = true;
            Ribbon.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Metro;
            Ribbon.Location = new System.Drawing.Point( 0, 36 );
            Ribbon.MenuButtonFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            Ribbon.MenuButtonText = "FILE";
            Ribbon.MenuButtonWidth = 56;
            Ribbon.MenuColor = System.Drawing.Color.FromArgb( 54, 54, 54 );
            Ribbon.Name = "Ribbon";
            Ribbon.Office2013ColorScheme = Syncfusion.Windows.Forms.Tools.Office2013ColorScheme.DarkGray;
            Ribbon.Office2016ColorScheme = Syncfusion.Windows.Forms.Tools.Office2016ColorScheme.Black;
            Ribbon.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Black;
            // 
            // 
            // 
            Ribbon.OfficeMenu.Name = "OfficeMenu";
            Ribbon.OfficeMenu.ShowItemToolTips = true;
            Ribbon.OfficeMenu.Size = new System.Drawing.Size( 12, 65 );
            Ribbon.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Ribbon.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            Ribbon.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2010;
            Ribbon.ShowQuickItemsDropDownButton = false;
            Ribbon.ShowRibbonDisplayOptionButton = false;
            Ribbon.Size = new System.Drawing.Size( 1338, 128 );
            Ribbon.Spreadsheet = Spreadsheet;
            Ribbon.SystemText.QuickAccessDialogDropDownName = "Start menu";
            Ribbon.SystemText.RenameDisplayLabelText = "&Display Name:";
            Ribbon.TabIndex = 0;
            Ribbon.Text = "spreadsheetRibbon1";
            Ribbon.ThemeName = "Default";
            Ribbon.ThemeStyle.MoreCommandsStyle.PropertyGridViewBorderColor = System.Drawing.Color.FromArgb( 171, 171, 171 );
            Ribbon.TitleColor = System.Drawing.Color.White;
            Ribbon.TitleFont = new System.Drawing.Font( "Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            // 
            // Spreadsheet
            // 
            Spreadsheet.AllowCellContextMenu = true;
            Spreadsheet.AllowExtendRowColumnCount = true;
            Spreadsheet.AllowFiltering = false;
            Spreadsheet.AllowFormulaRangeSelection = true;
            Spreadsheet.AllowTabItemContextMenu = true;
            Spreadsheet.AllowZooming = true;
            Spreadsheet.BaseThemeName = "";
            Spreadsheet.CanOverrideStyle = true;
            spreadsheetCopyPaste1.AllowPasteOptionPopup = true;
            spreadsheetCopyPaste1.DefaultPasteOption = Syncfusion.Windows.Forms.Spreadsheet.PasteOptions.Paste;
            Spreadsheet.CopyPaste = spreadsheetCopyPaste1;
            Spreadsheet.DefaultColumnCount = 50;
            Spreadsheet.DefaultRowCount = 100;
            Spreadsheet.DisplayAlerts = true;
            Spreadsheet.Dock = System.Windows.Forms.DockStyle.Fill;
            Spreadsheet.FileName = "Book1";
            Spreadsheet.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            Spreadsheet.ForeColor = System.Drawing.Color.Black;
            Spreadsheet.FormulaBarVisibility = true;
            formulaRangeSelectionController1.AllowMouseSelection = true;
            formulaRangeSelectionController1.AllowSelectionOnEditing = true;
            Spreadsheet.FormulaRangeSelectionController = formulaRangeSelectionController1;
            Spreadsheet.IsCustomTabItemContextMenuEnabled = false;
            Spreadsheet.Location = new System.Drawing.Point( 0, 164 );
            Spreadsheet.Name = "Spreadsheet";
            Spreadsheet.Padding = new System.Windows.Forms.Padding( 1 );
            Spreadsheet.SelectedTabIndex = 0;
            Spreadsheet.SelectedTabItem = null;
            Spreadsheet.ShowBusyIndicator = true;
            Spreadsheet.Size = new System.Drawing.Size( 1338, 530 );
            Spreadsheet.TabIndex = 1;
            Spreadsheet.TabItemContextMenu = null;
            Spreadsheet.Text = "Spreadsheet";
            Spreadsheet.ThemeName = "Default";
            // 
            // ToolStrip
            // 
            ToolStrip.AddButton = null;
            ToolStrip.AddColumnButton = null;
            ToolStrip.AddTableButton = null;
            ToolStrip.BackColor = System.Drawing.Color.Transparent;
            ToolStrip.BindingSource = BindingSource;
            ToolStrip.BorderStyle = Syncfusion.Windows.Forms.Tools.ToolStripBorderStyle.StaticEdge;
            ToolStrip.CalculatorButton = null;
            ToolStrip.CanOverrideStyle = true;
            ToolStrip.CaptionAlignment = Syncfusion.Windows.Forms.Tools.CaptionAlignment.Near;
            ToolStrip.CaptionFont = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            ToolStrip.CaptionStyle = Syncfusion.Windows.Forms.Tools.CaptionStyle.Top;
            ToolStrip.CaptionTextStyle = Syncfusion.Windows.Forms.Tools.CaptionTextStyle.Plain;
            ToolStrip.ChartButton = null;
            ToolStrip.DataFilter = null;
            ToolStrip.DeleteButton = null;
            ToolStrip.DeleteColumnButton = null;
            ToolStrip.DeleteRecordButton = null;
            ToolStrip.DeleteTableButton = null;
            ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            ToolStrip.DropDown = null;
            ToolStrip.EditButton = null;
            ToolStrip.EditColumnButton = null;
            ToolStrip.EditRecordButton = null;
            ToolStrip.EditSqlButton = null;
            ToolStrip.ExcelButton = null;
            ToolStrip.FilterDataButton = null;
            ToolStrip.FirstButton = null;
            ToolStrip.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            ToolStrip.ForeColor = System.Drawing.Color.MidnightBlue;
            ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            ToolStrip.HomeButton = CloseButton;
            ToolStrip.Image = null;
            ToolStrip.ImageDirectory = null;
            ToolStrip.ImageSize = new System.Drawing.Size( 16, 16 );
            ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] { StripSeparator, StatusLabel, Separator2, ToolStripTextBox, Separator3, Label3, FunctionLabel, Separator5, BrowseButton, Separator7, SaveButton, FilterSpacer, FilterLabel, DataSourceSeparator, LookupButton, FilterSeparator, FiltersButton, SqlSeparator, BackButtonSeparator, CloseButton, Separator10, MenuButton } );
            ToolStrip.LastButton = null;
            ToolStrip.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office12;
            ToolStrip.Location = new System.Drawing.Point( 1, 1 );
            ToolStrip.Margin = new System.Windows.Forms.Padding( 1, 1, 1, 3 );
            ToolStrip.Name = "ToolStrip";
            ToolStrip.NextButton = null;
            ToolStrip.Office12Mode = false;
            ToolStrip.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Black;
            ToolStrip.Padding = new System.Windows.Forms.Padding( 1 );
            ToolStrip.PreviousButton = null;
            ToolStrip.RefreshButton = null;
            ToolStrip.SaveButton = null;
            ToolStrip.Separators = null;
            ToolStrip.ShowCaption = true;
            ToolStrip.ShowLauncher = true;
            ToolStrip.Size = new System.Drawing.Size( 1336, 41 );
            ToolStrip.Stretch = true;
            ToolStrip.TabIndex = 2;
            ToolStrip.TextBox = null;
            ToolStrip.ThemeName = "Office2016DarkGray";
            ToolStrip.ThemeStyle.ArrowColor = System.Drawing.Color.SteelBlue;
            ToolStrip.ThemeStyle.BackColor = System.Drawing.Color.Transparent;
            ToolStrip.ThemeStyle.BottomToolStripBackColor = System.Drawing.Color.Transparent;
            ToolStrip.ThemeStyle.CaptionBackColor = System.Drawing.Color.FromArgb( 28, 28, 28 );
            ToolStrip.ThemeStyle.CaptionForeColor = System.Drawing.Color.Black;
            ToolStrip.ThemeStyle.ComboBoxStyle.BorderColor = System.Drawing.Color.FromArgb( 65, 65, 65 );
            ToolStrip.ThemeStyle.ComboBoxStyle.HoverBorderColor = System.Drawing.Color.SteelBlue;
            ToolStrip.ThemeStyle.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb( 40, 40, 40 );
            ToolStrip.ThemeStyle.HoverItemBackColor = System.Drawing.Color.SteelBlue;
            ToolStrip.ThemeStyle.HoverItemForeColor = System.Drawing.Color.White;
            ToolStrip.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Office2016DarkGray;
            // 
            // CloseButton
            // 
            CloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            CloseButton.AutoToolTip = false;
            CloseButton.BackColor = System.Drawing.Color.Transparent;
            CloseButton.BindingSource = BindingSource;
            CloseButton.DataFilter = null;
            CloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            CloseButton.Field = Field.AccountCode;
            CloseButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            CloseButton.ForeColor = System.Drawing.Color.LightGray;
            CloseButton.HoverText = "Main Menu";
            CloseButton.Image = Resources.Images.WebCloseButton;
            CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            CloseButton.Margin = new System.Windows.Forms.Padding( 1 );
            CloseButton.Name = "CloseButton";
            CloseButton.Padding = new System.Windows.Forms.Padding( 1 );
            CloseButton.Size = new System.Drawing.Size( 23, 23 );
            CloseButton.Text = "toolStripButton10";
            CloseButton.ToolTip = ToolTip;
            CloseButton.ToolType = ToolType.MenuButton;
            // 
            // ToolTip
            // 
            ToolTip.AutoPopDelay = 5000;
            ToolTip.BackColor = System.Drawing.Color.FromArgb( 5, 5, 5 );
            ToolTip.BindingSource = null;
            ToolTip.BorderColor = System.Drawing.SystemColors.Highlight;
            ToolTip.ForeColor = System.Drawing.Color.White;
            ToolTip.InitialDelay = 500;
            ToolTip.IsDerivedStyle = true;
            ToolTip.Name = null;
            ToolTip.OwnerDraw = true;
            ToolTip.ReshowDelay = 100;
            ToolTip.Style = MetroSet_UI.Enums.Style.Custom;
            ToolTip.StyleManager = null;
            ToolTip.ThemeAuthor = "Terry D. Eppler";
            ToolTip.ThemeName = "Budget Execution";
            ToolTip.TipIcon = System.Windows.Forms.ToolTipIcon.Info;
            ToolTip.TipText = null;
            ToolTip.TipTitle = null;
            // 
            // Separator1
            // 
            Separator1.ForeColor = System.Drawing.Color.Black;
            Separator1.Margin = new System.Windows.Forms.Padding( 1 );
            Separator1.Name = "Separator1";
            Separator1.Padding = new System.Windows.Forms.Padding( 1 );
            Separator1.Size = new System.Drawing.Size( 6, 23 );
            // 
            // StripSeparator
            // 
            StripSeparator.ForeColor = System.Drawing.Color.Black;
            StripSeparator.Margin = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            StripSeparator.Name = "StripSeparator";
            StripSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            StripSeparator.Size = new System.Drawing.Size( 6, 23 );
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = System.Drawing.Color.Transparent;
            StatusLabel.Font = new System.Drawing.Font( "Roboto", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            StatusLabel.ForeColor = System.Drawing.Color.Black;
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size( 77, 22 );
            StatusLabel.Text = "toolStripLabelExt1";
            StatusLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Separator2
            // 
            Separator2.ForeColor = System.Drawing.Color.Black;
            Separator2.Margin = new System.Windows.Forms.Padding( 1 );
            Separator2.Name = "Separator2";
            Separator2.Padding = new System.Windows.Forms.Padding( 1 );
            Separator2.Size = new System.Drawing.Size( 6, 23 );
            // 
            // ToolStripTextBox
            // 
            ToolStripTextBox.BackColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            ToolStripTextBox.BindingSource = BindingSource;
            ToolStripTextBox.Field = Field.AccountCode;
            ToolStripTextBox.Font = new System.Drawing.Font( "Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            ToolStripTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            ToolStripTextBox.HoverText = "";
            ToolStripTextBox.Margin = new System.Windows.Forms.Padding( 1 );
            ToolStripTextBox.Name = "ToolStripTextBox";
            ToolStripTextBox.Padding = new System.Windows.Forms.Padding( 1 );
            ToolStripTextBox.Size = new System.Drawing.Size( 180, 23 );
            ToolStripTextBox.Tag = "";
            ToolStripTextBox.ToolTip = ToolTip;
            // 
            // Separator3
            // 
            Separator3.ForeColor = System.Drawing.Color.Black;
            Separator3.Margin = new System.Windows.Forms.Padding( 1 );
            Separator3.Name = "Separator3";
            Separator3.Padding = new System.Windows.Forms.Padding( 1 );
            Separator3.Size = new System.Drawing.Size( 6, 23 );
            // 
            // Label3
            // 
            Label3.BackColor = System.Drawing.Color.Transparent;
            Label3.ForeColor = System.Drawing.Color.Transparent;
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size( 131, 22 );
            Label3.Text = "this is to provide space";
            // 
            // FunctionLabel
            // 
            FunctionLabel.BackColor = System.Drawing.Color.FromArgb( 45, 45, 45 );
            FunctionLabel.BindingSource = null;
            FunctionLabel.DataFilter = null;
            FunctionLabel.Field = Field.AccountCode;
            FunctionLabel.Font = new System.Drawing.Font( "Roboto", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            FunctionLabel.ForeColor = System.Drawing.Color.Black;
            FunctionLabel.HoverText = null;
            FunctionLabel.Margin = new System.Windows.Forms.Padding( 1 );
            FunctionLabel.Name = "FunctionLabel";
            FunctionLabel.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            FunctionLabel.Size = new System.Drawing.Size( 79, 23 );
            FunctionLabel.Tag = "";
            FunctionLabel.Text = "    Functions:       ";
            FunctionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            FunctionLabel.ToolTip = null;
            // 
            // Separator5
            // 
            Separator5.ForeColor = System.Drawing.Color.Black;
            Separator5.Margin = new System.Windows.Forms.Padding( 1 );
            Separator5.Name = "Separator5";
            Separator5.Padding = new System.Windows.Forms.Padding( 1 );
            Separator5.Size = new System.Drawing.Size( 6, 23 );
            // 
            // BrowseButton
            // 
            BrowseButton.AutoToolTip = false;
            BrowseButton.BackColor = System.Drawing.Color.Transparent;
            BrowseButton.BindingSource = BindingSource;
            BrowseButton.DataFilter = null;
            BrowseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            BrowseButton.Field = Field.AccountCode;
            BrowseButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            BrowseButton.ForeColor = System.Drawing.Color.LightGray;
            BrowseButton.HoverText = "Upload Local File";
            BrowseButton.Image = Resources.Images.BrowseButton;
            BrowseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            BrowseButton.Margin = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Padding = new System.Windows.Forms.Padding( 1 );
            BrowseButton.Size = new System.Drawing.Size( 23, 23 );
            BrowseButton.Text = "toolStripButton2";
            BrowseButton.ToolTip = ToolTip;
            BrowseButton.ToolType = ToolType.BrowseButton;
            // 
            // Separator7
            // 
            Separator7.ForeColor = System.Drawing.Color.Black;
            Separator7.Margin = new System.Windows.Forms.Padding( 1 );
            Separator7.Name = "Separator7";
            Separator7.Padding = new System.Windows.Forms.Padding( 1 );
            Separator7.Size = new System.Drawing.Size( 6, 23 );
            // 
            // SaveButton
            // 
            SaveButton.AutoToolTip = false;
            SaveButton.BackColor = System.Drawing.Color.Transparent;
            SaveButton.BindingSource = BindingSource;
            SaveButton.DataFilter = null;
            SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            SaveButton.Field = Field.AccountCode;
            SaveButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            SaveButton.ForeColor = System.Drawing.Color.LightGray;
            SaveButton.HoverText = null;
            SaveButton.Image = Resources.Images.SaveButton;
            SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            SaveButton.Margin = new System.Windows.Forms.Padding( 3 );
            SaveButton.Name = "SaveButton";
            SaveButton.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            SaveButton.Size = new System.Drawing.Size( 30, 19 );
            SaveButton.Text = "toolStripButton1";
            SaveButton.ToolTip = ToolTip;
            SaveButton.ToolType = ToolType.Ns;
            // 
            // FilterSpacer
            // 
            FilterSpacer.BackColor = System.Drawing.Color.FromArgb( 45, 45, 45 );
            FilterSpacer.BindingSource = null;
            FilterSpacer.DataFilter = null;
            FilterSpacer.Field = Field.AccountCode;
            FilterSpacer.Font = new System.Drawing.Font( "Roboto", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            FilterSpacer.ForeColor = System.Drawing.Color.Transparent;
            FilterSpacer.HoverText = null;
            FilterSpacer.Margin = new System.Windows.Forms.Padding( 1 );
            FilterSpacer.Name = "FilterSpacer";
            FilterSpacer.Padding = new System.Windows.Forms.Padding( 1 );
            FilterSpacer.Size = new System.Drawing.Size( 85, 23 );
            FilterSpacer.Tag = "";
            FilterSpacer.Text = "toolStripLabel1";
            FilterSpacer.ToolTip = null;
            // 
            // FilterLabel
            // 
            FilterLabel.BackColor = System.Drawing.Color.FromArgb( 45, 45, 45 );
            FilterLabel.BindingSource = null;
            FilterLabel.DataFilter = null;
            FilterLabel.Field = Field.AccountCode;
            FilterLabel.Font = new System.Drawing.Font( "Roboto", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            FilterLabel.ForeColor = System.Drawing.Color.Black;
            FilterLabel.HoverText = null;
            FilterLabel.Margin = new System.Windows.Forms.Padding( 1 );
            FilterLabel.Name = "FilterLabel";
            FilterLabel.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            FilterLabel.Size = new System.Drawing.Size( 52, 23 );
            FilterLabel.Tag = "";
            FilterLabel.Text = "     Filters:";
            FilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            FilterLabel.ToolTip = ToolTip;
            // 
            // DataSourceSeparator
            // 
            DataSourceSeparator.ForeColor = System.Drawing.Color.Black;
            DataSourceSeparator.Margin = new System.Windows.Forms.Padding( 1 );
            DataSourceSeparator.Name = "DataSourceSeparator";
            DataSourceSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            DataSourceSeparator.Size = new System.Drawing.Size( 6, 23 );
            // 
            // LookupButton
            // 
            LookupButton.AutoToolTip = false;
            LookupButton.BackColor = System.Drawing.Color.Transparent;
            LookupButton.BindingSource = BindingSource;
            LookupButton.DataFilter = null;
            LookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            LookupButton.Field = Field.AccountCode;
            LookupButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            LookupButton.ForeColor = System.Drawing.Color.LightGray;
            LookupButton.HoverText = "Select Data Table";
            LookupButton.Image = Resources.Images.DataSearchButton;
            LookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            LookupButton.Margin = new System.Windows.Forms.Padding( 3 );
            LookupButton.Name = "LookupButton";
            LookupButton.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            LookupButton.Size = new System.Drawing.Size( 30, 19 );
            LookupButton.Text = "toolStripButton1";
            LookupButton.ToolTip = ToolTip;
            LookupButton.ToolType = ToolType.LookupButton;
            // 
            // FilterSeparator
            // 
            FilterSeparator.ForeColor = System.Drawing.Color.Black;
            FilterSeparator.Margin = new System.Windows.Forms.Padding( 1 );
            FilterSeparator.Name = "FilterSeparator";
            FilterSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            FilterSeparator.Size = new System.Drawing.Size( 6, 23 );
            // 
            // FiltersButton
            // 
            FiltersButton.AutoToolTip = false;
            FiltersButton.BackColor = System.Drawing.Color.Transparent;
            FiltersButton.BindingSource = BindingSource;
            FiltersButton.DataFilter = null;
            FiltersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            FiltersButton.Field = Field.AccountCode;
            FiltersButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            FiltersButton.ForeColor = System.Drawing.Color.LightGray;
            FiltersButton.HoverText = "Filter Data Table";
            FiltersButton.Image = Resources.Images.FilterButton;
            FiltersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            FiltersButton.Margin = new System.Windows.Forms.Padding( 3 );
            FiltersButton.Name = "FiltersButton";
            FiltersButton.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            FiltersButton.Size = new System.Drawing.Size( 30, 19 );
            FiltersButton.Text = "toolStripButton1";
            FiltersButton.ToolTip = ToolTip;
            FiltersButton.ToolType = ToolType.FilterButton;
            // 
            // SqlSeparator
            // 
            SqlSeparator.ForeColor = System.Drawing.Color.Black;
            SqlSeparator.Margin = new System.Windows.Forms.Padding( 1 );
            SqlSeparator.Name = "SqlSeparator";
            SqlSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            SqlSeparator.Size = new System.Drawing.Size( 6, 23 );
            // 
            // BackButtonSeparator
            // 
            BackButtonSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            BackButtonSeparator.ForeColor = System.Drawing.Color.Black;
            BackButtonSeparator.Margin = new System.Windows.Forms.Padding( 1 );
            BackButtonSeparator.Name = "BackButtonSeparator";
            BackButtonSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            BackButtonSeparator.Size = new System.Drawing.Size( 6, 23 );
            // 
            // Separator10
            // 
            Separator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            Separator10.ForeColor = System.Drawing.Color.Black;
            Separator10.Margin = new System.Windows.Forms.Padding( 1 );
            Separator10.Name = "Separator10";
            Separator10.Padding = new System.Windows.Forms.Padding( 1 );
            Separator10.Size = new System.Drawing.Size( 6, 23 );
            // 
            // MenuButton
            // 
            MenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            MenuButton.AutoToolTip = false;
            MenuButton.BackColor = System.Drawing.Color.Transparent;
            MenuButton.BindingSource = BindingSource;
            MenuButton.DataFilter = null;
            MenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            MenuButton.Field = Field.AccountCode;
            MenuButton.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            MenuButton.ForeColor = System.Drawing.Color.LightGray;
            MenuButton.HoverText = null;
            MenuButton.Image = Resources.Images.WebMenuButton;
            MenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            MenuButton.Margin = new System.Windows.Forms.Padding( 3 );
            MenuButton.Name = "MenuButton";
            MenuButton.Padding = new System.Windows.Forms.Padding( 5, 1, 5, 1 );
            MenuButton.Size = new System.Drawing.Size( 30, 19 );
            MenuButton.ToolTip = ToolTip;
            MenuButton.ToolType = ToolType.BackButton;
            // 
            // Label4
            // 
            Label4.BackColor = System.Drawing.Color.Transparent;
            Label4.ForeColor = System.Drawing.Color.Transparent;
            Label4.Name = "Label4";
            Label4.Size = new System.Drawing.Size( 170, 25 );
            Label4.Text = "this is a label to provide space";
            Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            Label6.BackColor = System.Drawing.Color.Transparent;
            Label6.ForeColor = System.Drawing.Color.Transparent;
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size( 123, 27 );
            Label6.Text = "this is a spacer this is a spacer to provide more space";
            // 
            // Separator9
            // 
            Separator9.ForeColor = System.Drawing.Color.Black;
            Separator9.Margin = new System.Windows.Forms.Padding( 1 );
            Separator9.Name = "Separator9";
            Separator9.Padding = new System.Windows.Forms.Padding( 1 );
            Separator9.Size = new System.Drawing.Size( 6, 28 );
            // 
            // Separator11
            // 
            Separator11.ForeColor = System.Drawing.Color.Black;
            Separator11.Margin = new System.Windows.Forms.Padding( 1 );
            Separator11.Name = "Separator11";
            Separator11.Padding = new System.Windows.Forms.Padding( 1 );
            Separator11.Size = new System.Drawing.Size( 6, 28 );
            // 
            // ContextMenu
            // 
            ContextMenu.AutoSize = false;
            ContextMenu.BackColor = System.Drawing.Color.FromArgb( 30, 30, 30 );
            ContextMenu.ForeColor = System.Drawing.Color.White;
            ContextMenu.IsDerivedStyle = false;
            ContextMenu.Name = "ContextMenu";
            ContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            ContextMenu.Size = new System.Drawing.Size( 156, 264 );
            ContextMenu.Style = MetroSet_UI.Enums.Style.Custom;
            ContextMenu.StyleManager = null;
            ContextMenu.ThemeAuthor = "Terry D. Eppler";
            ContextMenu.ThemeName = "Budget Execution";
            // 
            // HeaderPanel
            // 
            HeaderPanel.ColumnCount = 2;
            HeaderPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            HeaderPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 1277F ) );
            HeaderPanel.Controls.Add( Header, 1, 0 );
            HeaderPanel.Controls.Add( PictureBox, 0, 0 );
            HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            HeaderPanel.Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            HeaderPanel.Location = new System.Drawing.Point( 0, 0 );
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.RowCount = 1;
            HeaderPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            HeaderPanel.Size = new System.Drawing.Size( 1338, 36 );
            HeaderPanel.TabIndex = 3;
            // 
            // Header
            // 
            Header.BindingSource = null;
            Header.DataFilter = null;
            Header.Dock = System.Windows.Forms.DockStyle.Fill;
            Header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Header.Font = new System.Drawing.Font( "Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            Header.HoverText = null;
            Header.IsDerivedStyle = true;
            Header.Location = new System.Drawing.Point( 64, 3 );
            Header.Margin = new System.Windows.Forms.Padding( 3 );
            Header.Name = "Header";
            Header.Padding = new System.Windows.Forms.Padding( 1 );
            Header.Size = new System.Drawing.Size( 1271, 30 );
            Header.Style = MetroSet_UI.Enums.Style.Custom;
            Header.StyleManager = null;
            Header.TabIndex = 1;
            Header.Text = "Budget Execution";
            Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Header.ThemeAuthor = "Terry D. Eppler";
            Header.ThemeName = "Budget Execution";
            Header.ToolTip = ToolTip;
            // 
            // PictureBox
            // 
            PictureBox.Image = Resources.Images.App;
            PictureBox.Location = new System.Drawing.Point( 3, 3 );
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new System.Drawing.Size( 26, 18 );
            PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // LabelSeparator
            // 
            LabelSeparator.ForeColor = System.Drawing.Color.Black;
            LabelSeparator.Margin = new System.Windows.Forms.Padding( 1 );
            LabelSeparator.Name = "LabelSeparator";
            LabelSeparator.Padding = new System.Windows.Forms.Padding( 1 );
            LabelSeparator.Size = new System.Drawing.Size( 6, 28 );
            // 
            // ToolStripTable
            // 
            ToolStripTable.ColumnCount = 1;
            ToolStripTable.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            ToolStripTable.Controls.Add( ToolStrip, 0, 0 );
            ToolStripTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            ToolStripTable.Location = new System.Drawing.Point( 0, 694 );
            ToolStripTable.Name = "ToolStripTable";
            ToolStripTable.RowCount = 1;
            ToolStripTable.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            ToolStripTable.Size = new System.Drawing.Size( 1338, 45 );
            ToolStripTable.TabIndex = 4;
            // 
            // ExcelDataForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 14F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            BorderColor = System.Drawing.Color.FromArgb( 0, 120, 212 );
            BorderThickness = 2;
            CaptionBarColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            CaptionBarHeight = 5;
            CaptionButtonColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            CaptionButtonHoverColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            CaptionFont = new System.Drawing.Font( "Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point );
            CaptionForeColor = System.Drawing.Color.FromArgb( 0, 120, 212 );
            ClientSize = new System.Drawing.Size( 1338, 739 );
            Controls.Add( Spreadsheet );
            Controls.Add( ToolStripTable );
            Controls.Add( Ribbon );
            Controls.Add( HeaderPanel );
            Font = new System.Drawing.Font( "Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point );
            ForeColor = System.Drawing.Color.LightGray;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject( "$this.Icon" );
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size( 1350, 750 );
            MetroColor = System.Drawing.Color.FromArgb( 20, 20, 20 );
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 1350, 750 );
            Name = "ExcelDataForm";
            ShowIcon = false;
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ( (System.ComponentModel.ISupportInitialize)Ribbon ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize)BindingSource ).EndInit( );
            ToolStrip.ResumeLayout( false );
            ToolStrip.PerformLayout( );
            HeaderPanel.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)PictureBox ).EndInit( );
            ToolStripTable.ResumeLayout( false );
            ToolStripTable.PerformLayout( );
            ResumeLayout( false );
        }

        #endregion

        public Syncfusion.Windows.Forms.Spreadsheet.SpreadsheetRibbon Ribbon;
        public Syncfusion.Windows.Forms.Spreadsheet.Spreadsheet Spreadsheet;
        public System.Windows.Forms.BindingSource BindingSource;
        public ToolStripTextBox ToolStripTextBox;
        public ToolStripDropDown DropDown;
        public ToolStripButton AddButton;
        public ToolStripButton DeleteButton;
        public ToolStripButton EditButton;
        public ToolStripButton RefreshButton;
        public ToolStripButton ChartButton;
        public ToolStripButton CloseButton;
        public SmallTip ToolTip;
        public ToolStripButton RefreshDataButton;
        public ToolSeparator Separator6;
        public Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt StatusLabel;
        public Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt Label3;
        public Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt Label4;
        public Syncfusion.Windows.Forms.Spreadsheet.ToolStripLabelExt Label6;
        public ContextMenu ContextMenu;
        public ToolStripButton BrowseButton;
        public ToolStripButton DeleteDatabaseButton;
        public ToolSeparator Separator2;
        public ToolSeparator Separator3;
        public ToolSeparator Separator1;
        public ToolSeparator Separator4;
        public ToolSeparator Separator7;
        public ToolStripButton FiltersButton;
        public ToolSeparator FilterSeparator;
        public ToolSeparator Separator9;
        public ToolSeparator Separator10;
        public ToolStripButton TableButton;
        public ToolSeparator Separator5;
        public ToolSeparator Separator11;
        public System.Windows.Forms.TableLayoutPanel HeaderPanel;
        public System.Windows.Forms.PictureBox PictureBox;
        public Label Header;
        public ToolStripButton LookupButton;
        public ToolSeparator DataSourceSeparator;
        public ToolSeparator LabelSeparator;
        public ToolStripButton GroupButton;
        public ToolStripButton SqlButton;
        public ToolSeparator SqlSeparator;
        public ToolStripLabel FunctionLabel;
        public ToolStrip ToolStrip;
        public ToolStripLabel FilterSpacer;
        public ToolStripLabel FilterLabel;
        public ToolSeparator BackButtonSeparator;
        public ToolStripButton MenuButton;
        public ToolStripButton BackButton;
        public System.Windows.Forms.Timer Timer;
        public ToolStripButton SaveButton;
        public ToolSeparator StripSeparator;
        public System.Windows.Forms.TableLayoutPanel ToolStripTable;
    }
}