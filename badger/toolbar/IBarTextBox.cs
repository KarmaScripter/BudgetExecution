// <copyright file = "IBarTextBox.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

using System.Windows.Forms;

namespace BudgetExecution
{
    public interface IBarTextBox
    {
        /// <summary> Sets the hover information. </summary>
        /// <param name = "text" > The text. </param>
        void SetHoverText( string text );

        /// <summary> Sets the field. </summary>
        /// <param name = "field" > The field. </param>
        void SetField( Field field );

        /// <summary> Sets the tag. </summary>
        /// <param name = "tag" > The tag. </param>
        void SetTag( object tag );

        /// <summary>
        /// Sets the hover text.
        /// </summary>
        /// <param name="item">The item.</param>
        void SetHoverText( ToolStripItem item );

        void Clear();
    }
}
