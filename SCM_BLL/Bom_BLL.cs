using SCM_DAL;
using SCM_DAL.BomTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class Bom_BLL
    {
        private static BomTDS.qryItemListDataTable[] tableBomItem = null;
        int e;
        public DataTable GetBomData(int Type, string xmlData, int intwh, int bomId, DateTime dteDate, int enroll)
        {
            try
            {
                string msg = "";
                SprBuildOfMaterialTableAdapter adp = new SprBuildOfMaterialTableAdapter();
                return adp.GetBomData(Type, xmlData, intwh, bomId, dteDate, enroll,ref msg);
            }
            catch { return new DataTable(); }
        }

        public string[] AutoSearchBomId(string unit, string prefix)
        {

           tableBomItem = new BomTDS.qryItemListDataTable[Convert.ToInt32(unit)];
            qryItemListTableAdapter adpCOA = new qryItemListTableAdapter();
            tableBomItem[e] = adpCOA.GetItemSearchData(Convert.ToInt32(unit));


            // prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3 || prefix == "*")
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableBomItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.intItemID
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
                        var rows = from tmp in tableBomItem[e]
                                   where tmp.strItem.ToLower().Contains(prefix) || tmp.intItemID.ToString().ToLower().Contains(prefix)
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
                    retStr[i] = tbl.Rows[i]["strItem"] + "[ UOM:" + tbl.Rows[i]["strUoM"] + "]"+ "[" + tbl.Rows[i]["intItemID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }

        public DataTable getWorkstationParent(int intwh)
        {
            try
            {
                TblProcessWorkstationTableAdapter adp = new TblProcessWorkstationTableAdapter();
                return adp.GetWorkstationData(intwh);
            }
            catch {return new DataTable(); }
        }

        public string BomPostData(int type, string xmlString, int intWh, int bomid, DateTime dteDate, int enroll)
        { 
            string strMsg = "";
            try
            {
                SprBuildOfMaterialTableAdapter adp = new SprBuildOfMaterialTableAdapter();
                adp.GetBomData(type, xmlString, intWh, bomid, dteDate, enroll, ref strMsg);

            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;

        }

        public DataTable getChildData(int intwh, int parent)
        {
            try
            {
                TblProcessWorkstationTableAdapter adp = new TblProcessWorkstationTableAdapter();
                return adp.GetChildData(intwh, parent);
            }
            catch { return new DataTable(); }
        }

        public string GetRoutingData(int Type, string xmlMachine, string xmlAsset, int intWh, int Id, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprBillOfMaterialRoutingTableAdapter adp = new SprBillOfMaterialRoutingTableAdapter();
                adp.GetBomRoutingData(Type, xmlMachine, xmlAsset, intWh, Id, dteDate, enroll, ref strMsg);
            }
           
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public DataTable getBomRouting(int Type, string xmlMachine, string xmlAsset, int intWh, int Id, DateTime dteDate, int enroll)
        {
            try
            {
                string strMsg = "";
                SprBillOfMaterialRoutingTableAdapter adp = new SprBillOfMaterialRoutingTableAdapter();
               return adp.GetBomRoutingData(Type, xmlMachine, xmlAsset, intWh, Id, dteDate, enroll, ref strMsg);
            }
            catch { return new DataTable(); }
        }

       
    }
}
