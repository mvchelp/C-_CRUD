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
    public partial class DepartmentEntery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                 BindDepartment();
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            
            SaveDepartment();
        }

        protected void ClearControl()
        {
            txtDepartment.Text = string.Empty;
            spnError.InnerText = "";
        }

        private void SaveDepartment()
        {
            try
            {
                int result = 0;
                Department obj = new Department();
                obj.DepartmentName = txtDepartment.Text;
                if (hdnDepartID.Value != "")
                {
                    obj.DepID = int.Parse(hdnDepartID.Value);
                 
                }
                else 
                {
                    obj.DepID = 0;
                }

                if (obj.DepID > 0)
                {
                    result = (int)obj.UpdateDepartment(obj);
                }
                else
                {
                    result = (int)obj.SaveDepartment(obj);
                }
                ClearControl();
                if (result > 0)
                {
                    spnError.InnerText = "Record Save Successfully.! ";
                    if (obj.DepID > 0)
                    {
                        spnError.InnerText = "Record Update Successfully.! ";
                        btnSubmit.Text = "Save";
                        hdnDepartID.Value = "0";
                    }
                    BindDepartment();
                }

            }
            catch (Exception ex)
            {
                spnError.InnerText = ex.Message;
            }
        }

        protected void BindDepartment()
        {
            Department obj = new Department();
            DataTable dt= obj.GetDepartment();
            gvDepartment.DataSource = dt;
            gvDepartment.DataBind();
        }

      
      

        protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Department obj = new Department();
            int result = 0;
            int DepartId = 0;
            if (e.CommandName == "D")
            {
                DepartId = Convert.ToInt32(e.CommandArgument);
                result = (int)obj.DeleteDepartMent(DepartId);
                if (result > 0)
                {
                    spnError.InnerText = "Record Delete Successfully.! ";
                    BindDepartment();
                }
               
            }
            if (e.CommandName == "E")
            {
                DepartId = Convert.ToInt32(e.CommandArgument);
                DataTable dt = obj.GetDepartmentByID(DepartId);
                LoadData(dt);
            }
        }


        protected void LoadData(DataTable dt)
        {
            txtDepartment.Text = Convert.ToString(dt.Rows[0]["DepartmentName"]);
            hdnDepartID.Value = Convert.ToString(dt.Rows[0]["DepID"]);
            btnSubmit.Text = "Update";
        }




    }
}