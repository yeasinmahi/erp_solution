using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.ShiftTDSTableAdapters;
using System.Web.UI.WebControls;
using System.Data;

namespace HR_BLL.Global
{
    public class Shift
    {
        public ShiftTDS.TblShiftDataTable GetAllShift()
        {
            TblShiftTableAdapter ta = new TblShiftTableAdapter();
            return ta.GetShiftData();
        }

        public ShiftTDS.SprEmployeeShiftByEmpCodeDataTable GetEmployeeShiftByEmpCode(string empCode)
        {
            SprEmployeeShiftByEmpCodeTableAdapter objAdp = new SprEmployeeShiftByEmpCodeTableAdapter();
            return objAdp.GetEmployeeShiftByEmpCodeData(empCode);
        }

        public ShiftTDS.SprEmployeeShiftByJobStationIdDataTable GetAllShiftByJobStationId(int intJobStationId)
        {
            SprEmployeeShiftByJobStationIdTableAdapter ta = new SprEmployeeShiftByJobStationIdTableAdapter();
            return ta.GetShiftData(intJobStationId);
        }

        public ListItemCollection GetAllShift(string empCode, ref string pShift)
        {
            ListItemCollection lstItmCollection = new ListItemCollection();
            SprEmployeeUnitJobStationShiftByEmpCodeTableAdapter ta = new SprEmployeeUnitJobStationShiftByEmpCodeTableAdapter();
            ShiftTDS.SprEmployeeUnitJobStationShiftByEmpCodeDataTable tbl = ta.GetEmployeeUnitStationShiftData(empCode,ref pShift);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                lstItmCollection.Add(new ListItem(tbl[index].strShiftName.ToString(), tbl[index].intShiftID.ToString()));
            }
            return lstItmCollection;
        }

        public ListItemCollection GetAllShift2(string empCode)
        {
            string pShift="";
            //empCode = "1111001";
            ListItemCollection lstItmCollection = new ListItemCollection();
            SprEmployeeUnitJobStationShiftByEmpCodeTableAdapter ta = new SprEmployeeUnitJobStationShiftByEmpCodeTableAdapter();
            ShiftTDS.SprEmployeeUnitJobStationShiftByEmpCodeDataTable tbl = ta.GetEmployeeUnitStationShiftData(empCode, ref pShift);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                lstItmCollection.Add(new ListItem(tbl[index].strShiftName.ToString(), tbl[index].intShiftID.ToString()));
            }
            return lstItmCollection;
        }

        public ShiftTDS.SprShiftWorkerByJobStationDataTable GetAllShiftWorker(int unitId, int stationId)
        {
            SprShiftWorkerByJobStationTableAdapter ta = new SprShiftWorkerByJobStationTableAdapter();
            return ta.ShiftWorkerByJobStationData(unitId, stationId);
        }

    }
}
