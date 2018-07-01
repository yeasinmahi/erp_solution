using SCM_DAL.MasterMaterialTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class MasterMaterialBLL
    {
        public DataTable InsertUpdateSelectForItem(int intPart, int intWHID, string strItemName, string strDescription, string strPart, string strModel, string strSerial, string strBrand, decimal numReOrderLevel, decimal numMinimumStock, decimal numMaximumStock,
                decimal numSafetyStock, int intUOM, string strUOM, int intLocationID, int intGroupID, string strGroupName, int intCategoryID, string strCategoryName, int intSubCategoryID, string strSubCategoryName, int intMinorCategory,
                string strMinorCategory, int intPlantID, string strPlantName, string strABCClassification, string strFSNClassification, string strVDEClassification, int intInsertBy, int intPurchaseType,
                string strPurchaseType, int intPOProcessingTime, int intShipmentTime, int intProcessTime, int intTotalLeadTime, string strLotSize, int intEOQ, int intMOQ, int intSDEClassification,
                string strSDEClassification, int intHMLClassification, string strHMLClassification, bool ysnVATApplicable, int intAutoID)
        {
            SprItemAddAndApproveTableAdapter adp = new SprItemAddAndApproveTableAdapter();
            try
            {
                return adp.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM, intLocationID, intGroupID,
                    strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, strABCClassification, strFSNClassification,
                    strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime, intTotalLeadTime, strLotSize, intEOQ, intMOQ, intSDEClassification,
                    strSDEClassification, intHMLClassification, strHMLClassification, ysnVATApplicable, intAutoID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetLocationByWH(int intWHID)
        {
            TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
            try
            { return adp.GetLocationByWH(intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemListForPurchase()
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemListforPurchase(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemInfoForPurchase(int intAutoID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemInfoForPurchase(intAutoID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemListForAccounts()
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemListforAccounts(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemInfoForAccounts(int intAutoID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemInfoForAccounts(intAutoID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
    }
}
