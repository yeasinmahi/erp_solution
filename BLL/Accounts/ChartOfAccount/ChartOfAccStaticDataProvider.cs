using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.ChartOfAccount;
using System.Collections;
using System.Data;
using DAL.Accounts.ChartOfAccount.ChartOfAccTDSTableAdapters;
using HR_BLL.Global;
using HR_DAL.Global;

namespace BLL.Accounts.ChartOfAccount
{
    public static class ChartOfAccStaticDataProvider
    {
        private static ChartOfAccTDS.TblAccountsChartOfAccDataTable[] tableCOAs = null;
        private static Hashtable ht = new Hashtable();
        
        public static void Inatialize()
        {
          
            if (tableCOAs == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableCOAs = new ChartOfAccTDS.TblAccountsChartOfAccDataTable[tblUnit.Rows.Count];
                TblAccountsChartOfAccTableAdapter adpCOA = new TblAccountsChartOfAccTableAdapter();
                               

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableCOAs[i] = adpCOA.GetDataByUnitID(tblUnit[i].intUnitID);                    
                }
            }
        }
        public static IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> GetDataByUnitAndParentID(string unitID, int parentID)
        {
           
            Inatialize();
            IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
            where tmp.intParentID == parentID
            select tmp;
            return rows;

        }        
        public static string[] GetCOADataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
          DataTable tbl=new DataTable();
            prefix = prefix.ToLower(); 

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.ysnEnable == true && tmp.ysnHasChild == false
                           orderby tmp.strAccName
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
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable == true && tmp.ysnHasChild == false 
                              && tmp.intModulesAutoID != "1"// All Bank Info
                             //  && (tmp.IsintAccTemplateIDNull()?true:(tmp.intAccTemplateID != 19))// Cash In Hand
                               && tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strAccName
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
                    retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["strCode"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public static string[] GetCOADataForAutoFillByParent(string unitID,string parentId, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            prefix = prefix.ToLower();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.ysnEnable == true && tmp.ysnHasChild == false && tmp.intParentID == int.Parse(parentId)
                           orderby tmp.strAccName
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
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable == true 
                               && tmp.ysnHasChild == false 
                               && tmp.intParentID == int.Parse(parentId)
                               && tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strAccName
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
                    retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["strCode"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public static string[] GetCOADataForAutoFillWithoutCode(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.ysnEnable == true && tmp.ysnHasChild == false
                           orderby tmp.strAccName
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
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable == true && tmp.ysnHasChild == false
                               && tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strAccName
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
                    retStr[i] = tbl.Rows[i]["strAccName"].ToString();
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }        
        public static string[] GetCOAInsertSugessionDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl;

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                           where tmp.ysnEnable == true
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            else
            {
                try
                {
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               && tmp.ysnEnable == true
                               select tmp;
                    tbl = rows.CopyToDataTable();
                }
                catch
                {
                    return null;
                }
            }

            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strAccName"].ToString();
            }

            return retStr;
        }
        public static string[] GetCOALedgerDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl;

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                           where tmp.ysnEnable == true
                           && tmp.ysnLedger == true
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            else
            {
                try
                {
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               && tmp.ysnEnable == true
                               && tmp.ysnLedger == true
                               select tmp;
                    tbl = rows.CopyToDataTable();
                }
                catch
                {
                    return null;
                }
            }

            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strAccName"]  + " [" + tbl.Rows[i]["strCode"] + "]";
            }

            return retStr;
        }
        public static string[] GetCOAControlLedgerDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl;

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                           where tmp.ysnEnable == true
                           && tmp.ysnLedger == false
                           && tmp.ysnHasChild == true
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            else
            {
                try
                {
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               && tmp.ysnEnable == true
                               && tmp.ysnLedger == false
                               && tmp.ysnHasChild == true
                               select tmp;
                    tbl = rows.CopyToDataTable();
                }
                catch
                {
                    return null;
                }
            }

            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["strCode"] + "]";
            }

            return retStr;
        }
        public static string[] GetCOASubLedgerDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl;

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                           where tmp.ysnEnable == true
                           && tmp.ysnLedger == false
                           && tmp.ysnHasChild == false
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            else
            {
                try
                {
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               && tmp.ysnEnable == true
                               && tmp.ysnLedger == false
                               && tmp.ysnHasChild == false
                               select tmp;
                    tbl = rows.CopyToDataTable();
                }
                catch
                {
                    return null;
                }
            }

            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["strCode"] + "]";
            }

            return retStr;
        }        
        public static ChartOfAccTDS.TblAccountsChartOfAccRow GetCOA_ID_ByCode(string unitID, string code)
        {
            Inatialize();

            var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                       where tmp.strCode == code
                       select tmp;

            foreach (ChartOfAccTDS.TblAccountsChartOfAccRow row in rows)
            {
                return row;
            }

            return null;
        }
        public static ChartOfAccTDS.TblAccountsChartOfAccRow GetCOA_ID_ByID(string unitID, string id)
        {
            Inatialize();

            var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                       where tmp.intAccID == int.Parse(id)
                       select tmp;

            foreach (ChartOfAccTDS.TblAccountsChartOfAccRow row in rows)
            {
                return row;
            }

            return null;
        }
        public static void ReloadCOA(string unitID)
        {
            Inatialize();
            TblAccountsChartOfAccTableAdapter adpCOA = new TblAccountsChartOfAccTableAdapter();
            tableCOAs[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnitID(int.Parse(unitID));
        }
        public static IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> GetDataByParentID(string unitID, int parentID)
        {
            Inatialize();
            IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])].AsEnumerable()
                                                                       where tmp.intParentID == parentID
                                                                       select tmp;
            return rows;
        }

        //For Payment Register JV create by said
        public static string[] GetCOADataForAutoFillPaymentRegister(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            prefix = prefix.ToLower();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.ysnEnable == true && tmp.ysnHasChild == false
                           orderby tmp.strAccName
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
                    var rows = from tmp in tableCOAs[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable == true && tmp.ysnHasChild == false
                              && tmp.intModulesAutoID != "1"// All Bank Info
                                                            //  && (tmp.IsintAccTemplateIDNull()?true:(tmp.intAccTemplateID != 19))// Cash In Hand
                               && tmp.strAccName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strAccName
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
                    retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["strCode"] + "]"+ " [" + tbl.Rows[i]["intAccID"] + "]" ;
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
