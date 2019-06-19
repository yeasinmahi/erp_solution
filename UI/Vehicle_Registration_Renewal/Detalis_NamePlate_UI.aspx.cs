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
    public partial class Detalis_NamePlate_UI : System.Web.UI.Page
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
                bool aprvpermission;
                dt = objRenewal.GetAssetAprvPermission(deptid);
                aprvpermission = Convert.ToBoolean(dt.Rows[0]["ysnpermissionallow"].ToString());

                if (aprvpermission == true)
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
                   // TxtRegistrationDate.Text = dt.Rows[0]["dteRenewalDate"].ToString();
                    TxtTolTaka.Text = dt.Rows[0]["monTotalTaka"].ToString();
                   // TxtNextExp.Text = dt.Rows[0]["dteNextSubmitDate"].ToString();
                    //TxtExpire.Text = dt.Rows[0]["dteExpireDate"].ToString();
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