using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Module;
using DAL.Accounts.Module.ModuleTDSTableAdapters;

namespace BLL.Accounts.Module
{
    public class Module
    {

        public ModuleTDS.TblAccountsModuleDataTable GetModuleData()
        {
            TblAccountsModuleTableAdapter adp = new TblAccountsModuleTableAdapter();
            return adp.GetAllModule();
        }

    }
}
