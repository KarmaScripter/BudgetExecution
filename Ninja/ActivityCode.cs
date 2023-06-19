﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ActivityCode.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   ActivityCode.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.DataUnit" />
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    public class ActivityCode : DataUnit 
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        public override Source Source { get; set; }

        /// <summary>
        /// </summary>
        public override DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        public ActivityCode( )
        {
            Source = Source.ActivityCodes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ActivityCode( IQuery query )
            : this( )
        {
            Record = new DataBuilder( query )?.Record;
            ID = int.Parse( Record[ "ActivityCodesId" ].ToString( ) ?? "0" );
            Name = Record[ $"{Field.ActivityName}" ].ToString( );
            Code = Record[ $"{Field.ActivityCode}" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ActivityCode( IDataModel builder )
            : this( )
        {
            Record = builder?.Record;
            ID = int.Parse( Record?[ "ActivityCodesId" ].ToString( ) ?? "0" );
            Name = Record?[ "ActivityName" ].ToString( );
            Code = Record?[ "ActivityCode" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public ActivityCode( DataRow dataRow )
            : this( )
        {
            Record = dataRow;
            ID = int.Parse( Record[ "ActivityCodesId" ].ToString( ) ?? "0" );
            Name = dataRow[ "ActivityName" ].ToString( );
            Code = dataRow[ "ActivityCode" ].ToString( );
            Data = dataRow?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public ActivityCode( string code )
            : this( )
        {
            Record = new DataBuilder( Source, GetArgs( code ) )?.Record;
            ID = int.Parse( Record[ "ActivityCodesId" ].ToString( ) ?? "0" );
            Name = Record[ "ActivityName" ].ToString( );
            Code = Record[ "ActivityCode" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCode"/> class.
        /// </summary>
        /// <param name="activityCode">The activity code.</param>
        public ActivityCode( ActivityCode activityCode )
            : this( )
        {
            ID = activityCode.ID;
            Code = activityCode.Code;
            Name = activityCode.Name;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code ) )
            {
                try
                {
                    return new Dictionary<string, object> { [ "ActivityCode" ] = code };
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}