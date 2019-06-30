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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadUnitList();
                LoadShipPoint();
                LoadChallanList();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }
        public void LoadUnitList()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            ddlUnit.Loads(dt, "intUnitID", "strVATAccountName");
        }
        public void LoadChallanList()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int vatid = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetChallanByVAT(vatid);
                ddlChallan.LoadWithSelect(dt, "strCode", "strName");
            }
            
            
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShipPoint();
        }

        protected void ddlShipPoint_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void LoadShipPoint()
        {
            int unitId = ddlUnit.SelectedValue();
            dt = _vatObj.GetShippingPoint(Enroll, unitId);
            ddlShipPoint.LoadWithSelect(dt, "intShipPointId", "strName");
        }

        public void LoadSalesCode()
        {
            int shippingPointId = ddlShipPoint.SelectedValue();
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetSalesCode(accountId, shippingPointId);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
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
                LoadChallanList();
            }
        }
    }
}