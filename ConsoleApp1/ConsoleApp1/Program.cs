using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // connect();
            connect1();
        }


        static void connect()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Acts2023; Integrated Security = True;";
                   try
            {
                cn.Open();
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

        }

        static void connect1()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Acts2023; Integrated Security = True;";
                try
                {
                    cn.Open();
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }


        public class Employee
        {
            public int EmpNo { get; set; }

            public string Name { get; set; }

            public decimal Basic { get; set; }

            public int DeptNo { get; set; }
        }
    }

    }


