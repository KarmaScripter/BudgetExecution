﻿// <copyright file = "Supplementals.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Budget authority provided in an appropriations act in addition to regular or
    /// continuing appropriations already provided. Supplementals appropriations
    /// generally are made to cover emergencies, such as disaster relief, or other
    /// needs deemed too urgent to be postponed until the enactment of next year's
    /// regular appropriations act.
    /// </summary>
    /// <seealso cref = "ProgramResultsCode"/>
    /// <seealso cref = "IProgram"/>
    /// <seealso cref = "ISupplemental"/>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "ConvertToConstant.Global" )]
    public abstract class Supplemental : ProgramResultsCode
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public override Source Source { get; set; } = Source.StatusOfSupplementalFuning;

        /// <summary>
        /// Gets or sets the ProgramResultCodes identifier.
        /// </summary>
        /// <value>
        /// The ProgramResultCodes identifier.
        /// </value>
        public IKey Index { get; set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public IElement Type { get; set; }

        /// <summary>
        /// Gets or sets the boc.
        /// </summary>
        /// <value>
        /// The boc.
        /// </value>
        public IElement BOC { get; set; }

        /// <summary>
        /// Gets the Data builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Verify.IsMap( Data )
                    ? new Builder( Source, Data )
                    : default( Builder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBuilder );
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetName()
        {
            try
            {
                return Enum.IsDefined( typeof( AwardType ), Type )
                    ? new Element( Record, Field.Type )
                    : default( Element );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }
    }
}
