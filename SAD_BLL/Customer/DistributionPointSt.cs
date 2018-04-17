using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer;
using System.Collections;
using HR_BLL.Global;
using HR_DAL.Global;
using SAD_DAL.Customer.DistributionPointTDSTableAdapters;
using System.Data;

namespace SAD_BLL.Customer
{
    public static class DistributionPointSt
    {
        private static DistributionPointTDS.QryDisPointSTDataTable[] tableCusts = null;
        private static Hashtable ht = new Hashtable();

        private static void Inatialize()
        {
            if (tableCusts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableCusts = new DistributionPointTDS.QryDisPointSTDataTable[tblUnit.Rows.Count];
                QryDisPointSTTableAdapter adpCOA = new QryDisPointSTTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableCusts[i] = adpCOA.GetDataByUnit(tblUnit[i].intUnitID, true);
                }
            }
        }

        public static string[] GetDataForAutoFill(string unitID, string prefix, string type)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.IsintCusTypeNull() || (tmp.IsintCusTypeNull() ? "" : tmp.intCusType.ToString()) == ("" + type)
                           orderby tmp.strDisPointName
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
                               where tmp.IsintCusTypeNull() || (tmp.IsintCusTypeNull() ? "" : tmp.intCusType.ToString()) == ("" + type)
                               &&
                               (
                               tmp.strDisPointName.ToLower().Contains(prefix)
                               ||
                               tmp.intDisPointId.ToString().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentCulture)
                               )
                               orderby tmp.strDisPointName
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
                    retStr[i] = "\"" + tbl.Rows[i]["strDisPointName"] + " [" + tbl.Rows[i]["intDisPointId"] + "]" + "\"";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetDataForAutoFill(string unitID, string prefix, string salesOfficeId, string cusType)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.IsintCusTypeNull() || (tmp.IsintCusTypeNull() ? "" : tmp.intCusType.ToString()) == ("" + cusType)
                           && tmp.intSalesOffId.ToString() == salesOfficeId
                           && tmp.ysnEnable
                           orderby tmp.strDisPointName
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
                               where tmp.IsintCusTypeNull() || (tmp.IsintCusTypeNull() ? "" : tmp.intCusType.ToString()) == ("" + cusType)
                               && tmp.intSalesOffId.ToString() == salesOfficeId
                               &&
                               (
                               tmp.strDisPointName.ToLower().Contains(prefix)
                               ||
                               tmp.intDisPointId.ToString().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentCulture)
                               )
                               && tmp.ysnEnable
                               orderby tmp.strDisPointName
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
                    //retStr[i] = "\"" + tbl.Rows[i]["strDisPointName"] + " [" + tbl.Rows[i]["intDisPointId"] + "]" + "\"";

                    retStr[i] =  tbl.Rows[i]["strDisPointName"] + " [" + tbl.Rows[i]["intDisPointId"] + "]" ;

                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public static string[] GetDataForAutoFillRemote(string email, string prefix, string salesOffice, string type)
        {
            QryDisPointSTTableAdapter adp=new QryDisPointSTTableAdapter();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            tbl = adp.GetDisPointDataByRmtUser(email, int.Parse(salesOffice), int.Parse(type), prefix);
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strDisPointName"] + " [" + tbl.Rows[i]["intDisPointId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public static void Reload(string unitID)
        {
            Inatialize();
            QryDisPointSTTableAdapter adpCOA = new QryDisPointSTTableAdapter();
            tableCusts[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnit(int.Parse(unitID), true);
        }

    }
}
