using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoGenerate : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll,intWh;
        string filePathForXML, filePathForXMLPrepare, filePathForXMLPo, othersTrems, warrentyperiod; string xmlString = "";
        int indentNo,whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem; string payDate, paymentTrems, destDelivery, paymentSchedule; DateTime dtePo, dtelastShipment; decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;
        string[] arrayKey; string strType; char[] delimiterChars = { '[', ']' };


        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\PoGenerate";
        string stop = "stopping SCM\\PoGenerate";
        string perform = "Performance on SCM\\PoGenerate";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/In__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLPrepare = Server.MapPath("~/SCM/Data/InPre__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLPo = Server.MapPath("~/SCM/Data/Po__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                try { File.Delete(filePathForXMLPrepare); } catch { }
                try { File.Delete(filePathForXMLPo); } catch { }
                DateTime dte = DateTime.Now;
                txtdtePo.Text = dte.ToString("yyyy-MM-dd");
                dte = DateTime.Parse(txtdtePo.Text);

                DefaltPageLoad();
            }
            else
            {

            }
        }

        protected void btnPoView_Click(object sender, EventArgs e)
        {
            try
            {
                MrrReceive_BLL obj = new MrrReceive_BLL();
                int  intPo = int.Parse(txtPoNumber.Text);
                dt = obj.GetPO(intPo);
                if (dt.Rows.Count > 0)
                {
                    Session["pono"] = txtPoNumber.Text.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PoDetalisView.aspx');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO  not Found');", true);

                }


            }
            catch { }
        }

        //protected void ddlSuppliyer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //        int suppid = int.Parse(ddlSuppliyer.SelectedValue);

        //        dt = objPo.GetPoData(22, "", 0, suppid, DateTime.Now, enroll);
        //        if(dt.Rows.Count>0)
        //        {
        //            lblSuppAddress.Text = dt.Rows[0]["strName"].ToString();
        //        }
        //    }
        //    catch { }
        //}
        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string strSupp = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { strSupp = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
             
                dt = objPo.GetPoData(22, "", 0, supplierid, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSuppAddress.Text = dt.Rows[0]["strName"].ToString();
                }

            }
            catch { }

        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, "", HttpContext.Current.Session["unitId"].ToString());
        }


        #endregion====================Close===============================

      

        private void DefaltPageLoad()
        {
            var fd = log.GetFlogDetail(start, location, "DefaltPageLoad", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "DefaltPageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                txtDtefroms.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtdtePo.Text= DateTime.Now.ToString("yyyy-MM-dd");
                txtDteTo.Text= DateTime.Now.ToString("yyyy-MM-dd");
                dt = objPo.GetPoData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                dt.Clear();
                dt = objPo.GetPoData(21, "", 0, 0, DateTime.Now, enroll);
                ddlDepts.DataSource = dt;
                ddlDepts.DataTextField = "strName";
                ddlDepts.DataValueField = "Id";
                ddlDepts.DataBind();
                dt.Clear();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefaltPageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "DefaltPageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        } 

        #region=============Indent Sumery Tab-1 ==============================
        protected void Tab1_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                Tab5.CssClass = "Initial";

                MainView.ActiveViewIndex = 0;
            }
            catch { } 
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                hdnWHId.Value = intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString(); 
                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtDteTo.Text.ToString());
                string dept = ddlDepts.SelectedItem.ToString(); 
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"'+ " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(2, xmlData, intWh, 0, dteFrom, enroll);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
                dt.Clear();


            }
            catch { }
        }

        protected void btnSearchIndent_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                hdnWHId.Value = intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString();
                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtDteTo.Text.ToString());
                string dept = ddlDepts.SelectedItem.ToString();
                int indentId = int.Parse(txtIndentNo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(2, xmlData, intWh, indentId, dteFrom, enroll);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
                dt.Clear();
            }
            catch { }
        }

        protected void btnIndentDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML); File.Delete(filePathForXMLPo); dgvIndentPrepare.DataSource = "";dgvIndentPrepare.DataBind();}  catch { File.Delete(filePathForXML); File.Delete(filePathForXMLPo); dgvIndentPrepare.DataSource = ""; dgvIndentPrepare.DataBind(); }

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                int indent= int.Parse(lblIndent.Text.ToString());
                lblIndentType.Text = ddlDepts.SelectedItem.ToString();
                dt = objPo.GetPoData(3, "", intWh, indent, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblIndentDetUnit.Text = dt.Rows[0]["strDescription"].ToString();
                    hdnUnitId.Value= dt.Rows[0]["intUnitID"].ToString(); 
                    lblIndentDetWH.Text = dt.Rows[0]["strWareHoseName"].ToString(); 
                    lblIndentDate.Text =DateTime.Parse(dt.Rows[0]["dteIndentDate"].ToString()).ToString("dd-MM-yyyy");
                    lblindentApproveDate.Text = DateTime.Parse(dt.Rows[0]["dteApproveDate"].ToString()).ToString("dd-MM-yyyy");
                    lblInDueDate.Text =DateTime.Parse(dt.Rows[0]["dteDueDate"].ToString()).ToString("dd-MM-yyyy");
                }
                string unitId = hdnUnitId.Value.ToString();
                Session["unitId"] = unitId;

                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 1;
                string dept = ddlDepts.SelectedItem.ToString();
                
                dt = objPo.GetPoData(4, "", intWh, indent, DateTime.Now, enroll);// Indent Detalis 
                 
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    string indentId = dt.Rows[i]["indentId"].ToString();
                    string itemId = dt.Rows[i]["ItemId"].ToString();
                    string strItem = dt.Rows[i]["strItem"].ToString();
                    string strUom = dt.Rows[i]["strUom"].ToString();
                    string strHsCode = dt.Rows[i]["strHsCode"].ToString();
                    string strDesc = dt.Rows[i]["strDesc"].ToString();
                    string numCurStock = dt.Rows[i]["numCurStock"].ToString();
                    string numSafetyStock = dt.Rows[i]["numSafetyStock"].ToString();
                    string numIndentQty = dt.Rows[i]["numIndentQty"].ToString();
                    string numPoIssued = dt.Rows[i]["numPoIssued"].ToString();
                    string numRemain = dt.Rows[i]["numRemain"].ToString();
                    string numNewPo = dt.Rows[i]["numNewPo"].ToString();
                    string strSpecification = dt.Rows[i]["strSpecification"].ToString();
                    string monPreviousRate = dt.Rows[i]["monPreviousRate"].ToString();
                    CreateXml(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);

                }
                txtIndentNoDet.Text = "";
                ddlItem.DataSource = "";
                ddlItem.DataBind();
                LoadGridwithXml();
            }
            catch { }

        }

        private void CreateXml(string indentId, string itemId, string strItem, string strUom, string strHsCode, string strDesc, string numCurStock, string numSafetyStock, string numIndentQty, string numPoIssued, string numRemain, string numNewPo, string strSpecification, string monPreviousRate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNode(doc, indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNode(doc, indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
           
        }

        private XmlNode CreateItemNode(XmlDocument doc, string indentId, string itemId, string strItem, string strUom, string strHsCode, string strDesc, string numCurStock, string numSafetyStock, string numIndentQty, string numPoIssued, string numRemain, string numNewPo, string strSpecification, string monPreviousRate)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute IndentId = doc.CreateAttribute("indentId");
            IndentId.Value = indentId;
            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute StrItem = doc.CreateAttribute("strItem");
            StrItem.Value = strItem;
            XmlAttribute StrUom = doc.CreateAttribute("strUom");
            StrUom.Value = strUom;
            XmlAttribute StrHsCode = doc.CreateAttribute("strHsCode");
            StrHsCode.Value = strHsCode;
            XmlAttribute StrDesc = doc.CreateAttribute("strDesc");
            StrDesc.Value = strDesc;
            XmlAttribute NumCurStock = doc.CreateAttribute("numCurStock");
            NumCurStock.Value = numCurStock;

            XmlAttribute NumSafetyStock = doc.CreateAttribute("numSafetyStock");
            NumSafetyStock.Value = numSafetyStock;
            XmlAttribute NumIndentQty = doc.CreateAttribute("numIndentQty");
            NumIndentQty.Value = numIndentQty;
            XmlAttribute NumPoIssued = doc.CreateAttribute("numPoIssued");
            NumPoIssued.Value = numPoIssued;

            XmlAttribute NumRemain = doc.CreateAttribute("numRemain");
            NumRemain.Value = numRemain;
            XmlAttribute NumNewPo = doc.CreateAttribute("numNewPo");
            NumNewPo.Value = numNewPo;
            XmlAttribute StrSpecification = doc.CreateAttribute("strSpecification");
            StrSpecification.Value = strSpecification;

            XmlAttribute MonPreviousRate = doc.CreateAttribute("monPreviousRate");
            MonPreviousRate.Value = monPreviousRate;

            node.Attributes.Append(IndentId);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(StrItem);
            node.Attributes.Append(StrUom);

            node.Attributes.Append(StrHsCode);
            node.Attributes.Append(StrDesc);
            node.Attributes.Append(NumCurStock);
            node.Attributes.Append(NumSafetyStock);
            node.Attributes.Append(NumIndentQty);
            node.Attributes.Append(NumPoIssued);

            node.Attributes.Append(NumRemain);
            node.Attributes.Append(NumNewPo);
            node.Attributes.Append(StrSpecification);
            node.Attributes.Append(NumSafetyStock);
            node.Attributes.Append(MonPreviousRate);

            return node;
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("issue");
                xmlString = dSftTm.InnerXml;
                xmlString = "<issue>" + xmlString + "</issue>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvIndentDet.DataSource = ds; }

                else { dgvIndentDet.DataSource = ""; }
                dgvIndentDet.DataBind();
            }
            catch { }
        }
        protected void dgvIndentDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvIndentDet.DataSource;
                dsGrid.Tables[0].Rows[dgvIndentDet.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvIndentDet.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvIndentDet.DataSource = ""; dgvIndentDet.DataBind(); }
                else { LoadGridwithXml(); }


            }

            catch { }
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlWHPrepare.DataSource = "";
            ddlWHPrepare.DataBind();
            dgvIndent.DataSource = "";
            dgvIndent.DataBind();
            dgvIndentDet.DataSource = "";
            dgvIndentDet.DataBind();
            dgvIndentPrepare.DataSource = dt;
            dgvIndentPrepare.DataBind();
              
            hdnUnitId.Value = "0";
            hdnWHId.Value = "0";
            hdnWHName.Value = "0";
            hdnUnitName.Value = "0";

        }

        #endregion===========Close===================================== 

        #region==============Indent Detalis TAB-2 =============================
        protected void Tab2_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                Tab5.CssClass = "Initial";

                MainView.ActiveViewIndex = 1;
            }
            catch { }
            
        }
        protected void btnIndentDetShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnIndentDetShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnIndentDetShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int IndentNo = int.Parse(txtIndentNoDet.Text);
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + "2018-01-01" + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(11, xmlData, intWh, IndentNo, DateTime.Now, enroll);
                ddlItem.DataSource = dt;
                ddlItem.DataTextField = "strName";
                ddlItem.DataValueField = "Id";
                ddlItem.DataBind();
                dt.Clear();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnIndentDetShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnIndentDetShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                string itemid = ddlItem.SelectedValue.ToString();
                intWh = int.Parse(hdnWHId.Value.ToString());
                try {   indentNo = int.Parse(txtIndentNoDet.Text.ToString()); } catch { }
                string stringXml = "<voucher><voucherentry itemid=" + '"' + itemid + '"' + "/></voucher>".ToString();
                int CheckDuplicate=checkXmlItemData(itemid);

                if(CheckDuplicate == 1)
                {
                    try { File.Delete(filePathForXML); } catch { };
                    dt = objPo.GetPoData(4, stringXml, intWh, indentNo, DateTime.Now, enroll);// Indent Detalis 

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string indentId = dt.Rows[i]["indentId"].ToString();
                        string itemId = dt.Rows[i]["ItemId"].ToString();
                        string strItem = dt.Rows[i]["strItem"].ToString();
                        string strUom = dt.Rows[i]["strUom"].ToString();
                        string strHsCode = dt.Rows[i]["strHsCode"].ToString();
                        string strDesc = dt.Rows[i]["strDesc"].ToString();
                        string numCurStock = dt.Rows[i]["numCurStock"].ToString();
                        string numSafetyStock = dt.Rows[i]["numSafetyStock"].ToString();
                        string numIndentQty = dt.Rows[i]["numIndentQty"].ToString();
                        string numPoIssued = dt.Rows[i]["numPoIssued"].ToString();
                        string numRemain = dt.Rows[i]["numRemain"].ToString();
                        string numNewPo = dt.Rows[i]["numNewPo"].ToString();
                        string strSpecification = dt.Rows[i]["strSpecification"].ToString();
                        string monPreviousRate = dt.Rows[i]["monPreviousRate"].ToString();
                        CreateXml(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);

                    }

                    //============================
                    if (dgvIndentDet.Rows.Count > 0)
                    {
                        enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                        for (int index = 0; index < dgvIndentDet.Rows.Count; index++)
                        {

                            string indentId = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentId")).Text.ToString();
                            string itemId = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemId")).Text.ToString();
                            string strItem = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemName")).Text.ToString();
                            string strUom = ((Label)dgvIndentDet.Rows[index].FindControl("lblUom")).Text.ToString();
                            string strHsCode = ((Label)dgvIndentDet.Rows[index].FindControl("lblHsCode")).Text.ToString();
                            string strDesc = ((Label)dgvIndentDet.Rows[index].FindControl("lblPurpose")).Text.ToString();// lblPurpose
                            string numCurStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblCurrentStock")).Text.ToString();
                            string numSafetyStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblSaftyStock")).Text.ToString();
                            string numIndentQty = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentQty")).Text.ToString();
                            string numPoIssued = ((Label)dgvIndentDet.Rows[index].FindControl("lblPoIssue")).Text.ToString();
                            string numRemain = ((Label)dgvIndentDet.Rows[index].FindControl("lblRemaining")).Text.ToString();
                            string numNewPo = ((TextBox)dgvIndentDet.Rows[index].FindControl("TxtNewPO")).Text.ToString();
                            string strSpecification = ((TextBox)dgvIndentDet.Rows[index].FindControl("txtSpecification")).Text.ToString(); //lblSpecification as TextBox -- 
                            string monPreviousRate = ((Label)dgvIndentDet.Rows[index].FindControl("lblPreviousAvg")).Text.ToString();

                            
                            CreateXml(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                            
                        }
                    }
                    LoadGridwithXml();
                    //========================================
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
            }
            catch { }

        }
        private int checkXmlItemData(string itemid)
        {
               DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (itemid == (ds.Tables[0].Rows[i].ItemArray[1].ToString()))
                    {
                    CheckItem = 0;
                       
                        break;
                    }
                    else
                    {
                    CheckItem = 1;
                    }
                     
                }
            return CheckItem;

        }
        protected void btnPrepare_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepare_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnPrepare_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                try { File.Delete(filePathForXMLPrepare); } catch { }
                
                if (dgvIndentDet.Rows.Count > 0  )
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString()); 
                    for (int index = 0; index < dgvIndentDet.Rows.Count; index++)
                    {
                        
                            string indentId = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentId")).Text.ToString();
                            string itemId = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemId")).Text.ToString();
                            string strItem = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemName")).Text.ToString();
                            string strUom = ((Label)dgvIndentDet.Rows[index].FindControl("lblUom")).Text.ToString();
                            string strHsCode = ((Label)dgvIndentDet.Rows[index].FindControl("lblHsCode")).Text.ToString();
                            string strDesc = ((Label)dgvIndentDet.Rows[index].FindControl("lblPurpose")).Text.ToString();// lblPurpose
                            string numCurStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblCurrentStock")).Text.ToString();
                            string numSafetyStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblSaftyStock")).Text.ToString();
                            string numIndentQty = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentQty")).Text.ToString();
                            string numPoIssued = ((Label)dgvIndentDet.Rows[index].FindControl("lblPoIssue")).Text.ToString();
                            string numRemain = ((Label)dgvIndentDet.Rows[index].FindControl("lblRemaining")).Text.ToString();
                            string numNewPo = ((TextBox)dgvIndentDet.Rows[index].FindControl("TxtNewPO")).Text.ToString();
                            string strSpecification = ((TextBox)dgvIndentDet.Rows[index].FindControl("txtSpecification")).Text.ToString(); //lblSpecification as TextBox -- 
                            string monPreviousRate = ((Label)dgvIndentDet.Rows[index].FindControl("lblPreviousAvg")).Text.ToString();

                         if(decimal.Parse(numNewPo)>0)
                           {
                            CreateXmlPrepare(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                           } 
                    }
                    List<ListItem> items = new List<ListItem>();
                    items.Add(new ListItem(hdnWHName.Value.ToString(), hdnWHId.Value.ToString()));
                    ddlWHPrepare.Items.AddRange(items.ToArray());
                    intWh = int.Parse(ddlWHPrepare.SelectedValue);
                    dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, enroll);//get Currency Name
                    try { txtDestinationDelivery.Text = dt.Rows[0]["whaddress"].ToString(); } catch { }
                        
                    ddlCurrency.DataSource = dt;
                    ddlCurrency.DataTextField = "strName";
                    ddlCurrency.DataValueField = "Id";
                    ddlCurrency.DataBind();

                    

                    dt = objPo.GetPoData(7, "", intWh, int.Parse(hdnUnitId.Value), DateTime.Now, enroll);// Pay Date
                    ddlDtePay.DataSource = dt;
                    ddlDtePay.DataTextField = "strName";
                    ddlDtePay.DataValueField = "dteDate";
                    ddlDtePay.DataBind();

                    dt = objPo.GetPoData(8, "", intWh, int.Parse(hdnUnitId.Value), DateTime.Now, enroll);// Get Costcenter
                    ddlCostCenter.DataSource = dt;
                    ddlCostCenter.DataTextField = "strName";
                    ddlCostCenter.DataValueField = "Id";
                    ddlCostCenter.DataBind(); 

                    Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Initial"; 
                    Tab3.CssClass = "Clicked"; 
                    MainView.ActiveViewIndex = 2;

                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLPrepare);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }
            }


            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPrepare_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepare_Click", null);
            Flogger.WriteDiagnostic(fd);
             
            tracker.Stop();
        }

        private void CreateXmlPrepare(string indentId, string itemId, string strItem, string strUom, string strHsCode, string strDesc, string numCurStock, string numSafetyStock, string numIndentQty, string numPoIssued, string numRemain, string numNewPo, string strSpecification, string monPreviousRate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLPrepare))
            {
                doc.Load(filePathForXMLPrepare);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNodePrepare(doc, indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNodePrepare(doc, indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLPrepare);
            LoadGridwithXmlPrepare();
        }

        private XmlNode CreateItemNodePrepare(XmlDocument doc, string indentId, string itemId, string strItem, string strUom, string strHsCode, string strDesc, string numCurStock, string numSafetyStock, string numIndentQty, string numPoIssued, string numRemain, string numNewPo, string strSpecification, string monPreviousRate)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute IndentId = doc.CreateAttribute("indentId");
            IndentId.Value = indentId;
            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute StrItem = doc.CreateAttribute("strItem");
            StrItem.Value = strItem;
            XmlAttribute StrUom = doc.CreateAttribute("strUom");
            StrUom.Value = strUom;
            XmlAttribute StrHsCode = doc.CreateAttribute("strHsCode");
            StrHsCode.Value = strHsCode;
            XmlAttribute StrDesc = doc.CreateAttribute("strDesc");
            StrDesc.Value = strDesc;
            XmlAttribute NumCurStock = doc.CreateAttribute("numCurStock");
            NumCurStock.Value = numCurStock;

            XmlAttribute NumSafetyStock = doc.CreateAttribute("numSafetyStock");
            NumSafetyStock.Value = numSafetyStock;
            XmlAttribute NumIndentQty = doc.CreateAttribute("numIndentQty");
            NumIndentQty.Value = numIndentQty;
            XmlAttribute NumPoIssued = doc.CreateAttribute("numPoIssued");
            NumPoIssued.Value = numPoIssued;

            XmlAttribute NumRemain = doc.CreateAttribute("numRemain");
            NumRemain.Value = numRemain;
            XmlAttribute NumNewPo = doc.CreateAttribute("numNewPo");
            NumNewPo.Value = numNewPo;
            XmlAttribute StrSpecification = doc.CreateAttribute("strSpecification");
            StrSpecification.Value = strSpecification;

            XmlAttribute MonPreviousRate = doc.CreateAttribute("monPreviousRate");
            MonPreviousRate.Value = monPreviousRate;

            node.Attributes.Append(IndentId);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(StrItem);
            node.Attributes.Append(StrUom);

            node.Attributes.Append(StrHsCode);
            node.Attributes.Append(StrDesc);
            node.Attributes.Append(NumCurStock);
            node.Attributes.Append(NumSafetyStock);
            node.Attributes.Append(NumIndentQty);
            node.Attributes.Append(NumPoIssued);

            node.Attributes.Append(NumRemain);
            node.Attributes.Append(NumNewPo);
            node.Attributes.Append(StrSpecification);
            node.Attributes.Append(NumSafetyStock);
            node.Attributes.Append(MonPreviousRate);

            return node;
        }

        private void LoadGridwithXmlPrepare()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLPrepare);
                XmlNode dSftTm = doc.SelectSingleNode("issue");
                xmlString = dSftTm.InnerXml;
                xmlString = "<issue>" + xmlString + "</issue>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvIndentPrepare.DataSource = ds; }

                else { dgvIndentPrepare.DataSource = ""; }
                dgvIndentPrepare.DataBind();
            }
            catch { }
        }

        protected void dgvIndentPrepare_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlPrepare();
                DataSet dsGrid = (DataSet)dgvIndentPrepare.DataSource;
                dsGrid.Tables[0].Rows[dgvIndentPrepare.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLPrepare);
                DataSet dsGridAfterDelete = (DataSet)dgvIndentPrepare.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLPrepare); dgvIndentPrepare.DataSource = ""; dgvIndentPrepare.DataBind(); }
                else { LoadGridwithXmlPrepare(); } 
            }

            catch { }
        }

        protected void btnSetAIT_Click(object sender, EventArgs e)
        {
            if (dgvIndentPrepare.Rows.Count > 0)
            {
                decimal grandTotalAit=0, grandTotalVat=0, grandTotalQty=0, grandTotalValue=0, TotalValue=0;
                enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                for (int index = 0; index < dgvIndentPrepare.Rows.Count; index++)
                { 

                }

 
            }
        }

       

        #endregion============Close======================================

        #region==============PO Generate TAB-3 =============================
        protected void Tab3_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                Tab4.CssClass = "Initial";
                Tab5.CssClass = "Initial";

                MainView.ActiveViewIndex = 2;
            }
            catch { }
        }

         
        protected void btnGeneratePO_Click(object sender, EventArgs e)
        {
            try
            {
                

                try { File.Delete(filePathForXMLPo); } catch { }
                try
                {
                    arrayKey = txtSupplier.Text.Split(delimiterChars);
                    string strSupp = ""; supplierId = 0;
                    if (arrayKey.Length > 0)
                    { strSupp = arrayKey[0].ToString(); supplierId = int.Parse(arrayKey[1].ToString()); }
                }
                catch { supplierId = 0; }

                try { whid = int.Parse(ddlWHPrepare.SelectedValue); } catch { }
                try { unitid = int.Parse(hdnUnitId.Value); } catch { }
               
                try { currencyId = int.Parse(ddlCurrency.SelectedValue); } catch { currencyId = 0; }
                try { costId = int.Parse(ddlCostCenter.SelectedValue); } catch { }
                try { payDate = ddlDtePay.SelectedValue.ToString(); } catch { payDate ="0"; }
                try { dtePo = DateTime.Parse(txtdtePo.Text); } catch { dtePo = DateTime.Now; }
                try { others = decimal.Parse(txtOthers.Text); } catch { }
                try { tansport = decimal.Parse(txtTransport.Text); } catch { }
                try { grosDiscount = decimal.Parse(txtGrossDiscount.Text); } catch { }
                try { commision = decimal.Parse(txtCommosion.Text); } catch { commision = 0; }

                try { partialShipment = int.Parse(ddlPartialShip.SelectedValue); } catch { partialShipment = 0; }
                try { noOfShifment = int.Parse(txtNoOfShipment.Text); } catch { noOfShifment = 0; }
                try { afterMrrDay = int.Parse(txtAfterMrrDay.Text); } catch { afterMrrDay = 0; }
                try { paymentTrems = ddlPaymentTrams.SelectedItem.ToString(); } catch { }
                try { noOfInstallment = int.Parse(txtNoOfInstall.Text.ToString()); } catch { noOfInstallment = 0; }
                try { intervalInstallment = int.Parse(txtIntervel.Text.ToString()); } catch { intervalInstallment = 0; }
                try { noPayment = int.Parse(txtNoOfPayment.Text); } catch { noPayment = 0; }
                try { destDelivery = txtDestinationDelivery.Text.ToString(); } catch { destDelivery = ""; }
                try { paymentSchedule = txtPaymentSchedule.Text.ToString(); } catch { paymentSchedule = "0"; }
                try { dtelastShipment = DateTime.Parse(txtLastShipmentDate.Text); } catch { }
                  othersTrems = txtOthersTerms.Text.ToString();
                  warrentyperiod = txtWarrenty.Text.ToString();
                string strPoFor = ddlDepts.SelectedItem.ToString();

                if (dgvIndentPrepare.Rows.Count > 0 && hdnPreConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    for (int index = 0; index < dgvIndentPrepare.Rows.Count; index++)
                    {
                        string indentId = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblIndentId")).Text.ToString();
                        string itemId = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string strItem = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemName")).Text.ToString();
                        string strUom = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblUom")).Text.ToString(); 
                        string strDesc = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblDescription")).Text.ToString(); 
                        string numIndentQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblIndentQty")).Text.ToString(); 
                        string numPoQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblQty")).Text.ToString();
                        string monRate = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtRate")).Text.ToString();
                        string monVat = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtVAT")).Text.ToString();
                        string monAIT = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtAIT")).Text.ToString();
                        string monTotal = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblTotalVal")).Text.ToString();

                        //*********For Devlopment Requirment Change********************

                        // string strHsCode = ((Label)dgvIndentDet.Rows[index].FindControl("lblHsCode")).Text.ToString();
                        // string numCurStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblCurrentStock")).Text.ToString();
                        // string numSafetyStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblSaftyStock")).Text.ToString();
                        // string numPoIssued = ((Label)dgvIndentDet.Rows[index].FindControl("lblPoIssue")).Text.ToString();
                        // string numRemain = ((Label)dgvIndentDet.Rows[index].FindControl("lblRemaining")).Text.ToString();
                        //  string strSpecification = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblSpecification")).Text.ToString();
                        //  string monPreviousRate = ((Label)dgvIndentDet.Rows[index].FindControl("lblPreviousAvg")).Text.ToString();

                        if (decimal.Parse(monRate) > 0)
                        {

                            CreateXmlPO(indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal,
                            whid.ToString(), unitid.ToString(), supplierId.ToString(), currencyId.ToString(), costId.ToString(), payDate.ToString(), dtePo.ToString(), others.ToString(), tansport.ToString(), grosDiscount.ToString(), commision.ToString(), partialShipment.ToString(), noOfShifment.ToString(),
                            afterMrrDay.ToString(), paymentTrems.ToString(), noOfInstallment.ToString(), intervalInstallment.ToString(), noPayment.ToString(), destDelivery.ToString(), paymentSchedule.ToString(), dtelastShipment.ToString(), othersTrems, warrentyperiod, numIndentQty, strPoFor);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input valid rate');", true);
                            try { File.Delete(filePathForXMLPo); } catch { }
                            break;
                        }
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLPo);
                    XmlNode dSftTm = doc.SelectSingleNode("issue");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<issue>" + xmlString + "</issue>";

                    string msg = objPo.PoApprove(9, xmlString, intWh, 0, DateTime.Now, enroll);
                    string[] searchKey = Regex.Split(msg, ":");
                    lblPoNo.Text = "Po Number: " + searchKey[1].ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    txtGrossDiscount.Text = "0";txtOthers.Text = "0"; txtTransport.Text = "0";txtAit.Text = "0";
                    try { File.Delete(filePathForXMLPrepare); } catch { }
                    if (searchKey[1].ToString().Length > 2)
                    {
                        dgvIndentPrepare.DataSource = ""; dgvIndentPrepare.DataBind();
                        dgvIndentDet.DataSource = "";
                        dgvIndentDet.DataBind();
                        Tab1.CssClass = "Initial";
                        Tab2.CssClass = "Clicked";
                        Tab3.CssClass = "Initial";
                        MainView.ActiveViewIndex = 0;
                    }


                }
                

            }
            catch { }

        }
        private void CreateXmlPO(string indentId, string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment,string othersTrems,string  warrentyperiod,string numIndentQty,string strPoFor)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLPo))
            {
                doc.Load(filePathForXMLPo);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNodePo(doc, indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, numIndentQty, strPoFor);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNodePo(doc, indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, numIndentQty, strPoFor);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLPo);

        }

        private XmlNode CreateItemNodePo(XmlDocument doc, string indentId, string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment,string othersTrems,string warrentyperiod,string numIndentQty,string strPoFor)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute IndentId = doc.CreateAttribute("indentId");
            IndentId.Value = indentId;
            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute StrItem = doc.CreateAttribute("strItem");
            StrItem.Value = strItem;
            XmlAttribute StrUom = doc.CreateAttribute("strUom");
            StrUom.Value = strUom;

            XmlAttribute StrDesc = doc.CreateAttribute("strDesc");
            StrDesc.Value = strDesc;
            XmlAttribute NumPoQty = doc.CreateAttribute("numPoQty");
            NumPoQty.Value = numPoQty;
            XmlAttribute MonRate = doc.CreateAttribute("monRate");
            MonRate.Value = monRate;
            XmlAttribute MonVat = doc.CreateAttribute("monVat");
            MonVat.Value = monVat;
            XmlAttribute MonAIT = doc.CreateAttribute("monAIT");
            MonAIT.Value = monAIT;
            XmlAttribute MonTotal = doc.CreateAttribute("monTotal");
            MonTotal.Value = monTotal;
            XmlAttribute Whid = doc.CreateAttribute("whid");
            Whid.Value = whid;
            XmlAttribute Unitid = doc.CreateAttribute("unitid");
            Unitid.Value = unitid;
            XmlAttribute SupplierId = doc.CreateAttribute("supplierId");
            SupplierId.Value = supplierId;
            XmlAttribute CurrencyId = doc.CreateAttribute("currencyId");
            CurrencyId.Value = currencyId;
            XmlAttribute CostId = doc.CreateAttribute("costId");
            CostId.Value = costId;
            XmlAttribute PayDate = doc.CreateAttribute("payDate");
            PayDate.Value = payDate;

            XmlAttribute DtePo = doc.CreateAttribute("dtePo");
            DtePo.Value = dtePo;
            XmlAttribute Others = doc.CreateAttribute("others");
            Others.Value = others;
            XmlAttribute Tansport = doc.CreateAttribute("tansport");
            Tansport.Value = tansport;
            XmlAttribute GrosDiscount = doc.CreateAttribute("grosDiscount");
            GrosDiscount.Value = grosDiscount;
            XmlAttribute Commision = doc.CreateAttribute("commision");
            Commision.Value = commision;
            XmlAttribute PartialShipment = doc.CreateAttribute("partialShipment");
            PartialShipment.Value = partialShipment;
            XmlAttribute NoOfShifment = doc.CreateAttribute("noOfShifment");
            NoOfShifment.Value = noOfShifment;
            XmlAttribute AfterMrrDay = doc.CreateAttribute("afterMrrDay");
            AfterMrrDay.Value = afterMrrDay;
            XmlAttribute PaymentTrems = doc.CreateAttribute("paymentTrems");
            PaymentTrems.Value = paymentTrems;
            XmlAttribute NoOfInstallment = doc.CreateAttribute("noOfInstallment");
            NoOfInstallment.Value = noOfInstallment;
            XmlAttribute IntervalInstallment = doc.CreateAttribute("intervalInstallment");
            IntervalInstallment.Value = intervalInstallment;
            XmlAttribute NoPayment = doc.CreateAttribute("noPayment");
            NoPayment.Value = noPayment;
            XmlAttribute DestDelivery = doc.CreateAttribute("destDelivery");
            DestDelivery.Value = destDelivery;
            XmlAttribute PaymentSchedule = doc.CreateAttribute("paymentSchedule");
            PaymentSchedule.Value = paymentSchedule;
            XmlAttribute DtelastShipment = doc.CreateAttribute("dtelastShipment");
            DtelastShipment.Value = dtelastShipment;

            XmlAttribute OthersTrems = doc.CreateAttribute("othersTrems");
            OthersTrems.Value = othersTrems;
            XmlAttribute Warrentyperiod = doc.CreateAttribute("warrentyperiod");
            Warrentyperiod.Value = warrentyperiod;

            XmlAttribute NumIndentQty = doc.CreateAttribute("numIndentQty");
            NumIndentQty.Value = numIndentQty;

            XmlAttribute StrPoFor = doc.CreateAttribute("strPoFor");
            StrPoFor.Value = strPoFor;

            

            node.Attributes.Append(IndentId);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(StrItem);
            node.Attributes.Append(StrUom);

            node.Attributes.Append(StrDesc);
            node.Attributes.Append(NumPoQty);
            node.Attributes.Append(MonRate);
            node.Attributes.Append(MonVat);
            node.Attributes.Append(MonAIT);
            node.Attributes.Append(MonTotal);

            node.Attributes.Append(Whid);
            node.Attributes.Append(Unitid);
            node.Attributes.Append(SupplierId);
            node.Attributes.Append(CurrencyId);
            node.Attributes.Append(CostId); 

            node.Attributes.Append(PayDate);
            node.Attributes.Append(DtePo);
            node.Attributes.Append(Others);
            node.Attributes.Append(Tansport);
            node.Attributes.Append(GrosDiscount);

            node.Attributes.Append(Commision);
            node.Attributes.Append(PartialShipment);
            node.Attributes.Append(NoOfShifment);
            node.Attributes.Append(AfterMrrDay);
            node.Attributes.Append(PaymentTrems);

            node.Attributes.Append(NoOfInstallment);
            node.Attributes.Append(IntervalInstallment);
            node.Attributes.Append(NoPayment);
            node.Attributes.Append(DestDelivery);
            node.Attributes.Append(PaymentSchedule);

            node.Attributes.Append(DtelastShipment);

            node.Attributes.Append(OthersTrems);
            node.Attributes.Append(Warrentyperiod);
            node.Attributes.Append(NumIndentQty);
            node.Attributes.Append(StrPoFor); 
            return node;
        }

        #endregion============Close======================================

        #region================POView=====================================
        protected void Tab4_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Clicked";  
                Tab5.CssClass = "Initial";  

                MainView.ActiveViewIndex = 3;
                

            }
            catch { }
           
        }

        #endregion================Close===================================

        protected void Tab5_OnClick(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            Tab5.CssClass = "Clicked";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PoReport.aspx');", true);
        }
    }
}