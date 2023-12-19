using EmployeesMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/ShowEmployee
        public ActionResult ShowEmployee()
        {
          var emp= EmployeeModel.GetAll();
            return View(emp);
        }

        // GET: Home/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Home/AddEmployee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeModel emp)
        {
            try
            {
                EmployeeModel.Create(emp);

                return RedirectToAction(nameof(ShowEmployee));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
