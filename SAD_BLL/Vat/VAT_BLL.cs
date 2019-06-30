using SAD_DAL.Vat.VAT_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAD_DAL.Vat.VAT_TDS;

namespace SAD_BLL.Vat
{
    public class VAT_BLL
    {
        #region ===== List Bind & Others =================================================
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

        #endregion ==================================================================

        #region ===== Create New Item And Material Option ================================
        public DataTable GetDropDownDataBindForCreateItemAndMaterial(int intPart, int intUnitID, int ysnFactory, int intVATAccountID)
        {
            SprCreateNewItemAndMaterialDropDownBindTableAdapter adp = new SprCreateNewItemAndMaterialDropDownBindTableAdapter();
            try
            { return adp.GetDataForCreateNewItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertVatItemAndMaterial(int intPart, int intUnitID, string strName, int intUserID, int intUoM, string strUoM, string strHSCode, bool ysnExempted, int intVATAccountID, int intMaterialType)
        {
            string msg = "";
            try
            {
                SprCreateVatItemAndMaterialForWebTableAdapter adp = new SprCreateVatItemAndMaterialForWebTableAdapter();
                adp.InsertVatItemAndMaterial(intPart, intUnitID, strName, intUserID, intUoM, strUoM, strHSCode, ysnExempted, intVATAccountID, intMaterialType, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
                
        #endregion =======================================================================


        #region ===== Bridge Option ======================================================
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

        #endregion =======================================================================

        #region ===== User Info For VAT ==================================================
        public DataTable GetUserInfoForVAT(int intUserID)
        {
            UserInfoForVATTableAdapter adp = new UserInfoForVATTableAdapter();
            try
            { return adp.GetUserInfoForVAT(intUserID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        #endregion =======================================================================

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

        #region ===== Purchase Entry =====================================================
        public string InsertPurchaseEntry(int intUnitID, int intVATAccountID, int intUserID, int intPurTypeID, DateTime dtePurchaseDate, int ysnFactory, string xml)
        {
            string msg = "";
            try
            {
                SprInsertIntoPurchaseAndCurrentRegForWebTableAdapter adp = new SprInsertIntoPurchaseAndCurrentRegForWebTableAdapter();
                adp.InsertPurchaseEntry(intUnitID, intVATAccountID, intUserID, intPurTypeID, dtePurchaseDate, ysnFactory, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetSupplierList(int intUnitID)
        {
            TblSupplierTableAdapter adp = new TblSupplierTableAdapter();
            try
            { return adp.GetSupplierList(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        #endregion ========================================================================

        #region ===== Price Declaration ==================================================
        public DataTable GetVatItemListForPriceDec(int intUnitID, int intVATAccountID)
        {
            TblItemVatListTableAdapter adp = new TblItemVatListTableAdapter();
            try
            { return adp.GetVatItemList(intUnitID, intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDItemVatPrice(int intProductID)
        {
            TblItemVat_PriceInfoTableAdapter adp = new TblItemVat_PriceInfoTableAdapter();
            try
            { return adp.GetDItemVatPrice(intProductID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPreviousM1InfoByItem(int intVatItemID, int intMushokType, DateTime dteDate)
        {
            SprGetVATDeclaredPriceM1TableAdapter adp = new SprGetVATDeclaredPriceM1TableAdapter();
            try
            { return adp.GetPreviousM1InfoByItem(intVatItemID, intMushokType, dteDate); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUOMByItemID(int intMaterialID)
        {
            TblConfigMaterialVATTableAdapter adp = new TblConfigMaterialVATTableAdapter();
            try
            { return adp.GetUOMByItemID(intMaterialID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertPriceDeclaration(int intProductID, decimal monSDChargable, decimal monSDPercent, decimal monVATPercent, int intUnit, int intUserID, DateTime dteValidFrom, int intType, int intVATAccountID, decimal monSCPercent, bool ysnFactory, decimal monVatPrice, decimal monWholeSale, decimal monMRP, string xml)
        {
            string msg = "";
            try
            {
                SprPriceDeclarationForWebTableAdapter adp = new SprPriceDeclarationForWebTableAdapter();
                adp.InsertPriceDeclaration(intProductID, monSDChargable, monSDPercent, monVATPercent, intUnit, intUserID, dteValidFrom, intType, intVATAccountID, monSCPercent, ysnFactory, monVatPrice, monWholeSale, monMRP, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        
        #endregion =======================================================================

        #region ===== Treasury Deposit ===================================================
        public DataTable GetTreasuryDepositType()
        {
            TblConfigTreasuryDepositCodeTableAdapter adp = new TblConfigTreasuryDepositCodeTableAdapter();
            try
            { return adp.GetTreasuryDepositType(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }        
        public string InsertTreasuryDeposit(int intUnitID, int intVatAcc, int intDepositType, decimal monAmount, int intUserID, string strTrChallanNo, DateTime dteTrChallan, string strInstrumentNo, DateTime dteInstrument, DateTime dteTransactionDate)
        {
            string msg = "";
            try
            {
                SprVATTreasuryDepositForWebTableAdapter adp = new SprVATTreasuryDepositForWebTableAdapter();
                adp.InsertTreasuryDeposit(intUnitID, intVatAcc, intDepositType, monAmount, intUserID, strTrChallanNo, dteTrChallan, strInstrumentNo, dteInstrument, dteTransactionDate, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        #endregion =======================================================================

        #region ===== M11 Started ========================================================
        public DataTable GetVatAccAddressAndNumber(int intUserID, int intVatAccountID)
        {
            TblVATAccountTableAdapter adp = new TblVATAccountTableAdapter();
            try
            { return adp.GetVatAccAddressAndNumber(intUserID, intVatAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        int e;
        private static QrySalesChallanForM11PrintDataTable[] tblChallanListForM11 = null;

        public string[] AutoSearchChallanNoForM11(string intVatAcID, string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                int intVatAccID = int.Parse(intVatAcID.ToString());
                tblChallanListForM11 = new QrySalesChallanForM11PrintDataTable[intVatAccID];
                QrySalesChallanForM11PrintTableAdapter adpCOAList = new QrySalesChallanForM11PrintTableAdapter();
                tblChallanListForM11[e] = adpCOAList.GetChallanNoSearchForM11(intVatAccID);

                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblChallanListForM11[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strCode
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tblChallanListForM11[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strCode.ToLower().Contains(prefix) || tmp.strName.ToLower().Contains(prefix) || tmp.strVehicleRegNo.ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strCode
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr[i] = tbl.Rows[i]["strCode"] + " [" + tbl.Rows[i]["strName"] + "]" + " [" + tbl.Rows[i]["strVehicleRegNo"] + "]" + " [" + tbl.Rows[i]["strAddress"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }

        public DataTable GetM11PrintGetM11Print(string strChallanNo, int intVatAccountID, string strCustVATRegNo, string strFinalDistanitionAddress, string strVehicleRegNo, int intVatChallanNo, DateTime dteM11DateTime, int intUserID, DateTime dteChallanDate, int intUnitID, string strCustomerName)
        {
            DateTime dteCheck2 = DateTime.Parse("1900-01-01".ToString());
            DateTime dteCheck3 = DateTime.Parse(dteCheck2.ToString("yyyy-MM-dd"));

            SprVATChallanCreateTableAdapter adp = new SprVATChallanCreateTableAdapter();

            if(dteM11DateTime == dteCheck3)
            {
                try
                { return adp.GetM11Print(strChallanNo, intVatAccountID, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, null, null, intUserID, null, null, strCustomerName); }
                catch (Exception ex) { ex.ToString(); return new DataTable(); }
            }
            else
            {
                try
                { return adp.GetM11Print(strChallanNo, intVatAccountID, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, null, dteM11DateTime, intUserID, null, null, strCustomerName); }
                catch (Exception ex) { ex.ToString(); return new DataTable(); }
            }
            
        }


        #endregion =======================================================================

        #region ===== M-19 Print =============================================================
        public DataTable GetVATAccountInfoByID(int intVATAccountID)
        {
            TblVATAccount_InfoTableAdapter adp = new TblVATAccount_InfoTableAdapter();
            try
            { return adp.GetVATAccountInfoByID(intVATAccountID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetM19Data(int intVATAccountID, DateTime dteDate)
        {
            SprVatMonthlyReturnReportForExcelM19ForWebTableAdapter adp = new SprVatMonthlyReturnReportForExcelM19ForWebTableAdapter();
            try
            { return adp.GetM19Data(intVATAccountID, dteDate); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertM19(DateTime dteTransactionDate, int intVatAcc, int intUserID)
        {
            string msg = "";
            try
            {
                SprVatMonthlyReturnM19TableAdapter adp = new SprVatMonthlyReturnM19TableAdapter();
                adp.InsertM19(dteTransactionDate, intVatAcc, intUserID, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        #endregion ===========================================================================


        public DataTable GetVatUnitByUser(int enroll)
        {
            try
            {
                TblConfigVATUserPermissionTableAdapter adp = new TblConfigVATUserPermissionTableAdapter();
                return adp.GetVatUnitByEnroll(enroll);
            }
            catch { return new DataTable(); }
        }
        
        public DataTable GetChallanByVAT(int VatID)
        {
            try
            {
                qrySalesChallanForM11PrintTableAdapter adp = new qrySalesChallanForM11PrintTableAdapter();
                return adp.GetData(VatID);
            }
            catch { return new DataTable(); }
        }























    }
}
