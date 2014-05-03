namespace QTec.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QTec.Business.ViewModels;
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
        /// The q tec unit of work.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
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
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public  bool IsEmailUnique(string email)
        {
            return this.CheckEmail(email).Result;
        }

        private async Task<bool> CheckEmail(string email)
        {
            return await this.qTecUnitOfWork.EmployeeRepository.IsEmailUnique(email);
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
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var employees = await this.qTecUnitOfWork.EmployeeRepository.RetrieveAllRecordsAsync();
            var employeesViewModel = AutoMapper.Mapper.Map<IEnumerable<Employee>, List<EmployeeViewModel>>(employees);
            return employeesViewModel;
        }
    }
}