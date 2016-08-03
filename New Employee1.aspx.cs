using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gridview.GvEmployee;
using System.Data;

namespace Gridview
{
    public partial class New_Employee1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindNewEmployee();
            }
        }

        protected void bindNewEmployee()
        {
            NewEmployeeMeth obj= new NewEmployeeMeth();
            DataTable dt =obj.GetNewEmployee();
            gvNewEmployee.DataSource = dt;
            gvNewEmployee.DataBind();
        }
    }
}