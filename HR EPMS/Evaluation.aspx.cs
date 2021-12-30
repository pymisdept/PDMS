using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace HR_EPMS
{
    public partial class Evaluation : System.Web.UI.Page
    {


        private string cnStr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
        private SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            var refNo = Request.QueryString["RefNo"];
            string tempstring = string.Empty;


            //if (!Request.IsAuthenticated)
            //{
             //   HttpContext.Current.GetOwinContext().Authentication.Challenge(
             //   new AuthenticationProperties { RedirectUri = "/Evaluation?RefNo=" + refNo },
             //   OpenIdConnectAuthenticationDefaults.AuthenticationType);
            //}
            if (String.IsNullOrEmpty(refNo))
                Response.Redirect("Career.aspx");

            //v_interview_1_1.InnerHtml = "By Leung Fai Yiu Ken";
            //v_interview_1_2.InnerHtml = "Leung Fai Yiu Ken";
            //v_interview_2_1.InnerHtml = "By Michael Lui";
            //v_interview_2_2.InnerHtml = "Lui Wai Hung Michael";
            //v_interview_3_1.InnerHtml = "By Lee Chung Him Zeca";
            //v_interview_3_2.InnerHtml = "Lee Chung Him Zeca";
            string Approval1,Approval2,Approval3;
            Approval1 = "Tester1";
            Approval2 = "Tester2";
            Approval3 = "Tester3";
            v_interview_1_1.InnerHtml = "By "+Approval1;
            v_interview_1_2.InnerHtml = Approval1;
            v_interview_2_1.InnerHtml = "By "+Approval2;
            v_interview_2_2.InnerHtml = Approval2;
            v_interview_3_1.InnerHtml = "By "+Approval3;
            v_interview_3_2.InnerHtml = Approval3;

            var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            string email = userClaims?.FindFirst("preferred_username")?.Value;

            //foreach(var t in userClaims.Claims)
            //{
            //    email += t.Type + ", ";
            //}

            //anchorRefID.Attributes["href"] = "http://hr.pyengineering.com/hrms_Apply/ReportFrame.aspx?Report=Career_Report-prod.rpt&RefNo=" + refNo;
            anchorRefID.Attributes["href"] = "http://10.1.1.106/HRMStest/ReportFrame.aspx?Report=Career_Report.rpt&RefNo=" + refNo;

            if (Request.Form.Count > 0)
            {
                //string sql = "insert into Interview_Evaluation (Token,RefNum,Interview_Level,Qualification_Rating,Experience_Rating,LanguageAbility_Rating,CommunicationSkill_Rating,Maturity_Rating,Initative_Rating,SenseOfResponsibility_Rating,Stability_Rating,Attitude_Rating,Overall_Rating,StrengthWeakness,Interviewer_Email,Final_Decision,Date_Of_Interview,IsSubmitted) values (@token, @ref, @level, @qRating, @eRating, @lRating, @cRating, @mRating, @iRating, @rRating, @sRating, @aRating, @overallRating, @remarks, @interviewer, @final, GETDATE(), 0)";
                string sql2 = "update Interview_Evaluation set Qualification_Rating = @qRating, Experience_Rating = @eRating, LanguageAbility_Rating = @lRating, CommunicationSkill_Rating = @cRating, Maturity_Rating = @mRating, Initative_Rating = @iRating, SenseOfResponsibility_Rating = @rRating, Stability_Rating = @sRating, Attitude_Rating = @aRating, Overall_Rating = @overallRating, StrengthWeakness = @remarks where RefNum = @ref AND Interview_Level = @level";

                cn = new SqlConnection(cnStr);
                cn.Open();
                SqlCommand udcmd = new SqlCommand(sql2, cn);

                //cmd.Parameters.Add("@token", SqlDbType.NVarChar, 255).Value = EncryptClass.Encrypt("zecalee@pyengineering.com" + DateTime.Now.ToString("yyyyMMddhhmmss")); ;
                udcmd.Parameters.Add("@ref", SqlDbType.NVarChar, 20).Value = refNo;
                udcmd.Parameters.Add("@level", SqlDbType.Int).Value = Request.Form["e2_hidden_level"];
                udcmd.Parameters.Add("@qRating", SqlDbType.Int).Value = Request.Form["e2_quali"];
                udcmd.Parameters.Add("@eRating", SqlDbType.Int).Value = Request.Form["e2_exp"];
                udcmd.Parameters.Add("@lRating", SqlDbType.Int).Value = Request.Form["e2_lang"];
                udcmd.Parameters.Add("@cRating", SqlDbType.Int).Value = Request.Form["e2_comm"];
                udcmd.Parameters.Add("@mRating", SqlDbType.Int).Value = Request.Form["e2_maturity"];
                udcmd.Parameters.Add("@iRating", SqlDbType.Int).Value = Request.Form["e2_initiative"];
                udcmd.Parameters.Add("@rRating", SqlDbType.Int).Value = Request.Form["e2_sense"];
                udcmd.Parameters.Add("@sRating", SqlDbType.Int).Value = Request.Form["e2_stable"];
                udcmd.Parameters.Add("@aRating", SqlDbType.Int).Value = Request.Form["e2_attitude"];
                udcmd.Parameters.Add("@overallRating", SqlDbType.Int).Value = Request.Form["e2_overall"];
                udcmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 150).Value = Request.Form["e2_remarks"];
                //cmd.Parameters.Add("@interviewer", SqlDbType.NVarChar, 150).Value = email;
                //cmd.Parameters.Add("@final", SqlDbType.NVarChar, 100).Value = string.Empty;

                udcmd.ExecuteNonQuery();
                cn.Close();
            }

            if (refNo == string.Empty)
            {
                cRefNo.InnerHtml = refNo;
                cUser.InnerHtml = email;
            }
            else
            {
                cRefNo.InnerHtml = refNo;
                cUser.InnerHtml = email;


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

                cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = refNo;
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(46) && !String.IsNullOrEmpty(reader.GetString(46)))
                    { 
                        v_ref_name.InnerHtml = reader.GetString(46);
                    }
                    if (!reader.IsDBNull(47) && !String.IsNullOrEmpty(reader.GetString(47)))
                    {
                        v_ref_comp.InnerHtml = reader.GetString(47);
                    }
                    if (!reader.IsDBNull(48) && !String.IsNullOrEmpty(reader.GetString(48)))
                    {
                        v_ref_position.InnerHtml = reader.GetString(48);
                    }


                    if (!reader.IsDBNull(49) && !String.IsNullOrEmpty(reader.GetString(49)))
                    {
                        v_relat_name.InnerHtml = reader.GetString(49);
                    }

                    if (!reader.IsDBNull(50) && !String.IsNullOrEmpty(reader.GetString(50)))
                    {
                        v_relat_comp.InnerHtml = reader.GetString(50);
                    }
                    if (!reader.IsDBNull(51) && !String.IsNullOrEmpty(reader.GetString(51)))
                    {
                        v_relat_position.InnerHtml = reader.GetString(51);
                    }


                    if (!reader.IsDBNull(55) && !String.IsNullOrEmpty(reader.GetString(55)))
                    {
                        v_reference_employeeBefore.InnerHtml = reader.GetString(55);

                    }
                    if (v_reference_employeeBefore.InnerHtml == "Y")
                    { v_reference_employeeBefore.InnerHtml = "Yes"; }
                    else
                    { v_reference_employeeBefore.InnerHtml = "No"; }

                    if (!reader.IsDBNull(56) && !String.IsNullOrEmpty(reader.GetString(56)))
                    {
                        v_reference_guility.InnerHtml = reader.GetString(56);
                    }


                    if (v_reference_guility.InnerHtml == "Y")
                    { v_reference_guility.InnerHtml = "Yes"; }
                    else { v_reference_guility.InnerHtml = "No"; }



                    if (!reader.IsDBNull(57) && !String.IsNullOrEmpty(reader.GetString(57)))
                    {
                        v_reference_enquiryfromPrevEmployer.InnerHtml = reader.GetString(57);
                    }


                    if (v_reference_enquiryfromPrevEmployer.InnerHtml == "Y")
                    { v_reference_enquiryfromPrevEmployer.InnerHtml = "Yes"; }
                    else { v_reference_enquiryfromPrevEmployer.InnerHtml = "No"; }

                    if (!reader.IsDBNull(58) && !String.IsNullOrEmpty(reader.GetString(58)))
                    {
                        v_reference_injuiryleave.InnerHtml = reader.GetString(58);
                    }

                    if (v_reference_injuiryleave.InnerHtml == "Y")
                    { v_reference_injuiryleave.InnerHtml = "Yes"; }
                    else { v_reference_injuiryleave.InnerHtml = "No"; }



                    if (!reader.IsDBNull(21) && !String.IsNullOrEmpty(reader.GetString(21)))
                    {
                        v_Eng_name.InnerHtml = reader.GetString(21);
                    }
                    if (!reader.IsDBNull(22) && !String.IsNullOrEmpty(reader.GetString(22)))
                    {
                        if (v_Eng_name.InnerHtml == string.Empty)
                        { v_Eng_name.InnerHtml = reader.GetString(22); }
                        else
                        { v_Eng_name.InnerHtml = v_Eng_name.InnerHtml + " " + reader.GetString(22); }
                    }
                    if (!reader.IsDBNull(23) && !String.IsNullOrEmpty(reader.GetString(23)))
                    {
                        v_Chi_Name.InnerHtml = reader.GetString(23);
                    }
                    if (!reader.IsDBNull(19) && !String.IsNullOrEmpty(reader.GetString(19)))
                    {
                        v_name_with_AppliedPositionDesc.InnerHtml = v_Eng_name.InnerHtml + " - Application for " + reader.GetString(19);
                        v_name_with_AppliedPositionDesc2.InnerHtml = v_Eng_name.InnerHtml + " - Application for " + reader.GetString(19);
                    }

                    if (!String.IsNullOrEmpty(reader.GetString(27)))
                    {
                        if (v_address_1.InnerHtml == string.Empty) { v_address_1.InnerHtml = reader.GetString(27); }
                        else
                        { v_address_1.InnerHtml = v_address_1.InnerHtml + " " + reader.GetString(27); }
                    }
                    if (!String.IsNullOrEmpty(reader.GetString(28)))
                    {
                        if (v_address_1.InnerHtml == string.Empty) { v_address_1.InnerHtml = reader.GetString(28); }
                        else
                        { v_address_1.InnerHtml = v_address_1.InnerHtml + " " + reader.GetString(28); }
                    }
                    if (!String.IsNullOrEmpty(reader.GetString(29)))
                    {
                        if (v_address_1.InnerHtml == string.Empty) { v_address_1.InnerHtml = reader.GetString(29); }
                        else
                        { v_address_1.InnerHtml = v_address_1.InnerHtml + " " + reader.GetString(29); }
                    }
                    if (!String.IsNullOrEmpty(reader.GetString(25)))
                    {
                        if (v_address_1.InnerHtml == string.Empty) { v_address_1.InnerHtml = reader.GetString(25); }
                        else
                        { v_address_1.InnerHtml = v_address_1.InnerHtml + " " + reader.GetString(25); }
                    }

                    if (!String.IsNullOrEmpty(reader.GetString(26)))
                    {
                        if (v_address_1.InnerHtml == string.Empty) { v_address_1.InnerHtml = reader.GetString(26); }
                        else
                        { v_address_1.InnerHtml = v_address_1.InnerHtml + " " + reader.GetString(26); }
                    }
                    if (!String.IsNullOrEmpty(reader.GetString(30)))
                    {
                        h_phone.InnerHtml = reader.GetString(30);
                    }
                    if (!String.IsNullOrEmpty(reader.GetString(31)))
                    {
                        t_mobile.InnerHtml = reader.GetString(31);
                    }
                    v_DateOfBirth.InnerHtml = reader.GetDateTime(34).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(35) && !String.IsNullOrEmpty(reader.GetString(35)))
                    {
                        v_Nationality.InnerHtml = reader.GetString(35);
                    }

                    if (!String.IsNullOrEmpty(reader.GetString(32)))
                    {
                        v_ID.InnerHtml = reader.GetString(32);
                    }

                    if (!reader.IsDBNull(37) && !String.IsNullOrEmpty(reader.GetString(37)))
                    {
                        v_MaritalStatus.InnerHtml = reader.GetString(37);

                    }
                    if (!reader.IsDBNull(9) && !String.IsNullOrEmpty(reader.GetString(9)))
                    {
                        v_WorkingVisa.InnerHtml = reader.GetString(9);
                    }
                    v_ExpectedSalry.InnerHtml = reader.GetString(6);
                    if (!reader.IsDBNull(8) && !String.IsNullOrEmpty(reader.GetString(8)))
                    {
                        v_AvailableDate.InnerHtml = reader.GetString(8);
                    }

                }


                string imgfilename = string.Empty;
                if (reader.IsDBNull(44) || reader.GetString(44) == string.Empty)
                {
                    imgfilename = "https://career.pyengineering.com/Photo/profile.png"; //@"img/profile.png";
                }
                else
                {
                    //    int idx = reader.GetString(43).LastIndexOf('.');

                    try {
                        if (reader.GetString(43).Trim().Length > 0)
                        {
                            int idxLength = reader.GetString(43).Trim().Length;
                            int idx = reader.GetString(44).Trim().LastIndexOf('.');
                            imgfilename = "https://career.pyengineering.com/Photo/" + @reader.GetString(44);
                            //imgfilename = @"img/tmp/" + "profilePic_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(44).Substring(idx);
                            //if (reader.GetString(43).Trim().Substring(idxLength - 1, 1) == "\\")
                            //{

                            //    File.Copy(@reader.GetString(43) + @reader.GetString(44), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                            //}
                            //else
                            //{
                            //    File.Copy(@reader.GetString(43) + "\\" + @reader.GetString(44), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                            //}

                        }
                    }catch(Exception ex)
                    {

                    }
                    
                }

                v_profilepic.Attributes["src"] = imgfilename;


                tempstring = "EXEC [getEducationDetails] @staffid_2";
                reader.Close();
                cmd.Connection = cn;
                cmd.CommandText = tempstring;
                cmd.Parameters.Add("@staffid_2", SqlDbType.VarChar, 20).Value = refNo;
                reader = cmd.ExecuteReader();
                int tchk = 1;
                while ((reader.Read()) && (tchk <= 3))
                {
                    if (!reader.IsDBNull(18) && !String.IsNullOrEmpty(reader.GetString(18)))
                    {
                        if (tchk == 1)
                        {
                            v_Edu_Description_1.InnerHtml = reader.GetString(18);
                            if (!reader.IsDBNull(12))
                            {
                                v_GradYear_1.InnerHtml = reader.GetInt32(12).ToString();
                            }

                            if (!reader.IsDBNull(14))
                            {
                                if (v_GradYear_1.InnerHtml == string.Empty)
                                { v_GradYear_1.InnerHtml = reader.GetInt32(14).ToString(); }
                                else
                                { v_GradYear_1.InnerHtml = v_GradYear_1.InnerHtml + " - " + reader.GetInt32(14).ToString(); }
                            }

                            if (!reader.IsDBNull(7) && !String.IsNullOrEmpty(reader.GetString(7)))
                            { v_Sch_Desc_1.InnerHtml = reader.GetString(7); }
                            else
                            {
                                if (!reader.IsDBNull(8) && !String.IsNullOrEmpty(reader.GetString(8)))
                                { v_Sch_Desc_1.InnerHtml = reader.GetString(8); }
                                else
                                { v_Sch_Desc_1.InnerHtml = ""; }
                            }

                            if (!reader.IsDBNull(9) && !String.IsNullOrEmpty(reader.GetString(9)))
                            { v_ProgrammeName_1.InnerHtml = reader.GetString(9); }
                            else
                            { v_ProgrammeName_1.InnerHtml = ""; }
                        }
                        else
                        {
                            if (tchk == 2)
                            {
                                v_Edu_Description_2.InnerHtml = reader.GetString(18);
                                if (!reader.IsDBNull(12))
                                {
                                    v_GradYear_2.InnerHtml = reader.GetInt32(12).ToString();
                                }

                                if (!reader.IsDBNull(14))
                                {
                                    if (v_GradYear_2.InnerHtml == string.Empty)
                                    { v_GradYear_2.InnerHtml = reader.GetInt32(14).ToString(); }
                                    else
                                    { v_GradYear_2.InnerHtml = v_GradYear_2.InnerHtml + " - " + reader.GetInt32(14).ToString(); }
                                }

                                if (!reader.IsDBNull(7) && !String.IsNullOrEmpty(reader.GetString(7)))
                                { v_Sch_Desc_2.InnerHtml = reader.GetString(7); }
                                else
                                {
                                    if (!reader.IsDBNull(8) && !String.IsNullOrEmpty(reader.GetString(8)))
                                    { v_Sch_Desc_2.InnerHtml = reader.GetString(8); }
                                    else
                                    { v_Sch_Desc_2.InnerHtml = ""; }
                                }

                                if (!reader.IsDBNull(9) && !String.IsNullOrEmpty(reader.GetString(9)))
                                { v_ProgrammeName_2.InnerHtml = reader.GetString(9); }
                                else
                                { v_ProgrammeName_2.InnerHtml = ""; }
                            }
                            else
                            {
                                v_Edu_Description_3.InnerHtml = reader.GetString(18);
                                if (!reader.IsDBNull(12))
                                {
                                    v_GradYear_3.InnerHtml = reader.GetInt32(12).ToString();
                                }

                                if (!reader.IsDBNull(14))
                                {
                                    if (v_GradYear_3.InnerHtml == string.Empty)
                                    { v_GradYear_3.InnerHtml = reader.GetInt32(14).ToString(); }
                                    else
                                    { v_GradYear_3.InnerHtml = v_GradYear_3.InnerHtml + " - " + reader.GetInt32(14).ToString(); }
                                }

                                if (!reader.IsDBNull(7) && !String.IsNullOrEmpty(reader.GetString(7)))
                                { v_Sch_Desc_3.InnerHtml = reader.GetString(7); }
                                else
                                {
                                    if (!reader.IsDBNull(8) && !String.IsNullOrEmpty(reader.GetString(8)))
                                    { v_Sch_Desc_3.InnerHtml = reader.GetString(8); }
                                    else
                                    { v_Sch_Desc_3.InnerHtml = ""; }
                                }

                                if (!reader.IsDBNull(9) && !String.IsNullOrEmpty(reader.GetString(9)))
                                { v_ProgrammeName_3.InnerHtml = reader.GetString(9); }
                                else
                                { v_ProgrammeName_3.InnerHtml = ""; }
                            }
                        }
                    }
                    tchk = tchk + 1;
                }

                tempstring = "EXEC [getJobDetails] @staffid_3";
                reader.Close();
                cmd.Connection = cn;
                cmd.CommandText = tempstring;
                cmd.Parameters.Add("@staffid_3", SqlDbType.VarChar, 20).Value = refNo;
                reader = cmd.ExecuteReader();
                tchk = 1;
                while ((reader.Read()) && (tchk <= 3))
                {
                    if (!reader.IsDBNull(2) && !String.IsNullOrEmpty(reader.GetString(2)))
                    {
                        if (tchk == 1)
                        {
                            v_Exp_Description_1.InnerHtml = reader.GetString(2);
                            if (!reader.IsDBNull(5))
                            {
                                v_ExpYear_1.InnerHtml = reader.GetInt32(5).ToString();
                            }

                            if (!reader.IsDBNull(7))
                            {
                                if (v_ExpYear_1.InnerHtml == string.Empty)
                                { v_ExpYear_1.InnerHtml = reader.GetInt32(7).ToString(); }
                                else
                                { v_ExpYear_1.InnerHtml = v_ExpYear_1.InnerHtml + " - " + reader.GetInt32(7).ToString(); }
                            }

                            v_Position_1.InnerHtml = reader.GetString(3);
                            v_LeaveDes_1.InnerHtml = reader.GetString(12);

                        }
                        else
                        {
                            if (tchk == 2)
                            {
                                v_Exp_Description_2.InnerHtml = reader.GetString(2);
                                if (!reader.IsDBNull(5))
                                {
                                    v_ExpYear_2.InnerHtml = reader.GetInt32(5).ToString();
                                }

                                if (!reader.IsDBNull(7))
                                {
                                    if (v_ExpYear_2.InnerHtml == string.Empty)
                                    { v_ExpYear_2.InnerHtml = reader.GetInt32(7).ToString(); }
                                    else
                                    { v_ExpYear_2.InnerHtml = v_ExpYear_2.InnerHtml + " - " + reader.GetInt32(7).ToString(); }
                                }

                                v_Position_2.InnerHtml = reader.GetString(3);
                                v_LeaveDes_2.InnerHtml = reader.GetString(12);
                            }
                            else
                            {
                                v_Exp_Description_3.InnerHtml = reader.GetString(2);
                                if (!reader.IsDBNull(5))
                                {
                                    v_ExpYear_3.InnerHtml = reader.GetInt32(5).ToString();
                                }

                                if (!reader.IsDBNull(7))
                                {
                                    if (v_ExpYear_3.InnerHtml == string.Empty)
                                    { v_ExpYear_3.InnerHtml = reader.GetInt32(7).ToString(); }
                                    else
                                    { v_ExpYear_3.InnerHtml = v_ExpYear_3.InnerHtml + " - " + reader.GetInt32(7).ToString(); }

                                    v_Position_3.InnerHtml = reader.GetString(3);
                                    v_LeaveDes_3.InnerHtml = reader.GetString(12);

                                }
                            }
                        }
                    }
                    tchk = tchk + 1;
                }

                tempstring = "EXEC [getLangDetails] @staffid_4";
                reader.Close();
                cmd.Connection = cn;
                cmd.CommandText = tempstring;
                cmd.Parameters.Add("@staffid_4", SqlDbType.VarChar, 20).Value = refNo;

                reader = cmd.ExecuteReader();
                tchk = 1;
                while ((reader.Read()) && (tchk <= 3))
                {

                    if (tchk == 1)
                    {
                        v_skill_1.InnerHtml = reader.GetString(3);

                        if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                        {
                            if (reader.GetString(4).Trim() == "3")
                            {
                                if (v_skill_1.InnerHtml == string.Empty) { v_skill_1.InnerHtml = "(Excellent)"; }
                                else { v_skill_1.InnerHtml = v_skill_1.InnerHtml + " (Excellent)"; }
                            }
                            else
                            {
                                if (reader.GetString(4).Trim() == "2")
                                {
                                    if (v_skill_1.InnerHtml == string.Empty) { v_skill_1.InnerHtml = "(Good)"; }
                                    else { v_skill_1.InnerHtml = v_skill_1.InnerHtml + " (Good)"; }
                                }
                                else
                                {
                                    if (reader.GetString(4).Trim() == "1")
                                    {
                                        if (v_skill_1.InnerHtml == string.Empty) { v_skill_1.InnerHtml = "(Fair)"; }
                                        else { v_skill_1.InnerHtml = v_skill_1.InnerHtml + " (Fair)"; }
                                    }
                                    else
                                    {
                                        if (v_skill_1.InnerHtml == string.Empty) { v_skill_1.InnerHtml = "(N/A)"; }
                                        else { v_skill_1.InnerHtml = v_skill_1.InnerHtml + " (N/A)"; }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (v_skill_1.InnerHtml == string.Empty) { v_skill_1.InnerHtml = "(N/A)"; }
                            else { v_skill_1.InnerHtml = v_skill_1.InnerHtml + " (N/A)"; }
                        }
                    }
                    else
                    {
                        if (tchk == 2)
                        {
                            v_skill_2.InnerHtml = reader.GetString(3);

                            if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                            {
                                if (reader.GetString(4).Trim() == "3")
                                {
                                    if (v_skill_2.InnerHtml == string.Empty) { v_skill_2.InnerHtml = "(Excellent)"; }
                                    else { v_skill_2.InnerHtml = v_skill_2.InnerHtml + " (Excellent)"; }
                                }
                                else
                                {
                                    if (reader.GetString(4).Trim() == "2")
                                    {
                                        if (v_skill_2.InnerHtml == string.Empty) { v_skill_2.InnerHtml = "(Good)"; }
                                        else { v_skill_2.InnerHtml = v_skill_2.InnerHtml + " (Good)"; }
                                    }
                                    else
                                    {
                                        if (reader.GetString(4).Trim() == "1")
                                        {
                                            if (v_skill_2.InnerHtml == string.Empty) { v_skill_2.InnerHtml = "(Fair)"; }
                                            else { v_skill_2.InnerHtml = v_skill_2.InnerHtml + " (Fair)"; }
                                        }
                                        else
                                        {
                                            if (v_skill_2.InnerHtml == string.Empty) { v_skill_2.InnerHtml = "(N/A)"; }
                                            else { v_skill_2.InnerHtml = v_skill_2.InnerHtml + " (N/A)"; }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (v_skill_2.InnerHtml == string.Empty) { v_skill_2.InnerHtml = "(N/A)"; }
                                else { v_skill_2.InnerHtml = v_skill_2.InnerHtml + " (N/A)"; }
                            }
                        }
                        else
                        {
                            v_skill_3.InnerHtml = reader.GetString(3);

                            if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                            {
                                if (reader.GetString(4).Trim() == "3")
                                {
                                    if (v_skill_3.InnerHtml == string.Empty) { v_skill_3.InnerHtml = "(Excellent)"; }
                                    else { v_skill_3.InnerHtml = v_skill_3.InnerHtml + " (Excellent)"; }
                                }
                                else
                                {
                                    if (reader.GetString(4).Trim() == "2")
                                    {
                                        if (v_skill_3.InnerHtml == string.Empty) { v_skill_3.InnerHtml = "(Good)"; }
                                        else { v_skill_3.InnerHtml = v_skill_3.InnerHtml + " (Good)"; }
                                    }
                                    else
                                    {
                                        if (reader.GetString(4).Trim() == "1")
                                        {
                                            if (v_skill_3.InnerHtml == string.Empty) { v_skill_3.InnerHtml = "(Fair)"; }
                                            else { v_skill_3.InnerHtml = v_skill_3.InnerHtml + " (Fair)"; }
                                        }
                                        else
                                        {
                                            if (v_skill_3.InnerHtml == string.Empty) { v_skill_3.InnerHtml = "(N/A)"; }
                                            else { v_skill_3.InnerHtml = v_skill_3.InnerHtml + " (N/A)"; }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (v_skill_3.InnerHtml == string.Empty) { v_skill_3.InnerHtml = "(N/A)"; }
                                else { v_skill_3.InnerHtml = v_skill_3.InnerHtml + " (N/A)"; }
                            }
                        }
                    }
 

                    tchk = tchk + 1;
                }

                tempstring = "EXEC [getQualiDetails] @staffid_5";
                reader.Close();
                cmd.Connection = cn;
                cmd.CommandText = tempstring;
                cmd.Parameters.Add("@staffid_5", SqlDbType.VarChar, 20).Value = refNo;

                reader = cmd.ExecuteReader();
                tchk = 1;
                while ((reader.Read()) && (tchk <= 3))
                {

                    if (tchk == 1)
                    {
                        if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                        {
                             v_skill_4.InnerHtml = reader.GetString(4);

                             if (!reader.IsDBNull(5) && !String.IsNullOrEmpty(reader.GetString(5)))
                             {
                                if (v_skill_4.InnerHtml == string.Empty)
                                {
                                    v_skill_4.InnerHtml = " (" + reader.GetString(5);
                                    if (!reader.IsDBNull(7))
                                    {
                                        v_skill_4.InnerHtml = v_skill_4.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                    }
                                    else
                                    {
                                        v_skill_4.InnerHtml = v_skill_4.InnerHtml + ")";
                                    }
                                }
                                else
                                {
                                    v_skill_4.InnerHtml = v_skill_4.InnerHtml + " (" + reader.GetString(5);
                                    if (!reader.IsDBNull(7))
                                    {
                                        v_skill_4.InnerHtml = v_skill_4.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                    }
                                    else
                                    {
                                        v_skill_4.InnerHtml = v_skill_4.InnerHtml + ")";
                                    }
                                }
                             }
                        }
                    }
                    else
                    {
                        if (tchk == 2)
                        {
                            if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                            {
                                v_skill_5.InnerHtml = reader.GetString(4);

                                if (!reader.IsDBNull(5) && !String.IsNullOrEmpty(reader.GetString(5)))
                                {
                                    if (v_skill_5.InnerHtml == string.Empty)
                                    {
                                        v_skill_5.InnerHtml = " (" + reader.GetString(5);
                                        if (!reader.IsDBNull(7))
                                        {
                                            v_skill_5.InnerHtml = v_skill_5.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                        }
                                        else
                                        {
                                            v_skill_5.InnerHtml = v_skill_5.InnerHtml + ")";
                                        }
                                    }
                                    else
                                    {
                                        v_skill_5.InnerHtml = v_skill_5.InnerHtml + " (" + reader.GetString(5);
                                        if (!reader.IsDBNull(7))
                                        {
                                            v_skill_5.InnerHtml = v_skill_5.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                        }
                                        else
                                        {
                                            v_skill_5.InnerHtml = v_skill_5.InnerHtml + ")";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!reader.IsDBNull(4) && !String.IsNullOrEmpty(reader.GetString(4)))
                            {
                                v_skill_6.InnerHtml = reader.GetString(4);

                                if (!reader.IsDBNull(5) && !String.IsNullOrEmpty(reader.GetString(5)))
                                {
                                    if (v_skill_6.InnerHtml == string.Empty)
                                    {
                                        v_skill_6.InnerHtml = " (" + reader.GetString(5);
                                        if (!reader.IsDBNull(7))
                                        {
                                            v_skill_6.InnerHtml = v_skill_6.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                        }
                                        else
                                        {
                                            v_skill_6.InnerHtml = v_skill_6.InnerHtml + ")";
                                        }
                                    }
                                    else
                                    {
                                        v_skill_6.InnerHtml = v_skill_6.InnerHtml + " (" + reader.GetString(5);
                                        if (!reader.IsDBNull(7))
                                        {
                                            v_skill_6.InnerHtml = v_skill_6.InnerHtml + " in " + reader.GetInt32(7).ToString() + ")";
                                        }
                                        else
                                        {
                                            v_skill_6.InnerHtml = v_skill_6.InnerHtml + ")";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    tchk = tchk + 1;
                }

                if (v_skill_4.InnerHtml == string.Empty) { v_skill_4.InnerHtml = "N/A"; }
                if (v_skill_5.InnerHtml == string.Empty) { v_skill_5.InnerHtml = "N/A"; }
                if (v_skill_6.InnerHtml == string.Empty) { v_skill_6.InnerHtml = "N/A"; }


            }
        }
    }
}