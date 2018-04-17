using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DAL.Accounts.Voucher;
using HR_BLL.Global;
using HR_DAL.Global;
using DAL.Accounts.Voucher.BankContraChqBearerTDSTableAdapters;
using System.Data;

namespace BLL.Accounts.Voucher
{
    public static class BankContraChqBearerST
    {
        private static BankContraChqBearerTDS.QryChequeBearerDataTable[] tableCusts = null;
        private static Hashtable ht = new Hashtable();

        private static void Inatialize()
        {
            if (tableCusts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableCusts = new BankContraChqBearerTDS.QryChequeBearerDataTable[tblUnit.Rows.Count];
                QryChequeBearerTableAdapter adpCOA = new QryChequeBearerTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableCusts[i] = adpCOA.GetData(tblUnit[i].intUnitID);
                }
            }
        }

        public static string[] GetCustomerDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "*")
            {
                var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strChqBearer
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
                    var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]
                               where tmp.strChqBearer.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strChqBearer
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
                    retStr[i] = tbl.Rows[i]["strChqBearer"].ToString();
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static bool HasThisInName(string unitID, string name)
        {
            Inatialize();
            var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]
                       where tmp.strChqBearer.ToLower() == name.ToLower()//, true, System.Globalization.CultureInfo.CurrentUICulture)
                       orderby tmp.strChqBearer
                       select tmp;
            if (rows.Count() > 0) return true;
            else return false;
        }        
        public static void ReloadCustomer(string unitID)
        {
            Inatialize();
            QryChequeBearerTableAdapter adpCOA = new QryChequeBearerTableAdapter();
            tableCusts[Convert.ToInt32(ht[unitID])] = adpCOA.GetData(int.Parse(unitID));
        }
    }
}
