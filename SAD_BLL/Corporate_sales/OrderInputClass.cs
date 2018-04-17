using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Corporate_sales.OrderInputCorpTableAdapters;
using SAD_DAL.Corporate_sales;
using System.Data;

namespace SAD_BLL.Corporate_sales
{
    public class orderInputClass
    {
        int e;
        
       private static OrderInputCorp.GetAutoSearchCustomerDataTable[]  tableCusts = null;
        public System.Data.DataTable getShippoint()
        {
            tblShippingPointTableAdapter GetCorSaelsShippoint = new tblShippingPointTableAdapter();
            return GetCorSaelsShippoint.GetShipPointName();


        }

        public System.Data.DataTable getShipPointOffice()
        {
            tblSalesOfficeTableAdapter getOffice = new tblSalesOfficeTableAdapter();
            return getOffice.GetData();
        }

        public string[] GetItemLists(string WHID, string prefix)
        {

            int intwh = Int32.Parse(WHID.ToString());
            //Inatialize(intwh);
            tableCusts = new OrderInputCorp.GetAutoSearchCustomerDataTable[Convert.ToInt32(WHID)];
            GetAutoSearchCustomerTableAdapter adpCOA = new GetAutoSearchCustomerTableAdapter();
            tableCusts[e] = adpCOA.GetAutoSearchCustomer(Convert.ToInt32(WHID));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 2)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.CustName
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
                                   where tmp.CustName.ToLower().Contains(prefix) //|| tmp.ItemNumber.ToLower().Contains(prefix)
                                   orderby tmp.CustName
                                   select tmp;
                        //           where tmp.strItem.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                        //           orderby tmp.strItem
                        //           select tmp;

                        //var rows2 = from tmp in tableCusts[Convert.ToInt32(ht[WHID])]
                        //            where tmp.ItemNumber.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                        //            orderby tmp.ItemNumber
                        //            select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }
                        // if (rows2.Count() > 0) { tbl = rows2.CopyToDataTable(); }

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

                    retStr[i] = tbl.Rows[i]["CustName"] + ";" + tbl.Rows[i]["CustId"];

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }


        }


        public DataTable getPendingReportCorp(int unitid, int shippointid)
        {
            OrdependingTableAdapter Reportorder = new OrdependingTableAdapter();
            return Reportorder.GetCorpOrderPending(unitid, shippointid);
        }
        public System.Data.DataTable getPendingProductWiseReportCorp(int Custid, int shippointid)
        {

            ERPPendingAFBLProductWiseCorpTableAdapter getErpProductPending = new ERPPendingAFBLProductWiseCorpTableAdapter();
            return getErpProductPending.GetCorPendingView(Custid, shippointid);
        }

        //public void insertoutlateinfo(int intenroll, string softwareReport)
        //{
        //    tblchecksoftwareTableAdapter cheksoftware = new tblchecksoftwareTableAdapter();
        //    cheksoftware.GetData(intenroll, softwareReport);
        //}
        public DataTable getPermission(int enrollnumber)
        {

            DairyLoginCustomerTableAdapter GetPermission = new DairyLoginCustomerTableAdapter();
            return GetPermission.GetDairyLoginCustomerData(enrollnumber);

        }
        public DataTable getarea()
        {
            HeadAreaTableAdapter getarea = new HeadAreaTableAdapter();
            return getarea.GetData();
        }
        public DataTable getareas()
        {
            AreaASMTableAdapter getarea = new AreaASMTableAdapter();
            return getarea.GetAreaData();
        }





        public DataTable getTerritoryHead(string Area)
        {
            AreaASMTableAdapter getterritory = new AreaASMTableAdapter();
            return getterritory.GetAreaTSMDataby(Area);
        }

        public DataTable getPoint(string area, string territory)
        {
            AreaASMTableAdapter getterritorypoint = new AreaASMTableAdapter();
            return getterritorypoint.GetTerritory(area, territory);
        }

        public DataTable getwoeks(DateTime dtfromdate, DateTime dttodate)
        {
            afblworkingdayTableAdapter getworksdayse = new afblworkingdayTableAdapter();
            return getworksdayse.GetData(dtfromdate,dttodate);
        }

        

        public DataTable getdetails(DateTime fromdate, DateTime todate, int part, string location)
        {
            CorpAchDetails1TableAdapter getAchievementdetails = new CorpAchDetails1TableAdapter();
            return getAchievementdetails.GetDairyAllAchievement(fromdate, todate, part, location);
        }

        public DataTable getloginnumber(int enroll)
        {
            OnlineSoftwarePermissionTableAdapter permissionnumber = new OnlineSoftwarePermissionTableAdapter();
            return permissionnumber.GetOnlineSoftwarepermission(enroll);

        }

        public DataTable getProductNameReportDairy()
        {
            tblAFBLCorporateSalesProductTableAdapter getProductlist = new tblAFBLCorporateSalesProductTableAdapter();
            return getProductlist.GetProductList();
        }
        public DataTable getOrderAnalysisReportDairy(int part, int number, int enroll, DateTime dtefromdate, DateTime dtetodate, string line)
        {
            AFBLOrderAnalisysReportCorpTableAdapter getorderanalysis = new AFBLOrderAnalisysReportCorpTableAdapter();
            return getorderanalysis.GetOrderAnalysisReport(part, number, enroll, dtefromdate, dtetodate, line);

        }
        public DataTable GetEmployeeReport(DateTime dtefromdate, DateTime dtetodate, int part, int numbers, int enroll, int productNumber, int productid, string line)
        {
            CorpAFBLVehicleReportVSSalesEmployeeTableAdapter getEmployeeReport = new CorpAFBLVehicleReportVSSalesEmployeeTableAdapter();
            return getEmployeeReport.GetData(dtefromdate, dtetodate, part, numbers, enroll, productNumber, productid, line);
        }

        public DataTable getValuesbySalesdairy(DateTime dtefromdate, int part, int number, int enroll, int productnumber, int productid, string line)
        {
            CorpAFBLVehicleReportVSSalesTableAdapter getValuesSales = new CorpAFBLVehicleReportVSSalesTableAdapter();
            return getValuesSales.GetData(dtefromdate, part, number, enroll, productnumber, productid, line);
        }

       

        public DataTable getMonthlyReportCorp(DateTime dtefromdate, DateTime dtetodate, int part, string location)
        {
            CorpSalesMonthTableAdapter getMonthylyReport = new CorpSalesMonthTableAdapter();
            return getMonthylyReport.GetData((dtefromdate),(dtetodate), location, part);
        }
    }

   
}
