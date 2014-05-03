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

        public Task<Employee> GetByIdAsync(int id)
        {

            return Task.Run(
                async () =>

                    {
                        Employee employee = await this.dataContext.Employees.SingleOrDefaultAsync(e => e.EmployeeId.Equals(id));
                        return employee;
                    });

        }

        public Task<IEnumerable<Employee>> RetrieveAllRecordsAsync()
        {
            return Task.Run(async () =>
                {
                    IEnumerable<Employee> employees = await this.dataContext.Employees.OrderBy(e => e.FirstName).ToListAsync();

                    return employees;
                });
        }

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
                        this.dataContext.Employees.Attach(entity);
                        this.dataContext.Entry(entity).State = EntityState.Modified;
                    });
        }

        public Task Delete(Employee entity)
        {
            return Task.Run(
                () => { this.dataContext.Employees.Remove(entity); });
        }

        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public Task<bool> IsEmailUnique(string email)
        {
            return Task.Run(async () =>
                    {
                        var isemailExists = await this.dataContext.Employees.AnyAsync(e => e.Email.Equals(email));
                        return isemailExists;
                    });
        }
    }
}
