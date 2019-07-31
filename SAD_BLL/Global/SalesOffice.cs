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

        public DataTable GetAfblSalesEmpInfo(int empId)
        {
            DataTable dt = new DataTable();
            tblEmployee1TableAdapter obj = new tblEmployee1TableAdapter();
            dt = obj.GetSalesEmpInfo(empId);
            return dt;
        }

        public DataTable GetSalesEmpFGInfo(int empId)
        {
            DataTable dt = new DataTable();
            tblEmployeeProfileTransferPromotionTableAdapter obj = new tblEmployeeProfileTransferPromotionTableAdapter();
            dt = obj.GetEmpGeoInfo(empId);
            return dt;
        }
        public DataTable GetSalesEmpGeoInfo(int empId)
        {
            DataTable dt = new DataTable();
            DataTable1TableAdapter obj = new DataTable1TableAdapter();
            dt = obj.GetSalesOfficerGeo(empId);
            return dt;
        }
        public DataTable GetTerrSalesEmpGeoInfo(int empId)
        {
            DataTable dt = new DataTable();
            DataTable2TableAdapter obj = new DataTable2TableAdapter();
            dt = obj.GetTerrSalesOfficer(empId);
            return dt;
        }
        public DataTable GetAreaSalesEmpGeoInfo(int empId)
        {
            DataTable dt = new DataTable();
            DataTable3TableAdapter obj = new DataTable3TableAdapter();
            dt = obj.GetAreaSalesOfficer(empId);
            return dt;
        }
        public DataTable GetRegionSalesEmpGeoInfo(int empId)
        {
            DataTable dt = new DataTable();
            DataTable4TableAdapter obj = new DataTable4TableAdapter();
            dt = obj.GetRegSalesOfficer(empId);
            return dt;
        }

        public DataTable UpdateEmpResignDate (int empId, DateTime resgDate)
        {
            DataTable dt = new DataTable();
            tblEmpResignUpdateAdapter obj = new tblEmpResignUpdateAdapter();
            dt = obj.UpdateSalesResigndate(resgDate,empId);
            return dt;
        }
    }
}
