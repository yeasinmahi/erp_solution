using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Web.Services;
using HR_BLL.Global;
using System.Data;
using System.Xml;
using HR_BLL.Loan;
using UI.ClassFiles;

namespace UI.HR.Loan
{
    public partial class LoanScheduleModify : BasePage
    {

        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        HR_BLL.Loan.Loan objLoan;
        static int intLoginUerId;
        static int intjobStationID;
        int? userID = null;
        string filePathForXML = "";
        static int intLoanScheduleId = 0;
        static string strEmployeeCode = "";
        static bool ysnLoaded = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            //Summary    :   This function will use to Load initial Feild variable 
            //Created    :   Md. Yeasir Arafat / October-05-2012
            //Modified   :   
            //Parameters : 

            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            if (!IsPostBack)
            {

                filePathForXML = Server.MapPath("LoanScheduleDetails_XmlData.xml");
                File.Delete(filePathForXML);

                pnlUpperControl.DataBind();
                txtSearchEmployee.Attributes.Add("onkeyUp", "SearchText();");

                string srt = "";
                srt = "GotoNextFocus('" + btnSearch.ClientID + "',event);";
                txtSearchEmployee.Attributes.Add("onkeyPress", srt);


                DataTable odt = new DataTable();
                dgvUpdateLoanSchedule.DataSource = odt;
                dgvUpdateLoanSchedule.DataBind();

                // BindGridViewWithXml();
            }
            else
            {
                if (!String.IsNullOrEmpty(txtSearchEmployee.Text))
                {
                    string strSearchKey = txtSearchEmployee.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    LoadDefultFieldValue(searchKey[1]);
                    if (strEmployeeCode != hdfEmpCode.Value) // if (!ysnLoaded)
                    {
                        filePathForXML = Server.MapPath("LoanScheduleDetails_XmlData.xml");
                        File.Delete(filePathForXML);
                        strEmployeeCode = hdfEmpCode.Value;
                        LoadLoanScheduleDetailsXMLForDatagrid(searchKey[1]);
                    }
                }
                else
                {
                    RefreshPage();
                }
            }

        }

        private void LoadLoanScheduleDetailsXMLForDatagrid(string strEmployeeCode)
        {
            try
            {
                objLoan = new HR_BLL.Loan.Loan();
                int? loanApplicationId = 0;
                decimal? monTotalLoanScheduleAmount = 0;
                DataTable odtLoanScheduleDetails = objLoan.GetLoanScheduleDetailsByEmployeeCode(strEmployeeCode, ref loanApplicationId, ref monTotalLoanScheduleAmount);

                hdfLoanApplicationId.Value = loanApplicationId.ToString();
                hdfTotalLoanScheduleAmount.Value = monTotalLoanScheduleAmount.ToString();
                lblTotalRemaining.Text = "Total remaining Tk." + String.Format("{0:0.00}", monTotalLoanScheduleAmount); // monTotalLoanScheduleAmount.ToString("#.##");
                lblTotalRemaining.ForeColor = System.Drawing.Color.Red;

                if (odtLoanScheduleDetails.Rows.Count > 0)
                {
                    for (int index = 0; index < odtLoanScheduleDetails.Rows.Count; index++)
                    {
                        CreateXmlData(odtLoanScheduleDetails.Rows[index]["intScheduleId"].ToString(), odtLoanScheduleDetails.Rows[index]["intInstallmentAmount"].ToString(), odtLoanScheduleDetails.Rows[index]["intMonth"].ToString(), odtLoanScheduleDetails.Rows[index]["strMonth"].ToString(), odtLoanScheduleDetails.Rows[index]["intYear"].ToString());
                    }
                    BindGridViewWithXml();
                    // ysnLoaded = true;
                }
            }
            catch { }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            //Summary    :   This procedure will be used to search employee's details by employee code or employee name 
            //Created    :   Md. Yeasir Arafat / October-05-2012
            //Modified   :   
            //Parameters :   searching key. It's may employee's name or code


            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(intLoginUerId, intjobStationID, strSearchKey);
            return result;
        }
        private void LoadDefultFieldValue(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / October-05-2012
            //Modified   :   
            //Parameters :   empCode
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {

                    DataTable oDT_EmpInfo = new DataTable();
                    oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(userID, empCode);
                    if (oDT_EmpInfo.Rows.Count > 0)
                    {
                        txtName.Text = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                        txtUnit.Text = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                        txtDepartment.Text = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
                        txtJobStatus.Text = oDT_EmpInfo.Rows[0]["strJobType"].ToString();
                        txtJoiningDate.Text = oDT_EmpInfo.Rows[0]["dteJoiningDate"].ToString();
                    }
                }
            }
            catch
            {
            }
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / October-05-2012
            //Modified   :   
            //Parameters :   empCode

            try
            {
                LoadDefultFieldValue(hdfEmpCode.Value);
            }
            catch { }
        }
        private void RefreshPage()
        {
            //Summary    :   This procedure will be used to refresh page due to change searching key
            //Created    :   Md. Yeasir Arafat / August-05-2012
            //Modified   :   
            //Parameters :   
            try
            {
                txtDepartment.Text = "";
                txtDesignation.Text = "";
                txtJobStatus.Text = "";
                txtJoiningDate.Text = "";
                txtName.Text = "";
                txtUnit.Text = "";
                ysnLoaded = false;
                hdfLoanApplicationId.Value = "";
                hdfTotalLoanScheduleAmount.Value = "";
                filePathForXML = Server.MapPath("LoanScheduleDetails_XmlData.xml");
                File.Delete(filePathForXML);

                DataTable odt = new DataTable();
                dgvUpdateLoanSchedule.DataSource = odt;
                dgvUpdateLoanSchedule.DataBind();
            }
            catch { }
        }
        protected void BindGridViewWithXml()
        {
            DataSet odsXML = new DataSet();
            odsXML.ReadXml(Server.MapPath("LoanScheduleDetails_XmlData.xml"));
            dgvUpdateLoanSchedule.DataSource = odsXML;
            dgvUpdateLoanSchedule.DataBind();
            dgvUpdateLoanSchedule.ShowFooter = true;

            CalculateTotalAmountInGrid();

        }

        private void CalculateTotalAmountInGrid()
        {
            try
            {
                int totalLoanScheduleAmount_in_Grid = 0;
                for (int index = 0; index < dgvUpdateLoanSchedule.Rows.Count; index++)
                {
                    Label lblInstallmentAmount = (Label)dgvUpdateLoanSchedule.Rows[index].FindControl("lblInstallmentAmount");
                    totalLoanScheduleAmount_in_Grid += int.Parse(lblInstallmentAmount.Text);
                }
                lblTotal.Text = "Total : " + totalLoanScheduleAmount_in_Grid.ToString("#.##");
                lblTotal.ForeColor = System.Drawing.Color.Red;
            }
            catch { }
        }


        protected void dgvUpdateLoanSchedule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvUpdateLoanSchedule.EditIndex = e.NewEditIndex;
            BindGridViewWithXml();
        }
        protected void dgvUpdateLoanSchedule_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvUpdateLoanSchedule.EditIndex = -1;
            BindGridViewWithXml();
        }
        protected void dgvUpdateLoanSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //getting username from particular row
                // string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserName"));
                //identifying the control in gridview
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("imgbtnDelete");
                //raising javascript confirmationbox whenver user clicks on link button
                string strMessage = "Are you sure want to delete?";
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return confirm('really want to delete?');");
                }

            }
        }
        protected void dgvUpdateLoanSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                bool ysnScheduleExist = false;

                int loanApplicationId = Convert.ToInt32(dgvUpdateLoanSchedule.DataKeys[0].Values["intLoanApplicationId"].ToString());
                HiddenField hdnLoanScheduleId = (HiddenField)dgvUpdateLoanSchedule.FooterRow.FindControl("hdnLoanScheduleId");
                TextBox txtInstalmentAmount = (TextBox)dgvUpdateLoanSchedule.FooterRow.FindControl("txtftrInstallmentAmount");
                DropDownList ddlMonth = (DropDownList)dgvUpdateLoanSchedule.FooterRow.FindControl("ddlftrMonth");
                TextBox txtYear = (TextBox)dgvUpdateLoanSchedule.FooterRow.FindControl("txtftrYear");

                for (int index = 0; index < dgvUpdateLoanSchedule.Rows.Count; index++)
                {
                    Label lblMonth = (Label)dgvUpdateLoanSchedule.Rows[index].FindControl("lblMonth");
                    Label lblYear = (Label)dgvUpdateLoanSchedule.Rows[index].FindControl("lblYear");

                    if ((lblMonth.Text == ddlMonth.SelectedItem.Text) && (lblYear.Text == txtYear.Text))
                    {
                        ysnScheduleExist = true;
                    }
                }

                int currentMonthId = DateTime.Now.Month;
                int currentYearId = DateTime.Now.Year;

                if (ysnScheduleExist)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('Sorry!Loan schedule has already been exist.Please check your existing loan schedule.');", true);
                    return;
                }
                if ((int.Parse(ddlMonth.SelectedValue) < currentMonthId) && (int.Parse(txtYear.Text) == currentYearId))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('Sorry!Back dated loan schedule cannot be accepted.Please check your selected month.');", true);
                    return;
                }

                CreateXmlData(null, txtInstalmentAmount.Text, ddlMonth.SelectedValue, ddlMonth.SelectedItem.Text, txtYear.Text);
                BindGridViewWithXml();
            }
        }


        //protected void dgvUpdateLoanSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int loanApplicationId = Convert.ToInt32(dgvUpdateLoanSchedule.DataKeys[e.RowIndex].Values["intLoanApplicationId"].ToString());
        //    int scheduleId = Convert.ToInt32(dgvUpdateLoanSchedule.DataKeys[e.RowIndex].Values["intScheduleId"].ToString());

        //    BindGridViewWithXml();

        //    DataSet odsDataSource = (DataSet)dgvUpdateLoanSchedule.DataSource;
        //    odsDataSource.Tables[0].Rows[dgvUpdateLoanSchedule.Rows[e.RowIndex].DataItemIndex].Delete();
        //    odsDataSource.WriteXml(Server.MapPath("LoanScheduleDetails_XmlData.xml"));

        //    BindGridViewWithXml();
        //}

        protected void dgvUpdateLoanSchedule_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int loanApplicationId = Convert.ToInt32(dgvUpdateLoanSchedule.DataKeys[e.RowIndex].Values["intLoanApplicationId"].ToString());
            int scheduleId = Convert.ToInt32(dgvUpdateLoanSchedule.DataKeys[e.RowIndex].Values["intScheduleId"].ToString());

            TextBox txtInstallmentAmount = (TextBox)dgvUpdateLoanSchedule.Rows[e.RowIndex].FindControl("txtInstallmentAmount");
            // DropDownList ddlMonth = (DropDownList)dgvUpdateLoanSchedule.Rows[e.RowIndex].FindControl("ddlMonth");
            //TextBox txtYear = (TextBox)dgvUpdateLoanSchedule.Rows[e.RowIndex].FindControl("txtYear");


            int index = dgvUpdateLoanSchedule.Rows[e.RowIndex].DataItemIndex;


            BindGridViewWithXml();
            DataSet odsDataSource = (DataSet)dgvUpdateLoanSchedule.DataSource;
            odsDataSource.Tables[0].Rows[index]["intInstallmentAmount"] = txtInstallmentAmount.Text;
            //odsDataSource.Tables[0].Rows[index]["intMonth"] = ddlMonth.SelectedValue;
            //odsDataSource.Tables[0].Rows[index]["strMonth"] = ddlMonth.SelectedItem.Text;
            //odsDataSource.Tables[0].Rows[index]["intYear"] = txtYear.Text;

            odsDataSource.WriteXml(Server.MapPath("LoanScheduleDetails_XmlData.xml"));

            dgvUpdateLoanSchedule.EditIndex = -1;
            BindGridViewWithXml();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int totalLoanScheduleAmount_in_Grid = 0;
                decimal totalLoanScheduleAmount_in_Database = decimal.Parse(hdfTotalLoanScheduleAmount.Value == null ? "0" : hdfTotalLoanScheduleAmount.Value);
                for (int index = 0; index < dgvUpdateLoanSchedule.Rows.Count; index++)
                {
                    Label lblInstallmentAmount = (Label)dgvUpdateLoanSchedule.Rows[index].FindControl("lblInstallmentAmount");
                    totalLoanScheduleAmount_in_Grid += int.Parse(lblInstallmentAmount.Text);
                }

                if (totalLoanScheduleAmount_in_Grid != totalLoanScheduleAmount_in_Database)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('Sorry!Total remaining loan schedule amount should be Tk.' + " + totalLoanScheduleAmount_in_Database.ToString() + ");", true);
                    return;
                }

                XmlDocument doc = new XmlDocument();
                filePathForXML = Server.MapPath("LoanScheduleDetails_XmlData.xml");
                doc.Load(filePathForXML);

                //XmlNode strLoanScheduleDetails = doc.SelectSingleNode("LoanScheduleDetails");
                string xmlLoanScheduleDetails = doc.InnerXml;
                // xmlLoanScheduleDetails = "<LoanSchedule>" + xmlLoanScheduleDetails + "</LoanSchedule>";

                objLoan = new HR_BLL.Loan.Loan();
                string strUpdateStatus = "";
                strUpdateStatus = objLoan.UpdateLoanScheduleDetails(int.Parse(hdfLoanApplicationId.Value), xmlLoanScheduleDetails, intLoginUerId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strUpdateStatus + "');", true);

            }
            catch
            {

            }
        }

        #region Internal Method

        private void CreateXmlData(string strLoanScheduleId, string strLoanAmount, string strMonthId, string strMonthName, string strYear)
        {
            //Summary    :   This procedure will be used to create xml file 
            //Created    :   Md. Yeasir Arafat / October-13-2012
            //Modified   :   
            //Parameters :   load amount,monthtd,monthName,year
            filePathForXML = Server.MapPath("LoanScheduleDetails_XmlData.xml");
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("LoanScheduleDetails");
                XmlNode addItem = CreateItemNode(doc, null, strLoanAmount, strMonthId, strMonthName, strYear);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("LoanScheduleDetails");
                XmlNode addItem = CreateItemNode(doc, strLoanScheduleId, strLoanAmount, strMonthId, strMonthName, strYear);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string strLoanScheduleId, string strLoanAmount, string strMonthId, string strMonthName, string strYear)
        {
            //Summary    :   This procedure will be used to create xml node 
            //Created    :   Md. Yeasir Arafat / October-13-2012
            //Modified   :   
            //Parameters :   documents,load amount,monthtd,monthName,year



            int loanScheduleId;
            if (String.IsNullOrEmpty(strLoanScheduleId))
            {
                intLoanScheduleId++; //increase loan schedule id 
                loanScheduleId = -intLoanScheduleId;
            }
            else
            {
                loanScheduleId = int.Parse(strLoanScheduleId);
            }

            XmlNode node = doc.CreateElement("LoanSchedule");

            XmlAttribute atrLoanApplicationId = doc.CreateAttribute("intLoanApplicationId");
            atrLoanApplicationId.Value = hdfLoanApplicationId.Value; // loan application id

            XmlAttribute atrScheduleId = doc.CreateAttribute("intScheduleId");
            atrScheduleId.Value = (loanScheduleId).ToString();

            XmlAttribute atrInstallmentAmount = doc.CreateAttribute("intInstallmentAmount");
            atrInstallmentAmount.Value = strLoanAmount;

            XmlAttribute atrMonthId = doc.CreateAttribute("intMonth");
            atrMonthId.Value = strMonthId;

            XmlAttribute atrMonthName = doc.CreateAttribute("strMonth");
            atrMonthName.Value = strMonthName;

            XmlAttribute atrYear = doc.CreateAttribute("intYear");
            atrYear.Value = strYear;

            node.Attributes.Append(atrLoanApplicationId);
            node.Attributes.Append(atrScheduleId);
            node.Attributes.Append(atrInstallmentAmount);
            node.Attributes.Append(atrMonthId);
            node.Attributes.Append(atrMonthName);
            node.Attributes.Append(atrYear);
            return node;
        }
        #endregion
    }
}