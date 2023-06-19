﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 05-16-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="OutlookConfig.cs" company="Terry D. Eppler">
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
//   OutlookConfig.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Mail;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class OutlookConfig
    {
        /// <summary> Gets or sets the t os. </summary>
        /// <value> The t os. </value>
        public string[ ] Os { get; set; }

        /// <summary> Gets or sets the c cs. </summary>
        /// <value> The c cs. </value>
        public string[ ] CCs { get; set; }

        /// <summary> Gets or sets from. </summary>
        /// <value> From. </value>
        public string From { get; set; }

        /// <summary> Gets or sets from display name. </summary>
        /// <value> From display name. </value>
        public string DisplayName { get; set; }

        /// <summary> Gets or sets the subject. </summary>
        /// <value> The subject. </value>
        public string Subject { get; set; }

        /// <summary> Gets or sets the priority. </summary>
        /// <value> The priority. </value>
        public MailPriority Priority { get; set; }

        /// <summary> Gets or sets the name of the client credential user. </summary>
        /// <value> The name of the client credential user. </value>
        public string UserName { get; set; }

        /// <summary> Gets or sets the client credential password. </summary>
        /// <value> The client credential password. </value>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OutlookConfig"/>
        /// class.
        /// </summary>
        public OutlookConfig( )
        {
        }
    }
}