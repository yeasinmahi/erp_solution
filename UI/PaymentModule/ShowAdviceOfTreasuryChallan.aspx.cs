using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL.Payment;
using System.Data;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class ShowAdviceOfTreasuryChallan : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/ShowAdviceOfTreasuryChallan.aspx";
        string stop = "stopping PaymentModule/ShowAdviceOfTreasuryChallan.aspx";

        TreasuryChallanBLL objtreasuryChallanBLL = new TreasuryChallanBLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/ShowAdviceOfTreasuryChallan.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }

            int intVatAcc = int.Parse(Request.QueryString["id"]);
           
            int intType = 1;

            dt = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            lbldate.Text = dt.Rows[0]["strDescription"].ToString();
            lblmanager.Text = dt.Rows[2]["strDescription"].ToString();
            lblbank.Text = dt.Rows[3]["strDescription"].ToString();
            lbladd.Text = dt.Rows[4]["strDescription"].ToString();
            lblsub.Text = dt.Rows[8]["strDescription"].ToString();
            lbldear.Text = dt.Rows[10]["strDescription"].ToString();
            lblsalam.Text = dt.Rows[11]["strDescription"].ToString();
            lblmsg.Text = dt.Rows[13]["strDescription"].ToString();

            DataTable dt1 = new DataTable();
            intType = 2;
            dt1 = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            DataTable dt2 = new DataTable();
            intType = 3;
            dt2 = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            Label9.Text = dt2.Rows[0]["strMoney"].ToString();

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        decimal totalamount = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monAmount"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label amountLabel = (Label)e.Row.FindControl("lblTotal");

                if (amountLabel != null)
                {
                    amountLabel.Text = totalamount.ToString();
                }

            }
           
                
        }



















    }
}