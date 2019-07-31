using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

using System.Web.Script.Services;
using System.Web.Services;

using HR_BLL.Employee;

namespace UI.HR.Employee
{
    public partial class AJMLEmployeeProfile : Page
    {
        DataTable dt = new DataTable();
        CustomerGeo obj = new CustomerGeo();
        int LineId, RegionId, AreaId, TerritoryId, PointId, ProductId, ProductUOM,unitid,enroll,costid;
        EmpCostCenterBLL objCost = new EmpCostCenterBLL();
        decimal Qtypcs, Qty;
        DateTime Date;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Common_Reports/HR_Report/AJMLEmpProfile?rs:Embed=true');", true);

            }
        }

       
    }
}