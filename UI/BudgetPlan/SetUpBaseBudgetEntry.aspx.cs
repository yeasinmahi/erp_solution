using Budget_BLL.Budget;
using SAD_BLL.Item;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        int enrol, reporttype, coaid, unitid, intmainheadcoaid,intvitmid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        Budget_Entry_BLL obj = new Budget_Entry_BLL();
        SalesOrderView objso = new SalesOrderView();
        string xmlString = "";
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike,regionname, areaname, linename;
        decimal totalcom, selectedtotalcom = 0;

        string budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, january, february
        , march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, budgetcatg = ""
        , julyPromotion, augestPromotion, septemberPromotion, octoberPromotion, novemberPromotion, decemberPromotion,
         januaryPromotion, februaryPromotion, marchPromotion, aprilPromotion, mayPromotion, junePromotion;


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

                txtjan.Text = "0.0";
                txtFeb.Text = "0.0";
                txtMarch.Text = "0.0";
                txtApril.Text = "0.0";
                txtMay.Text = "0.0";
                txtJune.Text = "0.0";
                txtJuly.Text = "0.0";
                txtAugest.Text = "0.0";
                txtSpetmeber.Text = "0.0";
                txtOctober.Text = "0.0";
                txtNovember.Text = "0.0";
                txtDecember.Text = "0.0";
                txtJulyPromo.Text = "0.0";
              
             
                txtAugestPromo.Text = "0.0";
                txtSeptemberPromo.Text = "0.0";
                txtOctoberPromo.Text = "0.0";
                txtNovemberPromo.Text = "0.0";
                txtDecemberPromo.Text = "0.0";
                txtJanuaryPromo.Text = "0.0";
                txtFebruaryPromo.Text = "0.0";
                txtMarchPromo.Text = "0.0";
                txtAprilPromo.Text = "0.0";
                txtMayPromo.Text = "0.0";
                txtJunePromo.Text = "0.0";



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
            clear();
            int typeid=int.Parse(ddlBudgetType.SelectedValue.ToString());
            if(typeid==3 || typeid == 5)
            {
                lbltxboxallow();
            }


            
            


        }
        private void clear()
        {
            txtJuly.Text = "0.0"; txtAugest.Text = "0.0"; txtSpetmeber.Text = "0.0"; txtOctober.Text = "0.0"; txtNovember.Text = "0.0"; ; txtDecember.Text = "0.0";
            txtjan.Text = "0.0"; txtFeb.Text = "0.0"; txtMarch.Text = "0.0"; txtApril.Text = "0.0"; txtMay.Text = "0.0"; ; txtJune.Text = "0.0";
            //txtProduct.Text = "";
            txtBudgetQnt.Text = "0.0"; txtTotal.Text = "0.0";
            txtProductRate.Text = "0.0";
            txtJulyPromo.Text = "0.0"; txtAugestPromo.Text = "0.0"; txtSeptemberPromo.Text = "0.0"; txtOctoberPromo.Text = "0.0"; txtNovemberPromo.Text = "0.0"; ; txtDecemberPromo.Text = "0.0";
            txtJanuaryPromo.Text = "0.0"; txtFebruaryPromo.Text = "0.0"; txtMarchPromo.Text = "0.0"; txtAprilPromo.Text = "0.0"; txtMayPromo.Text = "0.0"; ; txtJunePromo.Text = "0.0";


        }

        private void lbltxboxallow()
        {
            txtJulyPromo.Visible =false; txtAugestPromo.Visible = false; txtSeptemberPromo.Visible = false; txtOctoberPromo.Visible = false; txtNovemberPromo.Visible = false; ; txtDecemberPromo.Visible = false;
            txtJanuaryPromo.Visible = false; txtFebruaryPromo.Visible = false; txtMarchPromo.Visible = false; txtAprilPromo.Visible = false; txtMayPromo.Visible = false; ; txtJunePromo.Visible = false;
            lblJulyProm.Visible = false; lblAugprom.Visible = false; lblSepprom.Visible = false; lblOctprom.Visible = false; lblNovprom.Visible = false; lblDecprom.Visible = false; lblJanuaryprom.Visible = false;
            lblFebprom.Visible = false; lblMarchprom.Visible = false; lblAprilprom.Visible = false; lblMayprom.Visible = false; lblJuneprom.Visible = false;
            txtQntPromo.Visible = false; txtTotalamntPromo.Visible = false; lblPromQnt.Visible = false;lblPromTotal.Visible = false;
            ddlRegion.Enabled = false; drdlArea.Enabled = false; drdlPrdouctLine.Enabled = false;
            txtProductRate.Text = "1";
          
           
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
                if (budgettype.Length <= 0) { budgettype = "0.0"; }

                if (int.Parse(budgettype)==3 || int.Parse(budgettype) == 5)
                {
                    txtProductRate.Enabled = true;
                    txtProductRate.Text = "1";
                }

                itemid = txtProduct.Text;
                arrayKey = itemid.Split(delimiterChars);
                itemid = arrayKey[1].ToString();
                prdname = arrayKey[0].ToString();

                if (budgettype == "4")
                {
                    dt = objso.GetFGItemvsInvItem(int.Parse(itemid));
                    string invitm= dt.Rows[0]["intinvitmid"].ToString();
                    itemid = invitm;
                }
                else
                {
                    txtProductRate.Text = "0.0";
                }





                salesofficeid = ddlSlaesOffice.SelectedValue.ToString();
                regionid = ddlRegion.SelectedValue.ToString();
                areaid = drdlArea.SelectedValue.ToString();
                prdlineid = drdlPrdouctLine.SelectedValue.ToString();
                //prdlineid = "1";
                costcneteid = ddlCostCenter.SelectedValue.ToString();
                yrid = ddlYear.SelectedValue.ToString();
              


                july = txtJuly.Text;
                if (july.Length <= 0) { july = "0.0"; }

                augest = txtAugest.Text;
                if (augest.Length <= 0) { augest = "0.0"; }

                september = txtSpetmeber.Text;
                if (september.Length <= 0) { september = "0.0"; }

                october = txtOctober.Text;
                if (october.Length <= 0) { october = "0.0"; }

                november = txtNovember.Text;
                if (november.Length <= 0) { november = "0.0"; }

                december = txtDecember.Text;
                if (december.Length <= 0) { december = "0.0"; }
                //budgyr = ddlYear.SelectedItem.Text.ToString();
                string inputString = ddlYear.SelectedItem.Text.ToString();
                budgyr = Regex.Replace(inputString, @"[^0-9]", "");

                january = txtjan.Text;
                if (january.Length <= 0) { january = "0.0"; }

                february = txtFeb.Text;
                if (february.Length <= 0) { february = "0.0"; }

                march = txtMarch.Text;
                if (march.Length <= 0) { march = "0.0"; }

                april = txtApril.Text;
                if (april.Length <= 0) { april = "0.0"; }

                may = txtMay.Text;
                if (may.Length <= 0) { may = "0.0"; }

                june = txtJune.Text;
                if (june.Length <= 0) { june = "0.0"; }

               

                string Productprice = txtProductRate.Text;
                if (Productprice.Length <= 0) { Productprice = "0.0"; }

                string totqnt = txtBudgetQnt.Text;
                if (totqnt.Length <= 0) { totqnt = "0.0"; }

                string totAmount = txtTotal.Text;
                if (totAmount.Length <= 0) { totAmount = "0.0"; }

                //regionname ,string areaname,string linename
                regionname = ddlRegion.SelectedItem.Text.ToString();
                areaname = drdlArea.SelectedItem.Text.ToString();
                linename = drdlPrdouctLine.SelectedItem.Text.ToString();


                julyPromotion = txtJulyPromo.Text;
                if (julyPromotion.Length <= 0) { julyPromotion = "0.0"; }

                augestPromotion = txtAugestPromo.Text;
                if (augestPromotion.Length <= 0) { augestPromotion = "0.0"; }

                septemberPromotion = txtSeptemberPromo.Text;
                if (septemberPromotion.Length <= 0) { septemberPromotion = "0.0"; }

                octoberPromotion = txtOctoberPromo.Text;
                if (octoberPromotion.Length <= 0) { octoberPromotion = "0.0"; }

                novemberPromotion = txtNovemberPromo.Text;
                if (novemberPromotion.Length <= 0) { novemberPromotion = "0.0"; }

                decemberPromotion = txtDecemberPromo.Text;
                if (decemberPromotion.Length <= 0) { decemberPromotion = "0.0"; }
                //budgyr = ddlYear.SelectedItem.Text.ToString();

                januaryPromotion = txtJanuaryPromo.Text;
                if (januaryPromotion.Length <= 0) { januaryPromotion = "0.0"; }

                februaryPromotion = txtFebruaryPromo.Text;
                if (februaryPromotion.Length <= 0) { februaryPromotion = "0.0"; }

                marchPromotion = txtMarchPromo.Text;
                if (marchPromotion.Length <= 0) { marchPromotion = "0.0"; }

                aprilPromotion = txtAprilPromo.Text;
                if (aprilPromotion.Length <= 0) { aprilPromotion = "0.0"; }

                mayPromotion = txtMayPromo.Text;
                if (mayPromotion.Length <= 0) { mayPromotion = "0.0"; }

                junePromotion = txtJunePromo.Text;
                if (junePromotion.Length <= 0) { junePromotion = "0.0"; }

                string totqntProm = txtQntPromo.Text;
                if (totqntProm.Length <= 0) { totqntProm = "0.0"; }

                string totAmountProm = txtTotalamntPromo.Text;
                if (totAmountProm.Length <= 0) { totAmountProm = "0.0"; }



                Createxml(budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, july, augest, september, october, november, december,
                january, february, march, april, may, june,  prdname, budgyr, Productprice, totqnt, totAmount,regionname,areaname,linename
                , julyPromotion, augestPromotion, septemberPromotion, octoberPromotion, novemberPromotion, decemberPromotion,
                januaryPromotion, februaryPromotion, marchPromotion, aprilPromotion, mayPromotion, junePromotion);
                clear();

            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
            //}




        }
        #region ================ Generate XML and Others ==========        
        private void Createxml(string budgettype, string itemid, string salesofficeid, string regionid, string areaid, string prdlineid, string costcneteid, string yrid,
        string july, string augest, string september, string october, string november, string december,
        string january, string february, string march, string april, string may, string june
            , string prdname, string budgyr, string productprice, string totqnt, string totamount, string regionname, string areaname, string linename
        , string julyPromotion, string augestPromotion, string septemberPromotion, string octoberPromotion, string novemberPromotion, string decemberPromotion,
        string januaryPromotion, string februaryPromotion, string marchPromotion, string aprilPromotion, string mayPromotion, string junePromotion)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("SetupbaseBudget");
                XmlNode addItem = CreateNode(doc, budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, july, augest, september, october, november, december,
                january, february, march, april, may, june,  prdname, budgyr, productprice,  totqnt,  totamount,  regionname,  areaname,  linename
                , julyPromotion, augestPromotion, septemberPromotion, octoberPromotion, novemberPromotion, decemberPromotion,
         januaryPromotion, februaryPromotion, marchPromotion, aprilPromotion, mayPromotion, junePromotion);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SetupbaseBudget");
                XmlNode addItem = CreateNode(doc, budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, july, augest, september, october, november, december,
                january, february, march, april, may, june, prdname, budgyr, productprice, totqnt, totamount, regionname, areaname, linename
                , julyPromotion, augestPromotion, septemberPromotion, octoberPromotion, novemberPromotion, decemberPromotion,
         januaryPromotion, februaryPromotion, marchPromotion, aprilPromotion, mayPromotion, junePromotion);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadGridwithXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string budgettype, string itemid, string salesofficeid, string regionid, string areaid, string prdlineid, string costcneteid, string yrid,
        string july, string augest , string september, string october, string november, string december,
        string january, string february, string march, string april, string may, string june, string prdname, string budgyr,string productprice, string totqnt, string totamount, string regionname, string areaname, string linename
        , string julyPromotion, string augestPromotion, string septemberPromotion, string octoberPromotion, string novemberPromotion, string decemberPromotion,
        string januaryPromotion, string februaryPromotion, string marchPromotion, string aprilPromotion, string mayPromotion, string junePromotion


            )
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
          
            XmlAttribute July = doc.CreateAttribute("july"); July.Value = july;
            XmlAttribute Augest = doc.CreateAttribute("augest"); Augest.Value = augest;
            XmlAttribute September = doc.CreateAttribute("september"); September.Value = september;
            XmlAttribute October = doc.CreateAttribute("october"); October.Value = october;
            XmlAttribute November = doc.CreateAttribute("november"); November.Value = november;
            XmlAttribute December = doc.CreateAttribute("december"); December.Value = december;
            XmlAttribute January = doc.CreateAttribute("january"); January.Value = january;
            XmlAttribute February = doc.CreateAttribute("february"); February.Value = february;
            XmlAttribute March = doc.CreateAttribute("march"); March.Value = march;
            XmlAttribute April = doc.CreateAttribute("april"); April.Value = april;
            XmlAttribute May = doc.CreateAttribute("may"); May.Value = may;
            XmlAttribute June = doc.CreateAttribute("june"); June.Value = june;

            XmlAttribute Prdname = doc.CreateAttribute("prdname"); Prdname.Value = prdname;
            XmlAttribute Budgyr = doc.CreateAttribute("budgyr"); Budgyr.Value = budgyr;
            XmlAttribute Productprice = doc.CreateAttribute("productprice"); Productprice.Value = productprice;
            XmlAttribute Totqnt = doc.CreateAttribute("totqnt"); Totqnt.Value = totqnt;
            XmlAttribute Totamount = doc.CreateAttribute("totamount"); Totamount.Value = totamount;

            XmlAttribute Regionname = doc.CreateAttribute("regionname"); Regionname.Value = regionname;
            XmlAttribute Areaname = doc.CreateAttribute("areaname"); Areaname.Value = areaname;
            XmlAttribute Linename = doc.CreateAttribute("linename"); Linename.Value = linename;


            XmlAttribute JulyPromotion = doc.CreateAttribute("julyPromotion"); JulyPromotion.Value = julyPromotion;
            XmlAttribute AugestPromotion = doc.CreateAttribute("augestPromotion"); AugestPromotion.Value = augestPromotion;
            XmlAttribute SeptemberPromotion = doc.CreateAttribute("septemberPromotion"); SeptemberPromotion.Value = septemberPromotion;
            XmlAttribute OctoberPromotion = doc.CreateAttribute("octoberPromotion"); OctoberPromotion.Value = octoberPromotion;
            XmlAttribute NovemberPromotion = doc.CreateAttribute("novemberPromotion"); NovemberPromotion.Value = novemberPromotion;
            XmlAttribute DecemberPromotion = doc.CreateAttribute("decemberPromotion"); DecemberPromotion.Value = decemberPromotion;
            XmlAttribute JanuaryPromotion = doc.CreateAttribute("januaryPromotion"); JanuaryPromotion.Value = januaryPromotion;
            XmlAttribute FebruaryPromotion = doc.CreateAttribute("februaryPromotion"); FebruaryPromotion.Value = februaryPromotion;
            XmlAttribute MarchPromotion = doc.CreateAttribute("marchPromotion"); MarchPromotion.Value = marchPromotion;
            XmlAttribute AprilPromotion = doc.CreateAttribute("aprilPromotion"); AprilPromotion.Value = aprilPromotion;
            XmlAttribute MayPromotion = doc.CreateAttribute("mayPromotion"); MayPromotion.Value = mayPromotion;
            XmlAttribute JunePromotion = doc.CreateAttribute("junePromotion"); JunePromotion.Value = junePromotion;



            node.Attributes.Append(Budgettype);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Salesofficeid);
            node.Attributes.Append(Regionid);

            node.Attributes.Append(Areaid);
            node.Attributes.Append(Prdlineid);
            node.Attributes.Append(Costcneteid);
            node.Attributes.Append(Yrid);
            node.Attributes.Append(July);
            node.Attributes.Append(Augest);
            node.Attributes.Append(September);
            node.Attributes.Append(October);
            node.Attributes.Append(November);
            node.Attributes.Append(December);
            node.Attributes.Append(January);
            node.Attributes.Append(February);
            node.Attributes.Append(March);
            node.Attributes.Append(April);
            node.Attributes.Append(May);
            node.Attributes.Append(June);
           
            node.Attributes.Append(Prdname);
            node.Attributes.Append(Budgyr);
            node.Attributes.Append(Productprice);
            node.Attributes.Append(Totqnt);
            node.Attributes.Append(Totamount);

            node.Attributes.Append(Regionname);
            node.Attributes.Append(Areaname);
            node.Attributes.Append(Linename);


            node.Attributes.Append(JulyPromotion);
            node.Attributes.Append(AugestPromotion);
            node.Attributes.Append(SeptemberPromotion);
            node.Attributes.Append(OctoberPromotion);
            node.Attributes.Append(NovemberPromotion);
            node.Attributes.Append(DecemberPromotion);
            node.Attributes.Append(JanuaryPromotion);
            node.Attributes.Append(FebruaryPromotion);
            node.Attributes.Append(MarchPromotion);
            node.Attributes.Append(AprilPromotion);
            node.Attributes.Append(MayPromotion);
            node.Attributes.Append(JunePromotion);



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
                string inputString = ddlYear.SelectedItem.Text.ToString();
                budgyr = Regex.Replace(inputString, @"[^0-9]", "");
                if (budgettype==4)
                {
                    dt = obj.GetBudgetProductInfo(prdid);
                    txtProductRate.Text = dt.Rows[0]["monprice"].ToString();
                }

                else if (budgettype == 3)
                {
                    dt = obj.GetBudgetFGQntvsMaterialQnt(int.Parse(budgyr),prdid);
                    txtJuly.Text = dt.Rows[0]["numMatQty"].ToString();
                    txtAugest.Text = dt.Rows[1]["numMatQty"].ToString();
                    txtSpetmeber.Text = dt.Rows[2]["numMatQty"].ToString();
                    txtOctober.Text = dt.Rows[3]["numMatQty"].ToString();
                    txtNovember.Text = dt.Rows[4]["numMatQty"].ToString();
                    txtDecember.Text = dt.Rows[5]["numMatQty"].ToString();
                    txtjan.Text = dt.Rows[6]["numMatQty"].ToString();
                    txtFeb.Text = dt.Rows[7]["numMatQty"].ToString();
                    txtMarch.Text = dt.Rows[8]["numMatQty"].ToString();
                    txtApril.Text = dt.Rows[9]["numMatQty"].ToString();
                    txtMay.Text = dt.Rows[10]["numMatQty"].ToString();
                    txtJune.Text = dt.Rows[11]["numMatQty"].ToString();

                }



                else
                {
                    txtProductRate.Text = "0.0";
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
