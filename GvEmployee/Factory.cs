using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Gridview.GvEmployee
{
    public class Factory
    {
        public object SaveStudent(Student objst)
        {
            int result = 0;
            try
            {
                string insert = "insert into tblStudent (FirstName,LastName,Rollno,Branch,EmailId,Address) values ('" + objst.FirstName + "','" + objst.LastName + "','" + objst.RollNo + "','" + objst.Branch + "','" + objst.EmailId + "','" + objst.Address + "')";
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
                // result = ex.Message;
            }
            return result;
        }

        public DataTable GetStudent()
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "SELECT * FROM tblStudent";
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

        public object DeleteStudent(int StdId)
        {
            object result = 0;
            try
            {
                string delete = "delete from tblStudent where StudentId = '" + StdId + "'";
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

        public object UpdateStudent(Student std)
        {
            object result = 0;
            try
            {
                string Update = "Update tblStudent set FirstName ='" + std.FirstName + "', LastName = '" + std.LastName + "', Rollno = '" + std.RollNo + "', Branch = '" + std.Branch + "', EmailId = '" + std.EmailId + "', Address = '" + std.Address + "' where StudentId = '" + std.StudentId + "'";
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

        public DataTable GetStudentById(int stdId)
        {
            DataTable dt = new DataTable();
            object result = 0;
            try
            {
                string get = "select * from tblStudent where StudentId = '" + stdId + "'";
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