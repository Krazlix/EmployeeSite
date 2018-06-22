using EmployeeSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.Data
{
    public class EmployeeManager
    {
        string connectionString = "Server=localhost; Database=project_intra; Trusted_Connection=True; MultipleActiveResultSets=true";
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Role", employee.Role);
                cmd.Parameters.AddWithValue("@Password", employee.Password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Employee checkEmployeeConnection(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Employee employeeConnect = new Employee();
                    while (reader.Read())
                    {
                        employeeConnect.Name = reader["Name"].ToString();
                    }
                    reader.Close();
                    return employeeConnect;
                }
                catch
                {

                }
                return (new Employee());
            }
        }
    }
    
}
