﻿// <copyright file = "ToolPanelBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    /// <summary> </summary>
    /// <seealso cref = "Syncfusion.Windows.Forms.Tools.ToolStripEx"/>
    public class ToolPanelBase : ToolPanelData
    {
        /// <summary>
        /// The image path
        /// </summary>
        public static readonly string ImagePath = Resource.ToolBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPanelBase"/> class.
        /// </summary>
        public ToolPanelBase()
        {
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void SetField( Field field )
        {
            try
            {
                Field = FormConfig.GetField( field );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the button.
        /// </summary>
        /// <param name = "imagename" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        public BarButton CreateButton( string imagename )
        {
            if( Verify.Input( imagename ) )
            {
                try
                {
                    var image = new BudgetImage( imagename, ImageSource.ToolBarImages,
                        ImageSizer.Small );

                    var button = new BarButton( image );
                    Items?.Add( button );

                    return Items?.Count > 0
                        ? button
                        : default( BarButton );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( BarButton );
                }
            }

            return default( BarButton );
        }

        /// <summary>
        /// Creates the label.
        /// </summary>
        /// <returns>
        /// </returns>
        public BarLabel CreateLabel()
        {
            try
            {
                var label = new BarLabel();
                Items?.Add( label );

                return label?.BindingSource != null && Items?.Count > 0
                    ? label
                    : default( BarLabel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BarLabel );
            }
        }

        /// <summary>
        /// Creates the ComboBox.
        /// </summary>
        /// <returns>
        /// </returns>
        public BarComboBox CreateComboBox()
        {
            try
            {
                var combobox = new BarComboBox();
                Items?.Add( combobox );

                return Items?.Count > 0
                    ? combobox
                    : default( BarComboBox );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BarComboBox );
            }
        }

        /// <summary>
        /// Creates the text box.
        /// </summary>
        /// <returns>
        /// </returns>
        public BarTextBox CreateTextBox()
        {
            try
            {
                var textbox = new BarTextBox();
                Items?.Add( textbox );

                return Items?.Count > 0
                    ? textbox
                    : default( BarTextBox );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BarTextBox );
            }
        }
    }
}