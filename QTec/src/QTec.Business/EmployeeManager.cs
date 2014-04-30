namespace QTec.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QTec.Core.Model;
    using QTec.Data;

    /// <summary>
    /// The employee manager.
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        /// <summary>
        /// The QTec unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qTecUnitOfWork;

       /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        /// </summary>
        /// <param name="qTecUnitOfWork">
        /// The QTec unit of work.
        /// </param>
        public EmployeeManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            if (qTecUnitOfWork == null)
            {
                throw new ArgumentNullException("qTecUnitOfWork");
            }

            this.qTecUnitOfWork = qTecUnitOfWork;
        }

       /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        public async void AddEmployee(Employee employee)
        {
           await this.qTecUnitOfWork.EmployeeRepository.Insert(employee);
        }

        /// <summary>
        /// The get employee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Employee"/>.
        /// </returns>
        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await this.qTecUnitOfWork.EmployeeRepository.GetByIdAsync(id);
            return employee;
        }

        /// <summary>
        /// The get employees.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await this.qTecUnitOfWork.EmployeeRepository.RetrieveAllRecordsAsync();
            return employees;
        }
    }
}