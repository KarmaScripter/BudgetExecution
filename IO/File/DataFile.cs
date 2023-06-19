﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 04-22-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="DataFile.cs" company="Terry D. Eppler">
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
//   DataFile.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static System.IO.Directory;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.FileBase" />
    /// <seealso cref="BudgetExecution.IDataFile" />
    public class DataFile : FileBase, IDataFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFile"/> class.
        /// </summary>
        public DataFile( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFile"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public DataFile( string input )
            : base( input )
        {
        }

        /// <summary>
        /// Transfers the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public void Transfer( DirectoryInfo folder )
        {
            if( ( folder != null )
               && !Exists( folder.FullName ) )
            {
                CreateDirectory( folder.FullName );
            }

            try
            {
                var _files = folder?.GetFiles( );
                if( _files?.Any( ) == true )
                {
                    foreach( var _fileInfo in _files )
                    {
                        Directory.Move( _fileInfo.FullName, folder.Name );
                    }
                }
            }
            catch( IOException _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        /// <c> true </c>
        /// if [contains] [the specified search]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool Contains( string search )
        {
            try
            {
                if( !string.IsNullOrEmpty( search )
                   && File.Exists( search ) )
                {
                    using var _stream = File.Open( search, FileMode.Open );
                    using var _reader = new StreamReader( _stream );
                    if( _reader != null )
                    {
                        var _text = _reader?.ReadLine( );
                        var _result = false;
                        while( _text == string.Empty )
                        {
                            if( Regex.IsMatch( _text, search ) )
                            {
                                _result = true;
                                break;
                            }

                            _text = _reader.ReadLine( );
                        }

                        return _result;
                    }
                }

                return false;
            }
            catch( IOException _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// Searches the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> Search( string pattern )
        {
            if( !string.IsNullOrEmpty( pattern ) )
            {
                try
                {
                    var _input = Path.GetFullPath( Buffer );
                    if( !string.IsNullOrEmpty( _input )
                       && File.Exists( _input ) )
                    {
                        IEnumerable<string> _enumerable = GetDirectories( _input, pattern );
                        var _list = new List<FileInfo>( );
                        foreach( var _file in _enumerable )
                        {
                            _list.Add( new FileInfo( _file ) );
                        }

                        return _list?.Any( ) == true
                            ? _list
                            : default( List<FileInfo> );
                    }
                }
                catch( IOException _ex )
                {
                    Fail( _ex );
                    return default( IEnumerable<FileInfo> );
                }
            }

            return default( IEnumerable<FileInfo> );
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <returns></returns>
        public string GetParentDirectory( )
        {
            if( !string.IsNullOrEmpty( Buffer ) )
            {
                try
                {
                    return HasParent
                        ? GetParent( Buffer )?.FullName
                        : string.Empty;
                }
                catch( IOException _ex )
                {
                    Fail( _ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            try
            {
                return !string.IsNullOrEmpty( Name )
                    ? Name
                    : string.Empty;
            }
            catch( IOException _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static FileInfo Create( string filePath )
        {
            try
            {
                return !string.IsNullOrEmpty( filePath )
                    ? new FileInfo( filePath )
                    : default( FileInfo );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( FileInfo );
            }
        }

        /// <summary>
        /// Browses this instance.
        /// </summary>
        /// <returns></returns>
        public static string OpenDialog( )
        {
            try
            {
                var _dialog = new OpenFileDialog( );
                _dialog.CheckFileExists = true;
                _dialog.CheckPathExists = true;
                _dialog.ShowDialog( );
                return _dialog.FileName;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Browses this instance.
        /// </summary>
        /// <returns></returns>
        public static string SaveDialog( )
        {
            try
            {
                var _dialog = new SaveFileDialog(  );
                _dialog.CheckFileExists = true;
                _dialog.CheckPathExists = true;
                return _dialog.FileName;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save( )
        {
            try
            {
                var _dialog = new SaveFileDialog( );
                _dialog.CreatePrompt = true;
                _dialog.OverwritePrompt = true;
                _dialog.CheckFileExists = true;
                _dialog.CheckPathExists = true;
                _dialog.ShowDialog( );
                return _dialog.FileName;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }
    }
}