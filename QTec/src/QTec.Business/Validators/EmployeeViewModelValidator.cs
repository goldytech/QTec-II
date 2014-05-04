// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeViewModelValidator.cs" company="">
//   
// </copyright>
// <summary>
//   The employee view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business.Validators
{
    using System;
    using System.Runtime.Remoting;

    using FluentValidation;

    using QTec.Business.ViewModels;
    using QTec.Core.Resources;

    /// <summary>
    /// The employee view model validator.
    /// </summary>
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
   {
       #region Declarations
       /// <summary>
       /// The employee manager.
       /// </summary>
       private readonly IEmployeeManager employeeManager; 
       #endregion

       #region Constructor
       /// <summary>
       /// Initializes a new instance of the <see cref="EmployeeViewModelValidator"/> class.
       /// </summary>
       /// <param name="employeeManager">
       /// The employee Manager.
       /// </param>
       public EmployeeViewModelValidator(IEmployeeManager employeeManager)
       {
           this.employeeManager = employeeManager;
           RuleFor(e => e.FirstName).NotEmpty().WithLocalizedMessage(() => ErrorMessages.FirstNameRequired).Length(5, 10).WithLocalizedMessage(() => ErrorMessages.FirstNameRequired);
           RuleFor(e => e.LastName).NotEmpty().WithLocalizedMessage(() => ErrorMessages.LastNameRequired);
           RuleFor(e => e.DateOfBirth).LessThan(DateTime.Today).WithLocalizedMessage(() => ErrorMessages.DateOfBirthLessThanCurrentDate).When(e => e.DateOfBirth != DateTime.MinValue);
            RuleFor(e => e.Email).EmailAddress().WithLocalizedMessage(() => ErrorMessages.InvalidEmail).When(e => !string.IsNullOrEmpty(e.Email)).Must(email => !this.employeeManager.IsEmailUnique(email)).WithLocalizedMessage(() => ErrorMessages.EmailAlreadyExists);
           RuleFor(e => e.Salary).NotEmpty().Must(salary => salary > 0).WithLocalizedMessage(() => ErrorMessages.ZeroSalary);
          RuleFor(e => e.DesignationId).NotEmpty().WithLocalizedMessage(() => ErrorMessages.DesignationRequired);
       } 
       #endregion
   }
}
