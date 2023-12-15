using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace TinyWeb.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }





        public static List<Employee> GetEmployees() {
            List<Employee> list = new List<Employee>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acts2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employee";
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Employee { EmpNo = dr.GetInt32(0), Name = dr.GetString(1), Basic = dr.GetDecimal(2), DeptNo = dr.GetInt32(3) });
                }
                Console.WriteLine("Success");
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally { cn.Close(); }
            return list;
        }

        public static Employee GetEmployee(int empNo)
        {
            Employee emp = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acts2023;Integrated Security=True";
            
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employee where EmpNo=@empNo";
            cmd.Parameters.AddWithValue("EmpNo", empNo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp.EmpNo = dr.GetInt32(0);
                    emp.Name = dr.GetString(1);
                    emp.Basic = dr.GetDecimal(2);
                    emp.DeptNo = dr.GetInt32(3);
                }
                else
                {
                    emp = null;
                }
                Console.WriteLine("Success");
                dr.Close();
                cn.Close();
                return emp;

            }

        public static void Insert(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acts2023;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Employee values(@EmpNo, @Name, @Basic, @DeptNo)";

                cmd.Parameters.AddWithValue("EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("Name", emp.Name);
                cmd.Parameters.AddWithValue("Basic", emp.Basic);
                cmd.Parameters.AddWithValue("DeptNo", emp.DeptNo);
                cmd.ExecuteNonQuery();

            }
            catch(Exception)
            {
                throw;
            }
            finally { cn.Close(); }
        }


        public static void DeleteEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acts2023;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from Employee where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("EmpNo",id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally { cn.Close(); }
        }

        public static void UpdateEmployee(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acts2023;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update Employee set EmpNo=@EmpNo, Name=@Name, Basic=@Basic, DeptNo=@DeptNo  where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("Name", emp.Name);
                cmd.Parameters.AddWithValue("Basic", emp.Basic);
                cmd.Parameters.AddWithValue("DeptNo", emp.DeptNo);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally { cn.Close(); }
        }

    } } 

