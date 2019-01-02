using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class InventoryReport : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private DataTable dt = new DataTable(); private int enroll, intwh, intSearchBy, intItem; private string strItem, strTypeId;
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\InventoryReport";
        private string stop = "stopping SCM\\InventoryReport";
        private string perform = "Performance on SCM\\InventoryReport";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DefaultDataBind();
            }
        }

        private void DefaultDataBind()
        {
            var fd = log.GetFlogDetail(start, location, "DefaultDataBind", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "DefaultDataBind", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataValueField = "Id";
                ddlWH.DataTextField = "strName";
                ddlWH.DataBind();

                Session["WareID"] = ddlWH.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefaultDataBind", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "DefaultDataBind", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string strType = ddlCategory.SelectedItem.ToString();

                //string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + " strType=" + '"' + strType + '"' + "/></voucher>".ToString();
                //dt = objIssue.GetViewData(15, xmlData, intwh, 0, DateTime.Now, enroll);
                //ddlList1.DataSource = dt;
                //ddlList1.DataValueField = "Id";
                //ddlList1.DataTextField = "strName";
                //ddlList1.DataBind();
                //lblName.Text = strType;
            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string strType = ddlSearchBy.SelectedItem.ToString();
                try { intItem = int.Parse(txtItemId.Text.ToString()); } catch { }
                strItem = txtItemId.Text.ToString();
                strTypeId = ddlCategory.SelectedValue.ToString();
                //if (strType == "Major Category")
                //{
                //    intSearchBy = 1;
                //}
                //else if (strType == "Cluster")
                //{
                //    intSearchBy = 0;
                //}
                //else if (strType == "Commodity")
                //{
                //    intSearchBy = 2;
                //}
                //else if (strType == "Item")
                //{
                //    if (intItem>0)
                //    {
                //        intSearchBy = 3;
                //        intType = intItem;
                //    }
                //    else
                //    {
                //        intSearchBy = 4;
                //        intType = int.Parse(ddlCategory.SelectedValue);

                //    }

                //}
                //else if (strType == "Minor Category")
                //{
                //    intSearchBy = 8;
                //}
                //else if (strType == "Plant")
                //{
                //    intSearchBy = 9;
                //}
                //else if (strType == "Purchase Type")
                //{
                //   if(strItem=="Local")
                //    {
                //        intType = 1;
                //    }
                //   else if(strItem == "Local")
                //    {
                //        intType = 2;
                //    }
                //}
                //else if (strType == "Store Location")
                //{
                //    intSearchBy = 6;
                //}

                if (strType == "Category")
                {
                    intSearchBy = 1;
                }
                else if (strType == "Sub-Category")
                {
                    intSearchBy = 2;
                }
                else if (strType == "Item")
                {
                    if (Convert.ToInt32(txtItemId.Text.ToString()) > 0)
                    {
                        intSearchBy = 3;
                        strTypeId = intItem.ToString();
                    }
                    else
                    {
                        intSearchBy = 4;
                        strTypeId = txtItemId.Text.ToString();
                    }
                }

                #region===================Start========================
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());

                string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + " strTypeId=" + '"' + strTypeId + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(16, xmlData, intwh, intSearchBy, DateTime.Now, enroll);
                dgvInvnetory.DataSource = dt;
                dgvInvnetory.DataBind();
                #endregion================Close========================
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "ddlSearchBy", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "ddlSearchBy", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string strType = ddlSearchBy.SelectedItem.ToString();

                string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + " strType=" + '"' + strType + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(14, xmlData, intwh, 0, DateTime.Now, enroll);
                ddlCategory.DataSource = dt;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "strName";
                ddlCategory.DataBind();
                lblCategory.Text = strType;
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "ddlSearchBy", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "ddlSearchBy", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}