// <copyright file = "IElement.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ***************************************************************************************************************************
    // ****************************************************     METHODS   ********************************************************
    // ***************************************************************************************************************************

    public interface IElement
    {
        /// <summary> Gets the name. </summary>
        /// <returns> </returns>
        string GetName();

        /// <summary> Gets the value. </summary>
        /// <returns> </returns>
        string GetValue();

        /// <summary> Gets the field. </summary>
        /// <returns> </returns>
        Field GetField();
    }
}