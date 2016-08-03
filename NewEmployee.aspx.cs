using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class NewEmployee : System.Web.UI.Page
    {
        DataTable Employee;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControl();
            }
        }

        protected void initControl()
        {
            bindDepartment();
            AddDatatable();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddNewRow();
            ClearControl();
        }

        protected void btnFinalSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        protected void ClearControl()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            rbGender.ClearSelection();
            ddlDepartment.ClearSelection();
            txtSalary.Text = "";

        }

        protected void bindDepartment()
        {
            ddlDepartment.Items.Insert(0, "Select");
            ddlDepartment.Items.Insert(1, "Mechanical");
            ddlDepartment.Items.Insert(2, "Computer");
            ddlDepartment.Items.Insert(3, "IT");
            ddlDepartment.Items.Insert(4, "Automobile");
            ddlDepartment.Items.Insert(5, "Electrical");
            ddlDepartment.Items.Insert(6, "Mechatronix");
        }

        protected void BindGrid()
        {
            gvTable.DataSource = (DataTable)ViewState["Employee"];
            gvTable.DataBind();
        }

        protected void AddDatatable()
        {
            try
            {
                this.Employee = new DataTable();
                Employee.TableName = "Employee";
                Employee.Columns.Add(new DataColumn("FirstName", typeof(string)));
                Employee.Columns.Add(new DataColumn("LastName", typeof(string)));
                Employee.Columns.Add(new DataColumn("Gender", typeof(int)));
                Employee.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
                Employee.Columns.Add(new DataColumn("Salary", typeof(int)));
                DataRow row = Employee.NewRow();
                Employee.Rows.Add(row);

                ViewState["Employee"] = Employee;
                BindGrid();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        protected void AddNewRow()
        {

            try
            {
                if (ViewState["Employee"] != null)
                {
                    this.Employee = (DataTable)ViewState["Employee"];
                    DataRow dr = null;

                    if (Employee.Rows.Count > 0)
                    {

                        for (int i = 1; i <= Employee.Rows.Count; i++)
                        {
                            dr = Employee.NewRow();
                            dr["FirstName"] = txtFname.Text;
                            dr["LastName"] = txtLname.Text;
                            dr["Gender"] = Convert.ToInt32(rbGender.SelectedItem.Value);
                            dr["DepartmentName"] = ddlDepartment.SelectedItem.Text;
                            dr["Salary"] = Convert.ToInt32(txtSalary.Text);

                        }
                        if (Employee.Rows[0][0].ToString() == "")
                        {
                            Employee.Rows[0].Delete();
                            Employee.AcceptChanges();

                        }

                        Employee.Rows.Add(dr);
                        ViewState["Employee"] = Employee;
                        BindGrid();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        protected void saveData()
        {
            try
            {
                this.Employee = (DataTable)ViewState["Employee"];
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (DataRow dr in Employee.Rows)
                    {
                        string insert = "insert into tblNewEmployee (FirstName,LastName,Gender,Department,Salary) values('" + dr["FirstName"] + "','" + dr["LastName"] + "','" + dr["Gender"] + "','" + dr["DepartmentName"] + "','" + dr["Salary"] + "')";
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = insert;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // result = ex.Message;
            }
            finally
            {
            }
        }


        protected void gvTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "D")
            {
                object index = Convert.ToInt32(e.CommandArgument);
                if (index !=null)
                {
                    DataTable Employee = (DataTable)ViewState["Employee"];
                    Employee.Rows.RemoveAt((int)index);
                }
                BindGrid();
            }
        }
    }
}