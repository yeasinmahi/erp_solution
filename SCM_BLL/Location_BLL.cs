using SCM_DAL.LocationTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class Location_BLL
    {
        

        public DataTable WhDataView(int type, string xmlLocation, int intWH, int parentID, int enroll)
        {
            try
            {
                string strMsg = "";
                SprWhLocationTableAdapter adp = new SprWhLocationTableAdapter();
                return adp.GetWhLocationData(type, xmlLocation, intWH, parentID, enroll, ref strMsg);
            }
            catch { return new DataTable(); }

        }

        public string WHLocationCreate(int type, string xmlLocation, int intWH, int parentID, int enroll)
        {
            string strMsg = "";
            try
            {

                SprWhLocationTableAdapter adp = new SprWhLocationTableAdapter();
                adp.GetWhLocationData(type, xmlLocation, intWH, parentID, enroll, ref strMsg);

            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public DataTable WhLocationView(int intwh)
        {

            TblWearHouseStoreLocationTableAdapter adp = new TblWearHouseStoreLocationTableAdapter();
            return adp.GetLocationData(intwh);
           
         
        }

        public DataTable ItemVIew(int intWH)
        {
            try
            {
                TblItemListTableAdapter adp = new TblItemListTableAdapter();
                return adp.GetItemNameData(intWH);

            }
            catch { return new DataTable(); }
           
        }
    }
}
