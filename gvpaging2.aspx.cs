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
    public partial class gvpaging2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid(1);
            }
        }

        public void bindGrid(int currentPage)
        {
            int pageSize = 3;
            int _TotalRowCount = 0;

            using (SqlConnection con = new SqlConnection("Data Source=RAHULRAVAL-PC;Initial Catalog=Employee;Integrated Security=True"))
            {

                SqlCommand cmd = new SqlCommand("spGetRecords2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                int startRowNumber = ((currentPage - 1) * pageSize) + 1;

                cmd.Parameters.AddWithValue("@StartIndex", startRowNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                SqlParameter parTotalCount = new SqlParameter("@TotalCount", SqlDbType.Int);
                parTotalCount.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parTotalCount);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                _TotalRowCount = Convert.ToInt32(parTotalCount.Value);

                gvCustomPaging2.DataSource = ds;
                gvCustomPaging2.DataBind();

                generatePager(_TotalRowCount, pageSize, currentPage);

            }
        }

        public void generatePager(int totalRowCount, int pageSize, int currentPage)
        {
            int totalLinkInPage = 2;
            int totalPageCount = (int)Math.Ceiling((decimal)totalRowCount / pageSize);

            int startPageLink = Math.Max(currentPage - (int)Math.Floor((decimal)totalLinkInPage / 2), 1);
            int lastPageLink = Math.Min(startPageLink + totalLinkInPage - 1, totalPageCount);

            if ((startPageLink + totalLinkInPage - 1) > totalPageCount)
            {
                lastPageLink = Math.Min(currentPage + (int)Math.Floor((decimal)totalLinkInPage / 2), totalPageCount);
                startPageLink = Math.Max(lastPageLink - totalLinkInPage + 1, 1);
            }

            List<ListItem> pageLinkContainer = new List<ListItem>();

            if (startPageLink != 1)
                pageLinkContainer.Add(new ListItem("First", "1", currentPage != 1));
            for (int i = startPageLink; i <= lastPageLink; i++)
            {
                pageLinkContainer.Add(new ListItem(i.ToString(), i.ToString(), currentPage != i));
            }
            if (lastPageLink != totalPageCount)
                pageLinkContainer.Add(new ListItem("Last", totalPageCount.ToString(), currentPage != totalPageCount));

            dlPagerx.DataSource = pageLinkContainer;
            dlPagerx.DataBind();
        }

        protected void dlPager_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "PageNo")
            {
                bindGrid(Convert.ToInt32(e.CommandArgument));
            }
        }
    }
}