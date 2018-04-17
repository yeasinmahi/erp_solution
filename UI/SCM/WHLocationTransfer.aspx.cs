using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class WHLocationTransfer : BasePage
    {
        Location_BLL objOperation = new Location_BLL();

        DataTable dt = new DataTable(); 
        string pID, pIDName, accountName; int enroll, intWH;
        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Trn__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvWHLocation.DataSource = ""; dgvWHLocation.DataBind(); }
                catch { }

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objOperation.WhDataView(1, "", intWH, 0, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                intWH = int.Parse(ddlWH.SelectedValue);

                dt = new DataTable();
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                dt = objOperation.WhDataView(5, "", intWH, 0, enroll);
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();              
                pnlUpperControl.DataBind();
            }
        }


        #region===================Action==========================================
        
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                dt = objOperation.WhDataView(5, "", intWH, 0, enroll);
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();

                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }
        
       
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {   
                accountName = ">" + ListBox1.SelectedItem.ToString();
                pID = ListBox1.SelectedValue.ToString();
                pIDName = ListBox1.SelectedItem.ToString();
                hdnOpID.Value = pID;
                hdnOpName.Value = pIDName;

                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                if (LinkButton2.Text.Length == 0) { LinkButton2.Text = accountName.ToString(); hdn1.Value = pID; }
                else if (LinkButton3.Text.Length == 0) { LinkButton3.Text = accountName.ToString(); hdn2.Value = pID; }
                else if (LinkButton4.Text.Length == 0) { LinkButton4.Text = accountName.ToString(); hdn3.Value = pID; }
                else if (LinkButton5.Text.Length == 0) { LinkButton5.Text = accountName.ToString(); hdn4.Value = pID; }
                else if (LinkButton6.Text.Length == 0) { LinkButton6.Text = accountName.ToString(); hdn5.Value = pID; }
                else if (LinkButton7.Text.Length == 0) { LinkButton7.Text = accountName.ToString(); hdn6.Value = pID; }
                else if (LinkButton8.Text.Length == 0) { LinkButton8.Text = accountName.ToString(); hdn7.Value = pID; }
                else if (LinkButton9.Text.Length == 0) { LinkButton9.Text = accountName.ToString(); hdn8.Value = pID; }
                else if (LinkButton10.Text.Length == 0) { LinkButton10.Text = accountName.ToString(); hdn9.Value = pID; }
               
                

            }
            catch { }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(LinkButton3.Text!="")
                {
                    if (dgvWHLocation.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                    {
                        enroll = int.Parse(Session[SessionParams.USER_ID].ToString());


                        for (int index = 0; index < dgvWHLocation.Rows.Count; index++)
                        {
                            if (((CheckBox)dgvWHLocation.Rows[index].FindControl("chkRow")).Checked == true)
                            {

                                string locationId = ((Label)dgvWHLocation.Rows[index].FindControl("lblLocId")).Text.ToString();
                                string locationName = ((Label)dgvWHLocation.Rows[index].FindControl("lblLocName")).Text.ToString();

                                CreateVoucherXml(locationId, locationName);
                            }


                        }
                    }
                    intWH = int.Parse(ddlWH.SelectedValue);
                    int parentId = int.Parse(hdnOpID.Value);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    try { File.Delete(filePathForXML); } catch { }
                    string msg = objOperation.WHLocationCreate(6, xmlString, intWH, parentId, enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    dt = objOperation.WhDataView(5, "", intWH, 0, enroll);
                    dgvWHLocation.DataSource = dt;
                    dgvWHLocation.DataBind();
                }
                else { try { File.Delete(filePathForXML); } catch { } }
               
            }


            catch { try { File.Delete(filePathForXML); } catch { } }
        }

        private void CreateVoucherXml(string locationId, string locationName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateLocation(doc, locationId, locationName );
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateLocation(doc, locationId, locationName);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateLocation(XmlDocument doc, string locationId, string locationName)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;
            XmlAttribute LocationName = doc.CreateAttribute("locationName");
            LocationName.Value = locationName;
             

            node.Attributes.Append(LocationId);
            node.Attributes.Append(LocationName);
             

            return node;
        }

        #endregion==========Close=============================================

        #region==================Link Button Chaild View======================
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                pID = hdn1.Value;
                hdnOpID.Value = pID;
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                 
            }
            catch { }

        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn2.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
               
            }
            catch { }

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn3.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn4.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();


                LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn5.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn6.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }

      

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn7.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                
            }
            catch { }

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn8.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton10.Text = string.Empty;
                 
            }
            catch { }

        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn9.Value;
                hdnOpID.Value = pID;
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                 
            }
            catch { }

        }

        #endregion=================Close================================================
    }
}