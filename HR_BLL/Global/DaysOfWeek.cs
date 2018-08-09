using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.DaysOfWeekTDSTableAdapters;
using System.Data;
using HR_DAL.Global.InventoryTDSTableAdapters;

namespace HR_BLL.Global
{
    public class DaysOfWeek
    {
        public DaysOfWeekTDS.TblDayDataTable GetAllDays()
        {
            TblDayTableAdapter ta = new TblDayTableAdapter();
            return ta.GetWeeklyDaysData();
        }
        #region ------------ Requisition List ------------
        public DataTable GetItemList(int unit)
        {
            try
            {
                ItemListTableAdapter ta = new ItemListTableAdapter();
                return ta.GetItemListData(unit);
            }
            catch { return new DataTable(); }
        }

        public DataTable ReqDetailsByReqCode(string recode)
        {
            try
            {
                ReqDetailViewTableAdapter reqDetail = new ReqDetailViewTableAdapter();
               return reqDetail.RequesitionViewGetData(recode);
            }

            catch { return new DataTable(); }
        }

        public DataTable GetWarehouseList(int enroll, int type)
        {
            try
            {
                SprStoreRequisitionWhTableAdapter ta = new SprStoreRequisitionWhTableAdapter();
                return ta.GetWarehouseListData(enroll, type);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAllDepartmentList()
        {
            try
            {
                DeptListTableAdapter ta = new DeptListTableAdapter();
                return ta.GetDeptListData();
            }
            catch { return new DataTable(); }
        }
        public string GetLastRequisitionId(int reqid, int reqBy, int unit, int station, string xml)
        {
            string lstreqid="";
            SprEmployeeRequisitionTableAdapter adp = new SprEmployeeRequisitionTableAdapter();
            try { adp.GetLastRequisitionNoData(reqid, reqBy, unit, station, xml, ref lstreqid); }
            catch { }
            return lstreqid;
        }
        public string GetSubmitRequisition(int reqid, int reqBy, int unit, int station, string xml)
        {
            string message = "";
            SprEmployeeRequisitionTableAdapter adp = new SprEmployeeRequisitionTableAdapter();
            try { adp.GetLastRequisitionNoData(reqid, reqBy, unit, station, xml, ref message); }
            catch { }
            return message;
        }
        public DataTable GetRequistionList(int unit, int station, int userid)
        {
            try
            {
                ActiveRequisitionTableAdapter ta = new ActiveRequisitionTableAdapter();
                return ta.GetActiveRequisitionData(userid);//unit, userid, station);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetRequistionDetails(int reqsid)
        {
            try
            {
                TblRequisitionDetailTableAdapter ta = new TblRequisitionDetailTableAdapter();
                return ta.GetRequisitionDetailsData(reqsid);
            }
            catch { return new DataTable(); }
        }
        public string ApprovedRejectRequisition(int status, string xml, int actionby)
        {
            string message = "";
            SprEmployeeRequisitionApprovedRejectTableAdapter adp = new SprEmployeeRequisitionApprovedRejectTableAdapter();
            try { adp.GetRequisitionApprovedRejectData(status, xml, actionby, ref message); }
            catch { }
            return message;
        }

        public DataTable GetRequisitionById(int intwhid,DateTime from ,DateTime to)
        {
            TblRequisitionTableAdapter adp = new TblRequisitionTableAdapter();
            return adp.GetRequisitionData(intwhid,from,to);
        }
        #endregion

        #region ------------ PO List ------------
        public DataTable GetPOPendingList(int enroll)
        {
            SprMIRPendingListTableAdapter adp=new SprMIRPendingListTableAdapter();
            //DataTable dt = new DataTable();
            //dt = adp.GetMRPendingListData(enroll);
            try { return adp.GetMRPendingListData(enroll); }
            catch { return new DataTable(); }
            
        }
        public DataTable GetPODetails(int poid, int enroll)
        {
            QryMIRDetailTableAdapter adp = new QryMIRDetailTableAdapter();
            try { return adp.GetPODetailsData(poid, enroll); }
            catch { return new DataTable(); }
        }
        public string SubmitPOInspection(string xml, int actionby)
        {
            string message = "";
            SprMIRInsertTableAdapter adp = new SprMIRInsertTableAdapter();
            try { adp.GetMIRInsertData(actionby, xml, ref message); }
            catch { }
            return message;
        }
        #endregion     
        
        #region ------------ Create GetPass Details------------
        public DataTable CreateGetpass(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate)
        {
            SprGatepassInformationTableAdapter adp = new SprGatepassInformationTableAdapter();
            try { return adp.GetSetGatepassData(type, actionby, xml, id, fdate, tdate); }
            catch { return new DataTable();}            
        }

        public DataTable GetGetpassListByUser(int actionby)
        {
            SprGatepassInformationTableAdapter adp = new SprGatepassInformationTableAdapter();
            try { return adp.GetListDataByUser(actionby); }
            catch { return new DataTable(); }
        }
        public DataTable CreateStoreRequisition(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate, int intInsertBy)
        {
            SprStoreRequisitionTableAdapter adp = new SprStoreRequisitionTableAdapter();
            try { return adp.GetSetStoreRequisitionData(type, actionby, xml, id, fdate, tdate, intInsertBy); }
            catch { return new DataTable(); }
        }
        #endregion


        public DataTable CostCetnterUnit(int intUnit)
        {
            TblCostCenterTableAdapter cost = new TblCostCenterTableAdapter();
            return cost.CostCenterNameGetData(intUnit);
        }

        public DataTable CheckCurrentStock(int v1, int v2)
        {
            try
            {
                RequesitionStockCheckTableAdapter stkchk = new RequesitionStockCheckTableAdapter();
                return stkchk.StoackCheckGetData(v1, v2);
            }
            catch { return new DataTable(); }
           
        }

       
    }    
}
