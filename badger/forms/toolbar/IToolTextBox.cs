// // <copyright file = "IToolTextBox.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

using System;
using System.Windows.Forms;

namespace BudgetExecution
{
    public interface IToolTextBox
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

        /// <summary> Called when [mouse over]. </summary>
        /// <param name = "sender" > The sender. </param>
        /// <param name = "e" >
        /// The
        /// <see cref = "EventArgs"/>
        /// instance containing the event data.
        /// </param>
        void OnMouseOver( object sender, EventArgs e );
    }
}
