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
        public DataTable InsertUpdateSelectForItem(int intPart, string strMaterialName, string strDescription, string strPart, string strModel, string strSerial, string strBrand, string strSpecification,
                    int intUOM, string strUOM, string strOrigin, int intLocationID, string strHSCode, int intGroupID, string strGroupName, int intCategoryID, string strCategoryName, int intSubCategoryID,
                    string strSubCategoryName, int intMinorCategory, string strMinorCategory, int intPlantID, string strPlantName, int intProcureType, string strProcureType, decimal numMaxLeadTime,
                    decimal numMinLeadTime, decimal numMinimumStock, decimal numMaximumStock, decimal numSafetyStock, decimal numReOrderPoint, decimal numReOrderQty, int intABC, string strABC, int intFSN,
                    string strFSN, int intVDE, string strVDE, int intSelfLife, string strOrderingLotSize, decimal numEOQ, decimal numMOQ, decimal numMaxDailyConsump, decimal numMinDailyConsump, int intSDE,
                    string strSDE, int intHML, string strHML, bool ysnVATApplicable, int intWHID, int intAutoID, int intInsertBy, int intCOAID, int intMaterialMasterID)
        {
            SprItemAddAndApproveTableAdapter adp = new SprItemAddAndApproveTableAdapter();
            try
            {
                return adp.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin,
                    intLocationID, strHSCode, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID,
                    strPlantName, intProcureType, strProcureType, numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC,
                    strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable,
                    intWHID, intAutoID, intInsertBy, intCOAID, intMaterialMasterID);
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
        public DataTable GetItemListForPurchase(int intWHID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemListforPurchase(intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemInfoForPurchase(int intAutoID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemInfoForPurchase(intAutoID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemListForAccounts(int intWHID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemListforAccounts(intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemInfoForAccounts(int intAutoID)
        {
            ItemListForPurchaseTableAdapter adp = new ItemListForPurchaseTableAdapter();
            try
            { return adp.GetItemInfoForAccounts(intAutoID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDropDaownData(int intPart, int intWHID, int intInsertBy, int intGroupID, int intCategoryID)
        {
            SprGetDropDownListForInventoryStatementTableAdapter adp = new SprGetDropDownListForInventoryStatementTableAdapter();
            try
            { return adp.GetDropdownData(intPart, intWHID, intInsertBy, intGroupID, intCategoryID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetInventoryStatement(int intWHID, DateTime dteFDate, DateTime dteTDate, int intSearchBy, string strID, int intCatNew)
        {
            SprInventoryStatementGlobalTableAdapter adp = new SprInventoryStatementGlobalTableAdapter();
            try
            { return adp.GetInventoryStatement(intWHID, dteFDate, dteTDate, intSearchBy, strID, intCatNew); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemListReport(string strSearchText)
        {
            QryMaterialListTableAdapter adp = new QryMaterialListTableAdapter();
            try
            { return adp.GetItemListReport(strSearchText); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetCOAList(int intUnitID, bool ysnAdvance, bool ysnPurchase, bool ysnCreditors, bool ysnAll, bool ysnBillReg)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetCOAList(intUnitID, ysnAdvance, ysnPurchase, ysnCreditors, ysnAll, ysnBillReg); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetMaterialDetails(int intMasterID)
        {
            MaterialsDetailsTableAdapter adp = new MaterialsDetailsTableAdapter();
            try
            { return adp.GetMaterialDetails(intMasterID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUnitID(int intWHID)
        {
            TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
            try
            { return adp.GetUnitID(intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUnitCheck(int intMasterID, int intUnitID)
        {
            TblMaterialDetailTableAdapter adp = new TblMaterialDetailTableAdapter();
            try
            { return adp.GetUnitCheck(intMasterID, intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
    }
}
