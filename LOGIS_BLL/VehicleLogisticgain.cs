using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_BLL.GLOBAL;
using LOGIS_DAL.VehicleLogisticgainTDSTableAdapters;

namespace LOGIS_BLL
{
    public class VehicleLogisticgain
    {
        public void SetGainValue(string userId, string unitId, string vehicleRegNoList, string vehicleVarID, string vehicleTypeList, DateTime startDate, DateTime? endDate, decimal price, decimal partyPrice, string uom, string currency, string product, ref int? error)
        {
            CodeGenatator cg = new CodeGenatator();
            string code = cg.GetLogisGainBatchCode(unitId);

            int? vhlVarID = null, uomID = null, pr = null;
            try
            {
                vhlVarID = int.Parse(vehicleVarID);
            }
            catch { }

            try
            {
                uomID = int.Parse(uom);
            }
            catch { }

            try { pr = int.Parse(product); }
            catch { }


            SprVehicleVarSetGainTableAdapter ta = new SprVehicleVarSetGainTableAdapter();
            ta.GetData(int.Parse(userId), vehicleRegNoList, vhlVarID, vehicleTypeList, true, startDate.Date, endDate, price, partyPrice, int.Parse(unitId), code, uomID, int.Parse(currency), pr, ref error);
        }

        public void SetGainGroupValue(string userId, string unitId,string groupId, string vehicleRegNoList, string vehicleVarID, string vehicleTypeList, DateTime startDate, DateTime? endDate, decimal price, decimal partyPrice, string uom, string currency, string product, ref int? error)
        {
            CodeGenatator cg = new CodeGenatator();
            string code = cg.GetLogisGainGroupBatchCode(unitId);

            int? vhlVarID = null, uomID = null, pr = null;
            try
            {
                vhlVarID = int.Parse(vehicleVarID);
            }
            catch { }

            try
            {
                uomID = int.Parse(uom);
            }
            catch { }

            try { pr = int.Parse(product); }
            catch { }


            SprVehicleVarSetGainByGroupTableAdapter ta = new SprVehicleVarSetGainByGroupTableAdapter();
            ta.GetData(int.Parse(userId), vehicleRegNoList, int.Parse(groupId), vhlVarID, vehicleTypeList, true, startDate.Date, endDate, price, partyPrice, int.Parse(unitId), code, uomID, int.Parse(currency), pr, ref error);
        }
    }
}
