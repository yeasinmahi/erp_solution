using BLL.Accounts.Advice;
using Flogging.Core;
using GLOBAL_BLL;
using Purchase_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class BankReceive : BasePage
    {
        DataTable dt;
        AdviceBLL bll = new AdviceBLL();
        Media obj = new Media();
        SeriLog log = new SeriLog();
        int intID, intUnitID, intEnroll, intAccountID, intCustomerID;
        DateTime dteStartDateTime, dteEndDateTime;
        string strUnitID, strNarration, strChequeNo, strCustomer, strRemarks, strDate;
        decimal monAmount, monCredit, monBalance;

        string location = "Accounts";
        string start = "starting Accounts\\Advice\\BankReceive";
        string stop = "stopping Accounts\\Advice\\BankReceive";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = obj.GetUnit(intEnroll);
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();

                }
                catch
                { }
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItem.DataSource = "";
            dgvItem.DataBind();
        }
        protected void dgvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Y")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = dgvItem.Rows[rowIndex];

                    intID = int.Parse((row.FindControl("lblID") as Label).Text);
                    intCustomerID = int.Parse((row.FindControl("ddlCustomer") as DropDownList).SelectedValue.ToString());
                    strCustomer = (row.FindControl("ddlCustomer") as DropDownList).SelectedItem.ToString();
                    strChequeNo = (row.FindControl("lblChequeNo") as Label).Text;
                    monAmount = decimal.Parse((row.FindControl("lblAmount") as Label).Text);
                    strDate = (row.FindControl("lblDate") as Label).Text;
                    strRemarks = (row.FindControl("txtRemarks") as TextBox).Text;
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intEnroll = int.Parse(hdnEnroll.Value);
                    strNarration = "Amount Received From " + strCustomer + " Cheque: " + strChequeNo + " Amount:" + monAmount + strRemarks + " Dated: " + strDate;

                    bll.InserBankReceive(intUnitID, intEnroll, intCustomerID, intID, strNarration);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Received Successfully.');", true);
                }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Somthing went wrong.');", true); }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                DropDownList ddlCustomer = (e.Row.FindControl("ddlCustomer") as DropDownList);
                dt = new DataTable();
                dt = bll.GetCustomerList(intUnitID);
                ddlCustomer.DataSource = dt;
                ddlCustomer.DataTextField = "CustomerName";
                ddlCustomer.DataValueField = "intCusID";
                ddlCustomer.DataBind();

                ddlCustomer.Items.Insert(0, new ListItem("Please Select Customer."));

            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Advice\\BankReceive Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                strUnitID = ddlUnit.SelectedValue.ToString();
                dt = new DataTable();
                dt = bll.GetBankData(strUnitID);
                dgvItem.DataSource = dt;
                dgvItem.DataBind();
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

    }
}