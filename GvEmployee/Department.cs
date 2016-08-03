using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Gridview.GvEmployee
{
    public class Department
    {
        private int _DepID;
        private string _DepartmentName;

        public int DepID
        {
            get { return _DepID; }
            set { _DepID = value; }
        }
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        public object SaveDepartment(Department objdepart)
        {
            object result = 0;
            try
            {
                string insert = "insert into tblDepartment(DepartmentName) values ('" + objdepart.DepartmentName + "')";
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
            catch(Exception ex)
            {
                // result = ex.Message;
            }
            return result;
        }

        public object UpdateDepartment(Department objdepart)
        {
            object result = 0;
            try
            {
                string update = "UPDATE [tblDepartment] SET [DepartmentName] = '" + objdepart.DepartmentName + "'  WHERE  DepID= '" + objdepart.DepID + "'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = update;
                    result = cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            return result;
        }
        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "SELECT DepID  ,DepartmentName   FROM tblDepartment";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Get;
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

        public object DeleteDepartMent(int depatId)
        {
            object result = 0;
            try
            {
                string Delete = "delete from tblDepartment where DepID='" + depatId + "'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Delete;
                    result = cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            return result;
        }

        public DataTable GetDepartmentByID(int depatId)
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "SELECT DepID  ,DepartmentName   FROM tblDepartment where DepID='" + depatId + "'";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Get;
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