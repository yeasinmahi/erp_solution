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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.AEFPS
{
    public partial class FpsSalesEntryDIT : BasePage
    {
        int empid,part,intitemid,intEntryid,id,intWID, intpaymenttype, intInsertby;
        decimal qty,SalesQty, monCredit, SalesAmount,ReceiveAmt, price,Salary,CreditPurchesAmount,AvailableBalance, monCashReceive, monCashReturn;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        string msg,svno, strWHName, qrcode, uom, ItemName;
        SeriLog log = new SeriLog();
        DataTable dt, dtr;


        readonly Receive_BLL _bll = new Receive_BLL();
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtedate;


        string location = "AEFPS";

        

        string start = "starting AEFPS\\FpsSalesEntry";
        string stop = "stopping AEFPS\\FpsSalesEntry";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                objAEFPS.getTemtableDeletedit(intInsertby);
                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();
                TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GetMemoCount();
                GetDiscount();
                txtCardNo.Enabled = false;

            }
            else
            { }
            
        }

        private void GetDiscount()
        {
            dt = objAEFPS.getDiscountList(int.Parse(ddlWH.SelectedValue.ToString()));
            ddlDiscountList.DataTextField = "strDiscountPar";
            ddlDiscountList.DataValueField = "monDiscount";
            ddlDiscountList.DataSource = dt;
            ddlDiscountList.DataBind();

        }

        private void GetMemoCount()
        {
            try
            {
                dt = objAEFPS.getmemoCount(int.Parse(ddlWH.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    lblMemoCounttxt.Text = dt.Rows[0]["counts"].ToString();
                }
                else
                {
                    lblMemoCounttxt.Text = "0".ToString();

                }
            }
            catch { }
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
                    objAEFPS.getinsertDIT(qrcode, intitemid, ItemName, qty, price, qty * price, intInsertby, decimal.Parse(ddlDiscountList.SelectedValue.ToString()), decimal.Parse(ddlDiscountList.SelectedValue.ToString())*(qty*price));
                    dtDetails = objAEFPS.getReportditf(intInsertby);
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
            if(hdnNetpayable.Value=="")
            { ReceiveAmt = 0; }
            else { ReceiveAmt = decimal.Parse(hdnNetpayable.Value); }
           
           
                if ((ReceiveAmt - SalesAmount) < 0)
                {
                    txtReturn.Text = ((ReceiveAmt - SalesAmount)*-1).ToString();
                }
                else { txtReturn.Text = (("0").ToString()); }

            if(int.Parse(ddlpaymenttype.SelectedValue)==1)
            { txtCardNo.Enabled = false; }
            else
            {
                txtCardNo.Enabled = true;
            }
               

           
        }

        DataTable dtDetails;
        protected void txtCashReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            SalesAmount =decimal.Parse(txtCashReceiveAmount.Text);
            if (hdnNetpayable.Value !="")
            {
                ReceiveAmt = decimal.Parse(hdnNetpayable.Value);
                
                   
                        if ((ReceiveAmt - SalesAmount) < 0)
                        {
                            txtReturn.Text = ((ReceiveAmt - SalesAmount) * -1).ToString();
                        }
                        else { txtReturn.Text = (("0").ToString()); }

                   
               
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);


                var tracker = new PerfTracker("Performance on AEFPS\\FpsSalesEntry Submit AEFPS Challan", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    if ((txtMobileno.Text != "") || (txtReturn.Text != ""))
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
                                    empid = int.Parse(0.ToString());
                                    intWID = int.Parse(ddlWH.SelectedValue.ToString());
                                    intpaymenttype = int.Parse(ddlpaymenttype.SelectedValue.ToString());
                                    if (txtCashReceiveAmount.Text != "")
                                    {
                                        monCashReceive = decimal.Parse(txtCashReceiveAmount.Text.ToString());
                                    }
                                    else { monCashReceive = decimal.Parse("0"); }
                                    monCashReturn = decimal.Parse(txtReturn.Text);
                                    intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                                    msg = objAEFPS.getSalesEntryDit(dtedate, empid, intWID, intpaymenttype, monCashReceive, monCashReturn, intInsertby, txtMobileno.Text, decimal.Parse(hdnNetpayable.Value), Decimal.Parse(hdnDiscount.Value),txtCardNo.Text);
                                    dgvRptTemp.DataBind();
                                    char[] delimiterCharss = { ':', ']' };
                                    arrayKeyItem = msg.Split(delimiterCharss);

                                    svno = (arrayKeyItem[1].ToString());
                                    HttpContext.Current.Session["empid"] = empid.ToString();
                                    lblchallanno.Text = "Challan No-" + svno.ToString();

                                    #region ===== Start Print =====================================================                

                                    strWHName = ddlWH.SelectedItem.ToString();



                                    txtCardNo.Text = "";
                                    txtCashReceiveAmount.Text = "";



                                    #endregion =====================================================================                

                                    lblsalesAmount.Text = "";

                                    txtCashReceiveAmount.Text = "";


                                    txtReturn.Text = "";

                                    //txtCreditStatus.Text = "";

                                }
                                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Available Sales Information !');", true); }
                            }
                        }
                    }
                    else
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Employee Inforation!');", true); }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();

                GetMemoCount();
            }

        }

  
        private void getEmployeeResult()
        {
           

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
            else
            {
                txtStock.Text = "0";
                hdnstockQty.Value = "0";
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
            return objFPSSaleEntry.GetItemSearchDITF(prefixText);

        }

        protected double TotalnumQty = 0, TotalAmount = 0, TotalmonTotalDiscount = 0;
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
                if (((Label)e.Row.Cells[2].FindControl("lblTtDiscount")).Text == "")
                {
                    TotalmonTotalDiscount += 0;
                }
                else
                {
                    TotalmonTotalDiscount += double.Parse(((Label)e.Row.Cells[2].FindControl("lblTtDiscount")).Text);
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
               
                lblsalesAmount.Text = "Sales Amount :"+ TotalAmount.ToString();
                lblDiscount.Text = "Discount Amount :" + TotalmonTotalDiscount.ToString();
                hdnDiscount.Value = TotalmonTotalDiscount.ToString();
                lblNetPayable.Text= "Net Payable :" + (TotalAmount- TotalmonTotalDiscount).ToString();
                hdnNetpayable.Value = (TotalAmount - TotalmonTotalDiscount).ToString();
                hdnActualSales.Value = (TotalAmount - TotalmonTotalDiscount).ToString();
                if (txtCashReceiveAmount.Text != "")
                {
                    SalesAmount = decimal.Parse(txtCashReceiveAmount.Text);
                }
                else { SalesAmount = decimal.Parse("0"); }
                if ((hdnNetpayable.Value != "") || (hdnNetpayable.Value != null))
                {
                    ReceiveAmt = decimal.Parse(hdnNetpayable.Value);
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


            objAEFPS.InsertUpdateAndReportDITF(id);
            dt = objAEFPS.getReportditf(intEntryid);
           // dt = objAEFPS.getReport(intEntryid);
            if (dt.Rows.Count > 0)
            {
                dgvRptTemp.DataSource = dt;
                dgvRptTemp.DataBind();

            }
            else
            {
                dgvRptTemp.DataBind();
                lblsalesAmount.Text = "Sales Amount :" + "0".ToString();
                lblDiscount.Text = "Discount Amount :" + "0".ToString();
                lblNetPayable.Text = "Net Payable :" +"0".ToString();
            }
           
        }

        protected void btnClearPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                int whId = Convert.ToInt32(ddlWH.SelectedItem.Value);
                _bll.ClearPrinter(whId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully Cleared');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Cleaning Problem');", true);
            }
        }

        protected void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                int whId = Convert.ToInt32(ddlWH.SelectedItem.Value);
                string voucharNumber =  txtVCNo.Text;
                _bll.RePrintVoucher(whId, voucharNumber);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your desired data is printing...');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something is error');", true);
            }
        }
       





    }
}