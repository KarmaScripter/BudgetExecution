﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ImageList.cs" company="Terry D. Eppler">
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
//   ImageList.cs
// </summary>
// ******************************************************************************************

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ImageList : ImageListBase
    {
        /// <summary> Gets or sets the image source. </summary>
        /// <value> The image source. </value>
        public ImageDirectory ImageSource { get; set; }

        /// <summary> Gets or sets the image. </summary>
        /// <value> The image. </value>
        public Image Image { get; set; }

        /// <summary> Gets or sets the file names. </summary>
        /// <value> The file names. </value>
        public IEnumerable<string> FileNames { get; set; }

        /// <summary> Gets or sets the file names. </summary>
        /// <value> The file names. </value>
        public IEnumerable<string> FilePaths { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ImageList"/>
        /// class.
        /// </summary>
        public ImageList( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ImageList"/>
        /// class.
        /// </summary>
        /// <param name="imageImageSource"> The image source. </param>
        /// <param name="size"> The size. </param>
        public ImageList( ImageDirectory imageImageSource, Size size )
        {
            ImageSource = imageImageSource;
            ImageSize = size;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ImageList"/>
        /// class.
        /// </summary>
        /// <param name="path"> The image source. </param>
        /// <param name="size"> The size. </param>
        public ImageList( string path, Size size )
        {
            ImageSource = ImageDirectory.Ns;
            ImageSize = size;
            Images.Add( new Bitmap( path ) );
        }

        /// <summary> Adds the specified image. </summary>
        /// <param name="image"> The image. </param>
        public void Add( Image image )
        {
            if( image != null )
            {
                try
                {
                    Images.Add( image );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Adds the specified path. </summary>
        /// <param name="path"> The path. </param>
        public void Add( string path )
        {
            if( !string.IsNullOrEmpty( path )
               && File.Exists( path ) )
            {
                try
                {
                    var _name = Path.GetFileName( path );
                    var _image = new Bitmap( path );
                    if( _image != null )
                    {
                        Images.Add( _name, _image );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Adds the specified paths. </summary>
        /// <param name="paths"> The paths. </param>
        public void Add( string[ ] paths )
        {
            if( paths?.Any( ) == true )
            {
                try
                {
                    foreach( var _file in paths )
                    {
                        if( File.Exists( _file ) )
                        {
                            var _name = Path.GetFileName( _file );
                            var _image = new Bitmap( _file );
                            if( _image != null )
                            {
                                Images.Add( _name, _image );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Adds the specified paths. </summary>
        /// <param name="image"> The paths. </param>
        public void Remove( Image image )
        {
            if( ( image != null )
               && ( Images?.Contains( image ) == true ) )
            {
                try
                {
                    Images.Remove( image );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Creates the images. </summary>
        /// <param name="srcDir"> The source dir. </param>
        /// <returns> </returns>
        public IEnumerable<Image> CreateImages( string srcDir )
        {
            if( Directory.Exists( srcDir ) )
            {
                IEnumerable<string> _files = Directory.GetFiles( srcDir );
                var _list = new List<Image>( );
                if( _files?.Count( ) > 0 )
                {
                    foreach( var _file in _files )
                    {
                        using var _stream = File.Open( _file, FileMode.Open );
                        using var _img = new Bitmap( _stream );
                        _list.Add( _img );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IEnumerable<Image> );
            }

            return default( IEnumerable<Image> );
        }

        /// <summary> Gets the images. </summary>
        /// <param name="paths"> The source path. </param>
        /// <returns> </returns>
        public IEnumerable<Image> CreateImages( IEnumerable<string> paths )
        {
            if( paths?.Count( ) > 0 )
            {
                var _files = paths.ToList( );
                var _list = new List<Image>( );
                for( var i = 0; i < _files.Count; i++ )
                {
                    using var _stream = File.Open( _files[ i ], FileMode.Open );
                    using var _img = new Bitmap( _stream );
                    _list.Add( _img );
                }

                return _list.Count > 0
                    ? _list
                    : default( IEnumerable<Image> );
            }

            return default( IEnumerable<Image> );
        }
    }
}