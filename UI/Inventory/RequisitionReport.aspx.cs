using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class RequisitionReport : BasePage
    {
        DaysOfWeek req = new DaysOfWeek();
        DataTable dt = new DataTable();
        string month; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        #region=======================Requesition View========================
        protected void BtnShow_Click(object sender, EventArgs e)
        {
           
            try
            {
                string recode = TxtCode.Text.ToString();
                string sub2 = recode.Substring(0, 2);
                string subLast = recode.Substring(2, recode.Length-2);
                string year = subLast.Substring(0, 2);
                string lastdigit= subLast.Substring(2, subLast.Length - 2);
                if (sub2 == "01") { month = "Jan".ToString(); }
                else if (sub2 == "02") { month = "Feb".ToString(); }
                else if (sub2 == "03") { month = "Mar".ToString(); }
                else if (sub2 == "04") { month = "Apr".ToString(); }
                else if (sub2 == "05") { month = "May".ToString(); }
                else if (sub2 == "06") { month = "Jun".ToString(); }
                else if (sub2 == "07") { month = "Jul".ToString(); }
                else if (sub2 == "08") { month = "Aug".ToString(); }
                else if (sub2 == "09") { month = "Sep".ToString(); }
                else if (sub2 == "10") { month = "Oct".ToString(); }
                else if (sub2 == "11") { month = "Nov".ToString(); }
                else if (sub2 == "12") { month = "Dec".ToString(); }

                 recode = "REQ-" + month + year +"-" + lastdigit.ToString();

                dt = req.ReqDetailsByReqCode(recode);
                if (dt.Rows.Count>0)
                {
                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                }
                else
                {
                    dgvGridView.DataSource = ""; dgvGridView.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not Found.');", true);
                    
                }
            }
            catch { }
        }
        #endregion======================= Close ===============================
    }
}