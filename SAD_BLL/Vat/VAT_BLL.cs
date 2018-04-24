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
        
































    }
}
