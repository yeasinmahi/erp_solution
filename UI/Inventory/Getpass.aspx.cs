using HR_BLL.Global;
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
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class Getpass : BasePage
    {
        DaysOfWeek bll = new DaysOfWeek(); DataTable dtbl = new DataTable(); string xmlpath; string xmlString = "";
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/GP_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtToOther.Visible = false; Loadgrid();
                txtFromAddress.Text = HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString(); txtAddress.Enabled = true; 
                try { File.Delete(xmlpath); btnSubmit.Visible = false; } 
                catch { }
              
             
            }
        }

        
        #region=========================Employee AutoSearch==================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmplyeeAdd(string prefixText, int count)
        {
             
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetEmployeeLists(true, prefixText);
           

        }

        #endregion======================Close=================================
        #region =================== Get Pass Details Add ==================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    string dt = DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd");
                    string fadd = txtFromAddress.Text;
                    string tadd = "";
                    string taddid = "";
                   
                    if (chkOther.Checked == false)
                    {
                        //string item = ""; string itemid = "";
                        //bool proceed = false;
                        arrayKey = txtAddress.Text.Split(delimiterChars);
                     
                        if (arrayKey.Length > 0)
                        {
                            tadd = arrayKey[0].ToString(); taddid = arrayKey[1].ToString();
                           
                        }

                       // tadd = ddlTo.SelectedItem.ToString();
                        //taddid = ddlTo.SelectedValue.ToString();
                    }
                    else { tadd = txtToOther.Text; taddid = "-1"; }
                    string item = txtItem.Text;
                    string quantity = txtQuantity.Text;
                    string uom = txtUom.Text;
                    string remarks = txtRemarks.Text;
                    string driverName = txtDriverName.Text;
                    string contactNumber = txtContact.Text;
                    string vehicleNumber = txtVehicle.Text;
                    string isrtn = "0";
                    if (chkRtn.Checked)
                    {
                        isrtn = "1";
                    }
                    CreateXml(dt, fadd, tadd, taddid, item, quantity, uom, remarks, isrtn, driverName, contactNumber, vehicleNumber);
                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtItem.Text = string.Empty;
                    txtDriverName.Text = string.Empty;
                    txtContact.Text = string.Empty;
                    txtVehicle.Text = string.Empty;
                    txtQuantity.Text = @"0.00"; 
                    txtRemarks.Text = string.Empty;
                    txtUom.Text = string.Empty;
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void CreateXml(string dt, string fadd, string tadd, string taddid, string item, string quantity, string uom, string remarks, string isrtn, string driverName, string contactNumber, string vehicleNumber)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Getpass");
                XmlNode addItem = CreateNode(doc, dt, fadd, tadd, taddid, item, quantity, uom, remarks, isrtn, driverName, contactNumber, vehicleNumber);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Getpass");
                XmlNode addItem = CreateNode(doc, dt, fadd, tadd, taddid, item, quantity, uom, remarks, isrtn, driverName,contactNumber,vehicleNumber);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); Xml();
        }
        private XmlNode CreateNode(XmlDocument doc, string dt, string fadd, string tadd, string taddid, string item, string quantity, string uom, string remarks, string isrtn, string driverName, string contactNumber, string vehicleNumber)
        {
            XmlNode node = doc.CreateElement("gpdtls");
            XmlAttribute Dt = doc.CreateAttribute("dt");
            Dt.Value = dt;
            XmlAttribute Fadd = doc.CreateAttribute("fadd");
            Fadd.Value = fadd;
            XmlAttribute Tadd = doc.CreateAttribute("tadd");
            Tadd.Value = tadd;
            XmlAttribute Taddid = doc.CreateAttribute("taddid");
            Taddid.Value = taddid;
            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Returnable = doc.CreateAttribute("isrtn");
            Returnable.Value = isrtn;
            XmlAttribute DriverName = doc.CreateAttribute("driverName");
            DriverName.Value = driverName;
            XmlAttribute ContactNumber = doc.CreateAttribute("contactNumber");
            ContactNumber.Value = contactNumber;
            XmlAttribute VehicleNumber = doc.CreateAttribute("vehicleNumber");
            VehicleNumber.Value = vehicleNumber;

            node.Attributes?.Append(Dt);
            node.Attributes?.Append(Fadd);
            node.Attributes?.Append(Tadd);
            node.Attributes?.Append(Taddid);
            node.Attributes?.Append(Item);
            node.Attributes?.Append(Quantity);
            node.Attributes?.Append(Uom);
            node.Attributes?.Append(Remarks);
            node.Attributes?.Append(Returnable);
            node.Attributes?.Append(DriverName);
            node.Attributes?.Append(ContactNumber);
            node.Attributes?.Append(VehicleNumber);
            return node;
        }
        private void Xml()
        {
            XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
            XmlNode xlnd = doc.SelectSingleNode("Getpass");
            xmlString = xlnd.InnerXml;
            xmlString = "<Getpass>" + xmlString + "</Getpass>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet(); ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv.DataSource = ds;
                btnSubmit.Visible = true;
            }
            else
            {
                dgv.DataSource = "";
                btnSubmit.Visible = false;
            }
            dgv.DataBind();
        }
        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Xml();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); dgv.DataSource = ""; dgv.DataBind(); }
                else { Xml(); }
            }
            catch { }
        }
        protected void Dtls_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0].ToString() + "','" + datas[1].ToString() + "');", true);
                Loadgrid();
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void Loadgrid()
        {
            try
            {
                dtbl = bll.GetGetpassListByUser(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()));
                if (dtbl.Rows.Count > 0)
                {
                    dgvlist.DataSource = dtbl;
                    dgvlist.DataBind();
                }
                else
                {
                    dgvlist.DataSource = ""; dgvlist.DataBind();
                }
               
               
            }
            catch { }
        }

        #endregion =================== Get Pass Details Add ==================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode xmls;
                    string msg = "";
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("Getpass");
                        xmlString = xmls.InnerXml;
                        xmlString = "<Getpass>" + xmlString + "</Getpass>";
                        dtbl = bll.CreateGetpass(0,
                            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, 0,
                            DateTime.Now, DateTime.Now);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('" + dtbl.Rows[0]["Messages"].ToString() + "');", true);
                        File.Delete(xmlpath);
                        dgv.DataSource = "";
                        btnSubmit.Visible = false;
                        txtAddress.Text = "";
                        txtToOther.Text = "";
                        chkOther.Checked = false;
                        txtToOther.Visible = false;
                        dgv.DataBind();
                        Loadgrid();
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                }
            }
        }

        protected void chkOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOther.Checked == true) { txtToOther.Visible = true; txtAddress.Enabled = false; }
            else { txtToOther.Visible = false; txtAddress.Enabled = true; }
        }


    }
}