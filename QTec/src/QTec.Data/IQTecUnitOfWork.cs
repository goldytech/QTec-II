namespace QTec.Data
{
    using System.Threading.Tasks;

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
        /// Gets the designation repository.
        /// </summary>
        IDesignationRepository DesignationRepository { get; }
        
        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}
