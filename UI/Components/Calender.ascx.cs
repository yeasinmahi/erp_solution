using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// This Component is developped by Akram
/// </summary>
namespace UI.Components
{
    public partial class Calender : System.Web.UI.UserControl
    {
        public string pre = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = Request.AppRelativeCurrentExecutionFilePath.Replace("~/", "");

                if (str.Contains("/"))
                {
                    char[] ch = { '/' };
                    string[] ss = str.Split(ch);
                    for (int i = 0; i < (ss.Length - 1); i++)
                    {
                        pre += "../";
                    }
                }

                txtDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                pnlCompAkramCalendar.DataBind();
            }
        }
    }
}
