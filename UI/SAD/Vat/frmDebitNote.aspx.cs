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
    public partial class frmDebitNote : BasePage
    {
        string strChallanNo, strSupChallanNo, strReason, strMaterial, strItem, strVehicleTypeNo, strSuppname, strSuppAddress, strCusVatReg, intVATTime;
        int intItem, intYear,intMaterialid, intM12No, intM11Challanno,intsuppid,VatChallanNo, intid,intyear,intMonth, intSL;


        DataTable dt;decimal numQty, monRtnAmountWithoutSDnVAT, monRedqty, monValue, monSD, monSurCharge, monVAT, monM11Other, monM11VAT, monNewSD, monNewVAT;
        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' }; string[] arrayKeyItem;
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

            }
        }

        protected void txtMatrialName_TextChanged(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtMatrialName.Text.Split(delimiterCharss);
            strMaterial = (arrayKeyItem[0].ToString());
            intMaterialid = int.Parse(arrayKeyItem[1].ToString());
            dt = objMush.getmaterialinfo(intMaterialid);
            if(dt.Rows.Count>0)
            {
                ddlAllPurchase.DataTextField = "strChallanNo";
                ddlAllPurchase.DataValueField = "intID";
                ddlAllPurchase.DataSource = dt;
                ddlAllPurchase.DataBind();
            }
        }

       
        protected void ddlAllPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = objMush.getPurchaseinfo(int.Parse(ddlAllPurchase.SelectedValue));
            txtsuppVatReg.Text= dt.Rows[0]["strSupplierName"].ToString();
            txtVehicletypeno.Text = dt.Rows[0]["strVATRegNo"].ToString();
            hdnCustid.Value = dt.Rows[0]["intSupplierID"].ToString();

            dt = objMush.getMatrialproductinfo(int.Parse(ddlAllPurchase.SelectedValue));
            dgvVatProduct.DataSource = dt;
            dgvVatProduct.DataBind();
        }

    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // intM11Challanno =int.Parse(txtVatChallno.Text);
            intsuppid = int.Parse(hdnCustid.Value);
            strSuppname = hdnCustname.Value;
            strSupChallanNo = ddlAllPurchase.SelectedValue.ToString();
            strVehicleTypeNo = txtVehicletypeno.Text;
            dtedate = DateTime.Now;
            if (dtedate.Month >= 7)
            {
                intYear = int.Parse((dtedate.Year) + "" + ((dtedate.Year) + 1).ToString());
            }
            else { intYear = int.Parse(((dtedate.Year) - 1).ToString() + "" + ((dtedate.Year) + 1).ToString()); }
            dt = objMush.getVatChallano(intYear, int.Parse(hdnAccno.Value), "M12KA");
            intM12No = int.Parse(dt.Rows[0]["intVatChallanNo"].ToString());

            intSL = 0;
            if (dgvVatProduct.Rows.Count > 0)
            {
                for (int index = 0; index < dgvVatProduct.Rows.Count; index++)
                {
                    intSL = intSL + 1;
                    intItem =int.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblvatItemid")).Text.ToString());
                    strChallanNo = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrChallanNo")).Text.ToString();
                    strM11DateChallan =DateTime.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lbldtedate")).Text.ToString());
                    strItem = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVatProductName")).Text.ToString();
                    numQty =decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblQuantity")).Text.ToString());
                    monValue = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsdvat")).Text.ToString());
                    monSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsd")).Text.ToString());                  
                    monVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblVAT")).Text.ToString());
                    monRedqty = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblM11")).Text.ToString());
                    monNewSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecrateOthervat")).Text.ToString());
                    monNewVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecratevat")).Text.ToString());
                    string msg=objMush.getDebitnoteCreate(intM12No, intsuppid,strVehicleTypeNo,intItem, intSL, intM12No, strM11DateChallan,strItem,numQty,monValue,monSD,monVAT, monRedqty, monNewSD,monNewVAT,strReason,int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.UNIT_ID].ToString()), intYear, monSurCharge, strSupChallanNo, strM11DateChallan);
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