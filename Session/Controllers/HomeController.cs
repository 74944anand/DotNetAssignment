using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            Employee e = new Employee { ID = 10, Name = "Govind" };
            string jsonEmp=JsonSerializer.Serialize<Employee>(e);
            HttpContext.Session.SetString("emp", jsonEmp);
            //HttpContext.Session.SetString("emp", JsonSerializer.Serialize<Employee>(e));
            HttpContext.Session.SetString("a", "Hello");
            HttpContext.Session.SetInt32("b", 10);
            return View();

        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            string e = HttpContext.Session.GetString("emp");
            Employee emp = JsonSerializer.Deserialize<Employee>(e);

            ViewBag.name = emp.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
