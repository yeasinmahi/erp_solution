using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class SupplierAccountInfoChange : BasePage
    {
        InventoryTransfer_BLL objBll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string RequesterName, RequesterDesignation, SupplierName, SupplierAddress, RoutingNo,msg;
            int AccountNo, RequestBy, SuperviseBy;
            DateTime dteRequestBy, dteSuperviseBy;

            RequesterName = txtRequesterName.Text;
            RequesterDesignation = txtRequesterDesignation.Text;
            SupplierName = txtSupplierName.Text;
            SupplierAddress = txtSupplierAddress.Text;
            RoutingNo = txtRoutingNo.Text;
            AccountNo = Convert.ToInt32(txtAccountNo.Text);
            RequestBy=Convert.ToInt32(txtRequestBy.Text);
            SuperviseBy=Convert.ToInt32(txtSuperviseBy.Text);
            dteRequestBy = DateTime.Parse(txtRequestDate.Text);
            dteSuperviseBy = DateTime.Parse(txtApproveDate.Text);
            msg = objBll.InsertSupplierAccountsInfoList(RequesterName, RequesterDesignation, SupplierName, SupplierAddress, AccountNo, RoutingNo, RequestBy, SuperviseBy, dteRequestBy, dteSuperviseBy);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            ClearControl();
        }
        private void ClearControl()
        {
            txtRequesterName.Text = "";
            txtRequesterDesignation.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtRoutingNo.Text = "";
            txtAccountNo.Text = "";
            txtRequestBy.Text = "";
            txtSuperviseBy.Text = "";
            txtRequestDate.Text = "";
            txtApproveDate.Text = "";
        }
    }
}