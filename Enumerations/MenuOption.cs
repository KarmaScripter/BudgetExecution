﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 2-3-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        2-3-2024
// ******************************************************************************************
// <copyright file="MenuOption.cs" company="Terry D. Eppler">
//    Budget Execution is a Federal Budget, Finance, and Accounting application
//    for analysts with the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//    Contact at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   MenuOption.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public enum MenuOption
    {
        /// <summary>
        /// The file
        /// </summary>
        BrowseFile = 1,

        /// <summary>
        /// The folder
        /// </summary>
        BrowseFolder = 2,

        /// <summary>
        /// The calculator
        /// </summary>
        BudgetCalculator = 3,

        /// <summary>
        /// The windows calculator
        /// </summary>
        WindowsCalculator = 4,

        /// <summary>
        /// The calendar
        /// </summary>
        BudgetCalendar = 5,

        /// <summary>
        /// The budget calendar
        /// </summary>
        WindowsCalendar = 6, 

        /// <summary>
        /// The control panel
        /// </summary>
        ControlPanel = 7,

        /// <summary>
        /// The task manager
        /// </summary>
        TaskManager = 8,

        /// <summary>
        /// The windows maps
        /// </summary>
        WindowsMaps = 9,

        /// <summary>
        /// The windows media player
        /// </summary>
        WindowsMediaPlayer = 10,

        /// <summary>
        /// The one drive
        /// </summary>
        OneDrive = 11,

        /// <summary>
        /// The windows clock
        /// </summary>
        WindowsClock = 12, 

        /// <summary>
        /// The guidance
        /// </summary>
        BudgetGuidance = 13,

        /// <summary>
        /// The save
        /// </summary>
        SaveChanges = 14,

        /// <summary>
        /// The exit
        /// </summary>
        ExitApplication = 15
    }
}