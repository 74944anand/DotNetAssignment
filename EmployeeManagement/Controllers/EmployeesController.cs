using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesController/Details/5
        public ActionResult ViewAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            list=Employee.GetAllEmployees();
            return View(list);
        }

        // GET: EmployeesController/Create
        public ActionResult AddNewEmployee()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewEmployee(Employee e)
        {
            try
            {
                Employee.AddEmployee(e);

                return RedirectToAction(nameof(ViewAllEmployee));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee e = Employee.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee e)
        {
            try
            {
                Employee.SetEmployee(e, id);
                return RedirectToAction(nameof(ViewAllEmployee));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e=Employee.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                Employee.DeleteEmployee(id);
                return RedirectToAction(nameof(ViewAllEmployee));
            }
            catch
            {
                return View();
            }
        }
    }
}
