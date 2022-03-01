﻿// <copyright file = "ToolBarBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using Syncfusion.Windows.Forms.Tools;
    
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class ToolStripBase : ToolStripEx
    {
        /// <summary>
        /// Gets or sets the binding source.
        /// </summary>
        /// <value>
        /// The binding source.
        /// </value>
        public virtual BindingSource BindingSource { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public virtual Field Field { get; set; }

        /// <summary>
        /// Gets or sets the numeric.
        /// </summary>
        /// <value>
        /// The numeric.
        /// </value>
        public virtual Numeric Numeric { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public virtual IDictionary<string, object> DataFilter { get; set; }

        /// <summary>
        /// Gets or sets the setting.
        /// </summary>
        /// <value>
        /// The setting.
        /// </value>
        public virtual NameValueCollection Setting { get; set; } = ConfigurationManager.AppSettings;
        
        /// <summary>
        /// The image path
        /// </summary>
        public virtual string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the tool strip ComboBox.
        /// </summary>
        /// <value>
        /// The tool strip ComboBox.
        /// </value>
        public BudgetToolStripComboBox ToolStripComboBox { get; set; } = ToolFactory.CreateComboBox();

        /// <summary>
        /// Gets or sets the tool strip text box.
        /// </summary>
        /// <value>
        /// The tool strip text box.
        /// </value>
        public BudgetToolStripTextBox ToolStripTextBox { get; set; } = ToolFactory.CreateTextBox();

        /// <summary>
        /// Gets or sets the first button.
        /// </summary>
        /// <value>
        /// The first button.
        /// </value>
        public BudgetToolStripButton FirstButton { get; set; } = ToolFactory.CreateFirstButton();

        /// <summary>
        /// Gets or sets the previous button.
        /// </summary>
        /// <value>
        /// The previous button.
        /// </value>
        public BudgetToolStripButton PreviousButton { get; set; } = ToolFactory.CreatePreviousButton();

        /// <summary>
        /// Gets or sets the next button.
        /// </summary>
        /// <value>
        /// The next button.
        /// </value>
        public BudgetToolStripButton NextButton { get; set; } = ToolFactory.CreateNextButton();

        /// <summary>
        /// Gets or sets the last button.
        /// </summary>
        /// <value>
        /// The last button.
        /// </value>
        public BudgetToolStripButton LastButton { get; set; } = ToolFactory.CreateLastButton();

        /// <summary>
        /// Gets or sets the edit button.
        /// </summary>
        /// <value>
        /// The edit button.
        /// </value>
        public BudgetToolStripButton EditButton { get; set; } = ToolFactory.CreateEditButton();

        /// <summary>
        /// Gets or sets the add button.
        /// </summary>
        /// <value>
        /// The add button.
        /// </value>
        public BudgetToolStripButton AddButton { get; set; } = ToolFactory.CreateAddButton();

        /// <summary>
        /// Gets or sets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public BudgetToolStripButton DeleteButton { get; set; } = ToolFactory.CreateDeleteButton();

        /// <summary>
        /// Gets or sets the refresh button.
        /// </summary>
        /// <value>
        /// The refresh button.
        /// </value>
        public BudgetToolStripButton RefreshButton { get; set; } = ToolFactory.CreateRefreshButton();

        /// <summary>
        /// Gets or sets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public BudgetToolStripButton SaveButton { get; set; } = ToolFactory.CreateSaveButton();

        /// <summary>
        /// Gets or sets the print button.
        /// </summary>
        /// <value>
        /// The print button.
        /// </value>
        public BudgetToolStripButton PrintButton { get; set; } = ToolFactory.CreatePrintButton();

        /// <summary>
        /// Gets or sets the excel button.
        /// </summary>
        /// <value>
        /// The excel button.
        /// </value>
        public BudgetToolStripButton ExcelButton { get; set; } = ToolFactory.CreateExcelButton();

        /// <summary>
        /// Gets or sets the calculator button.
        /// </summary>
        /// <value>
        /// The calculator button.
        /// </value>
        public BudgetToolStripButton CalculatorButton { get; set; } = ToolFactory.CreateCalculatorButton();

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <param name="bindingSource">The bindingSource.</param>
        public virtual void SetDataSource<T1>( T1 bindingSource ) 
            where T1 : IBindingList
        {
            try
            {
                if( bindingSource is BindingSource _binder
                    && _binder?.DataSource != null )
                {
                    try
                    {
                        BindingSource.DataSource = _binder.DataSource;
                    }
                    catch( Exception ex )
                    {
                        Fail( ex );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="bindingList">The bindingSource.</param>
        /// <param name="dict">The dictionary.</param>
        public virtual void SetDataSource<T1, T2>( T1 bindingList, T2 dict )
            where T1 : IBindingList 
            where T2 : IDictionary<string, object>
        {
            try
            {
                if( Verify.IsBindable( bindingList )
                    && Verify.IsMap( dict ) )
                {
                    try
                    {
                        var _list = bindingList as BindingSource;
                        var _filter = string.Empty;

                        foreach( var _kvp in dict )
                        {
                            if( Verify.IsInput( _kvp.Key )
                                && Verify.IsRef( _kvp.Value ) )
                            {
                                _filter += $"{_kvp.Key} = {_kvp.Value} AND";
                            }
                        }

                        if( _filter?.Length > 0
                            && _list?.DataSource != null )
                        {
                            BindingSource.DataSource = _list?.DataSource;
                            BindingSource.Filter = _filter?.TrimEnd( " AND".ToCharArray() );
                        }
                    }
                    catch( Exception ex )
                    {
                        Fail( ex );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void SetDataSource<T1>( IEnumerable<T1> data ) 
            where T1 : IEnumerable<T1>
        {
            if( Verify.IsSequence( data ) )
            {
                try
                {
                    BindingSource.DataSource = data?.ToList();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="dict">The dictionary.</param>
        public virtual void SetDataSource<T1>( IEnumerable<T1> data, IDictionary<string, object> dict )
            where T1 : IEnumerable<T1>
        {
            if( Verify.IsSequence( data ) )
            {
                try
                {
                    var _filter = string.Empty;

                    foreach( var _kvp in dict )
                    {
                        if( Verify.IsInput( _kvp.Key )
                            && _kvp.Value != null )
                        {
                            _filter += $"{_kvp.Key} = {_kvp.Value} AND";
                        }
                    }

                    BindingSource.DataSource = data?.ToList();
                    BindingSource.Filter = _filter.TrimEnd( " AND".ToCharArray() );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="T3">The type of the 3.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The dictionary.</param>
        public virtual void SetDataSource<T1, T2, T3>( IEnumerable<T1> data, T2 field, T3 filter )
            where T1 : IEnumerable<T1> 
            where T2 : struct
        {
            if( Verify.IsSequence( data )
                && Validate.IsField( field ) )
            {
                try
                {
                    if( Verify.IsInput( filter?.ToString() ) )
                    {
                        BindingSource.DataSource = data.ToList();
                        BindingSource.DataMember = field.ToString();
                        BindingSource.Filter = $"{field} = {filter}";
                    }
                    else
                    {
                        BindingSource.DataSource = data.ToList();
                        BindingSource.DataMember = field.ToString();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        public virtual void SetDataSource<T1>( IEnumerable<T1> data, object field = null ) 
            where T1 : IEnumerable<T1>
        {
            if( Verify.IsInput( data ) )
            {
                try
                {
                    if( Verify.IsInput( field?.ToString() ) )
                    {
                        BindingSource.DataSource = data.ToList();
                        BindingSource.DataMember = field?.ToString();
                    }
                    else
                    {
                        BindingSource.DataSource = data.ToList();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the bindings.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param>The numeric.</param>
        /// <param name = "dict" > </param>
        public virtual void SetDataSource<T1, T2>( IEnumerable<T1> data, T2 dict )
            where T1 : IEnumerable<T1> 
            where T2 : IDictionary<string, object>
        {
            if( Verify.IsSequence( data )
                && Verify.IsMap( dict ) )
            {
                try
                {
                    var _filter = string.Empty;

                    foreach( var _kvp in dict )
                    {
                        if( Verify.IsInput( _kvp.Key )
                            && _kvp.Value != null )
                        {
                            _filter += $"{_kvp.Key} = {_kvp.Value} AND";
                        }
                    }

                    BindingSource.DataSource = data?.ToList();
                    BindingSource.Filter = _filter?.TrimEnd( " AND".ToCharArray() );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the binding source.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The filter.</param>
        public virtual void SetDataSource<T1, T2>( IEnumerable<T1> data, T2 field, object filter = null )
            where T1 : IEnumerable<T1> 
            where T2 : struct
        {
            if( Verify.IsSequence( data )
                && Validate.IsField( field ) )
            {
                try
                {
                    if( Verify.IsInput( filter?.ToString() ) )
                    {
                        BindingSource.DataSource = data.ToList();
                        BindingSource.DataMember = field.ToString();
                        BindingSource.Filter = $"{field} = {filter}";
                    }
                    else
                    {
                        BindingSource.DataSource = data.ToList();
                        BindingSource.DataMember = field.ToString();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
        
        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public virtual void SetField( Field field )
        {
            try
            {
                Field = BudgetForm.GetField( field );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Get Error Dialog.
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