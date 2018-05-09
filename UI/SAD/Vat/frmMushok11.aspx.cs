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
    public partial class frmMushok11 : BasePage
    {
        string strChallanNo, strVATNo, sallername, strSallerAddress,strCustAddress,custVatid, strCustomerName, strCustVATRegNo,strItemname, xmlString, strFinalDistanitionAddress, filePathForXML, strVehicleRegNo, TotalQty,Wastage,WholeSales,mrr, vno;bool ysntxt;
        int intYear,intsl, intVatChallanNo, intVatAccountID, intUnitID, intSVUnit, intTypeID, intCount=0, intVatItemid, intUserID, INTBOMID,intMatrialid,VatCount;
 
        DateTime dteM11DateTime,  dteChallanDate, dteSVDateTime;
        DataTable dt;
        Decimal SDCharge, SDPercent, monSDwithOutPrice=0, monSDAmount=0, monTotalSDAmount=0, monVatAmount=0
        , monSurChargeAmount=0, VATPercent, SCPercent,Qty,Amount, DollarAmount;
        DateTime dtedate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        ExcelDataBLL objExcel = new ExcelDataBLL();
        Mushok11 objMush = new Mushok11();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/ExportDeclare" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
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
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    lblVatAccNametxt.Text = dt.Rows[0]["strVATAccountName"].ToString();
                    lblVatregtxt.Text = dt.Rows[0]["strVATRegNo"].ToString();
                    lblAddresstxt.Text = dt.Rows[0]["strAddress"].ToString();
                }
                dt = objMush.getChallanList(int.Parse(hdnAccno.Value));
                ddlChallan.DataTextField = "challanno";
                ddlChallan.DataValueField = "strCode";
                ddlChallan.DataSource = dt;
                ddlChallan.DataBind();

            }
        }        
     
        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            intCount = intCount + 1;

            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItem.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            strItemname = (arrayKeyItem[0].ToString());
            Qty = decimal.Parse(txtQty.Text);
            Amount = decimal.Parse(txtAmount.Text);
            SDCharge = 0;
            SDPercent = 0;
           
            if (dgvExportVat.Rows.Count < 7)
            {
                CreateSalesXml(intVatItemid.ToString(), strItemname, Qty.ToString(), SDCharge.ToString(), "$" + SDPercent.ToString(), Amount.ToString(), "$" + Amount.ToString());
            }
        }
        protected void btnMushok_Click(object sender, EventArgs e)
        {
            hdnEnroll.Value = (Session[SessionParams.USER_ID].ToString());
            hdnChallanno.Value = ddlChallan.SelectedValue.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowPopUpCust('frmMushok11Print.aspx?');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            dtedate = DateTime.Now;
            if (dtedate.Month >= 7)
            {
                intYear =int.Parse((dtedate.Year)+""+((dtedate.Year)+1).ToString());
            }
            else { intYear = int.Parse(((dtedate.Year) - 1).ToString() + "" + ((dtedate.Year) + 1).ToString()); }
            dt = objMush.getVatChallano(intYear,int.Parse(hdnAccno.Value),"M11");
            intVatChallanNo = int.Parse(dt.Rows[0]["intVatChallanNo"].ToString());
            hdnYear.Value = intYear.ToString();
            sallername = lblVatAccNametxt.Text;
            strSallerAddress = lblAddresstxt.Text;
            strVATNo = lblVatregtxt.Text;
            strCustomerName = txtCustomer.Text;
            strCustAddress = txtAddressExp.Text;
            custVatid = txtVatIDExp.Text;
            strFinalDistanitionAddress = txtDestination.Text;
            strVehicleRegNo = txtVehicleNoExp.Text;
            if(txtFromExp.Text=="")
            {
                dteSVDateTime = DateTime.Now;
                dteM11DateTime = DateTime.Now;
            }
            else {
                dteSVDateTime = DateTime.Parse(txtFromExp.Text);
                dteM11DateTime = DateTime.Parse(txtFromExp.Text);
            }
            intUnitID = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            intTypeID = 6;
            intSVUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            if (dgvExportVat.Rows.Count > 0)
            {
               
                for (int index = 0; index < dgvExportVat.Rows.Count; index++)
                {
                    


                    intVatItemid =int.Parse(((Label)dgvExportVat.Rows[index].FindControl("lblProductid")).Text.ToString());
                    string paname = ((Label)dgvExportVat.Rows[index].FindControl("lblintItemnames")).Text.ToString();
                    Qty =decimal.Parse(((TextBox)dgvExportVat.Rows[index].FindControl("lblQuantity")).Text.ToString());
                    Amount = decimal.Parse(((TextBox)dgvExportVat.Rows[index].FindControl("lblAmount")).Text.ToString());
                    intsl = index;
                    objMush.getM11insert(sallername, strSallerAddress, strVATNo, strCustomerName, strCustAddress, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, intVatChallanNo, dteSVDateTime, dteM11DateTime, intsl, paname, Qty, monSDwithOutPrice, monSDAmount, monTotalSDAmount, monVatAmount, Amount, monSurChargeAmount,intYear, intUnitID, intTypeID, intSVUnit, int.Parse(hdnAccno.Value));
                    objMush.getM17m18(intVatChallanNo,dteSVDateTime,intVatItemid,Qty, monSDwithOutPrice, monSDAmount, monVatAmount,Amount, monSurChargeAmount, intUnitID,int.Parse(Session[SessionParams.USER_ID].ToString()), intTypeID, strCustomerName, strCustVATRegNo, strCustAddress, strFinalDistanitionAddress, int.Parse(hdnAccno.Value));
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowPopUpCustExport('frmMushok11PrintExport.aspx?');", true);
            }

        }
        protected void dgvExportVat_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            intCount = intCount - 1;
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
                dgvExportVat.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvExportVat.DataSource;
                dsGrid.Tables[0].Rows[dgvExportVat.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvExportVat.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvExportVat.DataSource = ""; dgvExportVat.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected void rbVat_CheckedChanged(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            PanelExport.Visible = false;
            PanelProductAdd.Visible = false;
        }

        protected void rbExport_CheckedChanged(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            PanelExport.Visible = true;
            PanelProductAdd.Visible = true;
        }
       
        protected double totalQty = 0, totalvalue=0, totalAmount=0;      
        protected void dgvExportVat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[2].FindControl("lblQty")).Text == "")
                {
                    totalQty += 0;
                }
                else
                {
                    totalQty += double.Parse(((Label)e.Row.Cells[6].FindControl("lblQty")).Text);
                }
                if (((Label)e.Row.Cells[7].FindControl("lblAmount")).Text == "")
                {
                    totalvalue += 0;
                }
                else
                {
                    totalvalue += double.Parse(((Label)e.Row.Cells[7].FindControl("lblAmount")).Text);
                }
                if (((Label)e.Row.Cells[7].FindControl("lblAmount")).Text == "")
                {
                    totalAmount += 0;
                }
                else
                {
                    totalAmount += double.Parse(((Label)e.Row.Cells[7].FindControl("lblAmount")).Text);
                }

            }
        }

        private void CreateSalesXml(string intItemid, string strItemname, string Qty,string sdcharge,string sdperc, string Amount, string DolarAmount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, intItemid, strItemname, Qty, sdcharge,sdperc, Amount, DolarAmount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, intItemid, strItemname, Qty, sdcharge, sdperc, Amount, DolarAmount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
          
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intItemid, string strItemname, string Qty,string sdchar,string sdper, string Amount, string DolarAmount)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute IntItemid = doc.CreateAttribute("intItemid");
            IntItemid.Value = intItemid;
            XmlAttribute StrItemname = doc.CreateAttribute("strItemname");
            StrItemname.Value = strItemname;
            XmlAttribute qty = doc.CreateAttribute("Qty");
            qty.Value = Qty;
            XmlAttribute Sdchar = doc.CreateAttribute("sdchar");
            Sdchar.Value = sdchar;
            XmlAttribute Sdper = doc.CreateAttribute("sdper");
            Sdper.Value = sdper;
            XmlAttribute amount = doc.CreateAttribute("Amount");
            amount.Value = Amount;
            XmlAttribute dolarAmount = doc.CreateAttribute("DolarAmount");
            dolarAmount.Value = DolarAmount;
            
            node.Attributes.Append(IntItemid);
            node.Attributes.Append(StrItemname);
            node.Attributes.Append(qty);
            node.Attributes.Append(Sdchar);
            node.Attributes.Append(Sdper);
            node.Attributes.Append(amount);
            node.Attributes.Append(dolarAmount);
           
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
                if (ds.Tables[0].Rows.Count > 0) { dgvExportVat.DataSource = ds; } else { dgvExportVat.DataSource = ""; }
                dgvExportVat.DataBind();
                dgvExportVat.Visible = false;
                dgvExportVat.Visible = true;
            }
            catch { dgvExportVat.DataSource = ""; dgvExportVat.DataBind(); }
        }
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int accid=  int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
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
        public static string[] ItemnameSearchSAD(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSadItem(prefixText, unitid);

        }
        #endregion * ********** End search **********

    }
}