using SAD_BLL.Corporate_sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnAccAdjust : Page
    {
        DataTable dt, dtproceed = new DataTable(); Bridge obj = new Bridge();
        string msg, message, custid, challanno, ttlamount, custname;

        int intcustid, intEnroll, rollid; Decimal decttlamount; DateTime dtedate; Boolean ysn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hdnenroll.Value = Session[SessionParams.USER_ID].ToString();
                intEnroll = int.Parse(hdnenroll.Value);
                try
                {
                    dtproceed = Bridge.GetProceedPermissionACAdj(intEnroll);
                    ysn = Boolean.Parse(dtproceed.Rows[0]["bitysnproceed"].ToString());
                }
                catch
                {
                    ysn = false;
                }
                dt = obj.GetDataforAccAdj();
                txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                if (dt.Rows.Count>0)
                {
                    dgvcorrtnaccapp.DataSource = dt;
                    dgvcorrtnaccapp.DataBind();
                    trdate.Visible = true;
                }
                else
                {
                    dgvcorrtnaccapp.DataSource = "";
                    dgvcorrtnaccapp.DataBind();
                    trdate.Visible = false;
                }
                if (ysn == true)
                {
                    dgvcorrtnaccapp.Columns[5].Visible = true;
                }
                else
                {
                    dgvcorrtnaccapp.Columns[5].Visible = false;
                }

            }
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] CommandArgument = btn.CommandArgument.Split(',');
            HttpContext.Current.Session["CustId"] = CommandArgument[0];
            HttpContext.Current.Session["ChallanNo"] = CommandArgument[1];
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CorpReturnJVView.aspx');", true);

        }

        protected void btnACCapp_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    Button btn = (Button)sender;
                    string[] CommandArgument = btn.CommandArgument.Split(',');
                    custid = CommandArgument[0];
                    challanno = CommandArgument[1];
                    ttlamount = CommandArgument[2];
                    intcustid = int.Parse(custid.ToString()); decttlamount = decimal.Parse(ttlamount.ToString());
                    try
                    {
                       if (txtdate.Text == "") { dtedate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); } else { DateTime dtedate2 = DateTime.Parse( txtdate.Text.ToString()); dtedate = DateTime.Parse(dtedate2.ToString("yyyy-MM-dd")); }
                    }
                    catch
                    {
                       dtedate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                  
                   
                    message = "Being the amount adjusted as sales return for Ref No " + challanno;
                    obj.InsertDataToJVBill(intcustid, decttlamount, message);
                    obj.InsertAccAdjAmnt( intcustid, challanno);
                    msg = obj.JVCreate(dtedate, message);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    intEnroll = int.Parse(hdnenroll.Value);
                    try
                    {
                        dtproceed = Bridge.GetProceedPermissionACAdj(intEnroll);
                        ysn = Boolean.Parse(dtproceed.Rows[0][1].ToString());
                    }
                    catch
                    {
                        ysn = false;
                    }
                    dt = obj.GetDataforAccAdj();
                    if (dt.Rows.Count > 0)
                    {
                        dgvcorrtnaccapp.DataSource = dt;
                        dgvcorrtnaccapp.DataBind();
                        trdate.Visible = true;
                    }
                    else
                    {
                        dgvcorrtnaccapp.DataSource = "";
                        dgvcorrtnaccapp.DataBind();
                        trdate.Visible = false;
                    }
                
                    if (ysn == true)
                    {
                        dgvcorrtnaccapp.Columns[5].Visible = true;
                    }
                    else
                    {
                        dgvcorrtnaccapp.Columns[5].Visible = false;
                    }

                }
            }
            catch { }
        }
 
    }
}