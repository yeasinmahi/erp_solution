﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.Payment.TreasuryChallanTDSTableAdapters;
namespace HR_BLL.Payment
{
    public class TreasuryChallanBLL
    {
        public DataTable getUnitByUser(int userId)
        {
            sprGetVATAccountByAccountsUserTableAdapter adp = new sprGetVATAccountByAccountsUserTableAdapter();
            return adp.GetUnitByUserId(userId);
        }

        public DataTable getChallanByVatAccountId(int vatAccountId)
        {
            TblChallanListTableAdapter adp = new TblChallanListTableAdapter();
            return adp.GetChallanDataByVatAcountId(vatAccountId);
        }

        public DataTable getChallanDetails(int vatAccountId)
        {
            TblDetailsTableAdapter adp = new TblDetailsTableAdapter();
            return adp.GetDetails(vatAccountId);
        }

        public DataTable getVatreg(int intTreasuryId)
        {
            TblVatTableAdapter adp = new TblVatTableAdapter();
            return adp.GetVatRegData(intTreasuryId);
        }

        public DataTable updateVatReg(int IntTreasuryId)
        {
            sprUPDATEtblVATTreasuryDepositTableAdapter adp = new sprUPDATEtblVATTreasuryDepositTableAdapter();
            return adp.UpdateVatTreasury(IntTreasuryId);
        }









        }
}