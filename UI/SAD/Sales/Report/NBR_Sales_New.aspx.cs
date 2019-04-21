using SAD_BLL.Customer;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
namespace UI.SAD.Sales.Report
{
    public partial class NBR_Sales_New : BasePage
    {
        string strKey;
        char[] delimiterChars = { '/', ']', ';', '-', '_', '.' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));
            }
            else
            {

            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }
        private void ShowReportDetails()
        {
            try
            {
                string url;
                DataTable oDTReportData = new DataTable();
                string path = "", unitName = "", unitAddress = "", cus = "", pro = "", frm = "", to = "", dateVal = "", dataSource = "";
                //if (rdoType.SelectedIndex == 0)
                //{
                //    path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/Sales.rdlc");
                //}
                //else if (rdoType.SelectedIndex == 1)
                //{
                //    path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesP.rdlc");
                //}
                //else if (rdoType.SelectedIndex == 2)
                //{
                //    path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesS.rdlc");
                //}
                //else
                //{
                //    path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesG.rdlc");
                //}

                char[] ch = { '[', ']' };
                string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    cus = temp[temp.Length - 1];
                }
                catch { }

                temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    pro = temp[temp.Length - 1];
                }
                catch { }

                frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
                to = txtTo.Text + " " + ddlTHour.SelectedValue;

                //string fromDate = txtFrom.Text;



                //DateTime fd = DateTime.Parse(fromDate);
                //string toDate = Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");
                //DateTime fDate, tDate;



                SalesByCusPro st = new SalesByCusPro();
                if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 1 || rdoType.SelectedIndex == 2)
                {


                    oDTReportData = st.GetStatementByCustomerProduct(frm, to, cus, pro
                        , Session[SessionParams.UNIT_ID].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                        , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
                    if (oDTReportData.Rows.Count > 0)
                    {
                        if (cus == "")
                        {
                            cus = "0";
                        }
                        if (pro == "")
                        {
                            pro = "0";
                        }
                        if (rdoType.SelectedIndex == 0)
                        {
                            // fromDate.ToString("YYYY-MM-dd") + "&toDate=" + toDate.ToString("YYYY-MM-dd")

                            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Sales%20And%20Distribution/Sales" + "&fromDate=" + txtFrom.Text + "&toDate=" + txtTo.Text + "&customerId=" + cus + "&productId=" + pro + "&userID=" + Session[SessionParams.USER_ID].ToString() + "&unitID=" + ddlUnit.SelectedValue + "&intCusType=" + ddlCusType.SelectedValue + "&intSOid=" + ddlSo.SelectedValue + "&ysnIncludePromo=" + rdoPromo.SelectedValue + "&rc:LinkTarget=_self";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
                        }
                        else if (rdoType.SelectedIndex == 1)
                        {
                            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Sales%20And%20Distribution/SalesP" + "&fromDate=" + txtFrom.Text.ToString() + "&toDate=" + txtTo.Text.ToString() + "&customerId=" + cus + "&productId=" + pro + "&userID=" + Session[SessionParams.USER_ID].ToString() + "&unitID=" + ddlUnit.SelectedValue + "&intCusType=" + ddlCusType.SelectedValue + "&intSOid=" + ddlSo.SelectedValue + "&ysnIncludePromo=" + rdoPromo.SelectedValue + "&rc:LinkTarget=_self";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
                        }
                        else if (rdoType.SelectedIndex == 2)
                        {
                            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Sales%20And%20Distribution/SalesS" + "&fromDate=" + txtFrom.Text.ToString() + "&toDate=" + txtTo.Text.ToString() + "&customerId=" + cus + "&productId=" + pro + "&userID=" + Session[SessionParams.USER_ID].ToString() + "&unitID=" + ddlUnit.SelectedValue + "&intCusType=" + ddlCusType.SelectedValue + "&intSOid=" + ddlSo.SelectedValue + "&ysnIncludePromo=" + rdoPromo.SelectedValue + "&rc:LinkTarget=_self";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.')", true);
                        //Toaster("Sorry! There is no data against your query.", "Customer Statement", Utility.Common.TosterType.Warning);
                    }


                }
                else
                {
                    oDTReportData = st.GetStatementByCustomerProductGross(frm, to, cus, pro
                        , Session[SessionParams.UNIT_ID].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                        , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
                    if (oDTReportData.Rows.Count > 0)
                    {
                        if (cus == "")
                        {
                            cus = "0";
                        }
                        if (pro == "")
                        {
                            pro = "0";
                        }

                        url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Sales%20And%20Distribution/SalesG" + "&fromDate=" + txtFrom.Text.ToString() + "&toDate=" + txtTo.Text.ToString() + "&customerId=" + cus + "&productId=" + pro + "&userID=" + Session[SessionParams.USER_ID].ToString() + "&unitID=" + ddlUnit.SelectedValue + "&intCusType=" + ddlCusType.SelectedValue + "&intSOid=" + ddlSo.SelectedValue + "&ysnIncludePromo=" + rdoPromo.SelectedValue + "&rc:LinkTarget=_self";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.')", true);
                        //Toaster("Sorry! There is no data against your query.", "Customer Statement", Utility.Common.TosterType.Warning);
                    }

                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}