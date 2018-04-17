using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AutoChallan;
using System.Data;
using System.Xml;
using UI.ClassFiles;
using System.IO;

namespace UI.SAD.ExcelChallan
{
    public partial class frmProductView : BasePage
    {
        ExcelDataBLL objExcel = new ExcelDataBLL();
        DataTable dt;
        int Shipid, Custid, part, Offid, enroll;
        string pid, qty, freeqty, price, xmlpath,vno,vid,driverenroll,dphone;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/ExcelChallan/Data/AutoChallanupload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(xmlpath); }catch { }
                part = 1; 
                Shipid = int.Parse(Request.QueryString["Shipid"].ToString());
                Offid = int.Parse(Request.QueryString["offid"].ToString());
                Custid = int.Parse(Request.QueryString["Custid"].ToString());
                lblDist.Text =Request.QueryString["CustName"].ToString();
                dt = objExcel.getProductview(Custid, Shipid, part);
                dgvPending.DataSource = dt;
                dgvPending.DataBind();

                dt = objExcel.getVehicleAndDriverName(Custid);
                if (dt.Rows.Count > 0)
                {
                    txtDriverName.Text = dt.Rows[0]["stremployeename"].ToString();
                    txtVehicleno.Text = dt.Rows[0]["strVno"].ToString();
                    txtMobile.Text = dt.Rows[0]["strcontactno1"].ToString();
                    hdnVid.Value = dt.Rows[0]["intVid"].ToString();
                    hdnEnroll.Value = dt.Rows[0]["intEmployeeenroll"].ToString();
                }
            }
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {          
            Custid = int.Parse(Request.QueryString["Custid"].ToString());
            vid = hdnVid.Value;
            vno = txtVehicleno.Text;
            driverenroll = hdnEnroll.Value;
            dphone = txtMobile.Text;
            if (dgvPending.Rows.Count > 0)
            {
                #region ********** XML ************
                for (int index = 0; index < dgvPending.Rows.Count; index++)
                {
                    pid=((HiddenField)dgvPending.Rows[index].FindControl("hdnPid")).Value.ToString();
                    qty = ((TextBox)dgvPending.Rows[index].FindControl("lblQuantity")).Text.ToString();
                    freeqty = ((HiddenField)dgvPending.Rows[index].FindControl("hdnFreeQty")).Value.ToString();
                    price = ((HiddenField)dgvPending.Rows[index].FindControl("hdnprice")).Value.ToString();
                    if (decimal.Parse(qty) > 0)
                    {
                        CreateVoucherXml(Custid.ToString(),pid, qty, freeqty, price,vid,vno,driverenroll,dphone);
                    }
                }

                #endregion **************** End **************
                #region  *************** Database Insert **************
                Shipid = int.Parse(Request.QueryString["Shipid"].ToString());
                Offid = int.Parse(Request.QueryString["offid"].ToString());
                enroll = int.Parse(Request.QueryString["userEnroll"].ToString()); ;
                part = 2;
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objExcel.ExcelDataInsert(xmlString, Shipid, Offid, enroll,part);
                File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                #endregion *********** End Database Entry *****************
                dt = objExcel.getLodingSlipno(Custid);
                if (dt.Rows.Count > 0)
                { txtSlipno.Text = dt.Rows[0]["strSlipNo"].ToString(); }
                dt = objExcel.getProductview(Custid, int.Parse(Request.QueryString["Shipid"].ToString()), 4);
                dgvPending.DataSource = dt;
                dgvPending.DataBind();

            }
        }
        private void CreateVoucherXml(string Custid, string pid, string qty, string freeqty, string price, string vid, string vno, string driverenroll, string dphone)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Voucher");
                XmlNode addItem = CreateItemNode(doc, Custid, pid, qty, freeqty, price, vid, vno, driverenroll, dphone);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Voucher");
                XmlNode addItem = CreateItemNode(doc, Custid, pid, qty, freeqty, price, vid, vno, driverenroll, dphone);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string Custid, string pid, string qty, 
               string freeqty, string price, string vid, string vno, string driverenroll, string dphone)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute custid = doc.CreateAttribute("Custid");
            custid.Value = Custid;
            XmlAttribute Pid = doc.CreateAttribute("pid");
            Pid.Value = pid;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Freeqty = doc.CreateAttribute("freeqty");
            Freeqty.Value = freeqty;
            XmlAttribute Price = doc.CreateAttribute("price");
            Price.Value = price;
            XmlAttribute Vid = doc.CreateAttribute("vid");
            Vid.Value = vid;
            XmlAttribute Vno = doc.CreateAttribute("vno");
            Vno.Value = vno;
            XmlAttribute Driverenroll = doc.CreateAttribute("driverenroll");
            Driverenroll.Value = driverenroll;
            XmlAttribute Dphone = doc.CreateAttribute("dphone");
            Dphone.Value = dphone;

            node.Attributes.Append(custid);
            node.Attributes.Append(Pid);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Freeqty);
            node.Attributes.Append(Price);
            node.Attributes.Append(Vid);
            node.Attributes.Append(Vno);
            node.Attributes.Append(Driverenroll);
            node.Attributes.Append(Dphone);

            return node;
        }

        protected double Pendingtotal = 0; protected double TotalQty = 0;
        protected void dgvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (((Label)e.Row.Cells[4].FindControl("lblTotalqty")).Text == "")
                //{
                //    TotalQty += 0;
                //}
                //else
                //{
                //    TotalQty += double.Parse(((Label)e.Row.Cells[4].FindControl("lblTotalqty")).Text);
                //}
            }

        }
    }
}