using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class BillFowardToBillingRpt : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

               
                dt = objPo.GetPoData(40, "", intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvBill.DataSource = "";
                dgvBill.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                lblWHs.Text = ddlWH.SelectedItem.ToString();
                string dept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept.ToString() + '"' + "/></voucher>".ToString();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objPo.GetPoData(41, xmlData ,intWh, 0, DateTime.Now, enroll);
                if(dt.Rows.Count>0)
                {
                    lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                    dgvBill.DataSource = dt;
                    dgvBill.DataBind();
                }
               
            }
            catch { }
        }
    }
}