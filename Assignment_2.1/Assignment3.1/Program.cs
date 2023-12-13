using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }



    interface IDbFunctions
    {
       void insert();
        void update();
        void delete();
    }

    public abstract class Employee
    {   
        private static int count_id=0;
        string name;
        int EmpNo;
        short DeptNo;
        public abstract decimal Basic
        {
           set; get;
        }

        private string Name
        {
            set
            {
                if(value != "")
                name = value;
                Console.WriteLine("Invalid Name");
            }
            get
            {
                return name;
            }
        }
        private int empNo
        {
            get
            {
                return EmpNo;
            }

        }
            short deptNo
        {
            set
            {
                if (value >0)
                    DeptNo = value;
                Console.WriteLine("Invalid Name");
            }
            get
            {
                return DeptNo;
            }

        }


        public Employee(string name1, int empNo, short deptNo1, decimal basic1)
        {
            Name = name1;
            EmpNo = ++count_id;
            deptNo = deptNo1;
            Basic = basic1;
        }

        public abstract decimal CalcNetSalary();


    }

    public class Manager:Employee, IDbFunctions
    {
       

        override
        public decimal Basic
        {
            set
            {
               Basic = value;   
            }
            get { return Basic; }
        }

        string Designation;

        public Manager(string name1, int empNo, short deptNo1, decimal basic1) : base(name1, empNo, deptNo1, basic1)
        {
        }

        string design
        {
            set {
                if (value != "")
                {
                    Designation = value;
                }
                else
                {
                    Console.WriteLine("Invalid Designation");
                }
            }
            get { return Designation; }
        }

       override
        public decimal CalcNetSalary()
        {
            decimal calcNetSalary = Basic * 2;
            return calcNetSalary;
        }

        public void insert()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }
    }

    public class GenralManger : Manager, IDbFunctions
    {
        string Perks;

        public GenralManger(string name1, int empNo, short deptNo1, decimal basic1) : base(name1, empNo, deptNo1, basic1)
        {
        }

        public string perks
        {
            get
            {
                return Perks;
            }
            set
            {
                Perks = value;
            }
        }
    }

    public class CEO:Employee, IDbFunctions
    {
        public CEO(string name1, int empNo, short deptNo1, decimal basic1) : base(name1, empNo, deptNo1, basic1)
        {
        }

        override
        public decimal Basic
        {
            set
            {
                Basic = value;
            }
            get { return Basic; }
        }

        override
        public sealed decimal CalcNetSalary()
        {
            decimal calcNetSalary = Basic * 4;
            return calcNetSalary;
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        public void insert()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
 }
    