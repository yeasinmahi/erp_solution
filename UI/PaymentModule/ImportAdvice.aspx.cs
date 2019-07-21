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

namespace UI.PaymentModule
{
    public partial class ImportAdvice :BasePage
    {
        private DataTable _dt;
        private ImportAdviceBll _bll = new ImportAdviceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime today = DateTime.Now;
                txtDate.Text = new DateTime(today.Year, today.Month, 1).ToString("yyyy/MM/dd");
                LoadUnit();
                LoadBank();
                LoadAdvice();
            }
        }

        public void LoadUnit()
        {
            _dt = _bll.GetUnit();
            ddlUnit.Loads(_dt, "intUnitID", "strDescription");
        }
        public void LoadBank()
        {
            _dt = _bll.GetBank();
            ddlbank.Loads(_dt, "intBankID", "strBankName");
        }
        public void LoadAdvice()
        {
            int unitId = ddlUnit.SelectedValue();
            int bankId = ddlbank.SelectedValue();
            string fromDate = txtDate.Text;
            string toDate = DateTime.Now.ToString("yyyy/MM/dd");
            _dt = _bll.GetAdvice(unitId,bankId,fromDate,toDate);
            ddlAdvice.Loads(_dt, "strAdviceGroup", "strAdviceGroup");
        }
        
        protected void btnShow_Click(object sender, EventArgs e)
        {

        }
        public void LoadGrid()
        {
            _dt = _bll.GetUnit();
            
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvice();
        }

        protected void ddlbank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvice();
        }
    }
}