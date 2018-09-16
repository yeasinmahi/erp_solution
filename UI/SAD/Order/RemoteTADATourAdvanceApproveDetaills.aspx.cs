using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADATourAdvanceApproveDetaills : BasePage
    {
        //string strDate; string strTodate;
        DataTable dt = new DataTable(); string id;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADATourAdvanceApproveDetaills";
        string stop = "stopping SAD\\Order\\RemoteTADATourAdvanceApproveDetaills";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveDetaills TADA Tour advane  details", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    //pnlUpperControl.DataBind();
                    id = Session["id"].ToString();
                int autoid = int.Parse(id);
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getTADAAdvanceSingleIDBase(autoid);

                if (dt.Rows.Count > 0)
                {

                    grdvIDBasisPendingTADAShow.DataSource = dt;
                    grdvIDBasisPendingTADAShow.DataBind();
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

        protected void grdvIDBasisPendingTADAShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvIDBasisPendingTADAShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

     


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "approve", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveDetaills TADA Tour advane  approve", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int index = 0;

            TextBox txtintidAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[0].FindControl("txtintidDet");
            TextBox txtintEnrolAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[2].FindControl("txtintEnrolDet");
            TextBox txtdteTourStartdateAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[3].FindControl("txtdteTourStartdateDet");
            TextBox txtdteTourEndDateAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[4].FindControl("txtdteTourEndDateDet");
            TextBox txtdecApproveAmountAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[9].FindControl("txtdecApproveAmountDet");
           

            string strIntid = txtintidAprv.Text;
            string strFrom = txtdteTourStartdateAprv.Text;
            string strTo = txtdteTourEndDateAprv.Text;
            string strEnrol = txtintEnrolAprv.Text;
            string strAprv = txtdecApproveAmountAprv.Text;
            int intid = int.Parse(strIntid.ToString());
            int enr = int.Parse(strEnrol.ToString());
            DateTime dtf = DateTime.Parse(strFrom.ToString());
            DateTime dtT = DateTime.Parse(strTo.ToString());
            Decimal  aprvAmount=decimal.Parse(strAprv.ToString());
           

            int insertby = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());
            string strApproveStatus = "Y";
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            bll.TADAAdvanceApprovebySupervisor(intid, enr, dtf, dtT, aprvAmount, insertby, strApproveStatus);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Insert');", true);

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "approve", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "approve", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Reject", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvanceApproveDetaills TADA Tour advane  Reject", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                int index = 0;

            TextBox txtintidAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[0].FindControl("txtintidDet");
            TextBox txtintEnrolAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[2].FindControl("txtintEnrolDet");
            TextBox txtdteTourStartdateAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[3].FindControl("txtdteTourStartdateDet");
            TextBox txtdteTourEndDateAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[4].FindControl("txtdteTourEndDateDet");
            TextBox txtdecApproveAmountAprv = (TextBox)grdvIDBasisPendingTADAShow.Rows[0].Cells[9].FindControl("txtdecApproveAmountDet");
           
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
            bll.TADAAdvanceApprovebySupervisor(intid, enr, dtf, dtT, aprvAmount, insertby, strApproveStatus);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Rejected');", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert();", true);
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