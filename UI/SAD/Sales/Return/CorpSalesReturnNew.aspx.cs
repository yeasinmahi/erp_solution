using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SAD_BLL.Corporate_Sales;
using SAD_BLL.Corporate_sales;
using System.Data;
using System.Xml;
using System.IO;
using System.Globalization;

namespace UI.SAD.Sales.Return
{
    public partial class CorpSalesReturnNew : BasePage
    {
        DataTable dt = new DataTable();
        Bridge obj = new Bridge();
        OrderInput_BLL objOrder = new OrderInput_BLL();
        string xmlpath = "", xmlString,strReportType, strcustid, strrtnqty, strwhrqty, strprodid, strprodname,strLocation, strchallanno;
        string datetxt;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Sales/Data/CorpRtn_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    
                    File.Delete(xmlpath);
                }
                catch { }
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (hdncustid.Value != "") { strcustid = hdncustid.Value; } else { }
                strchallanno = txtReturnVoucherNo.Text;
                Boolean whrcv = true;
                Boolean ftyrcv = false;
                DateTime dte;
                string strwhrcvdate = txtWHRDate.Text ;
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
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');window.location.href='/SAD/Sales/Return/CorpSalesReturnNew.aspx';", true); return;
                }

            }
            catch (Exception ex)
            {
                File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Return Items.');", true);
            }
        }

        protected void txtCustName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                char[] delimiterChars = { '[', ']' };
                string[] searchKey = txtCustName.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdncustid.Value = searchKey[1].ToString();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name is not valid');", true);
            }

        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '[', ']' };
                
                string[] searchKeyProd = txtProduct.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdnprodid.Value = searchKeyProd[1];
                int itemCustID;
                int itemProductID;
                if (hdnprodid.Value != null)
                {
                    decimal total = Int32.Parse(0.ToString());
                    itemCustID = Int32.Parse(hdncustid.Value);
                    itemProductID = Int32.Parse(hdnprodid.Value);
                    dt = new DataTable();

                    dt = obj.GetProductUOM(itemProductID, itemCustID, 0, 8, Convert.ToString(DateTime.Now));
                    if (dt.Rows.Count > 0)
                    {
                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            string name = dt.Rows[index]["strUOM"].ToString();
                            if (name == "Pice")
                            {
                                hdnUom.Value = dt.Rows[index]["intId"].ToString();
                            }
                        }
                    }

                }

            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Name is not valid');", true); }

        }


        #region========= auto search =========

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomer(string prefixText, int count)
        {
            Int32 unit = 2;
            string customertype = "11", SO = "16";
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return SAD_BLL.Customer.CustomerInfoSt.GetCustomerDataForAutoFill(unit.ToString(), prefixText, customertype.ToString(), SO.ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProduct(string prefixText, int count)
        {
            Int32 unit = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return SAD_BLL.Item.ItemSt.GetProductDataForAutoFill(unit.ToString(), prefixText);

        }

        #endregion============================

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnprodid.Value != "")
                {
                    strprodid = hdnprodid.Value;
                }
                else { }
                strReportType = ddlReport.SelectedItem.Text;
                strLocation = txtLocation.Text;
                strprodname = txtProduct.Text;
                strrtnqty = txtCustQty.Text;
                strwhrqty = txtWHQty.Text;
                DateTime dte;
                string strwhrcvdate;
                try
                {
                    dte = DateTime.ParseExact(txtWHRDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    strwhrcvdate = dte.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('DateTime Format Error.');", true);
                    return;
                }
                if (Convert.ToInt32(strrtnqty)>= Convert.ToInt32(strwhrqty))
                {
                    if (!string.IsNullOrWhiteSpace(hdncustid.Value) && !string.IsNullOrWhiteSpace(hdnprodid.Value))
                    {
                        dt = new DataTable();
                        dt = obj.ProductPrice(Convert.ToInt32(hdnprodid.Value), Convert.ToInt32(hdncustid.Value), Convert.ToInt32(hdnUom.Value), 8);
                        if (dt.Rows.Count > 0)
                        {
                            hdnprice.Value = dt.Rows[0]["Column1"].ToString();
                        }

                    }

                    if (!string.IsNullOrWhiteSpace(hdncustid.Value))
                    {
                        if ((hdnprodid.Value != "") && (hdnprice.Value != ""))
                        {
                            CreateReturnXml(strprodid, strReportType, strprodname, strrtnqty, strwhrqty, strLocation, (Math.Round((decimal.Parse(hdnprice.Value) * int.Parse(strrtnqty)), 2).ToString()));
                        }
                        else
                        {
                            txtProduct.Text = "";
                            txtCustQty.Text = "";
                            txtWHQty.Text = "";
                        }
                    }
                    else
                    {
                        txtCustName.Text = "";
                    }
                    txtProduct.Text = "";
                    txtCustQty.Text = "";
                    txtWHQty.Text = "";
                    strchallanno = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('WH received quantity should be less than Customer received quantity');", true);
                }
               


            }
            catch (Exception ex)
            {

                //var efd = log.GetFlogDetail(stop, location, "Add", ex);
                //Flogger.WriteError(efd);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name or Product Name is not valid');", true);
            }
        }

        private void CreateReturnXml(string strprodid, string strReportType, string strprodname, string strrtnqty, string strwhrqty,string strLocation, string strcost)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Return");
                XmlNode addItem = CreateItemNode(doc, strprodid, strReportType, strprodname, strrtnqty, strwhrqty, strLocation, strcost);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Return");
                XmlNode addItem = CreateItemNode(doc, strprodid, strReportType,strprodname, strrtnqty, strwhrqty, strLocation, strcost);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadGridwithXmlCorpReturn();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string strprodid,string strReportType, string strprodname, string strrtnqty, string strwhrqty,string strLocation, string strcost)
        {
            XmlNode node = doc.CreateElement("ReturnItems");
            XmlAttribute prodid = doc.CreateAttribute("strprodid");
            prodid.Value = strprodid;
            XmlAttribute reportType = doc.CreateAttribute("strReportType");
            reportType.Value = strReportType;
            XmlAttribute prodname = doc.CreateAttribute("strprodname");
            prodname.Value = strprodname;
            XmlAttribute rtnqty = doc.CreateAttribute("strrtnqty");
            rtnqty.Value = strrtnqty;
            XmlAttribute whrqty = doc.CreateAttribute("strwhrqty");
            whrqty.Value = strwhrqty;
            XmlAttribute location = doc.CreateAttribute("strLocation");
            location.Value = strLocation;
            XmlAttribute cost = doc.CreateAttribute("strcost");
            cost.Value = strcost;

            node.Attributes.Append(prodid);
            node.Attributes.Append(reportType);
            node.Attributes.Append(prodname);
            node.Attributes.Append(rtnqty);
            node.Attributes.Append(whrqty);
            node.Attributes.Append(location);
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvrtn.DataSource = ds;
            }
            else
            {
                dgvrtn.DataSource = "";
            }
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
                string fileName = dsGrid.Tables[0].Rows[e.RowIndex][1].ToString();
                File.Delete(Server.MapPath("~/SAD/Sales/Data/") + fileName);
                dsGrid.Tables[0].Rows[dgvrtn.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvrtn.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(xmlpath);
                    dgvrtn.DataSource = "";
                    dgvrtn.DataBind();
                }
                else
                {
                    LoadGridwithXmlCorpReturn();
                }

            }
            catch { }
        }







    }
}