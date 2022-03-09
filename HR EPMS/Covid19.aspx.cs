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
using System.Net;

namespace HR_EPMS
{
    public partial class Covid19 : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer_COVID"].ConnectionString;
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
                string request_button = Page.Request.Params["__EVENTTARGET"];
                where = string.Empty;

            }
            else
            {
                where = string.Empty;
                v_lastDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }

            try
            {
                cn.Open();

                cmd.Connection = cn;
                //cmd.CommandText = "select ROW_NUMBER() OVER(ORDER BY case_id) AS row_id, district, building_name, case_id from t_covid19_cases " + where;

                string sql = "select district, building_name, STUFF((SELECT ',' + CONVERT(varchar(10),cs.case_id) ";
                sql += "FROM t_covid19_cases cs ";
                sql += "WHERE cs.building_name = c.building_name FOR XML PATH('')), 1, 1, '') as case_id, count(1) as case_count from t_covid19_cases c ";
                sql += "GROUP BY building_name, district ORDER BY case_id desc";

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Prepare();

                reader = cmd.ExecuteReader();
                grid_Employee.DataSource = reader;
                grid_Employee.DataBind();
                reader.Close();


                string sql2 = "select max(log_datetime) as lastdate from t_covid19_log where log_status = 'SUCCESS'";
                SqlCommand cmd2 = new SqlCommand(sql2, cn);
                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    v_lastDate.Text = reader2.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss");
                }

                reader2.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                cn.Close();
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