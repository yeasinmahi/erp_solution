using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PurchaserPermormance : BasePage
    {
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
              
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(43, xmlData, intWh, 0, dteFrom, enroll);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
            }
            catch { }
            
        }
    }
}