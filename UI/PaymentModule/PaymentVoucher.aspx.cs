﻿using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class PaymentVoucher : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;
        
        #endregion ====================================================================================
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();

                if (!IsPostBack)
                {
                    hdnysnPay.Value = "0";
                    hdnysnDutyVoucher.Value = "0";

                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetCheckUserRoleForVoucher(hdnEmail.Value);
                        if (dt.Rows.Count > 0)
                        {
                            if (int.Parse(dt.Rows[0]["intCount"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                                return;
                            }
                        }
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }

                        


                    dt = new DataTable();
                    dt = objBillReg.GetUserInfoForPaymentModule(int.Parse(hdnEnroll.Value));                    
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ysnPay"].ToString()) == true)
                        {
                            hdnysnPay.Value = "1";
                        }
                        if (bool.Parse(dt.Rows[0]["ysnDutyVoucher"].ToString()) == true)
                        {
                            hdnysnDutyVoucher.Value = "1";
                        }                        
                    }
                }
            }
            catch { }
        }

























    }
}