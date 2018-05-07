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
    public partial class frmBrandroll : BasePage
    {
        string xmlpath,Challanno, Pname,strBandrollname, filePathForXML, xmlString,Packagename;
        int intyear,intmonth,intproductid,intbandrollid,intfactory, intVatItemid,intSuppId, Purchaseid,intBandrollid, intType;bool ysnexamp, ysnDay, ysnMaterial,YsnChallan,YsnMaterialTotal;
        DataTable dt;decimal qty, bandrollQty,withSDVat, monPrice, SDAmount,TotalAmount, Vat;

        DateTime dtedate,dtefdate,dtetdate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PurchaseAdd" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
             
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
        protected void ddlBandrollList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = objMush.getBandrollProduct(int.Parse(hdnAccno.Value), int.Parse(ddlBandrollList.SelectedValue));

            ddlBandrollProduct.DataTextField = "strVatProductName";
            ddlBandrollProduct.DataValueField = "strPackageType";
            ddlBandrollProduct.DataSource = dt;
            ddlBandrollProduct.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {                      
              
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objMush.BrandrollOrderEntry(xmlString, txtDemandOrderno.Text, dtedate, int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.USER_ID].ToString()));
                File.Delete(xmlpath);
         
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(hdnconfirm.Value) !=0)
            {
              
                strBandrollname = ddlBandrollList.SelectedItem.ToString();
                intbandrollid = int.Parse(ddlBandrollList.SelectedValue.ToString());
                Pname = ddlBandrollProduct.SelectedItem.ToString();
                intproductid = int.Parse(ddlBandrollProduct.SelectedValue.ToString());
                char[] delimiterCharss = { ',' };
                arrayKeyItem = ddlBandrollProduct.SelectedItem.ToString().Split(delimiterCharss);
                intproductid =int.Parse(arrayKeyItem[0].ToString());
                Packagename = (arrayKeyItem[1].ToString());
                qty = decimal.Parse(txtQty.Text);
                             
                CreateSalesXml(intproductid.ToString(), Pname, Packagename, intbandrollid.ToString(), strBandrollname, dtedate.ToString(), qty.ToString());
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
        private void CreateSalesXml(string Productid, string Productname, string packagetype, string brandrollid, string brandrollname, string qty, string Remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, Productid, Productname, packagetype, brandrollid, brandrollname,  qty, Remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, Productid, Productname, packagetype, brandrollid, brandrollname, qty, Remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string Productid, string Productname, string packagetype, string brandrollid, string brandrollname, string qty, string Remarks)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute productid = doc.CreateAttribute("Productid");
            productid.Value = Productid;
            XmlAttribute productname = doc.CreateAttribute("Productname");
            productname.Value = Productname;
            XmlAttribute Packagetype = doc.CreateAttribute("packagetype");
            Packagetype.Value = packagetype;
            XmlAttribute Brandrollid = doc.CreateAttribute("brandrollid");
            Brandrollid.Value = brandrollid;
            XmlAttribute Brandrollname = doc.CreateAttribute("brandrollname");
            Brandrollname.Value = brandrollname;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute remarks = doc.CreateAttribute("Remarks");
            remarks.Value = Remarks;
         

            node.Attributes.Append(productid);
            node.Attributes.Append(productname);
            node.Attributes.Append(Packagetype);
            node.Attributes.Append(Brandrollid);
            node.Attributes.Append(Brandrollname);
            node.Attributes.Append(Qty);
            node.Attributes.Append(remarks);

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

        protected void btnReport_Click(object sender, EventArgs e)
        {

            dtefdate = DateTime.Parse(txtfdate.Text);
            dtetdate = DateTime.Parse(txtfdate.Text);
            if (int.Parse(ddlShorby.SelectedValue) == 1)
            {
                ysnDay = true;
                ysnMaterial = false;
                YsnMaterialTotal = false;
                YsnChallan = false;
            }
            else if (int.Parse(ddlShorby.SelectedValue) == 2)
            {
                ysnDay = false;
                ysnMaterial = true;
                YsnMaterialTotal = false;
                YsnChallan = false;
            }
            else if (int.Parse(ddlShorby.SelectedValue) == 3)
            {
                ysnDay = false;
                ysnMaterial = false;
                YsnMaterialTotal = false;
                YsnChallan = true;
            }
            else if (int.Parse(ddlShorby.SelectedValue) == 4)
            {
                ysnDay = false;
                ysnMaterial = false;
                YsnMaterialTotal = true;
                YsnChallan = false;
            }



            dt = objMush.getPurchaseReport(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(hdnAccno.Value),dtefdate,dtetdate,ysnDay,ysnMaterial,YsnChallan,YsnMaterialTotal);
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