using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales.WeightBridgeDataController_TDSTableAdapters;
using System.Data;

namespace SAD_BLL.Sales
{
   public class WeightBridgeDataCollector
    {

       public DataTable GetWeightBridgeModelAndActivateState(int? intUnitID)
       {
           //Summary    :   This function will use to get weightBridge Model no and present activation state by unit Id 
           //Created    :   Md. Yeasir Arafat / May-27-2012
           //Modified   :   
           //Parameters :   return DataTable

           try
           {
               WeightBridgeModel_And_PresentStateTableAdapter tbl = new WeightBridgeModel_And_PresentStateTableAdapter();
               return tbl.GetData(intUnitID);
           }
           catch {
               DataTable odt = new DataTable();
               return odt;
           }
       }
       
    }
}
