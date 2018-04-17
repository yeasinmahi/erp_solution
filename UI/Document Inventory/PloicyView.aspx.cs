using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Document_Inventory;
using System.Data;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using UI.ClassFiles;
namespace UI.Document_Inventory
{
    public partial class PloicyView : System.Web.UI.Page
    {
        documentdownload bll = new documentdownload();
        DataTable pdownloads = new DataTable();

        string innerTableHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 data = Convert.ToInt32(Session["Rowid"].ToString());
                pdownloads = bll.PolicyView(data);
                
                if (pdownloads.Rows.Count > 0)
                {
                    string strPathurl = Uri.EscapeUriString(pdownloads.Rows[0]["strFtpFilePath"].ToString());
                    string imageUrl = "ftp://erp:erp123@ftp.akij.net/Policy/" + strPathurl;
                    myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));






                    //string ext = Path.GetExtension(pdownloads.Rows[0]["strFtpFilePath"].ToString());
//                    if (ext != ".pdf")
//                    {
//                        innerTableHtml = innerTableHtml + @" <table border='0'>
//                    <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='350px' Width='350px'></td></tr></table>";
//                        #region ------------ Filter Div By InnerHTML ---------------
//                        System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
//                        new System.Web.UI.HtmlControls.HtmlGenericControl("div");
//                        createDiv.ID = "createDiv";
//                        createDiv.InnerHtml = innerTableHtml;
//                        createDiv.Attributes.Add("class", "dynamicDivbn");
//                        this.Controls.Add(createDiv);
//                        #endregion
//                    }
                }

            }
        }



        }
    }

