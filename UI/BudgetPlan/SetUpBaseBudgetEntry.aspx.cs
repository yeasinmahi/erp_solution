using Budget_BLL.Budget;
using SAD_BLL.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.BudgetPlan
{
    public partial class SetUpBaseBudgetEntry : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        Budget_Entry_BLL obj = new Budget_Entry_BLL();
        string xmlString = "";
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;
        decimal totalcom, selectedtotalcom = 0;

        string budgettype,  itemid,  salesofficeid,  regionid,  areaid,  prdlineid,  costcneteid,  yrid, january,  february
        ,  march,  april,  may,  june,  july,  augest ,  september,  october,  november,  december, prdname, budgyr, budgetcatg = "";
        
        #endregion
        

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            xmlpath = Server.MapPath("~/BudgetPlan/Data/BudgetEntry_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "setupbaseBudget.xml");
            if (!IsPostBack)
            {

                ////---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                ////-----**----------//
                ///

                txtjan.Text = "0";
                txtFeb.Text = "0";
                txtMarch.Text = "0";
                txtApril.Text = "0";
                txtMay.Text = "0";
                txtJune.Text = "0";
                txtJuly.Text = "0";
                txtAugest.Text = "0";
                txtSpetmeber.Text = "0";
                txtOctober.Text = "0";
                txtNovember.Text = "0";
                txtDecember.Text = "0";


            }
            else
            {

            }


            //LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();doc.Load(xmlpath);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("SetupbaseBudget");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SetupbaseBudget>" + xmlString + "</SetupbaseBudget>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvSetupBaseBudget.DataSource = ds; }
                else { grdvSetupBaseBudget.DataSource = ""; }
                grdvSetupBaseBudget.DataBind();




                //XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                //XmlNode xlnd = doc.SelectSingleNode("Requisition");
                //xmlString = xlnd.InnerXml;
                //xmlString = "<Requisition>" + xmlString + "</Requisition>";
                //StringReader sr = new StringReader(xmlString);
                //DataSet ds = new DataSet(); ds.ReadXml(sr);
                //if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; }
                //dgv.DataBind();








            }
            catch { }
        }
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void LoadGrid()
        {
            try
            {
                enrol = 1272;
                xmlString = "";
                unitid = 4;
                string fd = "2020-12-31";
                string td = "2020-12-31";

          

                string msg = obj.InsertOPSetupBaseBudget(xmlString, enrol, unitid);
                grdvSetupBaseBudget.DataSource = dt;
                grdvSetupBaseBudget.DataBind();
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, Common.TosterType.Error);
            }
        }









        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {

            //return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            return ItemSt.GetBudgetProductItem(HttpContext.Current.Session["budgetcatg"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);

        }








        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            

        }
        protected void ddlBudgetType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Session["budgetcatg"] = ddlBudgetType.SelectedValue.ToString();
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void btnADD_Click(object sender, EventArgs e)
        {

            //budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid,
            //january, february, march, april, may, june, july, augest, september, october, november, december

            if (hdnconfirm.Value == "1")
            {
                budgettype = ddlBudgetType.SelectedValue.ToString();
                if (budgettype.Length <= 0) { budgettype = "0"; }
                itemid = txtProduct.Text;
                arrayKey = itemid.Split(delimiterChars);
                itemid = arrayKey[1].ToString();
                prdname = arrayKey[0].ToString();

                salesofficeid = ddlSlaesOffice.SelectedValue.ToString();
                regionid = ddlRegion.SelectedValue.ToString();
                areaid = drdlArea.SelectedValue.ToString();
                prdlineid = drdlPrdouctLine.SelectedValue.ToString();
                prdlineid = "1";
                costcneteid = ddlCostCenter.SelectedValue.ToString();
                yrid = ddlYear.SelectedValue.ToString();

                january = txtjan.Text;
                if (january.Length <= 0) { january = "0"; }

                february = txtFeb.Text;
                if (february.Length <= 0) { february = "0"; }

                march = txtMarch.Text;
                if (march.Length <= 0) { march = "0"; }

                april = txtApril.Text;
                if (april.Length <= 0) { april = "0"; }

                may = txtMay.Text;
                if (may.Length <= 0) { may = "0"; }

                june = txtJune.Text;
                if (june.Length <= 0) { june = "0"; }

                july = txtJuly.Text;
                if (july.Length <= 0) { july = "0"; }

                augest = txtAugest.Text;
                if (augest.Length <= 0) { augest = "0"; }

                september = txtSpetmeber.Text;
                if (september.Length <= 0) { september = "0"; }

                october = txtOctober.Text;
                if (october.Length <= 0) { october = "0"; }

                november = txtNovember.Text;
                if (november.Length <= 0) { november = "0"; }

                december = txtDecember.Text;
                if (december.Length <= 0) { december = "0"; }
                budgyr = ddlYear.SelectedItem.Text.ToString();

                string Productprice = txtProductRate.Text;
                if (Productprice.Length <= 0) { Productprice = "0"; }

                string totqnt = txtBudgetQnt.Text;
                if (totqnt.Length <= 0) { totqnt = "0"; }

                string totAmount = txtTotal.Text;
                if (totAmount.Length <= 0) { totAmount = "0"; }


                //budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid,
                //january, february, march, april, may, june, july, augest, september, october, november, december

                Createxml(budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid,
                january, february, march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, Productprice, totqnt, totAmount);

            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
            //}




        }
        #region ================ Generate XML and Others ==========        
        private void Createxml(string budgettype, string itemid, string salesofficeid, string regionid, string areaid, string prdlineid, string costcneteid, string yrid,
           string january, string february, string march, string april, string may, string june, string july, string augest, string september, string october, string november, string december
            , string prdname, string budgyr,string productprice,string totqnt,string totamount)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("SetupbaseBudget");
                XmlNode addItem = CreateNode(doc, budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid,
                january, february, march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, productprice,  totqnt,  totamount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SetupbaseBudget");
                XmlNode addItem = CreateNode(doc, budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid,
                january, february, march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, productprice,  totqnt,  totamount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadGridwithXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string budgettype, string itemid, string salesofficeid, string regionid, string areaid, string prdlineid, string costcneteid, string yrid,
        string january, string february, string march, string april, string may, string june, string july, string augest
        , string september, string october, string november, string december, string prdname, string budgyr,string productprice, string totqnt, string totamount)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Budgettype = doc.CreateAttribute("budgettype"); Budgettype.Value = budgettype;
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Salesofficeid = doc.CreateAttribute("salesofficeid"); Salesofficeid.Value = salesofficeid;
            XmlAttribute Regionid = doc.CreateAttribute("regionid"); Regionid.Value = regionid;
            XmlAttribute Areaid = doc.CreateAttribute("areaid"); Areaid.Value = areaid;
            XmlAttribute Prdlineid = doc.CreateAttribute("prdlineid"); Prdlineid.Value = prdlineid;
            XmlAttribute Costcneteid = doc.CreateAttribute("costcneteid"); Costcneteid.Value = costcneteid;
            XmlAttribute Yrid = doc.CreateAttribute("yrid"); Yrid.Value = yrid;
            XmlAttribute January = doc.CreateAttribute("january"); January.Value = january;
            XmlAttribute February = doc.CreateAttribute("february"); February.Value = february;
            XmlAttribute March = doc.CreateAttribute("march"); March.Value = march;
            XmlAttribute April = doc.CreateAttribute("april"); April.Value = april;
            XmlAttribute May = doc.CreateAttribute("may"); May.Value = may;
            XmlAttribute June = doc.CreateAttribute("june"); June.Value = june;
            XmlAttribute July = doc.CreateAttribute("july"); July.Value = july;
            XmlAttribute Augest = doc.CreateAttribute("augest"); Augest.Value = augest;
            XmlAttribute September = doc.CreateAttribute("september"); September.Value = september;
            XmlAttribute October = doc.CreateAttribute("october"); October.Value = october;
            XmlAttribute November = doc.CreateAttribute("november"); November.Value = november;
            XmlAttribute December = doc.CreateAttribute("december"); December.Value = december;
            XmlAttribute Prdname = doc.CreateAttribute("prdname"); Prdname.Value = prdname;
            XmlAttribute Budgyr = doc.CreateAttribute("budgyr"); Budgyr.Value = budgyr;
            XmlAttribute Productprice = doc.CreateAttribute("productprice"); Productprice.Value = productprice;
            XmlAttribute Totqnt = doc.CreateAttribute("totqnt"); Totqnt.Value = totqnt;
            XmlAttribute Totamount = doc.CreateAttribute("totamount"); Totamount.Value = totamount;

            node.Attributes.Append(Budgettype);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Salesofficeid);
            node.Attributes.Append(Regionid);

            node.Attributes.Append(Areaid);
            node.Attributes.Append(Prdlineid);
            node.Attributes.Append(Costcneteid);
            node.Attributes.Append(Yrid);

            node.Attributes.Append(January);
            node.Attributes.Append(February);
            node.Attributes.Append(March);
            node.Attributes.Append(April);

            node.Attributes.Append(May);
            node.Attributes.Append(June);
            node.Attributes.Append(July);
            node.Attributes.Append(Augest);

            node.Attributes.Append(September);
            node.Attributes.Append(October);
            node.Attributes.Append(November);
            node.Attributes.Append(December);
            node.Attributes.Append(Prdname);
            node.Attributes.Append(Budgyr);
            node.Attributes.Append(Productprice);
            node.Attributes.Append(Totqnt);
            node.Attributes.Append(Totamount);

            return node;
        }
        #endregion

        protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtProduct.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnProduct.Value = temp[temp.Length - 1];
                hdnProductText.Value = temp[0];
                int prdid = int.Parse(hdnProduct.Value);
                int budgettype = int.Parse(Session["budgetcatg"].ToString());

                if(budgettype==4)
                {
                    dt = obj.GetBudgetProductInfo(prdid);
                    txtProductRate.Text = dt.Rows[0]["monprice"].ToString();
                }
                else
                {
                    txtProductRate.Text = "0";
                }

            }
            else
            {
                hdnProduct.Value = "";
            }
            //LoadGrid();

        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCostCenter_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void grdvSetupBaseBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvSetupBaseBudget.DataSource;
                dsGrid.Tables[0].Rows[grdvSetupBaseBudget.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)grdvSetupBaseBudget.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpath); grdvSetupBaseBudget.DataSource = ""; grdvSetupBaseBudget.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {

                try
                {

                    if (grdvSetupBaseBudget.Rows.Count > 0)
                    {
                        #region ------------ Insert into dataBase -----------


                        string strSearchKey = txtProduct.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        string code = arrayKey[1].ToString();
                        string strCustname = strSearchKey;
                        int enroll = int.Parse(code.ToString());


                        int unit = Convert.ToInt32(ddlUnit.SelectedValue.ToString());

                        System.Xml.XmlDocument doc = new XmlDocument();

                        //try
                        //{
                        doc.Load(xmlpath);
                        XmlNode dSftTm = doc.SelectSingleNode("SetupbaseBudget");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<SetupbaseBudget>" + xmlString + "</SetupbaseBudget>";
                        string message = obj.InsertOPSetupBaseBudget(xmlString, enrol, unit);
                        File.Delete(xmlpath);
                        grdvSetupBaseBudget.DataSource = null;
                        grdvSetupBaseBudget.DataBind();

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }


            //}

            //    catch (Exception ex)
            //    {


            //    }



        }
    }

    }
