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
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.PaymentModule
{
    public partial class MRRDetailsView : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/MRRDetailsView.aspx";
        string stop = "stopping PaymentModule/MRRDetailsView.aspx";

        Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt;

        int intPOID, intBillID, intMRRID;
        string strSPName, strPath;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = "";
        #endregion ====================================================================================
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MRRDetailsView.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try
                {
                    try { hdnBillID.Value = Session["billid"].ToString(); } catch { }
                    try { intMRRID = int.Parse(Request.QueryString["Id"]); } catch { }
                    try { Session["mrrid"] = intBillID.ToString(); } catch { }
                    //intBillID = 410924;
                    dt = new DataTable();
                    dt = objBillApp.GetMRRInfo(intMRRID);
                    if (dt.Rows.Count > 0)
                    {
                        lblMRRNo.Text = dt.Rows[0]["intMRRID"].ToString();
                        lblMRRDate.Text = DateTime.Parse(dt.Rows[0]["mrrDate"].ToString()).ToString("yyyy-MM-dd");
                        lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                        lblSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
                        lblChallanNo.Text = dt.Rows[0]["strExtnlReff"].ToString();
                        lblChallanDate.Text = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString()).ToString("yyyy-MM-dd");
                        lblIssuedBy.Text = dt.Rows[0]["strEmployee"].ToString();
                    }

                    dt = new DataTable();
                    dt = objBillApp.GetMRRItemInfo(intMRRID);
                    if (dt.Rows.Count > 0)
                    {
                        dgvItemDetails.DataSource = dt;
                        dgvItemDetails.DataBind();
                    }

                    dt = new DataTable();
                    dt = objBillApp.GetDocLByMRRID(intMRRID);
                    if (dt.Rows.Count > 0)
                    {
                        dgvDocList.DataSource = dt;
                        dgvDocList.DataBind();
                    }

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string strPathurl = dt.Rows[i]["strFtpPath"].ToString();// + strPathurlDocument_57826_St -3, 1, 16-A.jpg
                                string url = "ftp://erp:erp123@ftp.akij.net" + strPathurl;
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
                    catch { }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected decimal ggrandtotalamntwv = 0;
        protected void dgvItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ggrandtotalamntwv += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblAmntWV")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }


        public void btnBack_Click()
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + hdnBillID.Value + "');", true);
        }


















    }
}