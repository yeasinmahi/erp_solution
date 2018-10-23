using HR_BLL.CreativeSupport;
using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.CreativeSupportModule
{
    public partial class CreativeSupportReport : BasePage
    {
        CreativeSBll objcr = new CreativeSBll();
        DataTable dt;

        int intPart, intReceiver;
        DateTime dteFrom, dteTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    
                }
                catch (Exception ex) { throw ex; }
            }
        }

        private void LoadGrid()
        {
            try
            {
                intPart = 1;
                dteFrom = DateTime.Parse(txtFrom.Text);
                dteTo = DateTime.Parse(txtTo.Text);

                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intReceiver = int.Parse(temp1[3].ToString());
                }
                catch { intReceiver = 0; }
                
                dt = objcr.GetAllReport(intPart, intReceiver, dteFrom, dteTo);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch (Exception ex) { throw ex; }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmpListForCreativeSupportList(string prefixText)
        {
            CreativeSBll objAutoSearch_BLL = new CreativeSBll();
            return objAutoSearch_BLL.AutoEmpListForCreativeSupport(prefixText);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected decimal grandtpoint = 0;
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    grandtpoint += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblPoint")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }













































    }
}