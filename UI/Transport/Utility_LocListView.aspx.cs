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

namespace UI.Transport
{
    public partial class Utility_LocListView : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL(); Utility_BLL objut = new Utility_BLL();
        DataTable dt;

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
                    dt = objut.GetDocListForView(intReffID);                       
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Result.');", true); }

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strPathurl = dt.Rows[i]["strFilePath"].ToString();// + strPathurlDocument_57826_St -3, 1, 16-A.jpg
                            string url = "ftp://erp:erp123@ftp.akij.net/UtilityDocList/" + strPathurl;
                            string imageUrl = url;//System.Web.HttpUtility.HtmlEncode(url); ;
                            innerTableHtml = innerTableHtml + @" <table border='0'>
                                <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='350px' Width='350px'></td></tr></table>";
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