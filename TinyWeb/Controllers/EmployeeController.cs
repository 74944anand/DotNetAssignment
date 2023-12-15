using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyWeb.Models;



namespace TinyWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            emp = Employee.GetEmployees();
            return View(emp);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = Employee.GetEmployee(id);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                Employee.Insert(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee e=Employee.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employee e)
        {
            try
            {
                Employee.UpdateEmployee(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e = Employee.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                Employee.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
