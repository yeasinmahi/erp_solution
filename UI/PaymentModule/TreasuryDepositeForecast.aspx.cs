using HR_BLL.Payment;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using Utility;

namespace UI.PaymentModule
{
    public partial class TreasuryDepositeForecast : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/TreasuryDepositeForecast.aspx";
        string stop = "stopping PaymentModule/TreasuryDepositeForecast.aspx";

        readonly TreasuryChallanBLL _bll = new TreasuryChallanBLL();
        DataTable dt = new DataTable();
        DataTable dtbank = new DataTable();
        DataTable dtacc = new DataTable();
        DataTable dtChartOfAcc = new DataTable();
        int intUnit,intBank, intVatAcc, intBankAcc,intTreasuryId,intPart=0;
        int intCOA; string strAccName="", strPayTo="", strNarration="";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryDepositeForecast.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer); 

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtVDate.Text = DateTime.Now.ToString();
                LoadUnit();
                LoadBank();
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void LoadUnit()
        {
            Common.LoadDropDown(ddlUnit,_bll.getUnitByUser(Enroll), "intVatAccountID", "strVatAccountName");

        }
        public void LoadBank()
        {
            int unitId = ddlUnit.SelectedValue();
            DataTable dt = _bll.GetBankListData(unitId);
            if (dt.Rows.Count > 0)
            {
                Common.LoadDropDownWithSelect(ddlBank, _bll.GetBankListData(unitId), "intBankID", "strBankName");
            }
            else
            {
                Common.UnLoadDropDownWithSelect(ddlBank);
            }
            

        }
        public void LoadAccount()
        {
            int unitId = ddlUnit.SelectedValue();
            int bankId = ddlBank.SelectedValue();
            DataTable dt = _bll.GetBankListData(unitId);
            if (dt.Rows.Count > 0)
            {
                Common.LoadDropDownWithSelect(ddlAccount, _bll.GetAccountListData(unitId, bankId), "intAccountID", "strBankAccount");
            }
            else
            {
                Common.UnLoadDropDownWithSelect(ddlAccount);
            }
            

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryDepositeForecast.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
             
            intVatAcc = int.Parse(ddlUnit.SelectedItem.Value);
            dt = _bll.GetForecastDetails(intVatAcc);
            GvDetails.DataSource = dt;
            GvDetails.DataBind();

            //LoadBank();
            
            //if(intVatAcc==3)
            //{
            //    intUnit = 4;
            //}
            //else
            //{
            //    intUnit = 105;
            //}

            //dtbank = _bll.GetBankListData(intVatAcc);
            //ddlBank.DataSource = dtbank;
            //ddlBank.DataTextField = "strBankName";
            //ddlBank.DataValueField = "intBankID";
            //ddlBank.DataBind();

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region===========Radio Button==============
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRadioAdvice.Checked == true)
            {
                
            }
            else if(btnRadioCheque.Checked==true)
            {
                
            }
        }
        #endregion=====

        #region=======DropDown Index Change===========
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccount();
            //intVatAcc = int.Parse(ddlUnit.SelectedItem.Value);
            //intBank = int.Parse(ddlBank.SelectedItem.Value);
            //if (intVatAcc == 3)
            //{
            //    intUnit = 4;
            //}
            //else
            //{
            //    intUnit = 105;
            //}

            //dtacc = _bll.GetAccountListData(intVatAcc, intBank);

            //ddlAccount.DataSource = dtacc;
            //ddlAccount.DataTextField = "strBankAccount";
            //ddlAccount.DataValueField = "intAccountID";
            //ddlAccount.DataBind();
        }
        #endregion==========end===============

        #region ======== GridView RowCommand =============
        protected void GvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int intType=1;
            if (e.CommandName != "DepositV") return;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GvDetails.Rows[index];
            intType = int.Parse((row.FindControl("lblIntType") as Label).Text);
            intVatAcc = int.Parse(ddlUnit.SelectedItem.Value);

            if (intVatAcc == 3)
            {
                intUnit = 4;
            }
            else
            {
                intUnit = 105;
            }
            
            DateTime dteVdate = DateTime.Parse(txtVDate.Text);
            string strDrAmount = (row.FindControl("txtPay") as TextBox)?.Text;
            if (string.IsNullOrWhiteSpace(strDrAmount))
            {
                Toaster("Please Input Debit Amount ",Common.TosterType.Warning);
                return;
            }

            decimal.TryParse(strDrAmount, out var monDramount);
            if (monDramount == 0)
            {
                Toaster("Please Input Debit Amount Properly", Common.TosterType.Warning);
                return;
            }
            decimal monCrAmount = monDramount*(-1);
            intBank = int.Parse(ddlBank.SelectedItem.Value);
            intBankAcc = int.Parse(ddlAccount.SelectedItem.Value);

            string strVatAcc = ddlUnit.SelectedItem.Text;
            DataTable dtAdd = new DataTable();
            dtAdd = _bll.getUnitByUser(Enroll);
            string Address = strVatAcc + ',' + dtAdd.Rows[0]["strAddress"].ToString();
            string strName = "Managing Director, " + strVatAcc + " Akij House, 198 Bir Uttam Mir Shawkat Sharak, Gulshan Link Road, Tejgaon I/A, Dhaka-1208.";
            
            if(monDramount == 0)
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Voucher cannot be inserted with zero amount.');", true); }
                       
            if(btnRadioAdvice.Checked==false && btnRadioCheque.Checked==false)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Cheque or Advise as instrument.');", true);                
            }
            
            if(intType==1)
            {
                intTreasuryId = 1;
                dtChartOfAcc=_bll.GetChartOfAccIdList(intVatAcc, intTreasuryId);
            }
            else if(intType == 2)
            {
                intTreasuryId = 2;
                dtChartOfAcc=_bll.GetChartOfAccIdList(intVatAcc, intTreasuryId);
            }
            else if (intType == 3)
            {
                intTreasuryId = 11;
                dtChartOfAcc=_bll.GetChartOfAccIdList(intVatAcc, intTreasuryId);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Chart of account found for such deposit.');", true);
            }

            if (dtChartOfAcc.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Chart of account found for such deposit.');", true);
            }
            else
            {
                intCOA = int.Parse(dtChartOfAcc.Rows[0]["intCOA"].ToString());
                strAccName = dtChartOfAcc.Rows[0]["strAccName"].ToString();
                strPayTo = "B. Bank Chq. issued in favour of B. Bank for " + dtChartOfAcc.Rows[0]["strTreasuryType"].ToString();
                strNarration = "Being the amount paid to B. Bank for " + dtChartOfAcc.Rows[0]["strTreasuryType"].ToString() + " as per date: " + dteVdate; //which date?
                
            }

            if(btnRadioCheque.Checked == true){ intPart = 1; }
            else if(btnRadioAdvice.Checked == true) { intPart = 2; }
            
            _bll.GetTreasuryForcastDataList(intPart, Enroll, intVatAcc, intUnit, dteVdate, monDramount, monCrAmount, intBank, intBankAcc, Address, strName, intTreasuryId, intCOA, strAccName, strPayTo, strNarration);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Treasury deposit voucher inserted successfully.');", true);
            

            #region=======comment========

            //===========insert Vouchar=================
            //    string strCode="", strVoucherCode;
            //    DataTable dtStrCode = new DataTable();
            //    dtStrCode=_bll.InsertVoucharList(intUnit, "voucherBP", dteVdate, "BP",true,ref strCode);
            //    strVoucherCode = dtStrCode.Rows[0]["strCode"].ToString();

            //    //===========Set Cheque No==================

            //    if (btnRadioCheque.Checked == true)
            //    {
            //        DataTable dtCheck = new DataTable();
            //        dtCheck = _bll.GetSetAndUpdateChequeList(intBankAcc, strVoucherCode, ref strCheckNo);
            //        strInstrument = dtCheck.Rows[0]["strCheckNo"].ToString();

            //        if(strInstrument=="")
            //        {
            //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Cheque Leaf Finished.Enter New Cheque Book and Try Again.');", true);                    
            //        }
            //    }
            //    else if(btnRadioAdvice.Checked == true)
            //    {
            //        DataTable dtAdvice = new DataTable();
            //        dtAdvice = _bll.GetSetAndUpdateAdviceList(intUnit, ref strCode);
            //        strInstrument = dtAdvice.Rows[0]["strCode"].ToString();
            //    }

            //    //==========voucher bank==========
            //    DateTime dteLastActionTime = DateTime.Now; string msg = "";
            //    DataTable dtinsert = new DataTable();           
            //    _bll.InsertVoucharBank(strVoucherCode, intUnit, intBank, intBankAcc, strInstrument, dteVdate, strNarration, monCrAmount, intUserId, dteLastActionTime, strPayTo, intCOA, monDrAmount, strAccName, ref msg);
            //    _bll.InsertVoucharList(intUnit, "Treasury", dteVdate, "TSR", true, ref strCode);
            #endregion

        }
        #endregion

        #region========Header Row Created In Gridview======================
        protected void GvDetails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DateTime day0 = DateTime.Now;
                DateTime day1=day0.AddDays(-1); DateTime day2 = day1.AddDays(-1); DateTime day3 = day2.AddDays(-1); DateTime day4 = day3.AddDays(-1);
                DateTime day5 = day4.AddDays(-1); DateTime day6 = day5.AddDays(-1); DateTime day7 = day6.AddDays(-1);
                
                GridView ProductGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert); //rowindex,dataitemindex,DataControlRowType rowType,DataControlRowState rowState
                TableCell HeaderCell = new TableCell();                
                HeaderCell.Text = day7.ToString("yyyy-MM-dd");              
                HeaderCell.ColumnSpan = 3;
                HeaderCell.HorizontalAlign = HorizontalAlign.Right;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day6.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day5.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day4.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day3.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day2.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day1.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = day0.ToString("yyyy-MM-dd");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderRow.Cells.Add(HeaderCell);


                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
          
            }

        }
        #endregion

        #region============ Gridview RowBound for calculate total value ================

        decimal totalDay_0 = 0, totalDay_1 = 0, totalDay_2 = 0, totalDay_3 = 0, totalDay_4 = 0, totalDay_5 = 0, totalDay_6 = 0, totalDay_7 = 0, totalNetPay = 0, totalCurrentBalance = 0;
        protected void GVDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalDay_0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_0"));
                totalDay_1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_1"));
                totalDay_2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_2"));
                totalDay_3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_3"));
                totalDay_4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_4"));
                totalDay_5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_5"));
                totalDay_6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_6"));
                totalDay_7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "day_7"));
                totalNetPay += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Column1"));
                totalCurrentBalance += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monCurrentBalance"));
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label Label0 = (Label)e.Row.FindControl("lblday0");
                if (Label0 != null)
                {
                    Label0.Text = totalDay_0.ToString();
                }
                Label Label1 = (Label)e.Row.FindControl("lblday1");
                if (Label1 != null)
                {
                    Label1.Text = totalDay_1.ToString();
                }
                Label Label2 = (Label)e.Row.FindControl("lblday2");
                if (Label2 != null)
                {
                    Label2.Text = totalDay_2.ToString();
                }
                Label Label3 = (Label)e.Row.FindControl("lblday3");
                if (Label3 != null)
                {
                    Label3.Text = totalDay_3.ToString();
                }
                Label Label4 = (Label)e.Row.FindControl("lblday4");
                if (Label4 != null)
                {
                    Label4.Text = totalDay_4.ToString();
                }
                Label Label5 = (Label)e.Row.FindControl("lblday5");
                if (Label5 != null)
                {
                    Label5.Text = totalDay_5.ToString();
                }
                Label Label6 = (Label)e.Row.FindControl("lblday6");
                if (Label6 != null)
                {
                    Label6.Text = totalDay_6.ToString();
                }
                Label Label7 = (Label)e.Row.FindControl("lblday7");
                if (Label0 != null)
                {
                    Label7.Text = totalDay_7.ToString();
                }
                Label LabelCurrentB = (Label)e.Row.FindControl("lblmonCurrentBalance");
                if (LabelCurrentB != null)
                {
                    LabelCurrentB.Text = totalCurrentBalance.ToString();
                }
                Label LabelNetPay = (Label)e.Row.FindControl("lblNetPay");
                if (LabelNetPay != null)
                {
                    LabelNetPay.Text = totalNetPay.ToString();
                }


            }

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    foreach (TableCell tc in e.Row.Cells)
            //    {
            //        tc.BorderStyle = BorderStyle.None;
            //    }
            //}


        }
        #endregion ==========End RowBound=============

        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBank();
        }
    }
}