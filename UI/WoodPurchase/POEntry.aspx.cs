using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.WoodPurchase
{
    public partial class POEntry : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        int intEnroll, intPOID, intUnitID, intJobStationID, intWH; bool ysnActive;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnJobStaion.Value = Session[SessionParams.JOBSTATION_ID].ToString();

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitJobStation(intWH);
                    hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();

                    intUnitID = int.Parse(hdnUnit.Value.ToString());
                    intJobStationID = int.Parse(hdnJobStaion.Value.ToString());

                    LoadGrid();
                }
            }
            catch { }
        }
        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();

                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());

                LoadGrid();
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(txtPO.Text);
                intEnroll = int.Parse(hdnEnroll.Value.ToString());
                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());

                bll.POEntry(intPOID, intEnroll, intUnitID, intWH);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Inserted.');", true);
                LoadGrid();
            }
            catch { }
            
        }

        private void LoadGrid()
        {
            dt = new DataTable();
            dt = bll.GetInsertedPO(intUnitID, intWH);
            dgvPOList.DataSource = dt;
            dgvPOList.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                string strSearchKey = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = Regex.Split(strSearchKey, ",");
                string strdex = searchKey[1];
                string strReffid = searchKey[0];
                intPOID = int.Parse(strReffid.ToString());

                int index = int.Parse(strdex.ToString());
                ysnActive = ((CheckBox)dgvPOList.Rows[index].FindControl("chkActive")).Checked;

                bll.UpdatePO(ysnActive, intPOID);

                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Updated.');", true);
                LoadGrid();
            }
            catch { }
            
        }

    }
}