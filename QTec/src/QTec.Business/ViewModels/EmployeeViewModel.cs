// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The employee view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business.ViewModels
{
    using System;

    using QTec.Business.Validators;
    using QTec.Core.Model;

    /// <summary>
    /// The employee view model.
    /// </summary>
    //[FluentValidation.Attributes.Validator(typeof(EmployeeViewModelValidator))]
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId
        {
            get; 
            set;
        }
        
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

       /// <summary>
       /// Gets or sets the date of birth.
       /// </summary>
       public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public double Salary 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the designation id.
        /// </summary>
        public int DesignationId
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public Gender Gender
        {
            get; 
            set;
        }
    }
}
