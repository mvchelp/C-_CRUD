using System;
using System.Web.UI.WebControls;
using System.Data;
using Gridview.GvEmployee;

namespace Gridview
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInitControls();
            }
        }

        protected void BindInitControls()
        {
            BindStudent();
            BindBranch();
        }
        protected void BindBranch()
        {
            Department obj = new Department();

            ddlBranch.DataSource = obj.GetDepartment();
            ddlBranch.DataTextField = "DepartmentName";
            ddlBranch.DataValueField = "DepID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, "--Select--");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            savestudent();
        }

        protected void ClearControl()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtRollNo.Text = "";
            ddlBranch.ClearSelection();
            txtEmail.Text = "";
            txtAdress.Text = "";

        }

        protected void BindStudent()
        {
          
            Factory objFactory = new Factory();
            DataTable dt = objFactory.GetStudent();
            gvDepartment.DataSource = dt;
            gvDepartment.DataBind();
        }

        private void savestudent()
        {

            int result = 0;
            try
            {
                Student obj = new Student();
                Factory objFactory = new Factory();
                obj.FirstName = txtFname.Text;
                obj.LastName = txtLname.Text;
                obj.RollNo = Convert.ToInt32(txtRollNo.Text);
                obj.Branch = ddlBranch.SelectedItem.Value;
                obj.EmailId = txtEmail.Text;
                obj.Address = txtAdress.Text;
                if (hdnStudent.Value != "" && hdnStudent.Value!=null)
                {
                    obj.StudentId = Convert.ToInt32(hdnStudent.Value);

                }
                else
                {
                    obj.StudentId = 0;
                }

                
                if (obj.StudentId > 0)
                {
                    result = (int)objFactory.UpdateStudent(obj);

                }
                else
                {
                    result = (int)objFactory.SaveStudent(obj);
                }
                ClearControl();

                if (result > 0)
                {
                    spnError.InnerText = "Record Save Successfully.! ";
                    if (obj.StudentId > 0)
                    {
                        spnError.InnerText = "Record Update Successfully.! ";
                        btnSubmit.Text = "Save";
                        hdnStudent.Value = "0";
                    }
                    BindStudent();
                }
            }
            catch (Exception ex)
            {
                spnError.InnerText = ex.Message;
            }
        }

        protected void LoadData(DataTable dt)
        {
            txtFname.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
            txtLname.Text = Convert.ToString(dt.Rows[0]["LastName"]);
            txtRollNo.Text = Convert.ToString(dt.Rows[0]["RollNo"]);
            ddlBranch.SelectedValue = Convert.ToString(dt.Rows[0]["Branch"]);
            txtEmail.Text = Convert.ToString(dt.Rows[0]["EmailId"]);
            txtAdress.Text = Convert.ToString(dt.Rows[0]["Address"]);
            hdnStudent.Value = Convert.ToString(dt.Rows[0]["StudentId"]);
            btnSubmit.Text = "Update";
        }

        protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
             
                Factory objFactory = new Factory();
                int result = 0;
                int stdid = 0;
                if (e.CommandName == "D")
                {
                    stdid = Convert.ToInt32(e.CommandArgument);
                    result = (int)objFactory.DeleteStudent(stdid);
                    if (result > 0)
                    {
                        spnError.InnerText = "record delete successfully.! ";
                        BindStudent();
                    }
                }

                if (e.CommandName == "E")
                {
                    stdid = Convert.ToInt32(e.CommandArgument);
                    DataTable dt = objFactory.GetStudentById(stdid);
                    LoadData(dt);
                }
            }
        }
    }
}