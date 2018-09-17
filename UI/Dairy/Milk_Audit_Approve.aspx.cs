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
    public partial class Milk_Audit_Approve : BasePage
    {
        #region ===== Variable Decliaration ===================================================================
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_Audit_Approve.aspx";
        string stop = "stopping Dairy/Milk_Audit_Approve.aspx";

        Project_Class obj = new Project_Class();
        DataTable dt;

        int intCCID, intVehicleID, intInsertBy;
        string dteFromDate, dteToDate, ID, filePathForXML, xmlString, xml, mrrno;
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_Approve.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                filePathForXML = Server.MapPath("~/Dairy/Data/MilkMRRApprove_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                    dt = obj.GetChillingCenterName();
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region ===== Show Grid Load ==========================================================================
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }        
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_Approve.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                dteFromDate = txtFrom.Text;
                dteToDate = txtTo.Text;
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                dt = new DataTable();
                dt = obj.GetDataForAudit(dteFromDate.ToString(), dteToDate.ToString(), intCCID);
                dgvAuditApprove.DataSource = dt;
                dgvAuditApprove.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected decimal totalqty = 0;
        protected decimal totalmrramou = 0;
        protected decimal totalbonusamou = 0;
        protected decimal totalpayableamou = 0;
        protected void dgvAuditApprove_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalmrramou += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblMRRAmount")).Text);
                    totalbonusamou += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblBonusAmount")).Text);
                    totalpayableamou += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblPayableAmount")).Text);                    
                }
            }
            catch { }
        }
        #endregion ============================================================================================

        #region ===== Details Report ==========================================================================
        protected void dgvAuditApprove_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_Approve.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "D")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                
                //Reference the GridView Row.
                GridViewRow row = dgvAuditApprove.Rows[rowIndex];

                ID = (row.FindControl("lblMRRNo") as Label).Text;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocListView('" + ID + "');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion ============================================================================================

        #region ===== Bill Complete Action ====================================================================
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_Approve.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    if (dgvAuditApprove.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvAuditApprove.Rows.Count; index++)
                        {
                            mrrno = ((Label)dgvAuditApprove.Rows[index].FindControl("lblMRRNo")).Text.ToString();
                            CreateXml(mrrno);
                        }

                        if (dgvAuditApprove.Rows.Count > 0)
                        {
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("MilkMRRApprove");
                                xmlString = dSftTm.InnerXml;
                                xmlString = "<MilkMRRApprove>" + xmlString + "</MilkMRRApprove>";
                                xml = xmlString;
                            }
                            catch { }
                            if (xml == "") { return; }
                        }

                        //Final Update
                        string message = obj.AuditApprove(intCCID, intInsertBy, xml);

                        if (filePathForXML != null) { File.Delete(filePathForXML); }
                        dgvAuditApprove.DataSource = ""; dgvAuditApprove.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateXml(string mrrno)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("MilkMRRApprove");
                XmlNode addItem = CreateItemNode(doc, mrrno);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("MilkMRRApprove");
                XmlNode addItem = CreateItemNode(doc, mrrno);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string mrrno)
        {
            XmlNode node = doc.CreateElement("MilkMRRApprove");

            XmlAttribute Mrrno = doc.CreateAttribute("mrrno"); Mrrno.Value = mrrno;
            
            node.Attributes.Append(Mrrno);
            return node;
        }
        #endregion ============================================================================================

        



    }
}