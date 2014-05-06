namespace QTec.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.Practices.ServiceLocation;

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
            var response = await this.employeeManager.GetEmployees();

            // no error occured
            if (!response.Exceptions.Any())
            {
                return response.Response != null ? this.View(response.Response.ToList()) : null;
            }

            foreach (var keyValuePair in response.Exceptions)
            {
                this.ModelState.AddModelError(keyValuePair.Key, new Exception(keyValuePair.Value)); 
            }

            return response.Response != null ? this.View(response.Response.ToList()) : null;
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

            var response = await this.employeeManager.SaveEmployee(employee);

            // no error occured
            if (!response.Exceptions.Any())
            {
              return this.RedirectToAction("Index");
            }
            else
            {
                
                foreach (var keyValuePair in response.Exceptions)
                {
                    this.ModelState.AddModelError(keyValuePair.Key, new Exception(keyValuePair.Value));
                }
            }

            var designations = await this.designationManager.GetDesignations();
           ViewBag.DesignationId = new SelectList(designations.ToList(), "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await this.employeeManager.GetEmployee(id.Value);
            if (response.Exceptions.Any())
            {
                return null; // TODO Goto error page
            }

            if (response.Response != null)
            {
                var designations = await this.designationManager.GetDesignations();
                ViewBag.DesignationId = new SelectList(designations, "Id", "Name", response.Response.DesignationId);
                return this.View(response.Response);
            }

            return this.HttpNotFound();
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include="EmployeeId,FirstName,LastName,DesignationId,DateOfBirth,Salary,Email,Gender")] EmployeeViewModel employeeViewModel)
        {
            
                 var response = await this.employeeManager.SaveEmployee(employeeViewModel);
                if (!response.Exceptions.Any())
                {
                    return RedirectToAction("Index");    
                }

            //TODO handle the error    
            var designations = await this.designationManager.GetDesignations();
            ViewBag.DesignationId = new SelectList(designations, "Id", "Name", employeeViewModel.DesignationId);
                return this.View(employeeViewModel);
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
