using SCM_DAL;
using SCM_DAL.PoGenerateTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class PoGenerate_BLL
    {
        private static PoGenerateTDS.TblIServiceListDataTable[] tableService = null;
        private static PoGenerateTDS.DataTableSearchPOUserDataTable[] tablePoUser = null;
        private static PoGenerateTDS.TblSupplierMasterDataTable[] tblMasterSupplier = null;
        private static PoGenerateTDS.TblSupplierDataTable[] tblSupplier = null;
        private int e;

        public DataTable GetPoData(int type, string xml, int intWh, int indentId, DateTime dteDate, int enroll)
        {
            string msg = "";
            try
            {

                SprPoGenerateTableAdapter adp = new SprPoGenerateTableAdapter();
                return adp.GetPoGenerateData(type, xml, intWh, indentId, dteDate, enroll, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return new DataTable();
            }
        }

        public string PoApprove(int type, string xml, int intWh, int indentId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprPoGenerateTableAdapter adp = new SprPoGenerateTableAdapter();
                adp.GetPoGenerateData(type, xml, intWh, indentId, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public DataTable GetUnit()
        {
            try
            {
                TblUnitTableAdapter unit = new TblUnitTableAdapter();
                return unit.GetUnitData();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetUnitID(int intWh)
        {
            try
            {
                TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
                return adp.GetUnitIdbyWHData(intWh);
            }
            catch { return new DataTable(); }
        }



        public DataTable GetIndentbyPO(int intpoid)
        {
            try
            {
                GetIndentByPOTableAdapter unit = new GetIndentByPOTableAdapter();
                return unit.GetIndentByPO(intpoid);
            }
            catch { return new DataTable(); }
        }

        public string[] AutoSearchPoUser(string prefix)
        {
            tablePoUser = new PoGenerateTDS.DataTableSearchPOUserDataTable[Convert.ToInt32(1)];
            DataTableSearchPOUserTableAdapter adpCOA = new DataTableSearchPOUserTableAdapter();
            tablePoUser[e] = adpCOA.GetPoUserData();

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tablePoUser[e]//Convert.ToInt32(ht[unitID])
                               orderby tmp.strEmployeeName
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
                        var rows = from tmp in tablePoUser[e]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix)
                                   orderby tmp.strEmployeeName
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                        //if (rows2.Count() > 0) { tbl = rows2.CopyToDataTable(); }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " " + "[" + tbl.Rows[i]["intEmployeeID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string[] AutoSearchServiceItem(string intunit, string prefix)
        {
            tableService = new PoGenerateTDS.TblIServiceListDataTable[Convert.ToInt32(intunit)];
            TblIServiceListTableAdapter adpCOA = new TblIServiceListTableAdapter();
            tableService[e] = adpCOA.GetServiceItemData(Convert.ToInt32(intunit));

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 2)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableService[e]//Convert.ToInt32(ht[unitID])
                               orderby tmp.strItemName
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
                        var rows = from tmp in tableService[e]
                                   where tmp.strItemName.ToLower().Contains(prefix) || tmp.strPartNo.ToLower().Contains(prefix) || tmp.strDescription.ToLower().Contains(prefix)
                                   orderby tmp.strItemName
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                        //if (rows2.Count() > 0) { tbl = rows2.CopyToDataTable(); }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    // retStr[i] = tbl.Rows[i]["strItemName"] +" " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" + ";" + tbl.Rows[i]["intItem"];
                    retStr[i] = tbl.Rows[i]["strItemName"] + " " + tbl.Rows[i]["strDescription"] + " " + tbl.Rows[i]["strPartNo"] + "[" + tbl.Rows[i]["intItemID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string[] AutoSearchMasterSupplier(string prefix, string strType)
        {
            tblMasterSupplier = new PoGenerateTDS.TblSupplierMasterDataTable[Convert.ToInt32(1)];
            TblSupplierMasterTableAdapter adpCOA = new TblSupplierMasterTableAdapter();
            tblMasterSupplier[e] = adpCOA.GetMasterSupplierData(strType);

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            prefix = prefix.Trim().ToLower();
            if (prefix.Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblMasterSupplier[e]//Convert.ToInt32(ht[unitID])
                               orderby tmp.strSuppMasterName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tblMasterSupplier[e]
                                   where tmp.strSuppMasterName.ToLower().Contains(prefix) || tmp.intSuppMasterID.ToString().ToLower().Contains(prefix)
                                   orderby tmp.strSuppMasterName
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                        //if (rows2.Count() > 0) { tbl = rows2.CopyToDataTable(); }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strSuppMasterName"] + "[" + tbl.Rows[i]["intSuppMasterID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string[] AutoSearchSupplier(string prefix, string strType, string unit)
        {
            tblSupplier = new PoGenerateTDS.TblSupplierDataTable[Convert.ToInt32(unit)];
            TblSupplierTableAdapter adpCOA = new TblSupplierTableAdapter();
            tblSupplier[e] = adpCOA.GetSupplierData(int.Parse(unit));

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblSupplier[e]//Convert.ToInt32(ht[unitID])
                               orderby tmp.strSupplierName
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
                        var rows = from tmp in tblSupplier[e]
                                   where tmp.strSupplierName.ToLower().Contains(prefix) || tmp.intSupplierID.ToString().ToLower().Contains(prefix)
                                   orderby tmp.strSupplierName
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                        //if (rows2.Count() > 0) { tbl = rows2.CopyToDataTable(); }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strSupplierName"] + " " + "[" + tbl.Rows[i]["intSupplierID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        //public DataTable PoRegisterViewData(DateTime fDate  , DateTime tDate  ,string dept,int intWH  , int type  , int? intID  , int? intNewType)
        //{
        //    try
        //    {
        //        SprPORegisterTableAdapter adpView = new SprPORegisterTableAdapter();
        //        return adpView.GetPoRegisterData(fDate, tDate, dept, intWH, type, intID, intNewType);
        //    }
        //    catch { return new DataTable(); }

        //}

        public DataTable PoRegisterDataList(DateTime fDate, DateTime tDate, string dept, int intWH, int type, int? intID, int? intNewType)
        {
            try
            {
                sprPORegisterTableAdapter adpView = new sprPORegisterTableAdapter();
                return adpView.GetPoRegDataList(fDate, tDate, dept, intWH, type, intID, intNewType);
            }
            catch { return new DataTable(); }
        }

        public DataTable PoInfo(int intpoid)
        {
            POInfoTableAdapter adp = new POInfoTableAdapter();
            return adp.GetData(intpoid);
        }

        public string UpdatePO(decimal numQty, decimal monRate, decimal monVAT, decimal monAIT, int intItemID, int intPOID)
        {
            string msg = "";
            try
            {
                TblPurchaseOrderShipmentItemDetailTableAdapter adp = new TblPurchaseOrderShipmentItemDetailTableAdapter();
                adp.UpdatePOData(numQty, monRate, monVAT, monAIT, intItemID, intPOID);
                return msg = "Updated Successfully";
            }
            catch { }
            return msg;
        }

        public DataTable GetWHName(int whid)
        {
            try
            {
                tblWearHouseTableAdapter adp = new tblWearHouseTableAdapter();
                return adp.GetWHData(whid);
            }
            catch { return new DataTable(); }
        }

        public string DeletePo(int intItemID, int intPOID)
        {
            string msg = "";
            try
            {
                TblIndentItemAndPOItemTableAdapter adp = new TblIndentItemAndPOItemTableAdapter();
                adp.DeletePOData(intItemID, intPOID);
                return msg = "Deleted Successfully";
            }
            catch { }
            return msg;
        }

        public string UpdatePOMain(int intShipmentNo, string strDesPort, bool ysnPartialShip, string strPay, int intDay, int intInstall, int intInsInter, int intWarrenty, string strOtherTerms, DateTime dteShipDate, int intPOID, int intType, decimal monFreight, decimal monPacking, decimal monDiscount, int intSupplierID, DateTime dtePODate, int intCurrencyID, int enroll)
        {
            string msg = "";
            try
            {
                sprUpdatePOTableAdapter adp = new sprUpdatePOTableAdapter();
                adp.UpdatePOMainData(intShipmentNo, strDesPort, ysnPartialShip, strPay, intDay, intInstall, intInsInter, intWarrenty, strOtherTerms, dteShipDate, intPOID, intType, monFreight, monPacking, monDiscount, intSupplierID, dtePODate, intCurrencyID, enroll);
                return msg = "Updated Successfully";
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public DataTable GetItemInfoByPO(int intPOID)
        {
            TblItemInfoTableAdapter adp = new TblItemInfoTableAdapter();
            try
            { return adp.GetItemInfoByPO(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetMRRNoByPO(int intPOID)
        {
            TblFactoryReceiveMRRTableAdapter adp = new TblFactoryReceiveMRRTableAdapter();
            try
            { return adp.GetMRRNoByPO(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetSupplierInfoByPO(int intPOID)
        {
            TblSupplierInfoTableAdapter adp = new TblSupplierInfoTableAdapter();
            try
            { return adp.GetSupplierInfoByPO(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetSupplierAddress(int supplierId)
        {
            tblSupplierTableAdapter adp = new tblSupplierTableAdapter();
            try
            {
                return adp.GetSupplierAddress(supplierId);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetShipmentAndOtherInfoByPO(int intPOID)
        {
            TblShipmentTableAdapter adp = new TblShipmentTableAdapter();
            try
            { return adp.GetShipmentAndOtherInfoByPO(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetCurrency()
        {
            TblCurrencyConversionTableAdapter adp = new TblCurrencyConversionTableAdapter();
            try
            { return adp.GetCurrency(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable POCurrection(int intPart, int intPOID, DateTime dtePODate, int intCurrencyID, decimal monFreight, decimal monPacking, decimal monDiscount, int intShipment, string strDeliveryAddress, int ysnPartialShip,
        string strPayTerm, int intCreditDays, int intInstallmentNo, int intInstallmentInterval, int intWarrantyMonth, string strOtherTerms, DateTime dteLastShipmentDate, int intUpdateBy, int supplierId)
        {
            sprPOUPdateDeleteTableAdapter adp = new sprPOUPdateDeleteTableAdapter();
            try
            {
                return adp.POdeleteUpdate(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking, monDiscount, intShipment, strDeliveryAddress, ysnPartialShip,
                strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, dteLastShipmentDate, intUpdateBy, supplierId);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public bool CheckPOId(int POId)
        {
            bool result = false;
            sprPOUPdateDeleteTableAdapter adp = new sprPOUPdateDeleteTableAdapter();
            try
            {
                object _obj = adp.CheckPOId(POId);
                if (_obj != null)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public bool UpdateCnFBillNo(string BillNo, int POId)
        {
            bool result = false;
            sprPOUPdateDeleteTableAdapter adp = new sprPOUPdateDeleteTableAdapter();
            try
            {
                int ii = adp.UpdateCnFBillNo(BillNo,POId);
                if (ii > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public DataTable GetSuppliers(int poId)
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetSupplier(poId);
            }
            catch (Exception exception)
            {
                return new DataTable();
            }

        }


        public string UpdateItemInfoByPONew(int intPOID, decimal numPOQty, int intItemID, string strSpecification, decimal monRate, decimal monVAT, decimal monAmount, int intupdateby, decimal monAIT)
        {
            string msg = "";
            sprPOItemInfoUpdateTableAdapter adp = new sprPOItemInfoUpdateTableAdapter();
            adp.UpdateItemInfoByPO(intPOID, numPOQty, intItemID, strSpecification, monRate, monVAT, monAmount, intupdateby, monAIT, ref msg);
            return msg;
        }

        public DataTable GetApprovalAuthorityList(int enroll, string POType)
        {
            TblApprovalAuthorityTableAdapter adp = new TblApprovalAuthorityTableAdapter();
            try
            {
                return adp.GetPOApprovalAuthority(enroll, POType);
            }
            catch
            {
                return new DataTable();
            }
        }
        public DataTable GetApprovalInfo(int poId)
        {
            DataTable2TableAdapter adp = new DataTable2TableAdapter();
            try
            {
                return adp.GetApprovalInfo(poId);
            }
            catch
            {
                return new DataTable();
            }
        }

        public string Delete_PO_Data(int intItemID, int POID, int Enroll)
        {
            string msg = "";
            SprDeletePOTableAdapter adp = new SprDeletePOTableAdapter();
            try
            {
                adp.DeletePO(intItemID, POID, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return msg;
        }
        public DataTable ImportLCType()
        {
            TblImportLcTypeTableAdapter adp = new TblImportLcTypeTableAdapter();
            try
            {
                return adp.GetImportLCType();
            }
            catch
            {
                return new DataTable();
            }
        }
        public DataTable MaterialType()
        {
            TblItemCategoryTableAdapter adp = new TblItemCategoryTableAdapter();
            try
            {
                return adp.GetMaterialType();
            }
            catch
            {
                return new DataTable();
            }
        }


        public DataTable ImportLcIncoTerms()
        {
            TblImportLcIncoTermsTableAdapter adp = new TblImportLcIncoTermsTableAdapter();
            try
            {
                return adp.GetImportLcIncoTerms();
            }
            catch
            {
                return new DataTable();
            }
        }
        public DataTable BankInfoForImportPayment()
        {
            TblBankInfoForImportPaymenTableAdapter adp = new TblBankInfoForImportPaymenTableAdapter();
            try
            {
                return adp.GetBank();
            }
            catch
            {
                return new DataTable();
            }
        }

        public string InsertImportLC(int intPOID, int intLCCategory, int intItemCategory, int intBank, string strLoadingPort, string strDestination, decimal monTolerancePercent, int intCurrency,
        decimal monLcTenorMonth, string dteLastShipmentDate, string dteLcExpireDate, DateTime dteInsertionTime, int intInsertBy, int intUnit, int intSupplierID, int intIncoTerms,
        string strOrigin, string strDescription, string strPiNo, string dtePIDate, int intPresentationDays, bool ysnSROBenifit, bool ysnLocalLc, decimal monPIAmount,
        bool ysnLcConfirmation, decimal numQtyTolerancePercent)
        {
            string msg = "";
            TblImportLCTableAdapter adp = new TblImportLCTableAdapter();
            try
            {
                adp.InsertIntoImportLC(intPOID, intLCCategory, intItemCategory, intBank, strLoadingPort, strDestination, monTolerancePercent, intCurrency,
                monLcTenorMonth, dteLastShipmentDate, dteLcExpireDate, dteInsertionTime, intInsertBy, intUnit, intSupplierID, intIncoTerms,
                strOrigin, strDescription, strPiNo, dtePIDate, intPresentationDays, ysnSROBenifit, ysnLocalLc, monPIAmount,
                ysnLcConfirmation, numQtyTolerancePercent);
                msg = "Generated Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return msg;
        }

        public DataTable GetPOAmountByPOID(int POId)
        {
            qryInventoryPOTotalTableAdapter adp = new qryInventoryPOTotalTableAdapter();
            try
            {
                return adp.GetPOTotalData(POId);
            }
            catch
            {
                return new DataTable();
            }
        }


    }
}