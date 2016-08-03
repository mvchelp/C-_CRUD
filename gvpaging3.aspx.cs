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
    public partial class gvpaging3 : System.Web.UI.Page
    {
        protected int pageIndex = 0;
        protected int pageCount = 0;
        protected int rowCount = 0;
        private const int CONST_PAGE_SIZE = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                pageCount = CalcPageCount(rowCount);
                ViewState["PageCount"] = pageCount;
                ViewState["PageIndex"] = pageIndex;
                RefreshPageButtons();
                
            }
            else
            {
                if (ViewState["PageIndex"] != null)
                {
                    pageIndex = Convert.ToInt32(ViewState["PageIndex"]);
                }
                if (ViewState["PageCount"] != null)
                {
                    pageCount = Convert.ToInt32(ViewState["PageCount"]);
                }
            }
        }

        private int CalcPageCount(int totalRows)
        {
            return (int)(totalRows / CONST_PAGE_SIZE);
        }

        private void BindData()
        {
            DataSet dsProducts = RetrieveProducts();
            gvEmployee3.DataSource = dsProducts;
            gvEmployee3.DataBind();
        }

        private DataSet RetrieveProducts()
        {
            DataSet dsEmployee = new DataSet();
            using (SqlConnection conn = new SqlConnection("Data Source=RAHULRAVAL-PC;Initial Catalog=Employee;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("spGetRecords3", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", CONST_PAGE_SIZE);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int);
                    cmd.Parameters["@RecordCount"].Direction =
                    ParameterDirection.Output;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsEmployee);
                    rowCount = (int)cmd.Parameters["@RecordCount"].Value;
                }
            }
            lblPageCount.Text = "<i><b>" +"Displaying Page " + 1 + " of " + CONST_PAGE_SIZE + "<b></i>";
            return dsEmployee;
        }


        protected void PageChangeEventHandler(object sender, CommandEventArgs e)
        {
            switch (e.CommandArgument.ToString())
            {
                case "First":
                    pageIndex = 0;
                    break;
                case "Prev":
                    pageIndex = pageIndex - 1;
                    break;
                case "Next":
                    pageIndex = pageIndex + 1;
                    break;
                case "Last":
                    pageIndex = pageCount;
                    break;
            }
            ViewState["PageIndex"] = pageIndex;
            BindData();
            RefreshPageButtons();
            lblPageCount.Text = "<i><b>" + "Displaying Page " + ((int)ViewState["PageIndex"] + 1) + " of " + CONST_PAGE_SIZE + "<b><i>";
        }
        private void RefreshPageButtons()
        {
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            if (pageIndex == 0)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;             
                if (pageCount <= 0)
                    btnNext.Enabled = false;
            }
            else
            {
                if (pageIndex == pageCount)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
            }
        }
    }
}