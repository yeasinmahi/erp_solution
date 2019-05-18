using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Vat.Mushok11TDSTableAdapters;
using SAD_DAL.Vat;
using System.Data;
using System.Web.UI.WebControls;
using SAD_DAL.Vat.Mushok11NewTableAdapters;
using SAD_DAL.Vat.Mushok1718TDSTableAdapters;

namespace SAD_BLL.Vat
{
    public class Mushok11
    {
        private static Mushok11TDS.tblItemVatDataTable[] tableVatItem = null;
        private static Mushok11TDS.tblItemDataTable[] tableSADItem = null;
        private static Mushok11TDS.tblMaterialNameDataTable[] tableMatrialItem = null;
        private static Mushok11New.tblSupplierListDataTable[] tableSupplier = null;
        int e;
        public Mushok11TDS.SprVatM11SalesInfoDataTable GetInfoBySales(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string type)
        {
            if (code == "" || code.Length <= 9){code = null;}            
            
            bool? isCompleted = null;
            if (type == "act") { isCompleted = false;}            
            else if (type == "com") { isCompleted = true;}


            if (!isCompleted.Value)
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-1000); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(1000); }
            }
            else
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-7); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(6); }
            }

            SprVatM11SalesInfoTableAdapter ta = new SprVatM11SalesInfoTableAdapter();
            return ta.GetData(int.Parse(unitID), fromDate, toDate, isCompleted, code);

        }

        public DataTable getMinfo(int year,int vatid,int mid)
        {
            
            try
            {
                tblMinfoTableAdapter adp = new tblMinfoTableAdapter();
                return adp.GetVatInfo(year, vatid, mid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getTresuaryForcust(int accid)
        {
            try
            {
                sprVATTreasuryDepositForecastTableAdapter adp = new sprVATTreasuryDepositForecastTableAdapter();
                return adp.GetTresuaryReport(accid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCreditnotedetails(int Vatid, int Mid, int year)
        {
            try
            {
                sprCreditNotePrintsTableAdapter adp = new sprCreditNotePrintsTableAdapter();
                return adp.GetCreditPrint(Vatid, Mid, year);
            }
            catch { return new DataTable(); }
        }

        public void getmaterialupdate(int intitemid, int v)
        {
            try
            {
                tblConfigMaterialVAT1TableAdapter adp = new tblConfigMaterialVAT1TableAdapter();
                 adp.GetData(intitemid, v);

            }
            catch { }
        }

        public DataTable getM19Summary(int accid, DateTime dtedate)
        {
            try
            {
                sprVatMonthlyReturnReportForExcelM19TableAdapter adp = new sprVatMonthlyReturnReportForExcelM19TableAdapter();
                return adp.GetM19(accid, dtedate);
            }
            catch { return new DataTable(); }
        }

        public DataTable getVatYear(int accid)
        {
            try
            {
                tblVATAccountLastCounterYearTableAdapter adp = new tblVATAccountLastCounterYearTableAdapter();
                return adp.GetM11Preview(accid);
            }
            catch { return new DataTable(); }
        }

        public DataTable geterrorReport(int Accid, string dtedate)
        {
            
            try
            {
                sprVATChallenGetErrorTableAdapter adp = new sprVATChallenGetErrorTableAdapter();
                return adp.GetErrorReport(Accid,DateTime.Parse(dtedate));
            }
            catch { return new DataTable(); }
        }

        public DataTable getM18Summary(int Accid, int month, int year)
        {
            try
            {
                sprCurrentRegisterM18SummaryTableAdapter adp = new sprCurrentRegisterM18SummaryTableAdapter();
                return adp.GetM18Summary(Accid, month, year);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCurrentRegM18(int Accid, string fromDate, string toDate, int Part)
        {
            try
            {
                sprCurrentRegisterM18TableAdapter adp = new sprCurrentRegisterM18TableAdapter();
                return adp.GetM18(Accid, DateTime.Parse(fromDate), DateTime.Parse(toDate),Part);
            }
            catch { return new DataTable(); }
        }

        public string RebitSave(string xmlString, int Unitid, int Accid, int productid, int userid, DateTime dtedate)
        {
            string msg = "";
            try
            {
                sprRebateForExportTableAdapter adp = new sprRebateForExportTableAdapter();
                 adp.GetData(xmlString, Unitid, Accid, productid, userid, dtedate, ref msg);
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public DataTable getM11M17M18report(int VatAccid, string dtefdate, string dtetdate)
        {
            try
            {
                
                    sprM11ErrorInsertingM17M18TableAdapter adp = new sprM11ErrorInsertingM17M18TableAdapter();
                    return adp.GetM11NotShowM1718(VatAccid, DateTime.Parse(dtefdate), DateTime.Parse(dtetdate));
             
            }
            catch { return new DataTable(); }
        }

        public DataTable getM16report(int VatAccid, string dtefdate, string dtetdate,int part)
        {
            try
            {
                if (part == 1)
                {
                    sprPurchaseRegisterM16SummaryTableAdapter adp = new sprPurchaseRegisterM16SummaryTableAdapter();
                    return adp.GetM16(VatAccid, DateTime.Parse(dtefdate), DateTime.Parse(dtetdate));
                }
                else
                {
                    sprSalesRegisterM17SummaryTableAdapter adp = new sprSalesRegisterM17SummaryTableAdapter();
                    return adp.GetM16(VatAccid, DateTime.Parse(dtefdate), DateTime.Parse(dtetdate));
                }
            }
            catch { return new DataTable(); }
        }

        public DataTable GetSalesSummary(int unitid, int Accid, DateTime dtefdate, DateTime  dtetdate, bool ysnDay, bool ysnMaterial, bool ysnChallan)
        {
            try
            {
                sprGetSalesSummaryDataTableAdapter adp = new sprGetSalesSummaryDataTableAdapter();
                    return adp.GetSalesSummary(unitid, Accid, dtefdate, dtetdate,ysnDay,ysnMaterial,ysnChallan);
            }
            catch { return new DataTable(); }
        }

        public DataTable getPurchaseinfo(int Purid)
        {
            try
            {
                tblMaterialInfoTableAdapter adp = new tblMaterialInfoTableAdapter();
                return adp.GetpurChaseInfo(Purid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getBrandrollSummary(int accid, string fromdate, string todate, int Type, int brandrollid)
        {
            try
            {
                sprBandrollStockTableAdapter adp = new sprBandrollStockTableAdapter();
                return adp.GetBandRollReport(accid,DateTime.Parse(fromdate), DateTime.Parse(todate) , Type, brandrollid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getIssueSummary(DateTime  dtefdate, DateTime  dtetdate, int accid, int type)
        {
            //try
            //{
                if (type == 1)
                {
                    tblIssueSummaryTableAdapter adp = new tblIssueSummaryTableAdapter();
                    return adp.GetByDay((dtefdate.ToString()), (dtetdate.ToString()), accid);
                }
                else if(type == 2)
                {
                    tblIssueSummaryTableAdapter adp = new tblIssueSummaryTableAdapter();
                    return adp.GetbyMaterial((dtefdate.ToString()), (dtetdate.ToString()), accid);
                }
                else 
                {
                    tblIssueSummaryTableAdapter adp = new tblIssueSummaryTableAdapter();
                    return adp.GetTotal(dtefdate,dtetdate, accid);
                }
            //}
            //catch { return new DataTable(); }
        }

        public DataTable getImport(int Itemid,int part)
        {
            try
            {
                if (part == 1)
                {
                    tblExportTableAdapter adp = new tblExportTableAdapter();
                    return adp.GetImport(Itemid);
                }
                else {
                    tblExportTableAdapter adp = new tblExportTableAdapter();
                    return adp.GetMaterialUOM(Itemid);
                }
            }
            catch { return new DataTable(); }
        }

        public DataTable getExportReport(int itemid, string text)
        {
            try
            {
                sprVATRebateForExportStatementTableAdapter adp = new sprVATRebateForExportStatementTableAdapter();
                return adp.GetExprotReb(itemid,DateTime.Parse(text));
            }
            catch { return new DataTable(); }
        }

        public DataTable getinventory(int Accid, string dtefdate, string dtetodate, int? intItem)
        {
            try
            {
                sprGetVatInventoryTableAdapter adp = new sprGetVatInventoryTableAdapter();
                return adp.GetInventory(Accid,DateTime.Parse(dtefdate), DateTime.Parse(dtetodate), intItem);
            }
            catch { return new DataTable(); }
        }

        public DataTable getMatrialItemList(int BOMID)
        {
            try
            {
                tblExportTableAdapter adp = new tblExportTableAdapter();
                return adp.GetItemMaterial(BOMID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getBOMid(int itemid)
        {
            try
            {
                tblExportTableAdapter adp = new tblExportTableAdapter();
                return adp.GetBOMId(itemid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getexportamount(int itemid,int monthid, int yearid)
        {
            try
            {
                tblExportTableAdapter adp = new tblExportTableAdapter();
                return adp.GetData(itemid, monthid, yearid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getBandrollProduct(int accid, int bandrollid)
        {
            try
            {
                tblBandrollProductTableAdapter adp = new tblBandrollProductTableAdapter();
                return adp.GetBandrollProduct(accid, bandrollid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getMType()
        {
            try
            {
                tblConfigMusokTypeTableAdapter adpMtype = new tblConfigMusokTypeTableAdapter();
                return adpMtype.GetMushokType();
            }
            catch { return new DataTable(); }
        }

        public DataTable getImport(int intImportID)
        {
            try
            {
                tblExportTableAdapter adp = new tblExportTableAdapter();
                return adp.GetImportid(intImportID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getmaterialinfo(int intMaterialid)
        {
            try
            {
                tblMaterialInfoTableAdapter adp = new tblMaterialInfoTableAdapter();
                return adp.GetMaterialInfo(intMaterialid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getMatrialproductinfo(int purid)
        {
            try
            {
                tblMaterialProductTableAdapter adp = new tblMaterialProductTableAdapter();
                return adp.GetMatrialProductinfo(purid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getBandrollList(int Accid)
        {
            try
            {
                tblConfigBandrollTableAdapter adpbandroll = new tblConfigBandrollTableAdapter();
                return adpbandroll.GetBandRollname(Accid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getVatChallano(int intyear, string strChallanNo, int intUnitID, int userid,int part)
        {
            try
            {if (part == 1)
                {
                    tblVATSalesCreditTableAdapter adpvatinfo = new tblVATSalesCreditTableAdapter();
                    return adpvatinfo.GetVatChallanInfo(intyear.ToString(), strChallanNo, intUnitID, userid);
                }
                else
                {
                    tblVATSalesCreditTableAdapter adpvatinfo = new tblVATSalesCreditTableAdapter();
                    return adpvatinfo.GetProductInfo(intyear.ToString(), strChallanNo, intUnitID, userid);
                }
            }
            catch { return new DataTable(); }
        }

        public string getDebitnoteCreate(int intM12No1, int intsuppid, string strVehicleTypeNo, int intItem, int intSL, int intM12No2, DateTime strM11DateChallan1, string strItem, decimal numQty, decimal monValue, decimal monSD, decimal monVAT, decimal monRedqty, decimal monNewSD, decimal monNewVAT, string strReason, int unitid, int Accid, int userid, int intYear, decimal monSurCharge, string strSupChallanNo, DateTime strM11DateChallan2)
        {
            string msg = "";
            try
            {
                sprDebitNoteTableAdapter adp = new sprDebitNoteTableAdapter();
                adp.GetData(intM12No1, intsuppid, strVehicleTypeNo, intItem, intSL, intM12No2, strM11DateChallan1, strItem, numQty, monValue, monSD, monVAT, monRedqty, monNewSD, monNewVAT, strReason, unitid, Accid, userid, intYear, strSupChallanNo, strM11DateChallan2);
                msg = "Successfully Save";
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public string BrandrollReceiveEntry(string xmlString, int Accid, int userid,int type)
        {
            
            string msg = "";
            try
            {
                
                sprBrandrollEntryformTableAdapter adp = new sprBrandrollEntryformTableAdapter();
                adp.GetBandrollReceive(xmlString, Accid, userid,type, ref msg);
                msg = "Successfully Save";
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public string BrandrollOrderEntry(string xmlString, string Brandrollorderno, DateTime dtedate, int accid, int userid)
        {
            string msg = "";
            try
            {
                sprBrandrollEntryformTableAdapter adpmaterial = new sprBrandrollEntryformTableAdapter();
                adpmaterial.GetBrandrollDemand(xmlString, Brandrollorderno, dtedate, accid, userid,ref msg );
                msg = "Successfully Save";
            } catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public string  getDestroy(int unitid, int accid, string factory, int userid, int intItemid, string stritem, decimal qty, decimal value2, decimal sd, decimal vat, string remarks,int part)
        {
            string msg = "";
            try
            {
                if (part == 1)
                {

                    sprInsertFinishGoodDestroyTableAdapter adp = new sprInsertFinishGoodDestroyTableAdapter();
                    adp.GetInsertFinishGoodDestroy(unitid, accid, bool.Parse(factory), userid, intItemid, stritem, qty, value2, sd, vat, remarks);
                }
                else
                {
                    sprInsertRawMaterialDestroyTableAdapter adpmaterial = new sprInsertRawMaterialDestroyTableAdapter();
                    adpmaterial.GetData(unitid, accid, bool.Parse(factory), userid, intItemid, stritem, qty, value2, sd, vat, remarks);
                }
                msg = "Successfully Save";
            }
            catch (Exception e) { msg = e.ToString();  }
            return msg;
        }

        public DataTable getUOM(int Unitid)
        {
            try
            {
                tblVatUOMTableAdapter adp = new tblVatUOMTableAdapter();
                return adp.GetUOM(Unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable getTreasuryCode(int part)
        {
            try
            {
                if (part == 1)
                {

                    tblConfigTreasuryDepositCodeTableAdapter adp = new tblConfigTreasuryDepositCodeTableAdapter();
                    return adp.GetData();
                }
                else {
                    tblConfigTreasuryDepositCodeTableAdapter adp = new tblConfigTreasuryDepositCodeTableAdapter();
                    return adp.GetData();
                }

            }
            catch { return new DataTable(); }
        }

        public void getOtherAdjustmententry(DateTime dtedate, string strRemarks, int intUnitID, int userid, decimal monSD, decimal monVAT, decimal monSurCharge, int vatacid, int intType)
        {
            try
            {
                if (intType !=3)
                {

                    tblVATCurrentRegisterM18TableAdapter adp = new tblVATCurrentRegisterM18TableAdapter();
                    adp.GetOtherAdjustment2(dtedate.ToString(),strRemarks,intUnitID,userid,monSD,monVAT,monSurCharge,vatacid);
                }
                else
                {
                    tblVATCurrentRegisterM18TableAdapter adp = new tblVATCurrentRegisterM18TableAdapter();
                    adp.GetOtherAdjustment3(dtedate.ToString(), strRemarks, intUnitID, userid, monSD, monVAT, monSurCharge, vatacid);
                }

            }
            catch {}
        }

        public void getTreasuryEntry(int unitid, int accid, int intType, decimal totalAmount, int userid, string strChallanNo, DateTime dteChallanDate, string strInstrument, DateTime dteInstDate, DateTime dteTransDate)
        {
            try { 
            sprVATTreasuryDepositTableAdapter adp = new sprVATTreasuryDepositTableAdapter();
            adp.GetTreasuryEntry(unitid, accid, intType, totalAmount, userid, strChallanNo, dteChallanDate, strInstrument, dteInstDate, dteTransDate);

             }
            catch {  }
        }

        public DataTable PurchaseEntry(int Accid, int year, int month)
        {
            try
            {
                tblVatMonthlyReturnM19TableAdapter adp = new tblVatMonthlyReturnM19TableAdapter();
                return adp.GetPurchaseYear(Accid, year,month);

            }
            catch { return new DataTable(); }
        }

        public string getCreditnoteCreate(int intM12No, int intCustid, string strCusName, string strCusAddress, string strCusVatReg, string strVehicleTypeNo, int intItem, int intSL, int intM11Challanno, DateTime strM11DateChallan, string strItem, decimal numQty, decimal monValue, decimal monSD, decimal monVAT, decimal monM11Other, decimal monM11VAT, decimal monNewSD, decimal monNewVAT, string strReason, int v1, int v2, int v3, int intYear, decimal monSurCharge)
        {
            string msg = "";
            try
            {
                sprCreditNoteTableAdapter adp = new sprCreditNoteTableAdapter();
                adp.GetCreditNote(intM12No, intCustid, strCusName, strCusAddress, strCusVatReg, strVehicleTypeNo, intItem, intSL, intM11Challanno, strM11DateChallan, strItem, numQty, monValue, monSD, monVAT, monM11Other, monM11VAT, monNewSD, monNewVAT, strReason, v1, v2, v3, intYear, monSurCharge);
                msg = "Successfully";
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
            
        }

        public DataTable getM11PrintExport(int accid, string Names)
        {
            try
            {
                tblM11FullInfoTableAdapter adp = new tblM11FullInfoTableAdapter();
                return adp.GetM11ViewExport(accid,int.Parse(Names));
            }
            catch { return new DataTable(); }
        }

        public string PurchaseEntry(string xmlString, int unitid, int userid, int vataccid, DateTime dtedate, int intType, int factory)
        {
            string msg = "";string  entryid;
            try
            {
                sprPurchaseEntryformTableAdapter adp = new sprPurchaseEntryformTableAdapter();
                 adp.GetPurchaseEntryForm(xmlString, unitid, userid, vataccid, dtedate, intType, factory,ref msg);
            }
            catch (Exception e) { msg = e.ToString();  }
            return msg;

        }

        public DataTable getTreasuryCount(int Vataccid, int intyear, int intMonth)
        {
            try
            {
                tblVATTreasuryDepositTableAdapter adp = new tblVATTreasuryDepositTableAdapter();
                return adp.GetCountTreasury(Vataccid,intyear,intMonth);
            }
            catch { return new DataTable(); }
        }

        public DataTable getTreasuryYear(int intid)
        {
            try
            {
                tblVATTreasuryDepositTableAdapter adp = new tblVATTreasuryDepositTableAdapter();
                return adp.GetTreasuryYearMonth(intid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getUomSad(int Unitid)
        {
            try {
                if (Unitid != 3)
                {
                    tblUOMSADTableAdapter adpuomSad = new tblUOMSADTableAdapter();
                  return  adpuomSad.GetSADUOM(Unitid);
                }
                else
                {
                    tblUOMByATMLTableAdapter adp = new tblUOMByATMLTableAdapter();
                    return adp.GetUOMByATML();
                }
                 
            }
            catch { return new DataTable(); }
        }

        public DataTable getTreasuryRpt(int Accid, DateTime dtefdate, DateTime dtetdate, int intType)
        {
            try
            {
                if (intType == 1)
                {
                    tblVATTreasuryDepositTableAdapter adptr = new tblVATTreasuryDepositTableAdapter();
                    return adptr.GetALL(Accid,dtefdate.ToString(),dtetdate.ToString());
                }
                else if(intType == 2)
                {
                    tblVATTreasuryDepositTableAdapter adptr = new tblVATTreasuryDepositTableAdapter();
                    return adptr.GetSD(Accid, dtefdate.ToString(), dtetdate.ToString());
                }
                else if (intType == 3)
                {
                    tblVATTreasuryDepositTableAdapter adptr = new tblVATTreasuryDepositTableAdapter();
                    return adptr.GetVat(Accid, dtefdate.ToString(), dtetdate.ToString());
                }
                else 
                {
                    tblVATTreasuryDepositTableAdapter adptr = new tblVATTreasuryDepositTableAdapter();
                    return adptr.GetSur(Accid, dtefdate.ToString(), dtetdate.ToString());
                }

            }
            catch { return new DataTable(); }
        }

        public DataTable getChallanprint(string Challanno, int Accid, string userid)
        {
            try
            {
                sprM11FinalPrintTableAdapter adpchallan = new sprM11FinalPrintTableAdapter();
                return adpchallan.GetPrint(Challanno, Accid, int.Parse(userid));

            }
            catch { return new DataTable(); }
        }

        public DataTable getChallanList(int vatAccid)
        {
            try
            {
                qrySalesChallanForM11PrintTableAdapter adpchallan = new qrySalesChallanForM11PrintTableAdapter();
               return  adpchallan.GetChallanList(vatAccid);

            }
            catch { return new DataTable(); }
        }

        public void getProductentry(int intVatItemid, decimal qty, DateTime dtedate, int unitid, int accid, int userid, int intType, int intBandrollid, decimal bandrollQty)
        {
            string msg = "";
            try
            {
                sprVATProductionEntryTableAdapter adp = new sprVATProductionEntryTableAdapter();
                adp.GetProductEntry(intVatItemid, qty, dtedate, unitid, accid, userid, intType, ref msg, intBandrollid, bandrollQty);
            }            
            catch {  }
        }

        public DataTable getPurchseCount(int purchaseid, int intyear, int intmonth)
        {
            try
            {
                tblPurchaseYearmonthTableAdapter adp = new tblPurchaseYearmonthTableAdapter();
                return adp.GetCountPurchase(purchaseid, intyear, intmonth);
            }
            catch { return new DataTable(); }
        }

        public DataTable getMushokCreate(string Challanno, int vatAccid, string strCustVATRegNo, string strFinalDistanitionAddress, string strVehicleRegNo, int? intVatAccountID, DateTime? dteM11DateTime, int intUserID, DateTime? dteChallanDate, int? intUnitID, string strCustomerName)
        {
            try
            {
                sprVATChallanCreateTableAdapter adp = new sprVATChallanCreateTableAdapter();
                return adp.GetVatChallanCreate(Challanno, vatAccid, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, intVatAccountID, dteM11DateTime, intUserID, dteChallanDate, intUnitID, strCustomerName);
            }
            catch { return new DataTable(); }
        }

        public DataTable getProductReport(int unitid, DateTime dtefdate, DateTime dtetdate, int Vataccid,int shorbyid)
        {
            try
            {  if (shorbyid == 1)
                {
                    tblProductionReportTableAdapter adp = new tblProductionReportTableAdapter();
                    return adp.GetProductRptByDay(unitid, dtefdate.ToString(), dtetdate.ToString(), Vataccid);
                }
               else if (shorbyid == 2)
                {
                    tblProductionReportTableAdapter adp = new tblProductionReportTableAdapter();
                    return adp.GetProductionReportByProduct(unitid, dtefdate.ToString(), dtetdate.ToString(), Vataccid);
                }
                else 
                {
                    tblProductionReportTableAdapter adp = new tblProductionReportTableAdapter();
                    return adp.GetProductionReportByProduct(unitid, dtefdate.ToString(), dtetdate.ToString(), Vataccid);
                }
            }
            catch { return new DataTable(); }
        }

        public DataTable getBridgeCheck(int intVatItemid)
        {
            try
            {
                tblItemCheckTableAdapter adpbridge = new tblItemCheckTableAdapter();
                return adpbridge.GetCount(intVatItemid);
            }
            catch { return new DataTable(); }
        }

        public void getProductDelete(int productionId)
        {
            try
            {
                sprVATProductionEntryTableAdapter adpProducts = new sprVATProductionEntryTableAdapter();
                 adpProducts.GetProductDelete(productionId);
                 adpProducts.GetProductWithIssueDelete(productionId);
            }
            catch { }
        }

        public DataTable getBandrollcount(int unitid, int vataccid, int intVatItemid)
        {
            try
            {
                tblItemVatBandrollCountTableAdapter adpbandroll = new tblItemVatBandrollCountTableAdapter();
                return adpbandroll.GetBandrollCount(unitid, vataccid, intVatItemid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getYearmonthpurchase(int Purchaseid)
        {
            
            try
            {
                tblPurchaseYearmonthTableAdapter adpyearmonth = new tblPurchaseYearmonthTableAdapter();
                return adpyearmonth.GetYearMonth(Purchaseid);
            }
            catch { return new DataTable(); }
        }

        public void gepPurchasedelete(int accid, int purchaseid,int typeid)
        {
            try
            {
                sprTempVatCorrectionTableAdapter adpPurchasedelete = new sprTempVatCorrectionTableAdapter();
                 adpPurchasedelete.GetPurchaseCorrection(accid, purchaseid, typeid);
            }
            catch {  }
        }

        public DataTable getMushokList(int intVatItemid)
        {
            try
            {
                tblBandrollListTableAdapter adpbandroll = new tblBandrollListTableAdapter();
                return adpbandroll.GetBandrollList( intVatItemid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getVatChallano(int intYear, int VatAccid, string Mushok)
        {
            try
            {
                sprVATAccountLastCounterTableAdapter adpvat = new sprVATAccountLastCounterTableAdapter();
                return adpvat.GetVatLastCount(intYear, VatAccid, Mushok);
            }
            catch { return new DataTable(); }
        }

        public DataTable getVatAccountS(int Enroll)
        {
            try { tblVatAccountNameTableAdapter adpnew = new tblVatAccountNameTableAdapter();
            return adpnew.GetVatAccount(Enroll); } catch { return new DataTable(); }
        }

        public void InsertVatSD(int intVatItemid, decimal sDCharge, decimal sDPercent, decimal vATPercent, int unitid, int userid, DateTime dtedate, int typeid, int accid, decimal sCPercent)
        {
            try
            {
                tblVATItemDeclaredPriceTableAdapter adpmtype = new tblVATItemDeclaredPriceTableAdapter();
                 adpmtype.GetVatInsert(intVatItemid, sDCharge, sDPercent, vATPercent, unitid, userid, dtedate.ToString(), typeid, accid, sCPercent);
            }
            catch { }
        }

        public DataTable GETMUSOKbom(int intVatItemid)
        {
            try
            {
                tblVATItemDeclaredPricebomTableAdapter ADPBO = new tblVATItemDeclaredPricebomTableAdapter();
                return ADPBO.GetbOM(intVatItemid);

            }
            catch { return new DataTable(); }
        }

        public DataTable getMatriltype()
        {
            try
            {
                tblConfigMaterialTypeTableAdapter adpmtype = new tblConfigMaterialTypeTableAdapter();
                return adpmtype.GetMatrialType();
            }
            catch { return new DataTable(); }
        }

        public void getM11insert(string sallername, string strSallerAddress, string strVATNo, string strCustomerName, string strCustAddress, string strCustVATRegNo, string strFinalDistanitionAddress, string strVehicleRegNo, int intVatChallanNo, DateTime dteSVDateTime, DateTime dteM11DateTime, int intsl, string paname, decimal qty, decimal monSDwithOutPrice, decimal monSDAmount, decimal monTotalSDAmount, decimal monVatAmount, decimal amount, decimal monSurChargeAmount, int intYear, int intUnitID, int intTypeID, int intSVUnit, int VatAccid)
        {
            try
            {
                tblm11FullInfoTableAdapter adpM11inser = new tblm11FullInfoTableAdapter();
                adpM11inser.GetM11Insert(sallername, strSallerAddress, strVATNo, strCustomerName, strCustAddress, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, intVatChallanNo, dteSVDateTime, dteM11DateTime, intsl, paname, qty, monSDwithOutPrice, monSDAmount, monTotalSDAmount, monVatAmount, amount, monSurChargeAmount, intYear, intUnitID, intTypeID, intSVUnit, VatAccid);
            }
            catch { }
        }

        public void getM17m18(int intVatChallanNo, DateTime dteSVDateTime, int intVatItemid, decimal qty, decimal monSDwithOutPrice, decimal monSDAmount, decimal monVatAmount, decimal amount, decimal monSurChargeAmount, int intUnitID, int userid, int intTypeID, string strCustomerName, string strCustVATRegNo, string strCustAddress, string strFinalDistanitionAddress, int Vataccid)
        {
            try
            {
                sprM17M18InsertTableAdapter adpM17m18insert = new sprM17M18InsertTableAdapter();
                adpM17m18insert.GetM17M18Insert(intVatChallanNo.ToString(),intVatChallanNo.ToString(), dteSVDateTime, intVatItemid,intVatItemid, qty, 
                monSDwithOutPrice, monSDAmount, monVatAmount, amount, monSurChargeAmount, intUnitID, 
                userid, intTypeID, strCustomerName, strCustVATRegNo, strCustAddress, strFinalDistanitionAddress, Vataccid);
            }
            catch { }
        }

        public void getItemBridge(int intSadItemid, int intVatItemid, int Accid, int userId)
        {
            try
            {
                tblItemVatConfigTableAdapter adpBridge = new tblItemVatConfigTableAdapter();
                 adpBridge.GetItemBridge(intSadItemid, intVatItemid, Accid, userId);
            }
            catch {  }
        }

        public DataTable getPurchaseReport(int unitid, int Accid, DateTime dtefdate, DateTime dtetdate, bool ysnDay, bool ysnMaterial, bool ysnChallan, bool ysnMaterialTotal)
        {
            try
            {
               sprGetPurchaseSummaryDataTableAdapter adpBridge = new sprGetPurchaseSummaryDataTableAdapter();
               return  adpBridge.GetPurchaseReport(unitid, Accid, dtefdate, dtetdate, ysnDay,ysnMaterial,ysnChallan,ysnMaterialTotal);
            }
            catch { return new DataTable(); }
        }

        public void insertBomConfig(int intItemid, int intMatrialid, string totalQty, string wastage, string values, int unitid, int userid, int iNTBOMID, int accid)
        {
            try
            {
                tblConfigItemBOMTableAdapter adpbom = new tblConfigItemBOMTableAdapter();
                adpbom.GetInsertBOM(intItemid, intMatrialid,decimal.Parse(totalQty),decimal.Parse(wastage),decimal.Parse(values), unitid, userid, iNTBOMID, accid);
            }
            catch { }
        }

        public void getType2(decimal sDCharge, decimal sDPercent, decimal vATPercent, string wholeSales, int intVatItemid, int accid)
        {
            try
            {
                tblItemVat2TableAdapter adpbom = new tblItemVat2TableAdapter();
                adpbom.GetType2(sDCharge, sDPercent, vATPercent, decimal.Parse(wholeSales), intVatItemid, accid);
            }
            catch { }
        }

        public void getMushokDepot(int unitid, int vatAccid, int intVatItemid, int mtype, int vatCount)
        {
            try
            {
                sprInsertItemMaterialForDepotFromDeclarationTableAdapter adpvcount = new sprInsertItemMaterialForDepotFromDeclarationTableAdapter();
                adpvcount.GetDepotDeclar(unitid, vatAccid, intVatItemid, mtype, vatCount);
            }
            catch { }
        }

        public DataTable getMushcount(int intVatItemid)
        {
            try
            {
                tblVatCountTableAdapter adpcount = new tblVatCountTableAdapter();
            return adpcount.GetCount(intVatItemid);
            }
            catch { return new DataTable(); }
        }

        public void getType4(decimal sDCharge, int intVatItemid, int accid)
        {
            try
            {
                tblItemVat3TableAdapter adpbom = new tblItemVat3TableAdapter();
                adpbom.GetType4(sDCharge, intVatItemid, accid);
            }
            catch { }
        }

        public void getType1(decimal sDCharge, decimal sDPercent, decimal vATPercent, string wholeSales, string mrr, decimal sCPercent, int intVatItemid, int accid)
        {
            try
            {
                tblItemVat1TableAdapter adpbom = new tblItemVat1TableAdapter();
                adpbom.GetData(sDCharge, sDPercent, vATPercent,decimal.Parse(wholeSales), decimal.Parse(mrr), sCPercent, intVatItemid, accid);
            }
            catch { }
        }

        public void PrintCompleted(string userId,string id)
        {
            SprVatM11SalesInfoTableAdapter ta = new SprVatM11SalesInfoTableAdapter();
            ta.Printed(int.Parse(userId), int.Parse(id));
        }

        public Mushok11TDS.SprVatChallanInfoDataTable GetVatChallanInfo(string id, string userId, string separator, ref DateTime date, ref string unitName
            , ref string unitAddress, ref string userName, ref string challanNo, ref string customerName
            , ref string customerPhone, ref string delevaryAddress, ref string otherInfo
            , ref string vehicle, ref string extra, ref decimal? extAmount, ref string propitor
            , ref string driver, ref string driverPh, ref string charge, ref string logistic, ref string incentive)
        {
            SprVatChallanInfoTableAdapter ta = new SprVatChallanInfoTableAdapter();
            DateTime? dt = null;
            Mushok11TDS.SprVatChallanInfoDataTable table = ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref extra, ref extAmount, ref propitor, ref driver, ref driverPh, ref charge, ref logistic, ref incentive);
            date = dt.Value;
            return table;
        }

        public void getVatitemcreate(int unitid, string Itemname, int userid, int uomid, string UOMName, string strHscode, bool ysntxt, int VatAccid)
        {
            try
            {
                tblVatItemCrateTableAdapter adpItemcreate = new tblVatItemCrateTableAdapter();
                adpItemcreate.GetVatItemInsert(unitid, Itemname, userid, uomid, UOMName, strHscode, ysntxt, VatAccid);
            }
            catch { }
        }

        public DataTable getPriceDetails(int intVatItemid, int mushoktype, DateTime dtedate)
        {
            try
            {
                sprGetVATDeclaredPriceM1TableAdapter adpmushok = new sprGetVATDeclaredPriceM1TableAdapter();
                return adpmushok.GetItemView(intVatItemid, mushoktype, dtedate);
            }
            catch { return new DataTable(); }
        }

        public void GetMatrialCreate(string strMaterialName, string strUOM, int intUnitID, int USERENROLL, int intMaterialTypeID, int intVatAccountID, bool ysntxt)
        {
            try
            {
                tblVatMatrialINsertTableAdapter adpItemcreate = new tblVatMatrialINsertTableAdapter();
                adpItemcreate.GetVatMatrialInsert(strMaterialName, strUOM, intUnitID, USERENROLL, intMaterialTypeID, intVatAccountID, ysntxt);
            }
            catch { }
        }

        public void getuomupdate(string UOMname, int Uomid,int unitid, int Accid, int intItemid)
        {
            try
            {
                tblUomidUpdateTableAdapter adpItemcreate = new tblUomidUpdateTableAdapter();
                adpItemcreate.GetUomUpdate(UOMname, Uomid, unitid, Accid, intItemid);
             }
            catch { }
        }
        public string[] getVatItemList(string prefix,int Accid)
        {
           
            tableVatItem = new Mushok11TDS.tblItemVatDataTable[Convert.ToInt32(Accid)];
            tblItemVatTableAdapter Vatitem = new tblItemVatTableAdapter();
            tableVatItem[e] = Vatitem.GetData(Accid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableVatItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strVatProductName
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
                     int c=int.Parse(tableVatItem[e].Rows.Count.ToString());
                        var rows = from tmp in tableVatItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strVatProductName.ToLower().Contains(prefix)
                                   orderby tmp.strVatProductName
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }
                    }
                    catch{  return null; }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strVatProductName"] + "," + "[" + tbl.Rows[i]["intID"] + "]";
                }
                return retStr;
            }
            else
            {
                return null;
            }
        }
        public string[] getMatrialItemList(string prefix, int Accid)
        {          
            tableMatrialItem = new Mushok11TDS.tblMaterialNameDataTable[Convert.ToInt32(Accid)];
            tblMaterialNameTableAdapter MatrialItem = new tblMaterialNameTableAdapter();
            tableMatrialItem[e] = MatrialItem.GetMatrialName(Accid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableMatrialItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strMaterialName
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
                        var rows = from tmp in tableMatrialItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strMaterialName.ToLower().Contains(prefix)
                                   orderby tmp.strMaterialName
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
                    retStr[i] = tbl.Rows[i]["strMaterialName"] + "," + "[" + tbl.Rows[i]["intMaterialID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
      
        public string[] getSadItem(string prefix, int Unitid)
        {
            tableSADItem = new Mushok11TDS.tblItemDataTable[Convert.ToInt32(Unitid)];
            tblItemTableAdapter SADItem = new tblItemTableAdapter();
            tableSADItem[e] = SADItem.GetData(Unitid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableSADItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strProductName
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
                        var rows = from tmp in tableSADItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strProductName.ToLower().Contains(prefix)
                                   orderby tmp.strProductName
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
                    retStr[i] = tbl.Rows[i]["strProductName"] + "," + "[" + tbl.Rows[i]["intid"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }
        public string[] getSupplierList(string prefix, int Unitid)
        {
            tableSupplier = new Mushok11New.tblSupplierListDataTable[Unitid];
            tblSupplierListTableAdapter MatrialItem = new tblSupplierListTableAdapter();
            tableSupplier[e] = MatrialItem.GetSupplierList(Unitid);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableSupplier[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strSupplierName
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
                        var rows = from tmp in tableSupplier[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strSupplierName.ToLower().Contains(prefix)
                                   orderby tmp.strSupplierName
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
                    retStr[i] = tbl.Rows[i]["strSupplierName"] + "," + "[" + tbl.Rows[i]["intSupplierID"] + "]";
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
