using System;
using System.Data;
using DALOOP.Inventory;
using SCM_DAL.ComparativeStatementTDSTableAdapters;

namespace SCM_BLL
{
    public class ComparativeStatementBll
    {
        public DataTable InsertRfq(int intUnitId, int intWhid,string xmlString,int enroll, out string msg)
        {
            msg = string.Empty;
            try
            {
                sprRFQTableAdapter adp = new sprRFQTableAdapter();
                return adp.GetData(intUnitId, intWhid, xmlString, enroll, ref msg);
            }
            catch (Exception e)
            {
                
                msg = e.Message;
                return new DataTable();
            }

        }
        public void InsertRfqSentEmail(int intRfqId, int intSupplierId, int enroll, out string msg)
        {
            msg = string.Empty;
            try
            {
                sprRfqSentEmailTableAdapter adp = new sprRfqSentEmailTableAdapter();
                adp.GetData(intRfqId, intSupplierId,  enroll, ref msg);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

        }
        public bool UpdateRfqEmailToSupplier(int intRfqId, int intSupplierId)
        {
            bool isUpdate;
            try
            {
                sprRfqSentEmailTableAdapter adp = new sprRfqSentEmailTableAdapter();
                isUpdate = adp.UpdateRfqEmailToSupplier(intRfqId, intSupplierId)>0;
            }
            catch (Exception e)
            {
                isUpdate = false;
            }
            return isUpdate;

        }
        public DataTable GetRfq(int intRfqId)
        {
            try
            {
                sprGetRFQTableAdapter adp = new sprGetRFQTableAdapter();
                return adp.GetData(intRfqId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
        public string InsertQuotation(string quotationNo,int intRfqId, int supplierId, int intCurrency ,string xmlString, int enroll)
        {
            string msg = string.Empty;
            try
            {
                sprQuotationTableAdapter adp = new sprQuotationTableAdapter();
                adp.GetData( quotationNo, intRfqId, supplierId, intCurrency, xmlString, enroll,
                    ref msg);
                return msg;
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }
        
        public DataTable GetComperativeStatement(int intRfqId)
        {
            try
            {
                sprComparativeStatementTableAdapter adp = new sprComparativeStatementTableAdapter();
                return adp.GetData(intRfqId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }

        public int GetUnitIdByRfq(int rfq)
        {
            try
            {
                return new RfqMainDal().GetUnitIdByRfqId(rfq);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
