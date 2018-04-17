using HR_DAL.Global.Expance_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.Global
{
    public class Expance_BLL
    {
        public DataTable ExpanceViewData(int intUnit,string stryear, int intEmployeeID)
        {
           
                SprCCWiseCostByEmployeeTableAdapter view = new SprCCWiseCostByEmployeeTableAdapter();
                return view.SPRPersonalExpanceGetData(intUnit, stryear, intEmployeeID);
            
        }

        public DataTable viewdetalis(int intUnit, string strYear,int cosid, int intEmployeeID)
        {
             SprCCCostByUnitUserAndCCTableAdapter viewdetalis = new SprCCCostByUnitUserAndCCTableAdapter();
                return viewdetalis.ViewetalisGetData(intUnit, strYear, cosid, intEmployeeID);
           
        }

        public DataTable viewdetaliswithCOA(int intcoa,int cosid)
        {
            try
            {
                TblAccountsSubLedgerTableAdapter divview = new TblAccountsSubLedgerTableAdapter();
                return divview.ExpanceDetalisbyCOAGetData(intcoa, cosid);
            }
            catch { return new DataTable(); }
        }
    }
}
