using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.Script.Services;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.PaymentModule
{
    public partial class PreviousPrice : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/PreviousPrice.aspx";
        string stop = "stopping PaymentModule/PreviousPrice.aspx";

        Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt;

        int intItemID;
        string strSPName, strPath;

        char[] delimiterChars = { '[', ']' };
        string[] arrayKey;
        int intSeparationID,itemid;
        string Id,itemName;
        string strDate;
        string strTodate;
        string UNITS;
        string enrol1;
        string ReportType;
        string innerTableHtml = "";
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PreviousPrice.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            //if (!IsPostBack)
            //{
               try
                {
                try { hdnBillID.Value = Session["billid"].ToString(); }
                catch { hdnBillID.Value = ""; }
                    intItemID = int.Parse(Request.QueryString["Id"]);
                    lblitemid.Text = Request.QueryString["Id"];
                    //hdnItemID.Value = intItemID.ToString();
                    ////Session["mrrid"] = intBillID.ToString();
                    if (Session["itemname"].ToString() == "")
                    {
                        lblItemName.Text = "";
                    }
                    else
                    {
                        lblItemName.Text = Session["itemname"].ToString();
                    }


                    dt = new DataTable();
                    dt = objBillApp.GetPriceListByItemID(intItemID);
                    if (dt.Rows.Count > 0)
                    {
                       // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Hello');", true);
                        dgvPriceList.DataSource = dt;
                        dgvPriceList.DataBind();
                    }

                    //dt = new DataTable();
                    //dt = objBillApp.GetChartOfPrice(int.Parse(hdnItemID.Value));
                    //Chart1.DataSource = dt;
                    //Chart1.DataBind();

                    dt = objBillApp.GetWHList();
                    ddlwh.DataSource = dt;
                    ddlwh.DataTextField = "strWareHoseName";
                    ddlwh.DataValueField = "intWHID";
                    ddlwh.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                    Flogger.WriteError(efd);
                }
            //}

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        public void btnBack_Click()
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + hdnBillID.Value + "');", true);
        }

        protected void txtItemId_TextChanged(object sender, EventArgs e)
        {
            txtItem.Text = "";
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            txtItemId.Text = "";
        }

        protected void btnShowItem_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShowItem_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PreviousPrice.aspx btnShowItem_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);


            DataTable dtt = new DataTable();
           
            if (txtItem.Text != "" && txtItemId.Text == "")
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                if (arrayKey.Length > 0)
                {
                    itemName = arrayKey[0].ToString();
                    itemid = Convert.ToInt32(arrayKey[1].ToString());
                    lblItemName.Text = itemName;
                    lblitemid.Text = itemid.ToString();
                }
                dtt = objBillApp.GetPurchaseList(itemid);
            }
            else
            {
                itemid = Convert.ToInt32(txtItemId.Text);
                //lblItemName.Text = itemName;
                lblitemid.Text = itemid.ToString();
                dtt = objBillApp.GetPurchaseList(itemid);
            }

            if (dtt.Rows.Count > 0)
            {
                dgvPriceList.DataSource = dtt;
                dgvPriceList.DataBind();
            }
            else
            {
                dgvPriceList.DataSource = "";
                dgvPriceList.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "btnShowItem_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlwh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlwh.SelectedValue;
            }
            catch { }
        }

        #region========================Auto Search============================ 
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            
            AutoSearch_BLL ast = new AutoSearch_BLL();
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);

        }

        #endregion====================Close====================================== 























    }
}