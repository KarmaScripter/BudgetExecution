﻿// <copyright file = "ConnectionBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class ConnectionBase
    {
        /// <summary>
        /// The connector
        /// </summary>
        public readonly ConnectionStringSettingsCollection Connectors =
            ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// The provider path
        /// </summary>
        public readonly NameValueCollection ProviderPath = ConfigurationManager.AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// The file extension
        /// </summary>
        public EXT FileExtension { get; set; }

        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">
        /// The source.</param>
        private protected void SetSource( Source source )
        {
            try
            {
                Source = Validate.IsSource( source )
                    ? source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private protected void SetSource( string fileName )
        {
            if( Verify.IsInput( fileName )
                && File.Exists( fileName )
                && Resource.Sources?.Contains( fileName ) == true )
            {
                try
                {
                    Source = (Source)Enum.Parse( typeof( Source ), fileName );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            if( !Verify.IsInput( fileName )
                || !File.Exists( fileName )
                || !Resource.Sources?.Contains( fileName ) != true )
            {
                return;
            }

            {
                try
                {
                    Source = Source.External;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetProvider( Provider provider )
        {
            try
            {
                Provider = Validate.IsProvider( provider )
                    && Resource.Providers?.Contains( provider.ToString() ) == true
                        ? (Provider)Enum.Parse( typeof( Provider ), $"{provider}" )
                        : Provider.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="extension">The extension.</param>
        private protected void SetProvider( EXT extension )
        {
            if( Validate.EXT( extension ) )
            {
                try
                {
                    Provider = extension switch
                    {
                        EXT.MDB => Provider.OleDb,
                        EXT.XLS => Provider.OleDb,
                        EXT.XLSX => Provider.Excel,
                        EXT.CSV => Provider.CSV,
                        EXT.SDF => Provider.SqlCe,
                        EXT.DB => Provider.SQLite,
                        EXT.MDF => Provider.SqlServer,
                        EXT.ACCDB => Provider.Access,
                        _ => Provider.SQLite
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetFilePath( Provider provider )
        {
            if( Validate.IsProvider( provider ) )
            {
                try
                {
                    FilePath = provider switch
                    {
                        Provider.OleDb => ProviderPath[ "OleDb" ],
                        Provider.Access => ProviderPath[ "Access" ],
                        Provider.SQLite => ProviderPath[ "SQLite" ],
                        Provider.SqlCe => ProviderPath[ "SqlCe" ],
                        Provider.SqlServer => ProviderPath[ "SqlServer" ],
                        Provider.CSV => ProviderPath[ "CSV" ],
                        Provider.Excel => ProviderPath[ "Excel" ],
                        Provider.NS => ProviderPath[ "Excel" ],
                        _ => ProviderPath[ "SQLite" ]
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        private protected void SetFilePath( string filePath )
        {
            try
            {
                FilePath = Verify.IsInput( filePath ) 
                    && File.Exists( filePath )
                        ? Path.GetFullPath( filePath )
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the file extension.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        private protected void SetFileExtension( string filePath )
        {
            if( Verify.IsInput( filePath ) )
            {
                try
                {
                    var _fileExtension = Path.GetExtension( filePath )
                            ?.Trim( '.' )
                            ?.ToUpper();

                    FileExtension = Enum.IsDefined( typeof( EXT ), _fileExtension )
                        ? (EXT)Enum.Parse( typeof( EXT ), _fileExtension )
                        : EXT.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected void SetFileName( string filePath )
        {
            if( Verify.IsInput( filePath ) )
            {
                try
                {
                    var _filename = Path.GetFileNameWithoutExtension( filePath );

                    FileName = Verify.IsInput( filePath )
                        ? _filename
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the provider path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected void SetProviderPath( string filePath )
        {
            if( Verify.IsInput( filePath )
                && File.Exists( filePath )
                && Path.HasExtension( filePath ) )
            {
                try
                {
                    var _extension =
                        (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( filePath ) );

                    FilePath = _extension switch
                    {
                        EXT.MDB => ConfigurationManager.AppSettings[ "OleDbFilePath" ],
                        EXT.ACCDB => ConfigurationManager.AppSettings[ "AccessFilePath" ],
                        EXT.DB => ConfigurationManager.AppSettings[ "SQLiteFilePath" ],
                        EXT.SDF => ConfigurationManager.AppSettings[ "SqlCeFilePath" ],
                        EXT.MDF => ConfigurationManager.AppSettings[ "SqlServerFilePath" ],
                        EXT.XLS => ConfigurationManager.AppSettings[ "ExcelFilePath" ]
                                                       .Replace( "{FilePath}", filePath ),
                        EXT.XLSX => ConfigurationManager.AppSettings[ "ExcelFilePath" ]
                                                        .Replace( "{FilePath}", filePath ),
                        EXT.CSV => ConfigurationManager.AppSettings[ "CsvFilePath" ]
                                                       .Replace( "{FilePath}", filePath ),
                        EXT.TXT => ConfigurationManager.AppSettings[ "CsvFilePath" ]
                                                       .Replace( "{FilePath}", filePath ),
                        _ => ConfigurationManager.AppSettings[ "SQLiteFilePath" ]
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the connection string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetConnectionString( Provider provider )
        {
            if( Validate.IsProvider( provider ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.OleDb:
                        case Provider.Excel:
                        case Provider.CSV:
                        {
                            var _connection = ConfigurationManager
                                              .ConnectionStrings[ provider.ToString() ]
                                              ?.ConnectionString;

                            ConnectionString = Verify.IsInput( _connection )
                                ? _connection?.Replace( "{FilePath}", FilePath )
                                : string.Empty;

                            break;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var _connection = ConfigurationManager
                                              .ConnectionStrings[ provider.ToString() ]
                                              ?.ConnectionString;

                            ConnectionString = Verify.IsInput( _connection )
                                ? _connection
                                : string.Empty;

                            break;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}