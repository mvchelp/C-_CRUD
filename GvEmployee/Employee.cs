using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Gridview.GvEmployee
{
    public class Employee
    {
        private int _EmployeeId;
        private string _FirstName;
        private string _Lastname;
        private string _Gender;
        private string _City;
        private string _DepartmentName;
        private int _Salary;

        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
        
        public DataTable GetEmployee()
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "SELECT * FROM tbl_Employee";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Get, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter ad = new SqlDataAdapter(cmd); 
                    ad.Fill(dt);
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            finally
            {
                //  con.Close();
            }
            return dt;
        }

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

        public object DeleteEmployee(int EmpId)
        {
            object result = 0;
            try
            {
                string delete = "delete from tbl_Employee where EmployeeId = '" + EmpId + "'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = delete;
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

        public object UpdateEmployee(Employee objemp)
        {
            object result = 0;
            try
            {
                string Update = "Update tbl_Employee set FirstName ='"+objemp.FirstName+"', Lastname = '"+ objemp.Lastname +"', Gender = '"+ objemp.Gender +"', City = '"+ objemp.City +"', DepartmentName = '"+ objemp.DepartmentName +"', Salary = '"+ objemp.Salary +"' where EmployeeId = '"+objemp.EmployeeId+"'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Update;
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

        public DataTable GetEmployeeById(int EmpId)
        {
            DataTable dt = new DataTable();
            object result = 0;
            try
            {
                string get = "select * from tbl_Employee where EmployeeId = '" + EmpId + "'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = get;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            finally
            {
                //  con.Close();
            }
            return dt;
        }
    }
}