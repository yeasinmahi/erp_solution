using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using SCM_DAL.MrrReceiveTDSTableAdapters;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PendingMRR : BasePage
    {
        #region INIT
        private object lockObj = new object();
        private MrrReceive_BLL obj = new MrrReceive_BLL();

        private DataTable dt = new DataTable();
        private int enroll, intWh, Mrrid;
        PendingMRRTableAdapter adapter = new PendingMRRTableAdapter();
        FactoryReceiveMRRItemDetailTableAdapter fmrridtAdapter = new FactoryReceiveMRRItemDetailTableAdapter();
        sprInventoryGetMissingCostTableAdapter mcAdapter = new sprInventoryGetMissingCostTableAdapter();
        ImportInventoryTableAdapter iitAdapter = new ImportInventoryTableAdapter();
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\MrrStatement";
        private string stop = "stopping SCM\\MrrStatement";
        private string perform = "Performance on SCM\\MrrStatement";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDteFrom.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                txtdteTo.Text = DateTime.Now.ToString("yyyy-MM-dd");

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = obj.DataView(19, "", intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                //dt = obj.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                //ddlDept.DataSource = dt;
                //ddlDept.DataTextField = "strName";
                //ddlDept.DataValueField = "Id";
                //ddlDept.DataBind();
                ddlDept.Items.Clear();
                ddlDept.Items.Insert(0, new ListItem("Import", "2"));
            }
            else { }
        }
        #endregion

        #region Event
        protected void btnAttachment_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAttachment_Click Upload", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnAttachment_Click Upload", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblMrrId = row.FindControl("lblMrrId") as Label;

                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewdetails('" + MrrId + "');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnAttachment_Click Upload", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnAttachment_Click Uplaod", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnMRRSDetail_Click(object sender, EventArgs e)
        {
            dgvIndent.Visible = false;
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/MRR_Statement_Report" + "&Indent=" + txtMrrNo.Text + "&FDate=" + txtDteFrom.Text + "&TDate=" + txtdteTo.Text + "&Department=" + ddlDept.SelectedItem.Text + "&Unit=" + ddlWH.SelectedValue + "&Enroll=" + Enroll + "&rc:LinkTarget=_self";

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }
        protected void btnComplete_Click(object sender, EventArgs e)
        {
            DataTable dtid = new DataTable();
            int count = 0;
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Button btnComplete = row.FindControl("btnComplete") as Button;
                btnComplete.Enabled = false;
                Label lblPo = row.FindControl("lblPo") as Label;
                Label lblMrrId = row.FindControl("lblMrrId") as Label;
                HiddenField hfShipmentID = row.FindControl("hfShipmentID") as HiddenField;
                HiddenField hfUnitID = row.FindControl("hfUnitID") as HiddenField;
                int PoId = Convert.ToInt32(lblPo.Text);
                int MrrId = Convert.ToInt32(lblMrrId.Text);
                int ShipmentId = !string.IsNullOrEmpty(hfShipmentID.Value) ? Convert.ToInt32(hfShipmentID.Value) : 0;
                int UnitId = !string.IsNullOrEmpty(hfUnitID.Value) ? Convert.ToInt32(hfUnitID.Value) : 0;
                int wh = Convert.ToInt32(ddlWH.SelectedValue);

                string sms = ImportMissingCost(PoId, ShipmentId);
                if (string.IsNullOrEmpty(sms))
                {
                    lock (lockObj)
                    {
                        dtid = fmrridtAdapter.GetMRRItemDetailsData(MrrId);
                        if (dtid != null)
                        {
                            if (dtid.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtid.Rows.Count; i++)
                                {
                                    int LocationId = !string.IsNullOrEmpty(dtid.Rows[i]["intLocationID"].ToString())
                                        ? Convert.ToInt32(dtid.Rows[i]["intLocationID"])
                                        : 0;
                                    int ItemId = !string.IsNullOrEmpty(dtid.Rows[i]["intItemID"].ToString())
                                        ? Convert.ToInt32(dtid.Rows[i]["intItemID"])
                                        : 0;
                                    decimal ReceiveQnt = !string.IsNullOrEmpty(dtid.Rows[i]["numReceiveQty"].ToString())
                                        ? Convert.ToDecimal(dtid.Rows[i]["numReceiveQty"])
                                        : 0;
                                    decimal ImportCostingItemRate = GetImportCostingItemRate(PoId, ShipmentId, ItemId);
                                    decimal monBDT = ReceiveQnt * ImportCostingItemRate;
                                    iitAdapter.InsertImportInventory(UnitId, wh, LocationId, ItemId, ReceiveQnt, monBDT,
                                        MrrId, 1);
                                    iitAdapter.UpdateFactoryReceiveMRRItemDetail(monBDT, MrrId, ItemId);
                                    iitAdapter.UpdateYSNInventory(MrrId, wh);
                                    count += 1;
                                }
                            }
                        }

                        if (count > 0)
                        {
                            Toaster("MRR Complete Successfully!", Utility.Common.TosterType.Success);
                            btnStatement_Click(null, null);
                        }
                    }
                }
                else
                {
                    Toaster("MRR Not Possible for Missing Cost!", Utility.Common.TosterType.Error);
                }
                btnComplete.Enabled = true;
            }
            catch (Exception ex)
            {
                string sms = "Complete Button : " + ex.Message.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }

            
        }
        protected void btnStatement_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnStatement_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnStatement_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            dgvIndent.Visible = true;
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Now.AddMonths(-1);
                DateTime dteTo = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(txtDteFrom.Text) && !string.IsNullOrWhiteSpace(txtdteTo.Text))
                {
                    dteFrom = DateTime.Parse(txtDteFrom.Text);
                    dteTo = DateTime.Parse(txtdteTo.Text);
                }

                string dept = ddlDept.SelectedItem.ToString();

                //string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                //try
                //{
                //    Mrrid = int.Parse(txtMrrNo.Text);
                //}
                //catch
                //{
                //    Mrrid = 0;
                //}
                //dt = obj.DataView(12, xmlData, intWh, Mrrid, dteFrom, enroll);
                dt = adapter.GetPendingMRRData(dteFrom.ToString(), dteTo.ToString(), intWh);
                dt.Columns.Add(new DataColumn("missingCost", typeof(string)));

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int poid = !string.IsNullOrEmpty(dt.Rows[i]["intpoid"].ToString()) ? Convert.ToInt32(dt.Rows[i]["intpoid"]) : 0;
                            int shipid = !string.IsNullOrEmpty(dt.Rows[i]["intShipmentID"].ToString()) ? Convert.ToInt32(dt.Rows[i]["intShipmentID"]) : 0;
                            dt.Rows[i]["missingCost"] = GetMRRMissingCost(poid, shipid);
                        }
                    }
                }

                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnStatement_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnStatement_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        

        protected void dgvIndent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblMrrId = row.FindControl("lblMrrId") as Label;

                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + MrrId + "');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDetalis_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion

        #region Method
        private string ImportMissingCost(int intpo, int intShipment)
        {
            string sms = string.Empty;
            try
            {
                sprInventoryGetMissingCostTableAdapter cost = new sprInventoryGetMissingCostTableAdapter();
                DataTable dt = new DataTable();
                dt = cost.GetImportMissingCost(intpo, intShipment);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        sms = dt.Rows[0]["strMissingCost"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            return sms;


        }

        protected void dgvIndent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            
        }

        private string GetMRRMissingCost(int poId, int shipmentId)
        {
            string missingCost = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                dt = mcAdapter.GetImportMissingCost(poId, shipmentId);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        missingCost = dt.Rows[0]["strMissingCost"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return missingCost;
        }
        private decimal GetImportCostingItemRate(int poId, int shipmentId, int itemId)
        {
            decimal ImportCostingRate = 1;
            try
            {
                object _obj = iitAdapter.GetImportCostingItemRate(poId, shipmentId, itemId);
                if (_obj != null)
                    ImportCostingRate = Convert.ToDecimal(_obj);
            }
            catch (Exception ex)
            {
            }
            return ImportCostingRate;
        }
        #endregion
    }
}