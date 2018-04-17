using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Reports.Bonus_TDSTableAdapters;
using System.Data;

namespace HR_BLL.Reports
{
   public  class BonusReport
    {
       public DataTable GetUnitwiseBonusDetails(int? intBonusId, DateTime? dteBonusEffectedDate, int? intUnitID, int? intJobStationId)
       {
           //Summary    :   This function will use to get Unit wise bonus details to generate bonus details report
           //Created    :   Md. Yeasir Arafat / July-31-2012
           //Modified   :   
           //Parameters :   bonus Effected date,bonusid, unit id and job station

           SprReport_BonusUnitwiseDetailsTableAdapter objSprReport_BonusUnitwiseDetailsTableAdapter = new SprReport_BonusUnitwiseDetailsTableAdapter();
           return objSprReport_BonusUnitwiseDetailsTableAdapter.UnitwiseBonusDetails(intBonusId, dteBonusEffectedDate, intUnitID, intJobStationId);
       }
    }
}
