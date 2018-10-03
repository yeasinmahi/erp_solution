using HR_BLL.TourPlan;
using HR_DAL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class BrandItemChallanPrint : System.Web.UI.Page
    {
        protected StringBuilder sb = new StringBuilder();
        protected StringBuilder sbP = new StringBuilder();
        protected StringBuilder sbGT = new StringBuilder();
        protected StringBuilder sbT = new StringBuilder();

        TourPlanning bll = new TourPlanning();
        DataTable dt = new DataTable();
        string donum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string promItem = "";
                decimal count = 0, promCount = 0, total = 0, gross = 0;
                decimal? extAmount = 0;
                DateTime date = new DateTime();
                char separator = '-';
                char[] sep = { separator };
                string unitName = "", unitAddress = "", userName = ""
                    , challanNo = "", customerName = "", customerPhone = "", delevaryAddress = "", other = ""
                    , vehicle = "", extra = "", propitor = "", driver = "", driverPh = "", charge = "", logistic = "", incentive = "";




                TourPlanningTDS.SprBrandItemChallaninformationforPrintDataTable table = bll.GetData(Request.QueryString["id"], Session[SessionParams.USER_ID].ToString(), separator.ToString()
                    , ref date, ref unitName, ref unitAddress, ref userName
                    , ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref other
                    , ref vehicle,  ref propitor
                    , ref driver, ref driverPh, ref logistic );

                if (table.Rows.Count > 0)
                {
                    lblUnitName.Text = unitName.ToUpper();
                    //lblUnitName.Text = "United Dhaka Tobacco Company LTD.";
                    lblUnitAddr.Text = unitAddress;
                    lblDate.Text = CommonClass.GetShortDateAtLocalDateFormat(date);
                    lblTime.Text = CommonClass.GetTimeAtLocalDateFormat(date);
                    lblCusName.Text = customerName;
                    lblCusAddr.Text = delevaryAddress;
                    lblCusPhone.Text = customerPhone;
                    lblCusBuyer.Text = "";
                    lblChlNo.Text = challanNo;
                    lblVehicle.Text = vehicle;
                    lblCusBuyer.Text = propitor;
                    lblDriver.Text = driver;
                    lblDriverPhone.Text = driverPh;
                    lblNarration.Text = other;

                    imgCode.ImageUrl = "../../../Accounts/Print/BarCodeHandler.ashx?info=" + challanNo;
                    imgLogo.ImageUrl = "../../../Accounts/Print/Images/" + Request.QueryString["unit"] + ".png";

                    lblUnitName1.Text = unitName.ToUpper();
                    lblUnitAddr1.Text = unitAddress;
                    lblDate1.Text = CommonClass.GetShortDateAtLocalDateFormat(date);
                    lblTime1.Text = CommonClass.GetTimeAtLocalDateFormat(date);
                    lblCusName1.Text = customerName;
                    lblCusAddr1.Text = delevaryAddress;
                    lblCusPhone1.Text = customerPhone;
                    lblCusBuyer1.Text = "";
                    lblChlNo1.Text = challanNo;
                    lblVehicle1.Text = vehicle;
                    lblCusBuyer1.Text = propitor;
                    lblDriver1.Text = driver;
                    lblDriverPhone1.Text = driverPh;
                    lblNarration1.Text = other;

                    imgCode1.ImageUrl = "../../../Accounts/Print/BarCodeHandler.ashx?info=" + challanNo;
                    imgLogo1.ImageUrl = "../../../Accounts/Print/Images/" + Request.QueryString["unit"] + ".png";

                    sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    sbP.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    
                    dt = bll.GetData(Request.QueryString["id"], Session[SessionParams.USER_ID].ToString(), separator.ToString()
                    , ref date, ref unitName, ref unitAddress, ref userName
                    , ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref other
                    , ref vehicle, ref propitor
                    , ref driver, ref driverPh, ref logistic);
                    if (dt.Rows.Count > 0)
                    {
                        dgvBrandItemChDet.DataSource = dt; dgvBrandItemChDet.DataBind();
                        grdvGaecopy.DataSource = dt; grdvGaecopy.DataBind();
                        // total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Quantity"));
                        //decimal totalqntton = dt.AsEnumerable().Sum(row => row.Field<decimal>("decwgtton"));
                        //dgvdodtls.FooterRow.Cells[3].Text = "Total";
                        //dgvdodtls.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                        //dgvdodtls.FooterRow.Cells[4].Text = total.ToString("N2");
                        //dgvdodtls.FooterRow.Cells[5].Text = totalqntton.ToString("N2");
                        //dgvdodtls.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                        //dgvdodtls.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                        //decimal totalHO = dt.AsEnumerable().Sum(row => row.Field<decimal>("Quantity"));
                        //decimal totalqnttonho = dt.AsEnumerable().Sum(row => row.Field<decimal>("decwgtton"));


                    }

                    }
                }
        }

        protected void dgvBrandItemChDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvGaecopy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}