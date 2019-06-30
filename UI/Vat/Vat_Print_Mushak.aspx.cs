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
            DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
            int vatid = Convert.ToInt32(row["intVatPointID"].ToString());
            dt = _vatObj.GetChallanByVAT(vatid);
            ddlChallan.LoadWithSelect(dt, "strCode", "strName");
            
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadChallanList();
        }
    }
}