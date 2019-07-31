using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAD_DAL.Global;
using SAD_DAL.Global.SalesOfficeTDSTableAdapters;

namespace SAD_BLL.Global
{
    public class SalesOffice
    {
        public SalesOfficeTDS.TblSalesOfficeDataTable GetSalesOffice(string unitId)
        {
            if (unitId == null || unitId == "") return new SalesOfficeTDS.TblSalesOfficeDataTable();
            TblSalesOfficeTableAdapter adp = new TblSalesOfficeTableAdapter();
            return adp.GetDataByUnit(int.Parse(unitId), true);
        }
        public SalesOfficeTDS.TblSalesOfficeDataTable GetSalesOfficeInfo(string salesOfficeId)
        {
            if (salesOfficeId == null || salesOfficeId == "") return new SalesOfficeTDS.TblSalesOfficeDataTable();
            TblSalesOfficeTableAdapter adp = new TblSalesOfficeTableAdapter();
            return adp.GetDataById(int.Parse(salesOfficeId));
        }
        public SalesOfficeTDS.QrySalesOfficeByShipPointDataTable GetSalesOfficeByShipPoint(string shipPoint)
        {
            if (shipPoint == "" || shipPoint == null) return new SalesOfficeTDS.QrySalesOfficeByShipPointDataTable();
            QrySalesOfficeByShipPointTableAdapter ta = new QrySalesOfficeByShipPointTableAdapter();
            return ta.GetDataByShipPoint(int.Parse(shipPoint), true);
        }

        public SalesOfficeTDS.SprSalesOfficeByUserDataTable GetSalesOffice(string userId, string unitId)
        {
            if (userId == "" || unitId == "" || unitId == null) return new SalesOfficeTDS.SprSalesOfficeByUserDataTable();
            SprSalesOfficeByUserTableAdapter ta = new SprSalesOfficeByUserTableAdapter();
            return ta.GetData(int.Parse(userId), int.Parse(unitId), true);
        }

        public SalesOfficeTDS.SprSalesOfficeByUserDataTable GetSalesOfficeWithAll(string userId, string unitId)
        {
            if (userId == "" || unitId == "" || unitId == null) return new SalesOfficeTDS.SprSalesOfficeByUserDataTable();
            SprSalesOfficeByUserTableAdapter ta = new SprSalesOfficeByUserTableAdapter();
            
            SalesOfficeTDS.SprSalesOfficeByUserDataTable table = ta.GetData(int.Parse(userId), int.Parse(unitId), true);

            SalesOfficeTDS.SprSalesOfficeByUserRow row = table.NewSprSalesOfficeByUserRow();
            row.intSalesOffId = 0;
            row.intUnitId = int.Parse(unitId);
            row.strName = "All";
            row.ysnEnable = true;

            table.Rows.Add(row);

            return table;
        }

        public DataTable GetAfblEmployeeEnroll()
        {
            DataTable dt = new DataTable();            
            tblEmployeeTableAdapter obj = new tblEmployeeTableAdapter();
            dt = obj.GetAfblEmployeeEnroll();
            return dt;
        }

    }
}
