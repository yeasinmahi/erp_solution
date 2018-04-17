using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.ValidationTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Validation
    {
        public void ysnButtonForSaveAcctive(int? lcID, int? ShipmentID, string poCode, string stepShotName, string openOrAmen, ref bool? ysnActive)
        {
            SprCommercialGetSaveButtonActiveTableAdapter adp = new SprCommercialGetSaveButtonActiveTableAdapter();

            adp.GetDataForSavebtn(lcID, ShipmentID, poCode, stepShotName, openOrAmen, ref ysnActive);
            
        }

    }
}
