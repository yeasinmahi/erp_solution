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
    public partial class AfblEmployeeSearch : System.Web.UI.Page
    {
        #region Initialize
        SalesOffice objSalesOffice = new SalesOffice();

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownData();
            }
        }

        #endregion

        #region Method
        private void FillDropDownData()
        {
            DataTable dtEnroll = new DataTable();
            dtEnroll = objSalesOffice.GetAfblEmployeeEnroll();

            if (dtEnroll != null && dtEnroll.Rows.Count > 0)
            {
                ddlEnroll.DataSource = dtEnroll;
                ddlEnroll.DataTextField = "strEmployeeID";
                ddlEnroll.DataValueField = "intEmployeeID";
                ddlEnroll.DataBind();
            }
            ddlEnroll.Items.Insert(0, new ListItem("--- Select ---", " "));
        }


        #endregion

        protected void ddlEnroll_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            int empId = 0;
            if (!string.IsNullOrEmpty(ddlEnroll.SelectedValue))
            {
                empId = Convert.ToInt32(ddlEnroll.SelectedValue);
                GetEmpInfo(empId);
            }
        }

        private void GetEmpInfo(int employeeId)
        {
            DataTable dt = new DataTable();
            int levelid = -1;
            int geoID = 0;
            try
            {
                dt = objSalesOffice.GetAfblSalesEmpInfo(employeeId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["strEmployeeName"] != null)
                        txtEmpName.Text = row["strEmployeeName"].ToString();
                    if (row["dteResign"] != null)
                        txtResignDte.Text = DateTime.Parse(dt.Rows[0]["dteResign"].ToString()).ToString("yyyy/MM/dd");
                    //txtResignDte.Text = row["dteResign"].ToString();
                    if (row["strDesignation"] != null)
                        txtDesignation.Text = row["strDesignation"].ToString();
                }
                if (!string.IsNullOrEmpty(txtEmpName.Text))
                {
                    dt = objSalesOffice.GetSalesEmpFGInfo(employeeId);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        if (row["intFGGroupID"] != null)
                            txtLine.Text = row["intFGGroupID"].ToString();
                        if (row["intGeoID"] != null)
                            geoID = Convert.ToInt32(row["intGeoID"].ToString());
                        if (row["intLevelID"] != null)
                            levelid = Convert.ToInt32(row["intLevelID"].ToString());
                    }
                    else
                    {
                        btnResign.Visible = false;
                        string errMsg = "Update employee GeoSetup Info.";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
                        return;
                    }

                    if(levelid == 4)
                    {
                        dt = objSalesOffice.GetSalesEmpGeoInfo(employeeId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            if (row["strRegion"] != null)
                                txtRegion.Text = row["strRegion"].ToString();
                            if (row["strArea"] != null)
                                txtArea.Text = (row["strArea"].ToString());
                            if (row["strTerritory"] != null)
                                txtTerrotory.Text =(row["strTerritory"].ToString());
                            if (row["strPoint"] != null)
                                txtPoint.Text = row["strPoint"].ToString();
                        }
                    }
                    else if (levelid == 3)
                    {
                        dt = objSalesOffice.GetTerrSalesEmpGeoInfo(employeeId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            if (row["strRegion"] != null)
                                txtRegion.Text = row["strRegion"].ToString();
                            if (row["strArea"] != null)
                                txtArea.Text = (row["strArea"].ToString());
                            if (row["strTerritory"] != null)
                                txtTerrotory.Text = (row["strTerritory"].ToString());                           
                        }
                    }
                    else if (levelid == 2)
                    {
                        dt = objSalesOffice.GetAreaSalesEmpGeoInfo(employeeId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            if (row["strRegion"] != null)
                                txtRegion.Text = row["strRegion"].ToString();
                            if (row["strArea"] != null)
                                txtArea.Text = (row["strArea"].ToString());                           
                        }
                    }
                    else if (levelid == 1)
                    {
                        dt = objSalesOffice.GetRegionSalesEmpGeoInfo(employeeId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            if (row["strRegion"] != null)
                                txtRegion.Text = row["strRegion"].ToString();                            
                        }
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Information Not Found');", true);
            }
            catch (Exception ex)
            {
                string msg = "EX ERROR : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            btnResign.Visible = true;
            txtEmpName.Text = string.Empty;
            txtResignDte.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtLine.Text = string.Empty;
            txtRegion.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtTerrotory.Text = string.Empty;
            txtPoint.Text = string.Empty;
        }

        protected void btnResign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResignDte.Text))
                UpdateResign();
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Resign Date Not Found');", true);
        }

        private void UpdateResign()
        {
            DataTable dt = new DataTable();
            int empId = 0;
            DateTime resignDate;
            try
            {
                empId = Convert.ToInt32(ddlEnroll.SelectedValue);
                resignDate = CommonClass.GetDateAtSQLDateFormat(txtResignDte.Text).Date;
                dt = objSalesOffice.UpdateEmpResignDate(empId, resignDate);
            }
            catch (Exception ex)
            {
                string msg = "EX ERROR : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            
        }
    }
}