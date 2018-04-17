using Purchase_BLL.VehicleRegRenewal_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
  
    public partial class TransPortCostApprovebyHead : BasePage
    {
        DataTable dt = new DataTable();
        RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
        int unitid; int intItem; string sessionID; string alermessageUpdate; int updateby,autoid; string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtVheicleNumber.Attributes.Add("onkeyUp", "SearchText();");
            }
            else
            {
                //if (!String.IsNullOrEmpty(txtVheicleNumber.Text))
                //{
                //    string strvheiclename = txtVheicleNumber.Text;
                //    LoadFieldValueHeadaprove(strvheiclename);

                //}
                //else
                //{
                //    //ClearControls();
                //}
            }
        }
        [WebMethod]
        public static List<string> GetAutoserachingAssetNameforHeadaprv(string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();

            List<string> result = new List<string>();
            result = bll.AutoSearchAssetName(strSearchKey);
            return result;
        }
     
        private void loadgrid()
        {

            try
            {
                int partid = int.Parse(drdlcategory.SelectedValue.ToString());
                int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int rpttypeid = int.Parse(drdlreportype.SelectedValue.ToString());
                bool ysnaprvstatus = Convert.ToBoolean(rpttypeid);
                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                int enr = int.Parse(hdnenrol);
                int jobstaionid = 0;
                
                dt = bll.RouteTransportCostDataApproveforDptHeadForRegistration(partid, unitid, jobstaionid, dteFromDate, dteToDate, rpttypeid, ysnaprvstatus);
            }
            catch
            {
                //
            }

            if (dt.Rows.Count > 0)
            {
                grdvaprvrenewaltransportcost.DataSource = "";
                grdvaprvrenewaltransportcost.DataBind();
                grdvForTransportcostaprvbyHead.DataSource = dt;
                grdvForTransportcostaprvbyHead.DataBind();
                decimal totalregistration = dt.AsEnumerable().Sum(row => row.Field<decimal>("monRegtration"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[3].Text = "Total";
                grdvForTransportcostaprvbyHead.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdvForTransportcostaprvbyHead.FooterRow.Cells[5].Text = totalregistration.ToString("N2");
                decimal totalmonTaxToken = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTaxToken"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[10].Text = totalmonTaxToken.ToString("N2");
                decimal totalmonFitness = dt.AsEnumerable().Sum(row => row.Field<decimal>("monFitness"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[15].Text = totalmonFitness.ToString("N2");
                decimal totalmonRoutePermit = dt.AsEnumerable().Sum(row => row.Field<decimal>("monRoutePermit"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[20].Text = totalmonRoutePermit.ToString("N2");
                decimal totalinsurance = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalinsurance"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[25].Text = totalinsurance.ToString("N2");
                decimal totalnameplatecst = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalnameplate"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[30].Text = totalnameplatecst.ToString("N2");
                decimal totaldrc = dt.AsEnumerable().Sum(row => row.Field<decimal>("totaldrc"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[35].Text = totaldrc.ToString("N2");
                decimal totaldeccost = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotal"));
                grdvForTransportcostaprvbyHead.FooterRow.Cells[39].Text = totaldeccost.ToString("N2");

            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
            }



        }

        private void loadgridforrenewal()
        {

            try
            {
                int partid = int.Parse(drdlcategory.SelectedValue.ToString());
                int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int rpttypeid = int.Parse(drdlreportype.SelectedValue.ToString());
                bool ysnaprvstatus = Convert.ToBoolean(rpttypeid);
           
                int jobstaionid = 0;
                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                int enr = int.Parse(hdnenrol);
                dt = bll.RouteTransportCostDataApproveforDptHeadForRenewal(partid, unitid, jobstaionid, dteFromDate, dteToDate, ysnaprvstatus);
               


            }
            catch
            {
                //
            }

            if (dt.Rows.Count > 0)
            {
                grdvForTransportcostaprvbyHead.DataSource = "";
                grdvForTransportcostaprvbyHead.DataBind();
                grdvaprvrenewaltransportcost.DataSource = dt;
                grdvaprvrenewaltransportcost.DataBind();

                decimal totalregistration = dt.AsEnumerable().Sum(row => row.Field<decimal>("monRegtration"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[3].Text = "Total";
                grdvaprvrenewaltransportcost.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdvaprvrenewaltransportcost.FooterRow.Cells[5].Text = totalregistration.ToString("N2");
                decimal totalmonTaxToken = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTaxToken"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[10].Text = totalmonTaxToken.ToString("N2");
                decimal totalmonFitness = dt.AsEnumerable().Sum(row => row.Field<decimal>("monFitness"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[14].Text = totalmonFitness.ToString("N2");
                decimal totalmonRoutePermit = dt.AsEnumerable().Sum(row => row.Field<decimal>("monRoutePermit"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[18].Text = totalmonRoutePermit.ToString("N2");
                decimal totalinsurance = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalinsurance"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[22].Text = totalinsurance.ToString("N2");
                decimal totalnameplatecst = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalnameplate"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[26].Text = totalnameplatecst.ToString("N2");
                decimal totaldrc = dt.AsEnumerable().Sum(row => row.Field<decimal>("totaldrc"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[30].Text = totaldrc.ToString("N2");
                decimal totaldeccost = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotal"));
                grdvaprvrenewaltransportcost.FooterRow.Cells[33].Text = totaldeccost.ToString("N2");

            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
            }



        }


        protected void btnShow_Click(object sender, EventArgs e)
        {

            int rpttypeid = int.Parse(drdlcategory.SelectedValue.ToString());
            if (rpttypeid == 1) { loadgridforrenewal(); }
            else { loadgrid(); }
           
        }

        protected void grdvForTransportcostaprvbyHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvForTransportcostaprvbyHead_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnDetRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration();", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('Detalis_Registration_UI.aspx');", true);
            }
            catch { }
        }

        protected void btnDetTaxToken_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TaxToken();", true);
            }
            catch { }
        }

        protected void btnDetFitness_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Fitness();", true);
            }
            catch { }
        }

        protected void btnDetRoutePermit_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RoutePermit();", true);
            }
            catch { }
        }

        protected void btnDetInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Insurance();", true);
            }
            catch { }
        }

        protected void btnDetNamePlate_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "NamePlate();", true);
            }
            catch { }
        }

        protected void btnDRC_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DRC();", true);
            }
            catch { }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

            //try
            //{
                int optionselectid = 1;
                int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
                int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                int statustypeid = int.Parse(drdlreportype.SelectedValue.ToString());
               
              
                    if (statustypeid == 0 && grdvForTransportcostaprvbyHead.Rows.Count > 0)
                    {
                       
                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                        int val = 1;
                        autoid = 0;
                        updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                        message = bll.UpdateDeptHeadAprvStaus(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        grdvForTransportcostaprvbyHead.DataSource = "";
                        grdvForTransportcostaprvbyHead.DataBind();
                        if (categoryid == 1) { loadgridforrenewal(); }
                        else { loadgrid(); }
                        
                    }
                   else if (statustypeid == 0 && grdvaprvrenewaltransportcost.Rows.Count > 0)
                    {
                      
                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                        int val = 1;
                        autoid = 0;
                        updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                        message = bll.UpdateDeptHeadAprvStaus(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        grdvaprvrenewaltransportcost.DataSource = "";
                        grdvaprvrenewaltransportcost.DataBind();

                        if (categoryid == 1) { loadgridforrenewal(); }
                        else { loadgrid(); }
                        
                    }

                    else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Sorry there is no data ", true); }
            //}
            
            //catch
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            //}
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void btnRejecttaxtoken_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void btnRejectfitness_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void btnRejectRoutePermit_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void btnRejectInsurance_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void btnRejectNameplate_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRejectDRC_Click(object sender, EventArgs e)
        {
            int optionselectid = 1;
            int categoryid = int.Parse(drdlcategory.SelectedValue.ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 autoid = int.Parse(searchKey[0].ToString());
                int typeid = 2;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int val = 2;
                updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                message = bll.transportcostrejectbyheadofdept(val, updateby, deptid, dteFromDate, dteToDate, optionselectid, autoid, categoryid, unitid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (categoryid == 1) { loadgridforrenewal(); }
                else { loadgrid(); }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);
            }
        }
    }
}