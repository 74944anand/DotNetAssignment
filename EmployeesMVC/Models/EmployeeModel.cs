using Microsoft.VisualBasic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace EmployeesMVC.Models
{

    
    public class EmployeeModel
    {
        public static string url = "http://localhost:5195/api/";

        public string? EmployeeName { get; set; }

        public string? EmployeeCity { get; set; }

        public DateTime? EmployeeDob { get; set; }

        public string? EmployeeGender { get; set; }

        public decimal? EmployeeSalary { get; set; }


        public static IEnumerable<EmployeeModel> GetAll()
        {

            IEnumerable<EmployeeModel> emp = null;
            using (var client= new HttpClient())
            {
                
                client.BaseAddress = new Uri(url);

                var task= client.GetAsync("Employee");
                task.Wait();

                var result = task.Result;


                if (result.IsSuccessStatusCode)
                {
                
                    var readTask = result.Content.ReadAsAsync<IEnumerable<EmployeeModel>>();
                    readTask.Wait();
                    emp = readTask.Result;                
                }
                else
                {
                    Console.WriteLine("Data getting failed");
                }
                return emp;
            }
            

        }

        public static void Create(EmployeeModel employee)
        {

            using(var client= new HttpClient())
            {
                var content= JsonSerializer.Serialize<EmployeeModel>(employee);
                HttpContent cn = new StringContent(content, Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri(url);
                var Task = client.PostAsync("Employee", cn);
                Task.Wait();
                var result = Task.Result;


                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Error");
                }


            }


        }
    }
}
