#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QTecUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The q tec unit of work.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#endregion

namespace QTec.Data
{
    using System;
    using System.Threading.Tasks;
    using QTec.Data.Contracts;
    using QTec.Data.Repositories;

    /// <summary>
    /// The QTec unit of work.
    /// </summary>
    public class QTecUnitOfWork : IQTecUnitOfWork, IDisposable
    {
        #region Declarations
        /// <summary>
        /// The data context.
        /// </summary>
        private QTecDataContext dataContext;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="QTecUnitOfWork"/> class.
        /// </summary>
        public QTecUnitOfWork()
        {
            this.dataContext = new QTecDataContext();
            this.disposed = false;
            this.EmployeeRepository = new EmployeeRepository(this.dataContext);
        } 
        #endregion

        #region IQTecUnitOfWork Implementation
        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        public IEmployeeRepository EmployeeRepository { get; private set; }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<int> SaveChangesAsync()
        {
            return Task.Run(
                async () =>
                {
                    var recordsAffected = await this.dataContext.SaveChangesAsync();
                    return recordsAffected;
                });
        }

        #endregion

        #region IDisposable Implementation

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}