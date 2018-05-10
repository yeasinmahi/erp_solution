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

namespace UI.SAD.ExcelChallan
{
    public partial class frmItemMushok1 : BasePage
    {
        string strHscode,Rate, xmlString, values, filePathForXML, strItemMatrial,TotalQty,Wastage,WholeSales,mrr, vno;bool ysntxt;
        int intItemid, intVatItemid, empid,INTBOMID,intMatrialid,VatCount;
        DataTable dt;Decimal SDCharge, SDPercent, VATPercent, SCPercent;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        ExcelDataBLL objExcel = new ExcelDataBLL();
        Mushok11 objMush = new Mushok11();
        DateTime dtedate;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Vat/Data/PriceDeclare" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                dt = objMush.getMType();
                ddlMType.DataTextField = "strName";
                ddlMType.DataValueField = "intMusokTypeID";
                ddlMType.DataSource = dt;
                ddlMType.DataBind();
                dt.Clear();
 
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
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            dt = objMush.getBridgeCheck(intVatItemid);
            
            if (txtSDCharge.Text == "")
            { SDCharge = 0; } else { SDCharge = decimal.Parse(txtSDCharge.Text); }
            if (txtSDPer.Text== "")
            { SDPercent = 0; } else { SDPercent = decimal.Parse(txtSDPer.Text); }
            if (txtVatper.Text == "")
            { VATPercent = 0; } else { VATPercent = decimal.Parse(txtVatper.Text); }            
            if (txtVatper.Text == "")
            { SCPercent = 0; }  else { SCPercent = decimal.Parse(txtSurCharge.Text); }


            if (dt.Rows.Count==0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please bridge the product first');", true);
            }
            else
            {
                objMush.InsertVatSD(intVatItemid, SDCharge, SDPercent, VATPercent, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dtedate, int.Parse(ddlMType.SelectedValue.ToString()), int.Parse(hdnAccno.Value), SCPercent);
            }
            dt = objMush.GETMUSOKbom(intVatItemid);
            INTBOMID = int.Parse(dt.Rows[0]["INTBOMID"].ToString());
            if (dgvMatrialAdd.Rows.Count > 0)
            {

                for (int index = 0; index < dgvMatrialAdd.Rows.Count; index++)
                {
                    if (((CheckBox)dgvMatrialAdd.Rows[index].Cells[0].Controls[0]).Checked)
                    {
                        intItemid = int.Parse(((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        intMatrialid = int.Parse(((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        TotalQty = (((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        Wastage = (((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        values =(((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        intItemid = int.Parse(((Label)dgvMatrialAdd.Rows[index].FindControl("lblCustid")).Text.ToString());
                        objMush.insertBomConfig(intItemid, intMatrialid, TotalQty, Wastage, values, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()),INTBOMID,int.Parse(hdnAccno.Value));
                    }
                }
               
              
            }
            if (int.Parse(ddlMType.SelectedValue) == 1)
            {
                objMush.getType1(SDCharge, SDPercent, VATPercent, WholeSales, mrr, SCPercent, intVatItemid, int.Parse(hdnAccno.Value));

            }else if (int.Parse(ddlMType.SelectedValue) == 2)
            { objMush.getType2(SDCharge, SDPercent, VATPercent, WholeSales, intVatItemid, int.Parse(hdnAccno.Value)); }
            else if (int.Parse(ddlMType.SelectedValue) == 3) {
                objMush.getType4(SDCharge, intVatItemid, int.Parse(hdnAccno.Value));
            }
            dt = objMush.getMushcount(intVatItemid);
            VatCount =int.Parse(dt.Rows[0]["intBOMCount"].ToString());
            if (int.Parse(hdnysnFactory.Value) == 1)
            {
                objMush.getMushokDepot(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), intVatItemid, int.Parse(ddlMType.SelectedValue), VatCount);

            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if(txtItemMatrial.Text!="")
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
                intVatItemid = int.Parse(arrayKeyItem[1].ToString());
                dt = objMush.getPriceDetails(intVatItemid,int.Parse(ddlMType.SelectedValue),DateTime.Now);               
                dgvMatrialItem.DataSource = dt;
                dgvMatrialItem.DataBind();

                dgvMatrialItem.Visible = true;
                dgvMatrialAdd.Visible = false;
            }
        }
        protected double PendingmonValue = 0;
        protected void dgvMatrialItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[6].FindControl("lblqty")).Text == "")
                {
                    PendingmonValue += 0;
                }
                else
                {
                    PendingmonValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblqty")).Text);
                }
                txtSDCharge.Text = PendingmonValue.ToString();
            }

        }
        protected double totalvalue = 0;
        protected void dgvMatrialAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[5].FindControl("lblValue")).Text == "")
                {
                    totalvalue += 0;
                }
                else
                {
                    totalvalue += double.Parse(((Label)e.Row.Cells[5].FindControl("lblValue")).Text);
                }
                txtSDCharge.Text = totalvalue.ToString();
            }

        }
        protected void btnSaves_Click(object sender, EventArgs e)
        {


        }
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                dgvMatrialAdd.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvMatrialAdd.DataSource;
                dsGrid.Tables[0].Rows[dgvMatrialAdd.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvMatrialAdd.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvMatrialAdd.DataSource = ""; dgvMatrialAdd.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected void btnSaves_Click1(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatMatrialname.Text.Split(delimiterCharss);
            intItemid = int.Parse(arrayKeyItem[1].ToString());
            strItemMatrial = (arrayKeyItem[0].ToString());
            TotalQty = txtTotalQty.Text;
            WholeSales = txtwholeSales.Text;
            Wastage = txtWastage.Text;
            mrr = txtMRR.Text;
            Rate = txtRate.Text;

            CreateSalesXml(intItemid.ToString(), strItemMatrial, TotalQty, Wastage, mrr,Rate, (decimal.Parse(TotalQty)*decimal.Parse(Rate)).ToString());


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
          
            LoadGridwithXml();
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
                if (ds.Tables[0].Rows.Count > 0) { dgvMatrialAdd.DataSource = ds; } else { dgvMatrialAdd.DataSource = ""; }
                dgvMatrialAdd.DataBind();
                dgvMatrialItem.Visible = false;
                dgvMatrialAdd.Visible = true;
            }
            catch { dgvMatrialItem.DataSource = ""; dgvMatrialItem.DataBind(); }
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