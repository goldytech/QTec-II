// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The DataRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The DataRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    /// <typeparam name="TKey">
    /// </typeparam>
    public interface IDataRepository<TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Gets all records from the entity
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        Task<IEnumerable<TEntity>> RetrieveAllRecordsAsync();

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Insert(TEntity entity);

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Update(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Delete(TKey id);
    }
}
