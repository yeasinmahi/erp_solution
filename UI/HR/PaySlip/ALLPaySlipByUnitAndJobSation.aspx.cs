using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HR_BLL.PaySlip;
using UI.ClassFiles;


namespace UI.HR.PaySlip
{
    public partial class ALLPaySlipByUnitAndJobSation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string employeeID = Request.QueryString["intEmployeeID"];
                string unitID = Request.QueryString["intUnitID"];
                string jobStationID = Request.QueryString["intEmployeeJobStationId"];
                string payrollGenerationDate = Request.QueryString["dtePayrollGenerationDate"];

                if (!String.IsNullOrEmpty(employeeID))
                {
                    GeneratePayslipByEmployeeID(employeeID, unitID, jobStationID, payrollGenerationDate);
                }
                else
                {
                    GeneratePayslipByUnitAndJostation(unitID, jobStationID, payrollGenerationDate);
                }
            }
        }

        private void GeneratePayslipByEmployeeID(string employeeID, string unitID, string jobStationID, string payrollGenerationDate)
        {
            //Summary    :   This function will use to generate employee wise payslip
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :   employeeID,unitID,jobSationID,dteSalaryGenerationDate

            HR_BLL.PaySlip.PayslipGenerator objPayslipGenerator = new HR_BLL.PaySlip.PayslipGenerator();
            DataTable oDTGeneratePaySlip = new DataTable();
            oDTGeneratePaySlip = objPayslipGenerator.DataForGeneratePayslipByEmployeeID(int.Parse(employeeID), int.Parse(unitID), int.Parse(jobStationID), DateTime.Parse(payrollGenerationDate));


            if (oDTGeneratePaySlip.Rows.Count > 0)
            {
                GeneratePaySlip(payrollGenerationDate, oDTGeneratePaySlip);

            }

        }

        private void GeneratePayslipByUnitAndJostation(string unitID, string jobStationID, string payrollGenerationDate)
        {
            //Summary    :   This function will use to generate payslip
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :   unitID,jobSationID,dteSalaryGenerationDate


            HR_BLL.PaySlip.PayslipGenerator objPayslipGenerator = new HR_BLL.PaySlip.PayslipGenerator();
            DataTable oDTGeneratePaySlip = new DataTable();
            oDTGeneratePaySlip = objPayslipGenerator.DataForGeneratePayslip(int.Parse(unitID), int.Parse(jobStationID), DateTime.Parse(payrollGenerationDate));


            if (oDTGeneratePaySlip.Rows.Count > 0)
            {
                GeneratePaySlip(payrollGenerationDate, oDTGeneratePaySlip);

            }
        }

        private void GeneratePaySlip(string payrollGenerationDate, DataTable oDTGeneratePaySlip)
        {
            #region Variable declaration
            string unitName = "";
            string jobStationName = "";
            string employeeName = "";
            string empCode = "";
            string totalSalary = "";
            string payableSalary = "";
            string designation = "";
            string empID = "";
            string barCodeImageUrl = "";
            string innerTableHtml = "";
            string tblRowInnerHtml = "";
            //string strEmptyRowInnerHtml = "<tr><td><br /><br /></td></tr>";
            string strDivInnerHtml = "";
            #endregion


            for (int index = 0; index < oDTGeneratePaySlip.Rows.Count; index++)
            {
                unitName = oDTGeneratePaySlip.Rows[index]["strDescription"].ToString();
                jobStationName = oDTGeneratePaySlip.Rows[index]["strJobStationName"].ToString();
                employeeName = oDTGeneratePaySlip.Rows[index]["strEmployeeName"].ToString();
                empCode = oDTGeneratePaySlip.Rows[index]["strEmployeeCode"].ToString();
                totalSalary = oDTGeneratePaySlip.Rows[index]["monSalary"].ToString();
                payableSalary = oDTGeneratePaySlip.Rows[index]["monTotalPayableSalary"].ToString();
                designation = oDTGeneratePaySlip.Rows[index]["strDesignation"].ToString();
                empID = oDTGeneratePaySlip.Rows[index]["intEmployeeID"].ToString();

                barCodeImageUrl = "../Employee/BarCodeImageHandler.ashx?ImgText=" + empID + "-" + DateTime.Parse(payrollGenerationDate).Month.ToString() + "-" + DateTime.Parse(payrollGenerationDate).Year.ToString();

                innerTableHtml = "";
                #region Generate innerTable html
                innerTableHtml = @"<div style='border:2px solid black; padding:0px 3px 3px 3px'><table border='0px'>
                                        <tr>
                                            <td colspan='8' style='text-align: center; font-size: medium;'>
                                                <strong>"; innerTableHtml = innerTableHtml + unitName + @"</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                              <td style='width: 70px'></td>
                                              <td style='width: 5px'></td>
                                              <td colspan='4' style='text-align:right'><strong>
                                              <img alt='' src='"; innerTableHtml = innerTableHtml + barCodeImageUrl + @"' style='text-align: right;width: 200px; height: 38px;' />
                                              </strong></td>
                                              <td></td>
                                              <td></td>
                                        </tr>
                                        <tr>
                                            <td style='width: 70px'><strong>Name</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td style='width: 300px'><strong>"; innerTableHtml = innerTableHtml + employeeName + @"</strong></td>
                                            <td style='width: 5px'></td>
                                            <td style='width: 15px'><strong>ID</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td style='width: 100px'><strong>"; innerTableHtml = innerTableHtml + empCode + @"</strong></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style='width: 70px'><strong>Designation</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td style='width: 300px'><strong>"; innerTableHtml = innerTableHtml + designation + @"</strong></td>
                                            <td style='width: 5px'></td>
                                            <td style='width: 15px'></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style='width: 70px'><strong>Job Sation</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td style='width: 300px'><strong>"; innerTableHtml = innerTableHtml + jobStationName + @"</strong></td>
                                            <td style='width: 5px'></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style='width: 85px'><strong>Total Salary</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td style='width: 200px'><strong>"; innerTableHtml = innerTableHtml + totalSalary + @"</strong></td>
                                            <td style='width: 5px'></td>
                                            <td style='width: 100px'><strong>Payable Salary</strong></td>
                                            <td style='width: 5px'>:</td>
                                            <td><strong>"; innerTableHtml = innerTableHtml + payableSalary + @"</strong></td>
                                        </tr>
                                    </table></div>";
                #endregion

                if (!String.IsNullOrEmpty(innerTableHtml))
                {
                    tblRowInnerHtml = tblRowInnerHtml + "<tr><td>" + innerTableHtml + "</td></tr>";
                }

            }

            if (!String.IsNullOrEmpty(tblRowInnerHtml))
            {
                strDivInnerHtml = "<table>" + tblRowInnerHtml + "</table>";
                divAllPayslipPrint.InnerHtml = strDivInnerHtml;
            }
        }


    }
}