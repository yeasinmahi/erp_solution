using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Closing.HR_Closing_TDSTableAdapters;

namespace HR_BLL.Closing
{
   public  class HR_Closing
    {
       public DataTable GetHRPeriodByUnitID(int? intUnitID)
       {
           //Summary    :   This function will use to get HR Period by unit id
           //Created    :   Md. Yeasir Arafat / May-29-2012
           //Modified   :   
           //Parameters :   return DataTable
           try
           {
               HRPeriod_ByUnitIDTableAdapter tbl = new HRPeriod_ByUnitIDTableAdapter();
               return tbl.GetData(intUnitID);
           }
           catch 
           {
               DataTable odt = new DataTable();
               return odt;
           }
       }

       public string ClosingPeriodByUnitID(int? intUnitId, DateTime? dteHRStartingYear, DateTime? dteHREndingYear)
       {
           //Summary    :   This function will use to close hr prriod by unit id
           //Created    :   Md. Yeasir Arafat / May-29-2012
           //Modified   :   
           //Parameters :   return strClosingStatus
           string strClosingStatus = "";
           try
           {
               sprHRPeriod_ClosingByUnitIdTableAdapter tbl = new sprHRPeriod_ClosingByUnitIdTableAdapter();
               tbl.GetData(intUnitId, dteHRStartingYear, dteHREndingYear, ref strClosingStatus);
               return strClosingStatus;
           }
           catch (Exception ex)
           {
               return "Sorry there is an error." + ex.Message;
           }
       }
      
    }
}
