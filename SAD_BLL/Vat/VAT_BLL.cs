using SAD_DAL.Vat.VAT_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.Vat
{
    public class VAT_BLL
    {
        public DataTable GetVMaterialList(int intUnitID, int intVATAccountID)
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetVMaterialList(intUnitID, intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUOMM(int intUnitID)
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetUOMM(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetType()
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetType(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUOMForFactory(int intVATAccountID)
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetUOMForFactory(intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetVATAccountListByEnroll(int intUserID)
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetVATAccountListByEnroll(intUserID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        //===== Bridge Option ====================================================
        public DataTable GetVATItemList(int intUnitID, int intVATAccountID)
        {
            TblItemVatTableAdapter adp = new TblItemVatTableAdapter();
            try
            { return adp.GetVATItemList(intUnitID, intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetFGItemListForATMLALL()
        {
            TblItemTableAdapter adp = new TblItemTableAdapter();
            try
            { return adp.GetFGItemListForATMLALL(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetFGItemList(int intUnitID)
        {
            TblItemTableAdapter adp = new TblItemTableAdapter();
            try
            { return adp.GetFGItemList(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertVATItemAndMaterialBridge(int intPart, int intFGID, int intVatItemID, int intVATAccountID, int intUserID, string xml)
        {
            string msg = "";
            try
            {
                SprVATItemAndMaterialBridgeTableAdapter adp = new SprVATItemAndMaterialBridgeTableAdapter();
                adp.InsertVATItemAndMaterialBridge(intPart, intFGID, intVatItemID, intVATAccountID, intUserID, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetRMList(int intUnitID)
        {
            TblItemListTableAdapter adp = new TblItemListTableAdapter();
            try
            { return adp.GetRMList(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        //====== User Info For VAT =================================
        public DataTable GetUserInfoForVAT(int intUserID)
        {
            UserInfoForVATTableAdapter adp = new UserInfoForVATTableAdapter();
            try
            { return adp.GetUserInfoForVAT(intUserID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }


        #region ===== Production Entry ===================================================
        public DataTable GetVATItemForProductionEntry(int intUnitID, int intVATAccountID)
        {
            TblItemVatForProductionEntryTableAdapter adp = new TblItemVatForProductionEntryTableAdapter();
            try
            { return adp.GetVATItemForProductionEntry(intUnitID, intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetTypeForProductionEntry()
        {
            TblConfigMusokTypeTableAdapter adp = new TblConfigMusokTypeTableAdapter();
            try
            { return adp.GetTypeForProductionEntry(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBandrollCountCheck(int intUnitID, int intVATAccountID, int intItemID)
        {
            TblItemVatForProductionEntryTableAdapter adp = new TblItemVatForProductionEntryTableAdapter();
            try
            { return adp.GetBandrollCountCheck(intUnitID, intVATAccountID, intItemID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBrandRollList(int intProductID)
        {
            TblItemVatForProductionEntryTableAdapter adp = new TblItemVatForProductionEntryTableAdapter();
            try
            { return adp.GetBrandRollList(intProductID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertProductionEntry(int intItem, decimal numQty, DateTime dteDate, int intUnit, int intVATAccountID, int intUserID, int intType, string strMessage, int intBandroll, decimal numBRWastage)
        {
            string msg = "";
            try
            {
                SprVATProductionEntryTableAdapter adp = new SprVATProductionEntryTableAdapter();
                adp.InsertProductionEntry(intItem, numQty, dteDate, intUnit, intVATAccountID, intUserID, intType, ref strMessage, intBandroll, numBRWastage);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        #endregion =======================================================================

        #region ===== Other Adjustment ===================================================
        public string InsertOtherAdjustment(DateTime dteDate, string strRemark, int intUnitID, int intUserID, decimal monSD, decimal monVAT, decimal monSurCharge, int intVATAccountID, int intTransactionTypeID)
        {
            string msg = "";
            try
            {
                SprOtherAdjustmentTableAdapter adp = new SprOtherAdjustmentTableAdapter();
                adp.InsertOtherAdjustment(dteDate, strRemark, intUnitID, intUserID, monSD, monVAT, monSurCharge, intVATAccountID, intTransactionTypeID, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        #endregion ========================================================================































    }
}
