﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="Organization.cs" company="Terry D. Eppler">
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
//   Organization.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary> </summary>
    /// <seealso cref="DataUnit"/>
    /// <seealso cref="BudgetExecution.ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class Organization : DataUnit 
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Organization"/>
        /// class.
        /// </summary>
        public Organization( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Organization"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Organization( IQuery query )
        {
            Record = new DataBuilder( query )?.Record;
            ID = int.Parse( Record[ "OrganizationsId" ].ToString( ) ?? "0" );
            Name = Record[ "Name" ].ToString( );
            Code = Record[ "Code" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Organization"/>
        /// class.
        /// </summary>
        /// <param name="org"> The org. </param>
        public Organization( string org )
        {
            Record = new DataBuilder( Source, GetArgs( org ) )?.Record;
            ID = int.Parse( Record[ "OrganizationsId" ].ToString( ) ?? "0" );
            Name = Record[ "Name" ].ToString( );
            Code = Record[ "Code" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Organization"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Organization( IDataModel builder )
        {
            Record = builder.Record;
            ID = int.Parse( Record[ "OrganizationsId" ].ToString( ) ?? "0" );
            Name = Record[ "Name" ].ToString( );
            Code = Record[ "Code" ].ToString( );
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Organization"/> class.
        /// </summary>
        /// <param name="org">The org.</param>
        public Organization( Organization org )
        {
            ID = org.ID;
            Code = org.Code;
            Name = org.Name;
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Organization"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public Organization( DataRow dataRow )
        {
            Record = dataRow;
            ID = int.Parse( Record[ "OrganizationsId" ].ToString( ) ?? "0" );
            Name = Record[ "Name" ].ToString( );
            Code = Record[ "Code" ].ToString( );
            Data = dataRow?.ToDictionary( );
        }

        /// <summary> Converts to dictionary. </summary>
        /// <returns> </returns>
        public IDictionary<string, object> ToDictionary( )
        {
            try
            {
                return Data?.Any( ) == true
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IDictionary<string, object> );
            }
        }
        
        /// <summary> Sets the arguments. </summary>
        /// <param name="code"> The code. </param>
        /// <returns> </returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code ) )
            {
                try
                {
                    return new Dictionary<string, object> { [ $"{Field.Code}" ] = code };
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