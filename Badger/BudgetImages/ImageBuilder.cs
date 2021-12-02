﻿// <copyright file = "ImageBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ImageBuilder : ImageConfig
    {
        /// <summary>
        /// The file path
        /// </summary>
        public string FullPath;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageBuilder"/> class.
        /// </summary>
        public ImageBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBuilder"/> class.
        /// </summary>
        /// <param name="fullPath">The fullPath.</param>
        public ImageBuilder( string fullPath )
        {
            SetName( Path.GetFileNameWithoutExtension( fullPath ) );
            Source = ImageSource.NS;
            SetFileExtension( Path.GetExtension( fullPath ) );
            SetImageFilePath( fullPath, Source );
            SetImageFormat( FileExtension );
            SetImageFilePath( ImageName, Source );
            SetImageSize( Medium );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBuilder"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public ImageBuilder( ImageSource source )
        {
            SetName( source.ToString() );
            SetImageSource( source );
            SetFileExtension( ImageFormat.PNG.ToString() );
            SetImageFormat( FileExtension );
            SetImageFilePath( ImageName, Source );
            SetImageFormat( Format );
            SetImageSize( ImageSizer.Medium );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageBuilder"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "source" >
        /// The resource.
        /// </param>
        /// <param name = "size" >
        /// The size.
        /// </param>
        public ImageBuilder( string name, ImageSource source, ImageSizer size = ImageSizer.Medium )
        {
            SetName( name );
            SetImageSource( source );
            SetFileExtension( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageFilePath( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageSize( ImageSizer.Medium );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageBuilder"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "source" >
        /// The resource.
        /// </param>
        /// <param name = "width" >
        /// The width.
        /// </param>
        /// <param name = "height" >
        /// The height.
        /// </param>
        public ImageBuilder( string name, ImageSource source, int width = 16,
            int height = 16 )
        {
            SetName( name );
            SetImageSource( source );
            SetFileExtension( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageFilePath( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageSize( width, height );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageBuilder"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "source" >
        /// The resource.
        /// </param>
        /// <param name = "size" >
        /// The size.
        /// </param>
        public ImageBuilder( string name, ImageSource source, Size size )
        {
            SetName( name );
            SetImageSource( source );
            SetFileExtension( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageFilePath( ImageName, Source );
            SetImageFormat( FileExtension );
            SetImageSize( size );
        }
        
        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name = "imageSource" >
        /// The imageSource.
        /// </param>
        /// <param name = "filePath" >
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetImageFilePath( string filePath, ImageSource imageSource )
        {
            if( Verify.ImageResource( imageSource )
                && Verify.Input( filePath )
                && imageSource != ImageSource.NS )
            {
                try
                {
                    var _files = Directory.GetFiles( Resource.Settings[ imageSource.ToString() ] );

                    var _path = _files
                        ?.Where( n => n.Contains( filePath ) )
                        ?.Select( n => n )
                        ?.FirstOrDefault();

                    if( Verify.Input( _path ) )
                    {
                        FullPath = File.Exists( _path )
                            ? _path
                            : default( string );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the image file path.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <returns></returns>
        private protected void GetImageFilePath( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    FullPath = File.Exists( filePath )
                        ? Path.GetFullPath( filePath )
                        : default( string );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the resource path.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetDirectoryPath()
        {
            try
            {
                return Verify.ImageResource( Source ) 
                    && Verify.Input( Resource.Settings[ $"{Source}" ] )
                        ? Resource.Settings[ $"{Source}" ]
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetFilePath()
        {
            try
            {
                return Verify.Input( FullPath )
                    ? FullPath
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }

            return default( string );
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns>
        /// </returns>
        public Size GetSize()
        {
            try
            {
                return Verify.ImageSize( ImageSize )
                    ? ImageSize
                    : default( Size );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }

            return default( Size );
        }

        /// <summary>
        /// Gets the name of the image.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetImageName()
        {
            try
            {
                return Verify.Input( ImageName )
                    ? ImageName
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the extenstion.
        /// </summary>
        /// <returns>
        /// </returns>
        public ImageFormat GetExtenstion()
        {
            try
            {
                return Enum.IsDefined( typeof( ImageFormat ), Format )
                    ? Format
                    : ImageFormat.PNG;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ImageFormat );
            }
        }

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        /// <returns>
        /// </returns>
        public FileStream GetFileStream()
        {
            try
            {
                return Verify.Input( FullPath ) && File.Exists( FullPath )
                    ? File.OpenRead( FullPath )
                    : default( FileStream );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( FileStream );
            }
        }
    }
}