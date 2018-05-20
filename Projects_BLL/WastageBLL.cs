using Projects_DAL.WastageTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCM_DAL.WastageNewTDSTableAdapters;



namespace Projects_BLL
{
    public class WastageBLL
    {
        public DataTable GetUnitList(int intEnroll)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUnitList(intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
          
        }

        public DataTable getUom()
        {
            try { tblItemUOMTableAdapter adp = new tblItemUOMTableAdapter(); return adp.GetUOM(); }
            catch { return new DataTable(); }
        }

        public void insertAG(string itemName,int? intItemid, int? intItemCategoryID, int Unitid, int Userid, DateTime? dteinsertdate, bool active, int? intUOMID2, int? intWorkCount,string custname,string CustAdd, string PhoneNo, int? CustTypeid, int? intCOAID, string Coaname,int? intCustid)
        {
           

            try
            {
                sprItemAddTableAdapter adp = new sprItemAddTableAdapter();
                adp.GetData(itemName, intItemid, intItemCategoryID, Unitid, Userid, dteinsertdate, active, intUOMID2, intWorkCount,custname,CustAdd,PhoneNo,CustTypeid,intCOAID,Coaname,intCustid);
            }
            catch { }
        }

        public DataTable getInvintoryWH(int unitid)
        {
            try
            {
                tblWHInventoryListTableAdapter adpwhInv = new tblWHInventoryListTableAdapter();
                return adpwhInv.GetWHInventory(unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getWH(int intinsertby)
        {
            try { tblWHListTableAdapter adpwh = new tblWHListTableAdapter();
                return adpwh.GetWH(intinsertby);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSalesReport(string dtefate, string dtetdate, int whid, int part)
        {
            try
            {
                if (part == 1)
                {
                    tblSalesReportTableAdapter adps = new tblSalesReportTableAdapter();
                    return adps.GetData(dtefate, dtetdate, whid);
                }
                else
                {
                    sprPendingSalesReportTableAdapter adps = new sprPendingSalesReportTableAdapter();
                    return adps.GetData(DateTime.Parse(dtefate),DateTime.Parse(dtetdate), whid);
                }
               
            } 
            catch { return new DataTable(); }
        }

        public DataTable getInvRpt(string dtefdae, string dtetodate, int whid)
        {
            try
            {
                sprWMInventoryReportTableAdapter adpInv = new sprWMInventoryReportTableAdapter();
                return adpInv.GetData(DateTime.Parse(dtefdae),DateTime.Parse(dtetodate),whid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getIteminfo(string Itemid)
        {
            try
            {
                tblItemInfoTableAdapter adp = new tblItemInfoTableAdapter();
                return adp.GetItemInfo(int.Parse(Itemid));
            }
            catch { return new DataTable(); }
        }

        public DataTable ItemListRpt(int Unitid)
        {
            try
            {
                tblItemListTableAdapter adpItemlsit = new tblItemListTableAdapter();
                return adpItemlsit.GetItemList(Unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable SalesDetials(string salesOrderNo, string deliveryChallan, int WHID)
        {
            try
            {
                tblSalesDetailsTableAdapter adpD = new tblSalesDetailsTableAdapter();
                return adpD.GetSalesDetails(salesOrderNo,int.Parse(deliveryChallan), WHID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getWHbyUnit(int Unitid)
        {
            try {
                tblWHByUnitTableAdapter adpwhbyunit = new tblWHByUnitTableAdapter();
                return adpwhbyunit.GetWHListByunit(Unitid);
            } catch { return new DataTable(); }
        }

        public DataTable pendingDetials(string salesOrderNo, int WHID)
        {
             try
            {
                tblPendingDetailsTableAdapter adpwhbyunit = new tblPendingDetailsTableAdapter();
                return adpwhbyunit.GetPendingDetails(salesOrderNo, WHID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSalesOrderList(int WHID)
        {
            try
            {
                tblSalesOrderTableAdapter adpwhbyunit = new tblSalesOrderTableAdapter();
                return adpwhbyunit.GetSalesOrder(WHID);
            }
            catch { return new DataTable(); }
        }

        public DataTable deptList()
        {
            try
            {
                tblDepartmentTableAdapter dpt = new tblDepartmentTableAdapter();
                return dpt.GetDepartment();
            }
            catch { return new DataTable(); }
        }

        public DataTable getReportForTransfer(int intwork,  string dteFdate, string dteTdate,int unitid, int whid,int? intTranferwhid)
        {
            try
            {
                sprWMItemTransferReportTableAdapter adp = new sprWMItemTransferReportTableAdapter();
                return adp.GetData(intwork,DateTime.Parse(dteFdate),DateTime.Parse(dteTdate), unitid, whid, intTranferwhid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getReffid()
        {
            try { tblReffIdTableAdapter adp = new tblReffIdTableAdapter();
                return adp.GetOutReffId();
            }
            catch { return new DataTable(); }
        }

       

        public DataTable ItemListRpt(string itemName, int? intItemid, int? intItemCategoryID, int? Unitid, int? Userid, DateTime? dteinsertdate, bool active, int? intUOMID, int? intWorkCount, string custname, string CustAdd, string PhoneNo, int? CustTypeid, int? intCOAID, string Coaname, int? intCustid)
        {
          
              sprItemAddTableAdapter adp = new sprItemAddTableAdapter();
              return   adp.GetData(itemName, intItemid, intItemCategoryID, Unitid, Userid, dteinsertdate, active, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
           
        }

        public DataTable getSalesOrderView(string Sono, int Unitid)
        {
            try
            {
                tblSalesOrderViewTableAdapter adpSOV = new tblSalesOrderViewTableAdapter();
                return adpSOV.GetSOView(Sono, Unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSODetails(int WHID,string SONO)
        {
            try { tblSODetailsTableAdapter adp = new tblSODetailsTableAdapter();
                return adp.GetSO(WHID, SONO);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCOA(int Unitid, int Cid)
        {
            try
            {
                tblCOAListTableAdapter adp = new tblCOAListTableAdapter();
                return adp.GetData(Unitid, Cid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCOAAcc(int Unitid)
        {
            try
            {
                tblAccountCOATableAdapter adpCOAHO = new tblAccountCOATableAdapter();
                return adpCOAHO.GetCOAHEAD(Unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getOpeningStock(int unitid, int itemid)
        {
            try
            {
                tblOpeningTableAdapter adpo = new tblOpeningTableAdapter();
                return adpo.GetOpening(unitid, itemid);
            }
            catch { return new DataTable(); }
        }

        public void getReceiveEntry(int intInOutReffID, DateTime dteTransactionDate, int intItemid, int? intQty, decimal? monInRate, decimal? monInValue, int? intOutQty, decimal? monOutRate, decimal? monOutValue, int intTransactionTypeID, int unitid, int intinsertby, DateTime now, int? intWHID, bool? ysnActive, string strRemarks, bool? ysnIssueComplete, int? intSalesID, int? intCustromerID, int? intDeliveryChallanNo, string strSalesOrderNo, int? intWeightIDNo, int? intDepartmentID, int? intTransferJobStationID, int? strRequisitionID, int? intTransferUnit, int intWastageWareHouseID, int? intTransferWastageWareHouseID)
        {
            try
            {
                sprWMTransactionTableAdapter adp = new sprWMTransactionTableAdapter();
                 adp.GetReceive(intInOutReffID, dteTransactionDate, intItemid, intQty, monInRate, monInValue, intOutQty, monOutRate, monOutValue, intTransactionTypeID, unitid, intinsertby, DateTime.Now, intWHID, ysnActive, strRemarks, ysnIssueComplete, intSalesID, intCustromerID, intDeliveryChallanNo, strSalesOrderNo, intWeightIDNo, intDepartmentID, intTransferJobStationID, strRequisitionID.ToString(), intTransferUnit, intWastageWareHouseID, intTransferWastageWareHouseID);
            }
            catch { }
        }

      

        public DataTable CustomerList(int intunitid)
        {
            try
            {
                tblCustomerListTableAdapter adpCust = new tblCustomerListTableAdapter();
                return adpCust.GetCustomerList(intunitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCheck(int COAid)
        {
            try
            {
                tblCheckTableAdapter adpc = new tblCheckTableAdapter();
                return adpc.GetData(COAid);
            }
            catch { return new DataTable(); }
        }

        public string insertSales(DateTime dtedate, int intCustid, int intunitid, int intEnroll, string mRRNO, int whid, string xml)
        {
            string msg = "";
            try
            {
                sprSalesEntryWastageTableAdapter adpc = new sprSalesEntryWastageTableAdapter();
                 adpc.GetSalesEntry(dtedate, intCustid, intunitid, intEnroll, mRRNO, whid, xml, ref msg);
            }
            catch(Exception e) { msg = e.ToString();  }
            return msg;
        }

        public string gtCreateVoucher(DateTime dteTransactionDate, int unitid, string narration, decimal? monTotalIssueAmount, int? cOAid, string cOAName, int? hOCOAid, string hOCOAName, int Enroll)
        {
            string msg = "";
            try
            {
                sprWMJournalVoucherTableAdapter adpc = new sprWMJournalVoucherTableAdapter();
                adpc.GetVoucher(unitid, narration, monTotalIssueAmount, cOAid, cOAName, hOCOAid, hOCOAName, Enroll,DateTime.Now);
            }
            catch (Exception e){ msg = e.ToString(); }
            return msg;
        }
    }
}
