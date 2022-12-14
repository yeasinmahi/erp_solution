using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnWHUpdate : Page
    {
        DataTable dt = new DataTable(); Bridge obj = new Bridge();
        int custid,  fk, productid; string challanno, pk, total;
        decimal productqtysubmit;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Return\\CorpReturnAccAdjust";
        string stop = "stopping SAD\\Sales\\Return\\CorpReturnAccAdjust";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Sales\\Return\\CorpReturnWHUpdate Return Warehouse wise", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    custid = int.Parse(HttpContext.Current.Session["CustId"].ToString());
                    challanno = (HttpContext.Current.Session["ChallanNo"].ToString());
                   
                    dt = obj.GetDataForWHUpdate(custid, challanno);
                    
                    lblCustomer.Text = dt.Rows[0]["Customer"].ToString();
                    lblchalan.Text = dt.Rows[0]["ChallanNo"].ToString();
                    dgv.DataSource = dt;
                    dgv.DataBind();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Return\\CorpReturnWHUpdate Corporate Sales Return Warehouse Recieve", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if ((hdnconfirm.Value =="1") &&(dgv.Rows.Count > 0))
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    fk = int.Parse(((HiddenField)dgv.Rows[i].FindControl("hdfk")).Value.ToString());
                    productid = int.Parse(((HiddenField)dgv.Rows[i].FindControl("hdprodid")).Value.ToString());
                    string  partyqty = ((TextBox)dgv.Rows[i].FindControl("txtpartyrtn")).Text.ToString();
                    string whqty = ((TextBox)dgv.Rows[i].FindControl("txtwhcv")).Text.ToString();
                    decimal partyqtysubmit = Decimal.Parse(partyqty.ToString());
                    decimal whqtysubmit = Decimal.Parse(whqty.ToString());
                    obj.UpdateWHRcv(partyqtysubmit, whqtysubmit, productid, fk);

                        custid = int.Parse(HttpContext.Current.Session["CustId"].ToString());
                        challanno = (HttpContext.Current.Session["ChallanNo"].ToString());
                        pk = (HttpContext.Current.Session["pk"].ToString());
                        total = (HttpContext.Current.Session["total"].ToString());
                        obj.InsertAppv(total, custid.ToString(), challanno, pk);
                    }
                   // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted');window.location.href='/SAD/Sales/Return/CorpReturnAccAdjust.aspx';", true); return;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted');CloseWindow();", true); return;
                }

            else { }
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