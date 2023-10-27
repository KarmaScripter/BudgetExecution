﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="IFolder.cs" company="Terry D. Eppler">
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
//   IFolder.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;
    using System.Threading;

    /// <summary> </summary>
    public interface IFolder
    {
        /// <summary> Creates the sub directory. </summary>
        /// <param name="dirName"> The folderName. </param>
        /// <returns> </returns>
        DirectoryInfo CreateSubDirectory( string dirName );

        /// <summary> Gets the Data. </summary>
        /// <returns> </returns>
        IDictionary<string, FileInfo> GetSubFileData( );

        /// <summary> Moves the specified fullName. </summary>
        /// <param name="destination"> The fullName. </param>
        void Move( string destination );

        /// <summary> Sets the access control. </summary>
        /// <param name="security"> The security. </param>
        void SetAccessControl( DirectorySecurity security );

        /// <summary> Zips the specified destination. </summary>
        /// <param name="destination"> The destination. </param>
        void Zip( string destination );

        /// <summary> Uns the zip. </summary>
        /// <param name="zipPath"> The zipPath. </param>
        void UnZip( string zipPath );

        /// <summary> Gets the special folders. </summary>
        /// <returns> </returns>
        IEnumerable<string> GetSpecialFolders( );

        /// <summary> Gets the sub folders. </summary>
        /// <returns> </returns>
        IDictionary<string, DirectoryInfo> GetSubDirectoryData( );
    }
}