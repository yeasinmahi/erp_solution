using MessagingToolkit.QRCode.Codec;
using QRCoder;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class ReceiveEntryAfs :BasePage
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        int enroll, mrrId, intWh,rack=1,godown=2,rackType;string ImagePath = "", rackId="0", receiveQty;
        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/AEFPS/Data/Reca__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind(); }
                catch { }
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
            else
            {

            }

        }

        #region===================Action==========================================

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML);}
                catch { }

                if (dgvReceive.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1 && rackType>0)
                {
                        enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                        rackId = ddlRack.SelectedValue.ToString(); 
                        enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        intWh = int.Parse(ddlWH.SelectedValue.ToString());
                        mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                       
                    for (int index = 0; index < dgvReceive.Rows.Count; index++)
                    {
                        string itemid = ((Label)dgvReceive.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string ItemName = ((Label)dgvReceive.Rows[index].FindControl("lblItemName")).Text.ToString();
                        string itmMasterId = ((Label)dgvReceive.Rows[index].FindControl("lblItemMaster")).Text.ToString();
                        receiveQty = ((TextBox)dgvReceive.Rows[index].FindControl("txtReceQty")).Text.ToString();
                        string salesPrice = ((TextBox)dgvReceive.Rows[index].FindControl("txtSalesPrice")).Text.ToString();
                        string dteDate = ((TextBox)dgvReceive.Rows[index].FindControl("txtExpireDate")).Text.ToString();
                        decimal reminQty = decimal.Parse(((Label)dgvReceive.Rows[index].FindControl("lblRemaingQty")).Text.ToString());
                       if(reminQty>=decimal.Parse(receiveQty) && decimal.Parse(receiveQty)>0 && decimal.Parse(salesPrice)>0)
                        {
                            CreateVoucherXml(itemid, itmMasterId, salesPrice, receiveQty, rackId, rackType, dteDate);
                        }
                        //else
                        //{
                        //    try { File.Delete(filePathForXML); } catch { };
                        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Receive Quantity Grater then Mrr Quantity);", true);
                        //    break;
                           
                        //}
                      

                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Rack Type');", true);

                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }
                if(xmlString.Length>5)
                {
                    string mrtg = objRec.MrrReceiveInsert(4, xmlString, intWh, mrrId, DateTime.Now, enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                }
               
                 
            }
            catch { }

        }

        private void CreateVoucherXml(string itemid, string itmMasterId, string salesPrice, string receiveQty, string rackId, int rackType, string dteDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItem(doc, itemid, itmMasterId, salesPrice, receiveQty, rackId, rackType, dteDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItem(doc, itemid, itmMasterId, salesPrice, receiveQty, rackId, rackType, dteDate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItem(XmlDocument doc, string itemid, string itmMasterId, string salesPrice, string receiveQty, string rackId, int rackType, string dteDate)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute ItmMasterId = doc.CreateAttribute("itmMasterId");
            ItmMasterId.Value = itmMasterId;

            XmlAttribute SalesPrice = doc.CreateAttribute("salesPrice");
            SalesPrice.Value = salesPrice;
            XmlAttribute ReceiveQty = doc.CreateAttribute("receiveQty");
            ReceiveQty.Value = receiveQty;

            XmlAttribute RackId = doc.CreateAttribute("rackId");
            RackId.Value = rackId;
            XmlAttribute RackType = doc.CreateAttribute("rackType");
            RackType.Value = receiveQty;

            XmlAttribute DteDate = doc.CreateAttribute("dteDate");
            DteDate.Value = dteDate; 

            node.Attributes.Append(Itemid);
            node.Attributes.Append(ItmMasterId);
            node.Attributes.Append(SalesPrice);
            node.Attributes.Append(ReceiveQty);
            node.Attributes.Append(RackId);
            node.Attributes.Append(RackType);
            node.Attributes.Append(DteDate);
            


            return node;
        }
        
        #endregion==========Close=============================================


        private void DefaltLoad()
        {
            try
            {
                
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();

            }
            catch { }

        }

        protected void ddlMrrNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }

        protected void raRack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                rackType = 1;
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                ddlRack.DataSource = dt;
                ddlRack.DataTextField = "strName";
                ddlRack.DataValueField = "Id";
                ddlRack.DataBind();
            }
            catch { }
        }

        protected void ragodwon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                rackType = 2;
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                ddlRack.DataSource = dt;
                ddlRack.DataTextField = "strName";
                ddlRack.DataValueField = "Id";
                ddlRack.DataBind();

            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                try { mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString()); } catch { mrrId = 0; }
               dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvReceive.DataSource = dt;
                    dgvReceive.DataBind();
                }
                else
                {
                    dgvReceive.DataSource = "";
                    dgvReceive.DataBind();
                }
                    
            }
            catch { }
        }
        
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rackId = ddlRack.SelectedValue.ToString();
                if (raRack.Checked==true || ragodwon.Checked==true && rackId !="" && int.Parse(hdnConfirm.Value)>0)
                {
                    
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                 
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                TextBox txtSalesQty = row.FindControl("txtReceQty") as TextBox;
                TextBox txtSalesPrice = row.FindControl("txtSalesPrice") as TextBox;
                TextBox txtPrintQty = row.FindControl("txtPrtQty") as TextBox;
                TextBox txtDteDate = row.FindControl("txtExpireDate") as TextBox;
                Label lblItemMaster = row.FindControl("lblItemMaster") as Label; 
                Label lblRemainQty = row.FindControl("lblRemaingQty") as Label;
                Label lblItem = row.FindControl("lblItemId") as Label;
                Label lblItemName = row.FindControl("lblItemName") as Label;
                string itemid = lblItem.Text.ToString();
                string ItemName = lblItemName.Text.ToString();
                string itmMaster = lblItemMaster.Text.ToString();
                string ReceiveQty = txtSalesQty.Text.ToString();
                string salseprice = txtSalesPrice.Text.ToString();
                string dteDate = txtDteDate.Text.ToString();               
                decimal reminQty = decimal.Parse(lblRemainQty.Text.ToString());
                string xmlunit = "<voucher><voucherentry itemId=" + '"' + itemid + '"' + " ItmMaster=" + '"' + itmMaster + '"' + " SalesPrice=" + '"' + salseprice + '"' + " ReceiveQty=" + '"' + ReceiveQty + '"' + " rackId=" + '"' + rackId + '"'+ " RackType=" + '"' + rackType.ToString() + '"' + " dteDate=" + '"' + dteDate + '"' + "/></voucher>".ToString();

                  

                    //    //#region===============Print Start=============
                    //    PrintDocument p = new PrintDocument();

                    //    //for (int i = 0; i < ReceiveQty; i++)
                    //    //{
                    //    // string mrtg = objRec.MrrReceiveInsert(4, xmlunit, intWh, mrrId, DateTime.Now, enroll);
                    //    string code = "Rack No.: 101, Item Name: Aafi Chili Powder (Spice) 200gm, Qty : 14 Pcs"; //mrtg+","+ ReceiveQty;

                    //    System.Windows.Forms.PictureBox imageControl = new System.Windows.Forms.PictureBox();
                    //    QRCodeEncoder encoder = new QRCodeEncoder();
                    //    Bitmap qrcode = encoder.Encode(code);
                    //    imageControl.Image = null;
                    //    imageControl.Image = qrcode as System.Drawing.Image;
                    //    //imageControl.Image.Save(ImagePath); 
                    //    p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                    //                {
                    //                    Bitmap bmpQr = new Bitmap(imageControl.Image);
                    //                    System.Drawing.Image QrImage = bmpQr;
                    //                    e1.Graphics.DrawImage(QrImage, 60, 2, 65, 70);
                    //                   // e1.Graphics.DrawString(ItemName, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(74, 15));
                    //                   // e1.Graphics.DrawString("MRR " + mrrId.ToString() + ",B" + code, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(74, 33));

                    //                };
                    //    p.Print();

                    ////}
                    //    //#endregion=============Close===========

                if (decimal.Parse(ReceiveQty) > 0 )
                 {
                    string mrtg = objRec.MrrReceiveInsert(4, xmlunit, intWh, mrrId, DateTime.Now, enroll);                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);

                 }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Receive Quantity Grater then Mrr Quantity);", true);
                }

                dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Rack Type');", true);

                }
            }
            catch { }

        }

        

    }
}