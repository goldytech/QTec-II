using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTec.Business
{
    using QTec.Core.Model;

    /// <summary>
    /// The Designation Manager interface.
    /// </summary>
    public interface IDesignationManager
    {
        /// <summary>
        /// The get designations.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<Designation>> GetDesignations(); 
    }
}
