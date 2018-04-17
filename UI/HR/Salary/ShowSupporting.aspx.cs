using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Salary
{
    public partial class ShowSupporting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string innerTableHtml = "";
            HR_BLL.Salary.SalaryInfo salinfo = new HR_BLL.Salary.SalaryInfo();
            DataTable dtabl = new DataTable();
            string unit = Request.QueryString["UNITID"];
            string station = Request.QueryString["STATIONID"];
            string date = Request.QueryString["DATE"];
            string viewtype = Request.QueryString["VTP"];
            dtabl = salinfo.GetSalaryAdviceandSupporting(int.Parse(unit), int.Parse(station), DateTime.Parse(date), viewtype);
            if (dtabl.Rows.Count > 0)
            {
                #region ----------- Set Data ------------
                decimal Total = decimal.Parse(dtabl.Compute("SUM(monTotalPayableSalary)", string.Empty).ToString());
                string total = "Total Amount : " + GetSubstringValue(Total.ToString());
                string month = DateTime.Parse(dtabl.Rows[0]["dtePayrollGenerationDate"].ToString()).ToString("MMMM");
                string year = DateTime.Parse(dtabl.Rows[0]["dtePayrollGenerationDate"].ToString()).Year.ToString();
                string cdaccount = dtabl.Rows[0]["strCDAccount"].ToString().ToUpper();
                string unitName = dtabl.Rows[0]["strDescription"].ToString().ToUpper();
                string unitAddress = dtabl.Rows[0]["strStationAddress"].ToString().ToUpper();
                string imageUrl = "../../Content/Images/img/" + unit + ".png";

                innerTableHtml = @" <table border='0' style = 'width:760px;'>
                    <tr><td style='text-align: left; width:25%'>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @"></td>

                    <td colspan='6' style='text-align: center; font-size: 14px; font-weight: bold;' valign='top'>"; innerTableHtml = innerTableHtml + unitName +
                     @"<br/ style='font-size: 12px; font-weight: bold;'>" + unitAddress + @"<br/><br/></td></tr>

                    <tr><td colspan='7' style='text-align: left; font-size: 11px; font-weight: bold;'><br/><br/>"; innerTableHtml = innerTableHtml +
                    @"Statement of Employees Salary of " + month + "," + year + @" to be transfer to the respective Employee's Bank Account by debiting our CD Account No-" +
                    cdaccount + @" as noted below. </td></tr>
                    <tr><td colspan='7'><hr /></td></tr>
                    </table>";
                    innerTableHtml = innerTableHtml + @"<table border='0' style = 'width:760px; border:solid 1px #c0c0c0;'><tr style='text-align:Left; font-size: 11px; font-weight: bold; border:solid 1px #c0c0c0;'><td style= 'Width:10%;'>"; innerTableHtml = innerTableHtml + @"Code</td>
                    <td style= 'Width:25%;'>Employee name</td><td style= 'Width:15%;'>Department</td><td style= 'Width:9%;'>Bank Name</td><td style= 'Width:14%;'>Branch</td>
                    <td style= 'Width:17%;'>Account No</td><td style= 'Width:10%;'>Amount</td></tr>
                    </table>";
                for (int row = 0; row < dtabl.Rows.Count; row++)
                {
                    string code = dtabl.Rows[row]["strEmployeeCode"].ToString();
                    string name = dtabl.Rows[row]["strEmployeeName"].ToString();
                    string dept = dtabl.Rows[row]["strDepatrment"].ToString();
                    string bnk = dtabl.Rows[row]["strBankName"].ToString();
                    string brnch = dtabl.Rows[row]["strBranchName"].ToString();
                    string accno = dtabl.Rows[row]["strBankAccountNo"].ToString();
                    string amount = GetSubstringValue(dtabl.Rows[row]["monTotalPayableSalary"].ToString());

                    innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:760px; text-align: left; font-size: 11px; border:solid 1px #c0c0c0;'>
                        <tr><td style= 'Width:10%;'>"; innerTableHtml = innerTableHtml + code + @"</td>
                        <td style= 'Width:25%;'>"; innerTableHtml = innerTableHtml + name + @"</td>
                        <td style= 'Width:15%;'>"; innerTableHtml = innerTableHtml + dept + @"</td>
                        <td style= 'Width:10%;'>"; innerTableHtml = innerTableHtml + bnk + @"</td>
                        <td style= 'Width:15%;'>"; innerTableHtml = innerTableHtml + brnch + @"</td>
                        <td style= 'Width:15%;'>"; innerTableHtml = innerTableHtml + accno + @"</td>
                        <td style= 'Width:10%; text-align: right;'>"; innerTableHtml = innerTableHtml + amount + @"</td>
                        </tr>
                        </table>";
                }
                innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:760px; text-align: right; font-size: 11px; font-weight: bold;'>
                <tr><td colspan='7'>"; innerTableHtml = innerTableHtml + total + @"</td></tr></table>";
                #endregion
            }

            #region ------------ Filter Div By InnerHTML ---------------
            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            createDiv.ID = "createDiv";
            createDiv.InnerHtml = innerTableHtml;
            createDiv.Attributes.Add("class", "dynamicDivbn");
            this.Controls.Add(createDiv);
            #endregion

        }

        private string GetSubstringValue(string gvnstring)
        {
            if (String.IsNullOrEmpty(gvnstring))
            {
                return gvnstring;
            }
            else
            {
                decimal number;
                Decimal.TryParse(gvnstring, out number);
                decimal returnDEC = Decimal.Round(number, 2);
                return returnDEC.ToString();
            }
        }



    }
}