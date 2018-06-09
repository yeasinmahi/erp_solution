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
    public partial class frmCreditNote : BasePage
    {
        string strChallanNo,strReason, strItem, strVehicleTypeNo, strCusName, strCusAddress, strCusVatReg, intVATTime;
        int intItem, intYear, intM12No, intM11Challanno,intCustid,VatChallanNo, intid,intyear,intMonth, intSL;

        DataTable dt;decimal numQty, monRtnAmountWithoutSDnVAT, monValue, monSD, monSurCharge, monVAT, monM11Other, monM11VAT, monNewSD, monNewVAT;
        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' };bool ysnFactory;
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
                //dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                //ddlVatAccount.DataTextField = "strVATAccountName";
                //ddlVatAccount.DataValueField = "intVatPointID";
                //ddlVatAccount.DataSource = dt;
                //ddlVatAccount.DataBind();
                //lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                //hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();

            }
        }
        protected void btnShowREPORT_Click(object sender, EventArgs e)
        {
            strChallanNo = txtVatChallno.Text;
            intyear = int.Parse(txtYear.Text);

            dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), 1);
            hdnCustid.Value = dt.Rows[0]["intCusID"].ToString();
            hdnCustname.Value = dt.Rows[0]["strCustName"].ToString();
            hdnCustname.Value = dt.Rows[0]["strCustAddress"].ToString();
            txtCustomerVatReg.Text = dt.Rows[0]["strCustVATRegNo"].ToString();
            dt.Clear();
            dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), 2);
            dgvVatProduct.DataSource = dt;
            dgvVatProduct.DataBind();

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            strChallanNo = txtVatChallno.Text;
            intyear =int.Parse(txtYear.Text);

            dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value),1);
            hdnCustid.Value = dt.Rows[0]["intCusID"].ToString();
            hdnCustname.Value = dt.Rows[0]["strCustName"].ToString();
            hdnCustname.Value = dt.Rows[0]["strCustAddress"].ToString();
            txtCustomerVatReg.Text = dt.Rows[0]["strCustVATRegNo"].ToString();
            dt.Clear();
            dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value),2);
            dgvVatProduct.DataSource = dt;
            dgvVatProduct.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            intM11Challanno =int.Parse(txtVatChallno.Text);
            intCustid = int.Parse(hdnCustid.Value);
            strCusName= hdnCustname.Value;
            strCusAddress = hdnCustAddress.Value;
            strVehicleTypeNo = txtVehicletypeno.Text;
            dtedate = DateTime.Now;
            if (dtedate.Month >= 7)
            {
                intYear = int.Parse((dtedate.Year) + "" + ((dtedate.Year) + 1).ToString());
            }
            else { intYear = int.Parse(((dtedate.Year) - 1).ToString() + "" + ((dtedate.Year) + 1).ToString()); }
            dt = objMush.getVatChallano(intYear, int.Parse(hdnAccno.Value), "M12");
            intM12No = int.Parse(dt.Rows[0]["intVatChallanNo"].ToString());

            intSL = 0;
            if (dgvVatProduct.Rows.Count > 0)
            {
                for (int index = 0; index < dgvVatProduct.Rows.Count; index++)
                {
                    intSL = intSL + 1;

                    intItem =int.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblvatItemid")).Text.ToString());
                    strChallanNo = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVATChallanNo")).Text.ToString();
                    strM11DateChallan =DateTime.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lbldtedate")).Text.ToString());
                    strItem = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVatProductName")).Text.ToString();
                    numQty =decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblQuantity")).Text.ToString());
                    monValue = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsdvat")).Text.ToString());
                    monSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsd")).Text.ToString());
                    monSurCharge = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblSurCharge")).Text.ToString());
                    monVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblVAT")).Text.ToString());
                    monM11Other = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblM11txt")).Text.ToString());
                    monM11VAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblM11")).Text.ToString());
                    monNewSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecrateOthervat")).Text.ToString());
                    monNewVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecratevat")).Text.ToString());

                    string msg=objMush.getCreditnoteCreate(intM12No, intCustid,strCusName,strCusAddress,strCusVatReg,strVehicleTypeNo,intItem,intSL,intM11Challanno,strM11DateChallan,strItem,numQty,monValue,monSD,monVAT,monM11Other,monM11VAT,monNewSD,monNewVAT,strReason,int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.UNIT_ID].ToString()), intYear, monSurCharge);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                }
            }
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