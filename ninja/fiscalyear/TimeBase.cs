// <copyright file = "TimeBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "UnitBase"/>
    /// <seealso cref = "IUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class TimeBase : UnitBase
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        private protected DateTime Day { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        private protected EventDate EventDate { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetName( DataRow datarow, string name )
        {
            if( datarow != null
                && Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var columns = datarow.Table?.GetColumnNames();

                    Name = columns?.Contains( name ) == true
                        ? name
                        : EventDate.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetName( EventDate date )
        {
            try
            {
                Name = Verify.EventDate( date )
                    ? date.ToString()
                    : EventDate.NS.ToString();
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetName( DataRow datarow, EventDate date )
        {
            if( Verify.Row( datarow )
                && Verify.EventDate( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    Name = names?.Contains( date.ToString() ) == true
                        ? date.ToString()
                        : EventDate.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDate( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( name ) == true )
            {
                try
                {
                    var date = (EventDate)Enum.Parse( typeof( EventDate ), name );

                    EventDate = Enum.IsDefined( typeof( EventDate ), date )
                        ? date
                        : default( EventDate );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDate( DataRow datarow, string name )
        {
            if( datarow != null
                && Verify.Input( name ) )
            {
                try
                {
                    var date = (EventDate)Enum.Parse( typeof( EventDate ), name );
                    var columns = datarow.Table?.GetColumnNames();

                    if( columns?.Any() == true
                        && columns?.Contains( $"{date}" ) == true )
                    {
                        EventDate = Enum.GetNames( typeof( EventDate ) )?.Contains( $"{date}" ) == true
                            ? date
                            : EventDate.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDate( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();

                    if( names?.Any() == true )
                    {
                        EventDate = names?.Contains( date.ToString() ) == true
                            ? date
                            : EventDate.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDay( string value )
        {
            try
            {
                Day = Verify.Input( value )
                    ? DateTime.Parse( value )
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "column" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDay( DataRow datarow, string column )
        {
            if( datarow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();
                    var value = datarow[ column ]?.ToString();

                    Day = names?.Contains( column ) == true && Verify.Input( value )
                        ? DateTime.Parse( value )
                        : default( DateTime );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetDay( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var value = datarow[ $"{date}" ]?.ToString();

                    Day = DateTime.Parse( value ) != null
                        ? DateTime.Parse( value )
                        : default( DateTime );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetValue( string value )
        {
            try
            {
                Value = Verify.Input( value )
                    ? value
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetValue( DataRow datarow, string column )
        {
            if( datarow != null
                && Verify.Input( column )
                && Enum.GetNames( typeof( EventDate ) )?.Contains( column ) == true )
            {
                try
                {
                    var names = datarow.Table?.GetColumnNames();
                    var value = datarow[ column ]?.ToString();

                    Value = names?.Contains( column ) == true && Verify.Input( value )
                        ? datarow[ column ].ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        /// <param name = "date" >
        /// The date.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetValue( DataRow datarow, EventDate date )
        {
            if( datarow != null
                && Verify.EventDate( date ) )
            {
                try
                {
                    var value = datarow[ $"{date}" ]?.ToString();

                    Value = DateTime.Parse( value ) != null
                        ? datarow[ $"{date}" ]?.ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}