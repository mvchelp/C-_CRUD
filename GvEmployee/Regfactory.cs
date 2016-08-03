using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Gridview.GvEmployee
{
    public class Regfactory
    {
        public DataTable GetStudentRegData()
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "Select * from tblRegistration ";
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

        public object SaveStudentForm (StudentReg objrg)
        {
            int result = 0;
            try
            {
                string insert = "insert into tblRegistration (FirstName,LastName,Gender,Language,EmailId) values ('" + objrg.FirstName + "','" + objrg.LastName + "','" + objrg.Gender + "','" + objrg.Language + "','" + objrg.EmailId + "')";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(insert,con);
                    cmd.CommandType = CommandType.Text;
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
    }
}