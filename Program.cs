// <copyright file = "Program.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [ STAThread ]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
            System.Windows.Forms.Application.Run( new BadgerMain() );
        }
    }
}
