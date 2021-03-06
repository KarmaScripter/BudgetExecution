// <copyright file = "ISupplemental.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    public interface ISupplemental
    {
        // ****************************************************************************************************************************
        // ************************************************  METHODS   ****************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Gets the supplemental identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the type of the supplemental.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetSupplementalType();

        /// <summary>
        /// Gets the name of the supplemental.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetName();

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFundCode();

        /// <summary>
        /// Gets the budget object class code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetBocCode();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        string ToString();
    }
}
