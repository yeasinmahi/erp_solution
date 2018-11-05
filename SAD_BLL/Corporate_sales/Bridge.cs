using SAD_DAL.Corporate_sales.DataSet1TableAdapters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SAD_BLL.Corporate_sales
{
    public class Bridge
    {

        public System.Data.DataTable productlists()
        {
            try { 
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            return adp.GetDataProduc();}catch { return new DataTable(); }
        }

       
        public System.Data.DataTable distributor()
        {
            try { 
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            return adp.GetData();}catch { return new DataTable();}
        }

       

        public System.Data.DataTable getAllSalesInInstitute(DateTime fromdate, DateTime todate, int ReportCategoryid)
        {
            try { 
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            return adp.GetDataInstituteSales(fromdate, todate, ReportCategoryid);}
            catch { return new DataTable(); }
        }

        public System.Data.DataTable getareaname()
        {
            try { 
            tblInstituteMarketSetupTableAdapter adp = new tblInstituteMarketSetupTableAdapter();
            return adp.GetDataarea();}catch { return new DataTable();}
        }


        public System.Data.DataTable gettername(int area)
        {
            try { 
            tblInstituteMarketSetupTableAdapter adp = new tblInstituteMarketSetupTableAdapter();
            return adp.GetTerritory(area);}
            catch { return new DataTable(); }
        }

  
        public System.Data.DataTable getpopint(int territory)
        {
            try { 
            tblInstituteMarketSetupTableAdapter adp = new tblInstituteMarketSetupTableAdapter();
            return adp.getpoint(territory);}
            catch { return new DataTable(); }
        }

       

        public System.Data.DataTable getareasales(DateTime fromdate, DateTime todate, int ReportCategoryid)
        {
            try { 
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            return adp.InstituteSalesArea(fromdate, todate, ReportCategoryid); } catch { return new DataTable(); }
        }

       

        public DataTable GetCorpProd(string prod)
        {
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            try{return adp.searchproduct(prod);}catch{ return new DataTable(); }
        }

        public System.Data.DataTable getterritorysales(DateTime fromdate, DateTime todate, int ReportCategoryid)
        {
            try { 
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            return adp.InstituteSalesTerritory(fromdate, todate, ReportCategoryid);
            } catch { return new DataTable(); }
        }

        

        public System.Data.DataTable get(DateTime fromdate, DateTime todate, int ReportCategoryid)
        {
            try { 
            CorpSalesTerritoryTableAdapter adp = new CorpSalesTerritoryTableAdapter();
            return adp.GetData(fromdate, todate, ReportCategoryid);
            } catch { return new DataTable(); }
        }

        public System.Data.DataTable getareasalesdate(DateTime fromdate, DateTime todate)
        {
            try { 
            CorpSalesDateTableAdapter adp = new CorpSalesDateTableAdapter();
            return adp.CorporateSalesAreaTotal(fromdate, todate);
            } catch { return new DataTable();}
        }

       

        public System.Data.DataTable getterritorysalesdate(DateTime fromdate, DateTime todate, int territory)
        {
            try
            {
                CorpSalesDateTableAdapter adp = new CorpSalesDateTableAdapter();
                return adp.CoporateSalesTotalTerritory(fromdate, todate, territory);
            }
            catch { return new DataTable(); }
        }

      

        public System.Data.DataTable getpointsalesdate(DateTime fromdate, DateTime todate, int pointid)
        {
            try
            {CorpSalesDateTableAdapter adp = new CorpSalesDateTableAdapter();
              return adp.CorporateSalesPoint2(fromdate, todate, pointid);
            } catch { return new DataTable(); }
        }



        public System.Data.DataTable GetDist(string distributor)
        {
            try{ DataTableSADCUSTTableAdapter adp = new DataTableSADCUSTTableAdapter();
            return adp.Customername(distributor);
            } catch{return new DataTable();}
        }

        public DataTable GetProd(string searchKey)
        {
            try
            {
                tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
                return adp.searchproduct(searchKey);
            } catch{return new DataTable();}
        }

        public DataTable GetCorpCustomer(string customer)
        {
            try
            {
                DataTableSADCUSTTableAdapter adp = new DataTableSADCUSTTableAdapter();
                return adp.Customername(customer);
            }
            catch { return new DataTable(); }
        }  

        public DataTable getprice(int itemid, int custid, int ItemUom, int salestype)
        {

            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            try
            {
                return adp.getprice(itemid, custid, ItemUom, salestype);
            }
            catch { return new DataTable(); }
        }
        public void insertreturn(string xmlString)
        {
            tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
            try
            {
                adp.insertinstitutereturn(xmlString);
            }
            catch { }
        }


        public DataTable custreturn(int custid, DateTime strdt, DateTime enddt)
        {
            try
            {
                DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
                return adp.custoreturn(custid, strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable custreturncsd(int custid, DateTime strdt, DateTime enddt)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            {
                return adp.custrtncsd(custid, strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable custreturndairy(int custid, DateTime strdt, DateTime enddt)
        {
            DataTableReturnTableAdapter customerreturn = new DataTableReturnTableAdapter();
            try
            {
                return customerreturn.custrtndairy(custid, strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable catreturn(DateTime strdt, DateTime enddt, string category)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            {
                return adp.catrtnall(strdt, enddt, category);
            }
            catch { return new DataTable(); }
        }

        public DataTable catreturncsd(DateTime strdt, DateTime enddt, string category)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            {
                return adp.catrtncsd(strdt, enddt, category);
            }
            catch { return new DataTable(); }
        }

        public DataTable catreturndairy(DateTime strdt, DateTime enddt, string category)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            {
                return adp.catrtndairy(strdt, enddt, category);
            }
            catch { return new DataTable(); }
        }

        public DataTable proreturnall(DateTime strdt, DateTime enddt)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            { 
                 return adp.prodreturnall(strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable proreturncsd(DateTime strdt, DateTime enddt)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            { 
                return adp.prodreturncsd(strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable proreturndairy(DateTime strdt, DateTime enddt)
        {
            DataTableReturnTableAdapter adp = new DataTableReturnTableAdapter();
            try
            { 
                return adp.prodrtndairy(strdt, enddt);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetCustomer(string customer)
        {
            DataTableSADCUSTTableAdapter adp = new DataTableSADCUSTTableAdapter();
            try
            {
                return adp.Customerforvehicle(customer);
            }
            catch 
            { 
                return new DataTable(); 
            }
        }
        public DataTable InsertCorpRtnNGetFk(string strcustid, string strchallanno, Boolean whrcv, Boolean ftyrcv, string stractionby, string strwhrcvdate)
        {
            tblAccountsUnfoundTableAdapter adp = new tblAccountsUnfoundTableAdapter();
            try
            {
                return adp.InsertCorpReturnNGetFK(int.Parse(strcustid), strchallanno, whrcv, ftyrcv, int.Parse(stractionby), Convert.ToDateTime(strwhrcvdate));
            }
            catch { return new DataTable(); }
        }

        public string InsertCorpReturnRcvProd(int fk,string xmlString)
        {
            string msg = "";
            try
            {
                sprERPCorpReturnTableAdapter adp = new sprERPCorpReturnTableAdapter();
                adp.InsertCorpReturn(fk,xmlString, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public void insertvehicle(int custid, int vehiclepaymentid, int intcustloanid, string strvehiclechesisno, string strmodelno, DateTime dtdeliverydate, decimal monvehicleprice, decimal downpayment, decimal monusefullife, decimal monloanperiod, decimal mondepreciation, decimal monemi, int insertedby, DateTime dtdatetimenow)
        {
            try
            {
                AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
                adp.insertvehloan(custid, vehiclepaymentid, intcustloanid, strvehiclechesisno, strmodelno, Convert.ToString(dtdeliverydate), monvehicleprice, downpayment, monusefullife, monloanperiod, mondepreciation, monemi, insertedby, Convert.ToString(dtdatetimenow));
            }
            catch { }
        }


        public DataTable selectloanvehicle()
        {
            AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
            try
            {
                return adp.reportloan();
            }
            catch { return new DataTable(); }
        }

        public void insertdata(int p1, int p2, decimal p3, DateTime datetime, int enroll)
        {
            try
            {
                DataTableInsertPaymentTableAdapter adp = new DataTableInsertPaymentTableAdapter();
                adp.Insertpayment(p1, p2, p3, datetime, enroll);
            }
            catch { }
        }

        public DataTable fnlsttltocustomer(int custid)
        {
            AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
            try
            {
                return adp.finalsettlementtocustomer(custid);
            }
            catch { return new DataTable(); }

        }

        public DataTable fnlsttltocompany(int custid)
        {
            AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
            try
            {
                return adp.finalsettlementtocompany(custid);
            }
            catch { return new DataTable(); }
        }

        public void settleclose(int custid)
        {
            try
            {
                AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
                adp.settelementclose(custid);
            }
            catch { }
        }

        public DataTable getjv(string narrations, string ttl)
        {
            JVCreateTableAdapter adp = new JVCreateTableAdapter();
            try
            {
                return adp.GetDataJV(narrations, ttl);
            }
            catch { return new DataTable(); }
        }

        public void creditfrmcustacc(int p1, int p2, string narration, decimal p3, string AccName)
        {
            try
            {
                tblAccountsVoucherJournalDetailsTableAdapter adp = new tblAccountsVoucherJournalDetailsTableAdapter();
                adp.insertintocustaccount(p1, p2, narration, p3, AccName);
            }
            catch { }
        }

        public void debittocompany(int p, string narrations, decimal total)
        {
            try
            { 
                tblAccountsVoucherJournalDetailsTableAdapter adp = new tblAccountsVoucherJournalDetailsTableAdapter();
                adp.InsertCompany(p, narrations, total);
            }
            catch { }
        }

        public DataTable custbalance(int custoid)
        {
           tblCustomerTableAdapter adp = new tblCustomerTableAdapter();
            try
            { 
                return adp.GetCustomerBalance(custoid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getjvfinal(string narrations, string amount)
        {
            JVCreateTableAdapter adp = new JVCreateTableAdapter();
            try
            { 
                return adp.GetFinalJV(narrations, amount);
            }
            catch { return new DataTable(); }
        }

        public void finalpaytocompany(int p1, int p2, string narration, decimal p3, string AccName)
        {
            try
            {
                tblAccountsVoucherJournalDetailsTableAdapter adp = new tblAccountsVoucherJournalDetailsTableAdapter();
                adp.Insertintocustomeraccclosed(p1, p2, narration, p3, AccName);
            }
            catch { }
        }

        public void finalpaytocompanycomacchit(int p1, string narrations, decimal p2)
        {
            try
            {
                tblAccountsVoucherJournalDetailsTableAdapter adp = new tblAccountsVoucherJournalDetailsTableAdapter();
                adp.InsertCompanyclosed(p1, narrations, p2);
            }
            catch { }
        }

        public DataTable getscopeid()
        {
            AFBLVehicleLoanTableAdapter adp = new AFBLVehicleLoanTableAdapter();
            try
            { 
                return adp.vehiclescopeid();
            }
            catch { return new DataTable(); }
        }



        public DataTable GetCustomerall(string customer)
        {
            DataTableSADCUSTTableAdapter adp = new DataTableSADCUSTTableAdapter();
            try
            {
                return adp.Customername(customer);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable getdairyreconsulationreport()
        {
            ReconculationTableAdapter adp = new ReconculationTableAdapter();
            try
            { 
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }

        public DataTable getaccountinfo(int intaccountid)
        {
            tblBankAccountStatement2TableAdapter adp = new tblBankAccountStatement2TableAdapter();
            try
            {
                return adp.GetData(intaccountid);
            }
            catch { return new DataTable(); }

        }

        public DataTable getbankaccountno(int id)
        {
            tblBankAccountInfoTableAdapter adp = new tblBankAccountInfoTableAdapter();
            try
            {
                return adp.GetData(id);
            }
            catch { return new DataTable(); }

        }

        public DataTable getchequee(string cheque, string inputcheque)
        {
            afblreconsilechequeTableAdapter adp = new afblreconsilechequeTableAdapter();
            try
            { 
                return adp.GetData(cheque, inputcheque);
            }
            catch { return new DataTable(); }

        }


        public DataTable GetCheckDistCount(int custid, string dtetodatecount)
        {
            ReconcilationCheckDistTableAdapter adp = new ReconcilationCheckDistTableAdapter();
            try
            {
                return adp.GetData(custid, dtetodatecount);
            }
            catch { return new DataTable(); }

        }

        public void updatestatement(string nnaration, string customerid, long intid)
        {
            try
            {
                tblBankAccountStatementTableAdapter adp = new tblBankAccountStatementTableAdapter();
                adp.GetData(nnaration, customerid, intid);
            }
            catch { }
        }

        public void insertunfoundinfo(int enroll, int custid, string cheque, string dtedepositdate, decimal monamount, int intid)
        {
            try
            {
                tblAccountsUnfoundTableAdapter adp = new tblAccountsUnfoundTableAdapter();
                adp.GetData(enroll, custid, cheque, dtedepositdate, monamount, intid);
            }
            catch { }
           
        }

        public void insertReconsulation(int intunitid, int enroll, int custid, decimal monamount, string naration)
        {
            try
            {
                tblAccountsUnfoundTableAdapter adp = new tblAccountsUnfoundTableAdapter();
                adp.GetDataBy(intunitid, enroll, custid, monamount, naration);
            }
            catch { }

        }

        public static DataTable GetDataForViewByFty()
        {
            DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
            try
            {
                return adp.CorpReturnFTYView();
            }
            catch { return new DataTable(); }
        }


        public DataTable GetDataForFtyCount(int custid, string challanno)
        {
            try
            { CorporateReturnTableAdapter adp = new CorporateReturnTableAdapter();
                return adp.CorporateReturnFTYRCVUpdate(custid, challanno);
            }
            catch { return new DataTable(); }
        }


        public DataTable GetDataForWHUpdate(int custid, string challanno)
        {
            try
            {
                CorporateReturnTableAdapter adp = new CorporateReturnTableAdapter();
                return adp.GetCorpReturnWHUpdateData(custid, challanno);
            }
            catch { return new DataTable(); }
        }

        public void InsertFtyRcvData( decimal productqty, int productid, int fk)
        {
            try
            {
                DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
                adp.UpdateCorpreturn(productqty, productid, fk);
            }
            catch { }
        }


        public void UpdateFtyRcv(int custid, string challanno)
        {
            try
            {
                DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
                adp.UpdateCorprtnFirst(custid, challanno);
            }
            catch { }
        }


        public void UpdateWHRcv(decimal partyqtysubmit, decimal whqtysubmit, int productid, int fk)
        {
            try
            {
                DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
                adp.EditPartyWHQty(partyqtysubmit, whqtysubmit, productid, fk);
            }
            catch { }
        }



        public DataTable GetDataForAppv()
        {
            sprERPCorpReturnAmountTableAdapter adp = new sprERPCorpReturnAmountTableAdapter();
            try
            {
                return adp.GetCorpSalesReturnAmount();
            }
            catch { return new DataTable(); }
        }


        public DataTable GetDataForAppView(int custid, string challanno)
        {
            try
            {
                CorporateReturnTableAdapter adp = new CorporateReturnTableAdapter();
                return adp.GetCorpReturnAppViewData(custid, challanno);
            }
            catch { return new DataTable(); }
        }

        public void InsertAppv(string total, string custid, string challanNo, string pk )
        {
            try
            {
                DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
                adp.UpdateCorpReturnFirstTableAccApp(decimal.Parse(total), int.Parse(custid), challanNo, int.Parse(pk));
            }
            catch { }
        }

        public DataTable GetDataforAccAdj()
        {
            try
            {
                ERP_SAD_sprERPCorpReturnAmountAccAdjustTableAdapter adp = new ERP_SAD_sprERPCorpReturnAmountAccAdjustTableAdapter();
                return adp.GetErpCorpSalesACAdjData();
            }
            catch { return new DataTable(); }
        }


        public void InsertDataToJVBill(int custid, decimal ttlamount, string message)
        {
            try
            {
                tblRemoteDistributorBillJVTableAdapter adp = new tblRemoteDistributorBillJVTableAdapter();
                adp.ErpCorpSalesInsertJVAmount(custid, ttlamount, message);
        }
            catch { }
        }

        public string JVCreate(DateTime dtedate, string message)
        {
           
            string msg = "";
            try
            {
                RemoteDistributorAllBillJVTableAdapter adp = new RemoteDistributorAllBillJVTableAdapter();
                adp.GetJVSubmit(dtedate, message, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }


        public void InsertAccAdjAmnt(int custid, string challanno)
        {
            try
            {
                DataTableCorpReturnViewTableAdapter adp = new DataTableCorpReturnViewTableAdapter();
                adp.UpdateCorpReturnTAmount( custid, challanno);
        }
            catch {  }
        }

        public DataTable GetCustomerName(int intcustid)
        {
            try
            {
                tblAFBLCorporateSalesProductTableAdapter adp = new tblAFBLCorporateSalesProductTableAdapter();
                return adp.GetCustomerName(intcustid);
            }
            catch { return new DataTable(); }
        }



        public static DataTable GetProceedPermission(int intEnroll)
        {
            GetErpCorpUserProceedPermissionTableAdapter adp = new GetErpCorpUserProceedPermissionTableAdapter();
            try
            {
                return adp.GetUserPermissionofProceed(intEnroll);
            }
            catch { return new DataTable(); }
        }



        public static DataTable GetProceedPermissionApp(int intEnroll)
        {
            GetErpCorpUserProceedPermissionTableAdapter adp = new GetErpCorpUserProceedPermissionTableAdapter();
            try
            {
                return adp.GetUserPermissionofProceedApp(intEnroll);
            }
            catch { return new DataTable(); }
        }


        public static DataTable GetProceedPermissionACAdj(int intEnroll)
        {
            GetErpCorpUserProceedPermissionTableAdapter adp = new GetErpCorpUserProceedPermissionTableAdapter();
            try
            {
                return adp.GetUserPermissionofProceedACAdj(intEnroll);
            }
            catch { return new DataTable(); }
        }



        public DataTable ProductPrice(int Itemid, int CustId, int ItemUom, int salestype)
        {
            ERP_Production_GetItemPriceTableAdapter adp = new ERP_Production_GetItemPriceTableAdapter();
            try
            {
                return adp.GetProductPricePerCustomerData(Itemid, CustId, ItemUom, salestype);
            }
            catch { return new DataTable(); }
        }


        public DataTable GetProductUOM(int itemProductID, int itemCustID, int intPriceVar, int intSalesType, string dteDate)
        {
            ERP_SAD_sprGetUOMRelationByProductTableAdapter adp = new ERP_SAD_sprGetUOMRelationByProductTableAdapter();
            try
            {
                return adp.GetUOMIdData(itemProductID, itemCustID, intPriceVar, intSalesType, dteDate);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetLoanCustomer(string customer)
        {
            DataTableSADCUSTTableAdapter adp = new DataTableSADCUSTTableAdapter();
            try
            {
                return adp.GetCustomerVehicleLoanId(customer);
            }
            catch
            {
                return new DataTable();
            }
        }

        public void JVCreateVehicleLoan()
        {
           try
            {
                ERP_Production_sprVehicleAdjustmentJVTableAdapter adp = new ERP_Production_sprVehicleAdjustmentJVTableAdapter();
                adp.GetVehicleLoanJV();
            }
            catch { }
        }



        public DataTable GetCoprReturnReport(int intcustid, int intprodid, DateTime dtefrom, DateTime dteto)
        {
            Erp_Remote_sprAFBLCorporateDamageReportSalesVSDamageTableAdapter adp = new Erp_Remote_sprAFBLCorporateDamageReportSalesVSDamageTableAdapter();
            try
            {
                return adp.GetCorpReturnReportData(intcustid, intprodid, dtefrom, dteto);   
            }
            catch
            {
                return new DataTable();
            }
        }

        public string DeleteCorpSales(int pk)
        {
            string msg = "";
            TblERPCorpReturnFirstTableAdapter adp = new TblERPCorpReturnFirstTableAdapter();
            try
            {
                adp.DeleteCorpSalesReturn(pk);
                return msg = "Deleted Successfully";
            }
            catch(Exception ex)
            {
                msg = ex.ToString();
                return msg;
            }
        }























    }

    
}


