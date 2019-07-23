using SAD_BLL.Global;
using SAD_BLL.Item;
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

namespace UI.SAD.Setup
{
    public partial class EmployeeBridgeJobStation : BasePage
    {
        SetupBLL objSetupBll = new SetupBLL();
        DataTable dt = new DataTable();
        string msgErr = string.Empty;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                    dt = new DataTable();
                    dt = objSetupBll.GetJobStationList(2);
                    ddlJobStation.DataTextField = "strjobstationname";
                    ddlJobStation.DataValueField = "intemployeejobstationid";
                    ddlJobStation.DataSource = dt;
                    ddlJobStation.DataBind();

                    //dt = new DataTable();
                    //dt = objSetupBll.GetCustomerList();
                    //ddlCustomer.DataTextField = "strName";
                    //ddlCustomer.DataValueField = "intCusID";
                    //ddlCustomer.DataSource = dt;
                    //ddlCustomer.DataBind();
                }
                catch (Exception ex)
                {
                    msgErr = ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int stationID, custID;
            try
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    custID = int.Parse(arrayKeyItem[1].ToString());
                }
                else { custID = int.Parse("0"); }

                stationID = Convert.ToInt16(ddlJobStation.SelectedValue.ToString());
                //custID = Convert.ToInt16(ddlCustomer.SelectedValue.ToString());
                objSetupBll.SaveEmpBridgeJobStation(stationID, custID);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Job Station Bridge Successfully');", true);
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        protected void btnBridgeReport_Click(object sender, EventArgs e)
        {
            DataTable dtview = new DataTable();
            try
            {
                dgvJSBridgeList.DataSource = null;
                dgvJSBridgeList.DataBind();

                dtview = objSetupBll.GetEmpBridgeJobStationList();
                dgvJSBridgeList.DataSource = dtview;
                dgvJSBridgeList.DataBind();

                dgvJSBridgeList.Columns[2].Visible = false;
                dgvJSBridgeList.Columns[3].Visible = true;
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        protected void btnNoBridgeReport_Click(object sender, EventArgs e)
        {
            DataTable dtgr = new DataTable();
            try
            {
                dgvJSBridgeList.DataSource = null;
                dgvJSBridgeList.DataBind();

                dtgr = objSetupBll.GetEmpNonBridgeJobStationList();
                dgvJSBridgeList.DataSource = dtgr;
                dgvJSBridgeList.DataBind();

                dgvJSBridgeList.Columns[2].Visible = true;
                dgvJSBridgeList.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        protected void btnGEORemove_Click(object sender, EventArgs e)
        {
            int custID;
            try
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    custID = int.Parse(arrayKeyItem[1].ToString());
                }
                else { custID = int.Parse("0"); }
                //custID = Convert.ToInt16(ddlCustomer.SelectedValue.ToString());

                objSetupBll.DelEmpBridgeJobStation(custID);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Delete Successfully');", true);
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        protected void btnDoubleBridgeRemove_Click(object sender, EventArgs e)
        {
            int custID;
            try
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    custID = int.Parse(arrayKeyItem[1].ToString());
                }
                else { custID = int.Parse("0"); }
                //custID = Convert.ToInt16(ddlCustomer.SelectedValue.ToString());

                objSetupBll.DelAllEmpBridgeJobStation(custID);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Delete Successfully');", true);
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        protected void dgvJSBridgeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] CustomerSearch(string prefixText, int count = 0)
        {
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetCstomer("2", prefixText);
        }

    }
}