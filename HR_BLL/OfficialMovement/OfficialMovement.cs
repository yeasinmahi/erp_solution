using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.OfficialMovement;
using System.Web.UI.WebControls;
using HR_DAL.OfficialMovement.OfficialMovementTDSTableAdapters;
using System.Data;

namespace HR_BLL.OfficialMovement
{
   public class OfficialMovement
    {
       #region Object Declare
       SprMovementGetMovementTypeTableAdapter objSprMovementGetMovementTypeTableAdapter = new SprMovementGetMovementTypeTableAdapter();
       SprGetAllUnApprovedOfficialMovementApplicationByUserIDTableAdapter objSprGetAllUnApprovedOfficialMovementApplicationByUserIDTableAdapter = new SprGetAllUnApprovedOfficialMovementApplicationByUserIDTableAdapter();
       SprInsertOfficialMovementApplicationTableAdapter objSprInsertOfficialMovementApplicationTableAdapter = new SprInsertOfficialMovementApplicationTableAdapter();
       SprUdateOfficialMovementApplicationTableAdapter objSprUdateOfficialMovementApplicationTableAdapter = new SprUdateOfficialMovementApplicationTableAdapter();
       SprDeleteOfficialMovementApplicationTableAdapter objSprDeleteOfficialMovementApplicationTableAdapter = new SprDeleteOfficialMovementApplicationTableAdapter();
       SprMovementGetAllUnapproveOfficialMovementApplicationForApproveByUserIDTableAdapter objSprMovementGetAllUnapproveOfficialMovementApplicationForApproveByUserIDTableAdapter = new SprMovementGetAllUnapproveOfficialMovementApplicationForApproveByUserIDTableAdapter();
       SprMovementApproveOfficeialMovementApplicationTableAdapter objSprMovementApproveOfficeialMovementApplicationTableAdapter = new SprMovementApproveOfficeialMovementApplicationTableAdapter();
       #endregion
       #region Method
       public ListItemCollection GetMovementTypeList()
       {
           //Summary    :   This function will use to Load Get OfficialMovementType for MovementTypeDropdown load
           //Created    :   Md. Yeasir Arafat / FEB-19-2012
           //Modified   :   
           //Parameters :

           ListItemCollection col = new ListItemCollection();
           OfficialMovementTDS.SprMovementGetMovementTypeDataTable tbl = objSprMovementGetMovementTypeTableAdapter.SprGetOfficialMovementType();
           for (int index = 0; index < tbl.Rows.Count; index++)
           {
               col.Add(new ListItem (tbl[index].strMoveType.ToString(),tbl[index].intMoveTypeID.ToString()));
           }

           return col;
       }
       #endregion
       public string SprInsertOfficialMovementApplication(int? intUserID, string empCode, int intMoveTypeID, DateTime dteStartTime, DateTime dteEndTime, string strCountryCode, string strAddress, int intDistrictID, string strReason)
       {
           //Summary    :   This function will use to Insert data into Official movement Application by Checking Movement Application Exsistency between FromDate AND ToDate 
           //Created    :   Md. Yeasir Arafat / FEB-19-2012
           //Modified   :   
           //Parameters :   return insertStatus
           try
           {
               string insertStatus = "";
               //objSprInsertOfficialMovementApplicationTableAdapter.SprInsertOfficialMovementApplication(intUserID, empCode, intMoveTypeID, dteStartTime, dteEndTime, strCountryCode, strAddress, intDistrictID, strReason, ref insertStatus);
               return insertStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }

       public string SprUdateOfficialMovementApplication(int intApplicationId,int? intUserID, string empCode, int intMoveTypeID, DateTime dteStartTime, DateTime dteEndTime, string strCountryCode, string strAddress, int intDistrictID, string strReason)
       {
           //Summary    :   This function will use to Update Official movement Application by Application And EmployeeID
           //Created    :   Md. Yeasir Arafat / FEB-19-2012
           //Modified   :   
           //Parameters :   return updateStatus
           try
           {
               string updateStatus = "";
               objSprUdateOfficialMovementApplicationTableAdapter.SprUdateOfficialMovementApplication(intApplicationId, intUserID, empCode,intMoveTypeID, dteStartTime, dteEndTime, strCountryCode, strAddress, intDistrictID, strReason, ref updateStatus);
               return updateStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }

       public string SprDeleteOfficialMovementApplication(int intApplicationId, int? userID,string empCode)
       {
           //Summary    :   This function will use to Update official movement Application by Application And EmployeeID
           //Created    :   Md. Yeasir Arafat / FEB-19-2012
           //Modified   :   
           //Parameters :   return deleteStatus 
           try
           {
               string deleteStatus = "";
               objSprDeleteOfficialMovementApplicationTableAdapter.SprDeleteOfficialMovementApplication(intApplicationId, userID, empCode, ref deleteStatus);
               return deleteStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }

       public DataTable GetAllUnApprovedOfficialMovementApplicationByUserID(string userID, string empCode)
       {
           //Summary    :   This function will use to Get All UnApproved Official movement Application  By  EmployeeID
           //Created    :   Md. Yeasir Arafat / FEB-19-2012
           //Modified   :   
           //Parameters :   return Unapprove Official movement Application As DataTable 

           int? intUserID = null;
           if (String.IsNullOrEmpty(userID))
           {
               intUserID = null;
           }
           else
           {
               intUserID = (int?)int.Parse(userID);
           }
           

           return objSprGetAllUnApprovedOfficialMovementApplicationByUserIDTableAdapter.SprGetAllUnApprovedOfficialMovementApplicationByUserID(intUserID, empCode);
       }

       public DataTable GetAllUnapproveOfficialMovementApplicationForApproveByUserID(int? intUserID)
       {
           //Summary    :   This function will use to Get All UnApproved Official movement Application  for approve
           //Created    :   Md. Yeasir Arafat / FEB-22-2012
           //Modified   :   
           //Parameters :   return Unapprove Official movement Application As DataTable 

           return objSprMovementGetAllUnapproveOfficialMovementApplicationForApproveByUserIDTableAdapter.SprMovementGetAllUnapproveOfficialMovementApplicationForApproveByUserID(intUserID);
       }
       public string SprApproveOfficialMovementApplication(int intApplicationId, int? intUserID, bool ysnApproved,bool ysnRejected)
       {
           //Summary    :   This function will use to Approve Official movement Application by ApplicationID
           //Created    :   Md. Yeasir Arafat / FEB-22-2012
           //Modified   :   
           //Parameters :   return appproveStatus
           try
           {
               string appproveStatus = "";
               objSprMovementApproveOfficeialMovementApplicationTableAdapter.SprApproveOfficeialMovementApplication(intApplicationId, intUserID, ysnApproved, ysnRejected, ref appproveStatus);
               return appproveStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }


       #region /* Application for Official Movement Developed By konock*/

       public string SubmitMovementApplication(string employeecode, int country, int district, DateTime fromdate, DateTime todate, string reason, string address, int actionBy)
       {
           string rtnMessage = "";
           try
           {
               SprMovement_ApplicationSubmitTableAdapter ta = new SprMovement_ApplicationSubmitTableAdapter();
               ta.MovementApplicationSubmit(employeecode,country, district,fromdate, todate, reason, address, actionBy, ref rtnMessage);
           }
           catch { rtnMessage = "0"; }
           return rtnMessage;
       }
       public string UpdateMovementApplication(int appid, int country, int district, DateTime fromdate, DateTime todate, string reason, string address, int actionBy)
       {
           string rtnMessage = "";
           try
           {
               SprMovement_ApplicationUpdateTableAdapter ta = new SprMovement_ApplicationUpdateTableAdapter();
               ta.MovementApplicationUpdate(appid, country, district, fromdate, todate, reason, address, actionBy, ref rtnMessage);
           }
           catch { rtnMessage = "0"; }
           return rtnMessage;
       }
       public string DeleteMovementApplication(int appid, int actionBy)
       {
           string rtnMessage = "";
           try
           {
               SprMovement_ApplicationDeleteTableAdapter ta = new SprMovement_ApplicationDeleteTableAdapter();
               ta.MovementApplicationDelete(appid, actionBy, ref rtnMessage);
           }
           catch { rtnMessage = "0"; }
           return rtnMessage;
       }
       public DataTable GetApplicationSummary(string strEmployeeCode, int? employeeid)
       {
           //Parameters : strEmployeeCode, employeeid
           SprMovement_ApplicationSummaryByEmployeeTableAdapter ad = new SprMovement_ApplicationSummaryByEmployeeTableAdapter();
           return ad.GetMovementApplicationSummary(strEmployeeCode, employeeid);
       }
       public DataTable GetMvTypeList()
       {
           try
           {
               TblofficialMovementTypeTableAdapter adp = new TblofficialMovementTypeTableAdapter();
               return adp.GetMovementTypeData();
           }
           catch { return new DataTable(); }
       }
       public string SubmitMovementApplication(int? intuser, string empcode, int mtp, TimeSpan tmstart, TimeSpan tmend, int counrty, int district, DateTime fromdate, DateTime todate, string reason, string address, int actionBy)
       {
           string insertStatus = "0";
           try
           {
               objSprInsertOfficialMovementApplicationTableAdapter.SprInsertOfficialMovementApplication(intuser, empcode, mtp, fromdate, todate, tmstart, tmend, counrty.ToString(), address, district, reason, actionBy, ref insertStatus);
               return insertStatus;
           }
           catch { return insertStatus; }
       }

        #endregion


       
    }
}
