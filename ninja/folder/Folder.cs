// <copyright file = "Folder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FolderBase" />
    /// <seealso cref="IFolder" />
    public class Folder : FolderBase, IFolder
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        public Folder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        /// <param name="datafile">The file.</param>
        public Folder( IDataFile datafile )
        {
            DataFile = datafile;
            DirectoryInfo = GetBaseDirectory();
            FolderName = DirectoryInfo.Name;
            FolderPath = DirectoryInfo.FullName;
            Files = Directory.GetFiles( FolderPath );
            DirectorySecurity = DirectoryInfo.GetAccessControl();
            CreationDate = DirectoryInfo.CreationTime;
            ChangedDate = DirectoryInfo.LastWriteTime;
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the current directory.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            try
            {
                return Verify.Input( DataPath.CurrentDirectory )
                    ? DataPath.CurrentDirectory
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Creates the specified filepath.
        /// </summary>
        /// <param name="fullname">The filepath.</param>
        /// <returns></returns>
        public static DirectoryInfo Create( string fullname )
        {
            try
            {
                return Verify.Input( fullname ) && !Directory.Exists( fullname )
                    ? Directory.CreateDirectory( fullname )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Deletes the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public static void Delete( string folder )
        {
            try
            {
                if( Verify.Input( folder )
                    && Directory.Exists( folder ) )
                {
                    Directory.Delete( folder, true );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the sub folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        public DirectoryInfo CreateSubDirectory( string folder )
        {
            if( string.IsNullOrEmpty( folder ) )
            {
                return default;
            }

            if( Verify.Input( folder )
                && Directory.Exists( folder ) )
            {
                Directory.Delete( folder );
            }

            try
            {
                return Verify.Input( folder ) && !Directory.Exists( folder )
                    ? DirectoryInfo?.CreateSubdirectory( folder )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the path data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDataPath> GetDataPaths()
        {
            try
            {
                var paths = Files?.Select( fd => new DataPath( fd ) )?.ToArray();

                return paths?.Any() == true
                    ? paths
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDataFile> GetDataFiles()
        {
            try
            {
                var paths = Files?.Select( f => new DataPath( f ) )?.ToArray();
                var data = paths?.Select( d => new DataFile( d ) )?.ToArray();

                return Verify.Input( data )
                    ? data
                    : default;
            }
            catch( IOException ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Moves the specified folderpath.
        /// </summary>
        /// <param name="path">The folderpath.</param>
        public void Move( string path )
        {
            try
            {
                if( Verify.Input( path )
                    && !Directory.Exists( path ) )
                {
                    DirectoryInfo?.MoveTo( path );
                }
                else if( Verify.Input( path )
                    && Directory.Exists( path ) )
                {
                    Directory.CreateDirectory( path );
                    DirectoryInfo?.MoveTo( path );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Zips the specified filepath.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public void Zip( string filepath )
        {
            try
            {
                if( Verify.Input( filepath ) )
                {
                    ZipFile.CreateFromDirectory( FolderPath, filepath );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="zippath">The zippath.</param>
        public void UnZip( string zippath )
        {
            try
            {
                if( Verify.Input( zippath )
                    && File.Exists( zippath ) )
                {
                    ZipFile.ExtractToDirectory( zippath, FolderPath );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the access control.
        /// </summary>
        /// <param name="security">The security.</param>
        public void SetAccessControl( DirectorySecurity security )
        {
            if( security != null )
            {
                try
                {
                    DirectoryInfo?.SetAccessControl( security );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
