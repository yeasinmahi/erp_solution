using BLL.Accounts.ChartOfAccount;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.ChartOfAccount
{
    public partial class GLCodeEntryNreport : System.Web.UI.Page
    {
        #region INIT
        private GLCodeBLL gLCodeBLL = new GLCodeBLL();
        private int UserID;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserID = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                FillDropDown(UserID);
            }
        }
        
        #endregion

        #region Event
        protected void btnGLCodeSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Method
        private void FillDropDown(int UserID)
        {
            DataTable udt = new DataTable();
            try
            {
                udt = gLCodeBLL.GetUnitData(UserID);
                if (udt != null && udt.Rows.Count > 0)
                {
                    ddlUnit.DataSource = udt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();
                }

                ddlUnit.Items.Insert(0, new ListItem("--- Select Unit ---", "-1"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion


    }
}