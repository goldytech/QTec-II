namespace QTec.Business
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Microsoft.Practices.ServiceLocation;

    using QTec.Business.Validators;
    using QTec.Business.ViewModels;
    using QTec.Core.Model;
    using QTec.Data;

    /// <summary>
    /// The employee manager.
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        /// <summary>
        /// The QTec unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qTecUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        /// </summary>
        /// <param name="qTecUnitOfWork">
        /// The q tec unit of work.
        /// </param>
        /// <exception cref="ArgumentNullException">ArgumentNullException
        /// </exception>
        public EmployeeManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            if (qTecUnitOfWork == null)
            {
                throw new ArgumentNullException("qTecUnitOfWork");
            }

            this.qTecUnitOfWork = qTecUnitOfWork;

        }

        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="employeeViewModel">
        /// The employee.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<QTecResponse<bool>> SaveEmployee(EmployeeViewModel employeeViewModel)
        {
            return Task.Run(async () =>
                    {
                        var exceptions = new Dictionary<string, string>();
                        var response = new QTecResponse<bool>();
                        try
                        {
                            var validator = new EmployeeViewModelValidator(ServiceLocator.Current.GetInstance<IEmployeeManager>());
                            var result = validator.Validate(employeeViewModel);
                            if (result.IsValid)
                            {
                                var employee = AutoMapper.Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                                if (employeeViewModel.EmployeeId > 0)
                                {
                                    await this.qTecUnitOfWork.EmployeeRepository.Update(employee);
                                }
                                else
                                {
                                    await this.qTecUnitOfWork.EmployeeRepository.Insert(employee);     
                                }
                               
                               var recordsAffected = await this.qTecUnitOfWork.SaveChangesAsync();
                                if (recordsAffected > 0)
                                {
                                    response.Response = true;
                                    response.Exceptions = exceptions;    
                                }
                            }
                            else
                            {
                                response.Response = false;
                                foreach (var validationError in result.Errors)
                                {
                                    exceptions.Add(validationError.PropertyName, validationError.ErrorMessage);
                                }
                            }
                        }
                        catch (SqlException sqlException)
                        {
                            exceptions.Add("SqlException", sqlException.Message);
                            response.Response = false;
                        }

                        response.Exceptions = exceptions;
                        return response;
                    });
        }

        /// <summary>
        /// Check whether email unique.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public bool IsEmailUnique(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            return this.qTecUnitOfWork.EmployeeRepository.IsEmailUnique(email);
        }

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<QTecResponse<EmployeeViewModel>> GetEmployee(int id)
        {
            return Task.Run(
                async () =>
                {
                    var exceptions = new Dictionary<string, string>();
                    try
                    {
                        var employee = await this.qTecUnitOfWork.EmployeeRepository.GetByIdAsync(id);
                        var employeeViewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employee);
                        return new QTecResponse<EmployeeViewModel> { Exceptions = exceptions, Response = employeeViewModel };
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add("Exception", exception.Message);
                        return new QTecResponse<EmployeeViewModel> { Exceptions = exceptions, Response = null };
                    }
                });
        }

       /// <summary>
        /// The get employees.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<QTecResponse<IEnumerable<EmployeeViewModel>>> GetEmployees()
        {
            var exceptions = new Dictionary<string, string>();
            IEnumerable<EmployeeViewModel> employeesViewModel = null;
            try
            {
                var employees = await this.qTecUnitOfWork.EmployeeRepository.RetrieveAllRecordsAsync();
                if (employees != null)
                {
                    employeesViewModel = AutoMapper.Mapper.Map<IEnumerable<Employee>, List<EmployeeViewModel>>(employees);
                }
            }
            catch (SqlException sqlException)
            {
                exceptions.Add("SqlException", sqlException.Message);
            }
            catch (TaskCanceledException taskCanceledException)
            {
                exceptions.Add("TaskCanceledException", taskCanceledException.Message);
            }

            // TODO catch your custom business exceptions
            return new QTecResponse<IEnumerable<EmployeeViewModel>>
            {
                Response = employeesViewModel,
                Exceptions = exceptions
            };
        }
    }
}