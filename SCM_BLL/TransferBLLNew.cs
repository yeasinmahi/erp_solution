using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SCM_DAL.TransferTDSTableAdapters;
using SCM_DAL;


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

        public DataTable getRpt(int intWHID, int intOutWHid, string text1, string text2, bool v)
        {
            throw new NotImplementedException();
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
            tblItemListTableAdapter Itemlist = new tblItemListTableAdapter();
            tableIteminv[e] = Itemlist.GetInvItemList(unitid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableIteminv[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.stritemname
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
    }
}
