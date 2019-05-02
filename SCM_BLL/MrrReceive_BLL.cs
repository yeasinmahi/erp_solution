using SCM_DAL.ItemTDSTableAdapters;
using SCM_DAL.MrrReceiveTDSTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class MrrReceive_BLL
    {
        public DataTable DataView(int Part, string xmlString, int intWh, int intPO, DateTime dteDate, int enroll)
        {
            try
            {
                string msg = "";
                SprMrrReceiveTableAdapter adp = new SprMrrReceiveTableAdapter();
                return adp.GetMrrReceiveData(Part, xmlString, intWh, intPO, dteDate, enroll, ref msg);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public string MrrReceive(int part, string xmlString, int intWh, int intPoid, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprMrrReceiveTableAdapter adp = new SprMrrReceiveTableAdapter();
                adp.GetMrrReceiveData(part, xmlString, intWh, intPoid, dteDate, enroll, ref strMsg);

            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public DataTable GetWhbyPo(int intPo)
        {
            TblPurchaseOrderMainTableAdapter adp = new TblPurchaseOrderMainTableAdapter();
            try
            {
                return adp.GetWHByPO(intPo);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetPoCompleteStatus(int intPo)
        {
            tblPurchaseOrderMainTableAdapter adp = new tblPurchaseOrderMainTableAdapter();
            try
            {
                return adp.GetPoCompleteStatus(intPo);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetWhByEnrollAndPo(int enroll, int intPo)
        {
            tblWearHouseOperatorTableAdapter adp = new tblWearHouseOperatorTableAdapter();
            try
            {
                return adp.GetWhByEnrollAndPo(enroll, intPo);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetPO(int intPO)
        {
            TblPurchaseOrderMainTableAdapter adp = new TblPurchaseOrderMainTableAdapter();
            try
            { return adp.GetPO(intPO); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetItemList(int intWH)
        {
            qryItemListNewTableAdapter adp = new qryItemListNewTableAdapter();
            try
            {
                return adp.GetItemList(intWH);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}