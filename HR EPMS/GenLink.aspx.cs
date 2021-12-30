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
using System.Web.Services;
using Newtonsoft.Json;
using log4net;
using log4net.Config;

namespace HR_EPMS
{
    public partial class GenLink : System.Web.UI.Page
    {
        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        private SqlConnection cn;
        private static readonly ILog TxtLog = LogManager.GetLogger(typeof(GenLink));
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<string> whereClause = new List<string>();
            XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));
            string where = string.Empty;
            TxtLog.Info("Connect String： "+cnStr);
            if (IsPostBack)
            {
                string request_button = Page.Request.Params["__EVENTTARGET"];
                where = string.Empty;

                if (request_button == "btn_Update")
                {
                    btnUpdate_Click(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"]);
                }
                if (request_button == "btn_search")
                {
                    btnSearch_Click(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn, cmd);
                }
                //ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], cn);
            }
            else
            {
                where = string.Empty;

                //bindfirstinterviewer();
                //bindsecondinterviewer();
                //bindthirdinterviewer();
            }

            //if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
            //{
            //    string Text = "";
            //    String constr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
            //    SqlConnection myconn = new SqlConnection(constr);
            //    myconn.Open();
            //    string sql = "select * from Staff_Master ";
            //    //SqlCommand cmd = new SqlCommand(sql, myconn);

            //    cmd.Connection = myconn;
            //    cmd.CommandText = sql;
            //    cmd.CommandType = CommandType.Text;

            //    SqlDataReader dataReader = cmd.ExecuteReader();
            //    while (dataReader.Read())
            //    {
            //        Text = Text + "{" + "\"label\":\"" + dataReader[2].ToString() + "\"," +
            //            "\"name\":\"" + dataReader[2].ToString() + "\"," +
            //            "\"id\":\"" + dataReader[5].ToString() + "\"," +
            //            "\"guid\":\"" + dataReader[0].ToString() + "\"" +
            //            "}|";
            //        Text = Text + "{" + "\"label\":\"" + dataReader[5].ToString() + "\"," +
            //            "\"name\":\"" + dataReader[2].ToString() + "\"," +
            //            "\"id\":\"" + dataReader[5].ToString() + "\"," +
            //            "\"guid\":\"" + dataReader[0].ToString() + "\"" +
            //            "}|";

            //    }
            //    Text = Text.Substring(0, Text.Length - 1);
            //    Text = Text + "";
            //    myconn.Close();
            //    Response.Write(Text);
            //    Response.End();
            //}
            if (!IsPostBack)
            {
               ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
            }


        }
        protected void ShowData(string posName, string refcode,string stStatus, SqlConnection cn)
        {
            try
            {
                SqlDataReader rd;
                SqlCommand cm = new SqlCommand();
                cn.Open();
                cm.Connection = cn;
                string statusSQL = "";
                string dtSQL = "";
                stStatus = (stStatus??"");
                //cmd.CommandText = "select ROW_NUMBER() OVER(ORDER BY case_id) AS row_id, district, building_name, case_id from t_covid19_cases " + where;
                if (stStatus.Contains('1'))
                {
                    statusSQL = "A.IsValid=1";
                 }
                else if(stStatus.Contains('2'))
                {
                    statusSQL = "A.IsValid=0";
                }
                else
                {
                    statusSQL = "1=1";
                }
                if (dtFrom.Text!="" && dtTo.Text != "")
                {
                    dtSQL = " and convert(char(8),A.CreateDate,112)>='" + dtFrom.Text.Replace("-", "")+"' and convert(char(8),A.CreateDate,112)<='"+dtTo.Text.Replace("-","")+"'";
                }
                string sql = "select A.ID, A.Postion, A.RefCode, A.Token, A.Company, B.PosCompany_EName, convert(nvarchar(10), A.CreateDate, 126) AS CreateDate, "+
                    "convert(nvarchar(10), A.ExpiryDate, 126) AS ExpiryDate, (Case when A.IsValid=1 then 'Active' else 'Inactive' END) as Status,"+
                    "(Case when convert(char(8),A.ExpiryDate,112)<convert(char(8),Getdate(),112) then 0 else 1 end) AS Lock from PositionLink A LEFT JOIN PosCompany B ON A.Company = B.PosCompany_Code";
                sql += " where "+ statusSQL + " and A.Postion like '%" + posName + "%' and A.RefCode like '%" + refcode + "%' "+dtSQL;
                sql += " order by ID desc";
                TxtLog.Info("Query SQL is: "+sql);
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;

                cm.Prepare();

                rd = cm.ExecuteReader();
                grid_Link.DataSource = rd;
                grid_Link.DataBind();
                rd.Close();
            }
            catch (Exception ex)
            {
                TxtLog.Error(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        protected void grid_Link_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            grid_Link.EditIndex = e.NewEditIndex;
            ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
        }
        protected void grid_Link_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = grid_Link.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox posi = grid_Link.Rows[e.RowIndex].FindControl("txt_position") as TextBox;
            TextBox refc = grid_Link.Rows[e.RowIndex].FindControl("txt_refCode") as TextBox;

            //TextBox city = grid_Link.Rows[e.RowIndex].FindControl("txt_refcode") as TextBox;
            TxtLog.Info("Row update start");
            cn = new SqlConnection(cnStr);
            cn.Open();
            //updating the record  
            //SqlCommand cmd = new SqlCommand("Update PositionLink set Postion='" + name.Text + "',City='" + city.Text + "' where ID=" + Convert.ToInt32(id.Text), cn);
            //TxtLog.Info("Row update sql is:"+ " Update PositionLink set Postion='" + posi.Text + "',RefCode='"+refc.Text+"' where ID=" + Convert.ToInt32(id.Text));
            SqlCommand cmd = new SqlCommand("Update PositionLink set Postion='" + posi.Text+ "',RefCode='" + refc.Text +"' where ID=" + Convert.ToInt32(id.Text), cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            grid_Link.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            
            ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
        }
        protected void grid_Link_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            grid_Link.EditIndex = -1;
            ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
        }

        private void btnUpdate_Click(string posName, string refcode)
        {
            try
            {
                cn.Open();
                string sql = "insert into PositionLink (Postion, Token, Company, CreateDate,  IsValid, ClickCount,RefCode) values (@pos, @token, @Company, @createDate, @isValid, 0, @refcode)";
                SqlCommand cmd2 = new SqlCommand(sql, cn);

                cmd2.Parameters.Add("@pos", SqlDbType.NVarChar, 50).Value = posName;
                cmd2.Parameters.Add("@token", SqlDbType.NVarChar, 1000).Value = EncryptClass.Encrypt(posName + DateTime.Now.ToString("yyyyMMddhhmmss"));
                cmd2.Parameters.Add("@Company", SqlDbType.NVarChar, 10).Value = "PYM";// companycode;
                cmd2.Parameters.Add("@createDate", SqlDbType.DateTime, 30).Value = DateTime.Now;
                //cmd2.Parameters.Add("@expiryDate", SqlDbType.DateTime, 30).Value = null;//DateTime.Now.AddDays(7);
                cmd2.Parameters.Add("@isValid", SqlDbType.Int).Value = 1;
                cmd2.Parameters.Add("@refcode", SqlDbType.VarChar, 10).Value =refcode;
                cmd2.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {
                TxtLog.Info(ex.Message);
            }
            finally
            {
                cn.Close();
                ShowData("", "", "", cn);
            }
        }

        private void btnSearch_Click(string posName, string refcode,string stStatus, SqlConnection cn, SqlCommand cm ) 
        {
            ShowData(posName, refcode,stStatus, cn);
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

        protected void grid_Link_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int id = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Deactive":
                    cn.Open();
                    //updating the record  
                    //SqlCommand cmd = new SqlCommand("Update PositionLink set Postion='" + name.Text + "',City='" + city.Text + "' where ID=" + Convert.ToInt32(id.Text), cn);
                    SqlCommand cmd = new SqlCommand("Update PositionLink set IsValid='0' where ID=" + Convert.ToInt32(e.CommandArgument.ToString()), cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                    grid_Link.EditIndex = -1;
                    //Call ShowData method for displaying updated data  
                    ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
                    break;
                case "Repost":
                    cn.Open();
                    //updating the record  
                    //SqlCommand cmd = new SqlCommand("Update PositionLink set Postion='" + name.Text + "',City='" + city.Text + "' where ID=" + Convert.ToInt32(id.Text), cn);
                    SqlCommand cmd1 = new SqlCommand("Update PositionLink set ExpiryDate=null,IsValid='1' where ID=" + Convert.ToInt32(e.CommandArgument.ToString()), cn);
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                    grid_Link.EditIndex = -1;
                    ShowData(Page.Request.Params["v_position"], Page.Request.Params["v_refcode"], Page.Request.Params["v_SelectActive"], cn);
                    break;
                default:
                    break;
            }
           // 
        }
    }

}