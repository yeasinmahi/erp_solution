using BLL.Accounts.Bank;
using System;
using System.Data;
using UI.ClassFiles;
using Utility;

namespace UI.Accounts.Bank
{

    public partial class RoutingNumberEntry : BasePage
    {
        private RoutingNumberEntrybll _bll = new RoutingNumberEntrybll();
        private DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        public void LoadBank()
        {
            txtRouting.Enabled = false;
            _dt = _bll.GetBank();
            ddlBank.Loads(_dt, "intID", "strBankName");
        }
        public void LoadBankBranch()
        {
            _dt = _bll.GetBankBranches();
            ddlBankBranch.Loads(_dt, "intID", "strBankBranchName");
        }

        public void LoadDistrict()
        {
            _dt = _bll.GetBankDistrict();
            ddlBankDistrict.Loads(_dt, "intDistrictID", "strDistrict");
        }

       
     

        public void LoadBankBranchCode()
        {
            txtBankBranchCode.Enabled = true;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string routingNumber = txtRouting.Text;
            int BankID = ddlBank.SelectedIndex;
            int BankBranchID = ddlBankBranch.SelectedIndex;
            int BankDistrict = ddlBankDistrict.SelectedIndex;
            string BankBranchCode = txtBankBranchCode.Text;
            if (string.IsNullOrWhiteSpace(routingNumber) || string.IsNullOrWhiteSpace(BankBranchCode))
            // Response.Write("<script>alert('No Field can BE EMPTY!!!!');</script>");
            {
                Toaster("Please Insert values in all Field!!!!!!"); 
            }
            else
            {
                _dt = _bll.GetInsertData(BankID, BankBranchID, BankDistrict, BankBranchCode, routingNumber);
                if (_dt.Rows.Count >0)
                    Toaster("Information Submitted Successfully!!!!");
            }

            txtRouting.Enabled = true;
            


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string routingNumber = txtRouting.Text;
            _dt = _bll.IsRoutingNumberExists(routingNumber);
            if (_dt.Rows.Count > 0)
            {
                Toaster("This Routing already Exist");
                txtRouting.Enabled = false;
                ddlBank.Enabled = false;
                ddlBankBranch.Enabled = false;
                ddlBankDistrict.Enabled = false;
                txtBankBranchCode.Enabled = false;
                btnSubmit.Enabled = false;
                return;
            }
            LoadBank();
            LoadBankBranch();
            LoadDistrict();
            LoadBankBranchCode();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtRouting.Enabled = true;
            ddlBank.Enabled = true;
            ddlBankBranch.Enabled = true;
            ddlBankDistrict.Enabled = true;
            txtBankBranchCode.Enabled = true;
            btnSubmit.Enabled = true;
        }


    }
}