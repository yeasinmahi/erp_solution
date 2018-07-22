
using Purchase_DAL.Asset;
using Purchase_DAL.Asset.AssetMaintenanceTDSTableAdapters;
using Purchase_DAL.Asset.SearchTDSTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Purchase_BLL.Asset
{
    public class AutoSearch_BLL
    {
        private static SearchTDS.SprAutosearchRequesitionDataTable[] tableCusts = null;
        private static SearchTDS.SprAutosearchRequesitionDataTable[] tableItem = null;

        private static SearchTDS.TblAutoSearchAssetRegisterDataTable[] tableCusts1 = null;
        private static SearchTDS.TblVehicleAutoSearchAssetRegisterDataTable[] tableCusts2 = null;
        private static SearchTDS.TblFixedAssetCOADataTable[] tblFixedAssetCoa= null;
        private static SearchTDS.TblAcountsChartOfACCDataTable[] tblAccountsChartOfAcc = null;
        private static SearchTDS.QRYEMPLOYEEPROFILEALLDataTable[] tableEmpList = null;
     
        private static Hashtable ht = new Hashtable();
        int e;
        public List<string> AutoSearchEmployee(string strSearchKeyemp,int intjobid)
        {
            List<string> result = new List<string>();
            DataTable1TableAdapter employeelist= new DataTable1TableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = employeelist.EmployeeSearchGetDataBy(strSearchKeyemp, intjobid);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strItemName"].ToString());
                }

            }
            return result;
        }

        public string[] GetEmployeeLists(Boolean active, string prefix)
        {
            tableEmpList = new SearchTDS.QRYEMPLOYEEPROFILEALLDataTable[Convert.ToInt32(active)];
            QRYEMPLOYEEPROFILEALLTableAdapter emplists = new QRYEMPLOYEEPROFILEALLTableAdapter();
            tableEmpList[e] = emplists.GetEmployeeData(Convert.ToBoolean(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmpList[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strOfficeEmail
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
                        var rows = from tmp in tableEmpList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strOfficeEmail.ToLower().Contains(prefix)|| tmp.strEmployeeName.ToLower().Contains(prefix) ||
                                   tmp.intEmployeeID.ToString().ToLower().Contains(prefix)
                                   orderby tmp.strOfficeEmail
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

                    retStr[i] =  tbl.Rows[i]["strEmployeeName"] + "," + tbl.Rows[i]["strDesignation"] + "," + tbl.Rows[i]["strDepatrment"] + "," + tbl.Rows[i]["strJobStationName"]+ tbl.Rows[i]["strOfficeEmail"] + ","  + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public List<string> AutoSearchCorporateEmployee(string strSearchKeyemp)
        {
            List<string> result2 = new List<string>();
            DataTable1TableAdapter Corpemployeelist = new DataTable1TableAdapter();
            DataTable oDT3 = new DataTable();
            oDT3 = Corpemployeelist.CorporateemployeeGetDataBy(strSearchKeyemp);
            if (oDT3.Rows.Count > 0)
            {
                for (int index = 0; index < oDT3.Rows.Count; index++)
                {
                    result2.Add(oDT3.Rows[index]["strItemName"].ToString());
                }

            }
            return result2;
        }
        public List<string> AutoSearchAssetrToolsAndEquipment(string strSearchTextTools)
        {
            List<string> result = new List<string>();
            DataTable1TableAdapter ToolsandEqipment = new DataTable1TableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = ToolsandEqipment.AutosearchTollsEquipmentGetData(strSearchTextTools);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strItemName"].ToString());
                }

            }
            return result;
        }
        public List<string> AutoSearchIndentServiceList(int Uid, string strSearchKeyItem)
        {
            List<string> result = new List<string>();
            DataTable1TableAdapter ServiceIndent = new DataTable1TableAdapter();
            DataTable oDT = new DataTable();
            oDT = ServiceIndent.IndentServiceListGetData(Uid, strSearchKeyItem);
            
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strItemName"].ToString());
                }

                
            }
            return result;
        }
        public List<string> AutoSearchCorporateVendor(string strSearchKeyVendor)
        {
            List<string> result = new List<string>();
            DataTable1TableAdapter corporateVendor = new DataTable1TableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = corporateVendor.CorporateVendorGetData(strSearchKeyVendor);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strItemName"].ToString());
                }

            }
            return result;
        }
        public List<string> AutoSearchFactoryVendor(string strSearchKeyVendor, int intjobid)
        {
            List<string> result = new List<string>();
            DataTable1TableAdapter factoryVendor = new DataTable1TableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = factoryVendor.FactoryVendorGetData(strSearchKeyVendor, intjobid);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strItemName"].ToString());
                }

            }
            return result;
        }
        private static void Inatialize(int intwh)
        {
          
            if (tableItem == null)
            {                
                WearHouseID unt = new WearHouseID();
                SearchTDS.TblWearHouseDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();
                tableItem = new SearchTDS.SprAutosearchRequesitionDataTable[tblUnit.Rows.Count];
                SprAutosearchRequesitionTableAdapter adpCOA = new SprAutosearchRequesitionTableAdapter();
                
                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                   
                    int untid = tblUnit[i].intWHID;
                    {
                        ht.Add(tblUnit[i].intWHID.ToString(), i);
                        tableItem[i] = adpCOA.AutosearchGetData(tblUnit[i].intWHID);
                    }
                }
            }
        }
        public string[] AutoSearchWHIDParts(string WHID, string prefix)
        {
            int intwh = Int32.Parse(WHID.ToString());
            // Inatialize(intwh);
            tableCusts = new SearchTDS.SprAutosearchRequesitionDataTable[Convert.ToInt32(WHID)];
            SprAutosearchRequesitionTableAdapter adpCOA = new SprAutosearchRequesitionTableAdapter();
            tableCusts[e] = adpCOA.AutosearchGetData(Convert.ToInt32(WHID));


            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strItem
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
                        var rows = from tmp in tableCusts[e]
                                   where tmp.strItem.ToLower().Contains(prefix) || tmp.ItemNumber.ToLower().Contains(prefix)
                                   orderby tmp.strItem
                                   select tmp;

                        //where tmp.intCusType.ToString() == type,.ToLower().StartsWith
                        //       && tmp.intSalesOffId.ToString() == salesOffice
                        //       && tmp.strName.ToLower().Contains(prefix)
                        //var rows2 = from tmp in tableCusts[Convert.ToInt32(ht[WHID])]
                        //            where tmp.ItemNumber.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                        //            orderby tmp.ItemNumber
                        //            select tmp;
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
                    retStr[i] = tbl.Rows[i]["strItem"] + "[" + "Stock" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" + ";" + tbl.Rows[i]["intItem"];
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }

        public static string[] AutoSearchLocationItem(string WHID, string prefix)
       {
           
             Inatialize(int.Parse(WHID));
            //tableItem = new SearchTDS.SprAutosearchRequesitionDataTable[Convert.ToInt32(WHID)];
            //SprAutosearchRequesitionTableAdapter adpCOA = new SprAutosearchRequesitionTableAdapter();
            //tableItem[e] = adpCOA.AutosearchGetData(Convert.ToInt32(WHID));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItem[Convert.ToInt32(ht[WHID])]                         
                               orderby tmp.strItem
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
                        var rows = from tmp in tableItem[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItem.ToLower().Contains(prefix) || tmp.ItemNumber.ToLower().Contains(prefix)
                                   orderby tmp.strItem
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
                    //retStr[i] = tbl.Rows[i]["strItem"] + "[" + "Stock" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" + "[" + tbl.Rows[i]["intItem"]+"]";
                    retStr[i] = tbl.Rows[i]["strItem"] + "[" + tbl.Rows[i]["intItem"] + "]" + "[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }


        public string[] AutoSearchFixedAssetCoa(string unit, string prefix)
        {

            tblFixedAssetCoa = new SearchTDS.TblFixedAssetCOADataTable[Convert.ToInt32(unit)];
            TblFixedAssetCOATableAdapter adpCOA = new TblFixedAssetCOATableAdapter();
            tblFixedAssetCoa[e] = adpCOA.GetAssetCOAData(Convert.ToInt32(unit));


            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 || prefix=="*")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblFixedAssetCoa[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.intGlobalCOA
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
                        var rows = from tmp in tblFixedAssetCoa[e]
                                   where tmp.strCode.ToLower().Contains(prefix) || tmp.strAccName.ToLower().Contains(prefix)
                                   orderby tmp.intGlobalCOA
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
                    retStr[i] = tbl.Rows[i]["strAccName"] + "[" + tbl.Rows[i]["strCode"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }



        public string[] AutoSearchAccountsChartOfACC(string unit, string prefix)
        {

            tblAccountsChartOfAcc = new SearchTDS.TblAcountsChartOfACCDataTable[Convert.ToInt32(unit)];
            TblAcountsChartOfACCTableAdapter adpCOA = new TblAcountsChartOfACCTableAdapter();
            tblAccountsChartOfAcc[e] = adpCOA.GetAccountsCartAccData(Convert.ToInt32(unit));


           // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblAccountsChartOfAcc[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.intAccID
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
                        var rows = from tmp in tblAccountsChartOfAcc[e]
                                   where tmp.strCode.ToLower().Contains(prefix) || tmp.strAccName.ToLower().Contains(prefix)
                                   orderby tmp.intAccID
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
                    retStr[i] =tbl.Rows[i]["strAccName"] + "[" + tbl.Rows[i]["strCode"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }

        public string[] GetAssetItem(Int32 Active, string prefix)
        {

            //Inatialize(intwh);
            if (tableCusts1 == null)
            {
                tableCusts1 = new SearchTDS.TblAutoSearchAssetRegisterDataTable[Convert.ToInt32(Active)];
                TblAutoSearchAssetRegisterTableAdapter adpCOA = new TblAutoSearchAssetRegisterTableAdapter();
                tableCusts1[e] = adpCOA.AssetAutoSearchGetData(Convert.ToBoolean(Active));
            }
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts1[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strNameOfAsset
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
                        var rows = from tmp in tableCusts1[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix)
                                   orderby tmp.intID
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
                    retStr[i] = tbl.Rows[i]["strNameOfAsset"] + "[" + tbl.Rows[i]["strAssetID"] + "]" + "[" + tbl.Rows[i]["intID"] + "]" + "[" + tbl.Rows[i]["intAssetType"] + "]";

                 //   retStr[i] = tbl.Rows[i]["strNameOfAsset"]+","+ tbl.Rows[i]["intAssetType"] + ";" + tbl.Rows[i]["strAssetID"] ;

                 }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public string[] GetAssetVehicle(int type, string prefix)
        {
            tableCusts2 = new SearchTDS.TblVehicleAutoSearchAssetRegisterDataTable[Convert.ToInt32(type)];
            TblVehicleAutoSearchAssetRegisterTableAdapter adpCOA = new TblVehicleAutoSearchAssetRegisterTableAdapter();
            tableCusts2[e] = adpCOA.VehicleAutoSearchGetData(Convert.ToInt32(type));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts2[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strNameOfAsset
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
                        var rows = from tmp in tableCusts2[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix)
                                   orderby tmp.strAssetID
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

                    retStr[i] = tbl.Rows[i]["strNameOfAsset"] + ";" + tbl.Rows[i]["strAssetID"];

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }


        public string[] GetAssetItemByUnit(string unit, string prefix)
        {

            
           
                tableCusts1 = new SearchTDS.TblAutoSearchAssetRegisterDataTable[Convert.ToInt32(1)];
                TblAutoSearchAssetRegisterTableAdapter adpCOA = new TblAutoSearchAssetRegisterTableAdapter();
                tableCusts1[e] = adpCOA.GetAssetUnitByData(Convert.ToInt32(unit));
           
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts1[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strNameOfAsset
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
                        var rows = from tmp in tableCusts1[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix)
                                   orderby tmp.intID
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
                    retStr[i] = tbl.Rows[i]["strNameOfAsset"] + "[" + tbl.Rows[i]["strAssetID"] + "]" + "[" + tbl.Rows[i]["intID"] + "]";
         
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
