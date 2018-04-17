using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.MigrationWork.AccChangeTDSTableAdapters;

namespace BLL.Accounts.MigrationWork
{
    public class Migration
    {

        public string ChangeAccountParent(int unitID, string codeForChange, string codeForNewParent, bool ysnWithChild)
        {
            bool ysnHimself=false;
            if(ysnWithChild)
            {
                ysnHimself=false;
            }
            else
            {
                ysnHimself=true;
            }
            SprTempChangeParentOfAccountTableAdapter adp = new SprTempChangeParentOfAccountTableAdapter();
            try
            {
                adp.ChangeParentOfAccount(codeForChange, codeForNewParent, ysnHimself, ysnWithChild, unitID);
                return "1";
            }
            catch
            {
                return "2";
            }
        }
    }
}
