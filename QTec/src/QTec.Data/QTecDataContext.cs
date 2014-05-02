// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QTecDataContext.cs" company="">
//   
// </copyright>
// <summary>
//   The QTec data context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Data
{
    using System.Data.Entity;

    using QTec.Core.Model;

    /// <summary>
    /// The QTec data context.
    /// </summary>
    public class QTecDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QTecDataContext"/> class.
        /// </summary>
        public QTecDataContext()
            : base("QTec")
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new QTecDbInitializer());
        }

        
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the designations.
        /// </summary>
        public DbSet<Designation> Designations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        public DbSet<Language> Languages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the employee languages.
        /// </summary>
        public DbSet<EmployeeLanguages> EmployeeLanguages
        {
            get;
            set;
        }
    }
}
