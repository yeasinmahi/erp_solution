using HR_BLL.Settlement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Settlement
{
    public partial class AccountsVoucherRealizeDetails : BasePage
    {
        public string voucherrealize1 = "";
        public string voucherrealize2 = "";

        HRClass objhr = new HRClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        string intenroll; int intPart; int intSVID; int intUnitID; int intEnroll;

        //GetDataForTestLegalRealize

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intenroll = Session["enrollcheck"].ToString();
                //dt = new DataTable();
                //dt = obj.GetDataForTestLegalRealize(intenroll);

                intEnroll = int.Parse(Session["enrollcheck"].ToString());
                dt = new DataTable();
                dt = obj.GetDetailsReportAll(intEnroll);

                if (dt.Rows.Count > 0)
                {
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {

                        //style='width:60%;'
                        voucherrealize1 = @" <table class = 'tbldecoration' align='left'>
                    <tr class='tblheader'><td colspan='4' style='text-align: center; padding:4px 0px 4px 2px;'> Statement of employee final settlement </td></tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Enroll No.: </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["intEnroll"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Job Station Name : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strJobStationName"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Code : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strEmployeeCode"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Separation Type : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strSeparateName"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Name : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Separation Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strSeparateDateTime"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Type of Employee : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strGroupName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Length of Service : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strTotalServiceLength"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Designation : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strDesignation"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Last working Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strLastOfficeDate"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Department : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strDepatrment"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Last Working Date By User : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strLastOfficeDateByUser"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Joining Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strJoiningDate"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Last office provide by Dept Head : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strLastOfficeDateByAuthority"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Reason of Separation : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strSeparateReson"].ToString() + @"</td>                      
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Dept. Accept By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strABEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Dept Head Accept Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strApproveDate"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strDHEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Dept Head : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRemarksByDeptHead"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Store Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strStoreEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Store Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRemarksByStore"].ToString() + @"</td>
                    </tr>

                   <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Accounts Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strACEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Accounts Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRemarksByAC"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>HR Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strHREmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Comments By HR Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRemarksByHR"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Legal Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strLegalEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Legal Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRemarksByLegal"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Audit Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strAuditEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Audit Dept. Release Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strRealizedByAuditDate"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Accounts Detp. Accept By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strVoucherEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Voucher No. & Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strVoucherNoDate"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>HR Clearange By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strHRFEmployeeName"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>HR Clearange Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strHRFinalRealizedDate"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Name of Bank & Branch : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strBankBranch"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:150px;'>Account No. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strBankAccountNo"].ToString() + @"</td>
                    </tr>

                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: #999999; padding:2px 0px 2px 2px;'> </td></tr>

                    </table>";

                        pnlvoucherrealizedetails1.DataBind();


                        voucherrealize2 = @" <table class = 'tbldecoration' align='left'>
                    <tr class='tblheader'>
                        <td colspan='2' style='text-align: center; padding:4px 0px 4px 2px;'> Payment </td>
                        <td colspan='2' style='text-align: center; padding:4px 0px 4px 2px;'> Deduction </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Salary : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monSalary"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Absent Amount : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monAbsentAmount"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Privilege Leave/Earn Leave : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monPLELAmount"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Late Amount : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monLateAmount"].ToString() + @"</td>
                    </tr> 

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Provident Fund : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monPFAmount"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>LWP Amount : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monLWPAmount"].ToString() + @"</td>
                    </tr>  

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Company Contribution : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monPFCompanyAmount"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Job Handover : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monDeductAmountByDeptHead"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Gratuity : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monGratuity"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Store Particle : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monDeductAmountByStore"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Legal Adjustment : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monAddAmountByLegal"].ToString() + @"</td>
                        
                        <td style='text-align: right; width:200px;'>Accounts Dues : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monDeductAmountByAC"].ToString() + @"</td>
                    </tr> 
                    
                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Others Amount : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monOtherAmount"].ToString() + @"</td>

                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>HR Deduction : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monDeductAmountByHR"].ToString() + @"</td>                        
                    </tr> 

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; font-weight: bold; background-color: #999999; width:200px;'>Total : </td>
                        <td style='text-align: left; font-weight: bold; background-color: #999999; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monTotalAmount"].ToString() + @"</td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Loan : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monLoanAmount"].ToString() + @"</td>                        
                    </tr> 

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Company Contribution : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monPFDCompanyAmount"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Gratuity : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monDGratuity"].ToString() + @"</td>
                    </tr>

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; font-weight: bold; background-color: #999999; width:200px;'>Total : </td>
                        <td style='text-align: left; font-weight: bold; background-color: #999999; width:250px; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monTotalDeduct"].ToString() + @"</td>                        
                    </tr> 

                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: White; padding:2px 0px 2px 2px;'> </td></tr>

                    <tr style='font-size: 11px; font-weight: bold; background-color: #999999;'>
                        <td style='text-align: right; width:150px;'>Net Payable (Tk.) : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["monNetPayable"].ToString() + @"</td>                      
                    </tr> 

                    <tr style='font-size: 11px; font-weight: bold; background-color: #999999;'>
                        <td style='text-align: right; width:150px;'>Net Payable (In Word) : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '>" + dt.Rows[row]["strNetPayable"].ToString() + @"</td>                      
                    </tr>  
                                           
                    </table>";

                        pnlvoucherrealizedetails2.DataBind();

                    }
                }
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountsVoucherRealize.aspx");
        }

    }
}