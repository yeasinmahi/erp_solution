using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.SupplyChain;

namespace UI.SCM
{
    public partial class SupplierBlackListEntry : BasePage
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

        protected void dgvSuppliser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BL")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvSuppliser.Rows[rowIndex];

                try
                {
                    if (hdnconfirm.Value == "1")
                    {
                        try
                        {
                            intSuppMasterID = int.Parse((row.FindControl("lblSuppID") as Label).Text);
                            strBlockRemarks = (row.FindControl("txtBlockRemarks") as TextBox).Text;

                            if (strBlockRemarks == "")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Remarks cannot be blank.');", true);
                                return;
                            }

                            dt = new DataTable();
                            dt = obj.UpdateSupplierInBlock(int.Parse(hdnEnroll.Value), strBlockRemarks, intSuppMasterID);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Supplier Block Successfully.');", true);

                            LoadGrid();
                        }
                        catch { }
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            System.Threading.Thread.Sleep(1500);

            string searchkey = txtSupplier.Text;

            if (txtSupplier.Text != "")
            {
                dt = new DataTable();
                dt = obj.GetSupplierProfile(searchkey);
                dgvSuppliser.DataSource = dt;
                dgvSuppliser.DataBind();
            }
            else
            {
                dt = new DataTable();
                dt = obj.GetAllSupplierProfile();
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