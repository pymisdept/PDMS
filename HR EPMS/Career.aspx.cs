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
    public partial class Career : System.Web.UI.Page
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
            string wheregpagra = string.Empty;
            string tempstring = string.Empty;

            if (IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.Form["v_refno"]))
                {
                    whereClause.Add("RefNum LIKE '%'+@refno+'%'");
                    cmd.Parameters.Add("@refno", SqlDbType.NVarChar, 23).Value = Request.Form["v_refno"];
                }

                if (!String.IsNullOrEmpty(Request.Form["v_appliedposition"]))
                {
                    whereClause.Add("ApplyPosition LIKE '%'+@appliedposition+'%'");
                    cmd.Parameters.Add("@appliedposition", SqlDbType.NVarChar, 120).Value = Request.Form["v_appliedposition"];
                }


                if (!String.IsNullOrEmpty(Request.Form["v_edu"]))
                {
                    wheregpagra = "EduLvl in(select id from education where description like '%'+@edulvl+'%')";
                    cmd.Parameters.Add("@edulvl", SqlDbType.NVarChar, 50).Value = Request.Form["v_edu"];
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
            }
            else
            {
                where = string.Empty;
                wheregpagra = string.Empty;
            }

            try
            {
                cn.Open();
                cmd.Connection = cn;
                tempstring = "select Token,ID,RefNum,ApplyPosition,Format(AppliedDate,'dd/MM/yyyy') as  AppliedDate,Eng_Surname,Eng_Othername,AliasName,Chi_Name," +
                "Addr_district as ADDRID,(Select description from district where id = Addr_District) as Addr_district," +
                "(CASE when exists(select description from education where id = edulvl and education = 'OTH') then edulvlname " +
                "else (select description from education where id = edulvl) end) as EDULVL,ProgramName,WorkEXP,ExpectedSalry," +
                "(CASE when AvailableDateOpt = 'D5' then AvailableDateOth else (Select description from tblAvaDate where code = AvailableDateOpt) end) as AvailableDateOpt," +
                "LatestPosition,FileName1 from Application_Form1";
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