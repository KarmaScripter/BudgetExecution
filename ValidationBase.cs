﻿// ************************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:              15-11-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        15-11-2023
// ************************************************************************************************
// <copyright file="ValidationBase.cs.cs" company="Terry D. Eppler">
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Eppler, Terry.cs
// </summary>
// ************************************************************************************************
namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class ValidationBase
    {
        /// <summary>
        /// 
        /// </summary>
        private protected const string AtomCharacters = "!#$%&'*+-/=?^_`{|}~";

        /// <summary>
        /// 
        /// </summary>
        private protected const int MaxDomainLabelLength = 63;

        /// <summary>
        /// 
        /// </summary>
        private protected const int MaxEmailAddressLength = 254;

        /// <summary>
        /// 
        /// </summary>
        private protected const int MaxLocalPartLength = 64;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="allowInternational"></param>
        /// <returns></returns>
        private protected static int Measure( string text, int startIndex, int endIndex,
            bool allowInternational )
        {
            int count;
            if( allowInternational )
            {
                var index = startIndex;
                count = 0;
                while( index < endIndex )
                {
                    if( ( ( index + 1 ) < endIndex )
                       && char.IsSurrogatePair( text, index ) )
                    {
                        index++;
                    }

                    index++;
                    count++;
                }
            }
            else
            {
                count = endIndex - startIndex;
            }

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private protected static bool IsControl( char c )
        {
            return ( c <= 31 ) || ( c == 127 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit( char c )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                return ( c >= '0' ) && ( c <= '9' );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private protected static bool IsLetter( char c )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                return ( ( c >= 'A' ) && ( c <= 'Z' ) ) || ( ( c >= 'a' ) && ( c <= 'z' ) );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private protected static bool IsLetterOrDigit( char c )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                return IsLetter( c ) || IsDigit( c );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="allowInternational"></param>
        /// <returns></returns>
        private protected static bool IsAtom( char c, bool allowInternational )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                if( IsControl( c ) )
                {
                    return false;
                }

                return c < 128
                    ? IsLetterOrDigit( c ) || ( AtomCharacters.IndexOf( c ) != -1 )
                    : allowInternational && !char.IsWhiteSpace( c );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="allowInternational"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private protected static bool IsDomain( char c, bool allowInternational, 
            ref SubDomainType type )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                if( c < 128 )
                {
                    if( IsLetter( c )
                       || ( c == '-' ) )
                    {
                        type |= SubDomainType.Alphabetic;
                        return true;
                    }

                    if( IsDigit( c ) )
                    {
                        type |= SubDomainType.Numeric;
                        return true;
                    }

                    return false;
                }

                if( allowInternational && !char.IsWhiteSpace( c ) )
                {
                    type |= SubDomainType.Alphabetic;
                    return true;
                }

                return false;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="allowInternational"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsDomainStart( char c, bool allowInternational, 
            out SubDomainType type )
        {
            try
            {
                var _test = c.ToString( );
                ThrowIf.NullOrEmpty( _test, nameof( c ) );
                if( c < 128 )
                {
                    if( IsLetter( c ) )
                    {
                        type = SubDomainType.Alphabetic;
                        return true;
                    }

                    if( IsDigit( c ) )
                    {
                        type = SubDomainType.Numeric;
                        return true;
                    }

                    type = SubDomainType.None;
                    return false;
                } 
                else if( allowInternational && !char.IsWhiteSpace( c ) )
                {
                    type = SubDomainType.Alphabetic;
                    return true;
                }
                else
                {
                    type = SubDomainType.None;
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                type = SubDomainType.None;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <param name="allowInternational"></param>
        /// <returns></returns>
        private protected static bool SkipAtom( string text, ref int index, 
            bool allowInternational )
        {
            try
            {
                ThrowIf.NullOrEmpty( text, nameof( text ) );
                ThrowIf.Negative( index, nameof( index ) );
                var startIndex = index;
                while( ( index < text.Length )
                      && IsAtom( text[ index ], allowInternational ) )
                {
                    index++;
                }

                return index > startIndex;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <param name="allowInternational"></param>
        /// <param name="type"></param>
        /// <returns>
        /// </returns>
        private protected static bool SkipSubDomain( string text, ref int index,
            bool allowInternational, out SubDomainType type )
        {
            var startIndex = index;
            if( !IsDomainStart( text[ index ], allowInternational, out type ) )
            {
                return false;
            }

            index++;
            while( ( index < text.Length )
                  && IsDomain( text[ index ], allowInternational, ref type ) )
            {
                index++;
            }

            var length = Measure( text, startIndex, index, allowInternational );
            if( ( index == text.Length )
               && ( length == 1 ) )
            {
                return false;
            }

            return ( length <= MaxDomainLabelLength ) && ( text[ index - 1 ] != '-' );
        }

        /// <summary> Fails the specified ex. </summary>
        /// <param name="ex"> The ex. </param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}