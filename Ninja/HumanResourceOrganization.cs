﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="HumanResourceOrganization.cs" company="Terry D. Eppler">
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
//   HumanResourceOrganization.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class HumanResourceOrganization : DataUnit
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HumanResourceOrganization"/>
        /// class.
        /// </summary>
        public HumanResourceOrganization( )
        {
            Source = Source.HumanResourceOrganizations;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public HumanResourceOrganization( IQuery query )
        {
            Record = new DataBuilder( query ).Record;
            Data = Record.ToDictionary( );
            ID = int.Parse( Record[ "HumanResourceOrganizationsId" ].ToString( ) ?? string.Empty );
            Code = Record[ "Code" ].ToString( );
            Name = Record[ "Name" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public HumanResourceOrganization( IDataModel builder )
        {
            Record = builder.Record;
            Data = Record.ToDictionary( );
            ID = int.Parse( Record[ "HumanResourceOrganizationsId" ].ToString( ) ?? string.Empty );
            Code = Record[ "Code" ].ToString( );
            Name = Record[ "Name" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="HumanResourceOrganization"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public HumanResourceOrganization( DataRow dataRow )
        {
            Record = dataRow;
            Data = dataRow.ToDictionary( );
            ID = int.Parse( dataRow[ "HumanResourceOrganizationsId" ].ToString( ) ?? string.Empty );
            Code = dataRow[ "Code" ].ToString( );
            Name = dataRow[ "Name" ].ToString( );
        }

        public HumanResourceOrganization( IDataUnit org )
        {
            ID = org.ID;
            Code = org.Code;
            Name = org.Name;
        }
    }
}