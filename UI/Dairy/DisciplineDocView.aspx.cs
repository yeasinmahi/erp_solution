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
    public partial class DisciplineDocView : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intWork; int intEnroll; string Unitid; int intSearchEnroll; string strReportType;
        int intID;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = "";

        int intReffID; int intDoct;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    intReffID = int.Parse(Request.QueryString["intID"]);
                    HttpContext.Current.Session["intReffID"] = intReffID.ToString();

                    dt = new DataTable();
                    dt = objtask.GetDisciplineDocView(intReffID);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Result.');", true); }

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strPathurl = dt.Rows[i]["strFilePath"].ToString();// + strPathurlDocument_57826_St -3, 1, 16-A.jpg
                            string url = "ftp://erp:erp123@ftp.akij.net/DisciplineDocList/" + strPathurl;
                            string imageUrl = url;//System.Web.HttpUtility.HtmlEncode(url); ;
                            innerTableHtml = innerTableHtml + @" <table border='0'>
                                <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='700px' Width='800px'></td></tr></table>";
                        }
                        #region ------------ Filter Div By InnerHTML ---------------
                        System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                        new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        createDiv.ID = "createDiv";
                        createDiv.InnerHtml = innerTableHtml;
                        createDiv.Attributes.Add("class", "dynamicDivbn");
                        this.Controls.Add(createDiv);
                        #endregion
                    }
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);

                }

            }
        }


























    }
}