using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.BOM
{
    public partial class ProductionReport : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId; private string xmlData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objBom.GetBomData(1, "", 0, 0, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
            }
            else { }
        }

        public void LoadGrid()
        {
            try
            {
                string dteFrom = txtFromDate.Text;
                string dteTo = txtToDate.Text;
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteDate = DateTime.Now;
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>";
                dt = objBom.GetBomData(6, xmlData, intwh, BomId, dteDate, Enroll);
                dgvBom.DataSource = dt;
                dgvBom.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnViewProductionOrder_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        protected void btnSaveProduction_Click(object sender, EventArgs e)
        {

        }
    }



}