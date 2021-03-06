// <copyright file = "IAmount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    /// <summary> </summary>
    public interface IAmount
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the value. </summary>
        /// <returns> </returns>
        double GetFunding();

        /// <summary> Gets the name. </summary>
        /// <returns> </returns>
        string GetName();

        /// <summary> Gets the numeric. </summary>
        /// <returns> </returns>
        Numeric GetNumeric();

        /// <summary> Gets the amount. </summary>
        /// <returns> </returns>
        IAmount GetAmount();
    }
}