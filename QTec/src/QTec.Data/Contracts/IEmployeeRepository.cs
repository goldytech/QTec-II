// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The EmployeeRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Data.Contracts
{
    using System.Threading.Tasks;

    using QTec.Core.Model;

    /// <summary>
    /// The EmployeeRepository interface.
    /// </summary>
    public interface IEmployeeRepository : IDataRepository<Employee, int>
    {
        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsEmailUnique(string email);
    }
}
