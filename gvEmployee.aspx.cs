using System;
using System.Web.UI.WebControls;
using System.Data;
using Gridview.GvEmployee;

namespace Gridview
{
    public partial class gvEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGvData();
            }
        }

        protected void btn_Submit_Click1(object sender, EventArgs e)
        {
            SaveEmployee();
        }

        protected void ClearControl()
        {
            txt_Fname.Text = "";
            txt_Lname.Text = "";
            txt_DeptName.Text = "";
            txt_City.Text = "";
            txt_Salary.Text = "";
            rb_Gender.ClearSelection();
        }

        private void SaveEmployee()
        {
            try
            {
                int result = 0;
                Employee obj = new Employee();
                obj.FirstName = txt_Fname.Text;
                obj.Lastname = txt_Lname.Text;
                obj.Gender = rb_Gender.SelectedItem.Value;
                obj.DepartmentName = txt_DeptName.Text;
                obj.City = txt_City.Text;
                obj.Salary = Convert.ToInt32(txt_Salary.Text);
                if (hdnEmployee.Value != "")
                {
                    obj.EmployeeId = Convert.ToInt32(hdnEmployee.Value);

                }
                else
                {
                    obj.EmployeeId = 0;
                }

                if (obj.EmployeeId > 0)
                {
                    result = (int)obj.UpdateEmployee(obj);

                }
                else
                {
                    result = (int)obj.saveEmployee(obj);
                }
                ClearControl();
                if (result > 0)
                {
                    spnError.InnerText = "Record Save Successfully.! ";
                    if (obj.EmployeeId > 0)
                    {
                        spnError.InnerText = "Record Update Successfully.! ";
                        btn_Submit.Text = "Save";
                        hdnEmployee.Value = "0";
                    }
                    BindGvData();
                }

            }
            catch (Exception ex)
            {
                spnError.InnerText = ex.Message;
            }
        }

        private void BindGvData()
        { 
            Employee obj = new Employee();
            DataTable dt = new DataTable();
            dt =obj.GetEmployee();
            gvEmployeeData.DataSource = dt;
            gvEmployeeData.DataBind();
        }

        protected void gvEmployeeData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Employee obj = new Employee();
            int result = 0;
            int EmpId = 0;
            if (e.CommandName == "D")
            {
                EmpId = Convert.ToInt32(e.CommandArgument);
                result = (int)obj.DeleteEmployee(EmpId);
                if (result > 0)
                {
                    spnError.InnerText = "Record Delete Successfully.! ";
                    BindGvData();
                }
            }

            if (e.CommandName == "E")
            {
                EmpId = Convert.ToInt32(e.CommandArgument);
                DataTable dt = obj.GetEmployeeById(EmpId);
                LoadData(dt);
            }
        }


        protected void LoadData(DataTable dt)
        {
            txt_Fname.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
            txt_Lname.Text = Convert.ToString(dt.Rows[0]["Lastname"]);
            rb_Gender.SelectedValue = Convert.ToString(dt.Rows[0]["Gender"]);
            txt_City.Text = Convert.ToString(dt.Rows[0]["City"]);
            txt_DeptName.Text = Convert.ToString(dt.Rows[0]["DepartmentName"]);
            txt_Salary.Text = Convert.ToString(dt.Rows[0]["Salary"]);
            hdnEmployee.Value = Convert.ToString(dt.Rows[0]["EmployeeId"]);
            btn_Submit.Text = "Update";
        }
    }
}