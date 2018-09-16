using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Order
{
    public partial class RemoteTADATourAdvanceApproveAccountDetaills : Page
    {
        //string strDate; string strTodate;
        DataTable dt = new DataTable(); string id;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADATourAdvanceApproveAccountDetaills";
        string stop = "stopping SAD\\Order\\RemoteTADATourAdvanceApproveAccountDetaills";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveAccountDetaills TADA Tour Advance Details Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    id = Session["id"].ToString();
                int autoid = int.Parse(id);
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getTADAAdvanceSingleIDBaseForAccountDept(autoid);

                if (dt.Rows.Count > 0)
                {

                    grdvAccountIDBasisPendingTADAShow.DataSource = dt;
                    grdvAccountIDBasisPendingTADAShow.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
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

        }

        protected void grdvAccountIDBasisPendingTADAShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvAccountIDBasisPendingTADAShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Approve", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveAccountDetaills TADA Tour Advance Acc Approve", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                int index = 0;

            TextBox txtintidAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[0].FindControl("txtintidDet");
            TextBox txtintEnrolAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[2].FindControl("txtintEnrolDet");
            TextBox txtdteTourStartdateAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[3].FindControl("txtdteTourStartdateDet");
            TextBox txtdteTourEndDateAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[4].FindControl("txtdteTourEndDateDet");
            TextBox txtdecApproveAmountAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[10].FindControl("txtdecAprvByACCOUNT");
           

            string strIntid = txtintidAprv.Text;
            string strFrom = txtdteTourStartdateAprv.Text;
            string strTo = txtdteTourEndDateAprv.Text;
            string strEnrol = txtintEnrolAprv.Text;
            string strAprv = txtdecApproveAmountAprv.Text;
            int intid = int.Parse(strIntid.ToString());
            int enr = int.Parse(strEnrol.ToString());
            DateTime dtf = DateTime.Parse(strFrom.ToString());
            DateTime dtT = DateTime.Parse(strTo.ToString());
            Decimal aprvAmount = decimal.Parse(strAprv.ToString());


            int insertby = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());

            string strApproveStatus = "Y";

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

            bll.TADAAdvanceApprovebyAccountDept(intid, enr, aprvAmount, insertby, dtf);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Insert');", true);
            grdvAccountIDBasisPendingTADAShow.DataSource = null;
            grdvAccountIDBasisPendingTADAShow.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Approve", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Approve", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Reject", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveAccountDetaills TADA Tour Advance Reject", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int index = 0;

            TextBox txtintidAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[0].FindControl("txtintidDet");
            TextBox txtintEnrolAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[2].FindControl("txtintEnrolDet");
            TextBox txtdteTourStartdateAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[3].FindControl("txtdteTourStartdateDet");
            TextBox txtdteTourEndDateAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[4].FindControl("txtdteTourEndDateDet");
            TextBox txtdecApproveAmountAprv = (TextBox)grdvAccountIDBasisPendingTADAShow.Rows[0].Cells[10].FindControl("txtdecAprvByACCOUNT");


            string strIntid = txtintidAprv.Text;
            string strFrom = txtdteTourStartdateAprv.Text;
            string strTo = txtdteTourEndDateAprv.Text;
            string strEnrol = txtintEnrolAprv.Text;
            string strAprv = txtdecApproveAmountAprv.Text;
            int intid = int.Parse(strIntid.ToString());
            int enr = int.Parse(strEnrol.ToString());
            DateTime dtf = DateTime.Parse(strFrom.ToString());
            DateTime dtT = DateTime.Parse(strTo.ToString());
            Decimal aprvAmount = decimal.Parse(strAprv.ToString());


            int insertby = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());

            string strApproveStatus = "N";

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

            bll.TADAAdvanceApprovebyAccountDept(intid, enr, aprvAmount, insertby, dtf);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Insert');", true);
            grdvAccountIDBasisPendingTADAShow.DataSource = null;
            grdvAccountIDBasisPendingTADAShow.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Reject", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Reject", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}