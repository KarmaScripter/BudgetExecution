// <copyright file = "HumanResourceData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="EmploymentBase" />
    /// <seealso cref="IHumanResourceData" />
    /// <seealso cref="ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class HumanResourceData : EmploymentBase, IHumanResourceData, ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        private static readonly Source _source = Source.WorkforceData;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        public HumanResourceData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public HumanResourceData( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.WorkforceDataId );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            Status = new Element( Record, Field.Status );
            JobTitle = new Element( Record, Field.JobTitle );
            OccupationalSeries = new Element( Record, Field.OccupationalSeries );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            Grade = new Element( Record, Field.Grade );
            Step = new Element( Record, Field.Step );
            AppointmentAuthority = new Element( Record, Field.AppointmentAuthority );
            AppointmentType = new Element( Record, Field.AppointmentType );
            BargainingUnit = new Element( Record, Field.BargainingUnit );
            RetirementPlan = new Element( Record, Field.RetirementPlan );
            HireDate = new Time( Record, EventDate.HireDate );
            ServiceDate = new Time( Record, EventDate.ServiceDate );
            WigiDueDate = new Time( Record, EventDate.WigiDueDate );
            GradeEntryDate = new Time( Record, EventDate.GradeEntryDate );
            StepEntryDate = new Time( Record, EventDate.StepEntryDate );
            CompensationRate = new Amount( Record, Numeric.CompensationRate );
            Args = Record.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public HumanResourceData( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.WorkforceDataId );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            Status = new Element( Record, Field.Status );
            JobTitle = new Element( Record, Field.JobTitle );
            OccupationalSeries = new Element( Record, Field.OccupationalSeries );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            Grade = new Element( Record, Field.Grade );
            Step = new Element( Record, Field.Step );
            AppointmentAuthority = new Element( Record, Field.AppointmentAuthority );
            AppointmentType = new Element( Record, Field.AppointmentType );
            BargainingUnit = new Element( Record, Field.BargainingUnit );
            RetirementPlan = new Element( Record, Field.RetirementPlan );
            HireDate = new Time( Record, EventDate.HireDate );
            ServiceDate = new Time( Record, EventDate.ServiceDate );
            WigiDueDate = new Time( Record, EventDate.WigiDueDate );
            GradeEntryDate = new Time( Record, EventDate.GradeEntryDate );
            StepEntryDate = new Time( Record, EventDate.StepEntryDate );
            CompensationRate = new Amount( Record, Numeric.CompensationRate );
            Args = Record.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public HumanResourceData( DataRow data )
            : this()
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.WorkforceDataId );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            Status = new Element( Record, Field.Status );
            JobTitle = new Element( Record, Field.JobTitle );
            OccupationalSeries = new Element( Record, Field.OccupationalSeries );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            Grade = new Element( Record, Field.Grade );
            Step = new Element( Record, Field.Step );
            AppointmentAuthority = new Element( Record, Field.AppointmentAuthority );
            AppointmentType = new Element( Record, Field.AppointmentType );
            BargainingUnit = new Element( Record, Field.BargainingUnit );
            RetirementPlan = new Element( Record, Field.RetirementPlan );
            HireDate = new Time( Record, EventDate.HireDate );
            ServiceDate = new Time( Record, EventDate.ServiceDate );
            WigiDueDate = new Time( Record, EventDate.WigiDueDate );
            GradeEntryDate = new Time( Record, EventDate.GradeEntryDate );
            StepEntryDate = new Time( Record, EventDate.StepEntryDate );
            CompensationRate = new Amount( Record, Numeric.CompensationRate );
            Args = Record.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Args { get; }

        /// <summary>
        /// Gets the workforce data identifier.
        /// </summary>
        /// <value>
        /// The workforce data identifier.
        /// </value>
        private IKey ID { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        private IElement Status { get; }

        /// <summary>
        /// Gets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        private IElement JobTitle { get; }

        /// <summary>
        /// Gets the occupational series.
        /// </summary>
        /// <value>
        /// The occupational series.
        /// </value>
        private IElement OccupationalSeries { get; }

        /// <summary>
        /// Gets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        private IElement Grade { get; }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        private IElement Step { get; }

        /// <summary>
        /// Gets the compensation rate.
        /// </summary>
        /// <value>
        /// The compensation rate.
        /// </value>
        private IAmount CompensationRate { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Element( FirstName )
                && Verify.Element( LastName ) )
            {
                try
                {
                    return FirstName.GetValue() + " " + LastName.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Args )
                    ? Args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the workforce data identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEmployee GetEmployee()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.EmployeeNumber}" ] = EmployeeNumber
                };

                var connection = new ConnectionBuilder( Source.Employees, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Employee( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Employee );
            }
        }

        /// <summary>
        /// Gets the human resource organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IHumanResourceOrganization GetHumanResourceOrganization()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.HumanResourceOrganizationCode}" ] = HumanResourceOrganizationCode
                };

                var connection = new ConnectionBuilder( Source.HumanResourceOrganizations, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new HumanResourceOrganization( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( HumanResourceOrganization );
            }
        }

        /// <summary>
        /// Gets the job title.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetJobTitle()
        {
            try
            {
                return Verify.Element( JobTitle )
                    ? JobTitle
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the occupational series.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetOccupationalSeries()
        {
            try
            {
                return Verify.Element( OccupationalSeries )
                    ? OccupationalSeries
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStatus()
        {
            try
            {
                return Verify.Element( Status )
                    ? Status
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the grade.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetGrade()
        {
            try
            {
                return Verify.Element( Grade )
                    ? Grade
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStep()
        {
            try
            {
                return Verify.Element( Step )
                    ? Step
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the compensation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetCompensation()
        {
            try
            {
                return CompensationRate.GetFunding() > -1.0
                    ? CompensationRate
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( HumanResourceData._source )
                    ? HumanResourceData._source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }
    }
}
