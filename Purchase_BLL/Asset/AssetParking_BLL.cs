using Purchase_DAL.Asset.AssetParkingTDSTableAdapters;
using System;
using System.Data;

namespace Purchase_BLL.Asset
{
    public class AssetParking_BLL
    {
        

        public DataTable GetAssetType()
        {
            try
            {
                AssetTypeTableAdapter ds = new AssetTypeTableAdapter();
                return ds.GetAssetType();
            }
            catch { return new DataTable(); }
           
        }

        public DataTable ParkingList(int intuntid)
        {
            try
            {
              
               ParkingListTableAdapter park = new ParkingListTableAdapter();
                return park.GetParkingListData();

            }
            catch { return new DataTable(); }
        }

        public DataTable ParkingDetalis(int intItem, int intPO, int intMrrID)
        {
            ParkingDetalisTableAdapter detalis = new ParkingDetalisTableAdapter();
            return detalis.GetParkingDetalisData(intItem, intPO, intMrrID);
        }

        public string InsertParkingData(int part, string xmlStringG, string xMLVehicle, string xMLBuilding, string xMLLand,decimal receveqty, int intenroll)
        {
            
            string rtnMessage = "";
            try
            {
                SprAssetParkintRegistrationTableAdapter ds = new SprAssetParkintRegistrationTableAdapter();
                ds.GetInsertParkingData(part, xmlStringG, xMLVehicle, xMLBuilding, xMLLand, receveqty,intenroll, ref rtnMessage);
            }
            catch { rtnMessage = "0"; }
            return rtnMessage;

        }

        public DataTable CwipAssetView(int v, string xmlStringG, string xMLVehicle, string xMLBuilding, string xMLLand, decimal recieveqty, int intuntid)
        {
            string rtnMessage = "";
            try
            {
                SprAssetParkintRegistrationTableAdapter cv = new SprAssetParkintRegistrationTableAdapter();
               return cv.GetInsertParkingData(v, xmlStringG, xMLVehicle, xMLBuilding, xMLLand, recieveqty, intuntid, ref rtnMessage);
            }
            catch { return new DataTable(); }
           
        }
    }
}