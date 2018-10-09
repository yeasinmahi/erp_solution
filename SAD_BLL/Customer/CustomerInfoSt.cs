using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SAD_DAL.Customer;
using HR_BLL.Global;

using SAD_DAL.Customer.CustomerTDSTableAdapters;
using HR_DAL.Global;
using System.Data;

namespace SAD_BLL.Customer
{
    public static class CustomerInfoSt
    {
        private static CustomerTDS.TblCustomerDDLDataTable[] tableCusts = null;
        private static Hashtable ht = new Hashtable();

        private static CustomerTDS.TblOSBaseCustomerDataTable[] tableCustsos = null;
        private static Hashtable htos = new Hashtable();



        private static CustomerTDS.TblCustomerSearchingDataTable[] tablUnitbaseCust = null;
        private static Hashtable htunit = new Hashtable();


        private static void Inatialize()
        {
            if (tableCusts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableCusts = new CustomerTDS.TblCustomerDDLDataTable[tblUnit.Rows.Count];
                TblCustomerDDLTableAdapter adpCOA = new TblCustomerDDLTableAdapter();

                

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    int untid = tblUnit[i].intUnitID;
                    //if (untid == 1 || untid == 46)
                    {
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableCusts[i] = adpCOA.GetDataByUnit(tblUnit[i].intUnitID);
                        
                    }
                }
            }
        }




        public static string[] GetCustomerDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
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
                    var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]
                               where tmp.strName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intCusID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public static string[] GetCustomerDataForAutoFill(string unitID, string prefix, string type,string salesOffice)        
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.intCusType.ToString() == type     
                           && tmp.intSalesOffId.ToString() == salesOffice
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
                    

                    var rows = from tmp in tableCusts[Convert.ToInt32(ht[unitID])]
                               where tmp.intCusType.ToString() == type
                               && tmp.intSalesOffId.ToString() == salesOffice
                               && tmp.strName.ToLower().Contains(prefix)
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intCusID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static void ReloadCustomer(string unitID)
        {
            Inatialize();
            TblCustomerDDLTableAdapter adpCOA = new TblCustomerDDLTableAdapter();
            tableCusts[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnit(int.Parse(unitID));
        }


        private static void Inatializeos()
        {
            if (tableCustsos == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                htos = new Hashtable();

                tableCustsos = new CustomerTDS.TblOSBaseCustomerDataTable[tblUnit.Rows.Count];
                TblOSBaseCustomerTableAdapter adpCOA = new TblOSBaseCustomerTableAdapter();


                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    int untid = tblUnit[i].intUnitID;
                    //if (untid == 1 || untid == 46)
                    {
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableCustsos[i] = adpCOA.GetDataByUnit(tblUnit[i].intUnitID);
                    }
                }
            }
        }


        public static string[] GetOSBaseCustomerDataForAutoFill(string unitID, string prefix, string territoryid, string salesOffice)
        {
            Inatializeos();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableCustsos[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.intPriceCatagory.ToString() == territoryid
                           && tmp.intSalesOffId.ToString() == salesOffice
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
                    var rows = from tmp in tableCustsos[Convert.ToInt32(ht[unitID])]
                               where tmp.intPriceCatagory.ToString() == territoryid
                               && tmp.intSalesOffId.ToString() == salesOffice
                               && tmp.strName.ToLower().Contains(prefix)
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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intCusID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        private static void Inatializeunitbase()
        {
            if (tablUnitbaseCust == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

               

                tablUnitbaseCust = new CustomerTDS.TblCustomerSearchingDataTable[tblUnit.Rows.Count];
                TblCustomerSearchingTableAdapter objcust = new TblCustomerSearchingTableAdapter();

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    int untid = tblUnit[i].intUnitID;
                    //if (untid == 1 || untid == 46)
                    {
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                       
                        tablUnitbaseCust[i] = objcust.GetDataByUnit(tblUnit[i].intUnitID);
                    }
                }
            }
        }

        public static string[] GetUnitBaseCustomerDataForAutoFill(string unitID, string prefix,string salesOffice)
        {
            Inatializeunitbase();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


          if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tablUnitbaseCust[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])
                           where tmp.intSalesOffId.ToString() == salesOffice
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
                    var rows = from tmp in tablUnitbaseCust[Convert.ToInt32(ht[unitID])]
                               where  tmp.strName.ToLower().Contains(prefix)
                               // where tmp.intSalesOffId.ToString()==salesOffice
                               //&& tmp.strName.ToLower().Contains(prefix)


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

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    //retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intCusID"] + "]";
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intCusID"] + "]";
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
