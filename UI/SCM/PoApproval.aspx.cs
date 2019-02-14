using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class PoApproval : BasePage
    {
        private DataTable dt = new DataTable();
        private string[] arrayKey; private char[] delimiterChars = { '[', ']' };

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\PoApproval";
        private string stop = "stopping SCM\\PoApproval";
        private string perform = "Performance on SCM\\PoApproval";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWh();
                LoadDepartment();
                //dt = DataTableLoad.GetPoDataTable(Enroll,14);
                //ddlPoUser.DataSource = dt;
                //ddlPoUser.DataTextField = "strName";
                //ddlPoUser.DataValueField = "Id";
                //ddlPoUser.DataBind();
                //dt.Clear();
            }
        }

        public void LoadDepartment()
        {
            dt = DataTableLoad.GetPoDataTable(Enroll, 24);
            Common.LoadDropDown(ddlDepts, dt, "Id", "strName");
            dt.Clear();
        }

        public void LoadWh()
        {
            dt = DataTableLoad.GetWHDataTable(Enroll);
            Common.LoadDropDownWithAll(ddlWH, dt, "Id", "strName");
            dt.Clear();
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetPoUserSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchPoUser(prefixText);
        }

        #endregion====================Close===============================

        protected void btnPoNoShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPoNoShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnPoNoShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                PoNoShowGrid();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPoNoShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPoNoShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void PoNoShowGrid()
        {
            string strPo = txtPoNo.Text;
            if (string.IsNullOrWhiteSpace(strPo))
            {
                Alert("Please write PO number");
                return;
            }
            if (int.TryParse(strPo, out int poNumber))
            {
                int dept = ddlDepts.SelectedValue();
                dt = DataTableLoad.GetPoViewDataTable(poNumber, Enroll, dept);
                if (dt.Rows.Count > 0)
                {
                    dgvPoApp.DataSource = dt;
                    dgvPoApp.DataBind();
                    dt.Clear();
                }
                else
                {
                    Alert("No data found");
                }
            }
            else
            {
                Alert("Please write po number properly");
            }
        }

        protected void btnPoUserShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPoUserShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnPoUserShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                PoUserGrid();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPoUserShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPoUserShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void PoUserGrid()
        {
            arrayKey = txtPoUser.Text.Split(delimiterChars);
            int enroll = 0;
            string item = ""; string itemid = "";
            if (arrayKey.Length > 0)
            {
                try
                {
                    item = arrayKey[0].ToString();
                    enroll = int.Parse(arrayKey[1].ToString());
                }
                catch { }
            }

            int intwh = int.Parse(ddlWH.SelectedValue);
            int dept = int.Parse(ddlDepts.SelectedValue);
            string xmlData = "<voucher><voucherentry dept=" + '"' + ddlDepts.SelectedItem.ToString() + '"' + "/></voucher>".ToString();
            dt = DataTableLoad.GetPoViewUserDataTable(intwh, enroll, dept, xmlData);
            if (dt.Rows.Count > 0)
            {
                dgvPoApp.DataSource = dt;
                dgvPoApp.DataBind();
                dt.Clear();
            }
            else
            {
                Alert("No data found");
            }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblPO = row.FindControl("lblPoNo") as Label;

                int pono = int.Parse(lblPO.Text.ToString());
                dt = DataTableLoad.GetPoViewDetalisDataTable(pono, Enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSuppliyers.Text = dt.Rows[0]["strSupplierName"].ToString();
                    lblAtten.Text = dt.Rows[0]["strReprName"].ToString();
                    lblPhone.Text = dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSupEmail.Text = dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSuppAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();
                    lblBillTo.Text = dt.Rows[0]["strDescription"].ToString();
                    lblShipTo.Text = dt.Rows[0]["strDeliveryAddress"].ToString();

                    lblPartialShip.Text = dt.Rows[0]["ysnPartialShip"].ToString();
                    lblNoShipment.Text = dt.Rows[0]["intShipment"].ToString();
                    DateTime dteLastship = DateTime.Parse(dt.Rows[0]["dteLastShipmentDate"].ToString());
                    lbllastShipmentDate.Text = dteLastship.ToString("yyyy-MM-dd");
                    lblPaymentTrems.Text = dt.Rows[0]["strPayTerm"].ToString();
                    lblPaymentDaysMrr.Text = dt.Rows[0]["intCreditDays"].ToString();
                    lblNoOfInstallment.Text = dt.Rows[0]["intInstallmentNo"].ToString();
                    lblIntervelDay.Text = dt.Rows[0]["intInstallmentInterval"].ToString();
                    lblDeliveryMonth.Text = dt.Rows[0]["intWarrantyMonth"].ToString();

                    lblTransportCharge.Text = dt.Rows[0]["monFreight"].ToString();
                    lblOthersCharge.Text = dt.Rows[0]["monPacking"].ToString();
                    lblGrossDis.Text = dt.Rows[0]["monDiscount"].ToString();
                    lblComission.Text = "0".ToString();
                    // lblGrandTotal.Text = dt.Rows[0]["monTotal"].ToString();

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                }

                dt = DataTableLoad.GetPoViewItemWaiseDetalisDataTable(pono, Enroll);
                dgvPoDetalis.DataSource = dt;
                dgvPoDetalis.DataBind();

                try
                {
                    Session["pono"] = pono;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PoDetalisView.aspx');", true);
                }
                catch { }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDetalis_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnApproval_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnApproval_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnConfirm.Value == "1")
                {
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    Label lblPO = row.FindControl("lblPoNo") as Label;
                    int pono = int.Parse(lblPO.Text.ToString());
                    string msg = DataTableLoad.POApproval(19, "", pono, Enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                    if (txtPoNo.Text.Length > 1)
                    {
                        dt = DataTableLoad.GetPoViewDataTable(int.Parse(txtPoNo.Text), Enroll, int.Parse(ddlDepts.SelectedValue));
                        dgvPoApp.DataSource = dt;
                        dgvPoApp.DataBind();
                        dt.Clear();
                        PoNoShowGrid();
                    }
                    else
                    {
                        int intwh = int.Parse(ddlWH.SelectedValue);
                        //arrayKey = txtPoUser.Text.Split(delimiterChars);
                        //string item = "";
                        //string itemid = "";
                        //if (arrayKey.Length > 0)
                        //{
                        //    item = arrayKey[0].ToString();
                        //    Enroll = int.Parse(arrayKey[1].ToString());
                        //}
                        string xmlData = "<voucher><voucherentry dept=" + '"' + ddlDepts.SelectedItem.ToString() + '"' + "/></voucher>".ToString();
                        dt = DataTableLoad.GetPoViewUserDataTable(intwh, Enroll, int.Parse(ddlDepts.SelectedValue), xmlData);
                        dgvPoApp.DataSource = dt;
                        dgvPoApp.DataBind();
                        dt.Clear();
                        PoUserGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnApproval_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnApproval_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvPoApp.DataSource = "";
                dgvPoApp.DataBind();
            }
            catch { }
        }
    }
}

public class DataTableLoad
{
    public static Table wh = null;
    public static PoGenerate_BLL objPos = new PoGenerate_BLL();
    public static DataTable ds = new DataTable();

    public static DataTable GetWHDataTable(int Enroll)
    {
        ds = objPos.GetPoData(12, "", 0, 0, DateTime.Now, Enroll);
        return ds;
    }

    public static DataTable GetPoDataTable(int Enroll, int intPart)
    {
        ds = objPos.GetPoData(intPart, "", 0, 0, DateTime.Now, Enroll);
        return ds;
    }

    internal static DataTable GetPoViewUserDataTable(int intwh, int Enroll, int dept, string xmlData)
    {
        ds = objPos.GetPoData(15, xmlData, intwh, dept, DateTime.Now, Enroll);
        return ds;
    }

    internal static DataTable GetPoViewDataTable(int PoId, int Enroll, int dept)
    {
        ds = objPos.GetPoData(16, "", dept, PoId, DateTime.Now, Enroll);
        return ds;
    }

    internal static DataTable GetPoViewDetalisDataTable(int PoId, int Enroll)
    {
        ds = objPos.GetPoData(17, "", 0, PoId, DateTime.Now, Enroll);
        return ds;
    }

    internal static DataTable GetPoViewItemWaiseDetalisDataTable(int pono, int Enroll)
    {
        ds = objPos.GetPoData(18, "", 0, pono, DateTime.Now, Enroll);
        return ds;
    }

    internal static string POApproval(int intPart, string stringXml, int pono, int Enroll)
    {
        string msg = objPos.PoApprove(intPart, stringXml, 0, pono, DateTime.Now, Enroll);
        return msg;
    }
}