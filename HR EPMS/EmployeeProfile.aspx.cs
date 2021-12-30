using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HR_EPMS
{
    public partial class EmployeeProfile : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<string> whereClause = new List<string>();
            string where = string.Empty;

            if (IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.Form["v_staffid"]))
                {
                    whereClause.Add("staffID LIKE @staffid");
                    cmd.Parameters.Add("@staffid", SqlDbType.NVarChar, 10).Value = String.Concat("%", Request.Form["v_staffid"], "%");
                }

                if (!String.IsNullOrEmpty(Request.Form["v_staffname"]))
                {
                    whereClause.Add("(engName LIKE @engName or chiName LIKE @chiName)");

                    cmd.Parameters.Add("@engName", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_staffname"], "%");
                    cmd.Parameters.Add("@chiName", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_staffname"], "%");
                }

                int showInactive = -1;
                if (String.IsNullOrEmpty(Request.Form["v_showinactive"]))
                    showInactive = 0;
                else
                    showInactive = Request.Form["v_showinactive"] == "on" ? 1 : 0;

                if (showInactive == 0)
                {
                    whereClause.Add("IsActive = 1");
                }

                for (int i = 0; i < whereClause.Count; i++)
                {
                    if (i == 0)
                        where = " where " + whereClause[i];
                    else
                        where += " and " + whereClause[i];
                }
            }
            else
            {
                where = string.Empty;
            }

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "select staffID, engName, chiName, curPosition, fromDate, DateDiff(year, firstJobDate, GETDATE()) AS workExp from t_EmployeeProfile " + where;
                cmd.CommandType = CommandType.Text;

                cmd.Prepare();

                reader = cmd.ExecuteReader();
                grid_Employee.DataSource = reader;
                grid_Employee.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {

            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}