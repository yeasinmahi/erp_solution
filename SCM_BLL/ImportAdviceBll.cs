using SCM_DAL.ImportAdviceTableAdapters;
using System;
using System.Data;
using SCM_BLL;
using Utility;

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
        public DataTable GetBankInfoForImport(int unitId, int bankId)
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
        public DataTable GetrateCount(string fromDate, string toDate)
        {
            try
            {
                DataTable2TableAdapter adp = new DataTable2TableAdapter();
                return adp.GetData(fromDate, toDate);

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable CreateVoucherBenificiarry(int intReqID, int intReqFor, int intUser)
        {
            try
            {
                sprImportFundRequisitionVoucherBenificiaryPayTableAdapter adp = new sprImportFundRequisitionVoucherBenificiaryPayTableAdapter();
                return adp.GetData(intReqID, intReqFor, intUser);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable CreateVoucherRequsition(int intReqID, int intReqFor, int intUser)
        {
            try
            {
                sprImportFundRequisitionVoucherTableAdapter adp = new sprImportFundRequisitionVoucherTableAdapter();
                return adp.GetData(intReqID, intReqFor, intUser);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable UpdateVoucher(string voucher, int reqId)
        {
            try
            {
                tblImportFundRequisitionTableAdapter adp = new tblImportFundRequisitionTableAdapter();
                return adp.GetData(voucher, reqId);

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetExchangeRate( string dteFDate, string dteTDate)
        {
            try
            {
                GetExchangeRateTableAdapter adp = new GetExchangeRateTableAdapter();
                return adp.GetExchangeRate(dteFDate.ToString(), dteTDate.ToString());
            }
            catch
            {

                return new DataTable();
            }

        }

    }
}
