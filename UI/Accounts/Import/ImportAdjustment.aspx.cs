using BLL.Accounts.Import;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Accounts.Import
{
    public partial class ImportAdjustment : System.Web.UI.Page
    {
        #region INIT
        ImportAdjustmentVoucherBLL objIAVbll = new ImportAdjustmentVoucherBLL();
        SeriLog log = new SeriLog();
        string location = "Import Adjustment";
        string start = "starting Import/ImportAdjustment.aspx";
        string stop = "stopping Import/ImportAdjustment.aspx";
        DataTable dt;
        string filePathForXML; string xmlString = ""; string xml;
        DateTime dteFromDate, dteToDate;
        decimal monAmount;
        int intUnitID, intUserID;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Accounts/Import/Data/ImportVoucher_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                FillDropdown();
            }
        }


        #endregion

        #region Event
        protected void btnReportShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/POVoucherOfAFBL.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intUnitID = int.Parse(hdnUnit.Value);
                    intUserID = int.Parse(hdnEnroll.Value);

                    if (dgvReportForImportVoucher.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvReportForImportVoucher.Rows.Count; index++)
                        {
                            if (((CheckBox)dgvReportForImportVoucher.Rows[index].FindControl("chkRow")).Checked == true)
                            {
                                int LCType = int.Parse(((HiddenField)dgvReportForImportVoucher.Rows[index].FindControl("hfGVLCType")).Value.ToString());
                                int ShipID = int.Parse(((HiddenField)dgvReportForImportVoucher.Rows[index].FindControl("hfGVShipID")).Value.ToString());
                                int CostGroupId = int.Parse(((HiddenField)dgvReportForImportVoucher.Rows[index].FindControl("hfGVCostGroup")).Value.ToString());

                                string LCNo = ((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblLcNo")).Text.ToString();
                                int ShipNo = int.Parse(((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblShipNo")).Text.ToString());

                                string CostGroup = ((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblCostGroup")).Text.ToString();
                                decimal ProvTk = decimal.Parse(((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblProvTk")).Text.ToString());

                                decimal ActualValue = decimal.Parse(((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblActualValue")).Text.ToString());

                                DateTime ProvDate = DateTime.ParseExact(((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblProvDate")).Text.ToString(),
                                    "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                Label lblActualDate = (Label)dgvReportForImportVoucher.Rows[index].FindControl("lblActualDate");
                                DateTime ActualDate = !string.IsNullOrEmpty(lblActualDate.Text) ? DateTime.ParseExact(lblActualDate.Text,
                                "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue;
                                //DateTime ActualDate =  DateTime.ParseExact(((Label)dgvReportForImportVoucher.Rows[index].FindControl("lblActualDate")).Text.ToString(),
                                //    "dd/MM/yyyy", CultureInfo.InvariantCulture);

                                //CreateXml(LCNo, LCType, ShipNo, ShipID, CostGroup, CostGroupId, ProvTk, ProvDate, ActualValue, ActualDate);
                                if (ActualValue > 0)
                                {
                                    CreateXml(LCNo, LCType, ShipNo, ShipID, CostGroup, CostGroupId, ProvTk, ProvDate, ActualValue, ActualDate);
                                }

                                //File.Delete(filePathForXML);
                                //LoadGrid();
                            }
                        }

                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            if (File.Exists(filePathForXML))
                            {
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("Adj");
                                string xmlString = dSftTm.InnerXml;
                                xmlString = "<Adj>" + xmlString + "</Adj>";
                                xml = xmlString;
                            }
                            
                            if (string.IsNullOrEmpty(xml))
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found for Save. Maybe or Maybe not for Actual Value.');", true);
                                LoadGrid();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.Message.ToString() + "');", true);
                        }
                        File.Delete(filePathForXML);
                       // string result = string.Empty;
                        string result = objIAVbll.ImportVoucherAdjustment(intUnitID, intUserID,xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + result + "');", true);
                    }
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

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Method
        private void FillDropdown()
        {
            DataTable dt = new DataTable();
            try
            {
                int enroll = int.Parse(hdnEnroll.Value);
                dt = objIAVbll.GetAllUnitByEnroll(enroll);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();
                }
                ddlUnit.Items.Insert(0, new ListItem("--- Select Unit ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Import/ImportAdjustment.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
           
            try
            {
                if (Validation() == true)
                {
                    intUnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    intUserID = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dteFromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dteToDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dgvReportForImportVoucher.DataSource = "";
                    dgvReportForImportVoucher.DataBind();
                    dt = objIAVbll.GetImportAdjustmentReportForVoucherData(intUnitID, intUserID, dteFromDate, dteToDate);
                    if (dt.Rows.Count > 0)
                    {
                        dgvReportForImportVoucher.DataSource = dt;
                        dgvReportForImportVoucher.DataBind();
                    }
                }
                fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        private bool Validation()
        {
            if (ddlUnit.SelectedValue == "-1")
            {
                ddlUnit.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Unit First!');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtFromDate.Text))
            {
                txtFromDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enter From Date');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtToDate.Text))
            {
                txtToDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enter To Date');", true);
                return false;
            }

            return true;
        }
        private void CreateXml(string strLc, int intLcType, int intShipNo, int intShipId, string strCostGroup, int intCostGroup,
            decimal monProvTk, DateTime dteProvDate, decimal monActual, DateTime dteActualDate)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Adj");
                XmlNode addItem = CreateItemNode(doc, strLc, intLcType.ToString(), intShipNo.ToString(), intShipId.ToString(),
                    strCostGroup, intCostGroup.ToString(), monProvTk.ToString(), dteProvDate.ToString(), monActual.ToString(),
                    dteActualDate.ToString());
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Adj");
                XmlNode addItem = CreateItemNode(doc, strLc, intLcType.ToString(), intShipNo.ToString(), intShipId.ToString(),
                    strCostGroup, intCostGroup.ToString(), monProvTk.ToString(), dteProvDate.ToString(), monActual.ToString(),
                    dteActualDate.ToString());
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

        }
        private XmlNode CreateItemNode(XmlDocument doc, string strLc, string intLcType, string intShipNo, string intShipId,
            string strCostGroup, string intCostGroup, string monProvTk, string dteProvDate, string monActual, string dteActualDate)
        {
            XmlNode node = doc.CreateElement("Adj");

            XmlAttribute StrLc = doc.CreateAttribute("strLc");
            StrLc.Value = strLc;
            XmlAttribute IntLcType = doc.CreateAttribute("intLcType");
            IntLcType.Value = intLcType;
            XmlAttribute IntShipNo = doc.CreateAttribute("intShipNo");
            IntShipNo.Value = intShipNo;
            XmlAttribute IntShipId = doc.CreateAttribute("intShipId");
            IntShipId.Value = intShipId;
            XmlAttribute StrCostGroup = doc.CreateAttribute("strCostGroup");
            StrCostGroup.Value = strCostGroup;
            XmlAttribute IntCostGroup = doc.CreateAttribute("intCostGroup");
            IntCostGroup.Value = intCostGroup;
            XmlAttribute MonProvTk = doc.CreateAttribute("monProvTk");
            MonProvTk.Value = monProvTk;
            XmlAttribute DteProvDate = doc.CreateAttribute("dteProvDate");
            DteProvDate.Value = dteProvDate;
            XmlAttribute MonActual = doc.CreateAttribute("monActual");
            MonActual.Value = monActual;
            XmlAttribute DteActualDate = doc.CreateAttribute("dteActualDate");
            DteActualDate.Value = dteActualDate;

            node.Attributes.Append(StrLc);
            node.Attributes.Append(IntLcType);
            node.Attributes.Append(IntShipNo);
            node.Attributes.Append(IntShipId);
            node.Attributes.Append(StrCostGroup);
            node.Attributes.Append(IntCostGroup);
            node.Attributes.Append(MonProvTk);
            node.Attributes.Append(DteProvDate);
            node.Attributes.Append(MonActual);
            node.Attributes.Append(DteActualDate);

            return node;
        }
        #endregion



    }
}