using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeEntry.EmployeeClass;

namespace EmployeeEntry
{
    public partial class EmployeeEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            SaveDepartment();
            
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

        private void SaveDepartment()
        {
            try
            {
               // int userVal = int.Parse(txt_Salary.Text);

                int result = 0;
                Employee  obj = new Employee();
                EmployeeFactory objFactory = new EmployeeFactory();
                obj.FirstName = txt_Fname.Text;
                obj.Lastname = txt_Lname.Text;
                obj.Gender = rb_Gender.SelectedItem.Value;
                obj.DepartmentName = txt_DeptName.Text;
                obj.City = txt_City.Text;
                obj.Salary = Convert.ToInt32(txt_Salary.Text);
                result = (int)objFactory.saveEmployee(obj);
                ClearControl();
                if (result > 0)
                {
                   spnError.InnerText= "Record Save Successfully.! ";

                }

            }
            catch (Exception ex)
            {
                spnError.InnerText = ex.Message;
            }
        }
    }
}