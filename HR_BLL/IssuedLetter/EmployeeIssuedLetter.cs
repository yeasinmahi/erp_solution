using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.IssuedLetter.EmployeeIssuedLetterTDSTableAdapters;
using HR_DAL.IssuedLetter;
using System.Data;

namespace HR_BLL.IssuedLetter
{
    public class EmployeeIssuedLetter
    {
        #region --------------- Issued Letter -----------
        public EmployeeIssuedLetterTDS.SprEmployeeIssuedAllLetterGetDataTable GetEmployeeIssuedAllLetter()
        {
            SprEmployeeIssuedAllLetterGetTableAdapter ta = new SprEmployeeIssuedAllLetterGetTableAdapter();
            return ta.GetEmployeeIssuedAllLetterData();
        }
        public EmployeeIssuedLetterTDS.SprEmployeeIssuedAllLetterPrintDataTable EmployeeIssuedLetterPrint(int intEmpId, int intLtrId)
        {
            SprEmployeeIssuedAllLetterPrintTableAdapter ta = new SprEmployeeIssuedAllLetterPrintTableAdapter();
            return ta.GetEmployeeIssuedAllLetterData(intEmpId, intLtrId);
        }

        #endregion

        #region --------------- Issued Performance -----------
        
        public DataTable GetIndividualInformation(int enroll)
        {
            InformationTableAdapter adp = new InformationTableAdapter();
            try { return adp.GetInformationData(enroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetIndividualInformation(string code)
        {
            InformationTableAdapter adp = new InformationTableAdapter();
            try { return adp.GetInformationByCodeData(code); }
            catch { return new DataTable(); }
        }
        public string InsertProgressData(int enroll, string xmleducation, string xmltraining, string bengli, string english, string others, string remarks, string expotherscompany, string xmlachievement, string rdoperformance, DateTime dtelstupdt, string xmlgrading, string shorttearm, string longtearm, string rdorelocat, string preference, string comments, string potential, string slfdevelopment, string tasktarget, string signatureurl)
        {
            SprConfidentialTableAdapter adapter = new SprConfidentialTableAdapter();
            string msg = "";
            try {
                adapter.IndividualProgressReportData(xmleducation, xmltraining, bengli, english, others, remarks, expotherscompany, xmlachievement, rdoperformance, dtelstupdt, xmlgrading, shorttearm, longtearm, rdorelocat, preference, comments, potential, slfdevelopment, tasktarget, signatureurl, enroll, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        #endregion

        #region -------------- Akij Group progress Report -----------------
        public DataTable GetGradingList()
        {
            TblGradingTableAdapter adp = new TblGradingTableAdapter();
            try { return adp.GetGradingListData(); }
            catch { return new DataTable(); }
        }
        public string InsertEmployeeProgress(int actionby, int loginuser, string eduxmlString, string traxmlString, string expxmlString)
        {
            SprAGEmployeeprogressTableAdapter adapter = new SprAGEmployeeprogressTableAdapter();
            string msg = "";
            try
            { adapter.InsertEmployeeProgressData(actionby, loginuser, eduxmlString, traxmlString, expxmlString, ref msg);}
            catch (Exception ex) { msg = ex.ToString() +", DB: " + msg ; }
            return msg;
        }
        public string UpdateEmployeeProgress(int actionby, int loginuser, string xmlString, string ovrallgrd, int incp, double inctk, double gross, string promotion, string remarks)
        {
            SprAGEmployeeapprisalTableAdapter adapter = new SprAGEmployeeapprisalTableAdapter();
            string msg = "";
            try
            { adapter.UpdateEmployeeProgressData(actionby, loginuser, xmlString, ovrallgrd, incp, decimal.Parse(inctk.ToString()), 
              decimal.Parse(gross.ToString()), promotion, remarks, ref msg); }
            catch (Exception ex) { msg = ex.ToString() + ", DB: " + msg; }
            return msg;
        }
        public DataTable GetPreviousRecord(int enroll, int status)
        {
            SprAGEmployeeprogressReportTableAdapter adp = new SprAGEmployeeprogressReportTableAdapter();
            try { return adp.GetPreviousRecordData(enroll, status); }
            catch { return new DataTable(); }
        }
        #endregion

        
    }
}
