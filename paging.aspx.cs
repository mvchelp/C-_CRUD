using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class paging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gvBind();
            }
        }

        protected void gvBind()
        {
            DataTable dt = new DataTable();
            try
            {
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetJoinEmployee",con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}