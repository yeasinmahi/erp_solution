using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.Bank;
using BLL.Accounts.ChartOfAccount;
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;


/// <summary>
/// Developped By Himadri Das
/// </summary>
namespace UI.Accounts.Bank
{
    public partial class BankInfo : BasePage
    //public partial class Accounts_Bank_BankInfo : System.Web.UI.Page
    {
            public string jsString;
            private string result;
            string userID;
            SeriLog log = new SeriLog();
            string location = "Accounts";
            string start = "starting Accounts\\Bank\\BankInfo";
            string stop = "stopping Accounts\\Bank\\BankInfo";
            protected void Page_Load(object sender, EventArgs e)
            {
                pnlScript.Visible = false;
                userID = "" + Session[SessionParams.USER_ID];
                //userID = "1";
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                }
            }
            protected void btnBankAdd_Click(object sender, EventArgs e)
            {

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\Bank\\BankInfo   BankInfo", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    BLL.Accounts.Bank.BankInfo addBank = new BLL.Accounts.Bank.BankInfo();
                result = addBank.BankInsertion(txtBName.Text, txtBDescription.Text, txtBankCode.Text, int.Parse(userID));
                txtBName.Text = "";
                txtBDescription.Text = "";
                txtBankCode.Text = "";
                ddlBankName.DataBind();
                lblBankAddNoti.Text = result;
                pnlScript.Visible = true;
                jsString = "ShowDiv('newBankDiv','bank')";
                pnlScript.DataBind();

                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();

            }
            protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
            {
                ddlBranchName.DataBind();
                GridView1.DataBind();
            }
            protected void txtBranchAdd_Click(object sender, EventArgs e)
            {
                BankBranch branch = new BankBranch();
                try
                {
                    result = branch.BankBranchInsertion(int.Parse(ddlBankName.SelectedValue), txtBanchName.Text, txtBranchDes.Text, txtBranchCode.Text, int.Parse(userID));
                    txtBanchName.Text = "";
                    txtBranchCode.Text = "";
                    txtBranchDes.Text = "";
                    ddlBranchName.DataBind();
                }
                catch
                {
                    result = "Falid to Insert Branch";
                }

                lblBranchAddNoti.Text = result;
                pnlScript.Visible = true;
                jsString = "ShowDiv('newBranchDiv','branch')";
                pnlScript.DataBind();



            }
            protected void btnAccountAdd_Click(object sender, EventArgs e)
            {
                var fd = log.GetFlogDetail(start, location, "add", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\Bank\\BankInfo   BankInfo Add", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    BankAccount account = new BankAccount();
                decimal? loanAmount = null, loanRate = null;
                DateTime? loanDate = null;

                bool? ysnCommulative = null;
                int? commulativeDays = null;

                int? loanPeriodInYear = null, installmentInYear = null;
                decimal? graceRate = null;
                int? gracePeriodinDays = null;

                if (hdnAccTypeID.Value != "0")
                {
                    loanAmount = decimal.Parse(txtLoanAmount.Text);
                    loanRate = decimal.Parse(txtLoanRate.Text);
                    loanDate = CommonClass.GetDateAtSQLDateFormat(txtDate.Text);


                }
                else
                {
                    loanAmount = null;
                    loanRate = null;
                    loanDate = null;
                }

                if (hdnAccTypeID.Value == "1") // shortTerm Loan
                {
                    if (ChkCom.Checked)
                    {
                        ysnCommulative = true;
                        commulativeDays = int.Parse(txtPeriod.Text);
                    }
                    else
                    {
                        ysnCommulative = false;
                        commulativeDays = 0;
                    }
                }
                else if (hdnAccTypeID.Value == "2")// longterm Loan
                {
                    gracePeriodinDays = int.Parse(txtGracePeriod.Text);
                    graceRate = decimal.Parse(txtGraceRate.Text);
                    loanPeriodInYear = int.Parse(txtLoanPeriod.Text);
                    installmentInYear = int.Parse(txtInstallmentYearly.Text);
                }
                else
                {
                    gracePeriodinDays = null;
                    graceRate = null;
                    loanPeriodInYear = null;
                    installmentInYear = null;
                }

                try
                {
                    result = account.BankAccountInsertion(
                                                            int.Parse(ddlBranchName.SelectedValue),
                                                            int.Parse(ddlUnit.SelectedValue),
                                                            txtAccNo.Text,
                                                            txtAccName.Text,
                                                            txtAccDes.Text,
                                                            int.Parse(ddlAccType.SelectedValue),
                                                            int.Parse(userID),
                                                            ""
                                                            , decimal.Parse(txtLoan.Text)
                                                            , int.Parse(hdnAccTypeID.Value)
                                                            , loanAmount
                                                            , loanRate
                                                            , loanDate
                                                            , ysnCommulative
                                                            , commulativeDays
                                                            , gracePeriodinDays
                                                            , graceRate
                                                            , loanPeriodInYear
                                                            , installmentInYear
                                                          );

                    txtAccDes.Text = "";
                    txtAccName.Text = "";
                    txtAccNo.Text = "";
                    //txtAccountCode.Text = "";
                    GridView1.DataBind();

                }
                catch
                {
                    result = "Failed to Insert Account";
                }
                lblAccountAddNoti.Text = result;
                pnlScript.Visible = true;
                jsString = "ShowDiv('newAccountDiv','account')";
                pnlScript.DataBind();

                ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "add", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "add", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }

            protected void btnAcctypeAdd_Click(object sender, EventArgs e)
            {
                var fd = log.GetFlogDetail(start, location, "add", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\Bank\\BankInfo   BankInfo accounts Type Add", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    BankAccountType acctype = new BankAccountType();


                try
                {
                    result = acctype.AddBankAccountType(int.Parse(ddlBankName.SelectedValue), txtAccType.Text, txtDesAcctype.Text, int.Parse(userID), txtAccTypeShortCode.Text);
                    txtDesAcctype.Text = "";
                    txtAccType.Text = "";
                    ddlAccType.DataBind();


                }
                catch (Exception exp)
                {
                    result = exp.Message;
                }

                lblAccTypeNoti.Text = result;
                pnlScript.Visible = true;
                jsString = "ShowDiv('newAccTypeDiv','accType')";
                pnlScript.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            protected void Button1_Click(object sender, EventArgs e)
            {

            }
            protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
            {
                if (CheckBox2.Checked)
                {
                    ddlLoanType.Visible = true;
                }
                else
                {
                    ddlLoanType.Visible = false;
                }
            }
            protected void ddlAccType_SelectedIndexChanged(object sender, EventArgs e)
            {
                //LoanType lt = new LoanType();
                //string loanType=lt.GetLoanTypeID(int.Parse(ddlAccType.SelectedValue));
                //hdnAccTypeID.Value = loanType;
                SetTheAcctype();
            }
            protected void ddlAccType_DataBound(object sender, EventArgs e)
            {
                SetTheAcctype();
            }

            private void SetTheAcctype()
            {
                BLL.Accounts.Bank.LoanType lt = new BLL.Accounts.Bank.LoanType();
                string loanType = lt.GetLoanTypeID(int.Parse(ddlAccType.SelectedValue == "" ? "0" : ddlAccType.SelectedValue));
                hdnAccTypeID.Value = loanType;
            }
        }
    }
