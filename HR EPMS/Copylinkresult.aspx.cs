using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace HR_EPMS
{
    public partial class LinkEdit : System.Web.UI.Page
    {
        private static string _Val;
        public static string Val
        {
            get { return _Val; }
            set { _Val = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var graduatelink = WebConfigurationManager.AppSettings["GraduateLink"];
            var normallink = WebConfigurationManager.AppSettings["NormalLink"];
            if (!IsPostBack)
            {
                string T_Key;
                string T2_Key;
                string T3_Key;
                string LinkType;
                string strURL;
                string recID;
                T_Key = Request.QueryString["Key"];
                T2_Key = Request.QueryString["Position"];
                T3_Key = Request.QueryString["RefCode"];
                LinkType = Request.QueryString["LinkType"];
                recID = Request.QueryString["ID"];
                if (LinkType.Equals("1"))
                {
                    strURL = graduatelink +"Main.aspx?Key="+ T_Key + "&Position=" + T2_Key + "&Refcode=" + T3_Key;
                }
                else if (LinkType.Equals("3"))
                {
                    strURL = graduatelink + "Phase2Main.aspx?Key=" + T_Key + "&Position=" + T2_Key + "&Refcode=" + T3_Key;
                }
                else
                { 
                    strURL = normallink+"GenMain.aspx?ID=" + recID;
                }

                Val = strURL;
                //var h1 = new HtmlGenericControl("h1");
               p1.InnerText = strURL;
                //Thread clipboardThread = new Thread(copyToClipboard);
                //clipboardThread.SetApartmentState(ApartmentState.STA);
                //clipboardThread.IsBackground = false;
                //clipboardThread.Start();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
            base.Response.Write(close);
        }
        protected void copyToClipboard()
        {          
            System.Windows.Forms.Clipboard.SetText(Val);
        }

        protected void btnCopyClicked(object sender, EventArgs e)
        {
            //var email = document.getElementById('tbSentMail');
            //var emailValue = email.value;
            ////copy to clipboard 
            //window.clipboardData.setData('Text', emailValue);
            Clipboard.SetText(Val);
        }
    }
}