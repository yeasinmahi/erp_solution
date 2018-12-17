using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.AutoChallan.ExcelDataTDSTableAdapters;
using SAD_DAL.Global.ShipPointTDSTableAdapters;
using SAD_DAL.Global.SalesOfficeTDSTableAdapters;
using SAD_DAL.AutoChallan;
using SAD_DAL.AutoChallan.DairyChallanTableAdapters;

namespace SAD_BLL.AutoChallan
{
    public class ExcelDataBLL
    {
        private static ExcelDataTDS.tblVehicleDataTable[] tableVehicle = null;
        int e;
        public string ExcelDataInsert(string xmlString, int shipId, int offid, int enroll,int part)
        {
            string msg = "";
            try
            {
                sprExcelDataUploadFormTableAdapter adp = new sprExcelDataUploadFormTableAdapter();
                adp.GetExcel(xmlString, shipId, offid, enroll, part, ref msg);              
            }
            catch(Exception e) { msg = e.ToString(); }
            return msg;
        }

        public DataTable getVehicleAndDriverName(int custid)
        {
            try
            {
                tblVehicleListTableAdapter adpPV = new tblVehicleListTableAdapter();
                return adpPV.GetVehicle(custid);

            }
            catch { return new DataTable(); }
        }

        public DataTable getOfficebyShippoint(int unitid, int userid, bool process)
        {
            try
            {
                tblSalesOfficeTableAdapter adp = new tblSalesOfficeTableAdapter();
                return adp.GetOff(unitid, userid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getProductview(int custid, int shipid, int part)
        {
            string msg = "";
            try
            {
                sprExcelAutoChallanViewTableAdapter adpPV = new sprExcelAutoChallanViewTableAdapter();
                return adpPV.GetProductView(custid, shipid,  part);
            }
            catch (Exception e) { msg = e.ToString();  return new DataTable(); }
        }

        public DataTable UploadDataOrderDairy(int shipid, DateTime dtedate)
        {
            try
            {
                tblDairyOrderViewTableAdapter adp = new tblDairyOrderViewTableAdapter();
                return adp.GetData(shipid, dtedate.ToString());
            }
            catch { return new DataTable(); }
        }

        public DataTable getCustINfo(int custid)
        {
            
            try
            {
                tblCustomerTableAdapter adp = new tblCustomerTableAdapter();
                return adp.GetData(custid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getProductviewDairy(int custid, int shipid, int part, int offid, DateTime dtedate)
        {

            try
            {
                sprExcelAutoChallanViewDairyTableAdapter adp = new sprExcelAutoChallanViewDairyTableAdapter();
                return adp.GetData(custid, shipid, part, offid,dtedate);
            }
            catch { return new DataTable(); }
        }
        public DataTable getProductviewDairyBalance(int custid, int shipid, int part, int offid, DateTime dtedate)
        {

            try
            {
                sprExcelAutoChallanViewDairyBalanceTableAdapter adp = new sprExcelAutoChallanViewDairyBalanceTableAdapter();
                return adp.GetData(custid, shipid, part, offid, dtedate);
            }
            catch { return new DataTable(); }
        }


        public DataTable getShippoint(int userid, int Unitid, bool Active)
        {
            try
            {
                SprShipPointByUserTableAdapter adp = new SprShipPointByUserTableAdapter();
                return adp.GetData(userid, Unitid, Active);
            }
            catch { return new DataTable(); }
        }

        public DataTable getOffice(int userid, int Unitid, bool Active)
        {
            try
            {
                SprSalesOfficeByUserTableAdapter adp = new SprSalesOfficeByUserTableAdapter();
                return adp.GetData(userid, Unitid, Active);
            }
            catch { return new DataTable(); }
        }

       

        public DataTable getLoadingSlipView(int shipid)
        {
            try
            {
                tblLoadingSlipViewAllTableAdapter adpSlip = new tblLoadingSlipViewAllTableAdapter();
                return adpSlip.GetSlipView(shipid);
            }
            catch { return new DataTable(); }
        }

        public DataTable UploadData(int Shipid)
        {
            try
            {
                tblExcelOrderTableAdapter adp = new tblExcelOrderTableAdapter();
                return adp.GetData(Shipid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getProductviewBalance(int custid, int shipid, int part)
        {

                sprExcelBalanceTableAdapter adp = new sprExcelBalanceTableAdapter();
                return adp.GetData(custid, shipid, part);
           
        }

        public DataTable UploadDataOrder(int shipid)
        {
            try
            {
                tblDistributionOrderTableAdapter adpo = new tblDistributionOrderTableAdapter();
                return adpo.GetData(shipid);
            }
            catch { return new DataTable(); }
        }

        public string[] GetVehicle( string prefix)
        {
            int shipid = 16;
            tableVehicle = new ExcelDataTDS.tblVehicleDataTable[Convert.ToInt32(shipid)];
            tblVehicleTableAdapter Vehicle = new tblVehicleTableAdapter();
            tableVehicle[e] = Vehicle.GetData();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableVehicle[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableVehicle[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strRegNo.ToLower().Contains(prefix) 
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strRegNo"]  + "," + "[" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public void getOrderdelete()
        {
            try
            {
                tblUploadOrderDeleteTableAdapter adp = new tblUploadOrderDeleteTableAdapter();
                adp.GetData();
            }
            catch { }
        }

        public void getOrderSlipdelete(int custid, int Shipid)
        {
            try
            {
                OrderDeleteTableAdapter adpSDelete = new OrderDeleteTableAdapter();
                adpSDelete.LoadingSlipDelete(custid, Shipid);
             }
            catch { }
        }

        public void getOrderdelete(int custid,int shipid)
        {
            try
            {
                OrderDeleteTableAdapter adp = new OrderDeleteTableAdapter();
                adp.GetOrderDelete(custid, shipid);
            }
            catch { }
        }

        public DataTable getLodingSlipno(int custid)
        {
            try { tblExcelDataLoadingSlipTableAdapter adp = new tblExcelDataLoadingSlipTableAdapter();
                return adp.GetLodingSlip(custid);
            } catch { return new DataTable(); }           
        }

        public void getVdelete(int custid, int vid)
        {
            try
            {
                tblvehicledeleteTableAdapter adp = new tblvehicledeleteTableAdapter();
                adp.VehicleDelete(custid, vid);
            }
            catch {}
        }

        public DataTable getVehilceReport(int shipid)
        {
            try
            {
                tblVehicleListFinalTableAdapter adpv = new tblVehicleListFinalTableAdapter();
                return adpv.GetVehicleReport(shipid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getEmpinfo(int empid)
        {
            try
            {
                QRYEMPLOYEEPROFILEALLTableAdapter adpemp = new QRYEMPLOYEEPROFILEALLTableAdapter();
                return adpemp.GetPhone(empid);
            }
            catch { return new DataTable(); }
        }

        public void Insertvehicle(int custid, int intshipid, int vid, string vno, int empid,string supplierName)
        {
            try
            {
                tblvehicledeleteTableAdapter adpd = new tblvehicledeleteTableAdapter();
                adpd.VehicleDelete(custid, vid);

                tblVehileProgramToFatoryTableAdapter adp = new tblVehileProgramToFatoryTableAdapter();
                adp.InsertDataVehicle(custid, intshipid, vid, vno, empid, supplierName);

               
            }
            catch { }
        }

        public void getOrderUpload(int custid, string msg, int Shipid, int officeid, int enroll)
        {
            try
            {
                sprExcelChallanUploadSingleTableAdapter adp = new sprExcelChallanUploadSingleTableAdapter();
                adp.GetExcelCopy(custid, msg, Shipid, officeid, enroll);
            }
            catch { }
        }

        public void getUpdateSlipnobyCustomer(string slip, int custid)
        {
            try
            {
                tblExcelDataLoadingSlip1TableAdapter adpupdateslip = new tblExcelDataLoadingSlip1TableAdapter();
                adpupdateslip.GetUpdateSlip(slip, custid);

             
                tblVehileProgramToFatory1TableAdapter adpupdate = new tblVehileProgramToFatory1TableAdapter();
                adpupdate.GetData(custid);
            }
            catch { }
        }

        public void getCustomerInsertdairy(int custid, DateTime dateTime)
        {
            try
            {
                
                tblDepotDairyorderTableAdapter adpupdateslip = new tblDepotDairyorderTableAdapter();
                adpupdateslip.GetData(custid.ToString(), dateTime.ToString());
            }
            catch { }
        }
    }
}
