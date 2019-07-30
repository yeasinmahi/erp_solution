using HR_BLL.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Employee
{
    public partial class EmployeeTransferNpromotion : System.Web.UI.Page
    {
        #region INIT
        EmployeeTransferNpromotionBLL objBLL = new EmployeeTransferNpromotionBLL();
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
            }
        }
        #endregion

        #region Event
        protected void tabNewEmpTransfer_Click(object sender, EventArgs e)
        {

            try
            {
                tabNewEmpTransfer.CssClass = "Clicked";
                tabEmpPromotion.CssClass = "Initial";
                tabOldEmpTransfer.CssClass = "Initial";
                tabOldEmpResign.CssClass = "Initial";

                mainView.ActiveViewIndex = 0;

                TabClear(1);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabEmpPromotion_Click(object sender, EventArgs e)
        {
            try
            {
                tabNewEmpTransfer.CssClass = "Initial";
                tabEmpPromotion.CssClass = "Clicked";
                tabOldEmpTransfer.CssClass = "Initial";
                tabOldEmpResign.CssClass = "Initial";

                mainView.ActiveViewIndex = 1;

                TabClear(2);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabOldEmpTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                tabNewEmpTransfer.CssClass = "Initial";
                tabEmpPromotion.CssClass = "Initial";
                tabOldEmpTransfer.CssClass = "Clicked";
                tabOldEmpResign.CssClass = "Initial";

                mainView.ActiveViewIndex = 2;

                TabClear(3);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabOldEmpResign_Click(object sender, EventArgs e)
        {
            try
            {
                tabNewEmpTransfer.CssClass = "Initial";
                tabEmpPromotion.CssClass = "Initial";
                tabOldEmpTransfer.CssClass = "Initial";
                tabOldEmpResign.CssClass = "Clicked";

                mainView.ActiveViewIndex = 3;

                TabClear(4);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }

        #region New Employee Transfer
        protected void ddlNETDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(ddlNETDesignation.SelectedValue) > 0)
                {
                    ETAccess(ddlNETDesignation.SelectedIndex);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Any Designation!');", true);
                }
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Designation : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlNETRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlNETRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlNETRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlNETArea.DataSource = dtr;
                        ddlNETArea.DataTextField = "Name";
                        ddlNETArea.DataValueField = "ID";
                        ddlNETArea.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Any Region!');", true);
                }
                ddlNETArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlNETArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlNETTerritory.Items.Clear();
                if (int.Parse(ddlNETArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlNETArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlNETTerritory.DataSource = dtt;
                        ddlNETTerritory.DataTextField = "Name";
                        ddlNETTerritory.DataValueField = "ID";
                        ddlNETTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Any Area!');", true);
                }
                ddlNETTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlNETTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlNETPoint.Items.Clear();
                if (int.Parse(ddlNETTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlNETTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlNETPoint.DataSource = dtp;
                        ddlNETPoint.DataTextField = "Name";
                        ddlNETPoint.DataValueField = "ID";
                        ddlNETPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Any TSM!');", true);
                }
                ddlNETPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlNETPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtNETEnroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNETEnroll.Text))
                {
                    int enroll = int.Parse(txtNETEnroll.Text.Trim());
                    string emp = objBLL.GetEmpNameByEnroll(enroll);
                    txtNETEmpName.Text = emp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enroll Textbox Null');", true);
                }


            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Enroll : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnNETUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (NETValidation() == true)
                {
                    if (hfConfirm.Value == "1")
                    {
                        bool result = NewEmployeeTransfer();
                        if (result == true)
                        {
                            
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('New Employee Transfer Data Update Successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Failed to Update New Employee Transfer.');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Employee Transfer Cancel Successfully.');", true);
                    }
                    NETClear();
                }
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Update Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region  Employee Promotion
        protected void ddlEPoldDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(ddlEPoldDesignation.SelectedValue) > 0)
                {
                    EPAccess(ddlEPoldDesignation.SelectedIndex);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Designation!');", true);
                }
                
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Old Designation : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPoldRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlEPoldRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlEPoldRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlEPoldArea.DataSource = dtr;
                        ddlEPoldArea.DataTextField = "Name";
                        ddlEPoldArea.DataValueField = "ID";
                        ddlEPoldArea.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Region!');", true);
                }
                ddlEPoldArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Old Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPnewRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlEPnewRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlEPnewRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlEPnewArea.DataSource = dtr;
                        ddlEPnewArea.DataTextField = "Name";
                        ddlEPnewArea.DataValueField = "ID";
                        ddlEPnewArea.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected New Region!');", true);
                }
                ddlEPnewArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion New Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPoldArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlEPoldTerritory.Items.Clear();
                if (int.Parse(ddlEPoldArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlEPoldArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlEPoldTerritory.DataSource = dtt;
                        ddlEPoldTerritory.DataTextField = "Name";
                        ddlEPoldTerritory.DataValueField = "ID";
                        ddlEPoldTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Area!');", true);
                }
                ddlEPoldTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPnewArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlEPnewTerritory.Items.Clear();
                if (int.Parse(ddlEPnewArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlEPnewArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlEPnewTerritory.DataSource = dtt;
                        ddlEPnewTerritory.DataTextField = "Name";
                        ddlEPnewTerritory.DataValueField = "ID";
                        ddlEPnewTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected New Area!');", true);
                }
                ddlEPnewTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPoldTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlEPoldPoint.Items.Clear();
                if (int.Parse(ddlEPoldTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlEPoldTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlEPoldPoint.DataSource = dtp;
                        ddlEPoldPoint.DataTextField = "Name";
                        ddlEPoldPoint.DataValueField = "ID";
                        ddlEPoldPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected TSM!');", true);
                }
                ddlEPoldPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPnewTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlEPnewPoint.Items.Clear();
                if (int.Parse(ddlEPnewTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlEPnewTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlEPnewPoint.DataSource = dtp;
                        ddlEPnewPoint.DataTextField = "Name";
                        ddlEPnewPoint.DataValueField = "ID";
                        ddlEPnewPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected TSM!');", true);
                }
                ddlEPnewPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlEPoldPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtEPEmpEnroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEPEmpEnroll.Text))
                {
                    int enroll = int.Parse(txtEPEmpEnroll.Text.Trim());
                    string emp = objBLL.GetEmpNameByEnroll(enroll);
                    txtEPEmpName.Text = emp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enroll Textbox Null');", true);
                }


            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Enroll : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnEPUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (EPValidation() == true)
                {
                    if (hfConfirm.Value == "1")
                    {
                        string result = EmployeePromotion();
                        if (result == "Success")
                        {
                            EPClear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Promotion Update Successfully.');", true);
                        }
                        else if (result == "Exists")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Employee Already Exists.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + result + "');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Employee Promotion Cancel Successfully.');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Update Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Old Employee Transfer
        protected void ddlOETOldDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(ddlOETOldDesignation.SelectedValue) > 0)
                {
                    OETAccess(ddlOETOldDesignation.SelectedIndex);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Designation!');", true);
                }
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Old Designation : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETOldRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlOETOldRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlOETOldRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlOETOldArea.DataSource = dtr;
                        ddlOETOldArea.DataTextField = "Name";
                        ddlOETOldArea.DataValueField = "ID";
                        ddlOETOldArea.DataBind();
                    }
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Region!');", true);
                }
                ddlOETOldArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETnewRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlOETnewRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlOETnewRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlOETNewArea.DataSource = dtr;
                        ddlOETNewArea.DataTextField = "Name";
                        ddlOETNewArea.DataValueField = "ID";
                        ddlOETNewArea.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected New Region!');", true);
                }
                ddlOETNewArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETOldArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlOETOldTerritory.Items.Clear();
                if (int.Parse(ddlOETOldArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlOETOldArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlOETOldTerritory.DataSource = dtt;
                        ddlOETOldTerritory.DataTextField = "Name";
                        ddlOETOldTerritory.DataValueField = "ID";
                        ddlOETOldTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Old Area!');", true);
                }
                ddlOETOldTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETNewArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlOETNewTerritory.Items.Clear();
                if (int.Parse(ddlOETNewArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlOETNewArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlOETNewTerritory.DataSource = dtt;
                        ddlOETNewTerritory.DataTextField = "Name";
                        ddlOETNewTerritory.DataValueField = "ID";
                        ddlOETNewTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected New Area!');", true);
                }
                ddlOETNewTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETOldTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlOETOldPoint.Items.Clear();
                if (int.Parse(ddlOETOldTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlOETOldTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlOETOldPoint.DataSource = dtp;
                        ddlOETOldPoint.DataTextField = "Name";
                        ddlOETOldPoint.DataValueField = "ID";
                        ddlOETOldPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected TSM!');", true);
                }
                ddlOETOldPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETNewTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlOETNewPoint.Items.Clear();
                if (int.Parse(ddlOETNewTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlOETNewTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlOETNewPoint.DataSource = dtp;
                        ddlOETNewPoint.DataTextField = "Name";
                        ddlOETNewPoint.DataValueField = "ID";
                        ddlOETNewPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected TSM!');", true);
                }
                ddlOETNewPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOETOldPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlOETNewPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtOETEmpEnroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOETEmpEnroll.Text))
                {
                    int enroll = int.Parse(txtOETEmpEnroll.Text.Trim());
                    string emp = objBLL.GetEmpNameByEnroll(enroll);
                    txtOETEmpName.Text = emp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enroll Textbox Null');", true);
                }


            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Enroll : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnOETUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (OETValidation() == true)
                {
                    if (hfConfirm.Value == "1")
                    {
                        string result = OldEmployeeTransfer();
                        if (result == "Success")
                        {
                            OETClear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Old Employee Transfer Update Successfully.');", true);
                        }
                        else if (result == "Exists")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Employee Already Exists.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + result + "');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Old Employee Transfer Cancel Successfully.');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                string sms = "Employee Promotion Update Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Old Employee Resign
        protected void ddlOERDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(ddlOERDesignation.SelectedValue) > 0)
                {
                    OERAccess(ddlOERDesignation.SelectedIndex);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Designation!');", true);
                }
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Resign Designation : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOERRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtr = new DataTable();
            try
            {
                if (int.Parse(ddlOERRegion.SelectedValue) > 0)
                {
                    int RegionID = int.Parse(ddlOERRegion.SelectedValue);
                    dtr = objBLL.GetAllAreaByRID(RegionID);
                    if (dtr != null && dtr.Rows.Count > 0)
                    {
                        ddlOERArea.DataSource = dtr;
                        ddlOERArea.DataTextField = "Name";
                        ddlOERArea.DataValueField = "ID";
                        ddlOERArea.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Region!');", true);
                }
                ddlOERArea.Items.Insert(0, new ListItem("--- Select Area ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Resign Region : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOERArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            try
            {
                ddlOERTerritory.Items.Clear();
                if (int.Parse(ddlOERArea.SelectedValue) > 0)
                {
                    int AID = int.Parse(ddlOERArea.SelectedValue);
                    dtt = objBLL.GetAllTSMByAID(AID);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        ddlOERTerritory.DataSource = dtt;
                        ddlOERTerritory.DataTextField = "Name";
                        ddlOERTerritory.DataValueField = "ID";
                        ddlOERTerritory.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected Area!');", true);
                }
                ddlOERTerritory.Items.Insert(0, new ListItem("--- Select Territory ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOERTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtp = new DataTable();
            try
            {
                ddlOERPoint.Items.Clear();
                if (int.Parse(ddlOERTerritory.SelectedValue) > 0)
                {
                    int TID = int.Parse(ddlOERTerritory.SelectedValue);
                    dtp = objBLL.GetAllPointByTID(TID);
                    if (dtp != null && dtp.Rows.Count > 0)
                    {
                        ddlOERPoint.DataSource = dtp;
                        ddlOERPoint.DataTextField = "Name";
                        ddlOERPoint.DataValueField = "ID";
                        ddlOERPoint.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not Selected TSM!');", true);
                }
                ddlOERPoint.Items.Insert(0, new ListItem("--- Select Point ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Area : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlOERPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtOEREmployeeEnroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOEREmployeeEnroll.Text))
                {
                    int enroll = int.Parse(txtOEREmployeeEnroll.Text.Trim());
                    string emp = objBLL.GetEmpNameByEnroll(enroll);
                    txtOEREmployeeName.Text = emp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Enroll Textbox Null');", true);
                }


            }
            catch (Exception ex)
            {
                string sms = "Old Employee Resign Enroll : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnOERUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (OERValidation() == true)
                {
                    if (hfConfirm.Value == "1")
                    {
                        string result = OldEmployeeResign();
                        if (result == "Success")
                        {
                            OETClear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Old Employee Resign Update Successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + result + "');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Old Employee Resign Cancel Successfully.');", true);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                string sms = "Old Employee Resign Update Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #endregion

        #region Method
        private void TabClear(int tab)
        {
            if (tab == 1)
            {
                EPClear();
                OETClear();
                OERClear();
            }
            else if (tab == 2)
            {
                NETClear();
                OETClear();
                OERClear();
            }
            else if (tab == 3)
            {
                NETClear();
                EPClear();
                OERClear();
            }
            else if (tab == 4)
            {
                NETClear();
                EPClear();
                OETClear();
            }
        }
        private void FillDropDown()
        {
            DataTable dtNETD = new DataTable();
            DataTable dtEPTD = new DataTable();
            DataTable dtChannel = new DataTable();
            DataTable dtRegion = new DataTable();
            try
            {
                #region Designation
                dtNETD = objBLL.GetAllSalesDesignation();
                dtEPTD = objBLL.GetAllSalesDesignationWithoutNSM();

                if (dtNETD != null && dtNETD.Rows.Count > 0)
                {
                    ddlNETDesignation.DataSource = dtNETD;
                    ddlNETDesignation.DataTextField = "Name";
                    ddlNETDesignation.DataValueField = "ID";
                    ddlNETDesignation.DataBind();

                }

                if (dtEPTD != null && dtEPTD.Rows.Count > 0)
                {
                    ddlEPoldDesignation.DataSource = dtEPTD;
                    ddlEPoldDesignation.DataTextField = "Name";
                    ddlEPoldDesignation.DataValueField = "ID";
                    ddlEPoldDesignation.DataBind();

                    ddlEPnewDesignation.DataSource = dtEPTD;
                    ddlEPnewDesignation.DataTextField = "Name";
                    ddlEPnewDesignation.DataValueField = "ID";
                    ddlEPnewDesignation.DataBind();

                    ddlOETOldDesignation.DataSource = dtEPTD;
                    ddlOETOldDesignation.DataTextField = "Name";
                    ddlOETOldDesignation.DataValueField = "ID";
                    ddlOETOldDesignation.DataBind();

                    ddlOERDesignation.DataSource = dtEPTD;
                    ddlOERDesignation.DataTextField = "Name";
                    ddlOERDesignation.DataValueField = "ID";
                    ddlOERDesignation.DataBind();
                }

                ddlNETDesignation.Items.Insert(0, new ListItem("--- Select Designation ---", "-1"));
                ddlEPoldDesignation.Items.Insert(0, new ListItem("--- Select Designation ---", "-1"));
                ddlEPnewDesignation.Items.Insert(0, new ListItem("--- Select Designation ---", "-1"));
                ddlOETOldDesignation.Items.Insert(0, new ListItem("--- Select Designation ---", "-1"));
                ddlOERDesignation.Items.Insert(0, new ListItem("--- Select Designation ---", "-1"));

                #endregion

                #region Channel
                dtChannel = objBLL.GetAllChannel();
                if (dtChannel != null && dtChannel.Rows.Count > 0)
                {
                    ddlNETChannel.DataSource = dtChannel;
                    ddlNETChannel.DataTextField = "Name";
                    ddlNETChannel.DataValueField = "ID";
                    ddlNETChannel.DataBind();

                    ddlEPoldChannel.DataSource = dtChannel;
                    ddlEPoldChannel.DataTextField = "Name";
                    ddlEPoldChannel.DataValueField = "ID";
                    ddlEPoldChannel.DataBind();

                    ddlEPnewChannel.DataSource = dtChannel;
                    ddlEPnewChannel.DataTextField = "Name";
                    ddlEPnewChannel.DataValueField = "ID";
                    ddlEPnewChannel.DataBind();

                    ddlOETOldChannel.DataSource = dtChannel;
                    ddlOETOldChannel.DataTextField = "Name";
                    ddlOETOldChannel.DataValueField = "ID";
                    ddlOETOldChannel.DataBind();

                    ddlOETNewChannel.DataSource = dtChannel;
                    ddlOETNewChannel.DataTextField = "Name";
                    ddlOETNewChannel.DataValueField = "ID";
                    ddlOETNewChannel.DataBind();

                    ddlOERChannel.DataSource = dtChannel;
                    ddlOERChannel.DataTextField = "Name";
                    ddlOERChannel.DataValueField = "ID";
                    ddlOERChannel.DataBind();
                }
                ddlNETChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                ddlEPoldChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                ddlEPnewChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                ddlOETOldChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                ddlOETNewChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                ddlOERChannel.Items.Insert(0, new ListItem("--- Select Channel ---", "-1"));
                #endregion

                #region Region
                dtRegion = objBLL.GetAllRegion();
                if (dtRegion != null && dtRegion.Rows.Count > 0)
                {
                    ddlNETRegion.DataSource = dtRegion;
                    ddlNETRegion.DataTextField = "Name";
                    ddlNETRegion.DataValueField = "ID";
                    ddlNETRegion.DataBind();

                    ddlEPoldRegion.DataSource = dtRegion;
                    ddlEPoldRegion.DataTextField = "Name";
                    ddlEPoldRegion.DataValueField = "ID";
                    ddlEPoldRegion.DataBind();

                    ddlEPnewRegion.DataSource = dtRegion;
                    ddlEPnewRegion.DataTextField = "Name";
                    ddlEPnewRegion.DataValueField = "ID";
                    ddlEPnewRegion.DataBind();

                    ddlOETOldRegion.DataSource = dtRegion;
                    ddlOETOldRegion.DataTextField = "Name";
                    ddlOETOldRegion.DataValueField = "ID";
                    ddlOETOldRegion.DataBind();

                    ddlOETnewRegion.DataSource = dtRegion;
                    ddlOETnewRegion.DataTextField = "Name";
                    ddlOETnewRegion.DataValueField = "ID";
                    ddlOETnewRegion.DataBind();

                    ddlOERRegion.DataSource = dtRegion;
                    ddlOERRegion.DataTextField = "Name";
                    ddlOERRegion.DataValueField = "ID";
                    ddlOERRegion.DataBind();
                }
                ddlNETRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                ddlEPoldRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                ddlEPnewRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                ddlOETOldRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                ddlOETnewRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                ddlOERRegion.Items.Insert(0, new ListItem("--- Select Region ---", "-1"));
                #endregion
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }

        private bool NETValidation()
        {
            if (ddlNETDesignation.SelectedValue == "-1")
            {
                ddlNETDesignation.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Designation');", true);
                return false;
            }


            if (ddlNETChannel.SelectedValue == "-1")
            {
                ddlNETChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Channel');", true);
                return false;
            }


            if (string.IsNullOrEmpty(txtNETDate.Text))
            {
                txtNETDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                return false;
            }

            if (int.Parse(ddlNETDesignation.SelectedValue) > 1492)
            {
                if (string.IsNullOrEmpty(ddlNETPoint.Text) && ddlNETPoint.SelectedValue == "-1")
                {
                    ddlNETPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Point');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlNETDesignation.SelectedValue) == 1492)
            {
                if (string.IsNullOrEmpty(ddlNETTerritory.Text) && ddlNETTerritory.SelectedValue == "-1")
                {
                    ddlNETTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Territory');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlNETDesignation.SelectedValue) == 1491)
            {
                if (string.IsNullOrEmpty(ddlNETArea.Text) && ddlNETArea.SelectedValue == "-1")
                {
                    ddlNETArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Area');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlNETDesignation.SelectedValue) == 1490)
            {
                if (string.IsNullOrEmpty(ddlNETRegion.Text) && ddlNETRegion.SelectedValue == "-1")
                {
                    ddlNETRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Region');", true);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtNETEmpName.Text))
            {
                txtNETEmpName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Name is Null');", true);
                return false;
            }

            return true;
        }
        private bool NewEmployeeTransfer()
        {
            int NewDesignationId = 0;
            int OldDesignationId = 0;
            int DepartmentId = 0;
            int JobstationId = 0;
            int GeoID = 0;
            int Channel = 0;
            DateTime TransferDate = DateTime.MinValue;
            int EmployeeID = 0;
            int UserId = 0;
            DataTable dte = new DataTable();
            bool result = false;
            try
            {
                NewDesignationId = int.Parse(ddlNETDesignation.SelectedValue);
                if (NewDesignationId > 1492)
                {
                    GeoID = int.Parse(ddlNETPoint.SelectedValue);
                }
                else if (NewDesignationId == 1492)
                {
                    GeoID = int.Parse(ddlNETTerritory.SelectedValue);
                }
                else if (NewDesignationId == 1491)
                {
                    GeoID = int.Parse(ddlNETArea.SelectedValue);
                }
                else if (NewDesignationId == 1490)
                {
                    GeoID = int.Parse(ddlNETRegion.SelectedValue);
                }
                else if (NewDesignationId == 1489)
                {
                    GeoID = 0;
                }
                Channel = int.Parse(ddlNETChannel.SelectedValue);
                TransferDate = DateTime.ParseExact(txtNETDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EmployeeID = int.Parse(txtNETEnroll.Text.Trim());
                dte = objBLL.GetEmployeeDetailsByEnroll(EmployeeID);
                if (dte != null && dte.Rows.Count > 0)
                {
                    OldDesignationId = int.Parse(dte.Rows[0]["intDesignationID"].ToString());
                    DepartmentId = int.Parse(dte.Rows[0]["intDepartmentID"].ToString());
                    JobstationId = int.Parse(dte.Rows[0]["intJobStationID"].ToString());
                }
                UserId = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (objBLL.CheckNewEmployeeTransfer(EmployeeID) > 0)
                {
                    string sms = txtNETEmpName.Text + "." + " This Employee Already Exists.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
                }
                else
                {
                    result = objBLL.InsertNewEmployeeTransfer(EmployeeID, TransferDate, JobstationId, DepartmentId, GeoID, Channel, OldDesignationId, UserId, NewDesignationId);
                }

            }
            catch (Exception ex)
            {
                string sms = "New Employee Transfer Update Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
            return result;
        }
        private void NETClear()
        {
            ddlNETDesignation.SelectedValue = "-1";
            ddlNETChannel.SelectedValue = "-1";
            ddlNETRegion.SelectedValue = "-1";
            ddlNETArea.Items.Clear();
            ddlNETTerritory.Items.Clear();
            ddlNETPoint.Items.Clear();
            txtNETEnroll.Text = string.Empty;
            txtNETEmpName.Text = string.Empty;
            txtNETDate.Text = string.Empty;
        }

        private bool EPValidation()
        {
            if (ddlEPnewDesignation.SelectedValue == "-1")
            {
                ddlEPnewDesignation.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select New Designation');", true);
                return false;
            }

            if (ddlEPoldDesignation.SelectedValue == "-1")
            {
                ddlEPoldDesignation.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Old Designation');", true);
                return false;
            }


            if (ddlEPnewChannel.SelectedValue == "-1")
            {
                ddlEPnewChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select New Channel');", true);
                return false;
            }

            if (ddlEPoldChannel.SelectedValue == "-1")
            {
                ddlEPoldChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Old Channel');", true);
                return false;
            }


            if (string.IsNullOrEmpty(txtEPDate.Text))
            {
                txtEPDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                return false;
            }

            if (int.Parse(ddlEPnewDesignation.SelectedValue) > 1492)
            {
                if (string.IsNullOrEmpty(ddlEPnewPoint.Text) && ddlEPnewPoint.SelectedValue == "-1")
                {
                    ddlEPnewPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Point');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlEPoldPoint.Text) && ddlEPoldPoint.SelectedValue == "-1")
                {
                    ddlEPoldPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Point');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlEPnewDesignation.SelectedValue) == 1492)
            {
                if (string.IsNullOrEmpty(ddlEPnewTerritory.Text) && ddlEPnewTerritory.SelectedValue == "-1")
                {
                    ddlEPnewTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Territory');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlEPoldTerritory.Text) && ddlEPoldTerritory.SelectedValue == "-1")
                {
                    ddlEPoldTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Territory');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlEPnewDesignation.SelectedValue) == 1491)
            {
                if (string.IsNullOrEmpty(ddlEPnewArea.Text) && ddlEPnewArea.SelectedValue == "-1")
                {
                    ddlEPnewArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Area');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlEPoldArea.Text) && ddlEPoldArea.SelectedValue == "-1")
                {
                    ddlEPoldArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Area');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlEPnewDesignation.SelectedValue) == 1490)
            {
                if (string.IsNullOrEmpty(ddlEPnewRegion.Text) && ddlEPnewRegion.SelectedValue == "-1")
                {
                    ddlEPnewRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Region');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlEPoldRegion.Text) && ddlEPoldRegion.SelectedValue == "-1")
                {
                    ddlEPoldRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Region');", true);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtEPEmpName.Text))
            {
                txtEPEmpName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Name is Null');", true);
                return false;
            }

            return true;
        }
        private string EmployeePromotion()
        {
            int NewDesignationId = 0;
            int NewGeoID = 0;
            int OldGeoID = 0;
            int NewChannel = 0;
            int OldChannel = 0;
            int LevelID = 0;

            DateTime PromotionDate = DateTime.MinValue;
            int EmployeeID = 0;
            int UserId = 0;
            DataTable dte = new DataTable();
            string result = string.Empty;
            try
            {
                NewDesignationId = int.Parse(ddlEPnewDesignation.SelectedValue);
                if (NewDesignationId > 1492)
                {
                    NewGeoID = int.Parse(ddlEPnewPoint.SelectedValue);
                    OldGeoID = int.Parse(ddlEPoldPoint.SelectedValue);
                    LevelID = 4;
                }
                else if (NewDesignationId == 1492)
                {
                    NewGeoID = int.Parse(ddlEPnewTerritory.SelectedValue);
                    OldGeoID = int.Parse(ddlEPoldTerritory.SelectedValue);
                    LevelID = 3;
                }
                else if (NewDesignationId == 1491)
                {
                    NewGeoID = int.Parse(ddlEPnewArea.SelectedValue);
                    OldGeoID = int.Parse(ddlEPoldArea.SelectedValue);
                    LevelID = 2;
                }
                else if (NewDesignationId == 1490)
                {
                    NewGeoID = int.Parse(ddlEPnewRegion.SelectedValue);
                    OldGeoID = int.Parse(ddlEPoldRegion.SelectedValue);
                    LevelID = 1;
                }

                NewChannel = int.Parse(ddlEPnewChannel.SelectedValue);
                OldChannel = int.Parse(ddlEPoldChannel.SelectedValue);

                PromotionDate = DateTime.ParseExact(txtEPDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EmployeeID = int.Parse(txtEPEmpEnroll.Text.Trim());
                UserId = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                //dte = objBLL.GetEmployeeDetailsByEnroll(EmployeeID);
                //if (dte != null && dte.Rows.Count > 0)
                //{
                //    OldDesignationId = int.Parse(dte.Rows[0]["intDesignationID"].ToString());
                //    DepartmentId = int.Parse(dte.Rows[0]["intDepartmentID"].ToString());
                //    JobstationId = int.Parse(dte.Rows[0]["intJobStationID"].ToString());
                //}
                //
                //if (objBLL.CheckNewEmployeeTransfer(EmployeeID) > 0)
                //{
                //    string sms = txtEPEmpName.Text + " This Employee Already Exists";
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
                //}
                //else
                //{
                //    result = objBLL.InsertNewEmployeeTransfer(EmployeeID, TransferDate, JobstationId, DepartmentId, GeoID, Channel,
                //    OldDesignationId, UserId, NewDesignationId);
                //}
                result = objBLL.EmployeePromotionAction(EmployeeID, PromotionDate, NewDesignationId, NewChannel, OldChannel, NewGeoID,
                    OldGeoID, UserId, LevelID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return result;
        }
        private void EPClear()
        {
            ddlEPoldDesignation.SelectedValue = "-1";
            ddlEPnewDesignation.SelectedValue = "-1";
            ddlEPoldChannel.SelectedValue = "-1";
            ddlEPnewChannel.SelectedValue = "-1";
            ddlEPoldRegion.SelectedValue = "-1";
            ddlEPnewRegion.SelectedValue = "-1";
            ddlEPoldArea.Items.Clear();
            ddlEPnewArea.Items.Clear();
            ddlEPoldTerritory.Items.Clear();
            ddlEPnewTerritory.Items.Clear();
            ddlEPnewPoint.Items.Clear();
            ddlEPoldPoint.Items.Clear();
            txtEPEmpEnroll.Text = string.Empty;
            txtEPEmpName.Text = string.Empty;
            txtEPDate.Text = string.Empty;
        }

        private bool OETValidation()
        {
            if (ddlOETOldDesignation.SelectedValue == "-1")
            {
                ddlOETOldDesignation.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Designation');", true);
                return false;
            }


            if (ddlOETNewChannel.SelectedValue == "-1")
            {
                ddlOETNewChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select New Channel');", true);
                return false;
            }

            if (ddlOETOldChannel.SelectedValue == "-1")
            {
                ddlOETOldChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Old Channel');", true);
                return false;
            }


            if (string.IsNullOrEmpty(txtOETDate.Text))
            {
                txtOETDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                return false;
            }

            if (int.Parse(ddlOETOldDesignation.SelectedValue) > 1492)
            {
                if (string.IsNullOrEmpty(ddlOETNewPoint.Text) && ddlOETNewPoint.SelectedValue == "-1")
                {
                    ddlOETNewPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Point');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlOETOldPoint.Text) && ddlOETOldPoint.SelectedValue == "-1")
                {
                    ddlOETOldPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Point');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOETOldDesignation.SelectedValue) == 1492)
            {
                if (string.IsNullOrEmpty(ddlOETNewTerritory.Text) && ddlOETNewTerritory.SelectedValue == "-1")
                {
                    ddlOETNewTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Territory');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlOETOldTerritory.Text) && ddlOETOldTerritory.SelectedValue == "-1")
                {
                    ddlOETOldTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Territory');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOETOldDesignation.SelectedValue) == 1491)
            {
                if (string.IsNullOrEmpty(ddlOETNewArea.Text) && ddlOETNewArea.SelectedValue == "-1")
                {
                    ddlOETNewArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Area');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlOETOldArea.Text) && ddlOETOldArea.SelectedValue == "-1")
                {
                    ddlOETOldArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Area');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOETOldDesignation.SelectedValue) == 1490)
            {
                if (string.IsNullOrEmpty(ddlOETnewRegion.Text) && ddlOETnewRegion.SelectedValue == "-1")
                {
                    ddlOETnewRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Region');", true);
                    return false;
                }
                if (string.IsNullOrEmpty(ddlOETOldRegion.Text) && ddlOETOldRegion.SelectedValue == "-1")
                {
                    ddlOETOldRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Old Region');", true);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtOETEmpName.Text))
            {
                txtOETEmpName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Name is Null');", true);
                return false;
            }

            return true;
        }
        private string OldEmployeeTransfer()
        {
            int DesignationId = 0;
            int NewGeoID = 0;
            int OldGeoID = 0;
            int NewChannel = 0;
            int OldChannel = 0;
            int LevelID = 0;

            DateTime TransferDate = DateTime.MinValue;
            int EmployeeID = 0;
            int UserId = 0;
            DataTable dte = new DataTable();
            string result = string.Empty;
            try
            {
                DesignationId = int.Parse(ddlOETOldDesignation.SelectedValue);
                if (DesignationId > 1492)
                {
                    NewGeoID = int.Parse(ddlOETNewPoint.SelectedValue);
                    OldGeoID = int.Parse(ddlOETOldPoint.SelectedValue);
                    LevelID = 4;
                }
                else if (DesignationId == 1492)
                {
                    NewGeoID = int.Parse(ddlOETNewTerritory.SelectedValue);
                    OldGeoID = int.Parse(ddlOETOldTerritory.SelectedValue);
                    LevelID = 3;
                }
                else if (DesignationId == 1491)
                {
                    NewGeoID = int.Parse(ddlOETNewArea.SelectedValue);
                    OldGeoID = int.Parse(ddlOETOldArea.SelectedValue);
                    LevelID = 2;
                }
                else if (DesignationId == 1490)
                {
                    NewGeoID = int.Parse(ddlOETnewRegion.SelectedValue);
                    OldGeoID = int.Parse(ddlOETOldRegion.SelectedValue);
                    LevelID = 1;
                }

                NewChannel = int.Parse(ddlOETNewChannel.SelectedValue);
                OldChannel = int.Parse(ddlOETOldChannel.SelectedValue);

                TransferDate = DateTime.ParseExact(txtOETDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EmployeeID = int.Parse(txtOETEmpEnroll.Text.Trim());
                UserId = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                result = objBLL.OldEmployeeTransferAction(EmployeeID, TransferDate, DesignationId, NewChannel, OldChannel, NewGeoID,
                    OldGeoID, UserId, LevelID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return result;
        }
        private void OETClear()
        {
            ddlOETOldDesignation.SelectedValue = "-1";
            ddlOETOldChannel.SelectedValue = "-1";
            ddlOETNewChannel.SelectedValue = "-1";
            ddlOETOldRegion.SelectedValue = "-1";
            ddlOETnewRegion.SelectedValue = "-1";
            ddlOETOldArea.Items.Clear();
            ddlOETNewArea.Items.Clear();
            ddlOETOldTerritory.Items.Clear();
            ddlOETNewTerritory.Items.Clear();
            ddlOETOldPoint.Items.Clear();
            ddlOETNewPoint.Items.Clear();
            txtOETEmpEnroll.Text = string.Empty;
            txtOETEmpName.Text = string.Empty;
            txtOETDate.Text = string.Empty;
        }

        private bool OERValidation()
        {
            if (ddlOERDesignation.SelectedValue == "-1")
            {
                ddlOERDesignation.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Designation');", true);
                return false;
            }


            if (ddlOERChannel.SelectedValue == "-1")
            {
                ddlOERChannel.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Channel');", true);
                return false;
            }


            if (string.IsNullOrEmpty(txtOERDate.Text))
            {
                txtOERDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Resign Date');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Transfer Date');", true);
                return false;
            }

            if (int.Parse(ddlOERDesignation.SelectedValue) > 1492)
            {
                if (string.IsNullOrEmpty(ddlOERPoint.Text) && ddlOERPoint.SelectedValue == "-1")
                {
                    ddlOERPoint.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Point');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOERDesignation.SelectedValue) == 1492)
            {
                if (string.IsNullOrEmpty(ddlOERTerritory.Text) && ddlOERTerritory.SelectedValue == "-1")
                {
                    ddlOERTerritory.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Territory');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOERDesignation.SelectedValue) == 1491)
            {
                if (string.IsNullOrEmpty(ddlOERArea.Text) && ddlOERArea.SelectedValue == "-1")
                {
                    ddlOERArea.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Area');", true);
                    return false;
                }
            }
            else if (int.Parse(ddlOERDesignation.SelectedValue) == 1490)
            {
                if (string.IsNullOrEmpty(ddlOERRegion.Text) && ddlOERRegion.SelectedValue == "-1")
                {
                    ddlOERRegion.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Region');", true);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtOEREmployeeName.Text))
            {
                txtOEREmployeeName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Employee Name is Null');", true);
                return false;
            }

            return true;
        }
        private string OldEmployeeResign()
        {
            int DesignationId = 0;
            int GeoID = 0;
            int Channel = 0;
            int LevelID = 0;

            DateTime ResignDate = DateTime.MinValue;
            int EmployeeID = 0;
            int UserId = 0;
            string result = string.Empty;
            try
            {
                DesignationId = int.Parse(ddlOERDesignation.SelectedValue);
                if (DesignationId > 1492)
                {
                    GeoID = int.Parse(ddlOERPoint.SelectedValue);
                    LevelID = 4;
                }
                else if (DesignationId == 1492)
                {
                    GeoID = int.Parse(ddlOERTerritory.SelectedValue);
                    LevelID = 3;
                }
                else if (DesignationId == 1491)
                {
                    GeoID = int.Parse(ddlOERArea.SelectedValue);
                    LevelID = 2;
                }
                else if (DesignationId == 1490)
                {
                    GeoID = int.Parse(ddlOERRegion.SelectedValue);
                    LevelID = 1;
                }

                Channel = int.Parse(ddlOERChannel.SelectedValue);

                ResignDate = DateTime.ParseExact(txtOERDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EmployeeID = int.Parse(txtOETEmpEnroll.Text.Trim());
                UserId = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                result = objBLL.OldEmployeeResignAction(EmployeeID, ResignDate, DesignationId, Channel, GeoID, UserId, LevelID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return result;
        }
        private void OERClear()
        {
            ddlOERDesignation.SelectedValue = "-1";
            ddlOERChannel.SelectedValue = "-1";
            ddlOERRegion.SelectedValue = "-1";
            ddlOERArea.Items.Clear();
            ddlOERTerritory.Items.Clear();
            ddlOERPoint.Items.Clear();
            txtOEREmployeeEnroll.Text = string.Empty;
            txtOEREmployeeName.Text = string.Empty;
            txtOERDate.Text = string.Empty;
        }

        private void EPAccess(int ID)
        {
            if(ID == 1)
            {
                ddlEPoldArea.Enabled = false;
                ddlEPnewArea.Enabled = false;
                ddlEPoldTerritory.Enabled = false;
                ddlEPnewTerritory.Enabled = false;
                ddlEPoldPoint.Enabled = false;
                ddlEPnewPoint.Enabled = false;
            }
            else if (ID == 2)
            {
                ddlEPoldTerritory.Enabled = false;
                ddlEPnewTerritory.Enabled = false;
                ddlEPoldPoint.Enabled = false;
                ddlEPnewPoint.Enabled = false;
            }
            else if (ID == 3)
            {
                ddlEPoldPoint.Enabled = false;
                ddlEPnewPoint.Enabled = false;
            }
            else
            {
                ddlEPoldArea.Enabled = true;
                ddlEPnewArea.Enabled = true;
                ddlEPoldTerritory.Enabled = true;
                ddlEPnewTerritory.Enabled = true;
                ddlEPoldPoint.Enabled = true;
                ddlEPnewPoint.Enabled = true;
            }
        }
        private void OETAccess(int ID)
        {
            if (ID == 1)
            {
                ddlOETOldArea.Enabled = false;
                ddlOETNewArea.Enabled = false;
                ddlOETOldTerritory.Enabled = false;
                ddlOETNewTerritory.Enabled = false;
                ddlOETOldPoint.Enabled = false;
                ddlOETNewPoint.Enabled = false;
            }
            else if (ID == 2)
            {
                ddlOETOldTerritory.Enabled = false;
                ddlOETNewTerritory.Enabled = false;
                ddlOETOldPoint.Enabled = false;
                ddlOETNewPoint.Enabled = false;
            }
            else if (ID == 3)
            {
                ddlOETOldPoint.Enabled = false;
                ddlOETNewPoint.Enabled = false;
            }
            else
            {
                ddlOETOldArea.Enabled = true;
                ddlOETNewArea.Enabled = true;
                ddlOETOldTerritory.Enabled = true;
                ddlOETNewTerritory.Enabled = true;
                ddlOETOldPoint.Enabled = true;
                ddlOETNewPoint.Enabled = true;
            }
        }
        private void ETAccess(int ID)
        {
            if (ID == 1)
            {
                ddlNETArea.Enabled = false;
                ddlNETTerritory.Enabled = false;
                ddlNETPoint.Enabled = false;
            }
            else if (ID == 2)
            {
                ddlNETTerritory.Enabled = false;
                ddlNETPoint.Enabled = false;
            }
            else if (ID == 3)
            {
                ddlNETPoint.Enabled = false;
            }
            else
            {
                ddlNETArea.Enabled = true;
                ddlNETTerritory.Enabled = true;
                ddlNETPoint.Enabled = true;
            }
        }
        private void OERAccess(int ID)
        {
            if (ID == 1)
            {
                ddlOERArea.Enabled = false;
                ddlOERTerritory.Enabled = false;
                ddlOERPoint.Enabled = false;
            }
            else if (ID == 2)
            {
                ddlOERTerritory.Enabled = false;
                ddlOERPoint.Enabled = false;
            }
            else if (ID == 3)
            {
                ddlOERPoint.Enabled = false;
            }
            else
            {
                ddlOERArea.Enabled = true;
                ddlOERTerritory.Enabled = true;
                ddlOERPoint.Enabled = true;
            }
        }



        #endregion

        
    }
}