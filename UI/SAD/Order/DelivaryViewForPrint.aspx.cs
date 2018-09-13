using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{

    public partial class DelivaryViewForPrint : System.Web.UI.Page
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DelivaryViewForPrint";
        string stop = "stopping SAD\\Order\\DelivaryViewForPrint";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "55";
                pnlMarque.DataBind();
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            GridView1.DataBind();

            /*if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
            }
            else
            {
                rdoComplete.Enabled = true;
            }*/
        }

       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\DelivaryViewForPrint Challan Cancel", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
            sv.CancelDO(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";

            switch (completed.ToString().ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('Delivary.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totPieces += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
                aprPieces += decimal.Parse(((Label)e.Row.Cells[8].Controls[1]).Text);
                totAmount += decimal.Parse(((Label)e.Row.Cells[9].Controls[1]).Text);
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            totAmount = 0;
            totPieces = 0;
            aprPieces = 0;
            EnableDisable();
        }

        private void EnableDisable()
        {
            int unit = int.Parse(ddlUnit.SelectedValue.ToString());
            if (unit == 53)
            {
                if (GridView1.Rows.Count > 0)
                {
                    if (GridView1.Rows.Count == 1 && txtCode.Text.Length > 0)
                    {
                        if (GridView1.Rows[0].RowType == DataControlRowType.DataRow)
                        {
                            try
                            {
                                if (((CheckBox)GridView1.Rows[0].Cells[9].Controls[0]).Checked)
                                {
                                    rdoComplete.SelectedIndex = 1;
                                }
                                else
                                {
                                    rdoComplete.SelectedIndex = 0;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            if (rdoComplete.SelectedIndex == 0)
            {
                GridView1.Columns[10].Visible = true;
                GridView1.Columns[11].Visible = true;
                GridView1.Columns[12].Visible = true;
                GridView1.Columns[13].Visible = false;
            }
            else
            {
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = true;
            }
        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[ClassFiles.SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        /*private void GetCode()
        {
            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            ShipPoint sp = new ShipPoint();
            string str = sp.GetPrefix(ddlShip.SelectedValue);
            if (str == "")
            {
                txtCode.Text = "";
            }
            else
            {
                txtCode.Text = str + "-" + pre + "-";
            }
        }*/

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 1) hdnCustomer.Value = temp[temp.Length - 1];
            else hdnCustomer.Value = "";
        }

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{

        //}
        protected string GetPrintLink(object voucherID, object completed)
        {
            string str = "";

            switch (("" + completed).ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('DelivaryViewForPrint.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Details</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void Complete_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string donumber = searchKey[0].ToString();
            Session["donumber"] = donumber;
            string oss = "12";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('DelivaryOrderDetPrint.aspx');", true);

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            //GetCode();
        }


    }
}