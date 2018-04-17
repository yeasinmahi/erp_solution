using SAD_BLL.Corporate_sales;
using SAD_BLL.Corporate_Sales;
using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using SAD_BLL.Item;

namespace UI.SAD.Sales.Return
{
    public partial class CorporateSalesReturn : BasePage
    {
        DataTable dt = new DataTable(); Bridge obj = new Bridge(); OrderInput_BLL objOrder = new OrderInput_BLL();
        string xmlpath = "", xmlString, strcustid, strrtnqty, strwhrqty, strprodid, strprodname, strchallanno;


        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Sales/Data/CorpRtn_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try { File.Delete(xmlpath); } catch { }
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '[', ']' };
                string[] searchKey = txtSearch.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdncustid.Value = searchKey[1].ToString();
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name is not valid');", true); }
        }

        protected void txtprod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '[', ']' };
              
                string[] searchKeyProd = txtprod.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdnprodid.Value = searchKeyProd[1];
                int itemCustID;int itemProductID;
                if (hdnprodid.Value != null)
                {
                    decimal total = Int32.Parse(0.ToString());
                    itemCustID = Int32.Parse(hdncustid.Value);
                    itemProductID = Int32.Parse(hdnprodid.Value);
                    dt = new DataTable();
                    dt = objOrder.GetProductUOM(0, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total, 0);
                    if (dt.Rows.Count > 0)
                    {
                        hdnUom.Value = dt.Rows[0]["intUOMId"].ToString();

                    }
                }
                
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Name is not valid');", true); }
        }

      

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomer(string prefixText, int count)
        {
            Int32 unit = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.GetCustname(unit.ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProduct(string prefixText, int count)
        {
            Int32 unit = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return ItemSt.GetProductDataForAutoFill(unit.ToString(), prefixText);

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {                
                if (hdnprodid.Value != "") { strprodid = hdnprodid.Value; } else {  }
                strprodname = txtprod.Text;
                strrtnqty = txtqty.Text; strwhrqty = txtwhqty.Text;
                if((hdncustid.Value != "") && (hdnprodid.Value != ""))
                {
                    dt = new DataTable();
                    dt = objOrder.ProductPrice(0, Convert.ToInt32(hdncustid.Value), 0, Convert.ToInt32(hdnprodid.Value), DateTime.Now, DateTime.Now, Convert.ToInt32(hdnUom.Value), 0);
                    if (dt.Rows.Count > 0) { hdnprice.Value = dt.Rows[0]["Column1"].ToString(); }
                    
                }

                if (hdncustid.Value != "")
                {
                    if ((hdnprodid.Value != "") && (hdnprice.Value != ""))
                    { CreateReturnXml(strprodid, strprodname, strrtnqty, strwhrqty, ((decimal.Parse(hdnprice.Value)*int.Parse(strrtnqty))/int.Parse(hdnUom.Value)).ToString()); }
                    else { txtprod.Text = ""; txtqty.Text = ""; txtwhqty.Text = ""; }
                }
                else { txtSearch.Text = ""; }
                txtprod.Text = ""; txtqty.Text = ""; txtwhqty.Text = ""; strchallanno = "";
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name or Product Name is not valid');", true); }
        }
        private void CreateReturnXml(string strprodid, string strprodname, string strrtnqty, string strwhrqty, string strcost)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Return");
                XmlNode addItem = CreateItemNode(doc, strprodid, strprodname, strrtnqty, strwhrqty, strcost);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Return");
                XmlNode addItem = CreateItemNode(doc, strprodid, strprodname, strrtnqty, strwhrqty, strcost);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadGridwithXmlCorpReturn();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string strprodid, string strprodname, string strrtnqty, string strwhrqty, string strcost)
        {
            XmlNode node = doc.CreateElement("ReturnItems");
            XmlAttribute prodid = doc.CreateAttribute("strprodid");
            prodid.Value = strprodid;
            XmlAttribute prodname = doc.CreateAttribute("strprodname");
            prodname.Value = strprodname;
            XmlAttribute rtnqty = doc.CreateAttribute("strrtnqty");
            rtnqty.Value = strrtnqty;
            XmlAttribute whrqty = doc.CreateAttribute("strwhrqty");
            whrqty.Value = strwhrqty;
            XmlAttribute cost = doc.CreateAttribute("strcost");
            cost.Value = strcost;

            node.Attributes.Append(prodid);
            node.Attributes.Append(prodname);
            node.Attributes.Append(rtnqty);
            node.Attributes.Append(whrqty);
            node.Attributes.Append(cost);

            return node;
        }
        private void LoadGridwithXmlCorpReturn()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlNode corpeturn = doc.SelectSingleNode("Return");
            xmlString = corpeturn.InnerXml;
            xmlString = "<Return>" + xmlString + "</Return>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvrtn.DataSource = ds; }
            else { dgvrtn.DataSource = ""; }
            dgvrtn.DataBind();
        }
        protected void dgvrtn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode corpeturn = doc.SelectSingleNode("Return");
                string xmlString = corpeturn.InnerXml;
                xmlString = "<Return>" + xmlString + "</Return>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvrtn.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvrtn.DataSource;
                string fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();
                File.Delete(Server.MapPath("~/SAD/Sales/Data/") + fileName);
                dsGrid.Tables[0].Rows[dgvrtn.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvrtn.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpath); dgvrtn.DataSource = ""; dgvrtn.DataBind(); }
                else { LoadGridwithXmlCorpReturn(); }
            }
            catch { }
        }
        protected void btvSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdncustid.Value != "") { strcustid = hdncustid.Value; } else {  }
                strchallanno = txtchallanno.Text;
                Boolean whrcv = true;
                Boolean ftyrcv = false;
                string strwhrcvdate = txtwhrcvdte.Text;
                string stractionby = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode corpreturn = doc.SelectSingleNode("Return");
                string xmlString = corpreturn.InnerXml;
                xmlString = "<Return>" + xmlString + "</Return>";
                if (hdnconfirm.Value == "1")
                {
                    dt = obj.InsertCorpRtnNGetFk(strcustid, strchallanno, whrcv, ftyrcv, stractionby, strwhrcvdate);
                    int fk = int.Parse(dt.Rows[0]["fk"].ToString());
                    string msg = obj.InsertCorpReturnRcvProd(fk, xmlString);
                    File.Delete(xmlpath);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');window.location.href='/SAD/Sales/Return/CorporateSalesReturn.aspx';", true); return;
                }

            }
            catch { File.Delete(xmlpath); ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Return Items.');", true); }
        }

        

    }
}