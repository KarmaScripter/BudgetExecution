// <copyright file = "BindingBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public class BindingBase : BindingSource
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <value>
        /// The data set.
        /// </value>
        private protected DataSet DataSet { get; set; }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        private protected DataTable DataTable { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected Source Source { get; set; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets the index of the current.
        /// </summary>
        /// <value>
        /// The index of the current.
        /// </value>
        private protected int Index { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        private protected Field Field { get; set; }

        /// <summary>
        /// Gets or sets the data filter.
        /// </summary>
        /// <value>
        /// The data filter.
        /// </value>
        public IDictionary<string, object> DataFilter { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <returns>
        /// </returns>
        public Field GetField()
        {
            try
            {
                return Verify.Field( Field )
                    ? Field
                    : default( Field );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Field );
            }
        }

        /// <summary>
        /// Gets the data filter.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetDataFilter()
        {
            try
            {
                return DataFilter?.Any() == true
                    ? DataFilter
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataTable GetDataTable()
        {
            try
            {
                return DataTable?.Rows?.Count > 0 && DataTable?.Columns?.Count > 0
                    ? DataTable
                    : default( DataTable );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            try
            {
                var data = DataTable?.AsEnumerable();

                return data?.Any() == true
                    ? data
                    : default( EnumerableRowCollection<DataRow> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataRow> );
            }
        }

        /// <summary>
        /// Gets the current row.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataRow GetCurrent()
        {
            try
            {
                return Record?.ItemArray?.Length > 0
                    ? Record
                    : default( DataRow );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataRow );
            }
        }

        /// <summary>
        /// Gets the index of the current.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetIndex()
        {
            try
            {
                return Index > 0
                    ? Index
                    : -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Fails the specified ex.
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
