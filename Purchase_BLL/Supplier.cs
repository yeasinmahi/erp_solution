using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL;
using Purchase_DAL.SupplierTDSTableAdapters;
using System.Collections;
using HR_BLL.Global;
using HR_DAL.Global;
using System.Data;

namespace Purchase_BLL
{
    public class Supplier
    {

        public static SupplierTDS.QrySupplierDataTable[] supplierStaticTable = null;
        private static Hashtable ht = new Hashtable();

        public void AddUpdate(ref string supplierId, string unitId, string type, string businessCat
            , string name, string country, string state, string city, string addr
            , string contact, string web, string fax, string email1, string email2
            , string owner, string ownerContact, string currency, string paymentMode
            , string trade, string vat, string bank, string branch, string accName, string accNo
            , DateTime date, string aggrements, string photoUrl, string signUrl, string userId)
        {
            int? id = null;
            try { id = int.Parse(supplierId); }
            catch { }
            SprSupplierAddUpdateTableAdapter ta = new SprSupplierAddUpdateTableAdapter();
            ta.GetData(ref id, int.Parse(unitId), int.Parse(type), int.Parse(businessCat), name, country, state
                , city, addr, contact, web, fax, email1, email2, owner, ownerContact, int.Parse(currency), int.Parse(paymentMode)
                , trade, vat, bank, branch, accName, accNo, date, aggrements, int.Parse(userId), photoUrl, signUrl);

            supplierId = id.ToString();
        }

        public SupplierTDS.QrySupplierDataTable GetDataByUnit(string unitId, bool isEnable)
        {
            QrySupplierTableAdapter ta = new QrySupplierTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitId), isEnable);
        }

        public SupplierTDS.QrySupplierDataTable GetDataById(string id)
        {
            QrySupplierTableAdapter ta = new QrySupplierTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }

        public void DisableEnable(string id, string userId)
        {
            QrySupplierTableAdapter ta = new QrySupplierTableAdapter();
            ta.DisableEnableById(int.Parse(userId), int.Parse(id));
        }

        public SupplierTDS.TblSupplierBusinessCatDataTable GetBusinessCat(string unitId)
        {
            TblSupplierBusinessCatTableAdapter ta = new TblSupplierBusinessCatTableAdapter();
            return ta.GetData(int.Parse(unitId));
        }

        public SupplierTDS.TblSupplierPaymentModeDataTable GetPaymentMode(string unitId)
        {
            TblSupplierPaymentModeTableAdapter ta = new TblSupplierPaymentModeTableAdapter();
            return ta.GetData(int.Parse(unitId));
        }

        public SupplierTDS.TblSupplierTypeDataTable GetBusinessType(string unitId)
        {
            TblSupplierTypeTableAdapter ta = new TblSupplierTypeTableAdapter();
            return ta.GetData(int.Parse(unitId));
        }

        // Add by Himadri 
        private static void Inatialize()
        {
            if (supplierStaticTable == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                supplierStaticTable = new SupplierTDS.QrySupplierDataTable[tblUnit.Rows.Count];
                QrySupplierTableAdapter adpCOA = new QrySupplierTableAdapter();

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    supplierStaticTable[i] = adpCOA.GetDataOfCommercialSupplier(tblUnit[i].intUnitID);
                   
                }

            }
        }


        // Add By Himadri For Sataic Class
        public static string[] GetCommercialSupplierListForAutoList(string unitID, string prefix)
        {
            Inatialize();
            string[] retStr = null;
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in supplierStaticTable[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
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
                    var rows = from tmp in supplierStaticTable[Convert.ToInt32(ht[unitID])]
                               where tmp.strName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
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

            // prepare the String Array
            if (tbl.Rows.Count > 0)
            {
                retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
            return retStr;
        }


    }
}


