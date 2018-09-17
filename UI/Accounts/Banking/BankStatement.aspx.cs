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
using BLL.Accounts.Banking;
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;


namespace UI.Accounts.Banking
{
    public partial class BankStatement : BasePage
    {
        //ReportDocument rd = new ReportDocument();
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\BankStatement";
        string stop = "stopping Accounts\\Banking\\BankStatement";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "7";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {

            }
        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void btnRemove_Click(object sender, EventArgs e)
        { var fd = log.GetFlogDetail(start, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\BankStatement Bank Statement Remove ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                BLL.Accounts.Banking.BankStatement bs = new BLL.Accounts.Banking.BankStatement();
            bs.CancelAutoReconcile(((Button)sender).CommandArgument);
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Cancel", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
        }

        protected string GetValue(object val, bool isDr)
        {
            decimal val_ = decimal.Parse(val.ToString());

            if (isDr && val_ < 0) return CommonClass.GetFormettingNumber(Math.Abs(val_));
            if (isDr && val_ > 0) return "";
            if (!isDr && val_ < 0) return "";
            if (!isDr && val_ > 0) return CommonClass.GetFormettingNumber(Math.Abs(val_));
            else return "";
        }
    }

}