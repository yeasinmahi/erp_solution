using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Personal
{
    public partial class DocView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
                int enroll = int.Parse(Request.QueryString["EN"].ToString());
                string tp = Request.QueryString["TP"]; 
                try
                {
                    dt = atp.GetPathList(enroll, tp);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strPathurl = Uri.EscapeUriString(dt.Rows[i]["NoOfPage"].ToString());
                            string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + strPathurl;
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
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);}

            }

        }


    }
}