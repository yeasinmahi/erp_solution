﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;

namespace UI.SAD.Customer.Report
{
    public partial class Statement : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlMarque.DataBind();

                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);

            }
            else
            {
                // SetReport();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    : Konock/ Apr-24-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId

            string path = "";
            if (rdoType.SelectedIndex == 0)
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Customer/Report/ReportTemplete/Statement.rdlc");
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Customer/Report/ReportTemplete/StatementDrCr.rdlc");
            }
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "", dataSource = "", accountName = "", accountCode = "";
            bool? isAssetOrLiabilities = false;

            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            string cusId = "";
            if (temp.Length > 0)
            {
                cusId = temp[temp.Length - 1];
            }
            StatementC st = new StatementC();
            if (rdoType.SelectedIndex == 0)
            {
                if (cusId == "") return;
                oDTReportData = st.GetStatementByCustomer(txtFrom.Text + " " + ddlFHour.SelectedValue, txtTo.Text + " " + ddlTHour.SelectedValue, cusId
                , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
                dataSource = "odsCustomerStatement";
            }
            else
            {

                oDTReportData = st.GetStatementDrCrByCustomer(txtFrom.Text + " " + ddlFHour.SelectedValue, txtTo.Text + " " + ddlTHour.SelectedValue, cusId
                , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ddlSo.SelectedValue, ddlCusType.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
                dataSource = "odsStatementDrCr";
            }



            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                string dateVal = "";
                if (txtFrom.Text.Trim() == "")
                {
                    dateVal = "As on: " + txtTo.Text;
                }
                else
                {
                    dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                }

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("AccountName", accountName));
                parameters.Add(new ReportParameter("AccountCode", accountCode));
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("Title", "Customer Statement"));
                parameters.Add(new ReportParameter("Date", dateVal));


                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = dataSource;
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }


        /* private void SetReport()
         {
             DataTable table = null;
             string accountName = "", accountCode = "", unitName = "", unitAddress = "";
             bool? isAssetOrLiabilities = false;

             char[] ch = { '[', ']' };
             string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
             string cusId = "";
             if (temp.Length > 0)
             {
                 cusId = temp[temp.Length - 1];
             }
             StatementC st = new StatementC();
             if (rdoType.SelectedIndex == 0)
             {
                 if (cusId == "") return;
                 table = st.GetStatementByCustomer(txtFrom.Text + " " + ddlFHour.SelectedValue, txtTo.Text + " " + ddlTHour.SelectedValue, cusId
                     , Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
             }
             else
             {

                 table = st.GetStatementDrCrByCustomer(txtFrom.Text + " " + ddlFHour.SelectedValue, txtTo.Text + " " + ddlTHour.SelectedValue, cusId
                     , Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlSo.SelectedValue, ddlCusType.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);

             }
             if (table.Rows.Count > 0)
             {

                 if (rdoType.SelectedIndex == 0)
                 {
                     rd.Load(Server.MapPath("Statement.rpt"));
                 }
                 else
                 {
                     rd.Load(Server.MapPath("StatementDrCr.rpt"));
                 }

                 rd.SetDataSource(table);

                 ParameterDiscreteValue pv = new ParameterDiscreteValue();

                 pv.Value = accountName;
                 rd.SetParameterValue("AccountName", pv);

                 pv.Value = accountCode;
                 rd.SetParameterValue("AccountCode", pv);

                 pv.Value = unitName.ToUpper();
                 rd.SetParameterValue("UnitName", pv);

                 pv.Value = unitAddress;
                 rd.SetParameterValue("UnitAddress", pv);

                 pv.Value = "Customer Statement";
                 rd.SetParameterValue("Title", pv);

                 if (txtFrom.Text.Trim() == "")
                 {
                     if (isAssetOrLiabilities == true) pv.Value = "As On " + txtTo.Text;
                     else pv.Value = "Upto: " + txtTo.Text;
                 }
                 else
                 {
                     pv.Value = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                 }
                 rd.SetParameterValue("Date", pv);


                 CrystalReportViewer1.ReportSource = rd;
             }
             else
             {
                 CrystalReportViewer1.ReportSource = null;
             }

         }*/



        //protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        //{
        //    rd.Dispose();
        //    rd.Clone();
        //    rd.Close();
        //    CrystalReportViewer1.Dispose();
        //}
    }
}

