using SCM_DAL;
using SCM_DAL.InventoryTransferTDSTableAdapters;
using System;
using System.Data;
using System.Linq;
using SCM_DAL.DmageTDSTableAdapters;

namespace SCM_BLL
{
    public class InventoryTransfer_BLL
    {
        private static InventoryTransferTDS.VehicleSearchDataTable[] tableVehicle = null;
        private int e;

        public DataTable GetTtransferDatas(int Type, string xmlString, int intWh, int id, DateTime dteDate, int enroll)
        {
            try
            {
                string msg = "";
                SprInventoryTransferWebTableAdapter adp = new SprInventoryTransferWebTableAdapter();
                return adp.GetTransferData(Type, xmlString, intWh, id, dteDate, enroll, ref msg);
            }
            catch { return new DataTable(); }
        }

        public string PostTransfer(int Type, string xmlString, int intWh, int id, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprInventoryTransferWebTableAdapter adp = new SprInventoryTransferWebTableAdapter();
                adp.GetTransferData(Type, xmlString, intWh, id, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex)
            {
                return strMsg = ex.ToString();
            }
            return strMsg;
        }

        public string PostTransferDamage(int Type, string xmlString, int intWh, int id, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                sprInventoryTransferWebDamageEntryTableAdapter adp = new sprInventoryTransferWebDamageEntryTableAdapter();
                adp.GetData(Type, xmlString, intWh, id, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public string[] AutoSearchVehicle(string unit, string prefix)
        {
            tableVehicle = new InventoryTransferTDS.VehicleSearchDataTable[Convert.ToInt32(unit)];
            VehicleSearchTableAdapter adpCOA = new VehicleSearchTableAdapter();
            tableVehicle[e] = adpCOA.GetVehicleData(Convert.ToInt32(unit));

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 || prefix == "*")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableVehicle[e]//Convert.ToInt32(ht[unitID])
                               orderby tmp.intID
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
                        var rows = from tmp in tableVehicle[e]
                                   where tmp.strRegNo.ToLower().Contains(prefix) || tmp.intID.ToString().ToLower().Contains(prefix)
                                   orderby tmp.strRegNo
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
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
                    retStr[i] = tbl.Rows[i]["strRegNo"] + "[" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetWearHouse()
        {
            TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
            return adp.GetWHList();
        }

        public DataTable GetFGList(int intunitid)
        {
            TblItemTableAdapter adp = new TblItemTableAdapter();
            return adp.GetFGData(intunitid);
        }

        public DataTable GetSadUOMList(int intunit)
        {
            TblUOMTableAdapter adp = new TblUOMTableAdapter();
            return adp.GetSadUOMData(intunit);
        }

        public DataTable InsertItemList(string strName, string strDescription, string strPartNo, string strBrand, int intClusterID, int intComGroupID, int intCategoryID, int intEnroll, DateTime dteLastActionTime, string strUoM)
        {
            tblItemMasterListTableAdapter adp = new tblItemMasterListTableAdapter();
            return adp.InsertItemData(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, intEnroll, dteLastActionTime, strUoM);
        }

        public DataTable GetItemMasterList(string strName, string strDescription, string strPartNo, string strBrand, int intClusterID, int intComGroupID, int intCategoryID, string strUoM, int intEnroll, int intUnit, int SADItemID, decimal numConversion, int intSadStandardUOM, int intInvUoM)
        {
            sprItemMasterListCreateFGTableAdapter adp = new sprItemMasterListCreateFGTableAdapter();
            return adp.GetItemMasterData(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, strUoM, intEnroll, intUnit, SADItemID, numConversion, intSadStandardUOM, intInvUoM);
        }

        public DataTable CreateItemMasterList(string strName, string strDescription, string strPartNo, string strBrand, int intClusterID, int intComGroupID, int intCategoryID, string strUoM, int intEnroll)
        {
            sprItemMasterListCreateTableAdapter adp = new sprItemMasterListCreateTableAdapter();
            return adp.GetItemMasterListCreate(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, strUoM, intEnroll);
        }

        public DataTable GetUnitListByEnrollData(int intEnroll)
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            return adp.GetUnitListByEnroll(intEnroll);
        }

        public DataTable InsertHSCodeData(string strHSCode, string strDescription, decimal CD, decimal RD, decimal SD, decimal VAT, decimal AIT, decimal ATV, decimal PSI, string strUnit, decimal TTI, decimal EXD)
        {
            SprAddHSCodeTableAdapter adp = new SprAddHSCodeTableAdapter();
            return adp.InsertHSCode(strHSCode, strDescription, CD, RD, SD, VAT, AIT, ATV, PSI, strUnit, TTI, EXD);
        }

        //public String InsertSupplierAccountsInfoList(string RequesterName, string RequesterDesignation, string SupplierName, string SupplierAddress,int AccountNo, int RoutingNo,int RequestBy,int SuperviseBy,DateTime dteRequestBy,DateTime dteSuperviseBy,string xml)
        //{
        //    SprSupplierAccountsInfoUpdateTableAdapter adp = new SprSupplierAccountsInfoUpdateTableAdapter();
        //    string msg = "";
        //    try
        //    {
        //       adp.InsertSupplierData(RequesterName, RequesterDesignation, SupplierName, SupplierAddress, AccountNo, RoutingNo, RequestBy, SuperviseBy, dteRequestBy, dteSuperviseBy, xml);
        //       msg = "SUPPLIER UPDATED SUCCESSFULLY..";
        //    }
        //    catch (Exception e) { msg = e.ToString(); }
        //    return msg;
        //}

        public DataTable InsertSupplierAccountsInfoList(string RequesterName, string RequesterDesignation, string SupplierName, int suppMasterID, string SupplierAddress, int AccountNo, int RoutingNo, int RequestBy, int SuperviseBy, DateTime dteRequestBy, DateTime dteSuperviseBy, string xml)
        {
            sprSupplierAccountsInfoUpdateTableAdapter adp = new sprSupplierAccountsInfoUpdateTableAdapter();
            string msg = "";
            try
            {
                return adp.GetSupplierData(RequesterName, RequesterDesignation, SupplierName, suppMasterID, SupplierAddress, AccountNo, RoutingNo, RequestBy, SuperviseBy, dteRequestBy, dteSuperviseBy, xml);
                //msg = "SUPPLIER UPDATED SUCCESSFULLY..";
            }
            catch (Exception e) { return new DataTable(); }
        }

        public DataTable GetSupplyInfoById(int supplerMasterId)
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            string msg = "";
            try
            {
                return adp.GetSupplierInfoByPoId(supplerMasterId);
                //msg = "SUPPLIER UPDATED SUCCESSFULLY..";
            }
            catch (Exception e) { return new DataTable(); }
        }

        public DataTable GetAssetData(int whid, DateTime FromDate, DateTime toDate, int intSearchBy, string strID)
        {
            SprInventoryStatementTableAdapter adp = new SprInventoryStatementTableAdapter();
            return adp.GetAssetData(whid, FromDate, toDate, intSearchBy, strID);
        }

        public DataTable InsertCurrentAssetAudit(string xml)
        {
            sprCurrentAssetAuditTableAdapter adp = new sprCurrentAssetAuditTableAdapter();
            try
            {
                return adp.InsertCurrentAssetData(xml);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetWHList()
        {
            tblWearHouseTableAdapter adp = new tblWearHouseTableAdapter();
            return adp.GetWHData();
        }

        public DataTable GetItemInfoByPoId(int poId, int intShipmen, bool isImported)
        {
            sprInventoryMRRGetItemInfoTableAdapter adp = new sprInventoryMRRGetItemInfoTableAdapter();
            string msg = "";
            try
            {
                return adp.GetItemInfoByPoId(poId, intShipmen, isImported);
                //msg = "SUPPLIER UPDATED SUCCESSFULLY..";
            }
            catch (Exception e) { return new DataTable(); }
        }

        //public string InsertGoodReceiveNote(int intItemId, string strItemName,string strDes,string strUoM,decimal numPoQnt, decimal numPreReceiveQnt, decimal numRemainingQnt, decimal numReceiveqnt,string strRemarks,int intActionBy,DateTime dteActionTime,bool ysnActive)
        //{
        //    sprInsertGoodReceiveNoteTableAdapter adp = new sprInsertGoodReceiveNoteTableAdapter();
        //    string message = string.Empty;
        //    try
        //    {
        //        adp.InsertGoodReceiveNote(intItemId, strItemName, strDes, strUoM, numPoQnt, numPreReceiveQnt, numRemainingQnt, numReceiveqnt, strRemarks, intActionBy, dteActionTime, ysnActive, ref message);
        //        //msg = "SUPPLIER UPDATED SUCCESSFULLY..";
        //    }catch(Exception ex)
        //    {
        //        message = "Unknown Exception";
        //    }

        //    return message;
        //}
        public int? InsertFactoryGoodReceive(int poId, int supplierId, string challanNo, DateTime challanDate, string driverName, string driverContact, string vechicleNo, string meterialDescription, int unitId, int WHId, string shipmentSl, int actionBy, ref int? intGNId)
        {
            sprInsertFactoryGoodReceiveTableAdapter adp = new sprInsertFactoryGoodReceiveTableAdapter();

            try
            {
                adp.InsertFactoryGoodReceive(poId, supplierId, challanNo, challanDate, driverName, driverContact, vechicleNo, meterialDescription, unitId, WHId, shipmentSl, actionBy, ref intGNId);
            }
            catch (Exception ex)
            {
                intGNId = 0;
            }

            return intGNId;
        }

        public int? InsertFactoryGoodsReceiveDetail(int gnId, int itemId, int poId, decimal poQnt, decimal receiveQnt, string remarks, ref int? intId)
        {
            sprInsertFactoryGoodsReceiveDetailTableAdapter adp = new sprInsertFactoryGoodsReceiveDetailTableAdapter();

            try
            {
                adp.InsertFactoryGoodsReceiveDetail(gnId, itemId, poId, poQnt, receiveQnt, remarks, ref intId);
            }
            catch (Exception ex)
            {
                intId = 0;
            }

            return intId;
        }

        public bool UpdateFactoryGoodReceiveInActiveByGrnIdTableAdapter(int gnId)
        {
            sprUpdateFactoryGoodReceiveInActiveByGrnIdTableAdapter adp = new sprUpdateFactoryGoodReceiveInActiveByGrnIdTableAdapter();

            try
            {
                adp.UpdateFactoryGoodReceiveInActiveByGrnId(gnId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetEmpByEmpID(int intEmployeeID)
        {
            QRYEMPLOYEEPROFILEALLTableAdapter adp = new QRYEMPLOYEEPROFILEALLTableAdapter();
            return adp.GetEmpData(intEmployeeID);
        }

        public DataTable GetSupplierAddress(int supplierMasterID)
        {
            tblSupplierMasterTableAdapter adp = new tblSupplierMasterTableAdapter();
            return adp.GetSupplierOrgAddress(supplierMasterID);
        }

        public DataTable GetAllJobStationList()
        {
            tblEmployeeJobStationTableAdapter adp = new tblEmployeeJobStationTableAdapter();
            return adp.GetAllJobStation();
        }

        public DataTable FixedAssetData(string xml, int intType, string strJobStationName, int enroll)
        {
            SprFixedAuditTableAdapter adp = new SprFixedAuditTableAdapter();
            return adp.GetFixedAuditData(xml, intType, strJobStationName, enroll);
        }

        public DataTable InventorySearch(int intType, int intWHID, int ItemId)
        {
            sprInventorySearchNewTableAdapter adp = new sprInventorySearchNewTableAdapter();
            return adp.GetInventorySearchItem(intType, intWHID, ItemId);
        }

        public DataTable GetWH(int intEnroll)
        {
            TblWHTableAdapter adp = new TblWHTableAdapter();
            return adp.GetWHByEnroll(intEnroll);
        }

        public DataTable InventoryAdjustment(int unit, int wh, int user, int intItem, decimal rcvQty, decimal monRate, int location, string remarks)
        {
            sprInsertMrrItemDetailWithoutPOTableAdapter adp = new sprInsertMrrItemDetailWithoutPOTableAdapter();
            return adp.InventoryAdjustment(unit, wh, user, intItem, rcvQty, monRate, location, remarks);

            //sprInventoryAdjsutmentTableAdapter adp = new sprInventoryAdjsutmentTableAdapter();
            //return adp.GetData(1,0,unit, wh, user, intItem, rcvQty, monRate, location, remarks,0);
        }
        public DataTable InventoryAdjustmentApproval(int id, int unit, int wh, int user, int intItem, decimal rcvQty, decimal monRate, int location, string remarks, int prmission)
        {
            sprInventoryAdjsutmentTableAdapter adp = new sprInventoryAdjsutmentTableAdapter();
            return adp.GetData(2, id, unit, wh, user, intItem, rcvQty, monRate, location, remarks, prmission);
        }

        public DataTable FGReceive_Data(int whid, DateTime FromDate, DateTime ToDate, int intType, int autoID, int itemID, DateTime transactionDate, decimal transactionQTY, int productID)
        {
            try
            {
                sprFGReceiveTableAdapter adp = new sprFGReceiveTableAdapter();
                return adp.GetData(whid, FromDate, ToDate, intType, autoID, itemID, transactionDate,
                    transactionQTY, productID);
            }
            catch (Exception exception)
            {
                return new DataTable();
            }
            


        }

        public DataTable DistributionData(int whid, DateTime FromDate, DateTime ToDate, int type, int intTransferID)
        {
            sprDistributionReceiveTableAdapter adp = new sprDistributionReceiveTableAdapter();
            return adp.GetDistributionData(whid, FromDate, ToDate, type, intTransferID);
        }
        public DataTable InsertReceiveData(int unit, int intwh, int outWH, int location, int user, int item, decimal qty, decimal value, int vehicle, string remarks, int intReff, int intTransferType, bool ysnSalesEntry)
        {

            sprInventoryTransferTableAdapter adp = new sprInventoryTransferTableAdapter();
            try
            {
                return adp.InsertTransferData(unit, intwh, outWH, location, user, item, qty, value, vehicle, remarks, intReff, intTransferType, ysnSalesEntry);
            }
            catch
            {
                return new DataTable();
            }

        }

        public DataTable GetUnitByWH(int whid)
        {
            TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
            return adp.GetUnitByWhId(whid);
        }

        public DataTable InsertTransferData(int unit, int intWH, int outWH, int location, int user, int intSalesEntryID, int item, decimal qty, string remarks, int intItemTransferType, string strItemTransferType)
        {
            sprInventoryTransferSalesDetailTableAdapter adp = new sprInventoryTransferSalesDetailTableAdapter();
            return adp.InsertInventoryTransferSalesData(unit, intWH, outWH, location, user, intSalesEntryID, item, qty, remarks, intItemTransferType, strItemTransferType);
        }

        public DataTable GetTripEntry(string strChallanNo, int intUnitID, int intSalesOffId, int intShipPointId)
        {
            sprChallanWiseRouteCostTableAdapter adp = new sprChallanWiseRouteCostTableAdapter();
            return adp.TripEntry(strChallanNo, intUnitID, intSalesOffId, intShipPointId);
        }
        public DataTable GetFgCostUpdate(int type,DateTime dteDate,int enroll,string xml,int intItemId,int intUnitID,int CostElementGroup,int CoAID,decimal monRate)
        {
            try
            {
                sprFGCostUpdateTableAdapter adp = new sprFGCostUpdateTableAdapter();
                return adp.FgCostUpdate(type,dteDate,enroll,xml,intItemId,intUnitID,CostElementGroup,CoAID,monRate);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetFgCostGroup()
        {
            try
            {
                tblItemCostingFGCostGroupTableAdapter adp = new tblItemCostingFGCostGroupTableAdapter();
                return adp.GetCostGroup();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetItemByUnitID(int unitid)
        {
            try
            {
                tblItemTableAdapter adp = new tblItemTableAdapter();
                return adp.GetItemByUnit(unitid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


    }
}