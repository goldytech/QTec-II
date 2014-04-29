// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The EmployeeRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Core.Contracts
{
    using QTec.Core.Model;

    /// <summary>
    /// The EmployeeRepository interface.
    /// </summary>
    public interface IEmployeeRepository : IDataRepository<Employee, int>
    {
    }
}
