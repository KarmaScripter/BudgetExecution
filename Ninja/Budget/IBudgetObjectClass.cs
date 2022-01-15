﻿// <copyright file = "IBudgetObjectClass.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    public interface IBudgetObjectClass : IProgram
    {
        /// <summary>
        /// Gets the budget object class.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetObjectClass GetBudgetObjectClass();

        /// <summary>
        /// Gets the budget object class category.
        /// </summary>
        /// <returns>
        /// </returns>
        BOC GetBudgetObjectClassCategory();
    }
}