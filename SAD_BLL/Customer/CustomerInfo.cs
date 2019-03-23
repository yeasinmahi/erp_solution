using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAD_DAL.Customer;
using SAD_DAL.Customer.CustomerTDSTableAdapters;

namespace SAD_BLL.Customer
{
    public class CustomerInfo
    {
        public CustomerTDS.TblCustomerDataTable GetCustomerInfo(string unitID, string geoID, string typeID, string salesOffId, string userID)
        {

            int? geo = null, tp = null, so = null;
            try { geo = int.Parse(geoID); }
            catch { }
            try { tp = int.Parse(typeID); }
            catch { }
            try { so = int.Parse(salesOffId); }
            catch { }

            TblCustomerTableAdapter adp = new TblCustomerTableAdapter();
            return adp.GetData(int.Parse(unitID), geo, tp, so);
        }

        public CustomerTDS.TblCustomerDataTable GetCustomerInfoById(string cusID)
        {
            TblCustomerTableAdapter ta = new TblCustomerTableAdapter();
            return ta.GetDataById(int.Parse(cusID));
        }

        public CustomerTDS.TblCustomerShortDataTable GetCustomerShortInfoById(string cusID)
        {
            TblCustomerShortTableAdapter ta = new TblCustomerShortTableAdapter();
            return ta.GetData(int.Parse(cusID));
        }

        public string GetCustomerAddressById(string cusID)
        {
            TblCustomerTableAdapter ta = new TblCustomerTableAdapter();
            return ta.GetAddressById(int.Parse(cusID)).ToString();
        }

        public CustomerTDS.TblCustomerDDLDataTable GetCustomerInfoByType(string typeID, string unitID, string salesOffice)
        {
            TblCustomerDDLTableAdapter ta = new TblCustomerDDLTableAdapter();
            return ta.GetCustomers(int.Parse(unitID), int.Parse(typeID), int.Parse(salesOffice));
        }

        public bool InsertCustomer(int unitID, string geoID, string name, string address, string phone, decimal creditLimit, string custype, string salesOffice, string userID, string propitor, bool isPeriodicle, int daysOfLimit, string email, string vatregs)
        {
            int? geo = null, tp = null, cus = null, so = null;
            try { geo = int.Parse(geoID); }
            catch { }
            try { tp = int.Parse(custype); }
            catch { }
            try { so = int.Parse(salesOffice); }
            catch { }

            bool ysnSuccess;
            SprCustomerInsertTableAdapter cusAdp = new SprCustomerInsertTableAdapter();
            try
            {
                cusAdp.InsertCustomerData(cus, unitID, geo, name, address, phone, tp, so, creditLimit, int.Parse(userID), propitor, isPeriodicle, daysOfLimit, email, vatregs);
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }

            return ysnSuccess;
        }
        public bool UpdateCustomer(string customerId, int unitID, string geoID, string name, string address, string phone, decimal creditLimit, string custype, string salesOffice, string userID, string propitor, bool isPeriodicle, int daysOfLimit, string email, string vatregs)
        {
            int? geo = null, tp = null, cus = null, so = null;//,lm=null;
            try { geo = int.Parse(geoID); }
            catch { }
            try { tp = int.Parse(custype); }
            catch { }
            try { cus = int.Parse(customerId); }
            catch { }
            try { so = int.Parse(salesOffice); }
            catch { }



            bool ysnSuccess;
            SprCustomerInsertTableAdapter cusAdp = new SprCustomerInsertTableAdapter();
            try
            {
                cusAdp.InsertCustomerData(cus, unitID, geo, name, address, phone, tp, so, creditLimit, int.Parse(userID), propitor, isPeriodicle, daysOfLimit, email, vatregs);
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }

            return ysnSuccess;
        }

        public void UpdatePriceCatagory(string customerId, string priceCatId)
        {
            int? pc = null;
            try { pc = int.Parse(priceCatId); }
            catch { }

            TblCustomerTableAdapter ta = new TblCustomerTableAdapter();
            ta.UpdatePriceCatagory(pc, int.Parse(customerId));
        }

        public void UpdateLogisCatagory(string customerId, string logisCatId)
        {
            int? pc = null;
            try { pc = int.Parse(logisCatId); }
            catch { }

            TblCustomerTableAdapter ta = new TblCustomerTableAdapter();
            ta.UpdateLogisCatagory(pc, int.Parse(customerId));
        }

        public CustomerTDS.TblCustomerDDLDataTable GetCustomerForDDL(string unitId, string type, string salesOffice)
        {
            TblCustomerDDLTableAdapter ta = new TblCustomerDDLTableAdapter();
            return ta.GetCustomers(int.Parse(unitId), int.Parse(type), int.Parse(salesOffice));
        }

        public void GetCustomerCreditLimitCreditBalance(string customerId, string unitId, string userId, ref decimal creditLimit, ref decimal balance)
        {
            if ("" + customerId == "" || "" + unitId == "") return;
            SprCustomerGetCrLmCrBalTableAdapter ta = new SprCustomerGetCrLmCrBalTableAdapter();
            decimal? lm = 0, bl = 0;
            ta.GetData(int.Parse(customerId), int.Parse(userId), int.Parse(unitId), ref lm, ref bl);
            creditLimit = lm.Value;
            balance = bl.Value;
        }

        public CustomerTDS.TblCustomerDDLDataTable GetCustomerForDDLWithAll(string unitId, string type, string salesOffice)
        {
            TblCustomerDDLTableAdapter ta = new TblCustomerDDLTableAdapter();
            CustomerTDS.TblCustomerDDLDataTable table;

            table = ta.GetCustomers(int.Parse(unitId), int.Parse(type), int.Parse(salesOffice));


            CustomerTDS.TblCustomerDDLRow row = table.NewTblCustomerDDLRow();
            row.intCusID = 0;
            row.intCusType = 0;
            row.intUnitID = int.Parse(unitId);
            row.strName = "All";

            table.Rows.Add(row);

            return table;
        }

        public CustomerTDS.SprGetCustomerInfoForSalesOrderDataTable GetCustomerInfoForSalesOrder(string customerId, string userId, string unitId, DateTime dte)
        {
            if (customerId == "" || userId == "" || unitId == "") return null;
            SprGetCustomerInfoForSalesOrderTableAdapter ta = new SprGetCustomerInfoForSalesOrderTableAdapter();
            return ta.GetData(int.Parse(customerId), int.Parse(unitId), dte, int.Parse(userId));
        }

        public DataTable getdataCustomerMonthlyTarget(int unit, int areaid, DateTime frm, DateTime dttodate, int reportoption, int customerCOAId, string xmlString, int insertby)
        {
            try
            {
                SprAreaBaseTargetTableAdapter bll = new SprAreaBaseTargetTableAdapter();
                return bll.GetDataAreaBaseTarget(unit, areaid, frm, dttodate, reportoption, customerCOAId, xmlString, insertby);
            }
            catch { return new DataTable(); }
        }

        //public CustomerTDS.SprGetCustomerInfoForQuatationDataTable GetCustomerInfoForQuatition(string customerId, string userId, string unitId, DateTime dte)
        //{
        //    if (customerId == "" || userId == "" || unitId == "") return null;
        //    SprGetCustomerInfoForQuatationTableAdapter ta = new SprGetCustomerInfoForQuatationTableAdapter();
        //    return ta.GetDataGetCustomerInfoForQuatation(int.Parse(customerId), int.Parse(unitId), dte, int.Parse(userId));
        //}
        public CustomerTDS.SprGetCustomerInfoForQuatationDataTable GetCustomerInfoForQuatition(string customerId)
        {
            if (customerId == "" ) return null;
            SprGetCustomerInfoForQuatationTableAdapter ta = new SprGetCustomerInfoForQuatationTableAdapter();
            return ta.GetDataGetCustomerInfoForQuatation(int.Parse(customerId));



        }
    }
    }
