using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using System.Net;

namespace UI.CreativeSupportModule
{
    public partial class DocView : System.Web.UI.Page
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = ""; string strPath;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {                
                strPath = Request.QueryString["Id"];

                //try
                //{
                //    intBillID = int.Parse(Request.QueryString["Id"]);
                //    dt = new DataTable();
                //    dt = objBillApp.GetDocumentList(intBillID, intEntryType);
                //}
                //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('List Empty.');", true); }

                try
                {
                    ////if (dt.Rows.Count > 0)
                    ////{
                    ////    for (int i = 0; i < dt.Rows.Count; i++)
                    ////    {
                    ////string strPathurl = dt.Rows[i]["strFilePath"].ToString();// + strPathurlDocument_57826_St -3, 1, 16-A.jpg
                    string url = "ftp://erp:erp123@ftp.akij.net/CreativeSupportModuleDoc/" + strPath;
                    string imageUrl = url;//System.Web.HttpUtility.HtmlEncode(url); ;
                    innerTableHtml = innerTableHtml + @" <table border='0'>
                                <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='700px' Width='800px'></td></tr></table>";
                    ////}
                    #region ------------ Filter Div By InnerHTML ---------------
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    createDiv.ID = "createDiv";
                    createDiv.InnerHtml = innerTableHtml;
                    createDiv.Attributes.Add("class", "dynamicDivbn");
                    this.Controls.Add(createDiv);
                    #endregion
                    ////}
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                }
            }
        }

































    }
}