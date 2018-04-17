using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Support_DAL;
using Support_DAL.PO_Currection_TDSTableAdapters;

namespace Support_BLL
{
    public class PO_Currection_BLL
    {
        int e;        
        private static PO_Currection_TDS.TblSupplierDataTable[] tableSupplierList = null;  

        public DataTable GetItemInfoByPO(int intPOID) 
        {
            GetItemInfoByPOTableAdapter adp = new GetItemInfoByPOTableAdapter();
            try
            { return adp.GetItemInfoByPO(intPOID); }
            catch { return new DataTable(); }
        }
        public DataTable GetShipmentAndOtherInfoByPO(int intPOID)  
        {
            GetShipmentAndOtherTableAdapter adp = new GetShipmentAndOtherTableAdapter();
            try
            { return adp.GetShipmentAndOtherInfoByPO(intPOID); }
            catch { return new DataTable(); }
        }        
        public DataTable GetMRRNoByPO(int intPOID)
        {
            TblFactoryReceiveMRRTableAdapter adp = new TblFactoryReceiveMRRTableAdapter();
            try
            { return adp.GetMRRNoByPO(intPOID); }
            catch { return new DataTable(); } 
        }       
        public DataTable GetSupplierInfoByPO(int intPOID) 
        {
            GetSuppInfoTableAdapter adp = new GetSuppInfoTableAdapter();
            try
            { return adp.GetSupplierInfoByPO(intPOID); }
            catch { return new DataTable(); }
        }        
        public DataTable GetSupplierListByUnit(int intUnitID) 
        {
            TblSupplierTableAdapter adp = new TblSupplierTableAdapter();
            try
            { return adp.GetSupplierListByUnit(intUnitID); }
            catch { return new DataTable(); } 
        }
        public DataTable GetCurrency() 
        {
            TblCurrencyConversionTableAdapter adp = new TblCurrencyConversionTableAdapter();
            try
            { return adp.GetCurrency(); }
            catch { return new DataTable(); }
        }
        public string[] GetSuppList(string intUnitID, string prefix) 
        {
            //intUnitID = "1";
            int unit = Int32.Parse(intUnitID.ToString());
            //Inatialize(intwh);

            tableSupplierList = new PO_Currection_TDS.TblSupplierDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeDataTable[e];
            TblSupplierTableAdapter adpCOA = new TblSupplierTableAdapter();
            tableSupplierList[e] = adpCOA.GetSupplierListByUnit(unit);
            //tableEmplist[e] = adpCOA.GetEmpList(Convert.ToInt32(intUnitID)); 
            //tableEmplist[e] = adpCOA.GetEmpListByUnit();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableSupplierList[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableSupplierList[e]  //[Convert.ToInt32(ht[WHID])]
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
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                    retStr[i] = tbl.Rows[i]["strSupplierName"] + " [" + tbl.Rows[i]["intSupplierID"] + "]";
                } return retStr;
            }
            else { return null; }
        }
        public string UpdatePO(int intPOID, int intSuppid, DateTime dtePODate, int intCurrencyID, int intMRRID, decimal monFreight, decimal monPacking, decimal monDiscount, int intShipment, string strDeliveryAddress, int ysnPartialShip, string strPayTerm, int intCreditDays, int intInstallmentNo, int intInstallmentInterval, int intWarrantyMonth, string strOtherTerms, DateTime dteLastShipmentDate,string potype, int intupdateby )
        { 
            string msg = "";
            SprPOCurrectionTableAdapter adp = new SprPOCurrectionTableAdapter();
            adp.UpdatePO(intPOID, intSuppid, dtePODate, intCurrencyID, intMRRID, monFreight, monPacking, monDiscount, intShipment, strDeliveryAddress, ysnPartialShip, strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, dteLastShipmentDate, potype, intupdateby, ref msg);
            return msg;
            
        }
        public string UpdateItemInfoByPONew(int intPOID, decimal numPOQty, int intItemID, string strSpecification, decimal monRate, decimal monVAT, decimal monAmount,int intupdateby)
        {
            string msg = "";
            SprPOItemInfoChangeTableAdapter adp = new SprPOItemInfoChangeTableAdapter();
            adp.UpdateItemInfoByPO(intPOID, numPOQty, intItemID, strSpecification, monRate, monVAT, monAmount, intupdateby, ref msg);
            return msg;
           
        }
        public DataTable GetProviderListByUnit(int intUnitID)
        {
            TblProviderlistTableAdapter adp = new TblProviderlistTableAdapter();
            try
            { return adp.GetDataTblProviderlistbasedonunit(intUnitID); }
            catch { return new DataTable(); }
        }

        public DataTable GetProviderListByPO(int poid)
        {
            TblsupplierbasePOTableAdapter adp = new TblsupplierbasePOTableAdapter();
            try
            { return adp.GetDataProvider(poid); }
            catch { return new DataTable(); }
        }









    }
}
