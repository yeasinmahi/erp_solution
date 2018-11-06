﻿using System;
using System.Web;
using System.Web.UI;
using SAD_BLL.AEFPS;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class PurchaseReturn : Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll;

        protected void Page_Load(object sender, EventArgs e)
        {
            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LoadWh();
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            string mrrNumber = txtMrrNumber.Text;
            if (!string.IsNullOrWhiteSpace(mrrNumber))
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('MRR can not be blank');", true);
            }
            
        }
        private void LoadWh()
        {

            ddlWh.DataSource = _bll.DataView(1, "", 0, 0, DateTime.Now, _intEnroll);
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}