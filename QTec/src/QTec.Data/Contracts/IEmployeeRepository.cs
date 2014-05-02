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
    using QTec.Core.Model;

    /// <summary>
    /// The EmployeeRepository interface.
    /// </summary>
    public interface IEmployeeRepository : IDataRepository<Employee, int>
    {
    }
}
