using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SAD_BLL.Sales;
using SAD_BLL.Customer;
using SAD_DAL.Customer;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Global;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Order
{
    public partial class VehicleSelectView : BasePage
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\VehicleSelectView";
        string stop = "stopping SAD\\Order\\VehicleSelectView";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
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

            if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
            }
            else
            {
                rdoComplete.Enabled = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\VehicleSelectView Vehicle Select View Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
            sv.CancelDO(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";

            switch (("" + completed).ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('VehicleSelect.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "&ship=" + ddlShip.SelectedValue.ToString().ToLower() + "')\"class=\"link\">Assign Vehicle</a>";
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
                string cellDate = ((Label)e.Row.FindControl("Label3")).Text;

                DateTime dodate = CommonClass.GetDateAtSQLDateFormat(cellDate);
                if (ddlSo.SelectedItem.Text.ToUpper() == "BULK" || ddlSo.SelectedItem.Text.ToUpper() == "CORPORATION")
                {
                }
                else
                {

                    //if (DateTime.Now.Subtract(dodate).Days >= 10 && DateTime.Now.Subtract(dodate).Days < 12)
                    //{
                    //    e.Row.BackColor = System.Drawing.Color.Yellow;
                    //}
                    //else if (DateTime.Now.Subtract(dodate).Days >= 12)
                    //{
                    //    e.Row.BackColor = System.Drawing.Color.Red;
                    //}
                    if (DateTime.Now.Subtract(dodate).Days >= 15 && DateTime.Now.Subtract(dodate).Days < 17)
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }
                    //else if (DateTime.Now.Subtract(dodate).Days >= 17)
                    //{
                    //    e.Row.BackColor = System.Drawing.Color.Red;
                    //}
                }

                try
                {
                    totPieces += decimal.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
                    aprPieces += decimal.Parse(((Label)e.Row.Cells[6].Controls[1]).Text);
                    totAmount += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
                }
                catch { }

                if (e.Row.Cells[9].Text == "0") e.Row.BackColor = System.Drawing.Color.LightGreen;
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
            if (GridView1.Rows.Count > 0)
            {
                if (GridView1.Rows.Count == 1 && txtCode.Text.Length > 9)
                {
                    if (GridView1.Rows[0].RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            if (((CheckBox)GridView1.Rows[0].Cells[8].Controls[0]).Checked)
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

            if (rdoComplete.SelectedIndex == 0)
            {
                GridView1.Columns[7].Visible = true;
                //GridView1.Columns[8].Visible = true;
                //GridView1.Columns[9].Visible = true;
            }
            else
            {
                GridView1.Columns[7].Visible = false;
                //GridView1.Columns[8].Visible = false;
                //GridView1.Columns[9].Visible = false;
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
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
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
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            //GetCode();
        }
        protected void lnkDO_Click(object sender, EventArgs e)
        {
            txtCode.Text = ((LinkButton)sender).CommandArgument;
            GridView1.DataBind();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView2.DataBind();
        }
    }
}