using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.SADCOA;
using SAD_DAL.SADCOA.customerManagementForCOATDSTableAdapters;

namespace SAD_BLL.Customer
{
    public class CusManageForCOA
    {

        public customerManagementForCOATDS.SprSADCOAGetDataDataTable GetCusManageCOAData(string cusType,string parentID,string unitID,string userID)
        {
            int? pID;
            if (parentID == "" || parentID==null)
            {
                pID = null;
            }
            else
            {
                pID = int.Parse(parentID);
            }
            SprSADCOAGetDataTableAdapter adp = new SprSADCOAGetDataTableAdapter();
            return adp.GetData(pID, int.Parse(cusType), int.Parse(unitID), int.Parse(userID));
        }


        public customerManagementForCOATDS.TblSADCOARelationDataTable GetLastLvel(string unitID, string typeID)
        {
            TblSADCOARelationTableAdapter adp = new TblSADCOARelationTableAdapter();
            return adp.GetDataForLastLavel(int.Parse(unitID), int.Parse(typeID));

        }


        public bool CustomerManagementForCOAInsert(int cusType, int parentID, int unitID, string name, string userID)
        {
            bool ysnSuccess;
            SprSADCOAInsertTableAdapter adp = new SprSADCOAInsertTableAdapter();
            try
            {
                adp.InsertCustomerManagementForCOA(cusType, parentID, unitID, name, int.Parse(userID));
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }

            return ysnSuccess;
        }

    }
}
