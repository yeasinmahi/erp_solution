using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;

namespace UI.SAD.Vat
{
    public partial class frmBrandrollReceive : BasePage
    {
        string xmlpath,Challanno,DeliveryNo,Dono,strBandrollname, filePathForXML, xmlString;
        int intyear,intmonth,intbandrollid, Purchaseid,intBandrollid;
        DataTable dt;decimal qty;
        DateTime dtedate, dteReceivedate,dteDodate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PurchaseAdd" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                txtdtedate.Text = DateTime.Now.ToString("yyyy-MMM-dd");
                txtDodate.Text = DateTime.Now.ToString("yyyy-MMM-dd");

                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }
                dt.Clear();
                dt = objMush.getBandrollList(int.Parse(hdnAccno.Value));
                ddlBandrollList.DataTextField= "strBandrollName";
                ddlBandrollList.DataValueField = "intBandrollID";
                ddlBandrollList.DataSource = dt;
                ddlBandrollList.DataBind();

            }
        }
      
        protected void btnSave_Click(object sender, EventArgs e)
        {                      
                dtedate =DateTime.Parse(txtdtedate.Text);
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objMush.BrandrollReceiveEntry(xmlString, int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.USER_ID].ToString()),int.Parse(ddltype.SelectedValue));
                File.Delete(xmlpath);
         
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(hdnconfirm.Value) !=0)
            {
                dteDodate = DateTime.Parse(txtDodate.Text);
              
                strBandrollname = ddlBandrollList.SelectedItem.ToString();
                intbandrollid = int.Parse(ddlBandrollList.SelectedValue.ToString());
                Dono = txtDemandOrderno.Text;
                dteDodate =DateTime.Parse(txtDodate.Text);
                DeliveryNo = txtDeliveryOrderno.Text;
                dtedate= DateTime.Parse(txtdtedate.Text);
                dteReceivedate = DateTime.Parse(txtdtedate.Text);
                qty =decimal.Parse(txtQty.Text);
       
                CreateSalesXml(intbandrollid.ToString(), strBandrollname, Dono, dteDodate.ToString(), DeliveryNo, dtedate.ToString(), dteReceivedate.ToString(), qty.ToString());
            }
            else {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Correct Information !');", true);
            }

        }
        protected void dgvPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvBrandroll.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvBrandroll.DataSource;
                dsGrid.Tables[0].Rows[dgvBrandroll.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvBrandroll.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvBrandroll.DataSource = ""; dgvBrandroll.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected double TotalQty = 0; protected double TotalValue = 0, TotalSDVAT = 0, TotalSD = 0, TotalVAT = 0;
        protected void dgvPurChaseRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[4].FindControl("lblQty")).Text == "")
                {
                    TotalQty += 0;
                }
                else
                {
                    TotalQty += double.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                }
                if (((Label)e.Row.Cells[4].FindControl("lblSDVATQty")).Text == "")
                {
                    TotalSDVAT += 0;
                }
                else
                {
                    TotalSDVAT += double.Parse(((Label)e.Row.Cells[4].FindControl("lblSDVATQty")).Text);
                }
                
                if (((Label)e.Row.Cells[4].FindControl("lblsd")).Text == "")
                {
                    TotalSD += 0;
                }
                else
                {
                    TotalSD += double.Parse(((Label)e.Row.Cells[4].FindControl("lblsd")).Text);
                }
                if (((Label)e.Row.Cells[4].FindControl("lblvatQty")).Text == "")
                {
                    TotalVAT += 0;
                }
                else
                {
                    TotalVAT += double.Parse(((Label)e.Row.Cells[4].FindControl("lblvatQty")).Text);
                }
                if (((Label)e.Row.Cells[5].FindControl("lblAmount")).Text == "")
                {
                    TotalValue += 0;
                }
                else
                {
                    TotalValue += double.Parse(((Label)e.Row.Cells[5].FindControl("lblAmount")).Text);
                }
            }

        }
        protected void btnDelete(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Purchaseid = int.Parse(searchKey[0].ToString());
                dt = objMush.getYearmonthpurchase(Purchaseid);
                intyear = int.Parse(dt.Rows[0]["intyear"].ToString());
                intmonth = int.Parse(dt.Rows[0]["intMonth"].ToString());
                dt = objMush.getPurchseCount(Purchaseid,intyear,intmonth);
                if (int.Parse(dt.Rows[0][""].ToString()) == 0)
                {
                    objMush.gepPurchasedelete(int.Parse(hdnAccno.Value), Purchaseid, 2);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Mushak-19 for this purchase already created. Therefore, delete is not possible!');", true); }
            }
            catch { }
        }
        private void CreateSalesXml(string brandrollid, string brandrollname,string Demorderno, string demordedate, string Deliveryno, string deliverydate,string receivedate, string qty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, brandrollid, brandrollname, Demorderno, demordedate, Deliveryno, deliverydate, receivedate,  qty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, brandrollid, brandrollname, Demorderno, demordedate, Deliveryno, deliverydate, receivedate, qty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string brandrollid, string brandrollname, string Demorderno, string demordedate, string Deliveryno, string deliverydate, string receivedate,string qty)
        {
            XmlNode node = doc.CreateElement("item");
       
            XmlAttribute Brandrollid = doc.CreateAttribute("brandrollid");
            Brandrollid.Value = brandrollid;
            XmlAttribute Brandrollname = doc.CreateAttribute("brandrollname");
            Brandrollname.Value = brandrollname;

            XmlAttribute demorderno = doc.CreateAttribute("Demorderno");
            demorderno.Value = Demorderno;
            XmlAttribute Demordedate = doc.CreateAttribute("demordedate");
            Demordedate.Value = demordedate;
            XmlAttribute deliveryno = doc.CreateAttribute("Deliveryno");
            deliveryno.Value = Deliveryno;
            XmlAttribute Deliverydate = doc.CreateAttribute("deliverydate");
            Deliverydate.Value = deliverydate;
            XmlAttribute Receivedate = doc.CreateAttribute("receivedate");
            Receivedate.Value = receivedate;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;

            node.Attributes.Append(Brandrollid);
            node.Attributes.Append(Brandrollname);
            node.Attributes.Append(demorderno);
            node.Attributes.Append(Demordedate);
            node.Attributes.Append(deliveryno);
            node.Attributes.Append(Deliverydate);
            node.Attributes.Append(Receivedate);
            node.Attributes.Append(Qty);
          

            return node;
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("SOItem");
                xmlString = xlnd.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvBrandroll.DataSource = ds; } else { dgvBrandroll.DataSource = ""; }
                dgvBrandroll.DataBind();
                dgvBrandroll.Visible = false;
                dgvBrandroll.Visible = true;
            }
            catch { dgvBrandroll.DataSource = ""; dgvBrandroll.DataBind(); }
        }

     
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchMatrial(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] SupplierSearch(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSupplierList(prefixText, unitid);
        }

        #endregion * ********** End search **********

    }
}