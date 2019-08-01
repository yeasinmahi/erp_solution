using SAD_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Customer
{
    public partial class AfblEmployeeLineChange : BasePage
    {
        #region Initialize
        SalesOffice objSalesOffice = new SalesOffice();
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                BindLine();
            }
        }
        protected void btnGetEnroll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEnroll.Text))
            {
                int empId = Convert.ToInt32(txtEnroll.Text.ToString());
                GetEmpInfo(empId);
            }
        }

        protected void btnChangeLine_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            int lineId = -1, empId=-1;

            if (!string.IsNullOrEmpty(ddlNewLine.SelectedValue))
                lineId = Convert.ToInt32(ddlNewLine.SelectedValue);
            if (!string.IsNullOrEmpty(txtEnroll.Text))
                empId = Convert.ToInt32(txtEnroll.Text.ToString());

            if (lineId > 0 && empId>0)
                UpdateLineInfo(empId, lineId);
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found For Update.');", true);
        }

        #endregion

        #region Method
        private void BindLine()
        {
            DataTable dtLine = new DataTable();
            dtLine = objSalesOffice.GetLineList();

            if (dtLine != null && dtLine.Rows.Count > 0)
            {
                ddlNewLine.DataSource = dtLine;
                ddlNewLine.DataTextField = "strFGGroupName";
                ddlNewLine.DataValueField = "intFGGroupID";
                ddlNewLine.DataBind();
            }
            //ddlNewLine.Items.Insert(0, new ListItem("--- Select ---", " "));
        }

        private void GetEmpInfo(int empID)
        {
            clearAll();
            DataTable dt = new DataTable();
            try
            {
                dt = objSalesOffice.GetEmpLineInfo(empID);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["strEmployeeName"] != null)
                        txtEmpname.Text = row["strEmployeeName"].ToString();
                    if (row["FGGroupName"] != null)
                        txtLineName.Text = row["FGGroupName"].ToString();
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Not Found');", true);
            }
            catch (Exception ex)
            {
                string msg = "EX ERROR : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        private void UpdateLineInfo(int empId, int LineId)
        {
            int insertby = Convert.ToInt32(hdnEnroll.Value);
            try
            {
                objSalesOffice.UpdateEmpLineInfo(LineId, empId, insertby);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);
                clearAll();
            }
            catch (Exception ex)
            {
                string msg = "EX ERROR : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            
        }

        private void clearAll()
        {
            txtEmpname.Text = string.Empty;
            txtLineName.Text = string.Empty;
        }
        #endregion
    }
}