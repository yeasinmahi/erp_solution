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
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI.Accounts.Bank
{
    public partial class ChequeBook : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Bank\\ChequeBook";
        string stop = "stopping Accounts\\Bank\\ChequeBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtStart.Attributes.Add("onchange", "Write();");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Add", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Bank\\ChequeBook   Cheque Book Add", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (txtStart.Text != "" && txtEnd.Text != "")
            {
                BankCheck bc = new BankCheck();
                bc.CheckBookAdd(ddlAccount.SelectedValue, txtStart.Text, txtEnd.Text, Session["sesUserID"].ToString());
                GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Add", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Add", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlAccount_DataBound(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        { var fd = log.GetFlogDetail(start, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Bank\\ChequeBook   Cheque Book Cancel", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnChq.Value != "")
            {
                BankCheck bc = new BankCheck();
                bc.CheckCancel(Session["sesUserID"].ToString(), txtCancel.Text, hdnChq.Value, true, txtNote.Text, ddlAccount.SelectedValue);

                GridView1.DataBind();
                }
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

        public string GetLastUsedChequeNo(object leftPart, object lastUsedNum, object endNum)
        {
            string ret = leftPart.ToString();

            for (int i = 0; i < (endNum.ToString().Length - lastUsedNum.ToString().Length); i++)
            {
                ret = ret + "0";
            }

            ret = ret + lastUsedNum.ToString();

            return ret;
        }
        protected void rdoActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoActive.SelectedIndex == 0)
            {
                GridView1.Columns[5].Visible = true;
                GridView1.Columns[6].Visible = true;
            }
            else if (rdoActive.SelectedIndex == 1)
            {
                GridView1.Columns[5].Visible = false;
            }
            else
            {
                GridView1.Columns[4].Visible = false;
                GridView1.Columns[5].Visible = false;
                GridView1.Columns[6].Visible = false;
            }
        }
    }
}
