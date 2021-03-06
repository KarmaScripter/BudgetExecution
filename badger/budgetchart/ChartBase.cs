// <copyright file = "ChartBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Syncfusion.Drawing;
    using Syncfusion.Windows.Forms.Chart;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.Chart.ChartControl" />
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class ChartBase : ChartControl
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartBase"/> class.
        /// </summary>
        public ChartBase()
        {
        }

        /// <summary>
        /// The style
        /// </summary>
        private protected static readonly IChartConfig Style = new ChartConfig();

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected Source Source { get; set; }

        /// <summary>
        /// Gets or sets the data model.
        /// </summary>
        /// <value>
        /// The data model.
        /// </value>
        private protected ISourceModel SourceModel { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private protected ISeriesConfig Configuration { get; set; }

        /// <summary>
        /// Gets or sets the metric.
        /// </summary>
        /// <value>
        /// The metric.
        /// </value>
        private protected IDataMetric DataMetric { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected ISeriesModel SeriesModel { get; set; }

        /// <summary>
        /// Gets the data series.
        /// </summary>
        /// <value>
        /// The data series.
        /// </value>
        private protected IDataSeries DataSeries { get; set; }

        /// <summary>
        /// Gets the default title.
        /// </summary>
        /// <value>
        /// The title information.
        /// </value>
        private protected ITitleInfo TitleInfo { get; set; }

        /// <summary>
        /// Gets or sets the binding source.
        /// </summary>
        /// <value>
        /// The binding source.
        /// </value>
        public BindingSource BindingSource { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the legend configuration.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="size">The size.</param>
        /// <param name="backcolor">The backcolor.</param>
        public void SetLegend( Font font, Size size, Color backcolor )
        {
            if( font != null 
                && size != Size.Empty 
                && backcolor != Color.Empty )
            {
                try
                {
                    ShowLegend = true;
                    Legend.Font = font;
                    Legend.ItemsSize = size;
                    Legend.VisibleCheckBox = true;
                    Legend.BackInterior = new BrushInfo( backcolor );
                    Legend.ItemsAlignment = AlignConfig.GetStringAlignment( StringAlignment.Center );
                    Legend.ItemsTextAligment = VerticalAlignment.Center;
                    Legend.Orientation = ChartOrientation.Vertical;
                    Legend.FloatingAutoSize = true;
                    Legend.ShowSymbol = true;
                    Legend.ShowItemsShadow = true;
                    Legend.ShowBorder = false;
                    Legend.Visible = true;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the source model.
        /// </summary>
        /// <returns></returns>
        public ISourceModel GetSourceModel()
        {
            try
            {
                return SourceModel?.GetData()?.Any() == true
                    ? SourceModel
                    : default( ISourceModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ISourceModel );
            }
        }

        /// <summary>
        /// Gets the series configuration.
        /// </summary>
        /// <returns></returns>
        public ISeriesConfig GetSeriesConfiguration()
        {
            try
            {
                var type = Configuration?.GetSeriesType();

                return type != null && Enum.IsDefined( typeof( ChartType ), type )
                    ? Configuration
                    : default( ISeriesConfig );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ISeriesConfig );
            }
        }

        /// <summary>
        /// Gets the data metric.
        /// </summary>
        /// <returns></returns>
        public IDataMetric GetDataMetric()
        {
            try
            {
                return DataMetric?.GetData()?.Any() == true
                    ? DataMetric
                    : default( IDataMetric );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataMetric );
            }
        }

        /// <summary>
        /// Gets the chart data.
        /// </summary>
        /// <returns></returns>
        public ISeriesModel GetChartData()
        {
            try
            {
                return SeriesModel?.GetSeriesValues()?.Any() == true
                    ? SeriesModel
                    : default( ISeriesModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ISeriesModel );
            }
        }

        /// <summary>
        /// Gets the data series.
        /// </summary>
        /// <returns></returns>
        public IDataSeries GetDataSeries()
        {
            try
            {
                return DataSeries?.GetDataPoints()?.Any() == true
                    ? DataSeries
                    : default( IDataSeries );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataSeries );
            }
        }

        /// <summary>
        /// Gets the tile information.
        /// </summary>
        /// <returns></returns>
        public ITitleInfo GetTileInfo()
        {
            try
            {
                return Verify.Input( TitleInfo?.GetAxisText() )
                    ? TitleInfo
                    : default( ITitleInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITitleInfo );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
