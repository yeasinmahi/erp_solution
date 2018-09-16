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
using System.Text;
using BLL.Accounts.Voucher;
using BLL.Accounts.Banking;
using UI.ClassFiles;
using GLOBAL_BLL;

namespace UI.Accounts.Banking
{
    public partial class ChequeRegister : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\ChequeRegister";
        string stop = "stopping Accounts\\Banking\\ChequeRegister";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            CollectIds();
            if (hdnIds.Value != "" || hdnConIds.Value != "")
            {
                VoucherForChqPrint bv = new VoucherForChqPrint();
                bv.ChequeRegisterPrinted(hdnIds.Value, hdnConIds.Value);
            }

            GridView1.DataBind();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            CollectIds();

        }

        private void CollectIds()
        {
            StringBuilder ids = new StringBuilder();
            StringBuilder conIds = new StringBuilder();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow && GridView1.Rows[i].Cells[0].Text != "")
                {
                    if (GridView1.Rows[i].Cells[1].Text.ToLower().StartsWith("b"))
                    {
                        if (ids.ToString() == "")
                        {
                            ids.Append(GridView1.Rows[i].Cells[0].Text);
                        }
                        else
                        {
                            ids.Append("," + GridView1.Rows[i].Cells[0].Text);
                        }
                    }
                    else if (GridView1.Rows[i].Cells[1].Text.ToLower().StartsWith("c"))
                    {
                        if (conIds.ToString() == "")
                        {
                            conIds.Append(GridView1.Rows[i].Cells[0].Text);
                        }
                        else
                        {
                            conIds.Append("," + GridView1.Rows[i].Cells[0].Text);
                        }
                    }
                }
            }

            if (ids.ToString() != "") hdnIds.Value = ids.ToString();
            if (conIds.ToString() != "") hdnConIds.Value = conIds.ToString();
        }
        protected void ddlBranchName_DataBound(object sender, EventArgs e)
        {
            ddlAccNo.DataBind();
        }
        protected void ddlAccNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void ddlAccNo_DataBound(object sender, EventArgs e)
        {
            //GridView1.DataBind();
        }
    }
}
