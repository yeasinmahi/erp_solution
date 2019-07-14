using SAD_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Setup
{
    public partial class AfblDistManager : System.Web.UI.Page
    {
        #region INITIALIZE
        String errMsg = "Exception Error.";
        AfblDistributionBll objAfblDistributionBll = new AfblDistributionBll();

        #endregion

        #region EventBase

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindDistributionGrid();
        }

        #endregion

        private void BindDistributionGrid()
        {
            DataTable dt = new DataTable();
            int partId = 3;
            try
            {
                dt = objAfblDistributionBll.GetAFBLDistributionInfo(null, null, null, partId, null, null, null, null, null, null, null);

                gvDistribute.DataSource = dt;
                gvDistribute.DataBind();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }
               
        protected void gvDistribute_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int partId = 6;
            int enroll = -1, pID = -1;
            DataTable dt = new DataTable();

            try
            {
                string lid = ((HiddenField)gvDistribute.Rows[e.RowIndex].FindControl("HiddenID")).Value;

                TextBox TextEnroll = (TextBox)gvDistribute.Rows[e.RowIndex].FindControl("txtEnroll");

                if (!string.IsNullOrEmpty(TextEnroll.Text))
                    enroll = Convert.ToInt32(TextEnroll.Text.ToString());
                if (!string.IsNullOrEmpty(lid))
                    pID = Convert.ToInt32(lid);

                if (enroll > -1 && pID > -1)
                {
                    dt = objAfblDistributionBll.GetAFBLDistributionInfo(null, null, pID, partId, null, null, enroll, null, null, null, null);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found To Update.');", true);
                }

            }
            catch (Exception Ex)
            {                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }
    }
}