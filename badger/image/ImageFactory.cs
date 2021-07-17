// <copyright file = "ImageFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "NotAccessedField.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    public class ImageFactory : ImageConfig
    {
        // ****************************************************************************************************************************
        // *********************************************    FIELDS  *******************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// The builder
        /// </summary>
        private readonly ImageBuilder _builder;

        /// <summary>
        /// The format
        /// </summary>
        private readonly ImageFormat _format;

        /// <summary>
        /// The stream data
        /// </summary>
        private readonly IDictionary<string, FileInfo> _fileStreams;

        /// <summary>
        /// The file paths
        /// </summary>
        private readonly IEnumerable<string> _paths;

        /// <summary>
        /// The file names
        /// </summary>
        private readonly IEnumerable<string> _names;

        // ****************************************************************************************************************************
        // *********************************************   CONSTRUCTORS ***************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageFactory"/> class.
        /// </summary>
        /// <param name = "imagebuilder" >
        /// The imagebuilder.
        /// </param>
        public ImageFactory( ImageBuilder imagebuilder )
        {
            _builder = imagebuilder;
            var imagesource = _builder.GetImageSource();
            _format = _builder.GetExtenstion();
            _paths = GetPaths( imagesource );
            _names = GetNames( _paths );
            _fileStreams = GetFileStreams( imagesource );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ImageFactory"/> class.
        /// </summary>
        /// <param name = "imagesource" >
        /// The imagesource.
        /// </param>
        public ImageFactory( ImageSource imagesource )
        {
            _builder = new ImageBuilder( imagesource );
            var source = _builder.GetImageSource();
            _format = _builder.GetExtenstion();
            _paths = GetPaths( source );
            _names = GetNames( _paths );
            _fileStreams = GetFileStreams( source );
        }

        // ****************************************************************************************************************************
        // ************************************************  METHODS   ****************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Sets the file paths.
        /// </summary>
        /// <param name = "resource" >
        /// The resource.
        /// </param>
        /// <returns>
        /// </returns>
        private IEnumerable<string> GetPaths( ImageSource resource )
        {
            try
            {
                return Verify.ImageResource( resource )
                    ? Directory.GetFiles( Resource.Settings[ resource.ToString() ] )
                    : default( string[] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Sets the file names.
        /// </summary>
        /// <returns>
        /// </returns>
        private IEnumerable<string> GetNames( IEnumerable<string> paths )
        {
            if( Verify.Input( paths ) )
            {
                try
                {
                    var filenames = new List<string>();

                    foreach( var path in paths )
                    {
                        if( Verify.Input( path ) )
                        {
                            var filename = Path.GetFileName( path );

                            if( File.Exists( filename ) )
                            {
                                filenames.Add( filename );
                            }
                        }
                    }

                    return filenames?.Any() == true
                        ? filenames
                        : default( List<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// Sets the file stream data.
        /// </summary>
        /// <param name = "resource" >
        /// The resource.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, FileInfo> GetFileStreams( ImageSource resource )
        {
            if( Verify.ImageResource( resource ) )
            {
                try
                {
                    var filedata = new Dictionary<string, FileInfo>();
                    var files = GetPaths( resource );

                    foreach( var image in files )
                    {
                        var stream = new FileInfo( image );
                        filedata.Add( stream.Name, stream );
                    }

                    return filedata?.Any() == true
                        ? filedata
                        : default( Dictionary<string, FileInfo> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, FileInfo> );
                }
            }

            return default( IDictionary<string, FileInfo> );
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetImageNames()
        {
            try
            {
                return _names?.Any() == true
                    ? _names
                    : default( IEnumerable<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the paths.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetImagePaths()
        {
            try
            {
                return _paths?.Any() == true
                    ? _paths
                    : default( IEnumerable<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the file stream data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, FileInfo> GetDataStreams()
        {
            try
            {
                return _fileStreams?.Any() == true
                    ? _fileStreams
                    : default( IDictionary<string, FileInfo> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, FileInfo> );
            }
        }

        /// <summary>
        /// Creates the image.
        /// </summary>
        /// <returns>
        /// </returns>
        public Bitmap CreateImage()
        {
            if( _builder?.GetFileStream() != null )
            {
                try
                {
                    using var stream = _builder?.GetFileStream();

                    return stream != null
                        ? new Bitmap( stream )
                        : default( Bitmap );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( Bitmap );
                }
            }

            return default( Bitmap );
        }

        /// <summary>
        /// Creates the icon.
        /// </summary>
        /// <returns>
        /// </returns>
        public Icon CreateIcon()
        {
            if( !_builder.GetSize().IsEmpty )
            {
                try
                {
                    using var stream = _builder.GetFileStream();

                    return stream != null
                        ? new Icon( stream, _builder.GetSize() )
                        : default( Icon );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( Icon );
                }
            }

            return default( Icon );
        }
    }
}
