using Flogging.Core;
using GLOBAL_BLL;
using HR_BLL.Global;
using SCM_BLL;
using SCM_DAL.MrrReceiveTDSTableAdapters;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class PendingMRR : BasePage
    {
        #region INIT
        private object lockObj = new object();
        private MrrReceive_BLL obj = new MrrReceive_BLL();
        public InventoryTransfer_BLL mirObj = new InventoryTransfer_BLL();
        DaysOfWeek bllobj = new DaysOfWeek();
        private DataTable dt = new DataTable();
        private int enroll, intWh, Mrrid;
        string xmlpath;
        string message="";
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
            xmlpath = Server.MapPath("~/Inventory/Data/INSBY_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_PO.xml");


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

                HideShowGridColumn();
                hdnpoid.Value = "0";
                hdnmrrid.Value = "0";
                try {
                    File.Delete(xmlpath);
                }
                catch {

                }
                pnlUpperControl.DataBind();
            }
            else { }
        }
        #endregion

        #region Button Event
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
                
                Label lblPo = row.FindControl("lblPo") as Label;
                string poid = lblPo.Text;
                string MrrId = lblMrrId.Text;
                hdnmrrid.Value = MrrId;
                Session["MrrID"] = lblMrrId.Text;
                

                if (ddlType.SelectedValue == "Costing")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + MrrId + "');", true);
                }
                else if (ddlType.SelectedValue == "QC")
                {
                    dt = mirObj.GetPermissionForQC(Enroll,Convert.ToInt32(ddlWH.SelectedValue));
                    string is_QC = "";
                    try
                    {
                        is_QC= dt.Rows[0]["ysnQC"].ToString(); ;
                    }
                    catch
                    {
                        is_QC = "False";
                    }
                    if(is_QC=="True")
                    {
                        dt = mirObj.GetItem(int.Parse(MrrId));
                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            dgv.DataBind();
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowDetailsDiv('" + poid + "');", true);

                    }
                    else
                    {
                        message = "You dont have QC permission for " +ddlWH.SelectedItem.Text;
                        Toaster(message, "Pending MRR", Common.TosterType.Warning);
                    }



                }

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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconf.Value == "1")
            {
                try
                {
                     for (int index = 0; index < dgv.Rows.Count; index++)
                        {
                            bool ysnChecked = false;
                            string proceed = "0";
                            string itemid = ((Label)dgv.Rows[index].FindControl("lblitmno")).Text.ToString();
                            string poqnty = ((Label)dgv.Rows[index].FindControl("lblpoqnty")).Text.ToString();
                            string mrrqnty = ((Label)dgv.Rows[index].FindControl("lblmrrqnty")).Text.ToString();
                            string quantity = ((TextBox)dgv.Rows[index].FindControl("txtChkQuantity")).Text.ToString();
                            string remarks = ((TextBox)dgv.Rows[index].FindControl("txtRemarks")).Text.ToString();

                            string unitid = ((Label)dgv.Rows[index].FindControl("lblintUnitID")).Text.ToString();
                            string locationid = ((Label)dgv.Rows[index].FindControl("lblLocationId")).Text.ToString();
                            string value = ((Label)dgv.Rows[index].FindControl("lblmonBDTTotal")).Text.ToString();

                            ysnChecked = ((CheckBox)dgv.Rows[index].Cells[10].Controls[0]).Checked;
                            if (Convert.ToInt32(quantity) > Convert.ToInt32(mrrqnty))
                            {
                                Toaster("MIR Qty cannot be greater than MRR Qty", "Pending MRR", Common.TosterType.Warning);
                            }
                            else if (Convert.ToInt32(quantity) < Convert.ToInt32(mrrqnty))
                            {
                                Toaster("MIR Qty cannot be less than MRR Qty", "Pending MRR", Common.TosterType.Warning);
                            }
                            else if (Convert.ToInt32(quantity) == Convert.ToInt32(mrrqnty))
                            {
                                if (ysnChecked)
                                {
                                    proceed = "1";
                                }
                                if (quantity.Length <= 0)
                                {
                                    quantity = "0";
                                }
                                if (int.Parse(quantity) > 0)
                                {
                                    dt = mirObj.GetMIRDetails(Convert.ToInt32(hdnmrrid.Value), Convert.ToInt32(itemid));
                                    if (dt.Rows.Count > 0)
                                    {
                                        string qty = dt.Rows[0]["intMRRID"].ToString();
                                        string item = dt.Rows[0]["intItemID"].ToString();
                                        message = "Item ID " + item + " for MRR No " + qty + " already submitted";
                                        Toaster(message, "Pending MRR", Common.TosterType.Warning);
                                    }
                                    else
                                    {
                                        CreateXml(hdnpoid.Value, hdnmrrid.Value, itemid, poqnty, quantity, remarks, proceed, unitid, locationid, value, mrrqnty);
                                    }
                                    
                                }
                            

                        }

                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlpath); int actionby = Enroll;
                        XmlNode nd = doc.SelectSingleNode("Inspection");
                        string xmlString = nd.InnerXml;
                        xmlString = "<Inspection>" + xmlString + "</Inspection>";
                        string msg = mirObj.SaveMIR(xmlString, Convert.ToInt32(ddlWH.SelectedValue), actionby);
                        File.Delete(xmlpath);
                        //dgvlist.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "HideReasonDiv('" + msg + "');", true);
                    }
                    

                }
                catch { }
            }
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

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideShowGridColumn();
        }

        public void HideShowGridColumn()
        {
            if (ddlType.SelectedItem.Value == "QC")
            {
                dgvIndent.Columns[7].Visible = false;
                dgvIndent.Columns[9].Visible = false;
            }
            else if (ddlType.SelectedItem.Value == "Costing")
            {
                dgvIndent.Columns[7].Visible = true;
                dgvIndent.Columns[9].Visible = true;
            }
        }
       
        #endregion

        #region === XML Bind ========
        private void CreateXml(string poid, string mrrid, string itemid, string poqnty, string quantity, string remarks, string proceed, string unitid, string locationid, string value,string mrrqnty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Inspection");
                XmlNode addItem = CreateNode(doc, poid, mrrid, itemid, poqnty, quantity, remarks, proceed, unitid, locationid, value, mrrqnty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Inspection");
                XmlNode addItem = CreateNode(doc, poid, mrrid, itemid, poqnty, quantity, remarks, proceed, unitid, locationid, value, mrrqnty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string poid, string mrrid, string itemid, string poqnty, string quantity, string remarks, string proceed, string unitid, string locationid, string value,string mrrqnty)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute POId = doc.CreateAttribute("poid");
            POId.Value = poid;
            XmlAttribute MRRId = doc.CreateAttribute("mrrid");
            MRRId.Value = mrrid;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute POqnty = doc.CreateAttribute("poqnty");
            POqnty.Value = poqnty;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Proceed = doc.CreateAttribute("proceed");
            Proceed.Value = proceed;
            XmlAttribute UnitId = doc.CreateAttribute("unitid");
            UnitId.Value = unitid;
            XmlAttribute LocationId = doc.CreateAttribute("locationid");
            LocationId.Value = locationid;
            XmlAttribute monValue = doc.CreateAttribute("value");
            monValue.Value = value;
            XmlAttribute MRRQty = doc.CreateAttribute("mrrqnty");
            MRRQty.Value = mrrqnty;

            node.Attributes.Append(POId);
            node.Attributes.Append(MRRId);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(POqnty);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(Proceed);

            node.Attributes.Append(UnitId);
            node.Attributes.Append(LocationId);
            node.Attributes.Append(monValue);
            node.Attributes.Append(MRRQty);

            return node;
        }

        #endregion === End XML =========
    }


}