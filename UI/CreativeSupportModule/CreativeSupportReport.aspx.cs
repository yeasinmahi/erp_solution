using HR_BLL.CreativeSupport;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Dairy_BLL;
using SAD_BLL.Transport;
using System.Text;
using System.Text.RegularExpressions;

namespace UI.CreativeSupportModule
{
    public partial class CreativeSupportReport : BasePage
    {
        CreativeS_BLL objcr = new CreativeS_BLL();
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

                intReceiver = 11621;

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
            CreativeS_BLL objAutoSearch_BLL = new CreativeS_BLL();
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