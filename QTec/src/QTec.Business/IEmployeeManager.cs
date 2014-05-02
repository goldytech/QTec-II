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

    using QTec.Business.ViewModels;
    using QTec.Core.Model;

    /// <summary>
    /// The EmployeeManager interface.
    /// </summary>
    public interface IEmployeeManager
    {
        /// <summary>
        /// The get employees.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<EmployeeViewModel>> GetEmployees();
       
        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        void AddEmployee(Employee employee);
    }
}
