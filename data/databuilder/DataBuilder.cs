// <copyright file = "DataBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class DataBuilder : Builder
    {
        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary> Initializes a new instance of the class. </summary>
        public DataBuilder()
        {
        }

        /// <summary> Initializes a new instance of the class. </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "provider" > The provider. </param>
        public DataBuilder( Source source, Provider provider = Provider.SQLite )
            : base( source, provider )
        {
        }

        /// <summary> Initializes a new instance of the class. </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "provider" > The provider. </param>
        /// <param name = "args" > The arguments. </param>
        public DataBuilder( Source source, Provider provider, IDictionary<string, object> args )
            : base( source, provider, args )
        {
        }

        /// <summary> Initializes a new instance of the class. </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "dict" > The dictionary. </param>
        public DataBuilder( Source source, IDictionary<string, object> dict )
            : base( source, dict )
        {
        }

        /// <summary> Initializes a new instance of the class. </summary>
        /// <param name = "query" > The query. </param>
        public DataBuilder( IQuery query )
            : base( query )
        {
        }

        /// <summary> Initializes a new instance of the class. </summary>
        /// <param name = "data" > The data. </param>
        public DataBuilder( DataRow data )
        {
            Record = data;
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Sets the date. </summary>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        public DateTime GetDate( Field field )
        {
            if( Verify.Row( Record )
                && Verify.Field( field ) )
            {
                try
                {
                    var columns = Record.Table?.GetColumnNames();

                    if( columns?.Contains( $"{field}" ) == true )
                    {
                        var date = Record.GetDate( field );

                        return Verify.DateTime( date )
                            ? date
                            : default( DateTime );
                    }
                    else
                    {
                        return default( DateTime );
                    }
                }
                catch( Exception ex )
                {
                    DataBuilder.Fail( ex );
                    return default( DateTime );
                }
            }
            else
            {
                return default( DateTime );
            }
        }

        /// <summary> Gets the data. </summary>
        /// <param name = "field" > The field. </param>
        /// <param name = "filter" > </param>
        /// <returns> </returns>
        public IEnumerable<DataRow> FilterData( Field field, string filter )
        {
            if( Verify.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = GetData()
                        ?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return query?.Any() == true
                        ? query.ToArray()
                        : default( DataRow[ ] );
                }
                catch( Exception ex )
                {
                    DataBuilder.Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }
    }
}