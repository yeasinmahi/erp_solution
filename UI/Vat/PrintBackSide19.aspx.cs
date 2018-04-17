using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class PrintBackSide19 : BasePage
    {
        string innerReportHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region ================= Header Region =====================
                innerReportHtml = @" <table border='0' style = 'text-align:left; font-size: 12px;font-family:Verdana;'>
                <tbody class='borders'> 
                <tr class='noborders'><td colspan='2' style = 'font-size: 15px;text-align:center;'><b>FOR OFFICE USE</b></td></tr>
                <tr style='font-weight:bold; width:335px;'><td>(Will be filled by local VAT Office)</td><td>Remarks :</td></tr>
                <tr><td>Date<br/> <br/> 
                1.	Receive<br/> 
                2.	Send to Revenue officer<br/><br/>
                1.	Receive<br/> 
                2.	Distribute<br/> 
                3.	Send to Commissioner office</td>
                <td><br/> <br/> <br/> <br/> Seal and Signature of Asst. Revenue officer<br/><br/> Remarks :<br/> <br/> <br/>
                Seal and Signature of Revenue officer </td></tr>
                
                <tr style='font-weight:bold;'><td>(Will be filled by Commissioner Office)</td><td>Remarks :</td></tr>
                <tr><td>Date :<br/>
                1.	Receive<br/>
                2.	Send to Directorate <br/>
                    (if applicable)<br/><br/>
                3.	Computer Entry <br/>
                4.	Send follow up Letter </td>
                <td style = 'text-align:right;'><br/><br/><br/> <br/> <br/><br/><br/><br/> Seal and Signature <br/><br/> </td></tr>

                <tr style='font-weight:bold;'><td>(Will be filled by Directorate)</td><td>Remarks :</td></tr>
                <tr><td colspan='2'>
                1.	Receive Date :<br/>
                2.	Review :<br/>
                3.	Remarks :<br/><br/><br/>
                Granted Amount (Tk.) :<br/>
                Deposit Account Number :<br/>
                4.	Send to commissioner office (Date) :<br/><br/><br/><br/><br/>Date : ................................      	
                .............. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Seal and Signature of officer<br/><br/></td></tr>
                </tbody> 
                </table>";
                report.InnerHtml = innerReportHtml;
                #endregion
            }
        }
    }
}