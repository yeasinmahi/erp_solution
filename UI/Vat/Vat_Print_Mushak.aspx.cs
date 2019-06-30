using SAD_BLL.Vat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Vat
{
    public partial class Vat_Print_Mushak : BasePage
    {
        VAT_BLL _vatObj = new VAT_BLL();
        DataTable dt = new DataTable();
        private string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadUnitList();
                LoadShipPoint();
                LoadSalesCode();
            }
        }
        public void LoadUnitList()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            ddlUnit.Loads(dt, "intUnitID", "strVATAccountName");
        }
        

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShipPoint();
        }

        protected void ddlShipPoint_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlType.SetSelectedValue("0");
        }

        public void LoadShipPoint()
        {
            int unitId = ddlUnit.SelectedValue();
            dt = _vatObj.GetShippingPoint(Enroll, unitId);
            ddlShipPoint.LoadWithSelect(dt, "intShipPointId", "strName");
        }

        private void GetVatPointId()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
            }
        }
        public void LoadTransferCode()
        {
            int shippingPointId = ddlShipPoint.SelectedValue();
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetTransferbyVat(accountId, shippingPointId);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else
            {
                ddlChallan.UnLoad();
            }
            
        }
        public void LoadSalesCode()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int vatid = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetSalesByVAT(vatid);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else
            {
                ddlChallan.UnLoad();
            }
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int typeId = ddlType.SelectedValue();
            if (typeId == 1) //Sales
            {
                LoadSalesCode();
            }
            else if (typeId == 2) //Transfer
            {
                LoadTransferCode();
                
            }
            else
            {
                ddlChallan.UnLoad();
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string vatPointId = string.Empty, challan, actualDeliveryDate, customerBinNo,finalAddress,vehicleNo,vatChallanNo,customerName;
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                vatPointId = row["intVatPointID"].ToString();
            }
            challan = ddlChallan.SelectedText();
            if (ddlChallan.SelectedValue() == 0)
            {
                challan = txtChallanNo.Text;
            }

            actualDeliveryDate = txtActualDeliveryDate.Text;
            customerBinNo = txtCustomerBinNo.Text;
            finalAddress = txtFinalAddress.Text;
            vehicleNo = txtVehicleNo.Text;
            vatChallanNo = txtVatChallanNo.Text;
            customerName = txtCustomerName.Text;
            if (ddlType.SelectedValue() == 1)
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/VAT_Management/M-6.3" + "&VATPointID=" + vatPointId + "&Challan=" + challan + "&ActualDelivery=" + actualDeliveryDate + "&strCustVATRegNo=" + customerBinNo + "&strFinalDistanitionAddress=" + finalAddress + "&strVehicleRegNo=" + vehicleNo + "&intVatChallanNo=" + vatChallanNo + "&strCustomerName=" + customerName + "&rc:LinkTarget=_self";

            }
            else if (ddlType.SelectedValue() == 2)
            {
                string m11No, vatAc, vatYear ;
                int challanNo = ddlChallan.SelectedValue();
                if (ddlChallan.SelectedValue() == 0)
                {
                    challan = txtChallanNo.Text;
                    challanNo = _vatObj.GetChallnIdByCode(challan, ddlUnit.SelectedValue());
                }
                dt = _vatObj.GetMoshok6Info(challanNo, Enroll);
                if (dt.Rows.Count > 0)
                {
                    m11No = dt.Rows[0]["intM11gaNo"].ToString();
                    vatAc = dt.Rows[0]["intFromVatAc"].ToString();
                    vatYear = dt.Rows[0]["intVatYear"].ToString();
                    url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/VAT_Management/M-6.5" + "&M65=" + m11No + "&VATPointID=" + vatAc + "&intVATYear=" + vatYear + "&rc:LinkTarget=_self";
                }
                else
                {
                    Toaster("Getting information Error");
                }
                
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }

        protected void ddlChallan_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChallan.SelectedValue() == 0)
            {
                txtChallanNo.Enabled = true;
            }
            else
            {
                txtChallanNo.Enabled = false;
            }
            
        }
    }
}