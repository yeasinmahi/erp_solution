using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Inventory
{
    public partial class ReqPolicyView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strPathurl = Request.QueryString["FP"];
                try
                {

                    strPathurl = Uri.EscapeUriString(strPathurl);
                    string imageUrl = "ftp://erp:erp123@ftp.akij.net/Policy/" + strPathurl;
                    myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));
                    #region ------------ Filter Div By InnerHTML ---------------
                    //innerTableHtml = innerTableHtml + @" <table border='0'><tr><td>"; innerTableHtml = innerTableHtml +
                    //@"<img src=" + imageUrl + @" Height='350px' Width='350px'></td></tr></table>";

                    //System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    //new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    //createDiv.ID = "createDiv";
                    //createDiv.InnerHtml = innerTableHtml;
                    //createDiv.Attributes.Add("class", "dynamicDivbn");
                    //this.Controls.Add(createDiv);
                    #endregion
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true); }

            }
        }
    }
}