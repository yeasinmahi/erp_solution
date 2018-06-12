using Purchase_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.WoodPurchase
{
    public partial class WoodReceiveAMFL : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        int intPart, intEnroll, intWH, intPOID, intSupplierID, intWoodTypeID, intZoneID, intJobStationID, intUnitID, intCirCum, intGateEntry;
        decimal numPOQty, monRate, numTotalWeight, numDeduction;
        string strChallan, xml, xmlString, strVehicleNo, filePathForXML, message, tagno, length, circum, cft, rate, itemid;
        DateTime dteReceiveDate, dteChallanDate;

        string xmlpath, strDocUploadPath, ext, path, ConStr;
        int ShipId, Offid, enroll;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                xmlpath = Server.MapPath("~/WoodPurchase/Data/Excelupload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //
                    filePathForXML = Server.MapPath("~/WoodPurchase/Data/Log_" + hdnEnroll.Value + ".xml");

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitJobStation(intWH);
                    hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                    LoadDropDown();
                    try
                    {
                        File.Delete(xmlpath);
                        File.Delete(filePathForXML);
                    }
                    catch { }
                }
            }
            catch { }
        }
        
        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                LoadDropDown();
            }
            catch { }
        }
        protected void ddlPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
            }
            catch { }
        }
        private void LoadDropDown()
        {
            try
            {
                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());

                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetPOList(intWH);
                ddlPOList.DataSource = dt;
                ddlPOList.DataValueField = "intPOID";
                ddlPOList.DataTextField = "strSupplierName";
                ddlPOList.DataBind();

                dt = new DataTable();
                dt = bll.GetWoodType(intUnitID);
                ddlWoodType.DataSource = dt;
                ddlWoodType.DataTextField = "strWoodType";
                ddlWoodType.DataValueField = "intWoodTypeID";
                ddlWoodType.DataBind();

                dt = new DataTable();
                dt = bll.GetZone(intUnitID, intJobStationID);
                ddlMokam.DataSource = dt;
                ddlMokam.DataTextField = "strZoneName";
                ddlMokam.DataValueField = "intZoneID";
                ddlMokam.DataBind();
            }
            catch { }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                try // Get Rate & Item ID
                {
                    filePathForXML = Server.MapPath("~/WoodPurchase/Data/Log_" + hdnEnroll.Value + ".xml");

                    intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                    intWoodTypeID = int.Parse(ddlWoodType.SelectedValue.ToString());
                    intCirCum = int.Parse(txtCircum.Text);

                    dt = new DataTable();
                    dt = bll.GetRate(intPOID, intWoodTypeID, intCirCum);
                    txtItemID.Text = dt.Rows[0]["intItemID"].ToString();
                    txtRate.Text = dt.Rows[0]["monRate"].ToString();
                    hdnSupplierID.Value = dt.Rows[0]["intSupplierID"].ToString();

                    tagno = txtTag.Text;
                    length = txtLength.Text;
                    circum = txtCircum.Text;
                    cft = txtCFT.Text;
                    rate = txtRate.Text;
                    itemid = txtItemID.Text;
                    if (tagno == "" && length == "" && circum == "" && cft == "" && rate == "" && itemid == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input correct infromation.');", true);
                    }
                    else
                    {
                        CreateXML(tagno, length, circum, cft, rate, itemid);
                    }
                    
                }
                catch { txtItemID.Text = ""; txtRate.Text = ""; }
                
            }
            catch { }
        }

        private void CreateXML(string tagno, string length, string circum, string cft, string rate, string itemid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("LogReceive");
                XmlNode addItem = CreateItemNode(doc, tagno, length, circum, cft, rate, itemid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("LogReceive");
                XmlNode addItem = CreateItemNode(doc, tagno, length, circum, cft, rate, itemid); ;
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
            XmlNode dSftTm = doc.SelectSingleNode("LogReceive");
            xmlString = dSftTm.InnerXml;
            xmlString = "<LogReceive>" + xmlString + "</LogReceive>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvReceive.DataSource = ds; }
            else { dgvReceive.DataSource = ""; }
            dgvReceive.DataBind();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string tagno, string length, string circum, string cft, string rate, string itemid)
        {
            XmlNode node = doc.CreateElement("LogReceive");

            XmlAttribute TagNo = doc.CreateAttribute("tagno");
            TagNo.Value = tagno;
            XmlAttribute Length = doc.CreateAttribute("length");
            Length.Value = length;
            XmlAttribute Circum = doc.CreateAttribute("circum");
            Circum.Value = circum;
            XmlAttribute CFT = doc.CreateAttribute("cft");
            CFT.Value = cft;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute ItemID = doc.CreateAttribute("itemid");
            ItemID.Value = itemid;
            
            node.Attributes.Append(TagNo);
            node.Attributes.Append(Length);
            node.Attributes.Append(Circum);
            node.Attributes.Append(CFT);
            node.Attributes.Append(Rate);
            node.Attributes.Append(ItemID);
            return node;
        }
        
        protected void dgvReceive_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                filePathForXML = Server.MapPath("~/WoodPurchase/Data/Log_" + hdnEnroll.Value + ".xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("LogReceive");
                xmlString = dSftTm.InnerXml;
                xmlString = "<LogReceive>" + xmlString + "</LogReceive>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvReceive.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvReceive.DataSource;
                dsGrid.Tables[0].Rows[dgvReceive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvReceive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReceive.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("LogReceive");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<LogReceive>" + xmlString + "</LogReceive>";
                        xml = xmlString;

                    }
                    catch { }
                    if (xml == "") { return; }
                }

                intPart = 1;
                intSupplierID = int.Parse(hdnSupplierID.Value.ToString());
                intZoneID = int.Parse(ddlMokam.SelectedValue.ToString());
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                dteReceiveDate = DateTime.Parse(txtReceiveDate.Text);
                intWoodTypeID = int.Parse(ddlWoodType.SelectedValue.ToString());
                dteChallanDate = DateTime.Parse(txtChallanDate.Text);
                intGateEntry = int.Parse(txtGateEntry.Text);
                strVehicleNo = txtVehicleNo.Text;
                intEnroll = int.Parse(hdnEnroll.Value.ToString());

                message = bll.InsertPreReceive(intPart, intSupplierID, intZoneID, intPOID, dteReceiveDate, intWoodTypeID, dteChallanDate, intGateEntry, strVehicleNo, intEnroll, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind();
            }
            catch { }
        }

        

    }
}