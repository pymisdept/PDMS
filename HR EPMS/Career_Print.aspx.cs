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
using log4net;

namespace HR_EPMS
{
    public partial class Career_Print : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        private SqlConnection cn;
        private static readonly ILog TxtLog = LogManager.GetLogger(typeof(Career_Print));
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            string sid = Request.QueryString["sid"];
            string tempstring = string.Empty;


            if (String.IsNullOrEmpty(sid))
                Response.Redirect("Career.aspx");


            cn.Open();
            cmd.Connection = cn;
            tempstring = "SELECT A.ID, ISNULL(A.RefNum, '') AS RefNum, ISNULL(A.JobRefNum, '') AS JobRefNum, ISNULL(A.AppliedDate, convert(datetime, '')), ISNULL(A.ModifiedDate, convert(datetime, ''))";
            tempstring += ", ISNULL(A.Remarks, ''), ISNULL(A.ExpectedSalry, ''), ISNULL(A.AvailableDateOpt, ''), CASE WHEN UPPER(ISNULL(A.AvailableDateOpt, '')) = 'OTH' THEN ISNULL(A.AvailableDateOth, '') ELSE ISNULL(B.AvaDate_Desc, '') END";
            tempstring += ", CASE WHEN ISNULL(A.WorkingVISA, 'N') = 'N' THEN 'NO' ELSE 'Y' END";
            tempstring += ", A.HTKOpt, A.HTKOth, ISNULL(A.FilePath, ''), ISNULL(A.FileName1, ''), ISNULL(A.FileName2, ''), ISNULL(A.FileName3, ''), ISNULL(A.FileName4, ''), ISNULL(A.FileName5, ''), A.Status, ISNULL(A.AppliedPositionDesc, '')";
            tempstring += ", ISNULL(A.Salutation, ''), ISNULL(A.Eng_Surname, ''), ISNULL(A.Eng_Othername, ''), ISNULL(A.Chi_Name, ''), ISNULL(A.Email, ''), ISNULL(C.subdistrict_eng_desc, '')";

            tempstring += ", CASE WHEN ISNULL(Addr_District, '') = 'HK' THEN 'HONG KONG' ELSE CASE WHEN ISNULL(Addr_District, '') = 'KL' THEN 'KOWLOON' ELSE CASE WHEN ISNULL(Addr_District, '') = 'NT' THEN 'NEW TERRITORIES' ELSE '' END END END, ISNULL(A.Addr_1, ''), ISNULL(A.Addr_2, ''), ISNULL(A.Addr_3, '')";

            tempstring += ", ISNULL(A.Phone, ''), ISNULL(A.Mobile, ''), ISNULL(A.ID_Card_No, ''), ISNULL(A.AliasName, ''), DateOfBirth, Nationality, SpouseName";
            tempstring += ", CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'SINGLE' THEN 'Single' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'MARRIED' THEN 'Married' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'WIDOWED' THEN 'Widowed' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'DIVORCED' THEN 'Divorced' ELSE '' END END END END AS MaritalStatus, SpouseHKID, EmergencyContactPerson, EmergencyContactRelationship";
            tempstring += ", EmergencyContactAddr, EmergencyContactPhone, FilePhotoPath, FilePhotoName1, FileSignatureName";
            tempstring += ", ISNULL(A.Referee_Name, ''), ISNULL(A.Referee_Company_Position, ''), ISNULL(A.Referee_RelationShip, ''), WorkPerson_Name";
            tempstring += ", WorkPerson_Company_Position, WorkPerson_RelationShip, EnglishTypeWPM, ChineseTypeWPM, OtherSkills";
            tempstring += ", reference_employeeBefore, reference_guility, reference_enquiryfromPrevEmployer, reference_injuiryleave, reference_TxtInputRef_Guility";
            tempstring += ", reference_TxtInputRef_enquiryfromPrevEmployer, reference_TxtInputRef_injuiryleave, 1 AS isActive";

            tempstring += ", CASE WHEN ISNULL(A.HTKOpt, '') = 'RT' THEN 'Recruitment Talk' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'JF' THEN 'Job Fair' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'JDB' THEN 'JobsDB' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'CW' THEN 'Company Website' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'OTH' THEN ISNULL(A.HTKOth, '') END END END END END AS HTKOth";
            tempstring += " FROM Application_Hdr A";
            tempstring += " LEFT JOIN";
            tempstring += " (select ISNULL(Type, '') AS AvaDate_Type, ISNULL(Code, '') AS AvaDate_Code, ISNULL(description, '') AS AvaDate_Desc from dbo.CodeTable where UPPER(ISNULL(Type, '')) = 'AVADATE') B ON";
            tempstring += " ISNULL(A.AvailableDateOpt, '') = B.AvaDate_Code";

            tempstring += " LEFT JOIN";
            tempstring += " subdistrict C ON";
            tempstring += " ISNULL(A.Addr_Subdistrict, '') = C.subdistrict_code";

            tempstring += " LEFT JOIN";
            tempstring += " district D ON";
            tempstring += " ISNULL(A.Addr_District, '') = D.district";

            cmd.CommandText = tempstring + " where RefNum = @staffid";

            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                v_RefNum.Text = reader.GetString(1);
                v_AppliedDate.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                v_ExpectedSalry.Text = reader.GetString(6);
                if (!reader.IsDBNull(8) && !String.IsNullOrEmpty(reader.GetString(8)))
                {
                    v_AvailableDate.Text = reader.GetString(8);
                }

                if (!reader.IsDBNull(9) && !String.IsNullOrEmpty(reader.GetString(9)))
                {
                    v_WorkingVisa.Text = reader.GetString(9);
                }

                if (!reader.IsDBNull(19) && !String.IsNullOrEmpty(reader.GetString(19)))
                {
                    v_AppliedPositionDesc.Text = reader.GetString(19);
                }
                if (!reader.IsDBNull(20) && !String.IsNullOrEmpty(reader.GetString(20)))
                {
                    v_Salutation.Text = reader.GetString(20);
                }

                if (!reader.IsDBNull(21) && !String.IsNullOrEmpty(reader.GetString(21)))
                {
                    v_Eng_Surname.Text = reader.GetString(21);
                }
                if (!reader.IsDBNull(22) && !String.IsNullOrEmpty(reader.GetString(22)))
                {
                    v_Eng_Othername.Text = reader.GetString(22);
                }
                if (!reader.IsDBNull(23) && !String.IsNullOrEmpty(reader.GetString(23)))
                {
                    v_Chi_Name.Text = reader.GetString(23);
                }

                if (!reader.IsDBNull(24) && !String.IsNullOrEmpty(reader.GetString(24)))
                {
                    v_Email.Text = reader.GetString(24);
                }

                if (!String.IsNullOrEmpty(reader.GetString(25)))
                {
                    v_Addr_Subdistrict.Text = reader.GetString(25);
                }

                if (!String.IsNullOrEmpty(reader.GetString(26)))
                {
                    v_Addr_District.Text = reader.GetString(26);
                }

                if (!String.IsNullOrEmpty(reader.GetString(27)))
                {
                    v_Addr_1.Text = reader.GetString(27);
                }
                if (!String.IsNullOrEmpty(reader.GetString(28)))
                {
                    v_Addr_2.Text = reader.GetString(28);
                }
                if (!String.IsNullOrEmpty(reader.GetString(29)))
                {
                    v_Addr_3.Text = reader.GetString(29);
                }

                if (!String.IsNullOrEmpty(reader.GetString(30)))
                {
                    v_Phone.Text = reader.GetString(30);
                }
                if (!String.IsNullOrEmpty(reader.GetString(31)))
                {
                    v_Mobile.Text = reader.GetString(31);
                }



                if (!String.IsNullOrEmpty(reader.GetString(32)))
                {
                    v_ID.Text = reader.GetString(32);
                }
                if (!String.IsNullOrEmpty(reader.GetString(33)))
                {
                    v_AliasName.Text = reader.GetString(33);
                }



                v_DateOfBirth.Text = reader.GetDateTime(34).ToString("yyyy-MM-dd");
                if (!reader.IsDBNull(35) && !String.IsNullOrEmpty(reader.GetString(35)))
                {
                    v_Nationality.Text = reader.GetString(35);
                }
                if (!reader.IsDBNull(36) && !String.IsNullOrEmpty(reader.GetString(36)))
                {
                    v_SpouseName.Text = reader.GetString(36);
                }

                if (!reader.IsDBNull(37) && !String.IsNullOrEmpty(reader.GetString(37)))
                {
                    v_MaritalStatus.Text = reader.GetString(37);

                }
                if (!reader.IsDBNull(38) && !String.IsNullOrEmpty(reader.GetString(38)))
                {
                    v_SpouseHKID.Text = reader.GetString(38);
                }
                if (!reader.IsDBNull(39) && !String.IsNullOrEmpty(reader.GetString(39)))
                {
                    v_EmergencyContactPerson.Text = reader.GetString(39);
                }
                if (!reader.IsDBNull(40) && !String.IsNullOrEmpty(reader.GetString(40)))
                {
                    v_EmergencyContactRelationship.Text = reader.GetString(40);
                }
                if (!reader.IsDBNull(41) && !String.IsNullOrEmpty(reader.GetString(41)))
                {
                    v_EmergencyContactAddr.Text = reader.GetString(41);
                }
                if (!reader.IsDBNull(42) && !String.IsNullOrEmpty(reader.GetString(42)))
                {
                    v_EmergencyContactPhone.Text = reader.GetString(42);
                }
                if (!reader.IsDBNull(52))
                {
                    v_EnglishTypeWPM.Text = reader.GetInt32(52).ToString();
                }
                if (!reader.IsDBNull(53))
                {
                    v_ChineseTypeWPM.Text = reader.GetInt32(53).ToString();
                }
                if (!reader.IsDBNull(54) && !String.IsNullOrEmpty(reader.GetString(54)))
                {
                    v_OtherSkills.Text = reader.GetString(54);
                }

                if (!reader.IsDBNull(55) && !String.IsNullOrEmpty(reader.GetString(55)))
                {
                    v_reference_employeeBefore.Text = reader.GetString(55);

                }
                if (v_reference_employeeBefore.Text == "Y")
                { v_reference_employeeBefore.Text = "Yes"; }
                else
                { v_reference_employeeBefore.Text = "No"; }

                if (!reader.IsDBNull(56) && !String.IsNullOrEmpty(reader.GetString(56)))
                {
                    v_reference_guility.Text = reader.GetString(56);
                }


                if (v_reference_guility.Text == "Y")
                { v_reference_guility.Text = "Yes"; }
                else { v_reference_guility.Text = "No"; }



                if (!reader.IsDBNull(57) && !String.IsNullOrEmpty(reader.GetString(57)))
                {
                    v_reference_enquiryfromPrevEmployer.Text = reader.GetString(57);
                }


                if (v_reference_enquiryfromPrevEmployer.Text == "Y")
                { v_reference_enquiryfromPrevEmployer.Text = "Yes"; }
                else { v_reference_enquiryfromPrevEmployer.Text = "No"; }

                if (!reader.IsDBNull(58) && !String.IsNullOrEmpty(reader.GetString(58)))
                {
                    v_reference_injuiryleave.Text = reader.GetString(58);
                }

                if (v_reference_injuiryleave.Text == "Y")
                { v_reference_injuiryleave.Text = "Yes"; }
                else { v_reference_injuiryleave.Text = "No"; }


                if (!reader.IsDBNull(59) && !String.IsNullOrEmpty(reader.GetString(59)))
                {
                    v_reference_TxtInputRef_Guility.Text = reader.GetString(59);
                }

                if (!reader.IsDBNull(60) && !String.IsNullOrEmpty(reader.GetString(60)))
                {
                    v_reference_TxtInputRef_enquiryfromPrevEmployer.Text = reader.GetString(60);
                }

                if (!reader.IsDBNull(61) && !String.IsNullOrEmpty(reader.GetString(61)))
                {
                    v_reference_TxtInputRef_injuiryleave.Text = reader.GetString(61);
                }

                if (!reader.IsDBNull(63) && !String.IsNullOrEmpty(reader.GetString(63)))
                {
                    v_HTKOth.Text = reader.GetString(63);
                }


                string imgfilename = string.Empty;
                if (reader.IsDBNull(44) || reader.GetString(44) == string.Empty)
                {
                    imgfilename = @"img/profile.png";
                }
                else
                {
                    //    int idx = reader.GetString(43).LastIndexOf('.');


                    if (reader.GetString(43).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(43).Trim().Length;
                        int idx = reader.GetString(44).Trim().LastIndexOf('.');
                        imgfilename = @"img/tmp/" + "profilePic_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(44).Substring(idx);
                        if (reader.GetString(43).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(43) + @reader.GetString(44)) == false && File.Exists(@reader.GetString(43).Replace("C:\\Applications", "V:") + @reader.GetString(44)) == true)
                            {
                                File.Copy(@reader.GetString(43).Replace("C:\\Applications", "V:") + @reader.GetString(44), @reader.GetString(43) + @reader.GetString(44));
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(43) + "\\" + @reader.GetString(44)) == false && File.Exists(@reader.GetString(43).Replace("C:\\Applications", "V:") + "\\" + @reader.GetString(44)) == true)
                            {
                                //File.Copy(@reader.GetString(43) + "\\" + @reader.GetString(44), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                                File.Copy(@reader.GetString(43).Replace("C:\\Applications", "V:") + "\\" + @reader.GetString(44), @reader.GetString(43) + "\\" + @reader.GetString(44));
                            }
                        }
                    }
                }

                v_profilepic.Attributes["src"] = imgfilename;
               
                if (reader.IsDBNull(45) || reader.GetString(45) == string.Empty)
                {
                    TxtLog.Info("The field of photo is null or empty");
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(45).Trim().LastIndexOf('.');
                        try
                        {
                            if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                            {
                                //if (File.Exists(@reader.GetString(12) + @reader.GetString(45)) == false && File.Exists(@reader.GetString(12).Replace("C:\\Applications", "V:") + @reader.GetString(45)) == true)
                                // && File.Exists("V://RecruitFileUpload//" + @reader.GetString(45)) == true
                                if (File.Exists(@reader.GetString(12) + @reader.GetString(45)) == false)
                                {
                                    File.Copy(@reader.GetString(12).Replace("C:\\Applications", "V:") + @reader.GetString(45), @reader.GetString(12) + @reader.GetString(45));
                                    File.Copy("V:\\RecruitFileUpload\\" + @reader.GetString(45), @reader.GetString(12) + @reader.GetString(45));
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                //if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(45)) == false && File.Exists(@reader.GetString(12).Replace("C:\\Applications", "V:") + "\\" + @reader.GetString(45)) == true)
                                // && File.Exists("V://RecruitFileUpload//" + @reader.GetString(45)) == true
                                if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(45)) == false)
                                {
                                    File.Copy("V:\\RecruitFileUpload\\" + @reader.GetString(45), @reader.GetString(12) + "\\" + @reader.GetString(45));
                                }
                                else
                                {
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            TxtLog.Error(ex.Message);
                        }

                    }
                }


                Response.Redirect("http://hr.pyengineering.com/hrms_Apply/ReportFrame.aspx?Report=Career_Report-prod.rpt&RefNo=" + sid);

                //    File.Copy(@reader.GetString(3), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                //}

                //v_profilepic.Attributes["src"] = imgfilename;


            }


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