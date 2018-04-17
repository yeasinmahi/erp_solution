using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.DisPoint.DisPointTDSTableAdapters;
using SAD_DAL.DisPoint;

namespace SAD_BLL.DisPoint
{
    public class DisPointInfo
    {
        public DisPointTDS.QryDisPointDetailsDataTable GetDataById(string unitId, string disPointId)
        {
            if (disPointId == "" || disPointId == null || unitId == "" || unitId == null) return new DisPointTDS.QryDisPointDetailsDataTable();
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            return ta.GetDataById(int.Parse(disPointId), int.Parse(unitId));
        }
        public DisPointTDS.QryDisPointDetailsDataTable GetData(string unitId, string customerId, bool isEnable,string disPointId)
        {
            int?cus=null,dis=null;

            try{cus=int.Parse(customerId);}catch{}
            try{dis=int.Parse(disPointId);}catch{}

            if (unitId == "" || unitId == null || (cus == null && dis == null)) return new DisPointTDS.QryDisPointDetailsDataTable();
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            return ta.GetDataByUnitCustDis(int.Parse(unitId), isEnable, cus, dis);
        }

        public void UpdateDisPoint(string disPointId, string unitId, string customerId, string name, string address, string contactPerson, string contactNo, bool isEnable)
        {
            if (customerId == "" || customerId == null || unitId == "" || unitId == null) return;
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            ta.UpdateDisPoint(int.Parse(customerId), name, address, contactNo, isEnable, contactPerson, int.Parse(unitId), int.Parse(disPointId));
        }

        public void InsertDisPoint(string unitId, string customerId, string name, string address,string contactPerson, string contactNo, bool isEnable)
        {
            if (customerId == "" || customerId == null || unitId == "" || unitId == null) return;
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            ta.InsertDisPoint(int.Parse(unitId), name, address, contactPerson, contactNo, int.Parse(customerId), isEnable);
        }

        public void UpdateLogisVar(string disPointId, string unitId, string logisVarId)
        {
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            ta.UpdateLogisVariable(int.Parse(logisVarId), int.Parse(unitId), int.Parse(disPointId));
        }

        public void UpdatePriceVar(string disPointId, string unitId, string priceVarId)
        {
            QryDisPointDetailsTableAdapter ta = new QryDisPointDetailsTableAdapter();
            ta.UpdatePriceVariable(int.Parse(priceVarId), int.Parse(unitId), int.Parse(disPointId));
        }
    }
}
