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
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace HR_EPMS
{
    public partial class Career : System.Web.UI.Page
    {
        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        //private string cnStr = ConfigurationManager.ConnectionStrings["uatcnCareer"].ConnectionString;
        private static readonly string uatMode = ConfigurationManager.AppSettings["UATMODE"];
        private SqlConnection cn;
        private string where = string.Empty;
        private string wheregpagra = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //grid_Employee.RowCreated += grid_Employee_RowCreated;
            cn = new SqlConnection(cnStr);
            //SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;
            List<string> whereClause = new List<string>();
            ClientScript.RegisterStartupScript(Page.GetType(), "OnLoad", "changepage();", true);
            if (IsPostBack)
            {
                string request_button = Page.Request.Params["__EVENTTARGET"];
                where = string.Empty;
                if (!String.IsNullOrEmpty(Request.Form["v_refno"]))
                {
                    whereClause.Add("RefNum LIKE '%'+@refno+'%'");
                    //cmd.Parameters.Add("@refno", SqlDbType.NVarChar, 23).Value = Request.Form["v_refno"];
                }

                if (!String.IsNullOrEmpty(Request.Form["v_appliedposition"]))
                {
                    whereClause.Add("ApplyPosition LIKE '%'+@appliedposition+'%'");
                    //cmd.Parameters.Add("@appliedposition", SqlDbType.NVarChar, 120).Value = Request.Form["v_appliedposition"];
                }


                if (!String.IsNullOrEmpty(Request.Form["v_edu"]))
                {
                    wheregpagra = "EduLvl in(select id from education where description like '%'+@edulvl+'%')";
                    //cmd.Parameters.Add("@edulvl", SqlDbType.NVarChar, 50).Value = Request.Form["v_edu"];
                }


                if (!String.IsNullOrEmpty(Request.Form["v_exp"]))
                {
                    if (Request.Form["v_exp"] != "A")
                    {
                        if (Request.Form["v_exp"] == "3")
                        {
                            whereClause.Add("ISNULL(WorkExp, 0) < 3");
                        }
                        else if (Request.Form["v_exp"] == "5")
                        {
                            whereClause.Add("ISNULL(WorkExp, 0) >= 3 and ISNULL(WorkExp, 0) <=  5");
                        }
                        else if (Request.Form["v_exp"] == "10")
                        {
                            whereClause.Add("ISNULL(WorkExp, 0) > 5 and ISNULL(WorkExp, 0) <= 10");
                        }
                        else if (Request.Form["v_exp"] == "20")
                        {
                            whereClause.Add("ISNULL(WorkExp, 0) > 10 and ISNULL(WorkExp, 0) <= 20");
                        }
                        else
                            whereClause.Add("ISNULL(WorkExp, 0) > 20");
                    }
                }


                if ((!String.IsNullOrEmpty(Request.Form["v_SelectSalary"])) && (!String.IsNullOrEmpty(Request.Form["v_Salary"])))
                {
                    if (Request.Form["v_Salary"] != "")
                    {
                        string temp_salary = Request.Form["v_Salary"].Trim();
                        if (Request.Form["v_SelectSalary"] == "1")
                        {
                            whereClause.Add("ExpectedSalry > '" + temp_salary + "'");
                        }
                        else if (Request.Form["v_SelectSalary"] == "2")
                        {
                            whereClause.Add("ExpectedSalry < '" + temp_salary + "'");
                        }
                        else if (Request.Form["v_SelectSalary"] == "3")
                        {
                            whereClause.Add("ExpectedSalry = '" + temp_salary + "'");
                        }
                    }
                }
                if ((!String.IsNullOrEmpty(Request.Form["v_Datefrom"])) && (!String.IsNullOrEmpty(Request.Form["v_Dateto"])))
                {
                    string dtFr = Request.Form["v_Datefrom"].Trim(); 
                    string dtTo = Request.Form["v_Dateto"].Trim();
                    if (String.Compare(dtFr, dtTo) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "checkdate()", true);
                        return;
                    }
                    else
                    {
                        whereClause.Add("Format(AppliedDate,'yyyy-MM-dd') >= '" + dtFr + "' and Format(AppliedDate,'yyyy-MM-dd') <= '" + dtTo + "'");
                    }
                       
                }
                for (int i = 0; i < whereClause.Count; i++)
                {
                    if (i == 0)
                        where = " where " + whereClause[i];
                    else
                        where += " and " + whereClause[i];
                }
                if (request_button == "btn_search")
                {
                    show_data();
                }
            }
            else
            {
                where = string.Empty;
                wheregpagra = string.Empty;
            }

            if (!IsPostBack)
            {
                show_data();
            }
        }
        protected void show_data()
        {
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.Connection = cn;
                //string statusSQL = "";
                string tempstring = "";
                //string where = "";
                //string wheregpagra = "";
                tempstring = "select Token,a.ID,RefNum,ApplyPosition,Format(AppliedDate,'dd/MM/yyyy') as  AppliedDate,Eng_Surname,Eng_Othername,AliasName,Chi_Name," +
                "Addr_district as ADDRID,(Select description from district where id = Addr_District) as Addr_district," +
                "(CASE when exists(select description from education where id = edulvl and education = 'OTH') then edulvlname " +
                "else (select description from education where id = edulvl) end) as EDULVL,ProgramName,WorkEXP,ExpectedSalry," +
                "(CASE when AvailableDateOpt = 'D5' then AvailableDateOth else (Select description from tblAvaDate where code = AvailableDateOpt) end) as AvailableDateOpt," +
                "(CASE when status = 'P2' then 'Submitted' else 'Not Submitted' end) as SubmitStatus," +
                "LatestPosition,FileName1,'PYM' as Companyname, b.Date as InterviewDate, b.Time as InterviewTime, b.Address as InterviewAdress, b.Contactperson, b.Contactno, b.Remarks from Application_Form1" +
                " a left join tblInterviewInfo b on b.refcode= a.RefNum";
                string sortstring = " order by ID";
                if (where == "")
                {
                    if (wheregpagra == "")
                    {
                        cmd.CommandText = tempstring + sortstring;
                    }
                    else
                    {
                        tempstring += " and " + wheregpagra + sortstring;
                        cmd.CommandText = tempstring;
                    }
                }
                else
                {
                    if (wheregpagra == "")
                    {
                        cmd.CommandText = tempstring + where + sortstring;
                    }
                    else
                    {
                        tempstring += where + " and " + wheregpagra + sortstring;
                        cmd.CommandText = tempstring;
                    }
                }
                //tempstring = "select * from Application_Form1 where ID=@ID";
                // cmd.CommandText = tempstring+sortstring;


                cmd.CommandType = CommandType.Text;
                cmd.Prepare();

                reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    reader.Close();
                    tempstring = "select distinct '' as Token,0 as ID,'' as RefNum,'No record was found' as ApplyPosition,'' as  AppliedDate,'' as Eng_Surname,'' as Eng_Othername,'' as AliasName,'' as Chi_Name," +
                "'' as ADDRID,'' as Addr_district, '' as EDULVL,'' as ProgramName,0.0 as WorkEXP,0 as ExpectedSalry," +
                "'' as AvailableDateOpt,'' as LatestPosition,'' as FileName1 from Application_Form1 order by ID";

                    cmd.CommandText = tempstring;
                    cmd.CommandType = CommandType.Text;
                    cmd.Prepare();


                    reader = cmd.ExecuteReader();
                    grid_Employee.DataSource = reader;
                    grid_Employee.DataBind();
                }
                else
                {
                    grid_Employee.DataSource = reader;
                    grid_Employee.DataBind();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void grid_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //grid_Employee.UseAccessibleHeader = true;
            ////grid_Employee.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                //cn.Open();
                //string CompanyCode = (e.Row.FindControl("lbl_companyname") as Label).Text;
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlcompanynames = (e.Row.FindControl("ddlcompanyname") as DropDownList);
                    SqlCommand cmd = new SqlCommand("SELECT PosCompany_Code, PosCompany_EName + ' ' + PosCompany_CName as Company_name FROM PosCompany", cn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //cn.Close();
                    ddlcompanynames.DataSource = dt;//GetData("SELECT PosCompany_Code, PosCompany_EName + ' ' + PosCompany_CName as Company_name FROM PosCompany");
                    ddlcompanynames.DataTextField = "Company_name";
                    ddlcompanynames.DataValueField = "PosCompany_Code";
                    ddlcompanynames.DataBind();

                    //Add Default Item in the DropDownList
                    ddlcompanynames.Items.Insert(0, new ListItem("---Select---"));

                    //Select the Country of Customer in DropDownList
                    //ddlcompanynames.Items.FindByValue(CompanyCode).Selected = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.TableSection = TableRowSection.TableFooter;
            }
        }
        private DataSet GetData(string query)
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand(query);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd1.Connection = cn;
                sda.SelectCommand = cmd1;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }      
        }
        protected void grid_Employee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Visible = false;

                AddHeaderRow1();
                AddHeaderRow2();
            }

        }
        void AddHeaderRow1()
        {
            GridViewRow gr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell thc1 = new TableHeaderCell();
            TableHeaderCell thc2 = new TableHeaderCell();
            TableHeaderCell thc3 = new TableHeaderCell();

            thc1.Text = " ";
            thc2.Text = "Application Form";
            thc3.Text = "Interview";

            thc1.ColumnSpan = 15;
            thc2.ColumnSpan = 5;
            thc3.ColumnSpan = 7;

            // Assign CSS
            thc1.CssClass = "StickyHeader";
            thc2.CssClass = "StickyHeader";
            thc3.CssClass = "StickyHeader";

            gr.Cells.AddRange(new TableCell[] { thc1, thc2, thc3 });

            grid_Employee.Controls[0].Controls.AddAt(0, gr);
        }
        void AddHeaderRow2()
        {
            GridViewRow gr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell thc1 = new TableHeaderCell();
            TableHeaderCell thc2 = new TableHeaderCell();
            TableHeaderCell thc3 = new TableHeaderCell();
            TableHeaderCell thc4 = new TableHeaderCell();
            TableHeaderCell thc5 = new TableHeaderCell();
            TableHeaderCell thc6 = new TableHeaderCell();
            TableHeaderCell thc7 = new TableHeaderCell();
            TableHeaderCell thc8 = new TableHeaderCell();
            TableHeaderCell thc9 = new TableHeaderCell();
            TableHeaderCell thc10 = new TableHeaderCell();
            TableHeaderCell thc11 = new TableHeaderCell();
            TableHeaderCell thc12 = new TableHeaderCell();
            TableHeaderCell thc13 = new TableHeaderCell();
            TableHeaderCell thc14 = new TableHeaderCell();
            TableHeaderCell thc15 = new TableHeaderCell();
            TableHeaderCell thc16 = new TableHeaderCell();
            TableHeaderCell thc17 = new TableHeaderCell();
            TableHeaderCell thc18 = new TableHeaderCell();
            TableHeaderCell thc19 = new TableHeaderCell();
            TableHeaderCell thc20 = new TableHeaderCell();
            TableHeaderCell thc21 = new TableHeaderCell();
            TableHeaderCell thc22 = new TableHeaderCell();
            TableHeaderCell thc23 = new TableHeaderCell();
            TableHeaderCell thc24 = new TableHeaderCell();
            TableHeaderCell thc25 = new TableHeaderCell();
            TableHeaderCell thc26 = new TableHeaderCell();

            thc1.Text = "ID";
            thc2.Text = "Reference No.";
            thc3.Text = "Apply Date";
            thc4.Text = "Applied Position";
            thc5.Text = "English Name";
            thc6.Text = "District";
            thc7.Text = "Education Level";
            thc8.Text = "Programme Name / Subject";
            thc9.Text = "Working Exp(Year)";
            thc10.Text = "Expected Salary";
            thc11.Text = "Date Available";
            thc12.Text = "Current Position";
            thc13.Text = "CV";
            thc14.Text = "Form2 Link";
            thc15.Text = "Dtls/Rpt";
            thc16.Text = "Application Form";
            thc17.Text = "Link";
            thc18.Text = "Submission";
            thc19.Text = "Company Name";
            thc20.Text = " ";
            thc21.Text = "Date";
            thc22.Text = "Time";
            thc23.Text = "Address";
            thc24.Text = "Contact Person";
            thc25.Text = "Contact No.";
            thc26.Text = "Remark";

            //// Assign CSS
            thc1.CssClass = "StickyHeader";
            thc2.CssClass = "StickyHeader";
            thc3.CssClass = "StickyHeader";
            thc4.CssClass = "StickyHeader";
            thc5.CssClass = "StickyHeader";
            thc6.CssClass = "StickyHeader";
            thc7.CssClass = "StickyHeader";
            thc8.CssClass = "StickyHeader";
            thc9.CssClass = "StickyHeader";
            thc10.CssClass = "StickyHeader";
            thc11.CssClass = "StickyHeader";
            thc12.CssClass = "StickyHeader";
            thc13.CssClass = "StickyHeader";
            thc14.CssClass = "StickyHeader";
            thc15.CssClass = "StickyHeader";
            thc16.CssClass = "StickyHeader";
            thc17.CssClass = "StickyHeader";
            thc18.CssClass = "StickyHeader";
            thc19.CssClass = "StickyHeader";
            thc20.CssClass = "StickyHeader";
            thc21.CssClass = "StickyHeader";
            thc22.CssClass = "StickyHeader";
            thc23.CssClass = "StickyHeader";
            thc24.CssClass = "StickyHeader";
            thc25.CssClass = "StickyHeader";
            thc26.CssClass = "StickyHeader";

            gr.Cells.AddRange(new TableCell[] { thc1, thc2, thc3, thc4, thc5, thc6, thc7, thc8, thc9, thc10, thc11, thc12, thc13, thc14, thc15, thc16, thc17, thc18, thc19, thc20, thc21, thc22, thc23, thc24, thc25, thc26 });

            grid_Employee.Controls[0].Controls.AddAt(1, gr);
        }

        protected void grid_Employee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*
              //Finding the controls from Gridview for the row which is going to update  
            Label id = grid_Link.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox posi = grid_Link.Rows[e.RowIndex].FindControl("txt_position") as TextBox;
            TextBox refc = grid_Link.Rows[e.RowIndex].FindControl("txt_refCode") as TextBox;

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
            
            show_data();
             
             */

        }

        protected void grid_Employee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_Employee.EditIndex = e.NewEditIndex;
            show_data();
        }

        protected void grid_Employee_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grid_Employee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_Employee.EditIndex = -1;
            show_data();
        }

        //protected void ButtonSendMail_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<string> lstAllRecipients = new List<string>();
        //        //Below is hardcoded - can be replaced with db data
        //        lstAllRecipients.Add("sanjeev.kumar@testmail.com");
        //        lstAllRecipients.Add("chandan.kumarpanda@testmail.com");

        //        Outlook.Application outlookApp = new Outlook.Application();
        //        Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
        //        Outlook.Inspector oInspector = oMailItem.GetInspector;
        //        // Thread.Sleep(10000);

        //        // Recipient
        //        Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
        //        foreach (String recipient in lstAllRecipients)
        //        {
        //            Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
        //            oRecip.Resolve();
        //        }

        //        //Add CC
        //        Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
        //        oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
        //        oCCRecip.Resolve();

        //        //Add Subject
        //        oMailItem.Subject = "Test Mail";

        //        // body, bcc etc...

        //        //Display the mailbox
        //        oMailItem.Display(true);
        //    }
        //    catch (Exception objEx)
        //    {
        //        Response.Write(objEx.ToString());
        //    }
        //}
    }
}
