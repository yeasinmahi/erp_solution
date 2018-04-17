using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.WoodPurchase
{
    public partial class WoodReceiveDetails : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        int intPOID, intReceiveId;
        string strDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //

                    BindPOlist();
                    
                }
            }
            catch { }
        }

        private void BindPOlist()
        {
            try
            {
                dt = new DataTable();
                dt = bll.GetPOForDetails();
                ddlPOList.DataSource = dt;
                ddlPOList.DataTextField = "strSupplierName";
                ddlPOList.DataValueField = "intPOID";
                ddlPOList.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlPOList.SelectedIndex >= 0 && txtReceiveDate.Text != "")
                {
                    LoadGrid();
                }
            }
            catch { }
        }

        private void LoadGrid()
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                strDate = txtReceiveDate.Text;

                dt = new DataTable();
                dt = bll.GetReportForEdit(intPOID, strDate);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                intReceiveId = int.Parse(searchKey[0]);

                bll.InactiveByReceiveID(intReceiveId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Removed.');", true);

                LoadGrid();
            }
            catch { }
        }

        protected void ddlPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvReceive.DataSource = "";
                dgvReceive.DataBind();
            }
            catch { }
        }
    }
}