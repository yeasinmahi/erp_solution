using SAD_BLL.Sales.Report;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Sales.Report
{
    public partial class CarryingBillJV : BasePage
    {
        private DataTable _dt,dt;
        private ImportAdviceBll _bll = new ImportAdviceBll();
        CarryingBILL objCarrying = new CarryingBILL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime today = DateTime.Now;
                txtDate.Text = new DateTime(today.Year, today.Month, 1).ToString("yyyy/MM/dd");
              
             
            }
        }

      
       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string fdate = txtDate.Text;
            string tdate = txttdate.Text;
            string rate = txtRate.Text;
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Payment/CarryingReport" + "&rate=" + decimal.Parse(rate).ToString()+ "&fdate=" + DateTime.Parse(fdate).ToString("yyyy-MM-dd") +"&Tdate=" + DateTime.Parse(tdate).ToString("yyyy-MM-dd");

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }






        enum Status
        {
            NoDataFound,
            Success,
            AlreadyCreate,
            CanNotCreate,
            UpdateFailed
        }

       

       
        protected void btnCreateVoucher_Click(object sender, EventArgs e)
        {
            if(txtRate.Text!="")
            {
                string fdate = txtDate.Text;
                string tdate = txttdate.Text;
                string rate = txtRate.Text;
                string coaname,Narration= "Amount adjusted for Carrying Bill "; ;
                int coaid,jvid;
                _dt = objCarrying.getCarrringBill(rate, fdate, tdate);
                decimal Totalsum = 0,amount;
                foreach (DataRow _dt in _dt.Rows)
                {
                    Totalsum += decimal.Parse(_dt["TotalAmount"].ToString());
                   
                }
                dt=objCarrying.getCarryingbillJ(Narration, Totalsum,int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()));
                jvid = int.Parse(dt.Rows[0]["Column1"].ToString());
                foreach (DataRow _dt in _dt.Rows)
                {
                    
                    coaid = int.Parse(_dt["intCOAid"].ToString());
                    coaid = int.Parse(_dt["intCOAid"].ToString());
                    coaname = _dt["strName"].ToString();
                    amount = decimal.Parse(_dt["monAmount"].ToString());
                    Narration = "Amount adjusted for Carrying Bill ("+coaname+")";
                   
                    objCarrying.getCarryingbillJV(jvid, coaid, Narration, amount*-1, coaname);

                }
                Narration = "Amount adjusted for Carrying Bill";
                objCarrying.getCarryingbillJV(jvid, 45817, Narration, Totalsum, "Carriage Outwards (Mkt)");
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Create');", true);
            txtRate.Text = "";

        }
    }
}