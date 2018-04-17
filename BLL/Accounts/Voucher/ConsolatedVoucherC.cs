using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.ConsolatedVoucherTDSTableAdapters;

namespace BLL.Accounts.Voucher
{
    public class ConsolatedVoucherC
    {
        public ConsolatedVoucherTDS.SprAccountsVoucherConsolatedDataTable GetConsolatedVoucher(DateTime fromDate
                                                                                                ,DateTime toDate
	                                                                                            ,bool? ysnEnabled
	                                                                                            ,bool? ysnCompleted
	                                                                                            ,bool? ysnFinished
	                                                                                            ,bool ysnBP
	                                                                                            ,bool ysnBR
	                                                                                            ,bool ysnCP
	                                                                                            ,bool ysnCR
	                                                                                            ,bool ysnJV
	                                                                                            ,bool ysnCN
	                                                                                            ,int intUserID
	                                                                                            ,int intUnitID
	                                                                                            ,ref string strUnitName
	                                                                                            ,ref string strAddress
                                                                                               )
        {

            SprAccountsVoucherConsolatedTableAdapter adp = new SprAccountsVoucherConsolatedTableAdapter();
            return adp.GetConsolatedVoucherData(fromDate, toDate, ysnEnabled, ysnCompleted, ysnFinished, ysnBP, ysnBR, ysnCP, ysnCR, ysnJV, ysnCN, intUserID, intUnitID, ref strUnitName, ref strAddress);

        }
    }
}
