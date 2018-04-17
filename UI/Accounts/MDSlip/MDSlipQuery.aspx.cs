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
using DAL.Accounts.MDSlip;
using BLL.Accounts.MDSlip;
using UI.ClassFiles;

namespace UI.Accounts.MDSlip
{
    public partial class MDSlipQuery : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = 1;
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime date = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            MDSlipC slip = new MDSlipC();
            MDSlipTDS.SprAccountsMDSlipQueryDataDataTable tbl = slip.GetDataForMDAlipQuery(date, int.Parse(ddlUnit.SelectedValue), rbReceivePayment.SelectedValue);


            GridView1.DataSource = tbl;
            GridView1.DataBind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Voucher";
                e.Row.Cells[1].Text = "Narration";
                e.Row.Cells[2].Text = "Voucher Date";
                e.Row.Cells[3].Text = "Transaction Date";
                e.Row.Cells[4].Text = "Party Name";
                e.Row.Cells[5].Text = "Amount";
                //e.Row.Cells[0].Text = "Voucher";

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DateTime tmp = DateTime.Parse(e.Row.Cells[2].Text);
                e.Row.Cells[2].Text = tmp.Day + "-" + tmp.Month + "-" + tmp.Year;

                tmp = DateTime.Parse(e.Row.Cells[3].Text);
                e.Row.Cells[3].Text = tmp.Day + "-" + tmp.Month + "-" + tmp.Year;


                //e.Row.Cells[3].Text = "Transaction Date";
                //e.Row.Cells[4].Text = "Party Name";
                //e.Row.Cells[5].Text = "Amount";
                //e.Row.Cells[0].Text = "Voucher";

            }
        }
    }
}
