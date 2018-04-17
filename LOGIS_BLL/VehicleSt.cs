using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LOGIS_DAL;
using HR_BLL.Global;
using HR_DAL.Global;
using LOGIS_DAL.VehicleTDSTableAdapters;
using System.Data;

namespace LOGIS_BLL
{
    public class VehicleSt
    {
        private static VehicleTDS.TblVehicleDataTable[] tableVehicle = null;
        private static Hashtable ht = new Hashtable();

        private static void Inatialize()
        {
            if (tableVehicle == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableVehicle = new VehicleTDS.TblVehicleDataTable[tblUnit.Rows.Count];
                TblVehicleTableAdapter adpCOA = new TblVehicleTableAdapter();                               

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {                    

                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableVehicle[i] = adpCOA.GetDataByUnit(tblUnit[i].intUnitID, true);
                }
            }
        }

        public static string[] GetVehicleDataForAutoFillCompany(string unitID, string shipPoint, string prefix, bool? isIn, bool? isInMaintain)
        {
            return GetVehicleDataForAutoFillDataProvider(unitID, shipPoint, prefix, true, isIn, true, false, false, isInMaintain);
        }

        public static string[] GetVehicleDataForAutoFillParty(string unitID, string shipPoint, string prefix, bool? isIn, bool? isInMaintain)
        {
            return GetVehicleDataForAutoFillDataProvider(unitID, shipPoint, prefix, true, isIn, false, true, true, isInMaintain);
        }

        public static string[] GetVehicleDataForAutoFillCustomer(string unitID, string shipPoint, string prefix, bool? isIn, bool? isInMaintain)
        {
            return GetVehicleDataForAutoFillDataProvider(unitID, shipPoint, prefix, true, isIn, false, true, true, isInMaintain);
        }

        public static string[] GetVehicleDataForAutoFillAll(string unitID,string shipPoint, string prefix, bool? isIn, bool? isInMaint)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                           where tmp.ysnEnable==true
                           && tmp.intAtThisShipPoint == (("" + shipPoint) == "" ? tmp.intAtThisShipPoint : int.Parse(shipPoint))
                           && (isIn == null ? true : (isIn.Value ? (tmp.IsintCurrentTripIdNull() ? false : true) : (tmp.IsintCurrentTripIdNull() ? true : false)))
                            && (isInMaint == null ? true :
                                                (isInMaint.Value ?
                                                (tmp.IsysnInMaintananceNull() ? false : !tmp.ysnInMaintanance) : (tmp.IsysnInMaintananceNull() ? true : !tmp.ysnInMaintanance)))
                           orderby tmp.strRegNo
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
                    var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                               where tmp.ysnEnable==true
                               && tmp.intAtThisShipPoint == (("" + shipPoint) == "" ? tmp.intAtThisShipPoint : int.Parse(shipPoint))
                                && tmp.strRegNo.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                                && (isIn == null ? true : (isIn.Value ? (tmp.IsintCurrentTripIdNull() ? false : true) : (tmp.IsintCurrentTripIdNull() ? true : false)))
                                 && (isInMaint == null ? true :
                                                (isInMaint.Value ?
                                                (tmp.IsysnInMaintananceNull() ? false : !tmp.ysnInMaintanance) : (tmp.IsysnInMaintananceNull() ? true : !tmp.ysnInMaintanance)))
                               orderby tmp.strRegNo
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
                    retStr[i] = tbl.Rows[i]["strRegNo"] + " [" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetVehicleDataForAutoFill(string unitID, string prefix)
        {
            return GetVehicleDataForAutoFillDataProvider(unitID,"", prefix, null, null, true, false, false, null);
        }

        public static string[] GetVehicleDataForAutoFillDataProvider(string unitID,string shipPoint, string prefix, bool? isEnable
            , bool? isIn, bool isCompany, bool isParty, bool isCustomer,bool? isInMaint)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                           where (isEnable == null ? true : (tmp.ysnEnable && isEnable.Value))
                           && tmp.ysnOwn == isCompany
                           && tmp.intAtThisShipPoint == (("" + shipPoint) == "" ? tmp.intAtThisShipPoint : int.Parse(shipPoint))
                           && isCompany ? true :
                               (
                                (isParty ? (tmp.Isint3rdPartyCOAidNull() ? false : true) : false)
                               ||
                                (isCustomer ? (tmp.IsintForThisCustomerNull() ? false : true) : false)
                               )
                           && (isIn == null ? true : (isIn.Value ? (tmp.IsintCurrentTripIdNull() ? false : true) : (tmp.IsintCurrentTripIdNull() ? true : false)))
                           && (isInMaint == null ? true :
                                                (isInMaint.Value ?
                                                (tmp.IsysnInMaintananceNull() ? false : !tmp.ysnInMaintanance) : (tmp.IsysnInMaintananceNull() ? true : !tmp.ysnInMaintanance)))
                           orderby tmp.strRegNo
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
                    var rows = from tmp in tableVehicle[Convert.ToInt32(ht[unitID])]
                                where tmp.strRegNo.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                                   && (
                                   (isEnable == null ? true : (tmp.ysnEnable && isEnable.Value))                                   
                                   && tmp.ysnOwn == isCompany
                                   && tmp.intAtThisShipPoint == (("" + shipPoint) == "" ? tmp.intAtThisShipPoint : int.Parse(shipPoint))
                                   && isCompany ? true :
                                       (
                                        (isParty ? (tmp.Isint3rdPartyCOAidNull() ? false : true) : false)
                                       ||
                                        (isCustomer ? (tmp.IsintForThisCustomerNull() ? false : true) : false)
                                       )
                                   && (isIn == null ? true : (isIn.Value ? (tmp.IsintCurrentTripIdNull() ? false : true) : (tmp.IsintCurrentTripIdNull() ? true : false)))
                                   && (isInMaint == null ? true :
                                                        (isInMaint.Value ?
                                                        (tmp.IsysnInMaintananceNull() ? false : !tmp.ysnInMaintanance) : (tmp.IsysnInMaintananceNull() ? true : !tmp.ysnInMaintanance)))
                                    )
                                   orderby tmp.strRegNo
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
                    retStr[i] = tbl.Rows[i]["strRegNo"] + " [" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static void ReloadVehicle(string unitID)
        {
            Inatialize();
            TblVehicleTableAdapter adpCOA = new TblVehicleTableAdapter();
            tableVehicle[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnit(int.Parse(unitID), true);
        }

        public static string[] GetVehicleDataForAutoFillParty(string unit, string prefixText)
        {
            TblVehicleTableAdapter adpCOA = new TblVehicleTableAdapter();
            DataTable tbl = new DataTable();
            tbl = adpCOA.GetDataByParty(int.Parse(unit), true, prefixText);
            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strRegNo"] + " [" + tbl.Rows[i]["intID"] + "]";
            }

            return retStr;
        }
    }
}