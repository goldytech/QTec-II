namespace QTec.Core.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeLanguages
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public virtual Employee Employee
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the language id.
        /// </summary>
        [ForeignKey("Language")]
        public int LanguageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public virtual Language Language
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fluency.
        /// </summary>
        public int Fluency
        {
            get;
            set;
        }
    }
}