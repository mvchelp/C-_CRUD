using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeEntry.EmployeeClass
{
    public class EmployeeFactory
    {

        public object saveEmployee(Employee objemp)
        {
            object result = 0;
            try
            {
                string insert = "insert into tbl_Employee (FirstName,Lastname,Gender,City,DepartmentName,Salary) values ('" + objemp.FirstName + "','" + objemp.Lastname + "','" + objemp.Gender + "','" + objemp.City + "','" + objemp.DepartmentName + "','" + objemp.Salary + "')";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insert;
                    result = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("something wrong");
            }
            return result;
        }  
    }
}