using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IndentRFQ : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll,intWh;
        string filePathForXML, filePathForXMLPrepare, filePathForXMLPo, othersTrems, warrentyperiod; string xmlString = "";
        int indentNo,whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem; string payDate, paymentTrems, destDelivery, paymentSchedule; DateTime dtePo, dtelastShipment; decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;
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
                DefaltPageLoad();
            }
            else
            {

            }
        }

       

       

        private void DefaltPageLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                txtDtefroms.Text = DateTime.Now.ToString("yyyy-MM-dd");
              
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
            catch { }
             
        } 

        #region=============Indent Sumery Tab-1 ==============================
        protected void Tab1_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
               
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
                try { File.Delete(filePathForXML); File.Delete(filePathForXMLPo); }  catch { File.Delete(filePathForXML); File.Delete(filePathForXMLPo);  }

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
              
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                
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
           
           
            dgvIndent.DataSource = "";
            dgvIndent.DataBind();
            dgvIndentDet.DataSource = "";
            dgvIndentDet.DataBind();
           
              
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
               

                MainView.ActiveViewIndex = 1;
            }
            catch { }
            
        }
        protected void btnIndentDetShow_Click(object sender, EventArgs e)
        {
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
            catch { }
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
                            string strSpecification = "0".ToString(); //lblSpecification as TextBox -- 
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
                  
                   
                   
                  


                   

                    Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Initial"; 
                   
                    MainView.ActiveViewIndex = 2;

                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLPrepare);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }
            }


            catch { }
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
                {  }

                else { }
               
            }
            catch { }
        }

       

        
       

        #endregion============Close======================================

        

        

    }
}