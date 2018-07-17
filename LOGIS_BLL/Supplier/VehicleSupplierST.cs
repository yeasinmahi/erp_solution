using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LOGIS_DAL.Supplier;
using HR_BLL.Global;
using HR_DAL.Global;
using LOGIS_DAL.Supplier.VehicleSupplierTDSTableAdapters;
using System.Data;

namespace LOGIS_BLL.Supplier
{
    public class VehicleSupplierST
    {
        private static VehicleSupplierTDS.TblVehicleSupplierDataTable[] tableVehicle = null;
        private static VehicleSupplierTDS.TblAllStandVehicleDataTable[] tblAllStandVheicle = null;
        private static VehicleSupplierTDS.TblStandVheicleDriverlistDataTable[] tblAllStandVheicleDriverList = null;
        private static Hashtable ht = new Hashtable();
        private static Hashtable htallstandvhc = new Hashtable();
        private static Hashtable htallstandvhcDriverList = new Hashtable();
        private static void Inatialize()
        {
            if (tableVehicle == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableVehicle = new VehicleSupplierTDS.TblVehicleSupplierDataTable[tblUnit.Rows.Count];
                TblVehicleSupplierTableAdapter adpCOA = new TblVehicleSupplierTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {

                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableVehicle[i] = adpCOA.GetDataByUnit(tblUnit[i].intUnitID, true);
                }
            }
        }


        private static void InatializeAllstandvhecicle()
        {
            if (tblAllStandVheicle == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                htallstandvhc = new Hashtable();

                tblAllStandVheicle = new VehicleSupplierTDS.TblAllStandVehicleDataTable[tblUnit.Rows.Count];
                TblAllStandVehicleTableAdapter adpCOAAllStandVhc = new TblAllStandVehicleTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {

                    htallstandvhc.Add(tblUnit[i].intUnitID.ToString(), i);
                    tblAllStandVheicle[i] = adpCOAAllStandVhc.GetDataAllStandVehicle();
                }
            }
        }


        private static void InatializeAllstandvhecicleDriverListName()
        {
            if (tblAllStandVheicleDriverList == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                htallstandvhcDriverList = new Hashtable();

                tblAllStandVheicleDriverList = new VehicleSupplierTDS.TblStandVheicleDriverlistDataTable[tblUnit.Rows.Count];
                TblStandVheicleDriverlistTableAdapter adpCOAAllStandVhc = new TblStandVheicleDriverlistTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {

                    htallstandvhcDriverList.Add(tblUnit[i].intUnitID.ToString(), i);
                    tblAllStandVheicleDriverList[i] = adpCOAAllStandVhc.GetDatadrvlist();
                }
            }
        }






        public static string[] GetSupplierDataForAutoFillAll(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                           orderby tmp.strName
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
                    var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable == true
                               && tmp.strName.ToLower().Contains(prefix)
                               orderby tmp.strName
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] =  tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }



        public static string[] GetAllStandVheicleDataForAutoFillAll(string unitID, string prefix)
        {
            InatializeAllstandvhecicle();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblAllStandVheicle[Convert.ToInt32(ht[unitID])]
                           orderby tmp.strVehicleNo
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
                    var rows = from tmp in tblAllStandVheicle[Convert.ToInt32(ht[unitID])]
                               //where tmp.== true
                               where tmp.strVehicleNo.ToLower().Contains(prefix)
                               orderby tmp.strVehicleNo
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strVehicleNo"] + " [" + tbl.Rows[i]["intVehicleID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }



        public static string[] GetAllStandVheicleDriverNameListDataForAutoFillAll(string unitID, string prefix)
        {
            InatializeAllstandvhecicleDriverListName();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblAllStandVheicleDriverList[Convert.ToInt32(ht[unitID])]
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
                    var rows = from tmp in tblAllStandVheicleDriverList[Convert.ToInt32(ht[unitID])]
                               //where tmp.== true
                               where tmp.strEmployeeName.ToLower().Contains(prefix)
                               orderby tmp.strEmployeeName
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["strEmployeeCode"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }







        public static void ReloadVehicle(string unitID)
        {
            Inatialize();

            TblVehicleSupplierTableAdapter adpCOA = new TblVehicleSupplierTableAdapter();
            tableVehicle[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnit(int.Parse(unitID), true);
        }


        public List<string> AutoSearchStandVhclList(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprStandByVheicleSearchingTableAdapter obj = new SprStandByVheicleSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = obj.GetDataStandByVheicleSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strVehicleNo"].ToString());
                }

            }
            return result;
        }

        public List<string> AutoSearchStandVhclDriverList(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprStandByVheicleDriverSearchingTableAdapter obj = new SprStandByVheicleDriverSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = obj.GetDataStandByVheicleDriverSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strEmployeeName"].ToString());
                }

            }
            return result;
        }


    }
}
