using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.ShipmentTypeTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class LCShipmentType
    {
        public ShipmentTypeTDS.TblCommercialShipmentTypesDataTable GetDataShipmentType()
        {
            TblCommercialShipmentTypesTableAdapter adp = new TblCommercialShipmentTypesTableAdapter();
            try
            {
                return adp.GetData();
            }
            catch
            {
                return null;
            }
        }

        public ShipmentTypeTDS.TblCommercialShipmentTypesDataTable GetDataShipmentTypeForShipment()
        {
            TblCommercialShipmentTypesTableAdapter adp = new TblCommercialShipmentTypesTableAdapter();
            try
            {
                return adp.GetDatForShipment();
            }
            catch
            {
                return null;
            }
        }
    }
}
