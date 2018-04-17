using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL;
using LOGIS_DAL.VehicleVarLogisGainGroupTDSTableAdapters;

namespace LOGIS_BLL
{
    public class VehicleVarLogisGainGroup
    {
        public VehicleVarLogisGainGroupTDS.TblVehicleLogisGainGroupDataTable GetGroupByUnit(string unit)
        {
            TblVehicleLogisGainGroupTableAdapter ta = new TblVehicleLogisGainGroupTableAdapter();
            return ta.GetDataByUnit(int.Parse(unit), true);
        }

        public void AddGroupByUnit(string unit, string groupName)
        {
            TblVehicleLogisGainGroupTableAdapter ta = new TblVehicleLogisGainGroupTableAdapter();
            ta.InsertGroup(groupName, int.Parse(unit), true);
        }

        public VehicleVarLogisGainGroupTDS.SprGetVehicleLogisGroupByCustomerDataTable GetCustomerByGroup(string customerId, string unit, string salesOffId, string CusType, string groupId, bool isInsert, bool isRemove)
        {
            int? cus = null;
            try { cus = int.Parse(customerId); }
            catch { }

            if (unit == null || unit == ""
                || salesOffId == null || salesOffId == ""
                || CusType == null || CusType == ""
                || groupId == null || groupId == "") return new VehicleVarLogisGainGroupTDS.SprGetVehicleLogisGroupByCustomerDataTable();

            SprGetVehicleLogisGroupByCustomerTableAdapter ta = new SprGetVehicleLogisGroupByCustomerTableAdapter();
            return ta.GetData(cus, int.Parse(unit), int.Parse(salesOffId), int.Parse(CusType), int.Parse(groupId), isInsert, isRemove);
        }
    }
}
