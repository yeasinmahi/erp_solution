 
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class CreateLocation : BasePage
    {
        int intWHID, intEnroll, intType, intUnit; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        string strName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                    dt = objRec.DataView(1, "", 0, 0, DateTime.Now, intEnroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();

                    dt = bll.GetLocationType();
                    ddlType.DataSource = dt;
                    ddlType.DataTextField = "strRackType";
                    ddlType.DataValueField = "intAutoId";
                    ddlType.DataBind();

                    lblLocation.Text = ddlType.SelectedItem.ToString() + " Name :";

                    LoadGrid();
                }
                catch { }
            }
        }

        private void LoadGrid()
        {
            try
            {
                intType = int.Parse(ddlType.SelectedValue.ToString());
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());

                dt = bll.GetLocationList(intType, intWHID);
                dgvLocation.DataSource = dt;
                dgvLocation.DataBind();
            }
            catch { }
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLocation.Text = ddlType.SelectedItem.ToString() + " Name :";

                LoadGrid();
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                strName = txtLocation.Text;
                if(strName == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Input Location Name First.');", true);
                }
                else
                {
                    if (dgvLocation.Rows.Count > 0)
                    {
                        for (int k = 0; k < dgvLocation.Rows.Count; k++)
                            if (strName == ((Label)dgvLocation.Rows[k].FindControl("lblName")).Text.ToString())
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Location Already Exit. Put Another Name.');", true);
                                return;
                            }
                    }

                    intType = int.Parse(ddlType.SelectedValue.ToString());
                    intWHID = int.Parse(ddlWH.SelectedValue.ToString());

                    dt = bll.GetUnitID(intWHID);
                    intUnit = int.Parse(dt.Rows[0]["intUnitID"].ToString());

                    bll.InsertLocation(strName, intType, intWHID, intUnit);

                    LoadGrid();

                }
            }
            catch { }
        }








    }
}