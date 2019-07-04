﻿using BLL.Accounts.Bank;
using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Accounts.Bank
{
    public partial class BankReceive : BasePage
    {
        BankAccount bankObj = new BankAccount();
        CustomerInfo customerInfoObj = new CustomerInfo();
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                LoadUnitList();
            }

        }
        protected void gridReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int unitid = Convert.ToInt16(ddlUnit.SelectedItem.Value);
                dt = customerInfoObj.GetCustomerListByUnit(unitid);
                var ddlCustomer = (DropDownList)e.Row.FindControl("ddlCustomer");
                ddlCustomer.DataSource = dt;
                ddlCustomer.DataTextField = "strName";
                ddlCustomer.DataValueField = "intCusID";
                ddlCustomer.DataBind();
                ddlCustomer.Items.Insert(0, new ListItem("--Select Customer--", "0"));
            }
         }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string ID  = gridReport.DataKeys[row.RowIndex]?.Value.ToString();
          
            DropDownList ddlcustomer = row.FindControl("ddlCustomer") as DropDownList;

            string CustomerId = ddlcustomer.SelectedValue;
            string CustomerName = ddlcustomer.SelectedItem.Text;

            string Date = (row.FindControl("lblDate") as Label).Text;
            string strChequeNo = (row.FindControl("lblCheque") as Label).Text;
            string monAmount = (row.FindControl("lblAmount") as Label).Text;
            string Other = "";
            try
            {
                 Other = (row.FindControl("txtOther") as TextBox).Text;
            }
            catch
            {
                Other = "";
            }
            
            string Narration = "Amount Received From " + CustomerName+ " Check : "+strChequeNo+ " Amount : "+monAmount+" "+Other+ " Dated : "+Date;
            int unitId = Convert.ToInt32(ddlUnit.SelectedValue);

            string msg = bankObj.SubmitBankReceiveData(unitId, Enroll,Convert.ToInt32( CustomerId),Convert.ToInt32(ID), Narration);
            Toaster(msg, "", Common.TosterType.Success);

            LoadReport();

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadReport();

        }
        public void LoadUnitList()
        {
            dt = unitObj.GetUnits(Enroll.ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        public void LoadReport()
        {
            string unit = ddlUnit.SelectedItem.Value;
            dt = bankObj.GetBankReceiveData(unit);
            gridReport.DataSource = dt;
            gridReport.DataBind();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gridReport_RowDataBound(ddlUnit,null);
        }

       
    }
}