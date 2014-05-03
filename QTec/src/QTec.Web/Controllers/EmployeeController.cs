namespace QTec.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using FluentValidation.Results;

    using QTec.Business;
    using QTec.Business.Validators;
    using QTec.Business.ViewModels;

    public class EmployeeController : Controller
    {
        /// <summary>
        /// The employee manager.
        /// </summary>
        private readonly IEmployeeManager employeeManager;

        /// <summary>
        /// The designation manager.
        /// </summary>
        private readonly IDesignationManager designationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeManager">
        /// The employee manager.
        /// </param>
        /// <param name="designationManager">
        /// The designation manager.
        /// </param>
        public EmployeeController(IEmployeeManager employeeManager, IDesignationManager designationManager)
        {
            this.employeeManager = employeeManager;
            this.designationManager = designationManager;
        }

        //
        // GET: /Employee/
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public async Task<ViewResult> Index()
        {
            var employees = await this.employeeManager.GetEmployees();
            return this.View(employees.ToList());
        }

        //
        // GET: /Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create
        public async Task<ViewResult> Create()
        {
            var designations = await this.designationManager.GetDesignations();
            ViewBag.DesignationId = new SelectList(designations, "Id", "Name");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,FirstName,LastName,DesignationId,DateOfBirth,Salary,Email,Gender")] EmployeeViewModel employee)
        {
            EmployeeViewModelValidator validator = new EmployeeViewModelValidator();
            ValidationResult result = validator.Validate(employee);
            if (result.IsValid)
            {
                //ViewBag.ProductName = model.ProductName;
                //ViewBag.ProductManufacturer = model.ProductManufacturer;

            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            //if (ModelState.IsValid)
            //{
            //    //db.Employees.Add(employee);
            //    //await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            var designations = await this.designationManager.GetDesignations();
           ViewBag.DesignationId = new SelectList(designations.ToList(), "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
