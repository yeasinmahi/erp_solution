using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.IO;


namespace UI.Asset
{
    public partial class Vehicle_Bill_Detalis_PopUp : BasePage
    {
        AssetMaintenance objBill = new AssetMaintenance();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 Mnumber = Convert.ToInt32(Session["intMaintenanceNo"].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


                intItem = 58;
                dt = objBill.ReportDetalisParts(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvPartsView.DataSource = dt;
                dgvPartsView.DataBind();
                decimal total1 = dt.AsEnumerable().Sum(row => row.Field<decimal>("monValue"));
                dgvPartsView.FooterRow.Cells[3].Text = "Total".ToString();
                dgvPartsView.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                dgvPartsView.FooterRow.Cells[4].Text = total1.ToString("N2");
            

                dt = new DataTable();
                intItem = 59;
                dt = objBill.ReportDetalisPerformer(intItem, Mnumber, intenroll, intjobid, intdept);
                DgvPerformer.DataSource = dt;
                DgvPerformer.DataBind();

                dt = new DataTable();

                intItem = 62;
                dt = objBill.MaintenanceBillServiceCharge(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvServiceCharge.DataSource = dt;
                dgvServiceCharge.DataBind();
                decimal total2 = dt.AsEnumerable().Sum(row => row.Field<decimal>("monServiceCost"));
                dgvServiceCharge.FooterRow.Cells[2].Text = "Total";
                dgvServiceCharge.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                dgvServiceCharge.FooterRow.Cells[3].Text = total2.ToString("N2");

                dt = new DataTable();
                dt = objBill.ACWownBillingUnit();
                DdlAcwOwn.DataSource = dt;
                DdlAcwOwn.DataTextField = "strUnit";
                DdlAcwOwn.DataValueField = "intAutoID";
                DdlAcwOwn.DataBind();

                dt = new DataTable();
                dt = objBill.InterCompanyBillunit();
                DdlInterCompany.DataSource = dt;
                DdlInterCompany.DataTextField = "strUnit";
                DdlInterCompany.DataValueField = "intAutoID";
                DdlInterCompany.DataBind();



                dt = new DataTable();
                intItem = 61;
                dt = objBill.MaintenanceBillAssetDetalis(intItem, Mnumber, intenroll, intjobid, intdept);
                if (dt.Rows.Count > 0)
                {
                    TxtPresentMilege.Text = dt.Rows[0]["strPresentMilege"].ToString();
                    TxtNextMilege.Text = dt.Rows[0]["strNextMilege"].ToString();
                    TxtProblem.Text = dt.Rows[0]["problem"].ToString();
                   // Ddljobstation.Text = dt.Rows[0][""].ToString();
                    TxtDeliveyDate.Text = dt.Rows[0]["dteEndDate"].ToString();
                    TxtCompany.Text = dt.Rows[0]["strJobStationName"].ToString();
                    TxtEntanceDate.Text = dt.Rows[0]["dteStartDate"].ToString();
                    TxtModel.Text = dt.Rows[0]["model"].ToString();
                    TxtJobNo.Text = dt.Rows[0]["intMaintenanceNo"].ToString();
                    TxtVehicleNo.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                }


            }
        }
    }
}