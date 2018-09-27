using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using Purchase_BLL.SupplyChain;

namespace UI.Inventory
{
    public partial class SupplierDocView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
                //int enroll = int.Parse(Request.QueryString["EN"].ToString());
                int intSuppMasterId = Convert.ToInt32(Request.QueryString["intSuppMasterId"]);
                string reportUrlPre = "ftp://erp:erp123@ftp.akij.net/SupplierDoc/";
                DataTable dt = new CSM().GetDocDetailsData(intSuppMasterId);
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        string src = reportUrlPre + Uri.EscapeUriString(row["strFilePath"].ToString());
                        string extension = System.IO.Path.GetExtension(src);

                        if (extension.ToLower().Equals(".pdf"))
                        {
                            myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + src + "'></iframe>"));

                        }
                        else if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg")
                                 || extension.ToLower().Equals(".png") || extension.ToLower().Equals(".gif"))
                        {
                            string lstrImgString = "<img src='" + src + "' width=\"500\"" + " hspace=\"5\" vspace=\"5\"></br>";
                            myPanel.Controls.Add(new LiteralControl(lstrImgString));
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Attchment type is "+extension+". this type is not supported in our system to view.');", true);
                        }
                       

                        
                    }
                    
                    //dt = atp.GetPathList(enroll, tp);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        string strPathurl = Uri.EscapeUriString(dt.Rows[i]["NoOfPage"].ToString());
                    //        string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + strPathurl;
                    //        myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));
                    //        //innerTableHtml = innerTableHtml + @" <table border='0'><tr><td>"; innerTableHtml = innerTableHtml + 
                    //        //@"<img src=" + imageUrl + @" Height='350px' Width='350px'></td></tr></table>";
                    //    }
                    #region ------------ Filter Div By InnerHTML ---------------
                    //System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    //new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    //createDiv.ID = "createDiv";
                    //createDiv.InnerHtml = innerTableHtml;
                    //createDiv.Attributes.Add("class", "dynamicDivbn");
                    //this.Controls.Add(createDiv);
                    #endregion
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                }

            }
        }
    }
}