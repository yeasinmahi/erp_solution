using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Penalty.PenaltyTDSTableAdapters;
using System.Data;

namespace HR_BLL.Penalty
{
   public class Penalty
    {
        #region All Operational Method
        public string InsertPunishmentData(int? intUserID, string empCode, decimal monPenaltyAmount, string strDescription, DateTime dteEffectedDate, int? intLoginUserID)
       {
           //Summary    :   THIS FUNCTION WILL BE USED TO INSERT PUNISHMENT DETAILS BY EMPLOYEE ID 
           //Created    :   MD. YEASIR ARAFAT / JUNE-01-2012
           //Modified   :   
           //Parameters :   return insertStatus
           try
           {
               string insertStatus = "";
               InsertPenaltyDataTableAdapter tbl = new InsertPenaltyDataTableAdapter();
               tbl.InsertData(intUserID, empCode, monPenaltyAmount, strDescription, dteEffectedDate, intLoginUserID, ref insertStatus);
               return insertStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
        public string UpdatePunishmentData(int? intUserID, string empCode, decimal monPenaltyAmount, string strDescription, DateTime dteEffectedDate, int? intLoginUserID)
       {
           //Summary    :   THIS FUNCTION WILL BE USED TO UPDATE PUNISHMENT DETAILS BY EMPLOYEE ID 
           //Created    :   MD. YEASIR ARAFAT / JUNE-01-2012
           //Modified   :   
           //Parameters :   return updateStatus
           try
           {
               string updateStatus = "";
               UpdatePenaltyDataTableAdapter tbl = new UpdatePenaltyDataTableAdapter();
               tbl.UpdateData(intUserID, empCode, monPenaltyAmount, strDescription, dteEffectedDate, intLoginUserID, ref updateStatus);
               return updateStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }
        public string DeletePunishmentData(int? intUserID, string empCode,DateTime dteEffectedDate, int? intLoginUserID)
       {
           //Summary    :   THIS FUNCTION WILL BE USED TO DELETE PUNISHMENT DETAILS BY EMPLOYEE ID 
           //Created    :   MD. YEASIR ARAFAT / JUNE-01-2012
           //Modified   :   
           //Parameters :   return deleteStatus
           try
           {
               string deleteStatus = "";
               DeletePenaltyDataTableAdapter tbl = new DeletePenaltyDataTableAdapter();
               tbl.DeleteData(intUserID, empCode,dteEffectedDate, intLoginUserID, ref deleteStatus);
               return deleteStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }
        public DataTable GetAllPunishmentData(int? intUserID, string empCode)
       {
           //Summary    :   THIS FUNCTION WILL BE USED TO GET ALL PUNISHMENT DETAILS BY EMPLOYEE ID 
           //Created    :   MD. YEASIR ARAFAT / JUNE-01-2012
           //Modified   :   
           //Parameters :   return DATA TABLE
           try
           {
               
               GetAllPenaltyByUserIDTableAdapter tbl = new GetAllPenaltyByUserIDTableAdapter();
               return tbl.GetData(intUserID, empCode);
               
           }
           catch (Exception ex)
           {
               DataTable odt = new DataTable();
               return odt;
           }
       }
        #endregion

        #region ----------- Disciplinary Punishment --------------
       public string InsertDisciplinaryPunishment(string empcode, int ptype, string dptype, DateTime effectivedate, decimal amount, string reason, int actionBy)
       {
           string rtnMessage = "";
           try
           {
               SprEmployeeDisciplinaryPunishmentTableAdapter ta = new SprEmployeeDisciplinaryPunishmentTableAdapter();
               ta.InsertPunishmentData(empcode, ptype, dptype, effectivedate, amount, reason, actionBy, ref rtnMessage);
           }
           catch { rtnMessage = "0"; }
           return rtnMessage;
       }
       public DataTable GetAllPunishment(string empCode)
        {
            try
            {
                TblEmployeePunishmentTableAdapter tbl = new TblEmployeePunishmentTableAdapter();
                return tbl.GetPunishmentData(empCode);
            }
            catch { return new DataTable(); }
        }
        public string CancelPunishment(int punishid)
        {
           string msg = "";
            try
            {
                TblEmployeePunishmentTableAdapter tbl = new TblEmployeePunishmentTableAdapter();
                tbl.CancelPunishment(punishid);
                return msg = "Penalty amount han been calceled." ;
            }
            catch (Exception ex){ return msg+" "+ex.Message.ToString(); }
        }

        #endregion

        #region All Familyday Method
        public DataTable GetPickDropList()
        {
            try
            {
                tblDropDownListTableAdapter tbl = new tblDropDownListTableAdapter();
                return tbl.GetPickDropData();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetGamesGroupList()
        {
            try
            {
                tblDropDownListTableAdapter tbl = new tblDropDownListTableAdapter();
                return tbl.GetGamesGroupData();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetGamesList(int groups)
        {
            try
            {
                tblDropDownListTableAdapter tbl = new tblDropDownListTableAdapter();
                return tbl.GetGamesDataBygroup(groups);
            }
            catch { return new DataTable(); }
        }
        public DataTable Familydayinformation(int type, string empcode, int pnd, string ptype, int actionBy, string xmlstring)
        {
            try
            {
                SprFamilyDayInformationTableAdapter ta = new SprFamilyDayInformationTableAdapter();
                return ta.SetFamilyInformationData(type, empcode, pnd, ptype, actionBy, xmlstring);
            }
            catch { return new DataTable(); }
        }
        #endregion

    }
}
