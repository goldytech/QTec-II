// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesignationRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The designation repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using QTec.Core.Model;
    using QTec.Data.Contracts;

    /// <summary>
    /// The designation repository.
    /// </summary>
    public class DesignationRepository : IDesignationRepository
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly QTecDataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignationRepository"/> class.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        public DesignationRepository(QTecDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<Designation> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The retrieve all records async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IEnumerable<Designation>> RetrieveAllRecordsAsync()
        {
            return Task.Run(async () =>
            {
                IEnumerable<Designation> designations = await this.dataContext.Designations.ToListAsync();

                return designations;
            });
        }

        public Task Insert(Designation entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Designation entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}