using Dairy_BLL;
using HR_BLL.Cafeteria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Cafeteria
{
    public partial class CafeteriaService : BasePage
    {
        GlobalBLL obj = new GlobalBLL(); DataTable dt;

        int intPart, intEnroll, intType, intMealOption, intMealFor, intCountMeal, isOwnGuest, isPayable, intActionBy, intMenuid;
        string strNarration, strMenu, message;
        DateTime tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); 
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                PR.Checked = true; txtSearchEmp.Enabled = false;

                txtSearchEmp.Text = Session[SessionParams.USER_NAME].ToString() + "[" + Session[SessionParams.USER_ID].ToString() + "]";
                txtDesignation.Text = Session[SessionParams.DESIG_NAME].ToString();
                txtDept.Text = Session[SessionParams.DEPT_NAME].ToString();
                txtUnit.Text = Session[SessionParams.UNIT_NAME].ToString();
                txtJobType.Text = Session[SessionParams.JOBTYPE_NAME].ToString();
                txtJobStation.Text = Session[SessionParams.JOBSTATION_NAME].ToString();
                PB.Enabled = false; rdoOwn.Checked = true; rdoGuest.Enabled = false; btnMenu.Visible = false;
                if (hdnEnroll.Value == "1059" || hdnEnroll.Value == "283833" || hdnEnroll.Value == "1052" || hdnEnroll.Value == "1053" || hdnEnroll.Value == "1054" 
                    || hdnEnroll.Value == "11621" || hdnEnroll.Value == "1056" || hdnEnroll.Value == "1058" || hdnEnroll.Value == "11595"
                    || hdnEnroll.Value == "1062" || hdnEnroll.Value == "118506" || hdnEnroll.Value == "1447")
                { PB.Enabled = true; rdoGuest.Enabled = true; }
                if (hdnEnroll.Value == "283833" || hdnEnroll.Value == "1056" || hdnEnroll.Value == "11621" || hdnEnroll.Value == "11595" || hdnEnroll.Value == "118506") { btnMenu.Visible = true; }
                LoadGrid();
                intEnroll = int.Parse(hdnEnroll.Value.ToString());
                LoadMealStatus();               
            }
        }

        private void LoadMealStatus()
        {
            try
            {
                dt = new DataTable();
                dt = obj.GetMealStatus(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    intType = int.Parse(dt.Rows[0]["intType"].ToString());
                    if (intType == 1)
                    {
                        lblPresentStatus.Text = "You are now Regular......";
                    }
                    else
                    {
                        lblPresentStatus.Text = "Your meal status is Irregular....";
                    }
                }
                else
                {
                    lblPresentStatus.Text = "";
                }
            }
            catch { lblMealStatus.Text = ""; }
            
        }

        private void LoadGrid()
        {
            try
            {
                intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                intPart = 1;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealR.DataSource = dt;
                dgvMealR.DataBind();

                intPart = 2;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealAppr.DataSource = dt;
                dgvMealAppr.DataBind();
  
                dt = new DataTable();
                dt = obj.GetMenuList();
                dgvMenuList.DataSource = dt;
                dgvMenuList.DataBind();
                
            }
            catch { }
        }
        

        [WebMethod] [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }
        
        #region =============== Insert & Update Action ============================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intPart = 1;
                    tdate = DateTime.Parse(txtDate.Text);
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intEnroll = int.Parse(temp1[1].ToString());
                    intType = int.Parse(ddlType.SelectedValue.ToString());
                    //intMealOption = 1; //*** Use 1 For Public *** //int.Parse(ddlMeal.SelectedValue.ToString());                    
                    if (PB.Checked == true) { intMealOption = 1; } else { intMealOption = 0; }
                    try
                    {
                        intCountMeal = int.Parse(txtMealno.Text);
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input No. of Meal');", true); return; }
                    if (intCountMeal == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input No. of Meal');", true); return; }

                    isOwnGuest = 0;
                    if (rdoOwn.Checked == true) { intMealFor = 1; } else { intMealFor = 2; }                    
                    if (intMealFor == 1) { isPayable = 1; } else { isPayable = 0; }
                    intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    strNarration = txtRemark.Text;

                    //Final In Insert                        
                    string message = obj.InsertEntryCafeteria(intPart, tdate, intEnroll, intType, intMealOption, intMealFor, intCountMeal, isOwnGuest, isPayable, strNarration, intActionBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                    intPart = 1;
                    dt = new DataTable();
                    dt = obj.GetCateteriaR(intPart, intEnroll);
                    dgvMealR.DataSource = dt;
                    dgvMealR.DataBind();

                    intPart = 2;
                    dt = new DataTable();
                    dt = obj.GetCateteriaR(intPart, intEnroll);
                    dgvMealAppr.DataSource = dt;
                    dgvMealAppr.DataBind();

                    LoadMealStatus();
                }
                catch { }
            }
        }
        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(delimiterChars);

                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
                intType = int.Parse(ddlType.SelectedValue.ToString());
                intMealOption = 0; //int.Parse(ddlMeal.SelectedValue.ToString());
                if (rdoOwn.Checked == true) { intMealFor = 1; } else { intMealFor = 2; }
                intCountMeal = 0;
                isOwnGuest = 0;
                isPayable = 0;
                intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                strNarration = "";

                if (e.CommandName.Equals("CANCEL"))
                {
                    intPart = 2;
                    tdate = DateTime.Parse(data[0].ToString());
                    string message = obj.InsertEntryCafeteria(intPart, tdate, intEnroll, intType, intMealOption, intMealFor, intCountMeal, isOwnGuest, isPayable, strNarration, intActionBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                }
                else if (e.CommandName.Equals("UPDATE"))
                {
                    if (hdnconfirm.Value == "1")
                    {
                        if (dgvMenuList.Rows.Count > 0)
                        {
                            intPart = 3;
                            for (int i = 0; i < dgvMenuList.Rows.Count; i++)
                            {
                                intMenuid = int.Parse(((HiddenField)dgvMenuList.Rows[i].FindControl("hdnDayId")).Value.ToString());
                                strMenu = ((TextBox)dgvMenuList.Rows[i].FindControl("txtMenu")).Text.ToString();

                                message = obj.InsertEntryCafeteria(intPart, tdate, intMenuid, intType, intMealOption, intMealFor, intCountMeal, isOwnGuest, isPayable, strMenu, intActionBy);
                            }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            LoadGrid();
                        }
                    }
                }                
            }
            catch { }
        }

        #endregion ================================================================

        #region ============== Selection Change ===============================
        protected void txtSearchEmp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            try
            {
                dt = new DataTable();
                dt = obj.GetEmpInfo(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                    txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                    txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                    txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                }
                intPart = 1;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealR.DataSource = dt;
                dgvMealR.DataBind();

                intPart = 2;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealAppr.DataSource = dt;
                dgvMealAppr.DataBind();

                LoadMealStatus();
            }
            catch { }
        }
        protected void PR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PR.Checked = true; PB.Checked = false; txtSearchEmp.Enabled = false;
                txtSearchEmp.Text = Session[SessionParams.USER_NAME].ToString() + "[" + Session[SessionParams.USER_ID].ToString() + "]";
                txtDesignation.Text = Session[SessionParams.DESIG_NAME].ToString();
                txtDept.Text = Session[SessionParams.DEPT_NAME].ToString();
                txtUnit.Text = Session[SessionParams.UNIT_NAME].ToString();
                txtJobType.Text = Session[SessionParams.JOBTYPE_NAME].ToString();
                txtJobStation.Text = Session[SessionParams.JOBSTATION_NAME].ToString();

                intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                intPart = 1;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealR.DataSource = dt;
                dgvMealR.DataBind();

                intPart = 2;
                dt = new DataTable();
                dt = obj.GetCateteriaR(intPart, intEnroll);
                dgvMealAppr.DataSource = dt;
                dgvMealAppr.DataBind();

                LoadMealStatus();
            }
            catch { }
        }
        protected void PB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PR.Checked = false; PB.Checked = true; txtSearchEmp.Enabled = true;
                txtSearchEmp.Text = "";
                txtDesignation.Text = "";
                txtDept.Text = "";
                txtUnit.Text = "";
                txtJobType.Text = "";
                txtJobStation.Text = "";

                dgvMealR.DataSource = "";
                dgvMealR.DataBind();
                
                dgvMealAppr.DataSource = "";
                dgvMealAppr.DataBind();

                LoadMealStatus();
            }
            catch { }
        }
        protected void rdoOwn_CheckedChanged(object sender, EventArgs e)
        {
            rdoOwn.Checked = true; rdoGuest.Checked = false;
        }
        protected void rdoGuest_CheckedChanged(object sender, EventArgs e)
        {
            rdoGuest.Checked = true;  rdoOwn.Checked = false;
        }

        #endregion ===============================================================













    }
}