using SCM_DAL.BillingTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCM_DAL.BillingTDS;

namespace SCM_BLL
{
    public class Billing_BLL
    {
        int e;
        private static SprGetCOAChildByUnitDataTable[] tblCOALedger = null;
        private static TblEmployeeDataTable[] tblEmpList = null;
        private static TblSupplierDataTable[] tblSupplierList = null;
        private static TblConfigOtherPartyListDataTable[] tblOtherPartyList = null;

        public DataTable GetAllUnit()
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            try
            { return adp.GetAllUnit(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPOInfo(int intPOID)
        {
            GetPOIntoTableAdapter adp = new GetPOIntoTableAdapter();
            try
            { return adp.GetPOInfo(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAdvAmount(string intPOID)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetAdvAmount(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAdvAmount(int intCOAID)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetLadgerBalance(intCOAID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetNetAmountByPO(string strPONo)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetNetAmountByPO(strPONo); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetLadgerBalance(int intCOAID)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetLadgerBalance(intCOAID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetCOAID(int intSupplierid)
        {
            TblSupplierTableAdapter adp = new TblSupplierTableAdapter();
            try
            { return adp.GetCOAID(intSupplierid); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetChallanByPOID(int intPOID)
        {
            TblSupplierTableAdapter adp = new TblSupplierTableAdapter();
            try
            { return adp.GetChallanByPOID(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetEmpName(int intEnroll)
        {
            TblEmployeeTableAdapter adp = new TblEmployeeTableAdapter();
            try
            { return adp.GetEmpName(intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPaymentApprovalSummaryAllUnitForWeb(int intUnitID, DateTime dteFDate, DateTime dteTDate, int intAction, int intEntryType, int intLevel)
        {
            SprPaymentApprovalSummaryAllUnitForWebTableAdapter adp = new SprPaymentApprovalSummaryAllUnitForWebTableAdapter();
            try
            { return adp.GetPaymentApprovalSummaryAllUnitForWeb(intUnitID, dteFDate, dteTDate, intAction, intEntryType, intLevel); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBillInfoByBillReg(string strBillReg)
        {
            SprPaymentApprovalSummaryAllUnitForWebTableAdapter adp = new SprPaymentApprovalSummaryAllUnitForWebTableAdapter();
            try
            { return adp.GetBillInfoByBillReg(strBillReg); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUnitInfoByBillID(int intBillID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetUnitInfoByBillID(intBillID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDocumentList(int intBillID, int intEntryType)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetDocumentList(intBillID, intEntryType); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetChallanList(int intBillID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetChallanList(intBillID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPOIDByBillID(int intBillID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetPOIDByBillID(intBillID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPODate(int intPOID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetPODate(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemDetailsByPO(int intID, bool ysnPO, int intEntryID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetItemDetailsByPO(intID, ysnPO, intEntryID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetIndentList(int intPOID)
        {
            SprGetDetailInfoForAuditPOPartTableAdapter adp = new SprGetDetailInfoForAuditPOPartTableAdapter();
            try
            { return adp.GetIndentList(intPOID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetMRRInfo(int intMRRID)
        {
            GetMRRInfoTableAdapter adp = new GetMRRInfoTableAdapter();
            try
            { return adp.GetMRRInfo(intMRRID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetMRRItemInfo(int intMRRID)
        {
            GetMRRInfoTableAdapter adp = new GetMRRInfoTableAdapter();
            try
            { return adp.GetMRRItemInfo(intMRRID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDocLByMRRID(int intMRRID)
        {
            GetDocListByMRRTableAdapter adp = new GetDocListByMRRTableAdapter();
            try
            { return adp.GetDocLByMRRID(intMRRID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        











        #region===== Search COA Ledger List =============================================== 
        public string[] AutoSearchCOALedger(string strUnit, string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                int intUnit = int.Parse(strUnit.ToString());
                tblCOALedger = new SprGetCOAChildByUnitDataTable[intUnit];
                SprGetCOAChildByUnitTableAdapter adpCOAList = new SprGetCOAChildByUnitTableAdapter();
                tblCOALedger[e] = adpCOAList.GetPartyLedgerList(intUnit, null, null, null, null, true);
             
                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblCOALedger[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strAccName
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
                        var rows = from tmp in tblCOALedger[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strAccName.ToLower().Contains(prefix) || tmp.intAccID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strAccName
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                        retStr[i] = tbl.Rows[i]["strAccName"] + " [" + tbl.Rows[i]["intAccID"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }
        #endregion=========================================================================

        #region===== Search Employee List =================================================  
        public string[] AutoSearchEmployee(string strUnit, string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                int intUnit = int.Parse(strUnit.ToString());
                tblEmpList = new TblEmployeeDataTable[intUnit];
                TblEmployeeTableAdapter adpEmpList = new TblEmployeeTableAdapter();
                tblEmpList[e] = adpEmpList.GetEmployeeList(intUnit);

                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblEmpList[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
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
                        var rows = from tmp in tblEmpList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }
        #endregion=========================================================================

        #region===== Search Supplier List =================================================  
        public string[] AutoSearchSupplier(string strUnit, string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                int intUnit = int.Parse(strUnit.ToString());
                tblSupplierList = new TblSupplierDataTable[intUnit];
                TblSupplierTableAdapter adpSuppList = new TblSupplierTableAdapter();
                tblSupplierList[e] = adpSuppList.GetSupplierList(intUnit);

                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblSupplierList[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tblSupplierList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strSupplierName.ToLower().Contains(prefix) || tmp.intSupplierID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strSupplierName
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr[i] = tbl.Rows[i]["strSupplierName"] + " [" + tbl.Rows[i]["intSupplierID"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }
        #endregion=========================================================================

        #region===== Search Supplier List =================================================  
        public string[] AutoSearchOtherParty(string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                int intUnit = 1;
                tblOtherPartyList = new TblConfigOtherPartyListDataTable[intUnit];
                TblConfigOtherPartyListTableAdapter adpOtherList = new TblConfigOtherPartyListTableAdapter();
                tblOtherPartyList[e] = adpOtherList.GetOtherParty();

                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblOtherPartyList[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strOtherParty
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
                        var rows = from tmp in tblOtherPartyList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strOtherParty.ToLower().Contains(prefix) || tmp.intID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strOtherParty
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr[i] = tbl.Rows[i]["strOtherParty"] + " [" + tbl.Rows[i]["intID"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }
        #endregion=========================================================================














    }
}
