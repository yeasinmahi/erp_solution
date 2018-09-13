using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Dairy
{
    public partial class Milk_MRR_By_Factory : BasePage
    {
        #region ===== Variable Decliaration ===================================================================
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_MRR_By_Factory.aspx";
        string stop = "stopping Dairy/Milk_MRR_By_Factory.aspx";

        Project_Class objDairy = new Project_Class();
        DataTable dt;

        int intCCID, intVehicleID, intInsertBy;
        string dteDate, suppid, mrrqty, mrrfat, mrrrate, dqtyamount, dfatamount, mrrvalue, challanno, challanqty,
        challanfat, challanamount, issueid, filePathForXML, xmlString, xml;
        DateTime dteMRRDate;
        decimal decMRRFat;
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_MRR_By_Factory.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Dairy/Data/MilkMRR_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                    dt = objDairy.GetChillingCenterName();
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();

                    ddVehicleBind();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }   

        #region ===== Grid Load Action ========================================================================
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_MRR_By_Factory.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                try
                {
                    dteDate = txtFrom.Text;
                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
                }
                catch { }

                dt = new DataTable();
                dt = objDairy.GetDataForMRR(intVehicleID, dteDate, intCCID);
                dgvMRR.DataSource = dt;
                dgvMRR.DataBind();
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected decimal totalissueqty = 0;
        protected decimal totalissuevalue = 0;
        protected decimal totalrecqty = 0;
        protected decimal totalqtydedamou = 0;
        protected decimal totalfatdedamou = 0;
        protected decimal totalnetvalue = 0;
        protected void dgvMRR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalissueqty += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblIssueQty")).Text);
                    totalissuevalue += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblIssueValue")).Text);
                    totalrecqty += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblRecQty")).Text);
                    totalqtydedamou += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblDeductQtyAmount")).Text);
                    totalfatdedamou += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblDeductFatPer")).Text);
                    totalnetvalue += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblNetValue")).Text);
                }
            }
            catch { }
        }        
        #endregion ============================================================================================

        #region ===== Selection Change Action =================================================================
        protected void ddlVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filePathForXML != null) { File.Delete(filePathForXML); }
            dgvMRR.DataSource = ""; dgvMRR.DataBind();
        }        
        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

                dt = new DataTable();
                dt = objDairy.GetVehicleListByCCID(intCCID);
                ddlVehicleNo.DataTextField = "strVehicleNo";
                ddlVehicleNo.DataValueField = "intVehicleID";
                ddlVehicleNo.DataSource = dt;
                ddlVehicleNo.DataBind();
            }
            catch { }
        }
        private void ddVehicleBind()
        {
            intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

            dt = new DataTable();
            dt = objDairy.GetVehicleListByCCID(intCCID);
            ddlVehicleNo.DataTextField = "strVehicleNo";
            ddlVehicleNo.DataValueField = "intVehicleID";
            ddlVehicleNo.DataSource = dt;
            ddlVehicleNo.DataBind();
        }
        #endregion ============================================================================================

        #region ===== Bill Complete Action ====================================================================
        protected void btnMRRSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_MRR_By_Factory.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if(txtMRRDate.Text == "")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input MRR Date');", true); return; }
                    dteMRRDate = DateTime.Parse(txtMRRDate.Text);
                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
                    if(txtTQuantity.Text == "" || txtTQuantity.Text == "0")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Quantity');", true); return; }
                    if (txtTFatPercentage.Text == "" || txtTFatPercentage.Text == "0")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Fat %');", true); return; }

                    decMRRFat = decimal.Parse(txtTFatPercentage.Text);
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    if (dgvMRR.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvMRR.Rows.Count; index++)
                        {
                            suppid = ((Label)dgvMRR.Rows[index].FindControl("lblSupplierID")).Text.ToString();
                            mrrqty = ((Label)dgvMRR.Rows[index].FindControl("lblRecQty")).Text.ToString();
                            mrrrate = ((Label)dgvMRR.Rows[index].FindControl("lblIssueRate")).Text.ToString();
                            dqtyamount = ((Label)dgvMRR.Rows[index].FindControl("lblDeductQtyAmount")).Text.ToString();
                            dfatamount = ((Label)dgvMRR.Rows[index].FindControl("lblDeductFatPer")).Text.ToString();
                            mrrvalue = ((Label)dgvMRR.Rows[index].FindControl("lblNetValue")).Text.ToString();
                            challanno = ((Label)dgvMRR.Rows[index].FindControl("lblChallanNo")).Text.ToString();
                            challanqty = ((Label)dgvMRR.Rows[index].FindControl("lblIssueQty")).Text.ToString();
                            challanfat = ((Label)dgvMRR.Rows[index].FindControl("lblIssueFat")).Text.ToString();
                            challanamount = ((Label)dgvMRR.Rows[index].FindControl("lblIssueValue")).Text.ToString();
                            issueid = ((Label)dgvMRR.Rows[index].FindControl("lblIssueID")).Text.ToString();
                            
                            CreateXml(suppid, mrrqty, mrrrate, dqtyamount, dfatamount, mrrvalue, challanno, challanqty, challanfat, challanamount, issueid);
                        }

                        if (dgvMRR.Rows.Count > 0)
                        {
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("MilkMRR");
                                xmlString = dSftTm.InnerXml;
                                xmlString = "<MilkMRR>" + xmlString + "</MilkMRR>";
                                xml = xmlString;
                            }
                            catch { }
                            if (xml == "") { return; }
                        }

                        //Final Update
                        string message = objDairy.InsertMilkMrrForFactory(dteMRRDate, intCCID, intVehicleID, decMRRFat, intInsertBy, xml);

                        if (filePathForXML != null) { File.Delete(filePathForXML); }
                        dgvMRR.DataSource = ""; dgvMRR.DataBind();
                        txtMRRDate.Text = "";
                        txtTQuantity.Text = "";
                        txtTFatPercentage.Text = "";
                        txtFrom.Text = "";
                        ddVehicleBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }
        private void CreateXml(string suppid, string mrrqty, string mrrrate, string dqtyamount, string dfatamount, string mrrvalue, string challanno, string challanqty, string challanfat, string challanamount, string issueid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("MilkMRR");
                XmlNode addItem = CreateItemNode(doc, suppid, mrrqty, mrrrate, dqtyamount, dfatamount, mrrvalue, challanno, challanqty, challanfat, challanamount, issueid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("MilkMRR");
                XmlNode addItem = CreateItemNode(doc, suppid, mrrqty, mrrrate, dqtyamount, dfatamount, mrrvalue, challanno, challanqty, challanfat, challanamount, issueid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string suppid, string mrrqty, string mrrrate, string dqtyamount, string dfatamount, string mrrvalue, string challanno, string challanqty, string challanfat, string challanamount, string issueid)
        {
            XmlNode node = doc.CreateElement("MilkMRR");

            XmlAttribute Suppid = doc.CreateAttribute("suppid"); Suppid.Value = suppid;
            XmlAttribute Mrrqty = doc.CreateAttribute("mrrqty"); Mrrqty.Value = mrrqty;
            XmlAttribute Mrrrate = doc.CreateAttribute("mrrrate"); Mrrrate.Value = mrrrate;
            XmlAttribute Dqtyamount = doc.CreateAttribute("dqtyamount"); Dqtyamount.Value = dqtyamount;
            XmlAttribute Dfatamount = doc.CreateAttribute("dfatamount"); Dfatamount.Value = dfatamount;
            XmlAttribute Mrrvalue = doc.CreateAttribute("mrrvalue"); Mrrvalue.Value = mrrvalue;
            XmlAttribute Challanno = doc.CreateAttribute("challanno"); Challanno.Value = challanno;
            XmlAttribute Challanqty = doc.CreateAttribute("challanqty"); Challanqty.Value = challanqty;
            XmlAttribute Challanfat = doc.CreateAttribute("challanfat"); Challanfat.Value = challanfat;
            XmlAttribute Challanamount = doc.CreateAttribute("challanamount"); Challanamount.Value = challanamount;
            XmlAttribute Issueid = doc.CreateAttribute("issueid"); Issueid.Value = issueid;

            node.Attributes.Append(Suppid);
            node.Attributes.Append(Mrrqty);
            node.Attributes.Append(Mrrrate);
            node.Attributes.Append(Dqtyamount);
            node.Attributes.Append(Dfatamount);
            node.Attributes.Append(Mrrvalue);
            node.Attributes.Append(Challanno);
            node.Attributes.Append(Challanqty);
            node.Attributes.Append(Challanfat);
            node.Attributes.Append(Challanamount);
            node.Attributes.Append(Issueid);
            return node;
        }
        #endregion ============================================================================================



















    }
}