using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.VehicleRegRenewal_BLL;
using UI.ClassFiles;
namespace UI.Vehicle_Registration_Renewal
{
    public partial class Detalis_Insurance_UI : BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int updateby;string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                int enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (deptid == 11 || deptid == 8)
                {
                    btnApprove.Visible = true;
                }
                else if (deptid == 21 && enrol == 1259)
                {
                    btnApprove.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                }

                Int32 IDs = Convert.ToInt32(Session["AutoID"].ToString());
                dt = new DataTable();
                dt = objRenewal.RenewalDetalis(IDs);
                if (dt.Rows.Count > 0)
                {
                    TxtStrUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtVehicleName.Text = dt.Rows[0]["StrName"].ToString();
                    TxtRegistrationDate.Text = Convert.ToDateTime(dt.Rows[0]["dteRenewalDate"].ToString()).ToShortDateString();
                    TxtTolTaka.Text = dt.Rows[0]["monTotalTaka"].ToString();
                    //TxtNextExp.Text = dt.Rows[0]["dteNextSubmitDate"].ToString();
                   // TxtExpire.Text = dt.Rows[0]["dteExpireDate"].ToString();
                    TxtVehicleType.Text = dt.Rows[0]["strVehicleType"].ToString();
                }

                dt = new DataTable();
                dt = objRenewal.totalDetalisView(IDs);
                dgvDetalisdata.DataSource = dt;
                dgvDetalisdata.DataBind();
                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTaka"));
                dgvDetalisdata.FooterRow.Cells[1].Text = "Total";
                dgvDetalisdata.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                dgvDetalisdata.FooterRow.Cells[2].Text = total.ToString("N2");


            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 IDs = Convert.ToInt32(Session["AutoID"].ToString());
                bool val = true;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = objRenewal.UpdateAuditAprvStaus(val, updateby, IDs, deptid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "window.close()", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }
    }
}