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
            ddlUnit.Loads(dt, "intVatAccountID", "strVATAccountName");
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
            int vatAccountId = ddlUnit.SelectedValue();
            if (vatAccountId == 1022)
            {
                ddlShipPoint.UnLoad();
                ddlShipPoint.Items.Add(new ListItem("ATML", "3"));
                ddlShipPoint.Items.Add(new ListItem("ATMLWU", "21"));
                ddlShipPoint.Items.Add(new ListItem("ATMLDU", "55"));
                ddlShipPoint.Items.Add(new ListItem("ATMLFU", "56"));
            }
            else
            {
                dt = _vatObj.GetVatUnitByUser(Enroll);
                DataRow row = dt.GetRow("intVatAccountID", vatAccountId);
                if (row != null)
                {
                    int unitId = Convert.ToInt32(row["intUnitID"].ToString());
                    dt = _vatObj.GetShippingPoint(Enroll, unitId);
                    ddlShipPoint.LoadWithSelect(dt, "intShipPointId", "strName");
                }
            }
            
        }

        private void GetVatPointId()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intVatAccountID", ddlUnit.SelectedValue());
                int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
            }
        }
        public void LoadTransferCode()
        {
            int shippingPointId = ddlShipPoint.SelectedValue();

            if (int.Parse(ddlUnit.SelectedValue) == 1022)
            {
                dt = _vatObj.GetATMLTransferChallanList(shippingPointId);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else if(int.Parse(ddlUnit.SelectedValue) != 1022)
            {
                
                dt = _vatObj.GetVatUnitByUser(Enroll);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.GetRow<int>("intVatAccountID", ddlUnit.SelectedValue());
                    int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
                    dt = _vatObj.GetTransferbyVat(accountId, shippingPointId);
                    ddlChallan.LoadWithSelect(dt, "intId", "strCode");
                }
                else
                {
                    ddlChallan.UnLoad();
                }
            }
            else
            {
                ddlChallan.UnLoad();
            }

        }
        public void LoadSalesCode()
        {
            int shippingPointId = ddlShipPoint.SelectedValue();

            if (int.Parse(ddlUnit.SelectedValue) == 1022)
            {
                dt = _vatObj.GetATMLSalesChallanList(shippingPointId);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else if (int.Parse(ddlUnit.SelectedValue) != 1022)
            {
                dt = _vatObj.GetVatUnitByUser(Enroll);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.GetRow<int>("intVatAccountID", ddlUnit.SelectedValue());
                    int vatid = Convert.ToInt32(row["intVatPointID"].ToString());
                    dt = _vatObj.GetSalesByVAT(vatid);
                    ddlChallan.LoadWithSelect(dt, "intId", "strCode");
                }
                else
                {
                    ddlChallan.UnLoad();
                }
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
            btnSave.Visible = false;
            string vatPointId = string.Empty, challan,challan2, actualDeliveryDate, customerBinNo,finalAddress,vehicleNo,vatChallanNo,customerName;
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intVatAccountID", ddlUnit.SelectedValue());
                vatPointId = row["intVatPointID"].ToString();
            }
            challan = ddlChallan.SelectedText();
            if (ddlChallan.SelectedValue() == 0)
            {
                challan2 = txtChallanNo.Text;
                challan = "";
            }
            else
            {
                challan2 = "";
            }


            //actualDeliveryDate = null;
            //customerBinNo = txtCustomerBinNo.Text;
            try { finalAddress = txtFinalAddress.Text; }
            catch { finalAddress = ""; }
            
            //vehicleNo = txtVehicleNo.Text;
            //vatChallanNo = txtVatChallanNo.Text;
            //customerName = txtCustomerName.Text;
            if (ddlType.SelectedValue() == 1 )
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/VAT_Management/M-6.3" + "&VATPointID=" + vatPointId + "&Challan=" + challan + "&Challan2=" + challan2 + "&strFinalDistanitionAddress=" + finalAddress+ "&rc:LinkTarget=_self";

                //"&ActualDelivery=" + actualDeliveryDate + "&strCustVATRegNo=" + customerBinNo + "&strFinalDistanitionAddress=" + finalAddress + "&strVehicleRegNo=" + vehicleNo + "&intVatChallanNo=" + vatChallanNo + "&strCustomerName=" + customerName +
            }
            else if (ddlType.SelectedValue() == 2 )
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
            btnSave.Visible = true;
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