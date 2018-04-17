using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.Bonus_TDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Benifit;
using System.Data;

namespace HR_BLL.Benifit
{
   public class Bonus_BLL
   {
       #region ===================== Employee Bonus ================
       public string CalculateBonus(int? intBonusID, DateTime? dteEffectedDate, int? intSoftwareUserLoginId)
       {
           //Summary    :   This function will use to calculat fesrival bonus
           //Created    :   Md. Yeasir Arafat / July-29-2012
           //Modified   :   
           //Parameters :   return calculate status
            string strBonusCalculationStatus = "";
           try
           {
               SprBenifit_CalculateFestivalBonusTableAdapter objSprBenifit_CalculateFestivalBonusTableAdapter = new SprBenifit_CalculateFestivalBonusTableAdapter();
               objSprBenifit_CalculateFestivalBonusTableAdapter.CalculateFestivalBonus(intBonusID, dteEffectedDate, intSoftwareUserLoginId, ref strBonusCalculationStatus);
           }
           catch (Exception ex) { strBonusCalculationStatus = ex.ToString(); }
           return strBonusCalculationStatus;
       }       
       public ListItemCollection GetBonusType()
       {
           //Summary    :   This function will use to get all Bonus type
           //Created    :   Md. Yeasir Arafat / Jult-29-2012
           //Modified   :   
           //Parameters :   

           ListItemCollection col = new ListItemCollection();

           SprBenifit_GetAllBonusTypeTableAdapter objSprBenifit_GetAllBonusTypeTableAdapter = new SprBenifit_GetAllBonusTypeTableAdapter();
           Bonus_TDS.SprBenifit_GetAllBonusTypeDataTable tbl = objSprBenifit_GetAllBonusTypeTableAdapter.GetAllBonusType();

           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               col.Add(new ListItem(tbl[i].strBonusName, tbl[i].intBonusId.ToString()));

           }


           return col;
       }
       public DataTable GetBonusDetailsForDataGrid()
       {
           //Summary    :   This function will use to get bonus details for showing in data grid
           //Created    :   Md. Yeasir Arafat / Jult-30-2012
           //Modified   :   
           //Parameters :   

           try
           {
               SprBenifit_GetBonusDetailsForDataGridTableAdapter objBenifit_GetBonusDetailsForDataGridTableAdapter = new SprBenifit_GetBonusDetailsForDataGridTableAdapter();
               return objBenifit_GetBonusDetailsForDataGridTableAdapter.GetData();
           }
           catch
           {
               DataTable odt = new DataTable();
               return odt;
           }
       }
       public DataTable GetUnitwiseBonusDetails(int? intLoginUserId, int? intBonusId)
       {
           //Summary    :   This function will use to get unit wise bonus details
           //Created    :   Md. Yeasir Arafat / July-30-2012
           //Modified   :   
           //Parameters :   

           UnitwiseBonusDetailsByLoginUserIdTableAdapter objUnitwiseBonusDetailsByLoginUserIdTableAdapter = new UnitwiseBonusDetailsByLoginUserIdTableAdapter();
           return objUnitwiseBonusDetailsByLoginUserIdTableAdapter.UnitwiseBonusDetailsByLoginUserId(intLoginUserId,intBonusId);
       }
       public DataTable GetUnitwiseBonusDetailsByUnitID(int? intUnitID, int? intBonusId)
       {
           //Summary    :   This function will use to get unit wise bonus details by loginUser ID
           //Created    :   Md. Yeasir Arafat / July-30-2012
           //Modified   :   
           //Parameters :   

           UnitwiseBonusDetailsByUnitIDTableAdapter objUnitwiseBonusDetailsByUnitIDTableAdapter = new UnitwiseBonusDetailsByUnitIDTableAdapter();
           return objUnitwiseBonusDetailsByUnitIDTableAdapter.UnitwiseBonusDetailsByUnitID(intUnitID,intBonusId);
       }
       public DataTable GetExcellProfile()
       {
           try
           {
               QryEmployeeProfileAllTableAdapter adp = new QryEmployeeProfileAllTableAdapter();
               return adp.GetGridData();
           }
           catch { return new DataTable(); }
       }

       #endregion

       #region===================== Attendance Benifits ===================
       public DataTable GetBenifitList()
       {
           try
           {
               TblBenifitTypeTableAdapter adp = new TblBenifitTypeTableAdapter();
               return adp.GetBenifitListData();
           }
           catch { return new DataTable(); }
       }
       public DataTable GetAttendanceBenifitList(int userid)
       {
           try
           {
               TblAttendanceBenifitTableAdapter adp = new TblAttendanceBenifitTableAdapter();
               return adp.GetAttendanceBenifitData(userid);
           }
           catch { return new DataTable(); }
       }
       public string InsertBenifit(string btype, string code, string amount, string narration, string userid)
       {
           string message = ""; QueriesTableAdapter qry = new QueriesTableAdapter();
           try
           {
               qry.InsertAttendanceBenifit(btype, amount, narration, userid, code);
               message = "Attendance benifit has been submitted";
           }
           catch (Exception ex) { message = ex.ToString(); }
           return message;
       }
       public string DeleteBenifit(int userid, int rowid)
       {
           string message = ""; QueriesTableAdapter qry = new QueriesTableAdapter();
           try
           {
               qry.UpdateAttendanceBenifit(userid, rowid);
               message = "Attendance benifit has been cancel"; 
           }
           catch (Exception ex) { message = ex.ToString(); }
           return message;
       }       
       #endregion


   }
}
