using System;
using System.Data;
using System.Data.SqlClient;

namespace Gridview.GvEmployee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binddata();
            }
        }

        public void savedata()
        {
            int result = 0;
            try
            {
                string insert = "insert into tbl_Employee (FirstName,Lastname,Gender,City,DepartmentName,Salary) values ('" + txt_Fname.Text + "','" + txt_Lname.Text + "','" + rb_Gender.SelectedItem.Text + "','" + txt_City.Text + "','" + txt_DeptName.Text + "','" + Convert.ToInt32(txt_Salary.Text) + "')";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insert;
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        spnError.InnerText = "Record Save Successfully.! ";
                    }
                }

            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
        }

        public void Binddata()
        {
            try
            {
                
                string Get = "SELECT * FROM tbl_Employee";
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Get, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    gvEmployeeData.DataSource = dr;
                    gvEmployeeData.DataBind();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            finally
            {
                //  con.Close();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            savedata();
            Binddata();
        }
    }
}