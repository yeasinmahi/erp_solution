using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using Purchase_BLL.Commercial;
using UI.ClassFiles;
using Purchase_BLL.SupplyChain;

namespace UI.Inventory
{
    public partial class SupplierApproval : BasePage
    {
        DataTable dt = new DataTable();
        CSM Suppliereport = new CSM();
        CSM report = new CSM();
        CSM bankcheck = new CSM();
        CSM InsertSupplier = new CSM();


        CSM Enlist = new CSM();

        //CSM INSERTsupplierapprovalPurchase = new CSM();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadgrid();

                Button1.Visible = false;
                btnTempory.Visible = false;
                btnMaster.Visible = false;
                btnForign.Visible = false;
                btnclose.Visible = false;
                btnSubmitForeign.Visible = false;
                Button3.Visible = false;

            }


        }

        private void Loadgrid()
        {
            try
            {
                dt = report.SUpplierListforApproval1();
                dgvSuppRequest.DataSource = dt;
                dgvSuppRequest.DataBind();
            }
            catch { }
        }

        protected void submit_Click(object sender, EventArgs e)
        {

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string senderdata = ((Button)sender).CommandArgument.ToString();
            //    Session["test"] = senderdata;

            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('SupplierEnlistment.aspx');", true);


            //}
            //catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string msid = searchKey[0].ToString();
                //string url = "SupplierEnlistment.aspx";
                Session["msid"] = msid;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);

                // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('" + url + "','" + msid + "');", true);

                btnApprove.Visible = false;

                btnSubmitForeign.Visible = false;
                Button3.Visible = false;
                btnTempory.Visible = false;
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                txtEnlishmentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                try
                {
                    if ((int.Parse(Session[SessionParams.USER_ID].ToString()) == 1039) || (int.Parse(Session[SessionParams.USER_ID].ToString()) == 1272))
                    {


                        string strRequestSupID = msid.ToString();
                        //Purchase_BLL.
                        if (strRequestSupID != "" && strRequestSupID != null)
                        {

                            /// int masid = int.Parse(Session["msid"].ToString());
                            int intRequestSupID = int.Parse(strRequestSupID.ToString());
                            dt = bankcheck.GetRequestedSuppInfo(intRequestSupID);
                            txtSuppliername.Text = dt.Rows[0]["strSuppMasterName"].ToString();
                            txtContactNo.Text = dt.Rows[0]["strOrgContactNo"].ToString();
                            txtAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();
                            txtFax.Text = dt.Rows[0]["strOrgFAXNo"].ToString();
                            txtemail.Text = dt.Rows[0]["strOrgMail"].ToString();
                            txtBin.Text = dt.Rows[0]["strBIN"].ToString();
                            txtVatReg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                            txtTin.Text = dt.Rows[0]["strTIN"].ToString();
                            txtTradeLicn.Text = dt.Rows[0]["strTradeLisenceNo"].ToString();
                            ddlBussType.Text = dt.Rows[0]["strBusinessType"].ToString();
                            txtContactP.Text = dt.Rows[0]["strReprName"].ToString();
                            ddlservice.Text = dt.Rows[0]["strServiceType"].ToString();
                            txtPhone.Text = dt.Rows[0]["strReprContactNo"].ToString();
                            //ddlSupplierType.Text = dt.Rows[0]["strSupplierType"].ToString();
                            txtPayTo.Text = dt.Rows[0]["strPayToName"].ToString();
                            txtACNo.Text = dt.Rows[0]["strACNO"].ToString();
                            txtEnlishmentDate.Text = dt.Rows[0]["dteEnlistmentDate"].ToString();
                            txtRouting.Text = dt.Rows[0]["strRoutingNo"].ToString();
                            txtShortName.Text = dt.Rows[0]["strShortName"].ToString();
                            //RadioButton1.Checked = true;
                            txtBank.Text = dt.Rows[0]["strBank"].ToString();
                            txtBankId.Text = dt.Rows[0]["intBankID"].ToString();
                            txtBranch.Text = dt.Rows[0]["strBranch"].ToString();
                            txtDistrictId.Text = dt.Rows[0]["intDistrictID"].ToString();
                            txtBranchId.Text = dt.Rows[0]["intBranchID"].ToString();
                            lblPOTypevalue.Text = dt.Rows[0]["strSupplierType"].ToString();
                            if(lblPOTypevalue.Text == "Foreign Purchase")
                            {
                                Labelotherinformation.Visible = false;
                                btnMaster.Visible = false;
                                btnForign.Visible = true;
                                btnclose.Visible = true;
                                txtPayTo.Visible=false;
                                lblpayto.Visible = false;
                                
                                txtACNo.Visible = false;
                                lblAcNo.Visible = false;

                                txtRouting.Visible = false;
                                lblrouting.Visible = false;
                                txtShortName.Text = dt.Rows[0]["strShortName"].ToString();
                                //RadioButton1.Checked = true;
                                RadioButton1.Visible = false;
                                txtBank.Visible = false;
                                lblbank.Visible = false;
                                txtBankId.Visible = false;
                                lblbankid.Visible = false;
                                txtBranch.Visible = false;
                                lblbranch.Visible = false;
                                lblbranchid.Visible = false;
                                txtDistrictId.Visible = false;
                                lbldistrictid.Visible = false;
                                txtBranchId.Visible = false;
                                lblbranchid.Visible = false;
                                

                            }

                            else if (lblPOTypevalue.Text == "Local Fabrication")
                            {

                                Labelotherinformation.Visible = true;
                                btnMaster.Visible = true;
                                btnForign.Visible = false;
                                btnclose.Visible = true;
                                txtPayTo.Visible = true;
                                lblpayto.Visible = true;

                                txtACNo.Visible = true;
                                lblAcNo.Visible = true;

                                txtRouting.Visible = true;
                                lblrouting.Visible = true;
                               
                                RadioButton1.Visible = true;
                                txtBank.Visible = true;
                                lblbank.Visible = true;
                                txtBankId.Visible = true;
                                lblbankid.Visible = true;
                                txtBranch.Visible = true;
                                lblbranch.Visible = true;
                                lblbranchid.Visible = true;
                                txtDistrictId.Visible = true;
                                lbldistrictid.Visible = true;
                                txtBranchId.Visible = true;
                                lblbranchid.Visible = true;

                            }

                            else if (lblPOTypevalue.Text == "Local Purchase")
                            {
                                Labelotherinformation.Visible = true;
                                //Button1.Visible = true;
                                //btnTempory.Visible = true;
                                btnMaster.Visible = true;
                                btnForign.Visible = false;
                                btnclose.Visible = true;
                                txtPayTo.Visible = true;
                                lblpayto.Visible = true;

                                txtACNo.Visible = true;
                                lblAcNo.Visible = true;

                                txtRouting.Visible = true;
                                lblrouting.Visible = true;

                                RadioButton1.Visible = true;
                                txtBank.Visible = true;
                                lblbank.Visible = true;
                                txtBankId.Visible = true;
                                lblbankid.Visible = true;
                                txtBranch.Visible = true;
                                lblbranch.Visible = true;
                                lblbranchid.Visible = true;
                                txtDistrictId.Visible = true;
                                lbldistrictid.Visible = true;
                                txtBranchId.Visible = true;
                                lblbranchid.Visible = true;
                            }
                            else { }

                        }
                        }
                }
                catch { }


            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }


        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            ////EditAndApprove();
            ////

            try
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                //Response.Write(enroll);
                ////DataTable dtcount = new DataTable();
                ////dtcount = bankcheck.getcount(enroll);
                ////Int32 permissioncoun = Convert.ToInt32(dtcount.Rows[0]["count"].ToString());
                int permissioncoun = 1;
                if (permissioncoun > 0)
                {

                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    int intSuppid = int.Parse(searchKey[0].ToString());
                    //  Response.Write(intSuppid);
                    //Session["ordernumber"] = intid; Complete1_Click

                    report.getSupplierApproval(enroll, intSuppid);
                   // report.InsertSupplierApprove(intSuppid, enroll);

                    string mesages = report.GridSubmitMasterSupplier(1, intSuppid, enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mesages + "');", true);
                    dt = new DataTable();
                    dt = report.SUpplierListforApproval1();
                    dgvSuppRequest.DataSource = dt;
                    dgvSuppRequest.DataBind();
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Approved.');", true);

            }

}


        protected void Complete2_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                DataTable dtcount = new DataTable();
                dtcount = bankcheck.getcount(enroll);
                Int32 permissioncoun = Convert.ToInt32(dtcount.Rows[0]["count"].ToString());
                if (permissioncoun > 0)
                {

                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);
                    Int32 intSuppid = int.Parse(searchKey[0].ToString());
                    report.GetSuppReject(enroll, intSuppid);
                    msg = "Rejected.";
                    Loadgrid();
                }
            }
            catch { msg = "Sorry to reject."; }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        }



      


        protected void submit_Clicken(object sender, EventArgs e)
        {
            try
            {

                if (hdnconfirm.Value == "1")
                {
                    string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                    string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
                    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                    int intRequestBy; string strShortName; string strACNO; string strRoutingNo; string strBank; string strBranch; int intBankID; int intDistrictID; int intBranchID;



                    //if (txtSuppliername.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Supplier Name.');", true); return; } 
                    //else { strSuppMasterName = txtSuppliername.Text; }

                    //if (txtAddress.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Address');", true); return; } 
                    //else { strOrgAddress = txtAddress.Text; }
                    //if (txtContactP.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Contact Person');", true); return; } 
                    //else { strReprName = txtContactP.Text; }
                    //if (txtPhone.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Phone No');", true); return; } 
                    //else { strReprContactNo = txtPhone.Text; }

                    //if (ddlBussType.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Business Type');", true); return; } 
                    //else { strBusinessType = ddlBussType.SelectedItem.ToString(); }
                    //if (ddlservice.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Service Type');", true); return; } 
                    //else { strServiceType = ddlservice.SelectedItem.ToString(); }

                    //if (ddlSupplierType.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Supplier Type');", true); return; } 
                    //else { strSupplierType = ddlSupplierType.SelectedItem.ToString(); }

                    //if (txtPayTo.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Pay To Name');", true); return; }
                    //else { strPayToName = txtPayTo.Text; }

                    //if (txtACNo.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input A/C No');", true); return; }
                    //else { strACNO = txtACNo.Text; }

                    //if (txtRouting.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Routing No');", true); return; } 
                    //else { strRoutingNo = txtRouting.Text; }
                    //RadioButton1.Checked = false;

                    //if (txtEnlishmentDate.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Enlistment Date');", true); return; }
                    //else { dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text); }



                    //if (txtACNo.MaxLength == 13)

                    //{ 
                    strSuppMasterName = txtSuppliername.Text;
                    strOrgAddress = txtAddress.Text;
                    strOrgMail = txtemail.Text;
                    strOrgContactNo = txtContactNo.Text;
                    strOrgFAXNo = txtFax.Text;
                    strBusinessType = ddlBussType.SelectedItem.ToString();
                    strServiceType = ddlservice.SelectedItem.ToString();
                    strBIN = txtBin.Text;
                    strTIN = txtTin.Text;
                    strVATRegNo = txtVatReg.Text;
                    strTradeLisenceNo = txtTradeLicn.Text;
                    strReprName = txtContactP.Text;
                    strReprContactNo = txtPhone.Text;

                    strPayToName = txtPayTo.Text;
                    strSupplierType = ddlSupplierType.SelectedItem.ToString();

                    strShortName = txtShortName.Text;
                    strACNO = txtACNo.Text;
                    strRoutingNo = txtRouting.Text;
                    strBank = txtBank.Text;
                    strBranch = txtBranch.Text;
                    intBankID = int.Parse(txtBankId.Text);
                    intDistrictID = int.Parse(txtDistrictId.Text);
                    intBranchID = int.Parse(txtBranchId.Text);
                    dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);


                    ///string ddldate = ddlDate.SelectedItem.ToString();
                    ///string ddlmonth = ddlMonth.SelectedValue.ToString();
                    ///string ddlyear = ddlMonth.SelectedItem.ToString();
                    ///string finaldate = ddldate + '-' + ddlmonth + '-' + ddlyear;
                    ///dteEnlistmentDate = Convert.ToDateTime(finaldate.ToString()); 
                    ///dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);


                    intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());



                    //if (txtBranch.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true); return; }

                    //else { RadioButton1.Checked = false; }



                    // intRequestBy = Convert.ToInt32("1039");
                    strShortName = txtShortName.Text;
                    // (strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName,strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID)
                    Enlist.InsertNewSuppliernew(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);


                    txtSuppliername.Text = "";
                    txtemail.Text = "";
                    txtContactNo.Text = "";
                    txtFax.Text = "";
                    ddlBussType.DataBind();
                    ddlservice.DataBind();
                    txtBin.Text = "";
                    txtTin.Text = "";
                    txtVatReg.Text = "";
                    txtTradeLicn.Text = "";
                    txtContactP.Text = "";
                    txtAddress.Text = "";
                    ddlSupplierType.DataBind();
                    txtACNo.Text = "";
                    txtRouting.Text = "";
                    txtBank.Text = "";
                    txtBranch.Text = "";
                    txtBankId.Text = "";
                    txtDistrictId.Text = "";
                    txtBranchId.Text = "";
                    txtPhone.Text = "";
                    ddlservice.DataBind();
                    //txtEnlishmentDate.Text = "";
                    txtPayTo.Text = "";
                    txtShortName.Text = "";


                    //DataTable EnrollwiseReport = new DataTable();
                    ////scm enrollReport = new SCM();
                    //CSM enrollReport = new CSM();


                    //EnrollwiseReport = enrollReport.EnrollwiseReport(intRequestBy);
                    //dgvlist.DataSource = EnrollwiseReport;
                    //dgvlist.DataBind();
                    //}
                    //else 
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account No Must be 13 digit !');", true);
                    //}

                }
            }
            catch { }
        }

        protected void txtSuppliername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtShortName.Text = txtSuppliername.Text;

            }
            catch { }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           string strRoutingNo = txtRouting.Text;
            if (strRoutingNo == "" || strRoutingNo.Length!=9)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Routing number in nine digit format');", true);
            }

            ChechRoutingNo();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
        }

        private void ChechRoutingNo()
        {
            try
            {
                DataTable dtbankcheck = new DataTable();
                string Routingnumber = txtRouting.Text;
                // dtbankcheck = bankcheck.getbankcheck(Routingnumber);
                dtbankcheck = bankcheck.getbankcheckNo(Routingnumber);
                string strBankName = dtbankcheck.Rows[0]["strBankName"].ToString();
                string strBankBranchName = dtbankcheck.Rows[0]["strBankBranchName"].ToString();

                string strBankId = dtbankcheck.Rows[0]["intBankID"].ToString();
                string strdistrictId = dtbankcheck.Rows[0]["intDistrictID"].ToString();
                string strBranchId = dtbankcheck.Rows[0]["intBranchID"].ToString();



                txtBank.Text = strBankName;
                txtBranch.Text = strBankBranchName;
                txtBankId.Text = strBankId;
                txtDistrictId.Text = strdistrictId;
                txtBranchId.Text = strBranchId;

                //if (txtBranch.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true); return; }

                //else { strBankBranchName = txtBranch.Text; }
                RadioButton1.Checked = false;
            }
            catch { RadioButton1.Checked = false; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true); }

        }


        //protected void btnEdit_Click2(object sender, EventArgs e)
        //{
        //    if (hdnconfirm.Value == "1")
        //    {
        //        string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
        //        string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
        //        //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
        //        int RequestBy; string strShortName; string strACNO; string strRoutingNo; string strBank; string strBranch; int BankID; int DistrictID; int BranchID;

        //        strSuppMasterName = txtSuppliername.Text;
        //        strOrgAddress = txtAddress.Text;
        //        strOrgMail = txtemail.Text;
        //        strOrgContactNo = txtContactNo.Text;
        //        strOrgFAXNo = txtFax.Text;
        //        strBusinessType = ddlBussType.SelectedItem.ToString();
        //        strServiceType = ddlservice.SelectedItem.ToString();
        //        strBIN = txtBin.Text;
        //        strTIN = txtTin.Text;
        //        strVATRegNo = txtVatReg.Text;
        //        strTradeLisenceNo = txtTradeLicn.Text;
        //        strReprName = txtContactP.Text;
        //        strReprContactNo = txtPhone.Text;
        //        strPayToName = txtPayTo.Text;
        //        strSupplierType = ddlSupplierType.SelectedItem.ToString();
        //        strShortName = txtShortName.Text;
        //        strACNO = txtACNo.Text;
        //        strRoutingNo = txtRouting.Text;
        //        strBank = txtBank.Text;
        //        strBranch = txtBranch.Text;
        //        BankID = int.Parse(txtBankId.Text);
        //        DistrictID = int.Parse(txtDistrictId.Text);
        //        BranchID = int.Parse(txtBranchId.Text);
        //        dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
        //        Int32 MasterId = int.Parse(Session["msid"].ToString());

        //        RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
        //        dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());

        //        string msg = "";
        //        //Enlist.INSERTMASTERSUPPLIERFINAL(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);
        //        //msg = Enlist.InsertNewSupplierEdit(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, MasterId);

        //        // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);

        //        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        //        //Response.Redirect("~/Inventory/SupplierFinal.aspx");
        //        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

        //        //Response.Redirect("~/Default.aspx");
        //        ////Response.Redirect("~/Inventory/SupplierFinal.aspx");



        //    }
        //}

        protected void ddlSupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {


            string strSupplierType;
            strSupplierType = ddlSupplierType.SelectedItem.ToString();
            Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
            if (suppliertypeid == 3)
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = false;
                btnApprove.Visible = false;
                btnSubmitForeign.Visible = false;
                Button3.Visible = false;
                txtPayTo.Visible = false;

                chkBox1.Visible = false;

                lblbank.Visible = false;
                lblpayto.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblAcNo.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;
               
                hid.Value = txtSuppliername.Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", false);
               
            }
            else if (suppliertypeid == 2)
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = false;
                btnApprove.Visible = false;
                btnSubmitForeign.Visible = false;
                Button3.Visible = false;
                txtPayTo.Visible = false;

                chkBox1.Visible = false;

                lblbank.Visible = false;
                lblpayto.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblAcNo.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;

                hid.Value = txtSuppliername.Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", false);

            }


            else 
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = true;
                btnApprove.Visible = true;
                btnSubmitForeign.Visible = true;
                Button3.Visible = true;
                txtPayTo.Visible = false;

                chkBox1.Visible = false;

                lblbank.Visible = false;
                lblpayto.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblAcNo.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;

                hid.Value = txtSuppliername.Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", false);

            }

            if ((int.Parse(Session[SessionParams.USER_ID].ToString()) == 1039) || (int.Parse(Session[SessionParams.USER_ID].ToString()) == 1392))
            { btnTempory.Visible = true; }
        }

        protected void submit_ClickForeign(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {

                string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
                //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                int RequestBy; string strShortName;

                strSuppMasterName = txtSuppliername.Text;
                strOrgAddress = txtAddress.Text;
                strOrgMail = txtemail.Text;
                strOrgContactNo = txtContactNo.Text;
                strOrgFAXNo = txtFax.Text;
                strBusinessType = ddlBussType.SelectedItem.ToString();
                strServiceType = ddlservice.SelectedItem.ToString();
                strBIN = txtBin.Text;
                strTIN = txtTin.Text;
                strVATRegNo = txtVatReg.Text;
                strTradeLisenceNo = txtTradeLicn.Text;
                strReprName = txtContactP.Text;
                strReprContactNo = txtPhone.Text;
                strPayToName = txtPayTo.Text;
                strSupplierType = ddlSupplierType.SelectedItem.ToString();
                strShortName = txtShortName.Text;
                //strACNO = txtACNo.Text;
                //strRoutingNo = txtRouting.Text;
                //strBank = txtBank.Text;
                //strBranch = txtBranch.Text;
                //BankID = int.Parse(txtBankId.Text);
                //DistrictID = int.Parse(txtDistrictId.Text);
                //BranchID = int.Parse(txtDistrictId.Text);
                dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
                //Int32 MasterId = int.Parse(Session["msid"].ToString());

                RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());
                strSuppMasterName = hid.Value;

                try
                {

                    strSupplierType = ddlSupplierType.SelectedItem.ToString();
                    Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
                    if (suppliertypeid == 3)
                    {
                        txtACNo.Enabled = false;
                        txtRouting.Enabled = false;
                        txtBank.Enabled = false;
                        txtBranch.Enabled = false;
                        txtBankId.Enabled = false;
                        txtDistrictId.Enabled = false;
                        txtBranchId.Enabled = false;



                    }

                    //Enlist.InsertSupplierMaster(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);

                    Enlist.InsertSupplierDumpFTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);


                    txtSuppliername.Text = "";
                    txtemail.Text = "";
                    txtContactNo.Text = "";
                    txtFax.Text = "";
                    ddlBussType.DataBind();
                    ddlservice.DataBind();
                    txtBin.Text = "";
                    txtTin.Text = "";
                    txtVatReg.Text = "";
                    txtTradeLicn.Text = "";
                    txtContactP.Text = "";
                    txtAddress.Text = "";
                    ddlSupplierType.DataBind();
                    txtPhone.Text = "";
                    ddlservice.DataBind();
                    //txtEnlishmentDate.Text = "";
                    txtPayTo.Text = "";
                    txtShortName.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);

                }


                catch { }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "RefreshParent();", true);
            }
        }


        protected void submit_ClickforignDump(object sender, EventArgs e)
        {

            //if (hdnconfirm.Value == "1")
            //{
            string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
            string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
            //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
            int intRequestBy; string strShortName;

            strSuppMasterName = txtSuppliername.Text;
            strOrgAddress = txtAddress.Text;
            strOrgMail = txtemail.Text;
            strOrgContactNo = txtContactNo.Text;
            strOrgFAXNo = txtFax.Text;
            strBusinessType = ddlBussType.SelectedItem.ToString();
            strServiceType = ddlservice.SelectedItem.ToString();
            strBIN = txtBin.Text;
            strTIN = txtTin.Text;
            strVATRegNo = txtVatReg.Text;
            strTradeLisenceNo = txtTradeLicn.Text;
            strReprName = txtContactP.Text;
            strReprContactNo = txtPhone.Text;

            strPayToName = txtPayTo.Text;
            strSupplierType = ddlSupplierType.SelectedItem.ToString();

            strShortName = txtShortName.Text;

            dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

            intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            strShortName = txtShortName.Text;

            Enlist.InsertSupplierDumpForeign(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);


            txtSuppliername.Text = "";
            txtemail.Text = "";
            txtContactNo.Text = "";
            txtFax.Text = "";
            ddlBussType.DataBind();
            ddlservice.DataBind();
            txtBin.Text = "";
            txtTin.Text = "";
            txtVatReg.Text = "";
            txtTradeLicn.Text = "";
            txtContactP.Text = "";
            txtAddress.Text = "";
            ddlSupplierType.DataBind();
            txtPhone.Text = "";
            ddlservice.DataBind();
            //txtEnlishmentDate.Text = "";

            //}
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        }

        protected void chkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //string strSupplierType;
            //strSupplierType = ddlSupplierType.SelectedItem.ToString();
            //Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
            if (((chkBox1)).Checked == true)
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = false;
                btnApprove.Visible = false;

                RadioButton1.Visible = false;
                lblbank.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;
                btnSubmitForeign.Visible = true;
                btnApprove.Visible = false;
                btnSubmitForeign.Visible = false;
                lblAcNo.Visible = false;
                Button3.Visible = true;
                Button1.Visible = false;
                btnApprove.Visible = false;

                //txtSuppliername.Text = txtPayTo.Text;
                hid.Value = txtSuppliername.Text;


                //Divinfo.Visible = false;
            }
            else if (((chkBox1)).Checked == false)
            {
                txtACNo.Visible = true;
                txtRouting.Visible = true;
                txtBank.Visible = true;
                txtBranch.Visible = true;
                txtBankId.Visible = true;
                txtDistrictId.Visible = true;
                txtBranchId.Visible = true;

                btnApprove.Visible = true;
                //btnEdit0.Visible = true;
                //btnEdit.Visible = true;
                RadioButton1.Visible = true;
                lblbank.Visible = true;
                lblrouting.Visible = true;
                RadioButton1.Visible = true;
                lblbankid.Visible = true;
                lblbranch.Visible = true;
                lblbranchid.Visible = true;
                lbldistrictid.Visible = true;
                lblAcNo.Visible = true;
                Button3.Visible = false;
                Button1.Visible = true;
                btnApprove.Visible = false;


            }
        }

        protected void submitTempory_Click(object sender, EventArgs e)
        {

            //if (hdnconfirm.Value == "1")
            //{
            //    string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
            //    string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
            //    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
            //    int intRequestBy; string strShortName;

            //    strSuppMasterName = txtSuppliername.Text;
            //    strOrgAddress = txtAddress.Text;
            //    strOrgMail = txtemail.Text;
            //    strOrgContactNo = txtContactNo.Text;
            //    strOrgFAXNo = txtFax.Text;
            //    strBusinessType = ddlBussType.SelectedItem.ToString();
            //    strServiceType = ddlservice.SelectedItem.ToString();
            //    strBIN = txtBin.Text;
            //    strTIN = txtTin.Text;
            //    strVATRegNo = txtVatReg.Text;
            //    strTradeLisenceNo = txtTradeLicn.Text;
            //    strReprName = txtContactP.Text;
            //    strReprContactNo = txtPhone.Text;

            //    strPayToName = txtPayTo.Text;
            //    strSupplierType = ddlSupplierType.SelectedItem.ToString();

            //    strShortName = txtShortName.Text;

            //    dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

            //    intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            //    strShortName = txtShortName.Text;

            //    Enlist.InsertSupplierDumpFTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);


            //    txtSuppliername.Text = "";
            //    txtemail.Text = "";
            //    txtContactNo.Text = "";
            //    txtFax.Text = "";
            //    ddlBussType.DataBind();
            //    ddlservice.DataBind();
            //    txtBin.Text = "";
            //    txtTin.Text = "";
            //    txtVatReg.Text = "";
            //    txtTradeLicn.Text = "";
            //    txtContactP.Text = "";
            //    txtAddress.Text = "";
            //    ddlSupplierType.DataBind();
            //    txtPhone.Text = "";
            //    ddlservice.DataBind();
            //    //txtEnlishmentDate.Text = "";
            //    txtPayTo.Text = "";
            //    txtShortName.Text = "";

            //}
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Not Allowed Please send via mail');", true);
        }

        protected void btnTempory_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
                //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                int intRequestBy; string strShortName;

                strSuppMasterName = txtSuppliername.Text;
                strOrgAddress = txtAddress.Text;
                strOrgMail = txtemail.Text;
                strOrgContactNo = txtContactNo.Text;
                strOrgFAXNo = txtFax.Text;
                strBusinessType = ddlBussType.SelectedItem.ToString();
                strServiceType = ddlservice.SelectedItem.ToString();
                strBIN = txtBin.Text;
                strTIN = txtTin.Text;
                strVATRegNo = txtVatReg.Text;
                strTradeLisenceNo = txtTradeLicn.Text;
                strReprName = txtContactP.Text;
                strReprContactNo = txtPhone.Text;

                strPayToName = txtPayTo.Text;
                strSupplierType = ddlSupplierType.SelectedItem.ToString();

                strShortName = txtShortName.Text;

                dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

                intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                strShortName = txtShortName.Text;

                Enlist.InsertMasterSupplierTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);


                txtSuppliername.Text = "";
                txtemail.Text = "";
                txtContactNo.Text = "";
                txtFax.Text = "";
                ddlBussType.DataBind();
                ddlservice.DataBind();
                txtBin.Text = "";
                txtTin.Text = "";
                txtVatReg.Text = "";
                txtTradeLicn.Text = "";
                txtContactP.Text = "";
                txtAddress.Text = "";
                ddlSupplierType.DataBind();
                txtPhone.Text = "";
                ddlservice.DataBind();
                //txtEnlishmentDate.Text = "";
                txtPayTo.Text = "";
                txtShortName.Text = "";

            }
        }

        protected void btnForign_Click(object sender, EventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{

                string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
                //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                int RequestBy ,BankID, DistrictID, BranchID,  MasterId; string strShortName, strACNO, strRoutingNo;


                strSuppMasterName = txtSuppliername.Text;
                strOrgAddress = txtAddress.Text;
                strOrgMail = txtemail.Text;
                strOrgContactNo = txtContactNo.Text;
                strOrgFAXNo = txtFax.Text;
                strBusinessType = ddlBussType.SelectedItem.ToString();
                strServiceType = ddlservice.SelectedItem.ToString();
                strBIN = txtBin.Text;
                strTIN = txtTin.Text;
                strVATRegNo = txtVatReg.Text;
                strTradeLisenceNo = txtTradeLicn.Text;
                strReprName = txtContactP.Text;
                strReprContactNo = txtPhone.Text;
                strPayToName = txtPayTo.Text;
                strSupplierType = ddlSupplierType.SelectedItem.ToString();
                strShortName = txtShortName.Text;
                //strACNO = txtACNo.Text;
                //strRoutingNo = txtRouting.Text;
                //strBank = txtBank.Text;
                //strBranch = txtBranch.Text;
                //BankID = int.Parse(txtBankId.Text);
                //DistrictID = int.Parse(txtDistrictId.Text);
                //BranchID = int.Parse(txtDistrictId.Text);
                dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
                //Int32 MasterId = int.Parse(Session["msid"].ToString());

                RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());
                //strSuppMasterName = hid.Value;

                //try
                //{

                    strSupplierType = ddlSupplierType.SelectedItem.ToString();
                    Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
            //if (suppliertypeid == 3)
            //{
            //    txtACNo.Text = "";
            //    txtRouting.Text = "";
            //    txtBank.Text = "";
            //    txtBranch.Text = "";
            //    txtBankId.Text ="0"; 
            //    txtDistrictId.Text = "";
            //    txtBranchId.Text = "0";



            //}

            //Enlist.InsertSupplierMaster(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);

            //Enlist.InsertSupplierDumpFTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);
            BankID = 0; DistrictID = 0; BranchID = 0; strACNO = ""; strRoutingNo = ""; MasterId = 0;
            string msg = "";
           
            msg = Enlist.InsertNewSupplierEdit(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, MasterId);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "ClosehdnDivision();", true);
            txtSuppliername.Text = "";
                    txtemail.Text = "";
                    txtContactNo.Text = "";
                    txtFax.Text = "";
                    ddlBussType.DataBind();
                    ddlservice.DataBind();
                    txtBin.Text = "";
                    txtTin.Text = "";
                    txtVatReg.Text = "";
                    txtTradeLicn.Text = "";
                    txtContactP.Text = "";
                    txtAddress.Text = "";
                    ddlSupplierType.DataBind();
                    txtPhone.Text = "";
                    ddlservice.DataBind();
                    //txtEnlishmentDate.Text = "";
                    txtPayTo.Text = "";
                    txtShortName.Text = "";
            //}


            //catch { }
            //}
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "ClosehdnDivision();", true);
        }


        protected void btnMaster_Click(object sender, EventArgs e)
        {
            EditAndApprove();
            Loadgrid();
        }

        private void EditAndApprove()
        {
            try
            {

                if (hdnconfirm.Value == "1")
                {
                    string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                    string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
                    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                    int RequestBy; string strShortName; string strACNO; string strRoutingNo; string strBank; string strBranch; int BankID; int DistrictID; int BranchID;
                    strPayToName = txtPayTo.Text;
                    strRoutingNo = txtRouting.Text;
                    strACNO = txtACNo.Text;
                    strReprContactNo = txtPhone.Text.ToString();
                    if (strReprContactNo.Length != 11)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Contact Number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }


                    if (strPayToName == "")
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Pay to Name');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }
                    else if (strRoutingNo.Length != 9)
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Routing number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }
                    else if (strACNO.Length != 13)
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Account number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }

                    else if (strPayToName != "" && strRoutingNo.Length == 9 && strACNO.Length == 13 && strReprContactNo.Length == 11)
                    {
                        strSuppMasterName = txtSuppliername.Text;
                        strOrgAddress = txtAddress.Text;
                        strOrgMail = txtemail.Text;
                        strOrgContactNo = txtContactNo.Text;
                        strOrgFAXNo = txtFax.Text;
                        strBusinessType = ddlBussType.SelectedItem.ToString();
                        strServiceType = ddlservice.SelectedItem.ToString();
                        strBIN = txtBin.Text;
                        strTIN = txtTin.Text;
                        strVATRegNo = txtVatReg.Text;
                        strTradeLisenceNo = txtTradeLicn.Text;
                        strReprName = txtContactP.Text;
                        strReprContactNo = txtPhone.Text;
                        strSupplierType = ddlSupplierType.SelectedItem.ToString();
                        strShortName = txtShortName.Text;
                        strBank = txtBank.Text;
                        strBranch = txtBranch.Text;
                        BankID = int.Parse(txtBankId.Text);
                        DistrictID = int.Parse(txtDistrictId.Text);
                        BranchID = int.Parse(txtBranchId.Text);
                        dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
                        dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());
                        Int32 MasterId = int.Parse(Session["msid"].ToString());
                        RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                        string msg = "";
                        msg = Enlist.InsertNewSupplierEdit(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, MasterId);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "ClosehdnDivision();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", ("Fail to insert"), true);

                }
            }
            catch { }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnView_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            string intSuppMasterId = gvr.Cells[0].Text;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('SupplierDocView.aspx?poId="+intSuppMasterId+"');", true);


            //pdfViwer.Src = "ftp://erp:erp123@ftp.akij.net/SupplierDoc/1_Cheque-Statement_1250__MICRChequecopy.pdf";

            //string FilePath = "f:/hello.pdf";

            //WebClient User = new WebClient();

            //Byte[] FileBuffer = User.DownloadData(FilePath);

            //if (FileBuffer != null)

            //{

            //    Response.ContentType = "application/pdf";

            //    Response.AddHeader("content-length", FileBuffer.Length.ToString());

            //    Response.BinaryWrite(FileBuffer);

            //}

        }
    }
}
