using Purchase_DAL.VehicleRegRenewal;
using Purchase_DAL.VehicleRegRenewal.VehicleRenewal_DALTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Purchase_BLL.VehicleRegRenewal_BLL
{
    public class AutoSearch_BLL
    {
        private static VehicleRenewal_DAL.AutoSearachDataTableDataTable[] tableCusts = null;
        int e;  
        public string[] AutoSearchVehicleNo(string prefix)
        {
            int intwh = Int32.Parse(1.ToString());
            //Inatialize(intwh);
            tableCusts = new VehicleRenewal_DAL.AutoSearachDataTableDataTable[Convert.ToInt32(intwh)]; 
            AutoSearachDataTableTableAdapter adpCOA = new AutoSearachDataTableTableAdapter();
            tableCusts[e] = adpCOA.AutoSearchVehicleGetData(Convert.ToBoolean(intwh));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >=3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableCusts[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix)
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

                        retStr[i] = tbl.Rows[i]["strNameOfAsset"]  + ";"  + tbl.Rows[i]["strAssetID"] ;

                        //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                    }

                    return retStr;

                }


                else
                {
                    return null;
                }
            

            
        }

        public string[] SearchVehicleAssetData(int Active, string prefix)
        {
            int intwh = Int32.Parse(1.ToString());
            //Inatialize(intwh);
            tableCusts = new VehicleRenewal_DAL.AutoSearachDataTableDataTable[Convert.ToInt32(intwh)];
            AutoSearachDataTableTableAdapter adpCOA = new AutoSearachDataTableTableAdapter();
            tableCusts[e] = adpCOA.AutoSearchVehicleGetData(Convert.ToBoolean(intwh));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableCusts[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix)
                                   && tmp.intAssetType==8
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
    }
}
