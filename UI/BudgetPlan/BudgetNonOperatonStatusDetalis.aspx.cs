using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Budget_BLL;
using Budget_BLL.Budget;

namespace UI.BudgetPlan
{

    public partial class BudgetNonOperatonStatusDetalis : System.Web.UI.Page
    {
        BudgetOperation_BLL objReport = new BudgetOperation_BLL();
        DataTable dt = new DataTable();
        int item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int OperationID = Int32.Parse(Session["intID"].ToString());
                dt = new DataTable();
                item = 4;
                dt = objReport.OperationdetalisReport(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                dgvOperation.DataSource = dt;
                dgvOperation.DataBind();
                dt = new DataTable();
                item = 5;
                dt = objReport.ConstingSectorReport(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                dgvCostingsector.DataSource = dt;
                dgvCostingsector.DataBind();
                if (dt.Rows.Count > 0) { Label1.Text = dt.Rows[0]["years"].ToString(); }

                dt = new DataTable();
                item = 7;
                dt = objReport.BudgereqEmployee(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                DgvPerformer.DataSource = dt;
                DgvPerformer.DataBind();
                item = 8;
                dt = objReport.BudgereqItems(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                dgvItems.DataSource = dt;
                dgvItems.DataBind();

                item = 9;
                dt = objReport.BudgereqTools(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                dgvTools.DataSource = dt;
                dgvTools.DataBind();

                item = 10;
                dt = objReport.BudgereqExpance(item, 0, 0, 0, 0, 0, 0, 0, OperationID, 0, 0, 0);
                dgvExpance.DataSource = dt;
                dgvExpance.DataBind();
            }

        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {

            Response.Redirect("BudgetPlanning_Requesition.aspx", true);

        }
    }
}