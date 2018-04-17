using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.PortContainnerTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class Containner
    {
        public ListItemCollection GetContainnerType()
        {
            ListItemCollection conTypeCol = new ListItemCollection();
            TblCommercialPortContainnerTypeTableAdapter adp = new TblCommercialPortContainnerTypeTableAdapter();
            PortContainnerTDS.TblCommercialPortContainnerTypeDataTable tbl = adp.GetContainnerTypeData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                conTypeCol.Add(new ListItem(tbl[i].strContainnerType, tbl[i].intContainnerTypeID.ToString()));

            }

            return conTypeCol;
        }
        public ListItemCollection GetContainnerType(int shipmentTypeID)
        {
            ListItemCollection conTypeCol = new ListItemCollection();
            TblCommercialPortContainnerTypeTableAdapter adp = new TblCommercialPortContainnerTypeTableAdapter();
            PortContainnerTDS.TblCommercialPortContainnerTypeDataTable tbl = adp.GetDataByShipmentType(shipmentTypeID);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                conTypeCol.Add(new ListItem(tbl[i].strContainnerType, tbl[i].intContainnerTypeID.ToString()));

            }

            return conTypeCol;
        }

        public PortContainnerTDS.FunCommercialGetContainnerByTypeDataTable GetContainnerByTypeID(int containnerTypeID)
        {
            FunCommercialGetContainnerByTypeTableAdapter adp = new FunCommercialGetContainnerByTypeTableAdapter();
            return adp.GetContainerData(containnerTypeID);
        }

    }
}
