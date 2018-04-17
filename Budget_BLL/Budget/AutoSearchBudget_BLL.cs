using Budget_DAL;
using Budget_DAL.BudgetOperationTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Budget_BLL.Budget
{
    public class AutoSearchBudget_BLL
    {
        private static BudgetOperationTDS.SprAutosearchRequesitionDataTable[] tableItemsName = null;
        private static BudgetOperationTDS.QryEmployeeProfileAllDataTable[] tableEmployee = null;
        private static BudgetOperationTDS.TblFixedAssetRegisterSearchDataTable[] tableAsset = null;
        
        int e;
        public string[] GetItemsNmaes(string WHID, string exixting, string prefix)
        {

            tableItemsName = new BudgetOperationTDS.SprAutosearchRequesitionDataTable[Convert.ToInt32(WHID)];
            SprAutosearchRequesitionTableAdapter adpCOA = new SprAutosearchRequesitionTableAdapter();
            tableItemsName[e] = adpCOA.ItemsAutoSearchGetData(Convert.ToInt32(WHID));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 && exixting=="1")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItemsName[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableItemsName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItem.ToLower().Contains(prefix) || Convert.ToString(tmp.intItem).ToLower().Contains(prefix)
                                   orderby tmp.strItem
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

                    retStr[i] = tbl.Rows[i]["strItem"] + "[" + tbl.Rows[i]["intItem"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public string[] GetEmployeeNames(string unit, string  exixting,string prefix)
        {
            tableEmployee = new BudgetOperationTDS.QryEmployeeProfileAllDataTable[Convert.ToInt32(unit)];
            QryEmployeeProfileAllTableAdapter adpCOA = new QryEmployeeProfileAllTableAdapter();
            tableEmployee[e] = adpCOA.AutosearchEmployeeGetData(Convert.ToInt32(unit));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 && exixting == "2")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmployee[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableEmployee[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || Convert.ToString(tmp.intEmployeeID).ToLower().Contains(prefix)
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public string[] GetToolsEquipments(string unit, string exixting,string prefix)
        {
            tableAsset= new BudgetOperationTDS.TblFixedAssetRegisterSearchDataTable[Convert.ToInt32(unit)];
            TblFixedAssetRegisterSearchTableAdapter adpCOA = new TblFixedAssetRegisterSearchTableAdapter();
            tableAsset[e] = adpCOA.AutoSearchAssetGetData(Convert.ToInt32(unit));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 && exixting == "3")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableAsset[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableAsset[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || Convert.ToString(tmp.strAssetID).ToLower().Contains(prefix)
                                   orderby tmp.strNameOfAsset
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

                    retStr[i] = tbl.Rows[i]["strNameOfAsset"] + "[" + tbl.Rows[i]["strAssetID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
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
