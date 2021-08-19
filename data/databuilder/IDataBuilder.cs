﻿// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    public interface IDataBuilder
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ****************************************************************************
        IBuilder GetBuilder();
    }
}