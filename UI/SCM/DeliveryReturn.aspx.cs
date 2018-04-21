﻿using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class DeliveryReturn : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
            else
            { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                getDataBind();
            }
            catch { }

        }

        private void getDataBind()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int poId = int.Parse(txtPoNo.Text.ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objPo.GetPoData(31, "", intWh, poId, DateTime.Now, enroll);
                dgvDelivery.DataSource = dt;
                dgvDelivery.DataBind();
            }
            catch { }
           
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value == "1")
                {

                    int poid =int.Parse(txtPoNo.Text.ToString());
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                    TextBox txtReson = row.FindControl("txtReson") as TextBox;
                    Label lblitemId = row.FindControl("lblitemId") as Label;
                    Label lblPoQty = row.FindControl("lblPoQty") as Label;
                     
                   
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    double returnQty = double.Parse(txtReturnQty.Text.ToString());
                    string remarks = txtReson.Text.ToString();
                    string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty.ToString() + '"' + " remarks=" + '"' + remarks + '"' + " itemId=" + '"' + lblitemId.Text.ToString() + '"' + " poQty=" + '"' + lblPoQty.Text.ToString() + '"' + "/></voucher>".ToString();
                    if (returnQty > 0)
                    {
                        string msg = objPo.PoApprove(32, xmlData, intWh, poid, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        getDataBind();
                    } 
                }

            }
            catch { }
        }
    }
}