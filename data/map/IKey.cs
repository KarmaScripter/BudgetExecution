// <copyright file = "IKey.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ***************************************************************************************************************************
    // ****************************************************     METHODS   ********************************************************
    // ***************************************************************************************************************************

    /// <summary> </summary>
    public interface IKey
    {
        /// <summary> Gets the name. </summary>
        /// <returns> </returns>
        string GetName();

        /// <summary> Gets the value. </summary>
        /// <returns> </returns>
        int GetIndex();

        /// <summary> Gets the field. </summary>
        /// <returns> </returns>
        PrimaryKey GetPrimaryKey();
    }
}