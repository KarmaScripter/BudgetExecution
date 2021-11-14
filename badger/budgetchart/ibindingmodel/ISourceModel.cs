﻿// <copyright file = "ISourceModel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;

    public interface ISourceModel
    {
        /// <summary> Gets the source binding. </summary>
        /// <returns> </returns>
        IChartBinding GetSourceBinding();

        /// <summary> Gets the data. </summary>
        /// <returns> </returns>
        IDictionary<string, IEnumerable<double>> GetSeriesData();

        /// <summary> Gets the metric. </summary>
        /// <returns> </returns>
        IDataMetric GetMetric();

        /// <summary> Gets the series configurations. </summary>
        /// <returns> </returns>
        ISeriesConfig GetSeriesConfiguration();
    }
}