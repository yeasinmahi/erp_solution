using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace UI.Dairy
{
    public partial class Task_DocDownAndView : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intReffID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                intReffID = int.Parse(Request.QueryString["intID"]);
                HttpContext.Current.Session["intReffID"] = intReffID.ToString();   

                //ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
                //int enroll = int.Parse(Request.QueryString["EN"].ToString());
                //string tp = Request.QueryString["TP"];
                try
                {
                    dt = new DataTable();
                    dt = objtask.GetViewDoc(intReffID);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strPathurl = Uri.EscapeUriString(dt.Rows[i]["strFilePath"].ToString());
                            string imageUrl = "ftp://erp:erp123@ftp.akij.net/TaskDocument/" + strPathurl;
                            myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));
                            //innerTableHtml = innerTableHtml + @" <table border='0'><tr><td>"; innerTableHtml = innerTableHtml + 
                            //@"<img src=" + imageUrl + @" Height='350px' Width='350px'></td></tr></table>";
                        }
                        #region ------------ Filter Div By InnerHTML ---------------
                        //System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                        //new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        //createDiv.ID = "createDiv";
                        //createDiv.InnerHtml = innerTableHtml;
                        //createDiv.Attributes.Add("class", "dynamicDivbn");
                        //this.Controls.Add(createDiv);
                        #endregion
                    }
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true); }

            }
        }
























    }
}