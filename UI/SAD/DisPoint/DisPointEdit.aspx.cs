using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.DisPoint;
using SAD_DAL.DisPoint;
using SAD_BLL.Customer;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;

namespace UI.SAD.DisPoint
{
    public partial class DisPointEdit : BasePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            hdnUnitId.Value = Request.QueryString["unt"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


            }
            else
            {
                //Session["sesUserID"] = "1";            

                if (Request.QueryString["id"] != null)
                {
                    DisPointInfo di = new DisPointInfo();
                    DisPointTDS.QryDisPointDetailsDataTable table = di.GetDataById(Request.QueryString["unt"], Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        txtCusName.Text = table[0].strName;
                        txtCusAddress.Text = table[0].IsstrAddressNull() ? "" : table[0].strAddress;
                        txtCusPhone.Text = table[0].IsstrContactNoNull() ? "" : table[0].strContactNo;
                        txtCusPropitor.Text = table[0].IsstrContactPersonNull() ? "" : table[0].strContactPerson;
                        txtCus.Text = table[0].strCustomerName + " [" + table[0].intCustomerId + "]";
                        chkActive.Checked = table[0].IsysnEnableNull() ? false : table[0].ysnEnable;
                    }
                }
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void btnCusSave_Click(object sender, EventArgs e)
        {
            string cust = "";
            if (txtCus.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                cust = temp[temp.Length - 1];
            }
            else
            {
                cust = "";
            }

            if (cust != "")
            {
                DisPointInfo dis = new DisPointInfo();
                if (Request.QueryString["id"] != null)
                {
                    dis.UpdateDisPoint(Request.QueryString["id"], hdnUnitId.Value, cust, txtCusName.Text, txtCusAddress.Text, txtCusPropitor.Text, txtCusPhone.Text, chkActive.Checked);
                }
                else
                {
                    dis.InsertDisPoint(hdnUnitId.Value, cust, txtCusName.Text, txtCusAddress.Text, txtCusPropitor.Text, txtCusPhone.Text, chkActive.Checked);
                }

                DistributionPointSt.Reload(hdnUnitId.Value);
            }

            Response.Redirect("~/Exit.aspx");
        }
    }
}