using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class gvpaging1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initControl();
        }

        protected void initControl()
        {
            int i = GetTotalCount();
            GetGvEmployee1(0, 10);
        }

        protected void gvEmployee1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee1.PageIndex = e.NewPageIndex;
            GetGvEmployee1(e.NewPageIndex, 3);
        }

        protected int GetTotalCount()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("spGetTotalCount", "Data Source=RAHULRAVAL-PC;Initial Catalog=Employee;Integrated Security=True");
            da.Fill(dt);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }

        public void GetGvEmployee1(int current, int pagesize)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("spGetRecords1", "Data Source=RAHULRAVAL-PC;Initial Catalog=Employee;Integrated Security=True");
            da.SelectCommand.Parameters.AddWithValue("@PageSize", pagesize);
            da.SelectCommand.Parameters.AddWithValue("@PageIndex", current);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            gvEmployee1.DataSource = dt;
            gvEmployee1.DataBind();
        }
    }
}