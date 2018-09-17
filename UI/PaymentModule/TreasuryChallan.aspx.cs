using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GLOBAL_BLL;
using HR_BLL.Payment;
using UI.ClassFiles;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class TreasuryChallan : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/TreasuryChallan.aspx";
        string stop = "stopping PaymentModule/TreasuryChallan.aspx";

        TreasuryChallanBLL objtreasuryChallan = new TreasuryChallanBLL();
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dT = new DataTable();
        DataTable adviceTable = new DataTable();
        char[] delimeters = { '.' }; string[] arraykey;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryChallan.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); dtVdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dtCha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtBankName.Text = "Bangladesh Bank"; txtBranch.Text = "Dhaka"; txtDistrict.Text = "Motijheel";
                lblChallanDate.Text= dtCha.Text; lblDate.Text = dtVdate.Text;
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryChallan.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            int treasuryid = int.Parse(ddlChallan.SelectedItem.Value);
            dt = objtreasuryChallan.getChallanDetails(treasuryid);
            dtt = objtreasuryChallan.getVatreg(treasuryid);
            lblDepositorName.Text= dt.Rows[0]["strDepositorName"].ToString();
            lblDepositorAdd.Text= dt.Rows[0]["strDepositorAddress"].ToString();            
            lblvat.Text = dt.Rows[0]["strTreasuryDepositDescription"].ToString() + " VAT Reg.NO:"+ dtt.Rows[0]["strVATRegNo"].ToString();
            lblcheque.Text = txtBankName.Text + " </br> " + dt.Rows[0]["Column1"].ToString();           
            lblChallanNo.Text = txtChallan.Text;           
            Double total = Convert.ToDouble(dt.Rows[0]["monAmount"].ToString());
            arraykey = dt.Rows[0]["monAmount"].ToString().Split(delimeters);

            if (arraykey.Length > 0)
            {
                lblTaka.Text = arraykey[0].ToString();
                lblPoisha.Text = arraykey[1].ToString();               
            }
            else
            {
                lblPoisha.Text = dt.Rows[0]["Column2"].ToString();
            }
            lblTotalTaka.Text = lblTaka.Text;
            lblTotalPoisha.Text = lblPoisha.Text;
            AmountFormat formatAmount = new AmountFormat();
            string totalAmountInWord = formatAmount.GetTakaInWords(total, "", "Only");
            lblMoney.Text = totalAmountInWord.ToString();

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryChallan.aspx btnSave_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
             
            int treasuryid = int.Parse(ddlChallan.SelectedItem.Value);
            string bankName = txtBankName.Text;
            string branchName = txtBranch.Text;
            string district = txtDistrict.Text;
            string dteChallan = DateTime.Now.ToString("yyyy-MM-dd");
            string challan = txtChallan.Text;
            string instrument = txtCheque.Text;
           
            dT = objtreasuryChallan.updateVat(bankName,district,branchName, dteChallan,challan,instrument,treasuryid);

            fd = log.GetFlogDetail(stop, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShowAdvice_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShowAdvice_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/TreasuryChallan.aspx btnShowAdvice_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            int intVatAcc = int.Parse(ddlUnit.SelectedItem.Value);          
            Response.Redirect("ShowAdviceOfTreasuryChallan.aspx?id=" + intVatAcc + "");

            fd = log.GetFlogDetail(stop, location, "btnShowAdvice_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }




























    }
}