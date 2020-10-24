// <copyright file = "IFolder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public interface IFolder
    {
        // ***************************************************************************************************************************
        // ****************************************************    MEMBERS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Creates the sub directory.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        DirectoryInfo CreateSubDirectory( string folder );

        /// <summary>
        /// Gets the path data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDataPath> GetDataPaths();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IFile> GetDataFiles();

        /// <summary>
        /// Moves the specified folder's path.
        /// </summary>
        /// <param name="path">
        /// The folder path.
        /// </param>
        void Move( string path );

        /// <summary>
        /// Sets the access control.
        /// </summary>
        /// <param name="security">The security.</param>
        void SetAccessControl( DirectorySecurity security );

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetFolderName();

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <returns></returns>
        string GetFolderPath();

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <returns></returns>
        DateTime GetCreationDate();

        /// <summary>
        /// Gets the changed date.
        /// </summary>
        /// <returns></returns>
        DateTime GetChangedDate();

        /// <summary>
        /// Zips the specified filepath.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        void Zip( string filepath );

        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        void UnZip( string filepath );

        /// <summary>
        /// Gets the special folders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetSpecialFolders();

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetFileNames();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<FileInfo> GetStreamData();

        /// <summary>
        /// Gets the sub folders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DirectoryInfo> GetSubFolders();
    }
}
