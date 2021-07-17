// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OfficeOpenXml;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Grid : ExcelCellBase, IGrid
    {
        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        public Grid()
        {
        }

        public Grid( ExcelWorksheet worksheet, ExcelRange range )
        {
            Worksheet = worksheet;
            Range = range;

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row,
                Range.End.Row );

            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        public Grid( ExcelWorksheet worksheet, ExcelAddress address )
        {
            Worksheet = worksheet;
            Address = address;
            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );

            Range = Worksheet.Cells[ From.Row, From.Column, To.Row,
                To.Column ];
        }

        public Grid( ExcelWorksheet worksheet, int fromrow = 1, int fromcolumn = 1,
                     int torow = 55, int tocolumn = 12 )
        {
            Worksheet = worksheet;

            Range = Worksheet.Cells[ fromrow, fromcolumn, torow,
                tocolumn ];

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row,
                Range.End.Row );

            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        public Grid( ExcelWorksheet worksheet, IReadOnlyList<int> cell )
        {
            Worksheet = worksheet;

            Range = Worksheet.Cells[ cell[ 0 ], cell[ 1 ], cell[ 2 ],
                cell[ 3 ] ];

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row,
                Range.End.Column );

            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        public Grid( ExcelWorksheet worksheet, (int Row, int Column) from,
                     (int Row, int Column) to )
        {
            Worksheet = worksheet;

            Range = Worksheet.Cells[ from.Row, from.Column, to.Row,
                to.Column ];

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row,
                Range.End.Row );

            From = from;
            To = to;
        }

        public Grid( ExcelWorksheet worksheet, (int Row, int Column) from )
        {
            Worksheet = worksheet;
            Range = Worksheet.Cells[ from.Row, from.Column ];

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.Start.Row,
                Range.Start.Column );

            From = from;
            To = From;
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        private protected ExcelRange Range { get; set; }

        private protected ExcelWorksheet Worksheet { get; set; }

        private protected ExcelAddress Address { get; set; }

        public (int Row, int Column) From { get; set; }

        public (int Row, int Column) To { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        public ExcelAddress GetAddress()
        {
            try
            {
                return Address.Columns > 0
                    ? Address
                    : default;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return default;
            }
        }

        public ExcelRange GetRange()
        {
            try
            {
                return Range.Columns > 0
                    ? Range
                    : default;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return default;
            }
        }

        public ExcelWorksheet GetWorksheet()
        {
            try
            {
                return Verify.Input( Worksheet.Name )
                    ? Worksheet
                    : default;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return default;
            }
        }

        public int CountCells( ExcelRange range )
        {
            try
            {
                return range != null
                    ? range.Rows * range.Columns
                    : default;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return -1;
            }
        }

        public int GetRowCount()
        {
            try
            {
                return Range.Rows > 0
                    ? Range.Rows
                    : 0;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return default;
            }
        }

        public int GetColumnCount()
        {
            try
            {
                return Range.Columns > 0
                    ? Range.Columns
                    : 0;
            }
            catch( Exception ex )
            {
                Grid.Fail( ex );
                return default;
            }
        }

        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}