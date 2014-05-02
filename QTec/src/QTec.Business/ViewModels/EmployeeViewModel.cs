namespace QTec.Business.ViewModels
{
    using System;

    /// <summary>
    /// The employee view model.
    /// </summary>
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
    }
}
