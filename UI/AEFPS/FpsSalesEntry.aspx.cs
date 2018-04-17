using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Drawing.Printing;
using System.Drawing;

namespace UI.AEFPS
{
    public partial class FpsSalesEntry : BasePage
    {
        int empid,part,intitemid,intEntryid,id,intWID, intpaymenttype, intInsertby;
        decimal qty,SalesQty, monCredit, SalesAmount,ReceiveAmt, price,Salary,CreditPurchesAmount,AvailableBalance, monCashReceive, monCashReturn;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        string msg,svno, strWHName, qrcode, uom, ItemName;

        DataTable dt, dtr;
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtedate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                objAEFPS.getTemtableDelete(intInsertby);
                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();
                TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            { }

        }
        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            getEmployeeResultTextBox();
        }
        protected void txtItemname_TextChanged(object sender, EventArgs e)
        {
            getItemResult();
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            ddlpaymenttype.DataBind();
            if (txtQty.Text != "")
            {
                qrcode = hdnSalesQty.Value;
                SalesQty = decimal.Parse(txtQty.Text);
                intitemid = int.Parse(hdnItemid.Value);
                intWID = int.Parse(ddlWH.SelectedValue);
                dt = new DataTable();
                part = 1;
                dt = objAEFPS.getPricesPer(part,intWID, intitemid, SalesQty);
                if (dt.Rows.Count > 0)
                {
                    price = decimal.Parse(dt.Rows[0]["monUnitPrice"].ToString());
                    txtPrice.Text = price.ToString();
                }
            }
            if ((txtStock.Text != "") && (txtQty.Text != "") && (txtPrice.Text != "") && (txtPrice.Text != "0") && (txtQty.Text != "0"))
            {
                if ((decimal.Parse(txtStock.Text)) >= decimal.Parse((txtQty.Text)))
                {
                    qrcode = hdnSalesQty.Value;
                    intitemid = int.Parse(hdnItemid.Value);
                    price = decimal.Parse(txtPrice.Text);
                    qty = decimal.Parse(txtQty.Text);
                    ItemName = txtItemname.Text;
                    intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                    objAEFPS.getinsert(qrcode, intitemid, ItemName, qty, price, qty * price, intInsertby);
                    dtDetails = objAEFPS.getReport(intInsertby);
                    if (dtDetails.Rows.Count > 0)
                    {
                        dgvRptTemp.DataSource = dtDetails;
                        dgvRptTemp.DataBind();
                    }
                    txtQRcode.Text = "";
                    txtItemname.Text = "";
                    txtPrice.Text = "";
                    txtQty.Text = "";
                    txtStock.Text = "";

                    txtQRcode.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Item Stock No Available !');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Sales Qty and Price !');", true);
            }

        }

        protected void ddlpaymenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCashReceiveAmount.Text == "")
            {
                SalesAmount = decimal.Parse("0");
            }
            else { SalesAmount = decimal.Parse(txtCashReceiveAmount.Text); }
            if(hdnSaleAmount.Value=="")
            { ReceiveAmt = 0; }
            else { ReceiveAmt = decimal.Parse(hdnSaleAmount.Value); }
           
            if (int.Parse(ddlpaymenttype.SelectedValue) == 1)
            {
                if ((ReceiveAmt - SalesAmount) < 0)
                {
                    txtReturn.Text = ((ReceiveAmt - SalesAmount)*-1).ToString();
                }
                else { txtReturn.Text = (("0").ToString()); }

            }
            else { txtReturn.Text = ("0".ToString()); txtCashReceiveAmount.Text = ("0".ToString()); }
        }

        DataTable dtDetails;
        protected void txtCashReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            SalesAmount =decimal.Parse(txtCashReceiveAmount.Text);
            if (hdnSaleAmount.Value !="")
            {
                ReceiveAmt = decimal.Parse(hdnSaleAmount.Value);
                if (int.Parse(ddlpaymenttype.SelectedValue) == 1)
                {
                    if (int.Parse(ddlpaymenttype.SelectedValue) == 1)
                    {
                        if ((ReceiveAmt - SalesAmount) < 0)
                        {
                            txtReturn.Text = ((ReceiveAmt - SalesAmount) * -1).ToString();
                        }
                        else { txtReturn.Text = (("0").ToString()); }

                    }
                    else { txtReturn.Text = ("0".ToString()); }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Cash !');", true); }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
                if ((txtEmployee.Text != "") || (txtEnroll.Text != "") || (txtEnroll.Text != "") || (txtReturn.Text != ""))
                {
                    if ((txtCashReceiveAmount.Text == "") && (ddlpaymenttype.SelectedValue == "1"))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Entry Receive Amount !');", true);
                    }
                    else
                    {
                        if (decimal.Parse(txtCashReceiveAmount.Text) < decimal.Parse(hdnActualSales.Value) && (ddlpaymenttype.SelectedValue == "1"))
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Receive Amount Wrong !');", true);
                        }

                        else
                        {
                            if (dgvRptTemp.Rows.Count > 0)
                            {

                                dtedate = DateTime.Parse(DateTime.Now.ToString());
                                empid = int.Parse(txtEnroll.Text.ToString());
                                intWID = int.Parse(ddlWH.SelectedValue.ToString());
                                intpaymenttype = int.Parse(ddlpaymenttype.SelectedValue.ToString());
                                if (txtCashReceiveAmount.Text != "")
                                {
                                    monCashReceive = decimal.Parse(txtCashReceiveAmount.Text.ToString());
                                }
                                else { monCashReceive = decimal.Parse("0"); }
                                monCashReturn = decimal.Parse("0");
                                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                                msg = objAEFPS.getSalesEntry(dtedate, empid, intWID, intpaymenttype, monCashReceive, monCashReturn, intInsertby);
                                dgvRptTemp.DataBind();
                                char[] delimiterCharss = { ':', ']' };
                                arrayKeyItem = msg.Split(delimiterCharss);

                                svno = (arrayKeyItem[1].ToString());
                                HttpContext.Current.Session["empid"] = empid.ToString();
                                lblchallanno.Text = "Challan No-" + svno.ToString();

                                #region ===== Start Print =====================================================                

                                strWHName = ddlWH.SelectedItem.ToString();
                                string strSearchKey = txtEmployee.Text;
                                string[] searchKey = Regex.Split(strSearchKey, ",");
                                string strCustomerName = searchKey[0];
                                string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                                string strPayType = ddlpaymenttype.SelectedItem.ToString();

                                txtDeg.Text = "";


                                txtEnroll.Text = "";
                                txtCashReceiveAmount.Text = "";



                                #endregion =====================================================================                


                                lblsalesAmount.Text = "";
                                txtEnroll.Text = "";
                                txtCashReceiveAmount.Text = "";
                                txtEmployee.Text = "";
                                txtEmname.Text = "";
                                txtReturn.Text = "";
                                txtDeg.Text = "";
                                txtDept.Text = "";

                                txtCard.Text = "";
                                txtCreditStatus.Text = "";

                            }
                            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Available Sales Information !');", true); }
                        }
                    }
                }
                else
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Employee Inforation!');", true); }

            

        }

  
        private void getEmployeeResult()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            empid = Int32.Parse(arrayKeyItem[1].ToString());
            dt = objAEFPS.getEmpinfo(empid);
            if (dt.Rows.Count > 0)
            {
                txtEmname.Text = dt.Rows[0]["strEmployeeName"].ToString();
                txtEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                txtCard.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                txtDeg.Text = dt.Rows[0]["strdesignation"].ToString();
                txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                hdnSalary.Value = dt.Rows[0]["monSalary"].ToString();
                dt = objAEFPS.getCreditAmountPurches(dt.Rows[0]["intEmployeeID"].ToString());
                if (dt.Rows.Count > 0)
                {
                    txtCredittotalamount.Text = dt.Rows[0]["CashReceiveamount"].ToString();
                    AvailableBalance = decimal.Parse(hdnSalary.Value) - decimal.Parse(dt.Rows[0]["CashReceiveamount"].ToString());
                    if (AvailableBalance > 0)
                    {
                        txtCreditStatus.Text = "Elizable";
                    }
                    else
                    {
                        txtCreditStatus.Text = "Not Elizable";
                    }
                }
                else { txtCredittotalamount.Text = ""; }

            }

        }

        private void getEmployeeResultTextBox()
        {
            try
            {
                dt = objAEFPS.getEmpCheck(ddlWH.SelectedValue, txtEmployee.Text);
                if (int.Parse(dt.Rows[0]["counts"].ToString()) == 1)
                {
                    empid = Int32.Parse(txtEmployee.Text.ToString());
                    dt = objAEFPS.getEmpinfo(empid);
                    if (dt.Rows.Count > 0)
                    {
                        txtEmname.Text = dt.Rows[0]["strEmployeeName"].ToString();
                        txtEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                        txtCard.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                        txtDeg.Text = dt.Rows[0]["strdesignation"].ToString();
                        txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                        hdnSalary.Value = dt.Rows[0]["monSalary"].ToString();
                        dt = objAEFPS.getCreditAmountPurches(dt.Rows[0]["intEmployeeID"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            txtCredittotalamount.Text = dt.Rows[0]["CashReceiveamount"].ToString();
                            AvailableBalance = decimal.Parse(hdnSalary.Value) - decimal.Parse(dt.Rows[0]["CashReceiveamount"].ToString());
                            if (AvailableBalance > 0)
                            {
                                txtCreditStatus.Text = "Elizable";
                            }
                            else
                            {
                                txtCreditStatus.Text = "Not Elizable";
                            }
                        }
                        else { txtCredittotalamount.Text = ""; }

                    }
                }
                 else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Employee No Permission !');", true); }
            }
            catch { }
        }
        private void getItemResult()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemname.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            ItemName = (arrayKeyItem[0].ToString());
            intitemid = Int32.Parse(arrayKeyItem[1].ToString());
                       
            dt = objAEFPS.getItembyQRcode(intitemid);
            txtItemname.Text = "";
            txtItemname.Text = ItemName;
            hdnItemid.Value = (dt.Rows[0]["intMasterId"].ToString());        
            hdnSalesQty.Value = (dt.Rows[0]["strBarcode"].ToString());

            intWID = int.Parse(ddlWH.SelectedValue.ToString());
            dt = objAEFPS.getInventoryStock(intitemid, intWID);
            if (dt.Rows.Count > 0)
            {
                txtStock.Text = dt.Rows[0]["invStock"].ToString();
                hdnstockQty.Value = dt.Rows[0]["invStock"].ToString();
            }


        }

        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count=0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetItemSearch(prefixText);

        }
        protected double TotalnumQty = 0, TotalAmount = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                if (((Label)e.Row.Cells[1].FindControl("lblnumQty")).Text == "")
                {
                    TotalnumQty += 0;
                }
                else
                {
                    TotalnumQty += double.Parse(((Label)e.Row.Cells[1].FindControl("lblnumQty")).Text);
                }
                if (((Label)e.Row.Cells[2].FindControl("lblmonAmount")).Text == "")
                {
                    TotalAmount += 0;
                }
                else
                {
                    TotalAmount += double.Parse(((Label)e.Row.Cells[2].FindControl("lblmonAmount")).Text);
                }
                hdnSaleAmount.Value = TotalAmount.ToString();
                hdnActualSales.Value= TotalAmount.ToString();
                lblsalesAmount.Text = "Sales Amount :"+ TotalAmount.ToString();
                if (txtCashReceiveAmount.Text != "")
                {
                    SalesAmount = decimal.Parse(txtCashReceiveAmount.Text);
                }
                else { SalesAmount = decimal.Parse("0"); }
                if ((hdnSaleAmount.Value != "") || (hdnSaleAmount.Value != null))
                {
                    ReceiveAmt = decimal.Parse(hdnSaleAmount.Value);
                }
                else { ReceiveAmt = decimal.Parse("0"); }
                if (int.Parse(ddlpaymenttype.SelectedValue) == 1)
                {
                    if ((ReceiveAmt - SalesAmount) < 0)
                    {
                        txtReturn.Text = ((ReceiveAmt - SalesAmount) * -1).ToString();
                    }
                    else { txtReturn.Text = (("0").ToString()); }

                }
                else { txtReturn.Text = ("0".ToString()); }


            }
        }

        protected void txtQRcode_TextChanged(object sender, EventArgs e)
        {

            if (txtQRcode.Text.ToString() != "")
            {
                string senderdata = (txtQRcode.Text.ToString());

                string strSearchKey = senderdata;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                qrcode = searchKey[0].ToString();

                hdnSalesQty.Value = (qrcode);                
               
                dt = new DataTable();
                dt = objAEFPS.getQRCodeforitem(qrcode);
                if (dt.Rows.Count > 0)
                {
                
                    txtItemname.Text = dt.Rows[0]["strName"].ToString();

                    intitemid = int.Parse(dt.Rows[0]["intMasterId"].ToString());
                    hdnItemid.Value = (dt.Rows[0]["intMasterId"].ToString());
                    uom = (dt.Rows[0]["strBarcode"].ToString());
                    intWID = int.Parse(ddlWH.SelectedValue.ToString());
                    dt = objAEFPS.getInventoryStock(intitemid, intWID);
                    if (dt.Rows.Count > 0)
                    {
                        txtStock.Text = dt.Rows[0]["invStock"].ToString();
                        hdnstockQty.Value = dt.Rows[0]["invStock"].ToString();
                    }


                }
                txtQRcode.Text = "";
            }

        }
        protected void Complete1_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");

          
            id = int.Parse(searchKey[0].ToString());

            intEntryid = int.Parse(Session[SessionParams.USER_ID].ToString());


            objAEFPS.InsertUpdateAndReport(id);
            dt = objAEFPS.getReport(intEntryid);
            if (dt.Rows.Count > 0)
            {
                dgvRptTemp.DataSource = dt;
                dgvRptTemp.DataBind();

            }
            else
            {
                dgvRptTemp.DataBind();
                lblsalesAmount.Text = "Sales Amount :" + "0".ToString();
            }
           
        }
    }
}