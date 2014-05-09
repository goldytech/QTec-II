// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The employee repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using QTec.Core.Model;
    using QTec.Data.Contracts;

    /// <summary>
    /// The employee repository.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly QTecDataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        public EmployeeRepository(QTecDataContext dataContext)
        {
            this.dataContext = dataContext;
           
        }

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<Employee> GetByIdAsync(int id)
        {

            return Task.Run(
                async () =>

                    {
                        Employee employee = await this.dataContext.Employees.SingleOrDefaultAsync(e => e.EmployeeId.Equals(id));
                        return employee;
                    });

        }

        /// <summary>
        /// The retrieve all records async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IEnumerable<Employee>> RetrieveAllRecordsAsync()
        {
            return Task.Run(async () =>
                {
                    IEnumerable<Employee> employees = await this.dataContext.Employees.OrderBy(e => e.FirstName).ToListAsync();

                    return employees;
                });
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Insert(Employee entity)
        {
            return Task.Run(
                () => { this.dataContext.Employees.Add(entity); });
        }

        public Task Update(Employee entity)
        {
            return Task.Run(
                () =>
                    {
                        var orignial = this.dataContext.Employees.FirstOrDefault(e => e.EmployeeId.Equals(entity.EmployeeId));
                        if (orignial != null)
                        {
                            this.dataContext.Entry(orignial).CurrentValues.SetValues(entity);
                        }

                        //this.dataContext.Entry(entity).State = EntityState.Modified;
                    });
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Delete(int id)
        {
            return Task.Run(async () =>
                    {
                       var employeetobeDeleted = await this.dataContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId.Equals(id));
                        this.dataContext.Employees.Remove(employeetobeDeleted);
                    });
        }

        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public bool IsEmailUnique(string email)
        {
            var isemailExists = this.dataContext.Employees.Any(e => e.Email.Equals(email));
            return isemailExists;
        }
    }
}
