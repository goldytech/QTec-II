#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesignationManager.cs" company="">
//   
// </copyright>
// <summary>
//   The designation manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#endregion
namespace QTec.Business
{
    #region Usings
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QTec.Core.Model;
    using QTec.Data; 
    #endregion

    /// <summary>
    /// The designation manager.
    /// </summary>
    public class DesignationManager : IDesignationManager
    {
        #region Declarations
        /// <summary>
        /// The QTec unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qtecunitofWork; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignationManager"/> class.
        /// </summary>
        /// <param name="qtecunitofWork">
        /// The QTec unit of work.
        /// </param>
        public DesignationManager(IQTecUnitOfWork qtecunitofWork)
        {
            this.qtecunitofWork = qtecunitofWork;
        } 
        #endregion

        #region IDesignationManager Implementation

        /// <summary>
        /// The get designations.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
       public async Task<IEnumerable<Designation>> GetDesignations()
        {
            var designations = await this.qtecunitofWork.DesignationRepository.RetrieveAllRecordsAsync();
            return designations ?? null;
        } 
        #endregion
    }
}