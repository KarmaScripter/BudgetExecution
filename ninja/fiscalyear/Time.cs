// <copyright file = "Time.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TimeBase" />
    /// <seealso cref="ITime" />
    /// <seealso cref="TimeBase" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class Time : TimeBase, ITime
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The default
        /// </summary>
        public static readonly Time Default = new Time( EventDate.NS );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        public Time()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="kvp">The KVP.</param>
        public Time( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetDate( kvp.Key );
            SetDay( kvp.Value?.ToString() );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Time( string name, string value = "" )
        {
            SetName( name );
            SetDate( name );
            SetDay( value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="value">The value.</param>
        public Time( EventDate date, string value = "" )
        {
            SetName( date );
            SetDate( date.ToString() );
            SetDay( value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="date">The date.</param>
        public Time( DataRow datarow, EventDate date )
        {
            SetDate( datarow, date );
            SetName( datarow, date );
            SetDay( datarow, date );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="value">The value.</param>
        public Time( DataRow datarow, string value )
        {
            SetDate( datarow, value );
            SetName( datarow, value );
            SetDay( datarow, value );
            Data = Day.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="datarow">The data.</param>
        /// <param name="column">The column.</param>
        public Time( DataRow datarow, DataColumn column )
        {
            SetDate( datarow, column.ColumnName );
            SetName( datarow, column.ColumnName );
            SetDay( datarow, datarow[ column ]?.ToString() );
            Data = Day.ToString();
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDay()
        {
            try
            {
                return Verify.DateTime( Day )
                    ? Day
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), EventDate )
                    ? EventDate.ToString()
                    : EventDate.NS.ToString();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EventDate.NS.ToString();
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), EventDate )
                    ? $"{Name} = {Day}"
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        public EventDate GetEventDate()
        {
            try
            {
                return Enum.IsDefined( typeof( EventDate ), EventDate )
                    ? EventDate
                    : EventDate.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EventDate.NS;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return !Verify.DateTime( Day )
                    ? Name + " = " + Day
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the specified element is equal.
        /// </summary>
        /// <param name="day">The element.</param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified element is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public bool IsEqual( ITime day )
        {
            if( day != null
                && day != Default )
            {
                try
                {
                    if( day?.GetValue()?.Equals( Day ) == true
                        && day?.GetName() == Name )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified primary is equal.
        /// </summary>
        /// <param name="first">The primary.</param>
        /// <param name="second">The secondary.</param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified primary is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public static bool IsEqual( ITime first, ITime second )
        {
            if( first != null
                && first != Element.Default
                && first != null
                && second != Element.Default )
            {
                try
                {
                    if( first?.GetValue()?.Equals( second?.GetValue() ) == true
                        && first?.GetName() == second?.GetName() )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }
    }
}
