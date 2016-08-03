using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gridview.gvpaging;
using System.Data;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class gvpaging4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalRows = 0;
                gvEmployee4.DataSource = EmployeeDataAccessLayer.GetEmployees(0, gvEmployee4.PageSize, gvEmployee4.Attributes["CurrentSortField"],gvEmployee4.Attributes["CurrentSortDirection"], out totalRows);
                gvEmployee4.DataBind();
                Databind_DDLPageNumbers(0, 3, totalRows);
                lblPageCount.Text = "<i><b>" + "Displaying Page " + 1 + " of " + gvEmployee4.PageSize + "<b><i>";
            }
        }

        private void Databind_DDLPageNumbers(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            if (totalPages > 1)
            {
                ddlPageNumbers.Enabled = true;
                ddlPageNumbers.Items.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    ddlPageNumbers.Items.Add(new
                        ListItem(i.ToString(), i.ToString()));
                }
            }
            else
            {
                ddlPageNumbers.SelectedIndex = 0;
                ddlPageNumbers.Enabled = false;
            }

            lblPageCount.Text = "<i><b>" + "Displaying Page " + (pageIndex + 1) + " of " + totalPages + "<b><i>";
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalRows = 0;

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            int pageIndex = 0;

            gvEmployee4.PageSize = pageSize;

            gvEmployee4.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, pageSize, gvEmployee4.Attributes["CurrentSortField"],gvEmployee4.Attributes["CurrentSortDirection"], out totalRows);
            gvEmployee4.DataBind();
            Databind_DDLPageNumbers(pageIndex, pageSize, totalRows);
        }

        protected void ddlPageNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalRows = 0;

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            int pageIndex = int.Parse(ddlPageNumbers.SelectedValue) - 1;

            gvEmployee4.PageSize = pageSize;

            gvEmployee4.DataSource = EmployeeDataAccessLayer.
            GetEmployees(pageIndex, pageSize, gvEmployee4.Attributes["CurrentSortField"],
                gvEmployee4.Attributes["CurrentSortDirection"], out totalRows);
            gvEmployee4.DataBind();
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            lblPageCount.Text = "<i><b>" + "Displaying Page " + (pageIndex + 1) + " of " + totalPages + "<b><i>";
        }

        private void SortGridview(GridView gridView, GridViewSortEventArgs e,
            out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] =
                    (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }

        protected void gvEmployee4_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview(gvEmployee4, e, out sortDirection, out sortField);
            string strSortDirection =
                sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            int totalRows = 0;
            gvEmployee4.DataSource = EmployeeDataAccessLayer.
                GetEmployees(gvEmployee4.PageIndex, gvEmployee4.PageSize,
                e.SortExpression, strSortDirection, out totalRows);
            gvEmployee4.DataBind();
            Databind_DDLPageNumbers(gvEmployee4.PageIndex, gvEmployee4.PageSize, totalRows);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeDataAccessLayer emp = new EmployeeDataAccessLayer();
            DataTable dt = new DataTable();
            dt = emp.GetSearchEmployee2(txtId.Text, txtFname.Text, txtLname.Text,txtGender.Text,txtCountry.Text, txtState.Text, txtCity.Text, txtLanguge.Text, txtEmail.Text);
            gvEmployee4.DataSource = dt;
            gvEmployee4.DataBind();
        }

    //    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        if (ddlSearchBy.SelectedItem.Text == "All")
    //        {
    //            txtSearch.Text = string.Empty;
    //            txtSearch.Enabled = false;
    //        }
    //        else
    //        {
    //            txtSearch.Enabled = true;
    //            txtSearch.Text = string.Empty;
    //            txtSearch.Focus();
    //        }
    //    }

    //    protected void btnSearch_Click(object sender, EventArgs e)
    //    {
    //        if (ddlSearchBy.SelectedItem.Text == "EmpId")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "FirstName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "LastName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "GenderName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "CountryName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "StateName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "CityName")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "Language")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //        else if (ddlSearchBy.SelectedItem.Text == "Email")
    //        {
    //            getEmpRecords(ddlSearchBy.SelectedItem.Text, txtSearch.Text.Trim());
    //        }
    //    }

    //    private void getEmpRecords(string searchBy, string searchVal)
    //    {
    //        EmployeeDataAccessLayer obj = new EmployeeDataAccessLayer();
    //        DataTable dt = new DataTable();
    //        dt = obj.GetSearchEmployee(searchBy, searchVal);
    //        gvEmployee4.DataSource = dt;
    //        gvEmployee4.DataBind();
    //    }
    }
}