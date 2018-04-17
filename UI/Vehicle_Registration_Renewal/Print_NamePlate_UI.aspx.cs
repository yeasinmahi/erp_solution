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
    public partial class Print_NamePlate_UI : BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Int32 IDs = Convert.ToInt32(Session["AutoID"].ToString());
                dt = new DataTable();
                dt = objRenewal.RenewalDetalis(IDs);
                if (dt.Rows.Count > 0)
                {
                    TxtStrUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtVehicleName.Text = dt.Rows[0]["StrName"].ToString();
                    // TxtRegistrationDate.Text = dt.Rows[0]["dteRenewalDate"].ToString();
                  
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
    }
}