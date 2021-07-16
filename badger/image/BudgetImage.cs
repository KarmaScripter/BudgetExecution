// <copyright file = "BudgetImage.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class BudgetImage : ImageConfig, IBudgetImage
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The builder
        /// </summary>
        private readonly ImageBuilder _builder;

        /// <summary>
        /// The factory
        /// </summary>
        private readonly ImageFactory _factory;

        // ****************************************************************************************************************************
        // *********************************************   CONSTRUCTORS ***************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetImage"/> class.
        /// </summary>
        public BudgetImage()
        {
        }

        public BudgetImage( string path )
        {
            Name = Path.GetFileNameWithoutExtension( path );
            _builder = new ImageBuilder( Path.GetFullPath( path ) );
            image = new Bitmap( _builder.GetFilePath() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetImage"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name = "source" > </param>
        public BudgetImage( string path, ImageSource source = ImageSource.NS )
        {
            Name = Path.GetFileNameWithoutExtension( path );
            _builder = new ImageBuilder( Name, source, ImageSizer.Medium );
            _factory = new ImageFactory( _builder );
            image = _factory.CreateImage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetImage"/> class.
        /// </summary>
        /// <param name = "imagebuilder" >
        /// The imagebuilder.
        /// </param>
        public BudgetImage( ImageBuilder imagebuilder )
        {
            _builder = imagebuilder;
            Name = _builder.GetImageName();
            _factory = new ImageFactory( _builder );
            image = _factory.CreateImage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetImage"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "resource" >
        /// The resource.
        /// </param>
        /// <param name = "size" >
        /// </param>
        public BudgetImage( string name, ImageSource resource, ImageSizer size = ImageSizer.Medium )
        {
            _builder = new ImageBuilder( name, resource, size );
            Name = _builder.GetImageName();
            _factory = new ImageFactory( _builder );
            image = _factory.CreateImage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetImage"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "size" >
        /// The size.
        /// </param>
        /// <param name = "resource" >
        /// The resource.
        /// </param>
        public BudgetImage( string name, ImageSource resource, Size size )
        {
            _builder = new ImageBuilder( name, resource, size );
            Name = _builder.GetImageName();
            _factory = new ImageFactory( _builder );
            image = _factory.CreateImage();
        }

        // ****************************************************************************************************************************
        // ************************************************  METHODS   ****************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public ImageBuilder GetBuilder()
        {
            try
            {
                return Verify.Ref( _builder )
                    ? _builder
                    : default( ImageBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ImageBuilder );
            }
        }

        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <returns>
        /// </returns>
        public ImageFactory GetFactory()
        {
            try
            {
                return Verify.Ref( _factory )
                    ? _factory
                    : default( ImageFactory );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ImageFactory );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetName()
        {
            if( Verify.Input( Name ) )
            {
                try
                {
                    return Path.HasExtension( Name )
                        ? Path.GetFileNameWithoutExtension( Name )
                        : Name;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the tag.
        /// </summary>
        /// <param name = "tag" >
        /// The tag.
        /// </param>
        public void SetTag( object tag )
        {
            if( Verify.Ref( image )
                && Verify.Ref( tag ) )
            {
                try
                {
                    image.Tag = tag;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    image?.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>
        /// </returns>
        public Image GetBitmap()
        {
            try
            {
                return Verify.Ref( image )
                    ? image
                    : default( Bitmap );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Image );
            }
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <returns>
        /// </returns>
        public Color GetColor( Color newcolor )
        {
            try
            {
                return newcolor != Color.Empty
                    ? ColorConfig.GetColor( newcolor )
                    : Color.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Color );
            }
        }
    }
}
