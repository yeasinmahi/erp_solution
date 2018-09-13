using Flogging.Core;
using GLOBAL_BLL;
using HR_BLL.Global;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IndentsApproval : System.Web.UI.Page
    {
        Indents_BLL objIndent = new Indents_BLL();
        DataTable dt = new DataTable();
        string xmlunit = ""; int enroll, CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "", indentQty;

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\IndentsApproval";
        string stop = "stopping SCM\\IndentsApproval";
        string perform = "Performance on SCM\\IndentsApproval";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/InAp__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML);}
                catch { }
                CalendarExtenderFrom.SelectedDate = DateTime.Now;
                CalendarExtenderTO.SelectedDate = DateTime.Now;
                DefaltDataBind();
            }
            else
            {

            }

        }

        private void DefaltDataBind()
        {
            var fd = log.GetFlogDetail(start, location, "DefaltDataBind", null);
            Flogger.WriteDiagnostic(fd);
           
            var tracker = new PerfTracker(perform + " " + "DefaltDataBind", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIndent.DataView(16, xmlunit, 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                dt.Clear();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefaltDataBind", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "DefaltDataBind", null);
            Flogger.WriteDiagnostic(fd);           
            tracker.Stop();

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
                Label lblIndents = row.FindControl("lblIndent") as Label;
                Label lblIndentDates = row.FindControl("lblIndentDate") as Label;
                Label lblDueDates = row.FindControl("lblDueDate") as Label;
                Label lblIndentTypes = row.FindControl("lblIndentType") as Label;
                lblIndentNo.Text = lblIndents.Text.ToString();
                DateTime dteIndent = DateTime.Parse(lblIndentDates.Text.ToString());
                lblIndentDate.Text = dteIndent.ToString("yyyy-mm-dd");
                DateTime dteDue = DateTime.Parse(lblDueDates.Text.ToString());
                lblDueDate.Text = dteDue.ToString("yyyy-mm-dd");
                lblIndentType.Text = lblIndentTypes.Text.ToString();

                int indentId = int.Parse(lblIndents.Text);
                intWh = int.Parse(ddlWH.SelectedValue);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                dgvIndent.Visible = false;

                dt = objIndent.DataView(8, "", intWh, indentId, DateTime.Now, enroll);
                dgvDetalis.DataSource = dt;
                dgvDetalis.DataBind();
                dt.Clear();
            }
           catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDetalis_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);           
            tracker.Stop();
           
        }

        protected void btnClsoe_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnDiv();", true);
                 
            }
            catch { }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML); } catch { } 
                intWh = int.Parse(ddlWH.SelectedValue);
                if (dgvDetalis.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString()); 
                    for (int index = 0; index < dgvDetalis.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvDetalis.Rows[index].FindControl("chkRow")).Checked == true)
                        { 
                            string itemid = ((Label)dgvDetalis.Rows[index].FindControl("lblItemIds")).Text.ToString();
                            string indentId = hdnIndentNo.Value.ToString(); 
                            CreateVoucherXml(itemid, indentId); 
                        } 
                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { } 
                string  msgs = objIndent.IndentEntry(10, xmlString, intWh, 0, DateTime.Now, enroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgs + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnDiv();", true);

                dgvDetalis.DataSource = ""; dgvDetalis.DataBind();
                dt = objIndent.DataView(7, "", intWh, 0, DateTime.Now, enroll);
                //dgvIndent.DataSource = dt;
                //dgvIndent.DataBind();
                dgvIndent.Visible = true;
                dt.Clear();
            }


            catch { }
        }

        private void CreateVoucherXml(string itemid, string indentId)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateApprove(doc, itemid, indentId);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateApprove(doc, itemid, indentId);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateApprove(XmlDocument doc, string itemid, string indentId)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute IndentId = doc.CreateAttribute("indentId");
            IndentId.Value = indentId;
             




            node.Attributes.Append(Itemid);
            node.Attributes.Append(IndentId); 
            return node;
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnApprove_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                try { File.Delete(filePathForXML); } catch { }
                intWh = int.Parse(ddlWH.SelectedValue);
                if (dgvDetalis.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString()); 
                    for (int index = 0; index < dgvDetalis.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvDetalis.Rows[index].FindControl("chkRow")).Checked == true)
                        { 
                            string itemid = ((Label)dgvDetalis.Rows[index].FindControl("lblItemIds")).Text.ToString();
                            string indentId = lblIndentNo.Text.ToString(); 
                            CreateVoucherXml(itemid, indentId); 
                        } 
                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }
                string msgs = objIndent.IndentEntry(9, xmlString, intWh, int.Parse(lblIndentNo.Text.ToString()), DateTime.Now, enroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgs + "');", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnDiv();", true);

                dgvDetalis.DataSource = ""; dgvDetalis.DataBind();
                string dteFrom = txtDteFrom.Text.ToString();
                string dteTo = txtdteTo.Text.ToString();
                string xml = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                dt = objIndent.DataView(7, xml, intWh, 0, DateTime.Now, enroll);
                //dgvIndent.DataSource = dt;
                //dgvIndent.DataBind();
                dgvIndent.Visible = true;
            }


            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnApprove_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.DataSource = "";
                dgvIndent.DataBind();
            }
            catch { }
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string dteFrom = txtDteFrom.Text.ToString();
                string dteTo = txtdteTo.Text.ToString();
                int Type = int.Parse(ddlApproval.SelectedValue.ToString());
                int wh = int.Parse(ddlWH.SelectedValue);
                string xml = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' +"/></voucher>".ToString();

                dt = objIndent.DataView(7, xml, wh, Type, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvIndent.DataSource = dt;
                    dgvIndent.DataBind();
                    dgvIndent.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Po Number Invalid or Approve or Reject');", true);
                }
               
                dt.Clear();
                

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void ddlApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.DataSource = "";
                dgvIndent.DataBind();
            }
            catch { }

        }
    }
}