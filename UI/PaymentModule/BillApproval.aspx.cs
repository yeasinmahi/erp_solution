using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class BillApproval : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        private SeriLog log = new SeriLog();
        private string location = "PaymentModule";
        private string start = "starting PaymentModule/BillApproval.aspx";
        private string stop = "stopping PaymentModule/BillApproval.aspx";
        private Billing_BLL objBillReg = new Billing_BLL();
        private DataTable dt;

        private string filePathForXML, xmlString, xml, challan, mrrid, amount;
        private int intUnitid, intPOID, intSuppid, intCOAID, intEnroll, intAction, intEntryType, intLevel, intBillID;
        private string strPType, strReffNo, strSupplierName, billid, actionid;
        private DateTime dteFDate, dteTDate;

        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillApproval.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Enroll.ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/BillApp_" + hdnEnroll.Value + ".xml");
                if (!IsPostBack)
                {
                    File.Delete(filePathForXML);
                    btnApproveAll.Visible = false;
                    hdnLevel.Value = "0";
                    dt = new DataTable();
                    dt = objBillReg.GetUserInfoForAudit(int.Parse(hdnEnroll.Value));
                    if (bool.Parse(dt.Rows[0]["ysnAudit2"].ToString()) == true)
                    {
                        hdnLevel.Value = "2";
                        btnApproveAll.Visible = true;
                        lblHeading.Text = "BILL APPROVAL (LEVEL-2)";
                    }
                    else if (bool.Parse(dt.Rows[0]["ysnAudit1"].ToString()) == true)
                    {
                        hdnLevel.Value = "1";
                        lblHeading.Text = "BILL APPROVAL (LEVEL-1)";
                    }
                    if (hdnLevel.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Bill Approval Permission Denied.');", true);
                        return;
                    }

                    //File.Delete(filePathForXML);
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    dt = objBillReg.GetAllUnit(Enroll);


                    //if (Enroll == 1178)
                    //{
                    //    DataRow dr = dt.AsEnumerable()
                    //        .SingleOrDefault(r => r.Field<int>("intUnitID") == 105);
                    //    //DataTable temp = new DataTable();
                    //    //dt.Clear();
                    //    //dt.AcceptChanges();
                    //    //dt.Rows.Add(dr.ItemArray);

                    //    foreach (DataRow row in dt.Rows)
                    //    {
                    //        if (!row.Equals(dr))
                    //        {
                    //            dt.Rows.Remove(row);
                    //        }
                    //    }
                    //    dt.AcceptChanges();
                    //}
                    //else
                    //{
                    //    DataRow dr = dt.AsEnumerable()
                    //        .SingleOrDefault(r => r.Field<int>("intUnitID") == 105);
                    //    dt.Rows.RemoveAt(dt.Rows.IndexOf(dr));
                    //}
                     

                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();
                    if (Enroll != 1178)
                    {
                        ddlUnit.Items.Insert(0, new ListItem("All Unit", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region===== Button Action============ ===================================================

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnApproveAll_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillApproval.aspx btnApproveAll_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    if (dgvBillReport.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvBillReport.Rows.Count; index++)
                        {
                            billid = ((Label)dgvBillReport.Rows[index].FindControl("lblID")).Text.ToString();
                            actionid = ((DropDownList)dgvBillReport.Rows[index].FindControl("ddlActionStatus")).SelectedValue.ToString();

                            if (billid != "" && actionid != "" && actionid != "1")
                            {
                                CreateVoucherXml(billid, actionid);
                            }
                        }
                    }

                    if (dgvBillReport.Rows.Count > 0)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("BillApp");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<BillApp>" + xmlString + "</BillApp>";
                            xml = xmlString;
                        }
                        catch { }
                    }
                    if (xml == "") { return; }

                    //*** Final Insert
                    string message = objBillReg.InsertAllBillApproval(int.Parse(hdnLevel.Value), int.Parse(hdnEnroll.Value), xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnApproveAll_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnApproveAll_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateVoucherXml(string billid, string actionid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("BillApp");
                XmlNode addItem = CreateItemNode(doc, billid, actionid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BillApp");
                XmlNode addItem = CreateItemNode(doc, billid, actionid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string billid, string actionid)
        {
            XmlNode node = doc.CreateElement("BillApp");
            XmlAttribute Billid = doc.CreateAttribute("billid"); Billid.Value = billid;
            XmlAttribute Actionid = doc.CreateAttribute("actionid"); Actionid.Value = actionid;

            node.Attributes.Append(Billid);
            node.Attributes.Append(Actionid);
            return node;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            LoadGridSingle();
        }

        private void LoadGridSingle()
        {
            var fd = log.GetFlogDetail(start, location, "btnGo_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillApproval.aspx btnGo_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                strReffNo = txtBillRegNo.Text;

                dt = objBillReg.GetBillInfoByBillReg(Enroll, strReffNo);
                dgvBillReport.DataSource = dt;
                dgvBillReport.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnGo_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnGo_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillApproval.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            intUnitid = int.Parse(ddlUnit.SelectedValue.ToString());
            dteFDate = DateTime.Parse(txtFromDate.Text);
            dteTDate = DateTime.Parse(txtToDate.Text);
            intAction = int.Parse(ddlAction.SelectedValue.ToString());
            intEntryType = 1;
            intLevel = int.Parse(hdnLevel.Value);

            dt = objBillReg.GetPaymentApprovalSummaryAllUnitForWeb(intUnitid, dteFDate, dteTDate, intAction, intEntryType, intLevel);
            dgvBillReport.DataSource = dt;
            dgvBillReport.DataBind();

            dgvBillReport.Columns[12].Visible = false;
            dgvBillReport.Columns[1].Visible = false;
            dgvBillReport.Columns[7].Visible = false;
            dgvBillReport.Columns[8].Visible = false;
            dgvBillReport.Columns[11].Visible = false;

            if (hdnLevel.Value == "1")
            {
                dgvBillReport.Columns[12].Visible = true;
                dgvBillReport.Columns[1].Visible = true;
                dgvBillReport.Columns[7].Visible = true;
                dgvBillReport.Columns[8].Visible = true;
                dgvBillReport.Columns[11].Visible = false;
            }
            else
            {
                dgvBillReport.Columns[12].Visible = false;
                dgvBillReport.Columns[1].Visible = false;
                dgvBillReport.Columns[7].Visible = false;
                dgvBillReport.Columns[8].Visible = false;
                dgvBillReport.Columns[11].Visible = true;
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #endregion=====================================================================================

        protected void dgvBillReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvBillReport.Rows[rowIndex];

            char[] ch1 = { ':', ':' };
            string[] temp1 = (row.FindControl("lblReff") as Label).Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
            string strPOCheck = temp1[0].ToString();
            try { intPOID = int.Parse(temp1[1].ToString()); } catch { intPOID = 0; }

            if (e.CommandName == "S")
            {
                try
                {
                    if (strPOCheck == "PO")
                    {
                        Session["pono"] = intPOID.ToString();//intBillID.ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('../SCM/PoDetalisView.aspx');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This is not a PO.');", true);
                        return;
                    }
                }
                catch { }
            }
            else if (e.CommandName == "SD")
            {
                Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                intBillID = int.Parse((row.FindControl("lblID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + intBillID.ToString() + "');", true);
            }
            else if (e.CommandName == "A")
            {
                Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                intBillID = int.Parse((row.FindControl("lblID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewApproveActionPopup('" + intBillID.ToString() + "');", true);
            }
        }
    }
}