using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SCM_DAL.TransferTDSTableAdapters;
using SCM_DAL;
using SCM_DAL.BomTDSTableAdapters;
using SCM_DAL.WestageTDSRPTTableAdapters;
using tblItemListTableAdapter = SCM_DAL.TransferTDSTableAdapters.tblItemListTableAdapter;

namespace SCM_BLL
{   
    public class TransferBLLNew
    {
        private static TransferTDS.tblItemDataTable[] tableItem = null;
        private static TransferTDS.tblItemListDataTable[] tableIteminv = null;
        int e;
        public DataTable Itemtype(int unitid)
        {
            try
            {
                tblItemTypeTableAdapter adp = new tblItemTypeTableAdapter();
                return adp.GetItemType(unitid);
            }
            catch { return new DataTable(); }
        }

        public string[] GetItemlist(int typeid,int unitid, string prefix)
        {
            int shipid = 16;
            tableItem = new TransferTDS.tblItemDataTable[Convert.ToInt32(shipid)];
            tblItemTableAdapter Vehicle = new tblItemTableAdapter();
            tableItem[e] = Vehicle.GetItemList(unitid,typeid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strproductname
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
                        var rows = from tmp in tableItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strproductname.ToLower().Contains(prefix)
                                   orderby tmp.strproductname
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
                    retStr[i] = tbl.Rows[i]["strproductname"] + "," + "[" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public DataTable getLocationListof(string whid)
        {
            tblWearHouseStoreLocation1TableAdapter adp = new tblWearHouseStoreLocation1TableAdapter();
            return adp.GetData(int.Parse(whid));
        }

        public DataTable getLocationList(string Whid)
        {
            
             try
            {
                tblWearHouseStoreLocationNewTableAdapter adp = new tblWearHouseStoreLocationNewTableAdapter();
                return adp.GetData(int.Parse(Whid));
            }
            catch { return new DataTable(); }
        }

        public DataTable getProductionItemList(int Productionid)
        {
            try
            {
                tblProductionItemListTableAdapter adpItemlist = new tblProductionItemListTableAdapter();
                return adpItemlist.GetProductionReceive(Productionid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getRpt(int intWHID, int intOutWHid, string text1, string text2, bool v)
        {
            throw new NotImplementedException();
        }

        public void ReceiveEntry(int autoid, int itemid, DateTime dtedate, decimal qty, int unitid, int intWHID, int intLocationid)
        {  
            try
            {
                tblInventoryTableAdapter adpIL = new tblInventoryTableAdapter();
                 adpIL.GetReceive(autoid, itemid, dtedate, qty, unitid, intWHID, intLocationid);
                
            }
            catch  {  }
        }

        public void ReceiveUpdate(decimal qty,int productionid, int itemid, int unitid)
        {
            try
            {
                tblInventoryTableAdapter adpIL = new tblInventoryTableAdapter();
                adpIL.GetReceiveUpdate(qty,productionid, itemid, unitid);

            }
            catch { }
        }

        public DataTable getRWH(int whid)
        {
            
           try
            {
                tblRptWHTableAdapter adpIL = new tblRptWHTableAdapter();
                return adpIL.GetRptWH(whid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getLocation(int itemid, int Whid)
        {
           try
            {
                sprItemLocationTableAdapter adpIL = new sprItemLocationTableAdapter();
                return adpIL.GetItemLocation(itemid, Whid);
            }catch { return new DataTable(); }
        }

        public DataTable getpermission(int enroll)
        {
            try
            {
                tblSavePermissionTableAdapter adpSave = new tblSavePermissionTableAdapter();
                return adpSave.GetData(enroll);
            }
            catch { return new DataTable(); }
        }

        public DataTable getTranfertype()
        {           
            try
            {
                tblItemTransferTypeTableAdapter TY = new tblItemTransferTypeTableAdapter();
                return TY.GetTransferType();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetTINItemlist(int itemid)
        {
            try {
                TransferITemTableAdapter adpTInItem = new TransferITemTableAdapter();
                return adpTInItem.GetTransferInITem(itemid);
            } catch { return new DataTable(); }
        }

        public DataTable getStockAlternative(int itemid)
        {
            try
            {
                tblItemStockTableAdapter TY = new tblItemStockTableAdapter();
                return TY.GetData(itemid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getWhbyuser(int Enroll)
        {
            try
            {
                tblWHListTableAdapter getAdp = new tblWHListTableAdapter();
               return getAdp.GetWHList(Enroll);

            }
            catch { return new DataTable(); }
        }

        public DataTable getIteminfo(int whid,int itemid,int? id)
        {
            
            try
            {
                sprGetItemListWithStockByWHTableAdapter adp = new sprGetItemListWithStockByWHTableAdapter();
                return adp.GetIteminfo(whid, itemid, id);
            }
            catch { return new DataTable(); }
        }

        public string GetSalesEntryDetils(int unitid, int intWHID, int intOutWHid, int intLocationid, int Enroll, int SalesId, int Pid, string qty,  string remarks,  int inttTransferTypeid, string strItemTransferType)
        {
            string msg = "";
            try
            {
                sprInventoryTransferSalesDetailTableAdapter adp = new sprInventoryTransferSalesDetailTableAdapter();
                 adp.GetSalesEntry(unitid, intWHID, intOutWHid, intLocationid, Enroll, SalesId, Pid,decimal.Parse(qty), remarks, inttTransferTypeid,strItemTransferType);
                msg = "Successfully";
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public string[] GetItemlistInv(int unitid, string prefix)
        {
            
            int shipid = 16;
            tableIteminv = new TransferTDS.tblItemListDataTable[Convert.ToInt32(shipid)];
            tblItemListTableAdapter itemlist = new tblItemListTableAdapter();
            tableIteminv[e] = itemlist.GetInvItemList(unitid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableIteminv[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.stritemname
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
                        var rows = from tmp in tableIteminv[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.stritemname.ToLower().Contains(prefix)
                                   orderby tmp.stritemname
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
                    retStr[i] = tbl.Rows[i]["stritemname"] + "," + "[" + tbl.Rows[i]["intitemid"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public void IssueDelete(int unitid, int intSalesId)
        {
            try
            {
                tblWMSalesTableAdapter adp = new tblWMSalesTableAdapter();
                adp.GetUpdate(unitid, intSalesId);
            }
            catch {  }
        }

        public DataTable GetTransferReceive(int unitid)
        {
            try
            {
                tblProductionDetailTableAdapter adpPLIst = new tblProductionDetailTableAdapter();
                return adpPLIst.GetProductionList(unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getShippontList(int unitid)
        {
            try
            {
               tblShippingPointTableAdapter adpshipAll = new tblShippingPointTableAdapter();
               return adpshipAll.GetShipList(unitid);
            }catch { return new DataTable(); }
        }

        public DataTable getToOffice(int Shipid)
        {
            try
            {
                tblSalesOfficeTableAdapter adp = new tblSalesOfficeTableAdapter();
                return adp.GetOfficeName(Shipid);
            }
            catch { return new DataTable(); }
        }

        public string getSavedata(int unitid, int intWHID, int intOutWHid, int intLocationid, int Enroll, int Pid, string Qty, decimal values, int intVid, string remarks, int intReff, int inttTransferTypeid,bool salesentry)
        {
            string msg = "";
            try
            {
                sprInventoryTransferTableAdapter adp = new sprInventoryTransferTableAdapter();
                 adp.GetSave(unitid, intWHID, intOutWHid, intLocationid, Enroll, Pid,decimal.Parse(Qty), values, intVid, remarks, intReff, inttTransferTypeid, salesentry);
                msg = "Successfully";
            }
            catch (Exception e){ msg = e.ToString(); }
            return msg;
        }

        public DataTable getUOMlist(int itemid)
        {
            try
            {
                tblUOM1TableAdapter adp = new tblUOM1TableAdapter();
                return adp.GetData(itemid);
            }
            catch { return new DataTable(); }
        }

        public string RemoteTransferEnrl(string xmlString, int unitid, string shipid, string offid, int enroll, string ToSHipid, string toOffid, int part)
        {
            string msg = "";
            try
            {
                sprTransferOrderEntryTableAdapter adp = new sprTransferOrderEntryTableAdapter();
                adp.InsertData(xmlString, unitid,int.Parse(shipid),int.Parse(offid), enroll,int.Parse(ToSHipid),int.Parse(toOffid),ref msg);
            }
            catch (Exception e){ msg = e.ToString();  }
            return msg;
        }

        public DataTable getALLWH()
        {
            try
            {
                tblAllWHTableAdapter adp = new tblAllWHTableAdapter();
                return adp.GetALLWH();
            }
            catch { return new DataTable(); }
        }

        public DataTable getTID(int intitemid)
        {
            try
            {
                tblInventoryTransferTableAdapter adpTID = new tblInventoryTransferTableAdapter();
                return adpTID.GetData(intitemid);

            }
            catch { return new DataTable(); }
        }



        public DataTable GetFromWH(int intEnroll)
        {
            try
            {
                GetFromWHTableAdapter adp = new GetFromWHTableAdapter();
                return adp.GetFromWH(intEnroll);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetToWH(int intEnroll)
        {
            try
            {
                GetToWHTableAdapter adp = new GetToWHTableAdapter();
                return adp.GetToWH(intEnroll);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetProductDataForTransfer(int intFromWHID, int intToWHID, string dteTransferDate)
        {
            try
            {
                GetProductDataForTransferTableAdapter adp = new GetProductDataForTransferTableAdapter();
                return adp.GetProductDataByWH(intFromWHID, intToWHID, dteTransferDate);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetMushakGa6Point5PrintData(int intFromVatAc, int intToVatAc, string strVehicle, DateTime dteTransferDate, int intUser, string xml)
        {
            try
            {
                SprPrintTransferChallanMushak6Point5TableAdapter adp = new SprPrintTransferChallanMushak6Point5TableAdapter();
                return adp.GetMushakGa6Point5PrintData(intFromVatAc, intToVatAc, strVehicle, dteTransferDate, intUser, xml);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetProductInfoForTransfer(int intTransferID)
        {
            try
            {
                GetProductInfoForTransferTableAdapter adp = new GetProductInfoForTransferTableAdapter();
                return adp.GetData(intTransferID);

            }
            catch { return new DataTable(); }
        }
        









    }
}
