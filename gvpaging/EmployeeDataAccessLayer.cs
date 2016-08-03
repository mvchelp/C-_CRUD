using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Gridview.gvpaging
{
    public class EmployeeDataAccessLayer
    {
        public static List<employees> GetEmployees(int pageIndex, int pageSize, string sortExpression, string sortDirection, out int totalRows)
        {
            List<employees> listEmployees = new List<employees>();

            using (SqlConnection con = new SqlConnection("Data Source=RAHULRAVAL-PC;Initial Catalog=Employee;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("spGetRecords4", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@PageIndex";
                paramStartIndex.Value = pageIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@PageSize";
                paramMaximumRows.Value = pageSize;
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter paramSortExpression = new SqlParameter();
                paramSortExpression.ParameterName = "@SortExpression";
                paramSortExpression.Value = sortExpression;
                cmd.Parameters.Add(paramSortExpression);

                SqlParameter paramSortDirection = new SqlParameter();
                paramSortDirection.ParameterName = "@SortDirection";
                paramSortDirection.Value = sortDirection;
                cmd.Parameters.Add(paramSortDirection);

                SqlParameter paramOutputTotalRows = new SqlParameter();
                paramOutputTotalRows.ParameterName = "@TotalRows";
                paramOutputTotalRows.Direction = ParameterDirection.Output;
                paramOutputTotalRows.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(paramOutputTotalRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employees emp = new employees();
                    emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();
                    emp.GenderName = rdr["GenderName"].ToString();
                    emp.CountryName = rdr["CountryName"].ToString();
                    emp.StateName = rdr["StateName"].ToString();
                    emp.CityName = rdr["CityName"].ToString();
                    emp.Language = rdr["Language"].ToString();
                    emp.Email = rdr["Email"].ToString();

                    listEmployees.Add(emp);
                }

                rdr.Close();
                totalRows = (int)cmd.Parameters["@TotalRows"].Value;

            }
            return listEmployees;
        }

        public DataTable GetSearchEmployee(string searchBy, string searchVal)
        {
            DataTable dt = new DataTable();
            object result = 0;
            try
            {
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spSearchEmployee",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter paramStartIndex = new SqlParameter();
                    paramStartIndex.ParameterName = "@SearchBy";
                    paramStartIndex.Value = searchBy;
                    cmd.Parameters.Add(paramStartIndex);

                    SqlParameter paramMaximumRows = new SqlParameter();
                    paramMaximumRows.ParameterName = "@SearchVal";
                    paramMaximumRows.Value = searchVal;
                    cmd.Parameters.Add(paramMaximumRows);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
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
            return dt;
        }

        public DataTable GetSearchEmployee2(string EmpId, string Fname, string Lname, string Gender, string Country, string State, string City, string Language, string Email)
        {
            DataTable dt = new DataTable();
            object result = 0;
            try
            {
                string CS = "Data Source=.;Initial Catalog=Employee;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spSearchEmployee2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", EmpId);
                    cmd.Parameters.AddWithValue("@FirstName", Fname);
                    cmd.Parameters.AddWithValue("@LastName", Lname);
                    cmd.Parameters.AddWithValue("@GenderName", Gender);
                    cmd.Parameters.AddWithValue("@CountryName", Country);
                    cmd.Parameters.AddWithValue("@StateName", State);
                    cmd.Parameters.AddWithValue("@CityName", City);
                    cmd.Parameters.AddWithValue("@Language", Language);
                    cmd.Parameters.AddWithValue("@Email", Email);        
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
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
            return dt;
        }
    }
}