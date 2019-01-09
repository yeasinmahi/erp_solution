using System;
using System.Data;
using UI.ClassFiles;
using SCM_BLL;

namespace UI.SCM
{
    public partial class ProductReport : BasePage
    {
        private MasterMaterialBLL bll = new MasterMaterialBLL(); private DataTable dt;
        private int intInsertBy, intPart, intWHID, intGroupID, intCategoryID;
        private string strSearchText;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    intPart = 1;
                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intPart, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataSource = dt;
                    ddlWH.DataBind();
                }
                catch { }
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchText.Text = "";
                dgvInvnetory.DataSource = "";
                dgvInvnetory.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                strSearchText = txtSearchText.Text;
                dt = new DataTable();
                dt = bll.GetItemListReport(strSearchText);
                dgvInvnetory.DataSource = dt;
                dgvInvnetory.DataBind();
            }
            catch { }
        }
    }
}