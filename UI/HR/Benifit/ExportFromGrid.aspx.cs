using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Benifit
{
    public partial class ExportFromGrid : BasePage
    {
        HR_BLL.Benifit.Bonus_BLL bll = new HR_BLL.Benifit.Bonus_BLL();
        ExportToExcelClass cll = new ExportToExcelClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");}
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExcell);

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bll.GetExcellProfile();
                dgvSummary.DataSource = dt; dgvSummary.DataBind();
            }
            catch { }
        }

        protected void btnExcell_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSummary.AllowPaging = false; dgvSummary.AllowSorting = false;
                ExportToExcelClass.Export("ExcellFile.xls", dgvSummary);
            }
            catch { }
        }
    }
}