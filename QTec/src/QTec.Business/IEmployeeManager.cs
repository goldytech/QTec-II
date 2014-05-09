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
        Task<QTecResponse<IEnumerable<EmployeeViewModel>>> GetEmployees();

        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="employeeViewModel">Employee ViewModel</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<QTecResponse<bool>> SaveEmployee(EmployeeViewModel employeeViewModel);

        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        bool IsEmailUnique(string email);

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<QTecResponse<EmployeeViewModel>> GetEmployee(int id);

        /// <summary>
        /// The delete employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<QTecResponse<bool>> DeleteEmployee(int id);
    }
}
