// <copyright file = "IConnectionFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System;
    using System.Data.Common;

    /// <summary> </summary>
    public interface IConnectionFactory : IProvider
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the connection. </summary>
        /// <returns> </returns>
        DbConnection GetConnection();

        /// <summary> Gets the connection manager. </summary>
        /// <returns> </returns>
        IConnectionBuilder GetConnectionBuilder();
    }
}