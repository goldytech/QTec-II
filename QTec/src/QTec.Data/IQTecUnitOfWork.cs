using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTec.Data
{
    using QTec.Data.Contracts;

    /// <summary>
    /// The QTecUnitOfWork interface.
    /// </summary>
    public interface IQTecUnitOfWork
    {
        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        IEmployeeRepository EmployeeRepository { get; }

        /// <summary>
        /// The save changes async.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
