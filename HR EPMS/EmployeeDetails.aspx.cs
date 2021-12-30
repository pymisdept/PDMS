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
using System.IO;

namespace HR_EPMS
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            string sid = Request.QueryString["sid"];

            if (String.IsNullOrEmpty(sid))
                Response.Redirect("EmployeeProfile.aspx");


            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "select staffID, engName, chiName, profiePic, dateOfBirth, curPosition, fromDate, keyData, remarks, profession from t_EmployeeProfile where staffID = @staffid";

            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                v_staffid.Text = reader.GetString(0);
                v_engname.Text = reader.GetString(1);
                v_chiname.Text = reader.GetString(2);
                v_dateofbirth.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                v_curpos.Text = reader.GetString(5);
                v_joineddate.Text = reader.GetDateTime(6).ToString("yyyy-MM-dd");
                v_keydata.Value = reader.GetString(7);
                v_remarks.Value = reader.GetString(8);
                v_prof.Text = reader.GetString(9);

                string imgfilename = string.Empty;
                if (reader.GetString(3) == string.Empty)
                {
                    imgfilename = @"img/profile.png";
                }
                else
                {
                    int idx = reader.GetString(3).LastIndexOf('.');
                    imgfilename = @"img/tmp/" + "profilePic_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(3).Substring(idx);
                    File.Copy(@reader.GetString(3), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                }

                v_profilepic.Attributes["src"] = imgfilename;


            }


            reader.Close();
            cmd.CommandText = "select rowNo, qualiName, issuedBy, issuedYear, showInCV from t_Qualification where staffID = @staffid order by issuedYear desc";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            cmd.Prepare();


            reader = cmd.ExecuteReader();
            grid_Quali.DataSource = reader;
            grid_Quali.DataBind();
            reader.Close();

            cmd.CommandText = "select rowNo, position, format(fromDate, 'yyyy-MM-dd') AS fromDate, CASE WHEN ISNULL(toDate,'') = '' THEN 'Present' ELSE format(toDate, 'yyyy-MM-dd') END as toDate, showInCV from t_PYMovement where staffID = @staffid order by fromDate desc";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            cmd.Prepare();
            reader = cmd.ExecuteReader();
            grid_Movement.DataSource = reader;
            grid_Movement.DataBind();
            reader.Close();


            cmd.CommandText = "select rowNo, compName, position, CASE WHEN ISNULL(jobDesc, '') = '' AND ISNULL(w.projCode, '') <> '' THEN p.projDesc ELSE ISNULL(jobDesc, '') END as jobDesc, format(fromDate, 'yyyy-MM-dd') as fromDate, CASE WHEN ISNULL(toDate,'') = '' THEN 'Present' ELSE format(toDate, 'yyyy-MM-dd') END as toDate, showInCV from t_WorkingExp w left join t_Project p on w.projCode = p.projCode where staffID = @staffid order by fromDate desc";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Exp.DataSource = reader;
            grid_Exp.DataBind();
            reader.Close();

            //if (IsPostBack)
            //{

            //}
            //else
            //{

            //}
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