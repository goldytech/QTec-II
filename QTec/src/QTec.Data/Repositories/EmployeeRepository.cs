namespace QTec.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using QTec.Core.Contracts;
    using QTec.Core.Model;

    /// <summary>
    /// The employee repository.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region IEmployeeRepository implementation
        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> RetrieveAllRecordsAsync()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Employee entity)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
