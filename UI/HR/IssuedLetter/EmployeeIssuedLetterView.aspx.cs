using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.IssuedLetter;
using HR_DAL.IssuedLetter;
using System.IO;
using UI.ClassFiles;
namespace UI.HR.IssuedLetter
{
    public partial class EmployeeIssuedLetterView : BasePage
    {

        HR_BLL.IssuedLetter.EmployeeIssuedLetter issuedLetter = new HR_BLL.IssuedLetter.EmployeeIssuedLetter();
        EmployeeIssuedLetterTDS.SprEmployeeIssuedAllLetterPrintDataTable issuedLtrTable = null;
        int height = 50;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empId = int.Parse(Request.QueryString["intEmployeeID"]);
                int ltrId = int.Parse(Request.QueryString["intLetterId"]);
                issuedLtrTable = issuedLetter.EmployeeIssuedLetterPrint(empId, ltrId);
                if (ltrId == 1)
                {
                    OfferLetterData();
                }
                else if (ltrId == 2)
                {
                    PermanentLetterData();
                }
                else if (ltrId == 3)
                {
                    ApointmentLetterData();
                }
                else
                { }

                //GenerateOfferLetter(empId, ltrId, typeId);
            }
        }

        private void OfferLetterData()
        {
            string letterPath = Server.MapPath("");
            letterPath = letterPath + "\\LetterTypeTemplate\\OfferLetterData.htm";
            string fileContent = File.ReadAllText(letterPath);
            try
            {
                fileContent = fileContent.Replace("[HEIGHT]", height.ToString());
                fileContent = fileContent.Replace("[DATE]", DateTime.Now.ToShortDateString());
                fileContent = fileContent.Replace("[NAME]", issuedLtrTable[0].strEmployeeName.ToString());
                fileContent = fileContent.Replace("[SONAME]", issuedLtrTable[0].strLetterName.ToString());
                fileContent = fileContent.Replace("[DUTIES]", issuedLtrTable[0].strResponsibility.ToString());
            }
            catch
            {
            }
            viewDiv.InnerHtml = fileContent;
        }

        private void PermanentLetterData()
        {
            string letterPath = Server.MapPath("");
            letterPath = letterPath + "\\LetterTypeTemplate\\PermanentLetterData.htm";
            string fileContent = File.ReadAllText(letterPath);
            try
            {
                fileContent = fileContent.Replace("[HEIGHT]", height.ToString());
                fileContent = fileContent.Replace("[DATE]", DateTime.Now.ToShortDateString());
                fileContent = fileContent.Replace("[NAME]", issuedLtrTable[0].strEmployeeName.ToString());
                fileContent = fileContent.Replace("[SONAME]", issuedLtrTable[0].strLetterName.ToString());
                fileContent = fileContent.Replace("[DUTIES]", issuedLtrTable[0].strResponsibility.ToString());
            }
            catch
            {
            }
            viewDiv.InnerHtml = fileContent;
        }

        private void ApointmentLetterData()
        {
            string letterPath = Server.MapPath("");
            letterPath = letterPath + "\\LetterTypeTemplate\\ApointmentLetterData.htm";
            string fileContent = File.ReadAllText(letterPath);
            try
            {
                fileContent = fileContent.Replace("[HEIGHT]", height.ToString());
                fileContent = fileContent.Replace("[DATE]", DateTime.Now.ToShortDateString());
                fileContent = fileContent.Replace("[NAME]", issuedLtrTable[0].strEmployeeName.ToString());
                fileContent = fileContent.Replace("[SUBJECT]", issuedLtrTable[0].strLetterSubject.ToString());
                fileContent = fileContent.Replace("[SALUTATION]", "Dear " + issuedLtrTable[0].strSortName.ToString());
                fileContent = fileContent.Replace("[DESIGNATION]", issuedLtrTable[0].strDesignation.ToString());
                fileContent = fileContent.Replace("[UNITADDRESS]", issuedLtrTable[0].strDescription.ToString() + " , " + issuedLtrTable[0].strStationAddress.ToString());
                fileContent = fileContent.Replace("[PROBPERIOD]", "6 (Six)");
                fileContent = fileContent.Replace("[PRIORNOTICE]", "30 (Thirty)");

                fileContent = fileContent.Replace("[COMPLETIONYEAR]", issuedLtrTable[0].strContactPeriod.ToString());

                fileContent = fileContent.Replace("[DUTIES]", issuedLtrTable[0].strResponsibility.ToString());
                fileContent = fileContent.Replace("[SALARY]", issuedLtrTable[0].monSalary.ToString());
                fileContent = fileContent.Replace("[REPORTINGTO]", issuedLtrTable[0].strReportingTo.ToString());
                fileContent = fileContent.Replace("[UNIT]", issuedLtrTable[0].strDescription.ToString());
                fileContent = fileContent.Replace("[UNITHEADNAME]", issuedLtrTable[0].strSigningAuthority.ToString());
                fileContent = fileContent.Replace("[UNITHEADDESIGNATION]", issuedLtrTable[0].strSigningAuthorityDesignation.ToString());

                fileContent = fileContent.Replace("[CCTO]", issuedLtrTable[0].strCCTo.ToString());

            }
            catch
            {
            }
            viewDiv.InnerHtml = fileContent;
        }



    }
}