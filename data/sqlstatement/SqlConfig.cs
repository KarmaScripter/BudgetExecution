// <copyright file = "SqlConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class SqlConfig : SqlBase, IProvider, ISource
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        private protected readonly EXT extension = EXT.SQL;

        /// <summary> The provider path </summary>
        private protected readonly NameValueCollection providerPath =
            ConfigurationManager.AppSettings;

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary> Gets the source. </summary>
        /// <value> The source. </value>
        private protected Source Source { get; set; }

        /// <summary> Gets the provider. </summary>
        /// <value> The provider. </value>
        private protected Provider Provider { get; set; }

        /// <summary> Gets the SQL statement. </summary>
        /// <value> The SQL statement. </value>
        private protected ISqlStatement SqlStatement { get; set; }

        /// <summary> Gets the file path. </summary>
        /// <value> The file path. </value>
        private protected string FilePath { get; set; }

        /// <summary> Gets the name of the file. </summary>
        /// <value> The name of the file. </value>
        protected string FileName { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the source. </summary>
        /// <returns> </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary> Gets the provider. </summary>
        /// <returns> </returns>
        public Provider GetProvider()
        {
            try
            {
                return Verify.Provider( Provider )
                    ? Provider
                    : default( Provider );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Provider );
            }
        }

        /// <inheritdoc/>
        /// <summary> Gets the type of the command. </summary>
        /// <returns> SQL </returns>
        public SQL GetCommandType()
        {
            try
            {
                return CommandType != SQL.NS
                    ? CommandType
                    : default( SQL );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( SQL );
            }
        }

        /// <inheritdoc/>
        /// <summary> Gets the arguments. </summary>
        /// <returns> </returns>
        public IDictionary<string, object> GetArgs()
        {
            if( Args.Any() )
            {
                try
                {
                    return Args ?? new Dictionary<string, object>();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return new Dictionary<string, object>();
                }
            }

            return new Dictionary<string, object>();
        }

        /// <inheritdoc/>
        /// <summary> Gets the connection manager. </summary>
        /// <returns> </returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.Input( ConnectionBuilder?.GetConnectionString() )
                    ? ConnectionBuilder
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ConnectionBuilder );
            }
        }

        /// <summary> Gets the command text. </summary>
        /// <returns> </returns>
        public string GetCommandText()
        {
            try
            {
                return Verify.Input( CommandText )
                    ? CommandText
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary> Gets the script files. </summary>
        /// <returns> </returns>
        public IEnumerable<string> GetScriptFiles()
        {
            if( Verify.Provider( Provider )
                && Enum.IsDefined( typeof( SQL ), CommandType ) )
            {
                try
                {
                    var directory = providerPath[ $"{Provider}" ] + $@"\{CommandType}";

                    if( !Verify.Input( directory )
                        || !Directory.Exists( directory ) )
                    {
                        return default( IEnumerable<string> );
                    }

                    var _scriptfiles = Directory.GetFiles( directory );

                    return _scriptfiles?.Any() == true
                        ? _scriptfiles
                        : default( string[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }
    }
}