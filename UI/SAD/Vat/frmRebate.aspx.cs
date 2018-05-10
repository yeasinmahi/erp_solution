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
    public partial class frmRebate : BasePage
    {
        string xmlpath,Challanno,itemname,DeliveryNo, strMaterial, intMaterial, monM1Qty, strUOM, strChallan, Dono,strBandrollname, filePathForXML, xmlString;
        int intyear,intmonth,Productid, intImportID, intbandrollid,itemid, Purchaseid,intBandrollid;
        DataTable dt;decimal qty, monQty, monCD, monSD, monRebateRate, monTotalDuty, monTotalUse, monRD, monOther, monExpQty;

        DateTime dtedate, dteReceivedate,dteimpdate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PurchaseAdd" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();           
                txtdate.Text = DateTime.Now.ToString("yyyy-MMM-dd");

                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }
                txtOthers.Text = "0";
                txtCD.Text = "0";
                txtSD.Text = "0";
                txtRD.Text = "0";
              

            }
        }

        protected void ddlMatiral_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = objMush.getImport(int.Parse(ddlMatiral.SelectedValue),1);
            if (dt.Rows.Count > 0)
            {
                ddlImport.DataTextField = "strChallanNo";
                ddlImport.DataValueField = "intID";
                ddlImport.DataSource = dt;
                ddlImport.DataBind();
            }
            dt.Clear();
           
            dt = objMush.getImport(int.Parse(ddlMatiral.SelectedValue), 2);
            if (dt.Rows.Count > 0)
            {
                lbluom.Text = dt.Rows[0]["strUOM"].ToString();
                lblused.Text = dt.Rows[0]["numQty"].ToString();
            }
            dt.Clear();



        }

        protected void ddlImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCD.Text = "";
            txtSD.Text = "";
            txtRD.Text = "";
            txtOthers.Text = "";

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtReportVatProduct.Text.Split(delimiterCharss);         
            itemid = int.Parse(arrayKeyItem[1].ToString());
            if (txtrdate.Text == "")
            {
                dt = objMush.getExportReport(itemid, txtrdate.Text);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItemName.Text.Split(delimiterCharss);
            Productid = int.Parse(arrayKeyItem[1].ToString());

                dtedate =DateTime.Parse(txtdate.Text);
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objMush.RebitSave(xmlString, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value),Productid, int.Parse(Session[SessionParams.USER_ID].ToString()),dtedate);
                File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ message + "');", true);
        }

        protected void txtItemMatrial_TextChanged(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItemName.Text.Split(delimiterCharss);
            itemname = (arrayKeyItem[0].ToString());
            itemid = int.Parse(arrayKeyItem[1].ToString());
            dtedate = DateTime.Parse(txtdate.Text);
            dt = objMush.getexportamount(itemid,  dtedate.Month, dtedate.Year);
            lblexport.Text = dt.Rows[0]["monExport"].ToString();
            dt = objMush.getBOMid(itemid);
            hdnbomid.Value= dt.Rows[0]["intBOMID"].ToString();
            dt = objMush.getMatrialItemList(int.Parse(hdnbomid.Value));
            ddlMatiral.DataTextField = "strMaterialName";
            ddlMatiral.DataValueField = "intVATMaterialID";
            ddlMatiral.DataSource = dt;
            ddlMatiral.DataBind();
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(hdnconfirm.Value) !=0)
            {
                dtedate = DateTime.Parse(txtdate.Text);
                strMaterial = ddlMatiral.SelectedItem.ToString();
                intMaterial= ddlMatiral.SelectedValue.ToString();
                monM1Qty = lblused.Text;
                strUOM = lbluom.Text;
                intImportID = int.Parse(ddlImport.SelectedValue);
                dt = objMush.getImport(intImportID);
                if (dt.Rows.Count > 0)
                {
                    Challanno = (dt.Rows[0]["strChallanNo"].ToString());
                    dteimpdate = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                }
                monCD =decimal.Parse(txtCD.Text);
                monSD= decimal.Parse(txtSD.Text);
                monRD = decimal.Parse(txtRD.Text);
                monOther = decimal.Parse(txtOthers.Text);
                monExpQty = decimal.Parse(lblexport.Text);
                monTotalUse =decimal.Parse(monM1Qty) * monExpQty;
                monTotalDuty = monCD + monSD + monRD + monOther;
                if(monTotalDuty!=0)
                {
                    monRebateRate = monTotalDuty / monQty;
                }
                CreateSalesXml(intMaterial.ToString(), strMaterial, strUOM, monM1Qty, monTotalUse.ToString(), intImportID.ToString(), Challanno, dtedate.ToString(), monExpQty.ToString(), monCD.ToString(), monSD.ToString(), monRD.ToString(), monOther.ToString(), monTotalDuty.ToString(), monRebateRate.ToString());
                txtCD.Text = "";
                txtSD.Text = "";
                txtRD.Text = "";
                txtOthers.Text = "";
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
        private void CreateSalesXml(string intMaterial, string strMaterial, string strUOM, string monM1Qty, string monTotalUse, string intImportID, string Challanno, string dtedate, string monExpQty, string monCD, string monSD, string monRD, string monOther, string monTotalDuty, string monRebateRate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, intMaterial, strMaterial, strUOM, monM1Qty, monTotalUse,  intImportID,  Challanno,  dtedate,  monExpQty,  monCD,  monSD,  monRD,  monOther,  monTotalDuty,  monRebateRate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, intMaterial, strMaterial, strUOM, monM1Qty, monTotalUse, intImportID, Challanno, dtedate, monExpQty, monCD, monSD, monRD, monOther, monTotalDuty, monRebateRate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intMaterial, string strMaterial, 
            string strUOM, string monM1Qty, string monTotalUse, string intImportID, string Challanno,
            string dtedate, string monExpQty, string monCD, string monSD, string monRD, string
            monOther, string monTotalDuty, string monRebateRate)
        {
            XmlNode node = doc.CreateElement("item");
       
            XmlAttribute IntMaterial = doc.CreateAttribute("intMaterial");
            IntMaterial.Value = intMaterial;
            XmlAttribute StrMaterial = doc.CreateAttribute("strMaterial");
            StrMaterial.Value = strMaterial;

            XmlAttribute StrUOM = doc.CreateAttribute("strUOM");
            StrUOM.Value = strUOM;
            XmlAttribute MonM1Qty = doc.CreateAttribute("monM1Qty");
            MonM1Qty.Value = monM1Qty;
            XmlAttribute MonTotalUse = doc.CreateAttribute("monTotalUse");
            MonTotalUse.Value = monTotalUse;
            XmlAttribute IntImportID = doc.CreateAttribute("intImportID");
            IntImportID.Value = intImportID;
            XmlAttribute challanno = doc.CreateAttribute("Challanno");
            challanno.Value = Challanno;
            XmlAttribute Dtedate = doc.CreateAttribute("dtedate");
            Dtedate.Value = dtedate;
            XmlAttribute MonExpQty = doc.CreateAttribute("monExpQty");
            MonExpQty.Value = monExpQty;
            XmlAttribute MonCD = doc.CreateAttribute("monCD");
            MonCD.Value = monCD;
            XmlAttribute MonSD = doc.CreateAttribute("monSD");
            MonSD.Value = monSD;
            XmlAttribute MonRD = doc.CreateAttribute("monRD");
            MonRD.Value = monRD;
            XmlAttribute MonOther = doc.CreateAttribute("monOther");
            MonOther.Value = monOther;
            XmlAttribute MonTotalDuty = doc.CreateAttribute("monTotalDuty");
            MonTotalDuty.Value = monTotalDuty;
            XmlAttribute MonRebateRate = doc.CreateAttribute("monRebateRate");
            MonRebateRate.Value = monRebateRate;

            node.Attributes.Append(IntMaterial);
            node.Attributes.Append(StrMaterial);
            node.Attributes.Append(StrUOM);
            node.Attributes.Append(MonM1Qty);
            node.Attributes.Append(MonTotalUse);
            node.Attributes.Append(IntImportID);
            node.Attributes.Append(challanno);
            node.Attributes.Append(Dtedate);
            node.Attributes.Append(MonExpQty);
            node.Attributes.Append(MonCD);
            node.Attributes.Append(MonSD);
            node.Attributes.Append(MonRD);
            node.Attributes.Append(MonOther);
            node.Attributes.Append(MonTotalDuty);
            node.Attributes.Append(MonRebateRate);
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
        public static string[] ItemnameSearch(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getVatItemList(prefixText, accid);
        }
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