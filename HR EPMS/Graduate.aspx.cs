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
    public partial class Graduate : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnFreshCareer"].ConnectionString;
        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<string> whereClause = new List<string>();
            List<string> whereClausegpagra = new List<string>();
            string where = string.Empty;
            string wheregpagra = string.Empty;
            string wheregpagra2 = string.Empty;


            string tempstring = string.Empty;

            if (IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.Form["v_staffid"]))
                {
                    whereClause.Add("ISNULL(A.RefNum, '') LIKE @staffid");
                    cmd.Parameters.Add("@staffid", SqlDbType.NVarChar, 10).Value = String.Concat("%", Request.Form["v_staffid"], "%");
                }

                if (!String.IsNullOrEmpty(Request.Form["v_appliedposition"]))
                {
                    whereClause.Add("ISNULL(J.[description], '') LIKE @appliedposition");
                    cmd.Parameters.Add("@appliedposition", SqlDbType.NVarChar, 100).Value = String.Concat("%", Request.Form["v_appliedposition"], "%");
                }

                if (!String.IsNullOrEmpty(Request.Form["v_staffname"]))
                {
                    whereClause.Add("(LTRIM(RTRIM(ISNULL(I.Eng_Surname, ''))) + ' ' + LTRIM(RTRIM(ISNULL(I.Eng_Othername, ''))) LIKE @engName or ISNULL(I.Chi_Name, '') LIKE @chiName)");

                    cmd.Parameters.Add("@engName", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_staffname"], "%");
                    cmd.Parameters.Add("@chiName", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_staffname"], "%");
                }
                if (!String.IsNullOrEmpty(Request.Form["v_edu"]))
                {
                    //whereClause.Add("(LTRIM(RTRIM(ISNULL(C.Edu_Description, ''))) LIKE @Edu or ISNULL(C.Sch_Description, '') LIKE @Sch or ISNULL(C.ProgrammeName, '') LIKE @Prog)");
                    wheregpagra2 = "(CASE WHEN ISNULL(I.education, '') = 'OTH' THEN ISNULL(XX.Edu_Others, '') ELSE ISNULL(I.description, '') END LIKE @Edu or";
                    wheregpagra2 = wheregpagra2 + " CASE WHEN ISNULL(J.school, '') = 'OTH' THEN ISNULL(XX.Sch_Others, '') ELSE ISNULL(J.description, '') END LIKE @Sch or ISNULL(XX.ProgrammeName, '') LIKE @Prog)";

                    cmd.Parameters.Add("@Edu", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_edu"], "%");
                    cmd.Parameters.Add("@Sch", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_edu"], "%");
                    cmd.Parameters.Add("@Prog", SqlDbType.NVarChar, 50).Value = String.Concat("%", Request.Form["v_edu"], "%");
                }


                //if (!String.IsNullOrEmpty(Request.Form["v_exp"])) 
                //{
                //    if (Request.Form["v_exp"] != "A")
                //    {
                //        if (Request.Form["v_exp"] == "3") {
                //            whereClause.Add("ISNULL(B.Total_Yr, 0) < 3");
                //        }
                //        else if (Request.Form["v_exp"] == "5") {
                //            whereClause.Add("ISNULL(B.Total_Yr, 0) >= 3 and ISNULL(B.Total_Yr, 0) <=  5");
                //        }
                //        else if (Request.Form["v_exp"] == "10") {
                //            whereClause.Add("ISNULL(B.Total_Yr, 0) > 5 and ISNULL(B.Total_Yr, 0) <= 10");
                //        }
                //        else if (Request.Form["v_exp"] == "20") 
                //        {
                //            whereClause.Add("ISNULL(B.Total_Yr, 0) > 10 and ISNULL(B.Total_Yr, 0) <= 20");
                //        }
                //        else
                //            whereClause.Add("ISNULL(B.Total_Yr, 0) > 20");
                //    }
                //}

                if ((!String.IsNullOrEmpty(Request.Form["v_SelectGPA"])) && (!String.IsNullOrEmpty(Request.Form["v_gpa"])))
                {
                    if (Request.Form["v_gpa"] != "")
                    {
                        string temp_gpa = Request.Form["v_gpa"].Trim();
                        if (Request.Form["v_SelectGPA"] == "1")
                        {
                            whereClausegpagra.Add(" (LTRIM(RTRIM(ISNULL(XX.Grade, ''))) >= '" + temp_gpa + "' and ISNULL(XX.ResultType, '') = 'GPA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                        else if (Request.Form["v_SelectGPA"] == "2")
                        {
                            whereClausegpagra.Add(" (LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <= '" + temp_gpa + "' and ISNULL(XX.ResultType, '') = 'GPA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                        else if (Request.Form["v_SelectGPA"] == "3")
                        {
                            whereClausegpagra.Add(" (LTRIM(RTRIM(ISNULL(XX.Grade, ''))) = '" + temp_gpa + "' and ISNULL(XX.ResultType, '') = 'GPA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                    }
                }

                if ((!String.IsNullOrEmpty(Request.Form["v_SelectGrade"])) && (!String.IsNullOrEmpty(Request.Form["v_grade"])))
                {
                    if (Request.Form["v_grade"] != "")
                    {
                        string temp_gra = Request.Form["v_grade"].Trim();

                        if (Request.Form["v_SelectGrade"] == "1")
                        {
                            whereClausegpagra.Add(" (CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'DIST' THEN '1' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'CRED' THEN '2' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'PASS' THEN '3' ELSE '4' END END END <= '" + temp_gra + "' and ISNULL(XX.ResultType, '') = 'GRA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                        else if (Request.Form["v_SelectGrade"] == "2")
                        {
                            whereClausegpagra.Add(" (CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'DIST' THEN '1' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'CRED' THEN '2' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'PASS' THEN '3' ELSE '4' END END END >= '" + temp_gra + "' and ISNULL(XX.ResultType, '') = 'GRA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                        else if (Request.Form["v_SelectGrade"] == "3")
                        {
                            whereClausegpagra.Add(" (CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'DIST' THEN '1' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'CRED' THEN '2' ELSE CASE WHEN UPPER(LEFT(ISNULL(XX.Grade, ''),4)) = 'PASS' THEN '3' ELSE '4' END END END = '" + temp_gra + "' and ISNULL(XX.ResultType, '') = 'GRA' and LTRIM(RTRIM(ISNULL(XX.Grade, ''))) <> '')");
                        }
                    }
                }

                //int showInactive = -1;
                //if (String.IsNullOrEmpty(Request.Form["v_showinactive"]))
                //    showInactive = 0;
                //else
                //    showInactive = Request.Form["v_showinactive"] == "on" ? 1 : 0;

                //if (showInactive == 0)
                //{
                //    whereClause.Add("IsActive = 1");
                //}

                if ((!String.IsNullOrEmpty(Request.Form["v_SelectSalary"])) && (!String.IsNullOrEmpty(Request.Form["v_Salary"])))
                {
                    if (Request.Form["v_Salary"] != "")
                    {
                        string temp_salary = Request.Form["v_Salary"].Trim();
                        if (temp_salary.Length == 4)
                        {
                            temp_salary = "0" + temp_salary;
                        }

                        if (Request.Form["v_SelectSalary"] == "1")
                        {
                            whereClause.Add("CASE WHEN LEN(LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', '')))) = 4 THEN '0'+LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) ELSE LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) END >= '" + temp_salary + "' and LTRIM(RTRIM(ISNULL(A.ExpectedSalry, ''))) <> ''");
                        }
                        else if (Request.Form["v_SelectSalary"] == "2")
                        {
                            whereClause.Add("CASE WHEN LEN(LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', '')))) = 4 THEN '0'+LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) ELSE LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) END <= '" + temp_salary + "' and LTRIM(RTRIM(ISNULL(A.ExpectedSalry, ''))) <> ''");
                        }
                        else if (Request.Form["v_SelectSalary"] == "3")
                        {
                            whereClause.Add("CASE WHEN LEN(LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', '')))) = 4 THEN '0'+LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) ELSE LTRIM(RTRIM(REPLACE(REPLACE(ISNULL(A.ExpectedSalry, ''), '$', ''), ',', ''))) END = '" + temp_salary + "' and LTRIM(RTRIM(ISNULL(A.ExpectedSalry, ''))) <> ''");
                        }
                    }
                }


                for (int i = 0; i < whereClause.Count; i++)
                {
                    if (i == 0)
                        where = " where " + whereClause[i];
                    else
                        where += " and " + whereClause[i];
                }
                for (int i = 0; i < whereClausegpagra.Count; i++)
                {
                    if (i == 0)
                        wheregpagra = whereClausegpagra[i];
                    else
                        wheregpagra += " or " + whereClausegpagra[i];
                }
                if (wheregpagra != string.Empty)
                {
                    if (wheregpagra2 != string.Empty)
                    {
                        wheregpagra = "(" + wheregpagra + ") and " + wheregpagra2;
                    }
                    else
                    {
                        wheregpagra = "(" + wheregpagra + ")";
                    }
                }
                else
                {
                    if (wheregpagra2 != string.Empty)
                    {
                        wheregpagra = wheregpagra2;
                    }
                }
            }
            else
            {
                where = string.Empty;
                wheregpagra = string.Empty;
                wheregpagra2 = string.Empty;
            }

            try
            {
                cn.Open();
                cmd.Connection = cn;
                tempstring = "select A.ID,'' AS Token,ISNULL(A.RefNum, '') AS staffID, LTRIM(RTRIM(ISNULL(I.Eng_Surname, ''))) + ' ' + LTRIM(RTRIM(ISNULL(I.Eng_Othername, ''))) AS engName";
                tempstring += ", ISNULL(I.Chi_Name, '') AS chiName, ISNULL(J.[description], '') AS curPosition";
                tempstring += ", ISNULL(A.ExpectedSalry, 0) as expectedsalary, convert(nvarchar(10), A.AppliedDate, 126) AS fromDate, ISNULL(X.eng_description, '') AS district_desc";
                tempstring += ", ISNULL(C.Edu_Description, '') AS Education_Desc, ISNULL(C.ProgrammeName, '') AS ProgrammeName, ISNULL(C.Sch_Description, '') AS School_Desc";
                tempstring += ", ISNULL(C.ResultType_Result, '') AS ResultType_Result,ISNULL(I.FileName1,'') AS FileName1,'' AS CurrPosition,'' AS WorkingExp,'' AS expectedsalary,'' AS DateAvailable";
                tempstring += " from Application_P2_Hdr A LEFT JOIN Application_P1_Hdr I ON A.RefNum = I.RefNum";
                tempstring += " left join district X ON I.Addr_District = X.district";
                tempstring += " LEFT JOIN [dbo].[PreferFunc] J ON I.AppliedPosCode = J.[func]";
                tempstring += " LEFT JOIN";
                tempstring += " (SELECT xx.RefNum, (xx.SumDiff_Month) / 12 AS Total_Yr FROM (SELECT RefNum, SUM((LEFT(ToYear,4) * 12 + RIGHT(ToMonth,2)) - (LEFT(FromYear,4) * 12 + RIGHT(FromMonth,2))) As";
                tempstring += " SumDiff_Month from Application_P2_JobExp GROUP BY RefNum) xx) B ON A.RefNum = B.RefNum";
                tempstring += " LEFT JOIN (";
                tempstring += " SELECT AA.ID, AA.RefNum, CASE WHEN ISNULL(BB.education, '') = 'OTH' THEN ISNULL(AA.Edu_Others, '') ELSE ISNULL(BB.description, '') END as Edu_Description";
                tempstring += ", CASE WHEN ISNULL(DD.school, '') = 'OTH' THEN ISNULL(AA.Sch_Others, '') ELSE ISNULL(DD.description, '') END as Sch_Description";
                tempstring += ", AA.ProgrammeName AS ProgrammeName, AA.GradYear, AA.GradMonth, AA.ResultType, AA.Grade, AA.TotalScore";
                tempstring += ", CASE WHEN ISNULL(AA.ResultType, '') = 'GPA' THEN CASE WHEN LTRIM(RTRIM(ISNULL(AA.Grade, ''))) = '' AND LTRIM(RTRIM(ISNULL(AA.TotalScore, ''))) = '' THEN";
                tempstring += " '' ELSE LTRIM(RTRIM(ISNULL(AA.Grade, '')))+'/'+LTRIM(RTRIM(ISNULL(AA.TotalScore, ''))) END ELSE LTRIM(RTRIM(ISNULL(AA.Grade, ''))) END AS ResultType_Result FROM";
                tempstring += " Application_P1_Education AA, education BB,";
                tempstring += " (select X.RefNum, max(RIGHT('0'+convert(nvarchar(2), ISNULL(R.EduLevel,0)), 2)+RIGHT('0000'+convert(nvarchar(4), ISNULL(X.GradYear, 0)), 4)+RIGHT('00'+convert(nvarchar(2), ISNULL(X.GradMonth, 0)), 2)) AS Max_EduLevel";
                tempstring += " from Application_P1_Education X INNER JOIN education R ON X.Edu_Level = R.[education] GROUP BY RefNum) CC,";
                tempstring += " school DD where AA.RefNum = CC.RefNum and AA.Edu_Level = BB.education and AA.Sch_Name = DD.school";
                tempstring += " and RIGHT('0'+convert(nvarchar(2), ISNULL(BB.EduLevel,0)), 2)+RIGHT('0000'+convert(nvarchar(4), ISNULL(AA.GradYear, 0)), 4)+RIGHT('00'+convert(nvarchar(2), ISNULL(AA.GradMonth, 0)), 2) = CC.Max_EduLevel";
                tempstring += ") C ON A.RefNum = C.RefNum";



                if (where == "")
                {
                    if (wheregpagra == "")
                    { cmd.CommandText = tempstring; }
                    else
                    {
                        tempstring += " where exists (select * from  Application_P1_Education XX, education I, school J";
                        tempstring += " where XX.Edu_Level = I.education and XX.Sch_Name = J.school and XX.RefNum = A.RefNum and " + wheregpagra + ")";
                        cmd.CommandText = tempstring;
                    }
                }
                else
                {
                    if (wheregpagra == "")
                    {
                        cmd.CommandText = tempstring + " " + where;
                    }
                    else
                    {
                        tempstring += " " + where + " and exists (select * from  Application_P1_Education XX, education I, school J";
                        tempstring += " where XX.Edu_Level = I.education and XX.Sch_Name = J.school and XX.RefNum = A.RefNum and " + wheregpagra + ")";

                        cmd.CommandText = tempstring;
                    }
                }
                cmd.CommandType = CommandType.Text;

                cmd.Prepare();

                reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    tempstring = "select TOP 1 '' AS staffID, 'No record found !' AS engName, '' AS chiName, '' AS curPosition, 0 as expectedsalary, '' AS fromDate";
                    tempstring += ", '' AS district_desc, '' AS Education_Desc, '' AS ProgrammeName, '' AS School_Desc, '' AS ResultType_Result from Application_P2_Hdr";

                    cmd.CommandText = tempstring;
                    cmd.CommandType = CommandType.Text;
                    cmd.Prepare();
                    reader.Close();

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