using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gridview.GvEmployee
{
    public class NewEmployeeMeth
    {
        public DataTable GetNewEmployee()
        {
            DataTable dt = new DataTable();
            try
            {
                string Get = "SELECT * FROM tblNewEmployee";
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
    }
}