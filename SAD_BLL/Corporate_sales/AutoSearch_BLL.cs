using SAD_DAL.Corporate_sales;
using SAD_DAL.Corporate_sales.OrderInput_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAD_BLL.Corporate_Sales
{
    
    public class AutoSearch_BLL
    {
        private static OrderInput_TDS.TblCustomerSearchDataTable[] tableCustsName = null;
        private static OrderInput_TDS.TblAFBLCorporateSalesProductSearchDataTable[] tableProductName = null;
        int e;
        public string[] GetCustname(string unit, string prefix)
        {
            int strUnit = Int32.Parse(unit.ToString());
            //Inatialize(intwh);
            tableCustsName = new OrderInput_TDS.TblCustomerSearchDataTable[Convert.ToInt32(unit)];
            TblCustomerSearchTableAdapter adpCOA = new TblCustomerSearchTableAdapter();
            tableCustsName[e] = adpCOA.SearchCustomerNameGetData(Convert.ToInt32(unit));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCustsName[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableCustsName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strName.ToLower().Contains(prefix) || Convert.ToString(tmp.intCusID).ToLower().Contains(prefix)
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strName"] + "[" + tbl.Rows[i]["intCusID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public string[] GetProductName(string p, string prefix)
        {
            int active = Int32.Parse(1.ToString());
            //Inatialize(intwh);
            tableProductName = new OrderInput_TDS.TblAFBLCorporateSalesProductSearchDataTable[Convert.ToInt32(active)];
            TblAFBLCorporateSalesProductSearchTableAdapter adpCOA = new TblAFBLCorporateSalesProductSearchTableAdapter();
            tableProductName[e] = adpCOA.SearchProductNameGetData(Convert.ToInt32(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >=1)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableProductName[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strProductName
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
                        var rows = from tmp in tableProductName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strProductName.ToLower().Contains(prefix) || Convert.ToString(tmp.intProductId).ToLower().Contains(prefix)
                                   orderby tmp.strProductName
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

                    retStr[i] = tbl.Rows[i]["strProductName"]+ "[" + tbl.Rows[i]["intProductId"] + "]";

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

