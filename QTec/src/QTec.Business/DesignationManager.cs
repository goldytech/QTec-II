// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesignationManager.cs" company="">
//   
// </copyright>
// <summary>
//   The designation manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using QTec.Business;
using QTec.Data;

namespace QTec.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QTec.Core.Model;
    using QTec.Data;

    /// <summary>
    /// The designation manager.
    /// </summary>
    public class DesignationManager : IDesignationManager
    {
        /// <summary>
        /// The qtec unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qTecUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignationManager"/> class.
        /// </summary>
        /// <param name="qTecUnitOfWork">
        /// The q tec unit of work.
        /// </param>
        public DesignationManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            this.qTecUnitOfWork = qTecUnitOfWork;
        }

        /// <summary>
        /// The get designations.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            var designations = await this.qTecUnitOfWork.DesignationRepository.RetrieveAllRecordsAsync();
            return designations ?? null;
        }
    }
}