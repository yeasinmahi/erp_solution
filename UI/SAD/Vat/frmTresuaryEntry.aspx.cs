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
    public partial class frmTresuaryEntry : BasePage
    {
        string strChallanNo, strInstrument;
        int intType,intid,intyear,intMonth;
        DataTable dt;decimal  TotalAmount;
        DateTime dteTransDate, dteChallanDate, dteInstDate,dtefdate,dtetdate;
        char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (int.Parse(Session[SessionParams.USER_ID].ToString()) != 1392)
                {
                    dt = objMush.getTreasuryCode(1);
                }
                else { dt = objMush.getTreasuryCode(2); }
                ddlShorby.DataTextField = "strTreasuryDepositDescription";
                ddlTCode.DataValueField = "intTreasuryDepositID";
                ddlTCode.DataSource = dt;
                ddlTCode.DataBind();


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(hdnconfirm.Value) == 1)
            {

                dteChallanDate = DateTime.Parse(txtChallandate.Text);
                dteTransDate = DateTime.Parse(txtDepositdate.Text);
                dteInstDate = DateTime.Parse(txtInstallmentdate.Text);
                TotalAmount = decimal.Parse(txtAmount.Text);
                intType = int.Parse(ddlTCode.SelectedValue);
                strInstrument = txtInstrument.Text;
                strChallanNo = txtChallanNo.Text;
                objMush.getTreasuryEntry(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), intType, TotalAmount, int.Parse(Session[SessionParams.USER_ID].ToString()), strChallanNo, dteChallanDate, strInstrument, dteInstDate, dteTransDate);
              
            }
        }     
        protected void btnReport_Click1(object sender, EventArgs e)
        {
            dtefdate = DateTime.Parse(txtfdate.Text);
            dtetdate = DateTime.Parse(txttdate.Text);
            intType =int.Parse(ddlShorby.SelectedValue);
            dt = objMush.getTreasuryRpt(int.Parse(hdnAccno.Value), dtefdate, dtetdate,intType);
        }
        protected double TotalValue = 0;
        protected void dgvTresuryRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[6].FindControl("lblmonAmount")).Text == "")
                {
                    TotalValue += 0;
                }
                else
                {
                    TotalValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblmonAmount")).Text);
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
                intid = int.Parse(searchKey[0].ToString());
                dt = objMush.getTreasuryYear(intid);
                intyear = int.Parse(dt.Rows[0]["intYear"].ToString());
                intMonth = int.Parse(dt.Rows[0]["intMonth"].ToString());
                dt = objMush.getTreasuryCount(int.Parse(hdnAccno.Value),intyear,intMonth);
                if (int.Parse(dt.Rows[0]["intCount"].ToString()) == 0)
                {
                    objMush.gepPurchasedelete(int.Parse(hdnAccno.Value), intid, 3);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Mushak-19 for this purchase already created. Therefore, delete is not possible!');", true);
                }



            }
            catch { }
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