using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.HR.Loan
{
    public partial class LoanCompleteScheduleWise : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        DataTable dt;
        string filePathForXML, xmlString = "", xml, scheduleid;
        int intPart, intEnroll, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment;        
        DateTime dteEffectiveDate; string strStatus, strRemarks;
        #endregion =====================================================================================
        
        #region===== Page Load Event ===================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/HR/Loan/Data/LoanSchedule_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                intEnroll = int.Parse(Request.QueryString["Id"]);
                hdnApplicationID.Value = intEnroll.ToString();
                LoadGrid();
            }
        }
        #endregion======================================================================================
        
        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            try
            {
                dgvLoan.DataSource = "";
                dgvLoan.DataBind();
                intPart = 4;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intEnroll);
                dgvLoan.DataSource = dt;
                dgvLoan.DataBind();
            }
            catch (Exception ex) { throw ex; }
        }
        protected int totalloanamountn = 0;
        protected void dgvLoan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalloanamountn += int.Parse(((Label)e.Row.Cells[3].FindControl("lblLoanAmountT")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion======================================================================================

        #region===== Loan Complete Event ===============================================================
        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if(txtRemarks.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Remarks Input.');", true); return; }
                strRemarks = txtRemarks.Text;

                if (dgvLoan.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvLoan.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvLoan.Rows[index].FindControl("chkRow")).Checked == true)
                        {
                            scheduleid = ((Label)dgvLoan.Rows[index].FindControl("lblScheduleID")).Text.ToString();
                            CreateVoucherXml(scheduleid);
                        }
                    }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("Loan");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<Loan>" + xmlString + "</Loan>";
                        xml = xmlString;
                    }
                    catch { return; }
                    if (xml == "") { return; }

                    intPart = 6;
                    intApplicationId = int.Parse(hdnApplicationID.Value);
                    intLType = 0;
                    intUserID = 0;
                    intLoanAmount = 0;
                    intNumberOfInstallment = 0;                    
                    intApproveLoanAmount = 0;
                    intApproveNumberOfInstallment = 0;
                    dteEffectiveDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    
                    //Final Insert
                    string message = objLoan.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                    hdnconfirm.Value = "0";
                    hdnApplicationID.Value = "0";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                hdnconfirm.Value = "0";
                hdnApplicationID.Value = "0";
            }
        }
        private void CreateVoucherXml(string scheduleid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Loan");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, scheduleid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Loan");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, scheduleid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }      
        private XmlNode CreateItemNodeDTFareCash(XmlDocument doc, string scheduleid)
        {
            XmlNode node = doc.CreateElement("Loan");

            XmlAttribute Scheduleid = doc.CreateAttribute("scheduleid");
            Scheduleid.Value = scheduleid;

            node.Attributes.Append(Scheduleid);
            return node;
        }
        #endregion======================================================================================
















    }
}