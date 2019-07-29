using DAL.Accounts.Bank.RoutingNumberEntryTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.Bank
{
    public class RoutingNumberEntrybll
    {

        public object Response { get; private set; }

        public DataTable GetBank()
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

        public DataTable GetBankBranches()
        {
            try
            {
                tblBankBranchNameTableAdapter adp = new tblBankBranchNameTableAdapter();
                return adp.GetData();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }

        }

        public DataTable GetBankDistrict()
        {
            try
            {
                tblDistrictTableAdapter adp = new tblDistrictTableAdapter();
                return adp.GetData();


            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }



        public DataTable IsRoutingNumberExists(string routingNumber)
        {
            try
            {
                tblBankInfoTableAdapter adp = new tblBankInfoTableAdapter();
                return adp.GetData(routingNumber);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetInsertData(int intBankId, int intBranchId, int intBankDistrict, string strBankBranchCode, string strRoutingNumber)
        {
            try
            {
                DataTable2TableAdapter adp = new DataTable2TableAdapter();
                return adp.GetData(intBankId, intBranchId, intBankDistrict, strBankBranchCode, strRoutingNumber);
            }
            catch (Exception ex)
            {
                return new DataTable();

            }
        }
    }
}
