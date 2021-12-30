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
    public partial class GraduateDetails : System.Web.UI.Page
    {

        private string cnStr = ConfigurationManager.ConnectionStrings["cnFreshCareer"].ConnectionString;
        private SqlConnection cn;

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
            //tempstring = "SELECT A.ID, ISNULL(A.RefNum, '') AS RefNum, ISNULL(A.JobRefNum, '') AS JobRefNum, ISNULL(A.AppliedDate, convert(datetime, '')), ISNULL(A.ModifiedDate, convert(datetime, ''))";
            //tempstring += ", ISNULL(A.Remarks, ''), ISNULL(A.ExpectedSalry, ''), ISNULL(A.AvailableDateOpt, ''), CASE WHEN UPPER(ISNULL(A.AvailableDateOpt, '')) = 'OTH' THEN ISNULL(A.AvailableDateOth, '') ELSE ISNULL(B.AvaDate_Desc, '') END";
            //tempstring += ", CASE WHEN ISNULL(A.WorkingVISA, 'N') = 'N' THEN 'NO' ELSE 'Y' END";
            //tempstring += ", A.HTKOpt, A.HTKOth, ISNULL(A.FilePath, ''), ISNULL(A.FileName1, ''), ISNULL(A.FileName2, ''), ISNULL(A.FileName3, ''), ISNULL(A.FileName4, ''), ISNULL(A.FileName5, ''), A.Status, ISNULL(A.AppliedPositionDesc, '')";
            //tempstring += ", ISNULL(A.Salutation, ''), ISNULL(A.Eng_Surname, ''), ISNULL(A.Eng_Othername, ''), ISNULL(A.Chi_Name, ''), ISNULL(A.Email, ''), ISNULL(C.subdistrict_eng_desc, '')";

            //tempstring += ", CASE WHEN ISNULL(Addr_District, '') = 'HK' THEN 'HONG KONG' ELSE CASE WHEN ISNULL(Addr_District, '') = 'KL' THEN 'KOWLOON' ELSE CASE WHEN ISNULL(Addr_District, '') = 'NT' THEN 'NEW TERRITORIES' ELSE '' END END END, ISNULL(A.Addr_1, ''), ISNULL(A.Addr_2, ''), ISNULL(A.Addr_3, '')";
            //tempstring += ", ISNULL(A.Phone, ''), ISNULL(A.Mobile, ''), ISNULL(A.ID_Card_No, ''), ISNULL(A.AliasName, ''), DateOfBirth, Nationality, SpouseName";
            //tempstring += ", CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'SINGLE' THEN 'Single' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'MARRIED' THEN 'Married' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'WIDOWED' THEN 'Widowed' ELSE CASE WHEN UPPER(ISNULL(MaritalStatus, '')) = 'DIVORCED' THEN 'Divorced' ELSE '' END END END END AS MaritalStatus, SpouseHKID, EmergencyContactPerson, EmergencyContactRelationship";
            //tempstring += ", EmergencyContactAddr, EmergencyContactPhone, FilePhotoPath, FilePhotoName1, FileSignatureName";
            //tempstring += ", ISNULL(A.Referee_Name, ''), ISNULL(A.Referee_Company_Position, ''), ISNULL(A.Referee_RelationShip, ''), WorkPerson_Name";
            //tempstring += ", WorkPerson_Company_Position, WorkPerson_RelationShip, EnglishTypeWPM, ChineseTypeWPM, OtherSkills";
            //tempstring += ", reference_employeeBefore, reference_guility, reference_enquiryfromPrevEmployer, reference_injuiryleave, reference_TxtInputRef_Guility";
            //tempstring += ", reference_TxtInputRef_enquiryfromPrevEmployer, reference_TxtInputRef_injuiryleave, isActive";
            //tempstring += " FROM Application_Hdr A";
            //tempstring += " LEFT JOIN";
            //tempstring += " (select ISNULL(Type, '') AS AvaDate_Type, ISNULL(Code, '') AS AvaDate_Code, ISNULL(description, '') AS AvaDate_Desc from dbo.CodeTable where UPPER(ISNULL(Type, '')) = 'AVADATE') B ON";
            //tempstring += " ISNULL(A.AvailableDateOpt, '') = B.AvaDate_Code";
            //tempstring += " LEFT JOIN";
            //tempstring += " subdistrict C ON";
            //tempstring += " ISNULL(A.Addr_Subdistrict, '') = C.subdistrict_code";
            //tempstring += " LEFT JOIN";
            //tempstring += " district D ON";
            //tempstring += " ISNULL(A.Addr_District, '') = D.district";


            tempstring = "SELECT A.ID, ISNULL(A.RefNum, '') AS RefNum, '' AS JobRefNum";
            tempstring += ", ISNULL(A.AppliedDate, convert(datetime, ''))";
            tempstring += ", ISNULL(A.ModifiedDate, convert(datetime, ''))";
            tempstring += ", ISNULL(A.Remarks, ''), ISNULL(A.ExpectedSalry, ''), ISNULL(A.AvailableDateOpt, ''), CASE WHEN UPPER(ISNULL(A.AvailableDateOpt, '')) = 'OTH' THEN ISNULL(A.AvailableDateOth, '') ELSE ISNULL(B.AvaDate_Desc, '') END";
            tempstring += ", CASE WHEN ISNULL(A.WorkingVISA, 'N') = 'N' THEN 'NO' ELSE 'YES' END";
            tempstring += ", A.HTKOpt, A.HTKOth, ISNULL(A.FilePath, ''), ISNULL(A.FileName1, ''), ISNULL(A.FileName2, ''), ISNULL(A.FileName3, ''), ISNULL(A.FileName4, ''), ISNULL(A.FileName5, '')";
            tempstring += ", A.Status, ISNULL(J.description, '') AS AppliedPositionDesc";
            tempstring += ", ISNULL(I.Salutation, ''), ISNULL(I.Eng_Surname, ''), ISNULL(I.Eng_Othername, ''), ISNULL(I.Chi_Name, '')";
            tempstring += ", ISNULL(I.Email, ''), ISNULL(I.Addr_Subdistrict, '')";
            tempstring += ", CASE WHEN ISNULL(I.Addr_District, '') = '' THEN '' ELSE CASE WHEN ISNULL(D.eng_description, '') = '' THEN '' ELSE ISNULL(D.eng_description, '') END END";
            tempstring += ", CASE WHEN ISNULL(I.Addr_Room, '') = '' THEN CASE WHEN ISNULL(I.Addr_Floor, '') = '' THEN '' ELSE 'Floor ' + LTRIM(RTRIM(ISNULL(I.Addr_Floor, ''))) END ELSE";
            tempstring += " CASE WHEN ISNULL(I.Addr_Floor, '') = '' THEN 'Room ' + LTRIM(RTRIM(ISNULL(I.Addr_Room, ''))) ELSE 'Room ' + LTRIM(RTRIM(ISNULL(I.Addr_Room, ''))) + ' Floor ' + LTRIM(RTRIM(ISNULL(I.Addr_Floor, ''))) END END AS Addr_1";
            tempstring += ", CASE WHEN ISNULL(I.Addr_House, '') = '' THEN LTRIM(RTRIM(ISNULL(I.Addr_Building, ''))) ELSE CASE WHEN ISNULL(I.Addr_Building, '') = '' THEN '' ELSE LTRIM(RTRIM(ISNULL(I.Addr_House, ''))) + ' ' + LTRIM(RTRIM(ISNULL(I.Addr_Building, ''))) END END AS Addr_2";
            tempstring += ", ISNULL(I.Addr_Street, '') AS Addr_3";
            tempstring += ", ISNULL(I.Phone, ''), '' AS Mobile";
            tempstring += ", '' AS ID_Card_No, '' AS AliasName, convert(datetime, '', 112) AS DateOfBirth";
            tempstring += ", '' AS Nationality, '' AS SpouseName";
            tempstring += ", '' AS MaritalStatus, '' AS SpouseHKID, '' AS EmergencyContactPerson, '' AS EmergencyContactRelationship";
            tempstring += ", '' AS EmergencyContactAddr, '' AS EmergencyContactPhone, '' AS FilePhotoPath, '' AS FilePhotoName1, '' AS FileSignatureName";
            tempstring += ", '' AS Referee_Name, '' AS Referee_Company_Position, '' AS Referee_RelationShip, '' AS WorkPerson_Name";
            tempstring += ", '' AS WorkPerson_Company_Position, '' AS WorkPerson_RelationShip, 0 AS EnglishTypeWPM, 0 AS ChineseTypeWPM, '' AS OtherSkills";
            tempstring += ", '' AS reference_employeeBefore, '' AS reference_guility, '' AS reference_enquiryfromPrevEmployer";
            tempstring += ", '' AS reference_injuiryleave, '' AS reference_TxtInputRef_Guility";
            tempstring += ", '' AS reference_TxtInputRef_enquiryfromPrevEmployer, '' AS reference_TxtInputRef_injuiryleave, 1 AS isActive";
            tempstring += ", CASE WHEN ISNULL(A.HTKOpt, '') = 'RT' THEN 'Recruitment Talk' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'JF' THEN 'Job Fair' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'JDB' THEN 'JobsDB' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'CW' THEN 'Company Website' ELSE CASE WHEN ISNULL(A.HTKOpt, '') = 'OTH' THEN ISNULL(A.HTKOth, '') END END END END END AS HTKOth";
            tempstring += " from Application_P2_Hdr A LEFT JOIN Application_P1_Hdr I ON A.RefNum = I.RefNum";
            tempstring += " LEFT JOIN [dbo].[PreferFunc] J ON I.AppliedPosCode = J.[func]";
            tempstring += " LEFT JOIN";
            tempstring += " (select ISNULL(Type, '') AS AvaDate_Type, ISNULL(Code, '') AS AvaDate_Code, ISNULL(description, '') AS AvaDate_Desc from dbo.CodeTable where UPPER(ISNULL(Type, '')) = 'AVADATE') B ON";
            tempstring += " ISNULL(A.AvailableDateOpt, '') = B.AvaDate_Code";
            tempstring += " LEFT JOIN";
            tempstring += " district D ON";
            tempstring += " ISNULL(I.Addr_District, '') = D.district";

            cmd.CommandText = tempstring + " where A.RefNum = @staffid";

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


                string lfile1 = string.Empty;
                string lfile2 = string.Empty;
                string lfile3 = string.Empty;
                string lfile4 = string.Empty;
                string lfile5 = string.Empty;

                string imgattfilename1 = string.Empty;
                string imgfilename1 = string.Empty;
                if (reader.IsDBNull(13) || reader.GetString(13) == string.Empty)
                {
                    imgattfilename1 = @"img/profile.png";
                    imgfilename1 = "";
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(13).Trim().LastIndexOf('.');
                        imgattfilename1 = @"img/tmp/" + "attfile1_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(13).Substring(idx);
                        imgfilename1 = reader.GetString(13);
                        if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(12) + @reader.GetString(13)) == true)
                            {
                                File.Copy(@reader.GetString(12) + @reader.GetString(13), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename1);
                            }
                            else
                            {
                                lfile1 = "N";
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(13)) == true)
                            {
                                File.Copy(@reader.GetString(12) + "\\" + @reader.GetString(13), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename1);
                            }
                            else
                            {
                                lfile1 = "N";
                            }
                        }

                    }
                }

                string imgattfilename2 = string.Empty;
                string imgfilename2 = string.Empty;
                if (reader.IsDBNull(14) || reader.GetString(14) == string.Empty)
                {
                    imgattfilename2 = @"img/profile.png";
                    imgfilename2 = "";
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(14).Trim().LastIndexOf('.');
                        imgattfilename2 = @"img/tmp/" + "attfile2_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(14).Substring(idx);
                        imgfilename2 = reader.GetString(14);
                        if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(12) + @reader.GetString(14)) == true)
                            {
                                File.Copy(@reader.GetString(12) + @reader.GetString(14), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename2);
                            }
                            else
                            {
                                lfile2 = "N";
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(14)) == true)
                            {
                                File.Copy(@reader.GetString(12) + "\\" + @reader.GetString(14), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename2);
                            }
                            else
                            {
                                lfile2 = "N";
                            }
                        }

                    }
                }

                string imgattfilename3 = string.Empty;
                string imgfilename3 = string.Empty;
                if (reader.IsDBNull(15) || reader.GetString(15) == string.Empty)
                {
                    imgattfilename3 = @"img/profile.png";
                    imgfilename3 = "";
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(15).Trim().LastIndexOf('.');
                        imgattfilename3 = @"img/tmp/" + "attfile3_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(15).Substring(idx);
                        imgfilename3 = reader.GetString(15);
                        if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(12) + @reader.GetString(15)) == true)
                            {
                                File.Copy(@reader.GetString(12) + @reader.GetString(15), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename3);
                            }
                            else
                            {
                                lfile3 = "N";
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(15)) == true)
                            {
                                File.Copy(@reader.GetString(12) + "\\" + @reader.GetString(15), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename3);
                            }
                            else
                            {
                                lfile3 = "N";
                            }
                        }

                    }
                }


                string imgattfilename4 = string.Empty;
                string imgfilename4 = string.Empty;
                if (reader.IsDBNull(16) || reader.GetString(16) == string.Empty)
                {
                    imgattfilename4 = @"img/profile.png";
                    imgfilename4 = "";
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(16).Trim().LastIndexOf('.');
                        imgattfilename4 = @"img/tmp/" + "attfile4_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(16).Substring(idx);
                        imgfilename4 = reader.GetString(16);
                        if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(12) + @reader.GetString(16)) == true)
                            {
                                File.Copy(@reader.GetString(12) + @reader.GetString(16), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename4);
                            }
                            else
                            {
                                lfile4 = "N";
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(16)) == true)
                            {
                                File.Copy(@reader.GetString(12) + "\\" + @reader.GetString(16), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename4);
                            }
                            else
                            {
                                lfile4 = "N";
                            }
                        }

                    }
                }

                string imgattfilename5 = string.Empty;
                string imgfilename5 = string.Empty;
                if (reader.IsDBNull(17) || reader.GetString(17) == string.Empty)
                {
                    imgattfilename5 = @"img/profile.png";
                    imgfilename5 = "";
                }
                else
                {
                    if (reader.GetString(12).Trim().Length > 0)
                    {
                        int idxLength = reader.GetString(12).Trim().Length;
                        int idx = reader.GetString(17).Trim().LastIndexOf('.');
                        imgattfilename5 = @"img/tmp/" + "attfile5_" + DateTimeOffset.UtcNow.Ticks.ToString() + @reader.GetString(17).Substring(idx);
                        imgfilename5 = reader.GetString(17);
                        if (reader.GetString(12).Trim().Substring(idxLength - 1, 1) == "\\")
                        {
                            if (File.Exists(@reader.GetString(12) + @reader.GetString(17)) == true)
                            {
                                File.Copy(@reader.GetString(12) + @reader.GetString(17), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename5);
                            }
                            else
                            {
                                lfile5 = "N";
                            }
                        }
                        else
                        {
                            if (File.Exists(@reader.GetString(12) + "\\" + @reader.GetString(17)) == true)
                            {
                                File.Copy(@reader.GetString(12) + "\\" + @reader.GetString(17), HttpContext.Current.Server.MapPath("~") + "//" + imgattfilename5);
                            }
                            else
                            {
                                lfile5 = "N";
                            }
                        }

                    }
                }

                if ((imgattfilename1 == @"img/profile.png") && (imgattfilename2 == @"img/profile.png") && (imgattfilename3 == @"img/profile.png") && (imgattfilename4 == @"img/profile.png") && (imgattfilename5 == @"img/profile.png"))
                { anchorID_except.Visible = true; }
                else
                { anchorID_except.Visible = false; }

                if (imgattfilename1 == @"img/profile.png")
                { anchorID_1.Visible = false; }
                else
                {
                    anchorID_1.Attributes["href"] = imgattfilename1;
                    //anchorID_1.InnerText = imgfilename1;
                    //anchorID_1.InnerHtml = "<img src='https://findicons.com/files/icons/753/gnome_desktop/64/gnome_mail_attachment.png'> </img>";
                    //anchorID_1.InnerHtml = "<img src='https://findicons.com/files/icons/753/gnome_desktop/64/gnome_mail_attachment.png' title='" + imgfilename1 + "'></img>";

                    if (lfile1 == string.Empty) { anchorID_1.InnerHtml = "<img src='img/gnome_mail_attachment.png' title='" + imgfilename1 + "'></img>"; }
                    else { anchorID_1.InnerHtml = "<img src='img/blankdocument.png' title='" + imgfilename1 + "'></img>"; }

                }

                if (imgattfilename2 == @"img/profile.png")
                { anchorID_2.Visible = false; }
                else
                {
                    anchorID_2.Attributes["href"] = imgattfilename2;
                    //anchorID_2.InnerText = imgfilename2;
                    if (lfile2 == string.Empty) { anchorID_2.InnerHtml = "<img src='img/gnome_mail_attachment.png' title='" + imgfilename2 + "'></img>"; }
                    else { anchorID_2.InnerHtml = "<img src='img/blankdocument.png' title='" + imgfilename2 + "'></img>"; }
                }

                if (imgattfilename3 == @"img/profile.png")
                { anchorID_3.Visible = false; }
                else
                {
                    anchorID_3.Attributes["href"] = imgattfilename3;
                    //anchorID_3.InnerText = imgfilename3;
                    if (lfile3 == string.Empty) { anchorID_3.InnerHtml = "<img src='img/gnome_mail_attachment.png' title='" + imgfilename3 + "'></img>"; }
                    else { anchorID_3.InnerHtml = "<img src='img/blankdocument.png' title='" + imgfilename3 + "'></img>"; }
                }

                if (imgattfilename4 == @"img/profile.png")
                { anchorID_4.Visible = false; }
                else
                {
                    anchorID_4.Attributes["href"] = imgattfilename4;
                    //anchorID_4.InnerText = imgfilename4;
                    if (lfile4 == string.Empty) { anchorID_4.InnerHtml = "<img src='img/gnome_mail_attachment.png' title='" + imgfilename4 + "'></img>"; }
                    else { anchorID_4.InnerHtml = "<img src='img/blankdocument.png' title='" + imgfilename4 + "'></img>"; }
                }

                if (imgattfilename5 == @"img/profile.png")
                {
                    anchorID_5.Visible = false;
                }
                else
                {
                    anchorID_5.Attributes["href"] = imgattfilename5;
                    //anchorID_5.InnerText = imgfilename5;
                    if (lfile5 == string.Empty) { anchorID_5.InnerHtml = "<img src='img/gnome_mail_attachment.png' title='" + imgfilename5 + "'></img>"; }
                    else { anchorID_5.InnerHtml = "<img src='img/blankdocument.png' title='" + imgfilename5 + "'></img>"; }
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
                if (v_DateOfBirth.Text == "1900-01-01")
                {
                    v_DateOfBirth.Text = string.Empty;
                }
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
                            File.Copy(@reader.GetString(43) + @reader.GetString(44), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                        }
                        else
                        {
                            File.Copy(@reader.GetString(43) + "\\" + @reader.GetString(44), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                        }

                    }
                }

                v_profilepic.Attributes["src"] = imgfilename;

                //    File.Copy(@reader.GetString(3), HttpContext.Current.Server.MapPath("~") + "//" + imgfilename);
                //}

                //v_profilepic.Attributes["src"] = imgfilename;


            }


            reader.Close();



            tempstring = "SELECT A.ID, A.RefNum, CASE WHEN ISNULL(A.Edu_Level, '') = 'OTH' THEN ISNULL(A.Edu_Others, '') ELSE ISNULL(B.description, '') END as edu_desc";
            tempstring += ", CASE WHEN ISNULL(A.Sch_Name, '') = 'OTH' THEN ISNULL(A.Sch_Others, '') ELSE ISNULL(C.description, '') END as school_desc";
            tempstring += ", A.ProgrammeName AS ProgrammeName";
            tempstring += ", '' AS fromDate";
            tempstring += ", CASE WHEN ISNULL(A.GradYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.GradMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.GradYear, 0)))), 4) END AS toDate";
            tempstring += ", CASE WHEN ISNULL(A.ResultType, '') = 'GRA' THEN 'Grade' ELSE ISNULL(A.ResultType, '') END AS ResultType, CASE WHEN ISNULL(A.ResultType, '') = 'GPA' THEN CASE WHEN LTRIM(RTRIM(ISNULL(A.Grade, ''))) = '' AND LTRIM(RTRIM(ISNULL(A.TotalScore, ''))) = '' THEN '' ELSE LTRIM(RTRIM(ISNULL(A.Grade, '')))+'/'+LTRIM(RTRIM(ISNULL(A.TotalScore, ''))) END ELSE LTRIM(RTRIM(ISNULL(A.Grade, ''))) END AS ResultType_Result";
            tempstring += " FROM Application_P1_Education A LEFT JOIN education B ON A.Edu_Level = B.education";
            tempstring += " LEFT JOIN school C ON A.Sch_Name = C.school where A.RefNum = @staffid";
            tempstring += " ORDER BY RIGHT('0'+convert(nvarchar(2), ISNULL(B.EduLevel,0)), 2)+RIGHT('0000'+convert(nvarchar(4), ISNULL(A.GradYear, 0)), 4)+RIGHT('00'+convert(nvarchar(2), ISNULL(A.GradMonth, 0)), 2) DESC";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Edu.DataSource = reader;
            grid_Edu.DataBind();
            reader.Close();

            tempstring = "select ID, RefNum, LineNum, OrgName, AwardDesc, ObtainYear from Application_P2_Award where RefNum = @staffid";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Award.DataSource = reader;
            grid_Award.DataBind();
            reader.Close();

            tempstring = "SELECT A.ID, A.RefNum, A.LineNum";
            tempstring += ", ISNULL(A.OrgName, '') as OrgName";
            tempstring += ", ISNULL(A.TitleName, '') as TitleName";
            tempstring += ", CASE WHEN ISNULL(A.FromYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.FromMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.FromYear, 0)))), 4) END AS fromDate";
            tempstring += ", CASE WHEN ISNULL(A.ToYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.ToMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.ToYear, 0)))), 4) END AS toDate";
            tempstring += " FROM Application_P2_Activity A where A.RefNum = @staffid";

            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Activities.DataSource = reader;
            grid_Activities.DataBind();
            reader.Close();

            //cmd.CommandText = "select rowNo, qualiName, issuedBy, issuedYear, showInCV from t_Qualification where staffID = @staffid order by issuedYear desc";

            //cmd.Parameters.Clear();
            //cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            //cmd.Prepare();


            //reader = cmd.ExecuteReader();
            //grid_Quali.DataSource = reader;
            //grid_Quali.DataBind();
            //reader.Close();

            //cmd.CommandText = "select rowNo, position, format(fromDate, 'yyyy-MM-dd') AS fromDate, CASE WHEN ISNULL(toDate,'') = '' THEN 'Present' ELSE format(toDate, 'yyyy-MM-dd') END as toDate, showInCV from t_PYMovement where staffID = @staffid order by fromDate desc";

            //cmd.Parameters.Clear();
            //cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 10).Value = sid;
            //cmd.Prepare();
            //reader = cmd.ExecuteReader();
            //grid_Movement.DataSource = reader;
            //grid_Movement.DataBind();
            //reader.Close();

            tempstring = "SELECT A.ID, RefNum, A.LineNUm, ISNULL(A.CompName, '') AS CompName, '' AS BusinessNature";
            tempstring += ", ISNULL(A.PosName, '') AS PosName";
            tempstring += ", CASE WHEN ISNULL(A.FromYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.FromMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.FromYear, 0)))), 4) END AS fromDate";
            tempstring += ", CASE WHEN ISNULL(A.ToYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.ToMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.ToYear, 0)))), 4) END AS toDate";
            tempstring += ", A.LastSalaryType AS LastSalaryType_Desc, A.LastSalary, '' AS Leave_Reason_Desc";
            tempstring += " FROM Application_P2_JobExp A LEFT JOIN LastSalaryType B  ON A.LastSalaryType = B.LastSalaryType";
            tempstring += " where RefNum = @staffid";
            tempstring += " ORDER BY CASE WHEN ISNULL(A.ToYear, 0) = 0 THEN";
            tempstring += " RIGHT('0000'+convert(nvarchar(4), ISNULL(A.FromYear, 0)), 4)+RIGHT('00'+convert(nvarchar(2), ISNULL(A.FromMonth, 0)), 2) ELSE";
            tempstring += " RIGHT('0000'+convert(nvarchar(4), ISNULL(A.ToYear, 0)), 4)+RIGHT('00'+convert(nvarchar(2), ISNULL(A.ToMonth, 0)), 2) END DESC";

            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Exp.DataSource = reader;
            grid_Exp.DataBind();
            reader.Close();

            tempstring = "SELECT A.ID, RefNum, A.LineNUm, ISNULL(A.OrgName, '') AS OrgName, ISNULL(A.TitleName, '') AS TitleName";
            tempstring += ", '' AS Qua_Level";
            //tempstring += ", CASE WHEN ISNULL(A.ObtainYear, 0) = 0 THEN '' ELSE RIGHT('0'+ LTRIM(RTRIM(CONVERT(nvarchar(2), ISNULL(A.ObtainMonth, 0)))), 2)+'/'+RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.ObtainYear, 0)))), 4) END AS ObtainYearMonth";
            tempstring += ", CASE WHEN ISNULL(A.ObtainYear, 0) = 0 THEN '' ELSE RIGHT('0000'+ LTRIM(RTRIM(CONVERT(nvarchar(4), ISNULL(A.ObtainYear, 0)))), 4) END AS ObtainYearMonth";
            tempstring += " FROM Application_P2_Qualification A where RefNum = @staffid";

            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Prof.DataSource = reader;
            grid_Prof.DataBind();
            reader.Close();

            tempstring = "SELECT A.ID, RefNum, A.LineNUm, ISNULL(A.Lang, '') AS Lang";
            tempstring += ", CASE WHEN LTRIM(RTRIM(ISNULL(A.Speaking, ''))) = '3' THEN 'Excellent' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Speaking, ''))) = '2' THEN 'Good' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Speaking, ''))) = '1' THEN 'Fair' ELSE 'N/A' END END END AS Spoken";
            tempstring += ", CASE WHEN LTRIM(RTRIM(ISNULL(A.Reading, ''))) = '3' THEN 'Excellent' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Reading, ''))) = '2' THEN 'Good' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Reading, ''))) = '1' THEN 'Fair' ELSE 'N/A' END END END AS Reading";
            tempstring += ", CASE WHEN LTRIM(RTRIM(ISNULL(A.Writing, ''))) = '3' THEN 'Excellent' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Writing, ''))) = '2' THEN 'Good' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.Writing, ''))) = '1' THEN 'Fair' ELSE 'N/A' END END END AS Written";
            tempstring += " FROM Application_P2_Language A where RefNum = @staffid";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Lang.DataSource = reader;
            grid_Lang.DataBind();
            reader.Close();


            tempstring = "SELECT A.ID, RefNum, A.LineNUm, ISNULL(A.SoftwareName, '') AS SoftwareName";
            tempstring += ", CASE WHEN LTRIM(RTRIM(ISNULL(A.ProfLevel, ''))) = '3' THEN 'Excellent' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.ProfLevel, ''))) = '2' THEN 'Good' ELSE CASE WHEN LTRIM(RTRIM(ISNULL(A.ProfLevel, ''))) = '1' THEN 'Fair' ELSE 'N/A' END END END AS ProfLevel";
            tempstring += " FROM Application_P2_Skill A where RefNum = @staffid";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Skills.DataSource = reader;
            grid_Skills.DataBind();
            reader.Close();

            //tempstring = "SELECT TOP 1 Referee_Name,  Referee_Company_Position, Referee_RelationShip FROM (";
            //tempstring += "SELECT '0' as Seq, ISNULL(A.Referee_Name, '') AS Referee_Name, ISNULL(A.Referee_Company_Position, '') AS Referee_Company_Position, ISNULL(A.Referee_RelationShip, '') AS Referee_RelationShip";
            //tempstring += " FROM Application_Hdr A where RefNum = @staffid"; 
            //tempstring += " UNION select '1' as Seq, '' AS Referee_Name, '' AS Referee_Company_Position, '' AS Referee_RelationShip) xx order by xx.Seq"; 

            tempstring = "SELECT '' AS Referee_Name, '' AS Referee_Company_Position, '' AS Referee_RelationShip";
            tempstring += " FROM Application_P1_Hdr A where RefNum = @staffid and 1=0";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Referee.DataSource = reader;
            grid_Referee.DataBind();

            reader.Close();

            //tempstring = "SELECT TOP 1 WorkPerson_Name,  WorkPerson_Company_Position, WorkPerson_RelationShip FROM (";
            //tempstring += "SELECT '0' as Seq, ISNULL(A.WorkPerson_Name, '') AS WorkPerson_Name, ISNULL(A.WorkPerson_Company_Position, '') AS WorkPerson_Company_Position, ISNULL(A.WorkPerson_RelationShip, '') AS WorkPerson_RelationShip";
            //tempstring += " FROM Application_Hdr A where RefNum = @staffid";
            //tempstring += " UNION select '1' as Seq, '' AS WorkPerson_Name, '' AS WorkPerson_Company_Position, '' AS WorkPerson_RelationShip) xx order by xx.Seq"; 

            tempstring = "SELECT '' AS WorkPerson_Name, '' AS WorkPerson_Company_Position, '' AS WorkPerson_RelationShip";
            tempstring += " FROM Application_P1_Hdr A where RefNum = @staffid and 1=0";
            cmd.CommandText = tempstring;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@staffid", SqlDbType.VarChar, 20).Value = sid;
            cmd.Prepare();

            reader = cmd.ExecuteReader();
            grid_Work.DataSource = reader;
            grid_Work.DataBind();


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