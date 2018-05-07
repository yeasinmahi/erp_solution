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
    public partial class frmPurchaseEntry : BasePage
    {
        string xmlpath,Challanno, strVatMatrialname, filePathForXML, xmlString;
        int intyear,intmonth,intItemid,intfactory, intVatItemid,intSuppId, Purchaseid,intBandrollid, intType;bool ysnexamp, ysnDay, ysnMaterial,YsnChallan,YsnMaterialTotal;
        DataTable dt;decimal qty, bandrollQty,withSDVat, monPrice, SDAmount,TotalAmount, Vat; DateTime dtedate,dtefdate,dtetdate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PurchaseAdd" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                txtFrom.Text = DateTime.Now.ToString("yyyy-MMM-dd");
                dt = objMush.getMType();

                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            
            dtedate =DateTime.Parse(txtFrom.Text);
            dt = objMush.PurchaseEntry(int.Parse(hdnAccno.Value), dtedate.Year, dtedate.Month);

            if (int.Parse(dt.Rows[0]["intAutoId"].ToString()) > 0)
            {
                intType = int.Parse(ddltype.SelectedValue);

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objMush.PurchaseEntry(xmlString, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(hdnAccno.Value), dtedate, intType, int.Parse(hdnysnFactory.Value));
                File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
           }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(hdnconfirm.Value) !=0)
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtMatrialName.Text.Split(delimiterCharss);
                strVatMatrialname = (arrayKeyItem[0].ToString());
                intItemid = int.Parse(arrayKeyItem[1].ToString());

                arrayKeyItem = txtSupplierName.Text.Split(delimiterCharss);
                intSuppId = int.Parse(arrayKeyItem[1].ToString());
                qty = decimal.Parse(txtQty.Text);
                monPrice = decimal.Parse(txtwithoutSDVat.Text);
                SDAmount = decimal.Parse(txtSDAmount.Text);
                Vat = decimal.Parse(txtVat.Text);
                TotalAmount = monPrice + SDAmount + Vat;
                intType = int.Parse(ddltype.SelectedValue);
                Challanno = txtChallanNo.Text;
                dtedate =DateTime.Parse(txtChallandate.Text);
                if (int.Parse(ddlExam.SelectedValue) == 1) { ysnexamp = true; } else { ysnexamp = true; }

                CreateSalesXml(intItemid.ToString(), strVatMatrialname,intSuppId.ToString(), Challanno, dtedate.ToString(), qty.ToString(),monPrice.ToString(), SDAmount.ToString(),  Vat.ToString(), TotalAmount.ToString(), ysnexamp.ToString());
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
                dgvPurchase.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvPurchase.DataSource;
                dsGrid.Tables[0].Rows[dgvPurchase.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvPurchase.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvPurchase.DataSource = ""; dgvPurchase.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected double TotalQty = 0; protected double TotalValue = 0, TotalSDVAT = 0, TotalSD = 0, TotalVAT = 0;
        protected void dgvProductRpt_RowDataBound(object sender, GridViewRowEventArgs e)
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
        private void CreateSalesXml(string intItemid, string strVatMatrialname, string intSuppId, string Challanno, string dtedate, string qty, string monPrice, string SDAmount, string Vat,string TotalAmount, string ysnexamp)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc,  intItemid,  strVatMatrialname,  intSuppId,  Challanno,  dtedate,  qty,  monPrice,  SDAmount,  Vat, TotalAmount,  ysnexamp);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, intItemid, strVatMatrialname, intSuppId, Challanno, dtedate, qty, monPrice, SDAmount, Vat, TotalAmount, ysnexamp);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intItemid, string strVatMatrialname, string intSuppId, string Challanno, string dtedate, string qty, string monPrice,  string SDAmount, string Vat,string TotalAmount, string ysnexamp)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute IntItemid = doc.CreateAttribute("intItemid");
            IntItemid.Value = intItemid;
            XmlAttribute StrVatMatrialname = doc.CreateAttribute("strVatMatrialname");
            StrVatMatrialname.Value = strVatMatrialname;
            XmlAttribute IntSuppId = doc.CreateAttribute("intSuppId");
            IntSuppId.Value = intSuppId;
            XmlAttribute challanno = doc.CreateAttribute("Challanno");
            challanno.Value = Challanno;
            XmlAttribute Dtedate = doc.CreateAttribute("dtedate");
            Dtedate.Value = dtedate;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute MonPrice = doc.CreateAttribute("monPrice");
            MonPrice.Value = monPrice;
            XmlAttribute sDAmount = doc.CreateAttribute("SDAmount");
            sDAmount.Value = SDAmount;
            XmlAttribute vat = doc.CreateAttribute("Vat");
            vat.Value = Vat;
            XmlAttribute totalAmount = doc.CreateAttribute("TotalAmount");
            totalAmount.Value = TotalAmount;
            XmlAttribute Ysnexamp = doc.CreateAttribute("ysnexamp");
            Ysnexamp.Value = ysnexamp;

            node.Attributes.Append(IntItemid);
            node.Attributes.Append(StrVatMatrialname);
            node.Attributes.Append(IntSuppId);
            node.Attributes.Append(challanno);
            node.Attributes.Append(Dtedate);
            node.Attributes.Append(Qty);
            node.Attributes.Append(MonPrice);
            node.Attributes.Append(sDAmount);
            node.Attributes.Append(vat);
            node.Attributes.Append(totalAmount);
            node.Attributes.Append(Ysnexamp);

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
                if (ds.Tables[0].Rows.Count > 0) { dgvPurchase.DataSource = ds; } else { dgvPurchase.DataSource = ""; }
                dgvPurchase.DataBind();
                dgvPurchase.Visible = false;
                dgvPurchase.Visible = true;
            }
            catch { dgvPurchase.DataSource = ""; dgvPurchase.DataBind(); }
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