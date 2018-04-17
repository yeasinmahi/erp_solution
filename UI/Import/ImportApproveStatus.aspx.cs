using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Imports;
using System.Data;
using System.Data.SqlClient;
using UI.ClassFiles;
using System.Net;
using System.IO;

namespace UI.Import
{
    public partial class ImportApproveStatus : BasePage
    {
        Import_BLL objImport = new Import_BLL();
        DataTable dt = new DataTable();
        DataTable dtApp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 RQID = Int32.Parse(Session["strRFIQID"].ToString());
                Int32 number, type;
                DgvApproval.Visible = true;
                DgvReport.Visible = true;
                number = Int32.Parse(RQID.ToString());
                type = Int32.Parse(3.ToString());
                dt = objImport.ViewData(number, type);

                type = Int32.Parse(2.ToString());

                dtApp = objImport.ViewData2(number, type);

                if (dt.Rows.Count > 0 && dtApp.Rows.Count > 0)
                {
                    DgvReport.DataSource = dt;
                    DgvReport.DataBind();

                    DgvApproval.DataSource = dtApp;
                    DgvApproval.DataBind();

                }
                else
                {
                    DgvApproval.Visible = false;
                    DgvReport.Visible = false;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                }
            }
        }


        protected void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();

                Session["strPath"] = ordernumber1;

               // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewData('DocViews.aspx');", true);
                if (ordernumber1 != "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewData('DocViews.aspx');", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                }


            }
            catch { }

        }
    }
}