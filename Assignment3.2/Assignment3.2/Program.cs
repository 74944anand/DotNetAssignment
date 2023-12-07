using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Number of Employee to be Stored");
            int empCount = Convert.ToInt32(Console.ReadLine());
            Employee [] e = new Employee[empCount];

            for (int i=0;i<empCount; i++) {
                Console.WriteLine("Enter Name of Employee");
                string name=Console.ReadLine();
                Console.WriteLine("Enter Salary of Employee");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                e[i]=new Employee(name, salary);
            }


            Employee e1= new Employee();
           
            e1.DisplayEmployeeWithHighSalary(empCount, e);
            Console.WriteLine("Enter Employee No");
            int empNo = Convert.ToInt32(Console.ReadLine());
            e1.showEmployeeDetails(empNo,e);    


        }
    }
    public class Employee
    {
        public static int Id = 0;
        private int EmpNo;
        private string name;
        string Name
        {
            set { name = value; }
            get { return name; }
        }
        private decimal BasicSalary ;

        decimal basic_Salary
        {
            set { BasicSalary = value; }
            get { return BasicSalary; }
        }
        public Employee(string name, decimal basicSalary) {
            this.EmpNo = ++Id;
            this.Name = name;
            this.basic_Salary = basicSalary;
        }

        public Employee()
        {
        }

        public void DisplayEmployeeWithHighSalary(int count, Employee[] e)
        {
            decimal salary = 0;
                for(int i = 0; i < count; i++)
                {
                    if (salary == 0)
                    {
                        salary = e[i].basic_Salary;
                    }
                    else
                    {
                        if(salary< e[i].basic_Salary)
                        {
                            salary = e[i].basic_Salary;
                        }
                    }
                }
            Console.WriteLine("Highest Salary: " + salary);
        }

        public void showEmployeeDetails(int EmpNo, Employee[] e)
        {
            foreach (Employee item in e)
            {
                if (item.EmpNo == EmpNo)
                {
                    Console.WriteLine("Employee No: "+item.EmpNo+ " Name: "+item.Name+ " Salary: "+ item.basic_Salary);
                }
            }
        }

    }
}
