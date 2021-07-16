// <copyright file = "Amount.cs" company = "Terry D. Eppler">
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
    using System.Threading;

    /// <summary> </summary>
    /// <seealso cref = "IAmount"/>
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Amount : AmountBase, IAmount
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary> The default </summary>
        public static readonly IAmount Default = new Amount( Numeric.NS, 0.0 );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        public Amount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "numeric" > The numeric. </param>
        /// <param name = "value" > The value. </param>
        public Amount( Numeric numeric = Numeric.Amount, double value = 0.0 )
        {
            Data = value;
            Funding = value;
            Numeric = numeric;
            Name = Numeric.ToString();
            Initial = Funding;
            Delta = Initial - Funding;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "value" > The value. </param>
        /// <param name = "numeric" > The numeric. </param>
        public Amount( double value = 0, Numeric numeric = Numeric.Amount )
        {
            Data = value;
            Funding = value;
            Numeric = numeric;
            Name = Numeric.ToString();
            Initial = Funding;
            Delta = Initial - Funding;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "numeric" > The numeric. </param>
        public Amount( DataRow data, Numeric numeric = Numeric.Amount )
        {
            Funding = double.Parse( data[ $"{numeric}" ].ToString() );
            Data = Funding.ToString();
            Numeric = numeric;
            Name = Numeric.ToString();
            Initial = Funding;
            Delta = Initial - Funding;
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Gets the original. </summary>
        /// <returns> </returns>
        public double GetOriginal()
        {
            try
            {
                return Initial > 0
                    ? Initial
                    : Amount.Default.GetFunding();
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
                return 0;
            }
        }

        /// <summary> Gets the change. </summary>
        /// <returns> </returns>
        public double GetDelta()
        {
            try
            {
                return Delta != 0
                    ? Delta
                    : Amount.Default.GetFunding();
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
                return Amount.Default.GetFunding();
            }
        }

        /// <summary> Gets the numeric. </summary>
        /// <returns> </returns>
        public Numeric GetNumeric()
        {
            try
            {
                return Enum.IsDefined( typeof( Numeric ), Numeric )
                    ? Numeric
                    : Numeric.NS;
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
                return default( Numeric );
            }
        }

        /// <summary> Increases the specified amount. </summary>
        /// <param name = "amount" > The amount. </param>
        public void Increase( double amount )
        {
            try
            {
                Delta = amount;
                Funding += Delta;

                if( Initial != Funding )
                {
                    //unfinished
                }
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
            }
        }

        /// <summary> Decreases the specified amount. </summary>
        /// <param name = "amount" > The amount. </param>
        public void Decrease( double amount )
        {
            try
            {
                Delta = amount;

                if( Funding > amount )
                {
                    Funding -= amount;
                }

                if( Initial != Funding )
                {
                    // Unfinished
                }
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
            }
        }

        /// <summary> Converts to string. </summary>
        /// <returns>
        /// A
        /// <see cref = "string"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( Data?.ToString() )
                    ? Data?.ToString()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
                return string.Empty;
            }
        }

        /// <summary> Determines whether the specified element is equal. </summary>
        /// <param name = "amount" > The element. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool IsEqual( IAmount amount )
        {
            if( amount != null
                && amount.GetFunding() != Amount.Default.GetFunding() )
            {
                try
                {
                    if( amount?.GetFunding() == Funding
                        && amount?.GetName()?.Equals( Name ) == true )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Amount.Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary> Determines whether the specified primary is equal. </summary>
        /// <param name = "first" > The primary. </param>
        /// <param name = "second" > The secondary. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified primary is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsEqual( IAmount first, IAmount second )
        {
            if( first != null
                && first != Amount.Default
                && first != null
                && second != Amount.Default )
            {
                try
                {
                    if( first?.GetFunding().Equals( second?.GetFunding() ) == true
                        && first?.GetName()?.Equals( second?.GetName() ) == true )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Amount.Fail( ex );
                    return false;
                }
            }

            return false;
        }

        // **************************************************************************************************************************
        // ********************************************      EVENTS     *************************************************************
        // **************************************************************************************************************************

        /// <summary> Called when [changed]. </summary>
        /// <param name = "sender" > The sender. </param>
        /// <param name = "e" >
        /// The
        /// <see cref = "EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnChanged( object sender, EventArgs e )
        {
            try
            {
                using var msg = new Message( "Not Yet Implemented" );
            }
            catch( Exception ex )
            {
                Amount.Fail( ex );
            }
        }
    }
}