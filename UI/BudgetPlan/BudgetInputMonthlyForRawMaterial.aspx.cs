using Budget_BLL.Budget;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.BudgetPlan
{
    public partial class BudgetInputMonthlyForRawMaterial : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, monthid, unitid, intmainheadcoaid, intvitmid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        Budget_Entry_BLL obj = new Budget_Entry_BLL();
        SalesOrderView objso = new SalesOrderView();
        string xmlString = "";
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike, regionname, areaname, linename;

      



        decimal totalcom, selectedtotalcom = 0;

        string budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, january, february
        , march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, budgetcatg = ""
        , julyPromotion, augestPromotion, septemberPromotion, octoberPromotion, novemberPromotion, decemberPromotion,
         januaryPromotion, februaryPromotion, marchPromotion, aprilPromotion, mayPromotion, junePromotion;


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
          
            xmlpath = Server.MapPath("~/BudgetPlan/Data/BudgetEntry_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "setupbaseBudget.xml");
            if (!IsPostBack)
            {

                ////---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                ////-----**----------//
                ///

               


            }
            else
            {

            }

        }
        #region ================ Generate XML and Others ==========        
        private void Createxml(string budgetyear, string intyear, string intmonthid, string itmid,string matqnt,string matamount, string stritemname )
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("SetupbaseBudgetRM");
                XmlNode addItem = CreateNode(doc, budgetyear,  intyear,  intmonthid,  itmid,  matqnt,  matamount,  stritemname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SetupbaseBudgetRM");
                XmlNode addItem = CreateNode(doc, budgetyear, intyear, intmonthid, itmid, matqnt, matamount, stritemname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string budgetyear, string intyear, string intmonthid, string itmid, string matqnt, string matamount, string stritemname)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Budgetyear = doc.CreateAttribute("budgetyear"); Budgetyear.Value = budgetyear;
            XmlAttribute Intyear = doc.CreateAttribute("intyear"); Intyear.Value = intyear;
            XmlAttribute Intmonthid = doc.CreateAttribute("intmonthid"); Intmonthid.Value = intmonthid;
            XmlAttribute Itmid = doc.CreateAttribute("itmid"); Itmid.Value = itmid;

            XmlAttribute Matqnt = doc.CreateAttribute("matqnt"); Matqnt.Value = matqnt;
            XmlAttribute Matamount = doc.CreateAttribute("matamount"); Matamount.Value = matamount;
            XmlAttribute Stritemname = doc.CreateAttribute("stritemname"); Stritemname.Value = stritemname;


            node.Attributes.Append(Budgetyear);
            node.Attributes.Append(Intyear);
            node.Attributes.Append(Intmonthid);
            node.Attributes.Append(Itmid);

            node.Attributes.Append(Matqnt);
            node.Attributes.Append(Matamount);
            node.Attributes.Append(Stritemname);


            return node;
        }
        #endregion

        #region =============== Insert Event Here =====================     

   

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                monthid = int.Parse(ddlBudgetMonth.SelectedValue.ToString());
                budgettype = ddlBudgetType.SelectedValue.ToString();
                unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                int yrid = int.Parse(ddlYear.SelectedValue.ToString());

                dt = obj.GetFGVsRawMaterialMonthly(yrid, unitid, monthid);
                if (dt.Rows.Count > 0)
                {
                    grdvFGVsRawMaterialMonthly.DataSource = dt;
                    grdvFGVsRawMaterialMonthly.DataBind();
                    //decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCashCommission1"));
                    //decimal totaldelvqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decTotalDelv1"));
                    //decimal totalcashdoqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decOnlyCashDOQnt1"));
                    //lblTotalcom.Visible = true;
                    //lbltotalcomamount.Text = Convert.ToString(txtTotalCommission);
                    //lblTotalcashdoqnt.Visible = true;
                    //lblcashdoqnt.Text = Convert.ToString(totalcashdoqnt);


                    //txtTotalCommission = 

                    //grdvFGVsRawMaterialMonthly.FooterRow.Cells[1].Text = "total";
                    //grdvFGVsRawMaterialMonthly.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    //grdvFGVsRawMaterialMonthly.FooterRow.Cells[5].Text = totalcashcom.ToString("N2");
                    //grdvFGVsRawMaterialMonthly.FooterRow.Cells[4].Text = totaldelvqnt.ToString("N2");
                    //grdvFGVsRawMaterialMonthly.FooterRow.Cells[3].Text = totalcashdoqnt.ToString("N2");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                monthid = int.Parse(ddlBudgetMonth.SelectedValue.ToString());
                budgettype = ddlBudgetType.SelectedValue.ToString();
                unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                int yrid = int.Parse(ddlYear.SelectedValue.ToString());

                if (grdvFGVsRawMaterialMonthly.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvFGVsRawMaterialMonthly.Rows.Count; index++)
                    {

                        if (((CheckBox)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            //budgetyear, intyear, intmonthid, itmid, matqnt, matamount, stritemname
                            string budgetyear = ((HiddenField)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("hdnintBudgetYear")).Value.ToString();
                            string intyear = ((HiddenField)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("hdnintYearid")).Value.ToString();
                            string intmonthid = ((HiddenField)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("hdnintMonth")).Value.ToString();
                            string itmid = ((HiddenField)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("hdnintMatID")).Value.ToString();

                            string matqnt = ((TextBox)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("txtdecMatQnt")).Text.ToString();
                            string matamount = ((TextBox)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("txtdecMatAmount")).Text.ToString();
                            string stritemname = ((HiddenField)grdvFGVsRawMaterialMonthly.Rows[index].FindControl("hdnstrItemName")).Value.ToString();

                           

                            Createxml(budgetyear, intyear, intmonthid, itmid, matqnt, matamount, stritemname);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                   
                  
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("SetupbaseBudgetRM");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<SetupbaseBudgetRM>" + xmlString + "</SetupbaseBudgetRM>";
                    string message = obj.InsertRawMaterialBudget(xmlString, enrol, unitid);
                    try { File.Delete(xmlpath); } catch { }
                    grdvFGVsRawMaterialMonthly.DataSource = null;
                    grdvFGVsRawMaterialMonthly.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);



                   

                  

                    #endregion ------------ Insertion End ----------------
               
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }
        }

        #endregion

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void grdvFGVsRawMaterialMonthly_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvFGVsRawMaterialMonthly_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    }
}