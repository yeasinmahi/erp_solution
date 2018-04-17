//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Purchase_DAL.Inventory.SupplierTableAdapters;
////using Purchase_DAL.Inventory.SupplierProfile;
//using System.Data;


//namespace UI.Inventory
//{
//    public class SCM
//    {

//        internal System.Data.DataTable getbankcheck(string Routingnumber)
//        {
//            SupplierBankCheckTableAdapter banckcheck = new SupplierBankCheckTableAdapter();
//            return banckcheck.SUpplierACInfoDump(Routingnumber);

//        }

//        internal System.Data.DataTable getSupt()
//        {
//            SupplierApproval1 SupApvReport = new SupplierApproval1();
//            return SupApvReport.GetSuppAddRequest();

//        }

//        public DataTable GetSupplierProfile()
//        {
//            SupplierProfileTableAdapter adp = new SupplierProfileTableAdapter();

//            return adp.GetSupplierProfileData();

//        }

//        public DataTable GetRequestedSuppInfo(int intSupplierID)
//        {
//            GetRequestedSuppInfoTableAdapter adp = new GetRequestedSuppInfoTableAdapter();
//            return adp.GetRequestedSuppInfo(intSupplierID);
           
//        }

//        //public DataTable GetSuppierProfile();
//        //{
//        //SupplierProfile adp=new SupplierProfile();
//        //  try
//        //    { return adp.GetSupplierProfile(); }
//        //  catch { return new DataTable(); }

//        //}

//        //public void InsertNewSupplier(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID)
//        //{
//        //    try
//        //    {
//        //        tblMasterSupplierDumpTableAdapter adp = new tblMasterSupplierDumpTableAdapter();

//        //        adp.GetInsertSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID);
//        //    }
//        //    catch { }
//        //}

//        public string InsertNewSupplierEdit(string strSuppMasterName,
//            string strOrgAddress,
//            string strOrgMail,
//            string strOrgContactNo,
//            string strOrgFAXNo,
//            string strBusinessType,
//            string strServiceType,
//            string strBIN,
//            string strTIN,
//            string strVATRegNo,
//            string strTradeLisenceNo,
//            string strRrepName,
//            string strRrContactNo,
//            string strPayToName,
//            string strSupplierType,
//            DateTime dteEnlistment,

//            int RequestBy,
//            string strShortName,
//            int BankID,
//            int DistrictID,
//            int BranchID,
//            string strACNO,
//            string strRoutingNo)
//        {

//            SprInsertMasterSupplierFromUITableAdapter adp = new SprInsertMasterSupplierFromUITableAdapter();
//            string msg = "";
//            adp.UpdateMasterSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strRrepName, strRrContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, ref msg);
//            return msg;

//        }



//        internal DataTable EnrollReport(int intRequestBy)
//        {
//            EnrollWiseSupplierTableAdapter adp = new EnrollWiseSupplierTableAdapter();
//            return adp.GetEnrollWiseSupplier(intRequestBy);
//        }
//    }
//}

