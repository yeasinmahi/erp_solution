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
    public partial class BudgetInfoModification : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid,   itmid, actiontype,  bgttype;
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        Budget_Entry_BLL obj = new Budget_Entry_BLL();
        string xmlString = "";
        bool ysnChecked;

     

        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;

     

        decimal totalcom, selectedtotalcom = 0;

        string budgettype, itemid, salesofficeid, regionid, areaid, prdlineid, costcneteid, yrid, january, february
        , march, april, may, june, july, augest, september, october, november, december, prdname, budgyr, budgetcatg = "";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            xmlpath = Server.MapPath("~/BudgetPlan/Data/BudgetEntry_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "budgetModification.xml");
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
        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {

            //return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            return ItemSt.GetBudgetProductItem(HttpContext.Current.Session["budgetcatg"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);

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
               
            }
            else
            {
                hdnProduct.Value = "";
            }
        }


        protected void ddlBudgetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["budgetcatg"] = ddlBudgetType.SelectedValue.ToString();
        }


        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                enrol = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int unitid = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                bgttype = Convert.ToInt32(ddlBudgetType.SelectedValue.ToString());
                actiontype = int.Parse(ddlActionType.SelectedValue.ToString());
                if (txtProduct.Text.Length > 2)
                {
                    string strSearchKey = txtProduct.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    itmid = int.Parse(code);
                }
                else
                {
                    itmid = 0;
                }



                dt = obj.GetBudgetModificationInfo(xmlString, enrol, unitid, dtFromDate, dtToDate, bgttype, itmid, actiontype);
                if (dt.Rows.Count > 0)
                {
                    grdvBudgetInfoModification.DataSource = dt;
                    grdvBudgetInfoModification.DataBind();



                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch (Exception ex) { }

        }


        #region ================ Generate XML and Others ==========        
        private void Createxml(string autoid, string qnt, string prdrate, string prdamount)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("BudgetModification");
                XmlNode addItem = CreateNode(doc, autoid,  qnt,  prdrate,  prdamount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BudgetModification");
                XmlNode addItem = CreateNode(doc, autoid, qnt, prdrate, prdamount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string autoid, string qnt, string prdrate, string prdamount)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Autoid = doc.CreateAttribute("autoid"); Autoid.Value = autoid;
            XmlAttribute Qnt = doc.CreateAttribute("qnt"); Qnt.Value = qnt;
            XmlAttribute Prdrate = doc.CreateAttribute("prdrate"); Prdrate.Value = prdrate;
            XmlAttribute Prdamount = doc.CreateAttribute("prdamount"); Prdamount.Value = prdamount;

            node.Attributes.Append(Autoid);
            node.Attributes.Append(Qnt);
            node.Attributes.Append(Prdrate);
            node.Attributes.Append(Prdamount);

            return node;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                if (grdvBudgetInfoModification.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvBudgetInfoModification.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvBudgetInfoModification.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                           
                            string autoid = ((HiddenField)grdvBudgetInfoModification.Rows[index].FindControl("hdnintBudgetId")).Value.ToString();
                            string qnt = ((TextBox)grdvBudgetInfoModification.Rows[index].FindControl("txtdecQnt")).Text.ToString();
                            string rate = ((TextBox)grdvBudgetInfoModification.Rows[index].FindControl("txtProductRate")).Text.ToString();
                            string totalamnt = ((TextBox)grdvBudgetInfoModification.Rows[index].FindControl("txtmonBudget")).Text.ToString();

                            Createxml(autoid, qnt, rate, totalamnt);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    unitid = int.Parse(ddlUnit.SelectedValue.ToString());

                    bgttype = int.Parse(ddlBudgetType.SelectedValue.ToString());
                    actiontype = int.Parse(ddlActionType.SelectedValue.ToString());
                    enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    if (txtProduct.Text.Length > 2)
                    {
                        string strSearchKey = txtProduct.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        string code = arrayKey[1].ToString();
                        itmid = int.Parse(code);
                    }
                    else
                    {
                        itmid = 0;
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("BudgetModification");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<BudgetModification>" + xmlString + "</BudgetModification>";
                    dt = obj.GetBudgetModificationInfo(xmlString, enrol, unitid, dtFromDate, dtToDate, bgttype, itmid, actiontype);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["strMessages"].ToString() + "');", true);

                    try { File.Delete(xmlpath); } catch { }



                    #endregion ------------ Insertion End ----------------
                    grdvBudgetInfoModification.DataSource = "";
                    grdvBudgetInfoModification.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }

        }
    }
}