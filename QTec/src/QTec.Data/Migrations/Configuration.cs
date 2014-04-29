namespace QTec.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using QTec.Core.Model;

    public sealed class Configuration : DbMigrationsConfiguration<QTec.Data.QTecDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(QTecDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Designations.Any())
            {
                AddDesignations(context);    
            }

            if (!context.Employees.Any())
            {
                AddEmployees(context);    
            }
            
        }

        /// <summary>
        /// The add designations.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        private static void AddDesignations(QTecDataContext dataContext)
        {
            dataContext.Designations.AddOrUpdate(new Designation { Id = 1, Name = "Software Engineer" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 2, Name = "Sr. Software Engineer" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 3, Name = "Software Trainee" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 4, Name = "Team Lead" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 5, Name = "Tech Lead" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 6, Name = "QA Engineer" });

        }

        /// <summary>
        /// The add employees.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        private static void AddEmployees(QTecDataContext dataContext)
        {
            dataContext.Employees.AddOrUpdate(
                new Employee
                    {
                        EmployeeId = 1,
                        DesignationId = 1,
                        Email = "shahrukh@gmail.com",
                        FirstName = "Shahrukh",
                        LastName = "Khan",
                        Gender = Gender.Female,
                        DateOfBirth = new DateTime(1976, 11, 1),
                        Salary = 12484
                    });
            dataContext.Employees.AddOrUpdate(
                new Employee
                    {
                        EmployeeId = 2,
                        DesignationId = 2,
                        Email = "salman@gmail.com",
                        FirstName = "Salman",
                        LastName = "Khan",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1986, 11, 21),
                        Salary = 48473
                    });

            dataContext.Employees.AddOrUpdate(
                new Employee
                    {
                        EmployeeId = 3,
                        DesignationId = 4,
                        Email = "aamir@gmail.com",
                        FirstName = "Aamir",
                        LastName = "Khan",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1977, 10, 8),
                        Salary = 36252
                    });

            dataContext.Employees.AddOrUpdate(
                new Employee
                    {
                        EmployeeId = 4,
                        DesignationId = 3,
                        Email = "saif@gmail.com",
                        FirstName = "Saif Ali",
                        LastName = "Khan",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1973, 1, 1),
                        Salary = 37262
                    });
        }
    }
}
