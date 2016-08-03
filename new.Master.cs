using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace Gridview
{
    public partial class _new : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Name"] = "Rahul";
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static int RefreshSession()
        {
            HttpContext.Current.Session["Name"] = "Rahul";
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            return timeout;
        }

        protected void ResetSession(object sender, EventArgs e)
        {
            string name = Session["Name"].ToString();
        }
    }
}