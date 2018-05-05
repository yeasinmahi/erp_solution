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
        int e;
        public DataTable GetPoData(int type, string xml, int intWh,int indentId, DateTime dteDate, int enroll)
        {
           
            try
            {
                string msg = "";
                SprPoGenerateTableAdapter adp = new SprPoGenerateTableAdapter();
                return adp.GetPoGenerateData(type, xml, intWh,indentId, dteDate, enroll, ref msg);
            }
            catch { return new DataTable(); }
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
            catch {return new DataTable();}
            
        }

        public  string[] AutoSearchPoUser( string prefix)
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
                    
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " " + "[" + tbl.Rows[i]["intEmployeeID"] +"]"; 
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

        public string[] AutoSearchMasterSupplier(string prefix,string strType)
        { 
            tblMasterSupplier = new PoGenerateTDS.TblSupplierMasterDataTable[Convert.ToInt32(1)];
            TblSupplierMasterTableAdapter adpCOA = new TblSupplierMasterTableAdapter();
            tblMasterSupplier[e] = adpCOA.GetMasterSupplierData(strType);

            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblMasterSupplier[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strSuppMasterName
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

                    retStr[i] = tbl.Rows[i]["strSuppMasterName"] + " " + "[" + tbl.Rows[i]["intSuppMasterID"] + "]";
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
            tblSupplier = new PoGenerateTDS.TblSupplierDataTable[Convert.ToInt32(1)];
            TblSupplierTableAdapter adpCOA = new TblSupplierTableAdapter();
            tblSupplier[e] = adpCOA.GetSupplierData(int.Parse(unit),strType);

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
    }
}
