﻿
using SCM_DAL;
using SCM_DAL.InventoryTransferTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCM_DAL.DmageTDSTableAdapters;

namespace SCM_BLL
{
    public class InventoryTransfer_BLL
    {
        private static InventoryTransferTDS.VehicleSearchDataTable[] tableVehicle = null;
        int e;
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
            catch (Exception ex) { return strMsg = ex.ToString(); }
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
                    if (rows.Count() > 0)
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
    }
}
