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
using UI.ClassFiles;
using SAD_BLL.Vat;
using System.IO;
using System.Xml;

namespace UI.VAT_Management
{
    public partial class BandrollReceive : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intDepositType;
        DateTime dteTrChallan, dteInstrument, dteTransactionDate;
        decimal monAmount;
        string strTrChallanNo, strInstrumentNo, filePathForXML, xmlString = "", xml, brid, brname, demno, demdate, dono, dodate, recdate, recqty;
        #endregion =====================================================================================
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                filePathForXML = Server.MapPath("~/VAT_Management/Data/BandrollReceive_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvBandrollReceive.DataSource = ""; dgvBandrollReceive.DataBind();
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    hdnysnFactory.Value = "0";
                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }

                    if (hdnysnFactory.Value == "0")
                    {
                        return;
                    }

                    //dt = new DataTable();
                    //dt = objvat.GetTreasuryDepositType();
                    //ddlDepositFor.DataTextField = "strTreasuryDepositDescription";
                    //ddlDepositFor.DataValueField = "intTreasuryDepositID";
                    //ddlDepositFor.DataSource = dt;
                    //ddlDepositFor.DataBind();
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }



        #region ===== Bandroll Receive Submit Action ==========================================
        protected void btnSaveReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    //string message = objvat.InsertTreasuryDeposit(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), intDepositType, monAmount, int.Parse(hdnEnroll.Value), strTrChallanNo, dteTrChallan, strInstrumentNo, dteInstrument, dteTransactionDate);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                }
            }
            catch { }
        }

        #endregion ============================================================================

        #region ===== Material Add Option =====================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                try { int intBID = int.Parse(ddlBandroll.SelectedValue.ToString()); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Bandroll selected.');", true);
                    return;
                }

                try
                {
                    DateTime dtedo = DateTime.Parse(txtDODate.Text);
                    DateTime dterec = DateTime.Parse(txtReceiveDate.Text);                    
                    dodate = txtDODate.Text;
                    recdate = txtReceiveDate.Text;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Do No., Do Date and Receive date Cannot be blank.');", true);
                    return;
                }
                if(txtDeliveryOrderNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Do No. Cannot be blank.');", true);
                    return;
                }
                dono = txtDeliveryOrderNo.Text;

                if (txtDemOrderNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Demand Order No. Cannot be blank.');", true);
                    return;
                }
                demno = txtDemOrderNo.Text;

                try { DateTime dtedem = DateTime.Parse(txtDate.Text); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Demand Order Date Cannot be blank.');", true);
                    return;
                }
                demdate = txtDate.Text;

                try { decimal qt = decimal.Parse(txtQuantity.Text); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Quantity Given.');", true);
                    return;
                }
                if(txtQuantity.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Quantity Given.');", true);
                    return;
                }
                recqty = txtQuantity.Text;

                brid = ddlBandroll.SelectedValue.ToString();
                brname = ddlBandroll.SelectedItem.ToString();

                #region ********* Duplicate Bandroll Check ****************************************                
                if (dgvBandrollReceive.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvBandrollReceive.Rows.Count; index++)
                    {
                        string olditemid = ((Label)dgvBandrollReceive.Rows[index].FindControl("lblBandrollID")).Text.ToString();

                        if (olditemid == brid)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Bandroll is already added.');", true);
                            return;
                        }
                    }
                }

                #endregion ************************************************************************

                //Start Create XML
                CreateVoucherXml(brid, brname, demno, demdate, dono, dodate, recdate, recqty);
                txtDemOrderNo.Text = "";
                txtDate.Text = "";
                txtDeliveryOrderNo.Text = "";
                txtDODate.Text = "";
                txtReceiveDate.Text = "";
                txtQuantity.Text = "";                
            }
            catch { }
        }
        private void CreateVoucherXml(string brid, string brname, string demno, string demdate, string dono, string dodate, string recdate, string recqty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, brid, brname, demno, demdate, dono, dodate, recdate, recqty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, brid, brname, demno, demdate, dono, dodate, recdate, recqty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
            xmlString = dSftTm.InnerXml;
            xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvBandrollReceive.DataSource = ds; }
            else { dgvBandrollReceive.DataSource = ""; }
            dgvBandrollReceive.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string brid, string brname, string demno, string demdate, string dono, string dodate, string recdate, string recqty)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Brid = doc.CreateAttribute("brid"); Brid.Value = brid;
            XmlAttribute Brname = doc.CreateAttribute("brname"); Brname.Value = brname;
            XmlAttribute Demno = doc.CreateAttribute("demno"); Demno.Value = demno;
            XmlAttribute Demdate = doc.CreateAttribute("demdate"); Demdate.Value = demdate;
            XmlAttribute Dono = doc.CreateAttribute("dono"); Dono.Value = dono;
            XmlAttribute Dodate = doc.CreateAttribute("dodate"); Dodate.Value = dodate;
            XmlAttribute Recdate = doc.CreateAttribute("recdate"); Recdate.Value = recdate;
            XmlAttribute Recqty = doc.CreateAttribute("recqty"); Recqty.Value = recqty;

            node.Attributes.Append(Brid);
            node.Attributes.Append(Brname);
            node.Attributes.Append(Demno);
            node.Attributes.Append(Demdate);
            node.Attributes.Append(Dono);
            node.Attributes.Append(Dodate);
            node.Attributes.Append(Recdate);
            node.Attributes.Append(Recqty);
            return node;
        }
        protected void dgvBandrollReceive_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                xmlString = dSftTm.InnerXml;
                xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvBandrollReceive.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvBandrollReceive.DataSource;
                dsGrid.Tables[0].Rows[dgvBandrollReceive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvBandrollReceive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvBandrollReceive.DataSource = ""; dgvBandrollReceive.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal rceqtygrandtotal = 0;
        protected void dgvBandrollReceive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                try
                {
                    rceqtygrandtotal += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblReceiveQty")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion ============================================================================






















    }
}