using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using UI.ClassFiles;
using SAD_BLL.Vat;
using System.IO;
using System.Xml;
namespace UI.VAT_Management
{
    public partial class Mushak19MonthlyReturn : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intVATAccountID; DateTime dteDate;

        #endregion =====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    hdnVATAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    hdnysnFactory.Value = "0";
                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }

                    dt = new DataTable();
                    dt = objvat.GetVATAccountInfoByID(int.Parse(hdnVATAccID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        lblVATAccountName.Text = dt.Rows[0]["strVatAccountName"].ToString();
                        lblAddress.Text = dt.Rows[0]["strAddress"].ToString();
                        lblPhoneNo.Text = dt.Rows[0]["strPhone"].ToString();
                        lblVATReg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                    }

                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    lblMonth.Text = DateTime.Parse(txtDate.Text).ToString("MMMM");
                    lblYear.Text = DateTime.Parse(txtDate.Text).ToString("yyyy");
                    lblDate.Text = DateTime.Parse(txtDate.Text).ToString("dd MMM, yyyy");
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());

                dt = new DataTable();
                dt = objvat.GetVATAccountInfoByID(intVATAccountID);
                if (dt.Rows.Count > 0)
                {
                    lblVATAccountName.Text = dt.Rows[0]["strVatAccountName"].ToString();
                    lblAddress.Text = dt.Rows[0]["strAddress"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["strPhone"].ToString();
                    lblVATReg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                }
                else
                {
                    lblVATAccountName.Text = "";
                    lblAddress.Text = "";
                    lblPhoneNo.Text = "";
                    lblVATReg.Text = "";
                }
            }
            catch { }
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            lblMonth.Text = DateTime.Parse(txtDate.Text).ToString("MMMM");
            lblYear.Text = DateTime.Parse(txtDate.Text).ToString("yyyy");
            lblDate.Text = DateTime.Parse(txtDate.Text).ToString("dd MMM, yyyy");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
                dteDate = DateTime.Parse(txtDate.Text);

                dt = new DataTable();
                dt = objvat.GetM19Data(intVATAccountID, dteDate);
                if (dt.Rows.Count > 0)
                {
                    lbl1A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column1A"].ToString()), 2).ToString();
                    lbl1B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column1B"].ToString()), 2).ToString();
                    lbl1C.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column1C"].ToString()), 2).ToString();
                    lbl2A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column2A"].ToString()), 2).ToString();
                    lbl3A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column3A"].ToString()), 2).ToString();
                    lbl4A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column4A"].ToString()), 2).ToString();
                    lbl5A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column5A"].ToString()), 2).ToString();
                    lbl6A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column6A"].ToString()), 2).ToString();
                    lbl7A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column7A"].ToString()), 2).ToString();
                    lbl7B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column7B"].ToString()), 2).ToString();
                    lbl8A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column8A"].ToString()), 2).ToString();
                    lbl8B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column8B"].ToString()), 2).ToString();
                    lbl9A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column9A"].ToString()), 2).ToString();
                    lbl9B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column9B"].ToString()), 2).ToString();
                    lbl10A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column10A"].ToString()), 2).ToString();
                    lbl10B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column10B"].ToString()), 2).ToString();
                    lbl11A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column11A"].ToString()), 2).ToString();
                    lbl12A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column12A"].ToString()), 2).ToString();
                    lbl13A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column13A"].ToString()), 2).ToString();
                    lbl14A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column14A"].ToString()), 2).ToString();
                    lbl15A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column15A"].ToString()), 2).ToString();
                    lbl16A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column16A"].ToString()), 2).ToString();
                    lbl16B.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column16B"].ToString()), 2).ToString();
                    lbl16C.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column16C"].ToString()), 2).ToString();
                    lbl17A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column17A"].ToString()), 2).ToString();
                    lbl18A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column18A"].ToString()), 2).ToString();
                    lbl19A.Text = Math.Round(decimal.Parse(dt.Rows[0]["Column19A"].ToString()), 2).ToString();
                }
            }
            catch { }
        }

        protected void btnM11Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
                        dteDate = DateTime.Parse(txtDate.Text);
                    }
                    catch { return; }

                    string message = objvat.InsertM19(dteDate, intVATAccountID, int.Parse(hdnEnroll.Value));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
            }
            catch { }
        }































    }
}