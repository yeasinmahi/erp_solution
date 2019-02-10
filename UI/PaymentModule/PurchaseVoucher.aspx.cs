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
    public partial class PurchaseVoucher : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/PurchaseVoucher.aspx";
        string stop = "stopping PaymentModule/PurchaseVoucher.aspx";

        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intUnitID, intType, intUser;
        string strType, filePathForXML, xmlString = "", xml, entryid, partyid, party, poid, narrantion, strEntryTypeName;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PurchaseVoucher.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/PV_" + hdnEnroll.Value + ".xml");
                if (!IsPostBack)
                {
                    try
                    {
                        File.Delete(filePathForXML); dgvPurchaseV.DataSource = ""; dgvPurchaseV.DataBind();

                        dt = new DataTable();
                        dt = objVoucher.GetUserRollCheck(hdnEmail.Value);
                        if (dt.Rows.Count > 0)
                        {
                            hdnCount.Value = dt.Rows[0]["intCount"].ToString();
                        }

                        hdnCount.Value = "1"; // ==== ****** This is hardcoded value use for check
                        if (hdnCount.Value == "0")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                            return;
                        }
                    }
                    catch { }

                    try
                    {
                        dt = new DataTable();
                        dt = objVoucher.GetUnitList(int.Parse(hdnEnroll.Value));
                        if (dt.Rows.Count > 0)
                        {
                            ddlUnit.DataTextField = "strUnit";
                            ddlUnit.DataValueField = "intUnitID";
                            ddlUnit.DataSource = dt;
                            ddlUnit.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                            return;
                        }
                    }
                    catch { }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                //    return;
                //}
                
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PurchaseVoucher.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intType = int.Parse(ddlType.SelectedValue.ToString());
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dgvPurchaseV.DataSource = "";
                dgvPurchaseV.DataBind();
                dt = objVoucher.GetPendingPurchaseVoucher(intUnitID, intType);
                if (dt.Rows.Count > 0)
                {
                    dgvPurchaseV.DataSource = dt;
                    dgvPurchaseV.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPurchaseV.DataSource = ""; dgvPurchaseV.DataBind();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPurchaseV.DataSource = ""; dgvPurchaseV.DataBind();
        }
        protected void btnPrepareAllVoucher_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PurchaseVoucher.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intUser = int.Parse(hdnEnroll.Value);
                    strType = ddlType.SelectedItem.ToString();
                    intType = int.Parse(ddlType.SelectedValue.ToString());

                    if (intType == 1)
                    {
                        strEntryTypeName = "Being the amount payable for credit purchase against MRR NO: ";
                    }
                    else if (intType == 2)
                    {
                        strEntryTypeName = "Being the amount Adjusted for purchase return against RETURN NO: ";
                    }
                    else if (intType == 3)
                    {
                        strEntryTypeName = "Being the amount payable for credit purchase against MRR NO: ";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Auto Voucher is only applicable for purchase and purchase return.');", true);
                        return;
                    }

                    if (filePathForXML != null) { File.Delete(filePathForXML); }

                    if (dgvPurchaseV.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvPurchaseV.Rows.Count; index++)
                        {
                            if (((CheckBox) dgvPurchaseV.Rows[index].FindControl("chkRow")).Checked == true)
                            {
                                entryid = ((Label) dgvPurchaseV.Rows[index].FindControl("lblID")).Text.ToString();
                                partyid = ((Label) dgvPurchaseV.Rows[index].FindControl("lblPartyID")).Text.ToString();
                                party = ((Label) dgvPurchaseV.Rows[index].FindControl("lblPartyName")).Text.ToString();
                                poid = ((Label) dgvPurchaseV.Rows[index].FindControl("lblPOID")).Text.ToString();
                                narrantion = strEntryTypeName + entryid + ", and PO NO: " + poid + ". Party: " + party;

                                if (party != "" || entryid != "" || poid != "")
                                {
                                    CreateVoucherXml(entryid, partyid, party, poid, narrantion);
                                }
                            }
                            else
                            {
                                // not selected
                            }
                            
                        }
                    }

                    if (dgvPurchaseV.Rows.Count > 0)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("PV");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<PV>" + xmlString + "</PV>";
                            xml = xmlString;
                        }
                        catch { }
                    }
                    if (xml == null) { return; }
                    if (xml == "") { return; }

                    //*** Final Insert
                    string message = objVoucher.InsertPurchaseVoucher(intUnitID, intUser, intType, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    if (filePathForXML != null) { File.Delete(filePathForXML); }
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXml(string entryid, string partyid, string party, string poid, string narrantion)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("PV");
                XmlNode addItem = CreateItemNode(doc, entryid, partyid, party, poid, narrantion);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("PV");
                XmlNode addItem = CreateItemNode(doc, entryid, partyid, party, poid, narrantion);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string entryid, string partyid, string party, string poid, string narrantion)
        {
            XmlNode node = doc.CreateElement("PV");
            XmlAttribute Entryid = doc.CreateAttribute("entryid"); Entryid.Value = entryid;
            XmlAttribute Partyid = doc.CreateAttribute("partyid"); Partyid.Value = partyid;
            XmlAttribute Party = doc.CreateAttribute("party"); Party.Value = party;
            XmlAttribute Poid = doc.CreateAttribute("poid"); Poid.Value = poid;
            XmlAttribute Narrantion = doc.CreateAttribute("narrantion"); Narrantion.Value = narrantion;

            node.Attributes.Append(Entryid);
            node.Attributes.Append(Partyid);
            node.Attributes.Append(Party);
            node.Attributes.Append(Poid);
            node.Attributes.Append(Narrantion);
            return node;
        }
        
        
































    }
}