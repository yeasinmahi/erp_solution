using System;
using System.Data;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.SupplyChain;

namespace UI.SCM
{
    public partial class SupplierBlackListReport : System.Web.UI.Page
    {
        private CSM obj = new CSM(); private DataTable dt;
        private int intSuppMasterID; private string strBlockRemarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                if (!IsPostBack)
                {
                }
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1500);
            LoadGrid();
        }

        private void LoadGrid()
        {
            string searchkey = txtSupplier.Text;

            if (txtSupplier.Text != "")
            {
                dt = new DataTable();
                dt = obj.GetSupplierProfileAllBlockList(searchkey);
                dgvSuppliser.DataSource = dt;
                dgvSuppliser.DataBind();
            }
            else
            {
                dt = new DataTable();
                dt = obj.GetSupplierProfileAllBlockList();
                dgvSuppliser.DataSource = dt;
                dgvSuppliser.DataBind();
            }
        }

        protected void dgvSuppliser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FEEC9C';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }
    }
}