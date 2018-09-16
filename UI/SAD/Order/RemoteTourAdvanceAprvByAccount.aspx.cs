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
    public partial class RemoteTourAdvanceAprvByAccount : BasePage
    {
        
        DataTable dt = new DataTable();
       SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTourAdvanceAprvByAccount";
        string stop = "stopping SAD\\Order\\RemoteTourAdvanceAprvByAccount";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private void Loadgrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTourAdvanceAprvByAccount Tour advane Aprove by Accounts", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dt = bll.getTADAAdvanceForAccountDeptAprv();
                if (dt.Rows.Count > 0)
                {
                    dgvlistTADA.DataSource = dt;
                    dgvlistTADA.DataBind();
                   
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true); }
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

        protected void Complete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTourAdvanceAprvByAccount Tour advane Aprove by Accounts Approve", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intID = searchKey[0].ToString();
            int id = int.Parse(intID);

            Session["id"] = id;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('RemoteTADATourAdvanceApproveAccountDetaills.aspx');", true);
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



      
      
       
    }
}