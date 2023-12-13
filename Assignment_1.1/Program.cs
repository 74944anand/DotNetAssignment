using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Employee o1 = new Employee(1, "Amol", 123465, 10);
            Employee o2 = new Employee(1, "Amol", 123465);
            Employee o3 = new Employee(1, "Amol");
            Employee o4 = new Employee(1);
            Employee o5 = new Employee();
            Console.ReadLine();


        }
    }

    public class Employee
    {
        private int empNo;
        private string name;
        private decimal Basic;
        private short DeptNo;


        public Employee(int empNo, string name, decimal basic, short deptNo)
        {
            this.empNo = empNo;
            this.name = name;
            Basic = basic;
            DeptNo = deptNo;
        }
        public Employee(int empNo, string name, decimal basic)
        {
            this.empNo = empNo;
            this.name = name;
            Basic = basic;
            DeptNo = 10;
        }
        public Employee(int empNo, string name)
        {
            this.empNo = empNo;
            this.name = name;
            Basic = 123465;
            DeptNo = 10;
        }
        public Employee(int empNo)
        {
            this.empNo = empNo;
            this.name = "Amol";
            Basic = 123465;
            DeptNo = 10;
        }
        public Employee()
        {
            this.empNo = 1;
            this.name = "Amol";
            Basic = 123465;
            DeptNo = 10;
        }
        public int EmployeeNo
        {
            get { return empNo; }
            set {
                if(value < 0)
                {
                    empNo = value;
                }
                else
                {
                    Console.WriteLine("Invalid Employee No");
                }
            
            }   
        }
        public string name1
        {
            get { return name; }
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Invalid Name");
                }

            }
        }
        public decimal Basic1
        {
            get { return Basic; }
            set
            {
                if (value <10000 && value > 30000)
                {
                    Basic= value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Salary");
                }

            }
        }
        public short DeptNo1
        {
            get { return DeptNo; }
            set
            {
                if (value < 0)
                {
                    DeptNo = value;
                }
                else
                {
                    Console.WriteLine("Invalid Department No");
                }

            }
        }

        public decimal GetNetSalary()
        {
            return Basic * 2000;
        }
    }
}
