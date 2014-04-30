// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeManager.cs" company="">
//   
// </copyright>
// <summary>
//   The EmployeeManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QTec.Core.Model;

    /// <summary>
    /// The EmployeeManager interface.
    /// </summary>
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> GetEmployees();
       
        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        void AddEmployee(Employee employee);
    }
}
