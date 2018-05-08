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
    public partial class frmMushok11PrintExport : BasePage
    {
        string strChallanNo, strCustomerName, strCustVATRegNo, xmlString, strFinalDistanitionAddress, filePathForXML, strVehicleRegNo, TotalQty,Wastage,WholeSales,mrr, vno;bool ysntxt;
        int  intUserID; DataTable dt;
        string[] arrayKeyItem;
        char[] delimiterChars = { '[', ']' };
        ExcelDataBLL objExcel = new ExcelDataBLL();
        Mushok11 objMush = new Mushok11();   DateTime dtedate;  

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PriceDeclare" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
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
                    lblCustomer.Text = dt.Rows[0]["strVATAccountName"].ToString();
                    lblAddresstxt.Text = dt.Rows[0]["strAddress"].ToString();
                }
                dt = objMush.getM11PrintExport(int.Parse(hdnAccno.Value), Request.QueryString["Challanno"].ToString());
              
                dgvChallan.DataSource = dt;
                dgvChallan.DataBind();
                if(dt.Rows.Count>0)
                {
                    
                    lblvatno.Text = dt.Rows[1]["strVATNo"].ToString();
                    lblCustNamtxt.Text = dt.Rows[1]["strCustomerName"].ToString();
                    lblCustNamtxt.Text = dt.Rows[1]["strCustomerAddress"].ToString();
                    lblFinalAddress.Text = dt.Rows[1]["strFinalDistanitionAdd"].ToString();
                    lblChallanotxt.Text= dt.Rows[1]["strVATNo"].ToString();
                    lblChallanDateTxt.Text= dt.Rows[1]["dteSVDateTime"].ToString();
                    dtedate=DateTime.Parse(dt.Rows[1]["dteSVDateTime"].ToString());
                    lblChallanDateTxt.Text = dtedate.ToString("hh:mm:ss"); 
                    lblvatno.Text = dt.Rows[1]["strCustomerVATNo"].ToString(); 
                    lblSonaktoSonka.Text = dt.Rows[1]["strSVno"].ToString();
                    lblVno.Text = dt.Rows[1]["strVehicleNo"].ToString();
                    dtedate = DateTime.Parse(dt.Rows[1]["dteM11DateTime"].ToString());
                    lblPayDate.Text = dtedate.ToString("dd-mm-yyyy");
                   
                    lblpaytime.Text= dtedate.ToString("dd-mm-yyyy") +" "+ dtedate.ToString("hh:mm:ss");

                }

            }
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
          
        }
      
        protected void btnMushok_Click(object sender, EventArgs e)
        {
            intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
            //dt = objMush.getMushokCreate(ddlChallan.SelectedValue.ToString(), int.Parse(hdnAccno.Value), strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, intVatChallanNo, dteM11DateTime, intUserID, dteChallanDate, intUnitID, strCustomerName);

        }
        protected double Qtytotal = 0, monSDwithOutPricetotal=0, monSDAmounttotal = 0, monTotalSDAmounttotal = 0, monVatAmounttotal = 0, monTotaltotal = 0;

        protected void dgvChallan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (((Label)e.Row.Cells[2].FindControl("lblqty")).Text == "")
                //{
                //    Qtytotal += 0;
                //}
                //else
                //{
                //    Qtytotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lblqty")).Text);
                //}
                //if (((Label)e.Row.Cells[3].FindControl("lblqtyw")).Text == "")
                //{
                //    monSDwithOutPricetotal += 0;
                //}
                //else
                //{
                //    monSDwithOutPricetotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lblqtyw")).Text);
                //}
                //if (((Label)e.Row.Cells[4].FindControl("lblmonSDAmountw")).Text == "")
                //{
                //    monSDAmounttotal += 0;
                //}
                //else
                //{
                //    monSDAmounttotal += double.Parse(((Label)e.Row.Cells[4].FindControl("lblmonSDAmountw")).Text);
                //}
                //if (((Label)e.Row.Cells[5].FindControl("lblmonTotalSDAmounts")).Text == "")
                //{
                //    monTotalSDAmounttotal += 0;
                //}
                //else
                //{
                //    monTotalSDAmounttotal += double.Parse(((Label)e.Row.Cells[5].FindControl("lblmonTotalSDAmounts")).Text);
                //}
                //if (((Label)e.Row.Cells[6].FindControl("lblmonVatAmountss")).Text == "")
                //{
                //    monVatAmounttotal += 0;
                //}
                //else
                //{
                //    monVatAmounttotal += double.Parse(((Label)e.Row.Cells[6].FindControl("lblmonVatAmountss")).Text);
                //}
                //if (((Label)e.Row.Cells[7].FindControl("lblmonTotalss")).Text == "")
                //{
                //    monTotaltotal += 0;
                //}
                //else
                //{
                //    monTotaltotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblmonTotalss")).Text);
                //}
            }

        }


        protected void dgvMatrialAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

        }
        protected void dgvExcelOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
        protected void btnSaves_Click(object sender, EventArgs e)
        {


        }
      
        protected void btnSaves_Click1(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           

           // CreateSalesXml(intItemid.ToString(), strItemMatrial, TotalQty, Wastage, mrr,Rate, (decimal.Parse(TotalQty)*decimal.Parse(Rate)).ToString());


        }
        private void CreateSalesXml(string intItemid, string strItemMatrial, string TotalQty, string Wastage, string mrr,string Rate,string Value )
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, intItemid, strItemMatrial, TotalQty, Wastage, mrr,Rate,Value);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, intItemid, strItemMatrial, TotalQty, Wastage, mrr, Rate, Value);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
          
           // LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intItemid, string strItemMatrial, string TotalQty, string Wastage, string mrr, string Rate, string Value)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute IntItemid = doc.CreateAttribute("intItemid");
            IntItemid.Value = intItemid;
            XmlAttribute StrItemMatrial = doc.CreateAttribute("strItemMatrial");
            StrItemMatrial.Value = strItemMatrial;
            XmlAttribute totalQty = doc.CreateAttribute("TotalQty");
            totalQty.Value = TotalQty;
            XmlAttribute wastage = doc.CreateAttribute("Wastage");
            wastage.Value = Wastage;
            XmlAttribute Mrr = doc.CreateAttribute("mrr");
            Mrr.Value = mrr;
            XmlAttribute rate = doc.CreateAttribute("Rate");
            rate.Value = Rate;
            XmlAttribute value = doc.CreateAttribute("Value");
            value.Value = Value;

            node.Attributes.Append(IntItemid);
            node.Attributes.Append(StrItemMatrial);
            node.Attributes.Append(totalQty);
            node.Attributes.Append(wastage);
            node.Attributes.Append(Mrr);
            node.Attributes.Append(rate);
            node.Attributes.Append(value);

            return node;
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