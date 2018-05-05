using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.SCM
{
    public partial class BillRegistration : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        string filePathForXML, xmlString, xml, challan, mrrid, amount;
        int intUnitid, intPOID, intSuppid, intCOAID, intEnroll;
        string strPType, strReffNo;

        #endregion ====================================================================================

        #region===== Page Load Event ==================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                ///filePathForXML = Server.MapPath("~/SCM/Data/MilkMRR_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    //File.Delete(filePathForXML);
                    GetDDLList();
                    TrueFasle();

                    txtEmplyeeName.Visible = false;
                    txtOtherPartyName.Visible = false;
                    txtCommonText.Visible = false;
                }
            }
            catch { }
        }
        private void GetDDLList()
        {
            try
            {
                dt = objBillReg.GetAllUnit();
                ddlBillingUnit.DataTextField = "strUnit";
                ddlBillingUnit.DataValueField = "intUnitID";
                ddlBillingUnit.DataSource = dt;
                ddlBillingUnit.DataBind();

                dt = objBillReg.GetAllUnit();
                ddlEmployeeUnit.DataTextField = "strUnit";
                ddlEmployeeUnit.DataValueField = "intUnitID";
                ddlEmployeeUnit.DataSource = dt;
                ddlEmployeeUnit.DataBind();
            }
            catch { }
        }

        #endregion=====================================================================================

        #region===== Web Method For Employee Search ===================================================
        

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchCOAList(string prefixText)
        {
            string strUnitID = HttpContext.Current.Session["Unitid"].ToString();
            Billing_BLL objAutoSearch_BLL = new Billing_BLL();
            return objAutoSearch_BLL.AutoSearchCOALedger(strUnitID, prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchSupplierList(string prefixText)
        {
            string strUnitID = HttpContext.Current.Session["Unitid"].ToString();
            Billing_BLL objAutoSearch_BLL = new Billing_BLL();
            return objAutoSearch_BLL.AutoSearchSupplier(strUnitID, prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchEmpList(string prefixText)
        {
            string strUnitID = HttpContext.Current.Session["Unitid"].ToString();
            Billing_BLL objAutoSearch_BLL = new Billing_BLL();
            return objAutoSearch_BLL.AutoSearchEmployee(strUnitID, prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchOtherPartyList(string prefixText)
        {
            Billing_BLL objAutoSearch_BLL = new Billing_BLL();
            return objAutoSearch_BLL.AutoSearchOtherParty(prefixText);
        }
        #endregion=====================================================================================

        #region ===== Selection Change Event ===========================================================  
        protected void ddlRefference_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrueFasle();
            HttpContext.Current.Session["Unitid"] = ddlBillingUnit.SelectedValue.ToString();
        }
        protected void ddlBillingUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitid = int.Parse(ddlBillingUnit.SelectedValue.ToString());
                HttpContext.Current.Session["Unitid"] = ddlBillingUnit.SelectedValue.ToString();
                txtCOALedger.Text = "";
            }
            catch { }
        }

        protected void ddlPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Md. Al-Amin

            try
            {
                intUnitid = int.Parse(ddlBillingUnit.SelectedValue.ToString());
                strPType = ddlPartyType.SelectedItem.ToString();

                lblEmployeeUnit.Enabled = false;
                ddlEmployeeUnit.Enabled = false;
                lblSearch.Enabled = false;
                txtSearch.Enabled = false;
                btnSearch.Enabled = false;
                txtPartyName.Text = "";
                txtEmplyeeName.Text = "";
                txtOtherPartyName.Text = "";
                txtCommonText.Text = "";

                if (strPType == "Supplier")
                {
                    txtPartyName.Visible = true;
                    txtEmplyeeName.Visible = false;
                    txtOtherPartyName.Visible = false;
                    txtCommonText.Visible = false;
                }
                else if (strPType == "Employee")
                {
                    txtPartyName.Visible = false;
                    txtEmplyeeName.Visible = true;
                    txtOtherPartyName.Visible = false;
                    txtCommonText.Visible = false;

                    lblEmployeeUnit.Enabled = true;
                    ddlEmployeeUnit.Enabled = true;
                    lblSearch.Enabled = true;
                    txtSearch.Enabled = true;
                    btnSearch.Enabled = true;
                    txtLBalance.Text = "";
                }
                else if (strPType == "Others")
                {
                    txtPartyName.Visible = false;
                    txtEmplyeeName.Visible = false;
                    txtOtherPartyName.Visible = true;
                    txtCommonText.Visible = false;
                }
                else
                {
                    txtPartyName.Visible = false;
                    txtEmplyeeName.Visible = false;
                    txtOtherPartyName.Visible = false;
                    txtCommonText.Visible = true;
                }

            }
            catch { }
        }

        protected void ckbAdvance_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAdvance.Checked == true) { txtBillNo.Text = "Advance"; txtAdjAmount.Text = "0"; txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); }
            else
            {
                txtBillNo.Text = "";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                intEnroll = int.Parse(txtSearch.Text);

                dt = objBillReg.GetEmpName(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    txtEmplyeeName.Text = dt.Rows[0]["EmpName"].ToString();
                    ddlEmployeeUnit.SelectedValue = dt.Rows[0]["intUnitID"].ToString();
                }
                else
                {
                    txtPartyName.Text = "";
                }
            }
            catch { }
        }

        protected void ddlEmployeeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPartyType.SelectedItem.ToString() == "Employee")
                {
                    //dtAllEmpList = obj.GetAllEmpListUnitWise(intUnitid);
                    //cmbPartyName.DataSource = dtAllEmpList;
                    //cmbPartyName.DisplayMember = "strEmployeeName";
                    //cmbPartyName.ValueMember = "intEmployeeID";
                }
                else if (ddlPartyType.SelectedItem.ToString() == "Supplier")
                {
                    //cmbPartyName.DataSource = null;
                    //dt = obj.GetSupplierList(intUnitid);
                    //cmbPartyName.DataSource = dt;
                    //cmbPartyName.DisplayMember = "strSupplierName";
                    //cmbPartyName.ValueMember = "intSupplierID";
                    //cmbEmployeeUnit.DataSource = null;
                }
                else if (ddlPartyType.SelectedItem.ToString() == "Other")
                {
                    //cmbPartyName.DataSource = null;
                    //dt = obj.GetOtherParty();
                    //cmbPartyName.DataSource = dt;
                    //cmbPartyName.DisplayMember = "strOtherParty";
                    //cmbPartyName.ValueMember = "intID";
                    //cmbEmployeeUnit.DataSource = null;
                }
                txtSearch.Text = "";
            }
            catch { }
        }
        private void TrueFasle()
        {
            string strRefName = ddlRefference.SelectedItem.ToString();

            if (strRefName == "PO")
            {
                ddlBillingUnit.Enabled = false;
                ddlPartyType.Enabled = false;
                txtPartyName.Enabled = false;
                btnGo.Enabled = true;
                ckbAdvance.Enabled = true;
                txtPOAmount.Enabled = false;
                txtLBalance.Enabled = false;
                txtAdvance.Enabled = false;
                lblPOAmount.Enabled = false;
                lblLBalance.Enabled = false;
                lblAdvance.Enabled = false;
                txtCOALedger.Enabled = false;
                lblCOALedger.Enabled = false;
            }
            else
            {
                ddlBillingUnit.Enabled = true;
                ddlPartyType.Enabled = true;
                txtPartyName.Enabled = true;
                btnGo.Enabled = false;
                ckbAdvance.Enabled = false;
                txtPOAmount.Enabled = false;
                txtLBalance.Enabled = false;
                txtAdvance.Enabled = false;
                lblPOAmount.Enabled = false;
                lblLBalance.Enabled = false;
                lblAdvance.Enabled = false;
                txtCOALedger.Enabled = true;
                lblCOALedger.Enabled = true;
            }

            ckbAdvance.Checked = false;
            ddlEmployeeUnit.Enabled = false;
            txtRemarks.Text = "";
            txtPOAmount.Text = "";
            txtAdjAmount.Text = "";
            txtAdvance.Text = "";
            txtAmount.Text = "";
            txtBillNo.Text = "";
            txtLBalance.Text = "";
            txtReffNo.Text = "";
        }

        #endregion =====================================================================================

        #region ===== btnGo Button Action ==============================================================  
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(txtReffNo.Text);
                strReffNo = intPOID.ToString();

                dt = new DataTable();
                dt = objBillReg.GetPOInfo(intPOID);
                if (dt.Rows.Count > 0)
                {
                    ddlBillingUnit.SelectedValue = dt.Rows[0]["intUnitID"].ToString();
                    txtPOAmount.Text = Math.Round(decimal.Parse(dt.Rows[0]["monPOAmount"].ToString()), 0).ToString();
                    ddlPartyType.SelectedValue = "1";
                    txtPartyName.Text = dt.Rows[0]["strSupplierName"].ToString();
                }
                dt = new DataTable();
                dt = objBillReg.GetAdvAmount(intPOID.ToString());
                if (dt.Rows.Count > 0)
                {
                    txtAdvance.Text = Math.Round(decimal.Parse(dt.Rows[0]["monAdvPaid"].ToString()), 0).ToString();
                }
                else { txtAdvance.Text = "0"; }

                dt = new DataTable(); //Get Previous Advance Amount & Previous Manual Adjustment Amount
                dt = objBillReg.GetNetAmountByPO(strReffNo);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        decimal PreAdvAdj = decimal.Parse(txtAdvance.Text) - decimal.Parse(dt.Rows[0]["monAdvanceAdjAmount"].ToString());
                        txtPreAdvance.Text = PreAdvAdj.ToString();
                    }
                    catch { txtPreAdvance.Text = "0"; }
                }
                else { txtPreAdvance.Text = "0"; }

                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtPartyName.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intSuppid = int.Parse(temp1[1].ToString());
                }
                catch { intSuppid = 0; }

                dt = new DataTable();
                dt = objBillReg.GetCOAID(intSuppid);
                intCOAID = 0;
                if (dt.Rows.Count > 0)
                {
                    intCOAID = int.Parse(dt.Rows[0]["intCOAID"].ToString());
                }

                if (intCOAID != 0)
                {
                    dt = new DataTable();
                    dt = objBillReg.GetLadgerBalance(intCOAID);
                    if (dt.Rows.Count > 0)
                    {
                        txtLBalance.Text = dt.Rows[0]["monLedgerBalance"].ToString();
                    }
                }
                else { txtLBalance.Text = "0"; }

                dt = objBillReg.GetChallanByPOID(intPOID);
                dgvChallan.DataSource = dt;
                dgvChallan.DataBind();

                //////decimal sumTotalAmount = 0;

                //////for (int i = 0; i < dgvChallanInfoByPO.Rows.Count; ++i)
                //////{
                //////    sumTotalAmount += Convert.ToDecimal(dgvChallanInfoByPO.Rows[i].Cells[2].Value);
                //////}

                //////txtAmount.Text = decimal.Round(sumTotalAmount, 2).ToString();
                //////if (sumTotalAmount == 0)
                //////{
                //////    txtAmount.Text = "";
                //////}

                if (ddlRefference.SelectedItem.ToString() == "PO")
                {
                    txtCOALedger.Enabled = false;
                }
                else
                {
                    txtCOALedger.Enabled = true;
                }
            }
            catch { }

        }

        #endregion =====================================================================================

        protected void dgvLoan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "R")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvChallan.Rows[rowIndex];

                try
                {
                    if (hdnconfirm.Value == "1")
                    {
                        try
                        {
                            //intPart = 3;
                            //intLType = 0;
                            //intApplicationId = int.Parse((row.FindControl("lblApplicationID") as Label).Text);
                            //intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                            //intLoanAmount = 0;
                            //intNumberOfInstallment = 0;
                            //intApproveLoanAmount = int.Parse((row.FindControl("txtAppAmount") as TextBox).Text);
                            //intApproveNumberOfInstallment = int.Parse((row.FindControl("txtAppInstall") as TextBox).Text);
                            //intApproveLoanAmount = int.Parse((row.FindControl("lblLoanAmountT") as Label).Text);
                            //intApproveNumberOfInstallment = int.Parse((row.FindControl("lblInstallment") as Label).Text);
                            //dteEffectiveDate = DateTime.Parse((row.FindControl("txtEffDate") as TextBox).Text);
                            //xml = "";
                            //strRemarks = "";

                            //** Final Insert
                            //string message = objLoan.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks);
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            //hdnconfirm.Value = "0";
                            //LoadGrid();
                        }
                        catch { }
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }



        #region ===== Item Add & Load Grid Action ===========================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //itemid = ddlItem.SelectedValue.ToString();
            //itemname = ddlItem.SelectedItem.ToString();
            //uom = txtUOM.Text;
            //qty = txtQty.Text;
            //rate = txtRate.Text;
            //value = txtValue.Text;
            //remarks = txtRemarks.Text;

            CreateAddXml(challan, mrrid, amount);

            //txtUOM.Text = "";
            //txtQty.Text = "";
            //txtRate.Text = "";
            //txtValue.Text = "";
            //txtRemarks.Text = "";
        }
        private void CreateAddXml(string challan, string mrrid, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, challan, mrrid, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, challan, mrrid, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("SOItem");
                xmlString = xlnd.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvChallan.DataSource = ds; } else { dgvChallan.DataSource = ""; }
                dgvChallan.DataBind();
            }
            catch { dgvChallan.DataSource = ""; dgvChallan.DataBind(); }
        }
        private XmlNode CreateItemNode(XmlDocument doc, string challan, string mrrid, string amount)
        {
            XmlNode node = doc.CreateElement("SOItem");

            XmlAttribute Challan = doc.CreateAttribute("challan"); Challan.Value = challan;
            XmlAttribute Mrrid = doc.CreateAttribute("mrrid"); Mrrid.Value = mrrid;
            XmlAttribute Amount = doc.CreateAttribute("amount"); Amount.Value = amount;

            node.Attributes.Append(Challan);
            node.Attributes.Append(Mrrid);
            node.Attributes.Append(Amount);
            return node;
        }
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvChallan.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvChallan.DataSource;
                dsGrid.Tables[0].Rows[dgvChallan.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvChallan.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvChallan.DataSource = ""; dgvChallan.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal totalqty = 0;
        protected decimal totalvalue = 0;
        protected void dgvSOItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                }
            }
            catch { }
        }

        #endregion ==========================================================================================





















    }
}