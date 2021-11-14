﻿// <copyright file = "Info.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary>
    /// 
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Info" />
        /// class.
        /// </summary>
        public Info()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Info" />
        /// class.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="body">The body.</param>
        /// <param name="footer">The footer.</param>
        public Info( string header, string body, string footer )
        {
            Header = ControlConfig.GetText( header );
            Body = ControlConfig.GetText( body );
            Footer = ControlConfig.GetText( footer );
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the footer.
        /// </summary>
        /// <value>
        /// The footer.
        /// </value>
        public string Footer { get; set; }
    }
}