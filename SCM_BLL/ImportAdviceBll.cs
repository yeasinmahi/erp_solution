using SCM_DAL.ImportAdviceTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class ImportAdviceBll
    {

        public DataTable GetUnit()
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetData();

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetBank()
        {
            try
            {
                tblBankInforForImportPaymentTableAdapter adp = new tblBankInforForImportPaymentTableAdapter();
                return adp.GetData();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetAdvice(int unitId, int bankId, string fromDate, string toDate)
        {
            try
            {
                qryImportBankAdviceRequirementTableAdapter adp = new qryImportBankAdviceRequirementTableAdapter();
                return adp.GetData(unitId, bankId, fromDate, toDate);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetUnit(int unitId, int bankId)
        {
            try
            {
                tblBankInforForImportPayment1TableAdapter adp = new tblBankInforForImportPayment1TableAdapter();
                return adp.GetData(unitId, bankId);

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetAdviceInformation(int intUnit,int intBank, DateTime ReqDate, string strAdviceGroup)
        {
            try
            {
                sprImportFundRequisitionAdviceDetailTableAdapter adp = new sprImportFundRequisitionAdviceDetailTableAdapter();
                return adp.GetData(intUnit, intBank, ReqDate, strAdviceGroup);

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
