using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using SAD_DAL.Customer;
using SAD_BLL.Customer;
using BLL.Accounts.ChartOfAccount;
using SAD_BLL.Item;
using UI.ClassFiles;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Customer
{
    public partial class CustomerInfoEdit : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Customer\\CustomerInfoEdit";
        string stop = "stopping SAD\\Customer\\CustomerInfoEdit";
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            hdnUnitId.Value = Request.QueryString["unt"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


            }
            else
            {
                //Session["sesUserID"] = "1";  

                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Customer\\CustomerInfoEdit  Customer info Edit", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    if (Request.QueryString["id"] != null)
                {
                    bool isPeriod;

                    SAD_BLL.Customer.CustomerInfo ci = new SAD_BLL.Customer.CustomerInfo();
                    CustomerTDS.TblCustomerDataTable table = ci.GetCustomerInfoById(Request.QueryString["id"]);
                    if (table.Rows.Count > 0)
                    {
                        isPeriod = table[0].IsysnPeriodicleCrLimNull() ? false : table[0].ysnPeriodicleCrLim;

                        txtCusName.Text = table[0].IsstrNameNull() ? "" : table[0].strName;
                        txtCusAddress.Text = table[0].IsstrAddressNull() ? "" : table[0].strAddress;

                        txtCRLimit.Text = table[0].IsmonCreditLimitNull() ? "0" : table[0].monCreditLimit.ToString();
                        txtDay.Text = table[0].IsintDaysOfCrLimNull() ? "0" : table[0].intDaysOfCrLim.ToString();

                        if (isPeriod)
                        {
                            txtCRLimit.Enabled = false;
                            txtDay.Enabled = true;
                            chkPeriod.Checked = true;
                        }
                        else
                        {
                            txtCRLimit.Enabled = true;
                            txtDay.Enabled = false;
                            chkPeriod.Checked = false;
                        }
                        txtCusPhone.Text = table[0].IsstrPhoneNull() ? "" : table[0].strPhone;
                        txtCusPropitor.Text = table[0].IsstrPropitorNull() ? "" : table[0].strPropitor;
                        txtEmail.Text = table[0].IsstrEmailAddressNull()? "" : table[0].strEmailAddress;
                        txtVATRegstration.Text = table[0].IsstrVatRegNoNull() ? "" : table[0].strVatRegNo;
                    }
                }
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
            }
        }


        protected void btnCusSave_Click(object sender, EventArgs e)
        {
            SAD_BLL.Customer.CustomerInfo cus = new SAD_BLL.Customer.CustomerInfo();
            if (Request.QueryString["id"] != null)
            {
                cus.UpdateCustomer(Request.QueryString["id"], int.Parse(hdnUnitId.Value), hdnGeoId.Value, txtCusName.Text.Trim(), txtCusAddress.Text, txtCusPhone.Text, decimal.Parse(txtCRLimit.Text), Request.QueryString["type"], Request.QueryString["so"], Session[SessionParams.USER_ID].ToString(), txtCusPropitor.Text, chkPeriod.Checked, int.Parse(txtDay.Text), txtEmail.Text, txtVATRegstration.Text);
            }
            else
            {
                cus.InsertCustomer(int.Parse(hdnUnitId.Value), hdnGeoId.Value, txtCusName.Text.Trim(), txtCusAddress.Text, txtCusPhone.Text, decimal.Parse(txtCRLimit.Text), Request.QueryString["type"], Request.QueryString["so"], Session[SessionParams.USER_ID].ToString(), txtCusPropitor.Text, chkPeriod.Checked, int.Parse(txtDay.Text), txtEmail.Text, txtVATRegstration.Text);
            }

            ChartOfAccStaticDataProvider.ReloadCOA(hdnUnitId.Value);
            CustomerInfoSt.ReloadCustomer(hdnUnitId.Value);

            Response.Redirect("~/Exit.aspx");
        }

        protected void chkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeriod.Checked)
            {
                txtCRLimit.Enabled = false;
                txtDay.Enabled = true;
                chkPeriod.Checked = true;
            }
            else
            {
                txtCRLimit.Enabled = true;
                txtDay.Enabled = false;
                chkPeriod.Checked = false;
            }
        }
    }
}