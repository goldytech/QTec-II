namespace QTec.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using QTec.Core.Contracts;
    using QTec.Core.Model;

    /// <summary>
    /// The employee repository.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region IEmployeeRepository implementation

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public  Task<Employee> GetByIdAsync(int id)
        {
            return Task.Run(async 
                () =>
                    {
                        Employee employee;
                        using (var db = new QTecDataContext())
                        {
                            employee = await db.Employees.SingleAsync(e=>e.EmployeeId.Equals(id));
                        }

                        return employee;
                    });
        }

        public Task<IEnumerable<Employee>> RetrieveAllRecordsAsync()
        {
            return Task.Run(async () =>
                    {
                        IEnumerable<Employee> employees;
                        using (var db =new QTecDataContext())
                        {
                            employees = await db.Employees.OrderBy(e=>e.FirstName).ToListAsync();
                        }
                        return employees;
                    });
        }

        public Task Insert(Employee entity)
        {
            return Task.Run(
                async () =>
                    {
                        using (var db = new QTecDataContext())
                        {
                            db.Employees.Add(entity);
                            await db.SaveChangesAsync();
                        }
                    });
        }

        public Task Update(Employee entity)
        {
            return Task.Run(
                () =>
                    {
                        using (var db = new QTecDataContext())
                        {
                            db.Entry(entity).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    });
        }

        public Task Delete(Employee entity)
        {
            return Task.Run(
                () =>
                    {
                        using (var db = new QTecDataContext())
                        {
                            db.Employees.Remove(entity);
                            db.SaveChanges();
                        }
                    });
        } 
        #endregion
    }
}
