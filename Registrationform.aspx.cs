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
    public partial class Registrationform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindStudentRegData();
        }

        protected void BindStudentRegData()
        {
            Regfactory obj = new Regfactory();
            DataTable dt = new DataTable();
            dt = obj.GetStudentRegData();
            gvStudentReg.DataSource = dt;
            gvStudentReg.DataBind();   
        }
    }
}