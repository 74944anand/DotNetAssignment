using Microsoft.Data.SqlClient;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public int DeptNo { get; set; } 




        public static List<Employee> GetAllEmployees()
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpMng;Integrated Security=True;";
            List<Employee> list = new List<Employee>();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Employee";

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Employee { Id=dr.GetInt32(0), Name=dr.GetString(1), City=dr.GetString(2), Address=dr.GetString(3), DeptNo=dr.GetInt32(4) });
                }


            }
            catch(Exception) 
            {

                throw;
            }
            finally { cn.Close(); }
            return list; 

        }

        public static Employee GetEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpMng;Integrated Security=True;";
            Employee emp= new Employee();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Employee where Id=@Id";

                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    emp.Id = dr.GetInt32(0);
                    emp.Name = dr.GetString(1);
                    emp.City = dr.GetString(2);
                    emp.Address = dr.GetString(3);
                    emp.DeptNo = dr.GetInt32(4);

                }


            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
            return emp;

        }
        public static void AddEmployee(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpMng;Integrated Security=True;";
            try
            {
                cn.Open ();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText = "insert into Employee values(@Id,@Name,@City,@Address,@DeptNo);";

                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
                    }
            finally {  cn.Close(); }

        }


        public static void SetEmployee(Employee emp,int id)
        {
            SqlConnection cn = new SqlConnection();    
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpMng;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Update Employee set Id=@Id,Name=@Name,City=@City,Address=@Address,DeptNo= @DeptNo where Id=@UId";


                cmd.Parameters.AddWithValue("@UId", id);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); ;
            }
            finally { cn.Close(); }

        }

        public static void DeleteEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpMng;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from employee where Id=@UId";

                cmd.Parameters.AddWithValue("@UId", id);

                cmd.ExecuteNonQuery();

                
            }
            catch (Exception)
            {
                throw;
            }
            finally { cn.Close(); }

        }
    }
}
