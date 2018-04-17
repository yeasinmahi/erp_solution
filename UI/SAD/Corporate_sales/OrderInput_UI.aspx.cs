
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;


namespace UI.SAD.Corporate_sales
{
    public partial class OrderInput_UI : BasePage
    {
        OrderInput_BLL objOrder = new OrderInput_BLL();
        DataTable dt = new DataTable();
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        string[] arrayKeyProduct; string xmlpath; string xmlString = "";
        decimal checktotal = 0; string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Corporate_sales/Data/Order_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
                Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Session["UnitID"] = intUnit;
                dt = objOrder.shippingpointName(intUnit);
                ddlShipPoint.DataSource = dt;
                ddlShipPoint.DataTextField = "strName";
                ddlShipPoint.DataValueField = "intID";
                ddlShipPoint.DataBind();
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = new DataTable();
                dt = objOrder.Viewgrid(enroll);
                dgvlist.DataSource = dt;
                dgvlist.DataBind();


            }
        }


        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerName(string prefixText, int count)
        {
            Int32 unit =Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetCustname(unit.ToString(), prefixText);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductNameSearch (string prefixText, int count)
        {
            Int32 unit = Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetProductName(unit.ToString(), prefixText);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total; decimal qtytotal = 0;
                dt = new DataTable();
                int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                arrayKeyItem = txtItem.Text.Split(delimiterChars);
                arrayKeyProduct = txtProduct.Text.Split(delimiterChars);
                string itemCust = ""; string itemCustID = "";
                string itemProduct = ""; string itemProductID = "";
                if (arrayKeyItem.Length > 0 && arrayKeyProduct.Length > 0)
                {
                    itemCust = arrayKeyItem[0].ToString();
                    itemCustID = arrayKeyItem[1].ToString();
                    itemProduct = arrayKeyProduct[0].ToString();
                    itemProductID = arrayKeyProduct[1].ToString();
                    try { total = decimal.Parse(hdnUom.Value.ToString()); }
                    catch { total = decimal.Parse(0.ToString()); }
                    dt = new DataTable();
                    dt = objOrder.ProductPrice(0, Convert.ToInt32(itemCustID), 0, Convert.ToInt32(itemProductID), DateTime.Now, DateTime.Now, total, 0);
                    if (dt.Rows.Count > 0) { hdnprice.Value = dt.Rows[0]["Column1"].ToString(); }

                    string qty = txtQuantity.Text.ToString();
                    decimal quentity = decimal.Parse(txtQuantity.Text.ToString());
                    decimal prices =decimal.Parse(hdnprice.Value.ToString());
                    string price = hdnprice.Value.ToString();
                    string spoint = ddlShipPoint.SelectedItem.ToString();
                    string spointID = ddlShipPoint.SelectedValue.ToString();
                   
                    decimal blanc =decimal.Parse(hdnBlance.Value.ToString())*-1;
                    decimal credit = decimal.Parse(hdncredit.Value.ToString());
                    decimal btotal = decimal.Parse((blanc + credit).ToString());
                    qtytotal = decimal.Parse(prices.ToString()) * quentity;
                    string totalprice = qtytotal.ToString();
                    checktotal += decimal.Parse(qtytotal.ToString());
                    if (btotal > checktotal)
                    {
                    CreateXml(itemCust, itemCustID, itemProduct, itemProductID, qty, price, spoint, spointID,totalprice);
                   
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Customer Blance.');", true);
                    }
                    //Clearcontrols();


                }
            }
            catch { }
        }

        private void CreateXml(string itemCust, string itemCustID, string itemProduct, string itemProductID, string qty, string price, string spoint, string spointID, string totalprice)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemCust, itemCustID, itemProduct, itemProductID, qty, price, spoint, spointID, totalprice);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemCust, itemCustID, itemProduct, itemProductID, qty, price, spoint, spointID, totalprice);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }

        private XmlNode CreateNode(XmlDocument doc, string itemCust, string itemCustID, string itemProduct, string itemProductID, string qty, string price, string spoint, string spointID, string totalprice)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute ItemCust = doc.CreateAttribute("itemCust");
            ItemCust.Value = itemCust;
            XmlAttribute ItemCustID = doc.CreateAttribute("itemCustID");
            ItemCustID.Value = itemCustID;
            XmlAttribute ItemProduct = doc.CreateAttribute("itemProduct");
            ItemProduct.Value = itemProduct;
            XmlAttribute ItemProductID = doc.CreateAttribute("itemProductID");
            ItemProductID.Value = itemProductID;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Price = doc.CreateAttribute("price");
            Price.Value = price;
            XmlAttribute Spoint = doc.CreateAttribute("spoint");
            Spoint.Value = spoint;
            XmlAttribute SpointID = doc.CreateAttribute("spointID");
            SpointID.Value = spointID;
            XmlAttribute Totalprice = doc.CreateAttribute("totalprice");
            Totalprice.Value = totalprice;


            node.Attributes.Append(ItemCust);
            node.Attributes.Append(ItemCustID);
            node.Attributes.Append(ItemProduct);
            node.Attributes.Append(ItemProductID);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Price);
            node.Attributes.Append(Spoint);
            node.Attributes.Append(SpointID);
            node.Attributes.Append(Totalprice);
          
            return node;
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlString = xlnd.InnerXml;
                xmlString = "<Requisition>" + xmlString + "</Requisition>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; } dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind(); }
        }
       
        private void Clearcontrols()
        {
           
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            try
            {
                arrayKeyItem = txtItem.Text.Split(delimiterChars);

                string itemCust = ""; int itemCustID;
                string itemProduct = ""; int itemProductID;
               
                    decimal total = Int32.Parse(0.ToString());
                    itemCustID = Int32.Parse(arrayKeyItem[1].ToString());
                    itemProductID = Int32.Parse(0.ToString());
                    dt = objOrder.GetCustomerBlance(2, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total, 0);
                    if (dt.Rows.Count > 0)
                    {
                        hdnBlance.Value = dt.Rows[0]["blance"].ToString();
                        hdncredit.Value = dt.Rows[0]["monCreditLimit"].ToString();
                        txtBlance.Text=dt.Rows[0]["blance"].ToString();
                        txtCreditlim.Text = dt.Rows[0]["monCreditLimit"].ToString();
                    }
                
            }
            catch { }
        
         }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKeyItem = txtItem.Text.Split(delimiterChars);
                arrayKeyProduct = txtProduct.Text.Split(delimiterChars);
                string itemCust = ""; int itemCustID;
                string itemProduct = ""; int itemProductID;
                if (arrayKeyProduct.Length > 0)
                {
                    decimal total = Int32.Parse(0.ToString());
                    itemCustID = Int32.Parse(arrayKeyItem[1].ToString());
                    itemProductID = Int32.Parse(arrayKeyProduct[1].ToString());
                    dt = objOrder.GetProductUOM(0, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total, 0); 
                    if (dt.Rows.Count > 0)
                    {
                        hdnUom.Value = dt.Rows[0]["intUOMId"].ToString();

                    }
                }
            }
            catch { }
          
        }

        protected void dgv_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); dgv.DataSource = ""; dgv.DataBind(); }
                else { LoadXml(); }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                      
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("Requisition");
                        xmlString = xmls.InnerXml;
                        xmlString = "<Requisition>" + xmlString + "</Requisition>";
                        dt = new DataTable();
                       dt = objOrder.CreateCorporaeOrderNumber(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, 0, DateTime.Now, DateTime.Now,0,0);
                         if(dt.Rows.Count>0)
                         {
                             data = dt.Rows[0]["ordernumber"].ToString();
                         }
                         ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + data + "');", true);
                         File.Delete(xmlpath); Clearcontrols(); dgv.DataSource = ""; dgv.DataBind(); dgvlist.DataBind();
                    }
                }
                catch { }
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["order"] = ordernumber1;



                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('OrderDetalis_UI.aspx');", true);

            }
            catch { }
        }
    }
}