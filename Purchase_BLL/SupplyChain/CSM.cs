using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Inventory.SupplierTableAdapters;
using Purchase_DAL.BusinessUnit;
//using Purchase_DAL.Inventory.SupplierProfile;
using System.Data;
using Purchase_DAL.BusinessUnit.BussUnitTableAdapters;
using Purchase_DAL.Inventory.ItemTableAdapters;
namespace Purchase_BLL.SupplyChain
{
    public class CSM
    {

        public string UpdateReject(int intDocID)
        {
            string msg1 = "Reject Successfully";
            UpdateRejectTableAdapter adp = new UpdateRejectTableAdapter();
            adp.UpdateYsnReject(intDocID);
            return msg1;
        }

        public string UpdateDeliver(int intDocID)
        {
            string msg1 = "Update Successfully";
            UpdateDeliverTableAdapter adp = new UpdateDeliverTableAdapter();
            adp.UpdateYsnDeliver(intDocID);
            return msg1;
        }

        public DataTable GetDocHistory()
        {
            GetDocHistoryTableAdapter adp = new GetDocHistoryTableAdapter();
            var temp = adp.GetDocHisData();
            return temp;
        }
        public void InsertTask(int intDocID, int intEnroll, int intActionBy)
        {
            //string msg = "";
            InsertDocDataTableAdapter adp = new InsertDocDataTableAdapter();
            adp.InsertDocHisData(intDocID, intEnroll, intActionBy);

        }

        public DataTable GetDepartment(int intEmployeeID)
        {
            GetDepartmentTableAdapter adp = new GetDepartmentTableAdapter();
            var temp = adp.GetDept(intEmployeeID);
            return temp;
        }
        public DataTable GetDocTypes()
        {
            GetDocTypesTableAdapter adp = new GetDocTypesTableAdapter();
            var temp = adp.GetDocType();
            return temp;
        }

        public DataTable GetDocDetailsData(int intEmployeeID, int intDocTypeId)
        {
            GetDocDetailsDataTableAdapter adp = new GetDocDetailsDataTableAdapter();
            var temp = adp.GetDocDetails(intEmployeeID, intDocTypeId);
            return temp;
        }
        public DataTable GetDocDetailsData(int intSuppMasterId)
        {
            tblSupplierDocListTableAdapter adp = new tblSupplierDocListTableAdapter();
            return adp.GetDocListBySupplyId(intSuppMasterId);
        }

        internal System.Data.DataTable getbankcheck(string Routingnumber)
        {
            SupplierBankCheckTableAdapter banckcheck = new SupplierBankCheckTableAdapter();
            return banckcheck.SUpplierACInfoDump(Routingnumber);


        }

        //internal System.Data.DataTable getSupt()
        //{
        //    SupplierApproval1 SupApvReport = new SupplierApproval1();
        //    return SupApvReport.GetSuppAddRequest();

        //}

        public DataTable GetSupplierProfile(string searchkey)
        {
            SupplierProfileTableAdapter adp = new SupplierProfileTableAdapter();

            return adp.GetSupplierProfileData(searchkey);

        }

        public DataTable GetAllSupplierProfile()
        {
            SupplierProfileTableAdapter adp = new SupplierProfileTableAdapter();

            return adp.GetAllSupplier();

        }

        public DataTable GetRequestedSuppInfo(int intRequestSupID)
        {
            GetRequestedSuppInfoTableAdapter adp = new GetRequestedSuppInfoTableAdapter();
            return adp.GetRequestedSuppInfo(intRequestSupID);
        }


        //public DataTable GetSuppierProfile();
        //{
        //SupplierProfile adp=new SupplierProfile();
        //  try
        //    { return adp.GetSupplierProfile(); }
        //  catch { return new DataTable(); }

        //}

        //public void InsertNewSupplier(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName,string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID)
        //{
        //    try
        //    {
        //        tblMasterSupplierDumpTableAdapter adp = new tblMasterSupplierDumpTableAdapter();

        //        adp.GetInsertSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName,strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID);
        //    }
        //    catch { }
        //}

        public string InsertNewSupplierEdit(string strSuppMasterName,
            string strOrgAddress,
            string strOrgMail,
            string strOrgContactNo,
            string strOrgFAXNo,
            string strBusinessType,
            string strServiceType,
            string strBIN,
            string strTIN,
            string strVATRegNo,
            string strTradeLisenceNo,
            string strRrepName,
            string strRrContactNo,
            string strPayToName,
            string strSupplierType,
            DateTime dteEnlistment,

            int RequestBy,
            string strShortName,
            int BankID,
            int DistrictID,
            int BranchID,
            string strACNO,

            string strRoutingNo,
            int MasterId
            )
        {

            SprInsertMasterSupplierFromUITableAdapter adp = new SprInsertMasterSupplierFromUITableAdapter();
            string msg = "";
            adp.UpdateMasterSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strRrepName, strRrContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, ref msg, MasterId);
            //adp.sprInsertMasterSupplierFromUI(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID, ref msg);
            return msg;

        }

        public string    INSERTMasterItemlistCreate(string strName, string strDescription, string strPartNo, string strBrand, int intClusterId, int intCommodityId, int intCategoryId, string strUoM, int enroll, string strModel, string strOrigin, string strSpecification)
        {
            int? ids = 0;

            try
            {
                sprItemMasterListCreateTableAdapter ins = new sprItemMasterListCreateTableAdapter();
                ins.GetItemMasterCreate(strName, strDescription, strPartNo, strBrand, intClusterId, intCommodityId, intCategoryId, strUoM, enroll,strModel,  strOrigin,strSpecification);

            }
            catch(Exception e) { ids = 0; }
            return ids.ToString();
            
         }

        public DataTable EnrollWiseSupplier(int intRequestBy)
        {
            EnrollWiseSupplierTableAdapter adp = new EnrollWiseSupplierTableAdapter();
            return adp.GetEnrollWiseSupplier(intRequestBy);
        }

        //internal DataTable GetRequest()
        //{
        //    GetRequestedSuppInfoTableAdapter adp = new GetRequestedSuppInfoTableAdapter();
        //    return adp.GetRequestedSuppInfo();

        //}

        public DataTable getbankcheckNo(string Routingnumber)
        {
            SupplierBankCheckTableAdapter banckcheck = new SupplierBankCheckTableAdapter();

            return banckcheck.SUpplierACInfoDump(Routingnumber);

        }

        public DataTable getReport()
        {
            SupplierApproval1 SupApvReport = new SupplierApproval1();
            return SupApvReport.GetSuppAddRequest();
        }

        //////public void InsertNewSuppliernew(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID)
        //////{
        //////    try
        //////    {
        //////        tblMasterSupplierDumpTableAdapter adp = new tblMasterSupplierDumpTableAdapter();

        //////        adp.GetInsertSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID);
        //////    }
        //////    catch { }
        //////}

        public string InsertSuppEnlistment(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID, string xml)
        {
            string msg = "";
            SprSupplierEnlistmentTableAdapter adp = new SprSupplierEnlistmentTableAdapter();
            adp.InsertSuppEnlistment(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID, xml, ref msg);
            return msg;
        }

        public DataTable GetCustList(string prefix)
        {
            SearchSupplierProfileTableAdapter custlist = new SearchSupplierProfileTableAdapter();
            try
            {
                return custlist.GetSearchInSupplierMaster(prefix);
            }
            catch
            {
                return new DataTable();
            }
        }



        public DataTable getcount(int enroll)
        {

            GetSupplierPermissionTableAdapter permissionCount = new GetSupplierPermissionTableAdapter();
            return permissionCount.GetSupplierPermission(enroll);

        }


        public DataTable GetIndentList(int intWHID, DateTime dteFromDate, DateTime dteToDate, int number)
        {
            sprIndentPendingApprovalRejectReportTableAdapter adp = new sprIndentPendingApprovalRejectReportTableAdapter();
            return adp.GetIndentApprovalPendingReport(intWHID, dteFromDate, dteToDate, number);
        }


        public DataTable getwarehouse(int intRequestBy)
        {
            GetWHListTableAdapter warehouse = new GetWHListTableAdapter();
            return warehouse.GetWHList(intRequestBy);
        }

        //public DataTable GetIndentDetail(int intWhid,int intIndentid)
        //{
        //    GetIndentDetailTableAdapter getIndent = new GetIndentDetailTableAdapter();
        //    //return getIndent.GetIndentDetailReportforApprove((intWHID, intIndentId);
        //}



        //public DataTable getindentsdetails(int intIndentid)
        //{

        //}

        public DataTable getindentsdetails(int intWhid, int intIndentid)
        {
            GetIndentDetailTableAdapter getindentdetailsrpt = new GetIndentDetailTableAdapter();
            return getindentdetailsrpt.GetIndentDetailReportforApprove(intWhid, intIndentid);
        }

        public DataTable UpdateIndentApprovrd(int Enroll, int intIndentID)
        {
            GetIndentApprovrdTableAdapter IndentApproval = new GetIndentApprovrdTableAdapter();
            return IndentApproval.GetIndentApprovrd(Enroll, intIndentID);
        }

        public DataTable UpdateIndentApproval2(int Enroll, int intIndentID, int intItemid)
        {
            UpdateIndentApproval2TableAdapter IndentApproval2 = new UpdateIndentApproval2TableAdapter();
            return IndentApproval2.UpdateIndentApprovrd2 (Enroll, intIndentID, intItemid);
        }

        public DataTable GetInventoryStatement(int intWHID, DateTime dteFromDate, DateTime dteToDate, int intSearchBy, string strID)

        {
            sprInventoryStatementTableAdapter adp = new sprInventoryStatementTableAdapter();
            return adp.GetInventoryStatement(intWHID, dteFromDate, dteToDate, intSearchBy, strID);
        }



        public DataTable GetItemCategory()
        {
           GetItemCategoryTableAdapter icta = new GetItemCategoryTableAdapter();
           return icta.GetItemCategory();
        }


        public DataTable GetItemSubCategory(int Enroll)
        {
            GetItemSubCategoryTableAdapter it = new GetItemSubCategoryTableAdapter();
            return it.GetItemSubCategory(Enroll); 
        }

        public DataTable GetDataAllBusinessUnit(string searchkey)
        {
            GetAllBusinessUnitTableAdapter ad = new GetAllBusinessUnitTableAdapter();
            return ad.GetDataAllBusinessUnit(searchkey);
        }

        public DataTable SUpplierListforApproval1(int enroll)

        {
            SUpplierListforApproval1TableAdapter sla = new SUpplierListforApproval1TableAdapter();
            return sla.SUpplierListforApproval1(enroll);
        }
        
           
 //      public void tblMasterSupplierApprovalPurchase(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID, int ysnApproved)
 //{
 //   try
 //      {
 //       tblMasterSupplierApprovalPurchaseTableAdapter adp = new tblMasterSupplierApprovalPurchaseTableAdapter();

 //           adp.tblMasterSupplierApprovalPurchase(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID,1);
 //           }
 //           catch { }
 //       }


         //public DataTable GetPurchaseApproval(int intApproved1by, int intSuppMasterID)
         //{
         //    GetPurchaseApprovalTableAdapter SUpPApproval1 = new GetPurchaseApprovalTableAdapter();
         //    return SUpPApproval1.GetPurchaseApproval(intApproved1by, intSuppMasterID);

 
         //}


         public void getSupplierApproval(int enroll, int intSuppid)
         {
             GetPurchaseApprovalTableAdapter SUpPApproval1 = new GetPurchaseApprovalTableAdapter();
             SUpPApproval1.GetPurchaseApproval(enroll,intSuppid); 
         }

         public void GetSuppReject(int enroll, int intSuppid)
         {
             GetSuppRejectTableAdapter SupReject = new GetSuppRejectTableAdapter();
             SupReject.GetSuppReject(enroll, intSuppid);   
         }

         public void InsertSupplierFromPurchase(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName)
         {
             try
             {
                 InsertSupplierFromPurchaseTableAdapter adp = new InsertSupplierFromPurchaseTableAdapter();

                 adp.InsertSupplierFromPurchase(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName);
             }
             catch { }   
         }

         public DataTable GetRequest1()
         {
             RequestedSupplierTableAdapter adp = new RequestedSupplierTableAdapter();
             return adp.RequestedSupplierAll();
         }


         //public void INSERTMASTERSUPPLIERFINAL(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName)
         //{
         //    INSERTMASTERSUPPLIERFINALTableAdapter ISM = new INSERTMASTERSUPPLIERFINALTableAdapter();

         //    ISM.INSERTMASTERSUPPLIERFINAL(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, (dteEnlistmentDate.ToString()), intRequestBy, strShortName);
         //}

         //public void UpdateMasterSupplier(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo,int intBankID, int intDistrictID, int intBranchID)
         //{
         //    SprInsertMasterSupplierFromUITableAdapter ISM = new SprInsertMasterSupplierFromUITableAdapter();

         //    ISM.UpdateMasterSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, (dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, intBankID, intDistrictID, intBranchID);
         //}


         public void InsertSupplierMaster(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistment, int RequestBy, string strShortName)
         {
             try
             {
                 InsertSupplierMasterTableAdapter adp = new InsertSupplierMasterTableAdapter();

                 adp.InsertSupplierMaster(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistment.ToString()), RequestBy, strShortName);
             }
             catch { }
         }

         public void InsertSupplierDumpForeign(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName)
         {
             try
             {
                 InsertSupplierDumpForeignTableAdapter adp = new InsertSupplierDumpForeignTableAdapter();

                 adp.InsertSupplierDumpForeign(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName,strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName);
             }
             catch { }
        
         }


         public DataTable GetDataAllUnit()
         {
             GetDataAllUnitTableAdapter adp = new GetDataAllUnitTableAdapter();
             return adp.GetDataAllUnit();
         }

         //public void InsertTblUnit(string strUnit, string strDescription, int intLastActionBy, string strVATRegNo, string strTIN, string strIRC, string strBusinessArea, int intParentUnit, string strAccEmailAddress, string intIRCRenewYear, string strPhone, string strFax, int intOwnershipType)
         //{
         //    try
         //    {
         //        InsertTblUnitTableAdapter adp = new InsertTblUnitTableAdapter();

         //        adp.InsertTblUnit(strUnit, strDescription, intLastActionBy, strVATRegNo, strTIN, strIRC, strBusinessArea, intParentUnit, strAccEmailAddress, intIRCRenewYear, strPhone, strFax, intOwnershipType);
         //    }
         //    catch { }




         public void InsertBussUnit(string strUnit, string strDescription, int intLastActionBy, string strVATRegNo, string strTIN, string strIRC, string strBusinessArea, string strAccEmailAddress, string intIRCRenewYear, int intOwnershipType, string strPhone, int intParentUnit, ref string msg)
         {
             try
             {
                 sprAddNewBussUnitTableAdapter ibu = new sprAddNewBussUnitTableAdapter();

                 ibu.InsertAddNewBussUnit(strUnit, strDescription, intLastActionBy, strVATRegNo, strTIN, strIRC, strBusinessArea, strAccEmailAddress, intIRCRenewYear, intOwnershipType, strPhone, intParentUnit, ref msg);
             }
             catch { }
         }

         public DataTable getUnitName()
         {
             GetUnitListTableAdapter getunitnamelist = new GetUnitListTableAdapter();
             return getunitnamelist.GetUnitList();
            
         }

         public void InsertSupplierDumpFTempory(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName)
         {
             try
             {
                 InsertSupplierDumpForeignTableAdapter adp = new InsertSupplierDumpForeignTableAdapter();

                 adp.InsertSupplierDumpForeign(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName);
             }
             catch { }
         }

         public void InsertMasterSupplierTempory(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName)
         {
             try
             {
                 InsertMasterSupplierTemporyTableAdapter adp = new InsertMasterSupplierTemporyTableAdapter();

                 adp.InsertMasterSupplierTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName);
             }
             catch { }
         }

         public DataTable GetDataCluster() 
         {
             GetDataClusterTableAdapter adp = new GetDataClusterTableAdapter();
             try
             { return adp.GetDataCluster(); }
             catch { return new DataTable(); }
         }
         public DataTable GetDataCommodity(int intClusterid)
         {
             GetDataCommodityTableAdapter adp = new GetDataCommodityTableAdapter();
             try
             { return adp.GetDataCommodity(intClusterid); }
             catch { return new DataTable(); }
         }        

         public DataTable GetRequisitionReport()
         {
           
              GetRequisitionReportTableAdapter it = new GetRequisitionReportTableAdapter();
             return it.GetRequisitionReport();
          }
        
         public List<string> AutoSearchItemData(string strSearchKeyemp)
         {
             List<string> result = new List<string>();
             GetItemAutoSearchTableAdapter employeelist = new GetItemAutoSearchTableAdapter();
             DataTable oDT2 = new DataTable();
             oDT2 = employeelist.GetItemAutoSearch(strSearchKeyemp);
             if (oDT2.Rows.Count > 0)
             {
                 for (int index = 0; index < oDT2.Rows.Count; index++)
                 {
                     result.Add(oDT2.Rows[index]["strItemMasterName"].ToString());
                 }

             }
             return result;
         }



         ////public string InsertNewSupplierEdit(string strName, string strDescription, string strPartNo, string strBrand, string strUoM, string strCluster, string strComGroupName, string strCategory)
         //{
             
         //}

         public DataTable GetDataCategory(int intCommodityId)
         {
             GetCategoryTableAdapter adp = new GetCategoryTableAdapter();
             try
             { return adp.GetDataCategory(intCommodityId); }
             catch { return new DataTable(); }
         }
       

         public void INSERTMasterItemlist(string strName, string strDescription, string strPartNo, string strBrand, int intClusterId, int intCommodityId, int intCategoryId, string strUoM, int enroll)
         {
             INSERTMasterItemTableAdapter ins = new INSERTMasterItemTableAdapter();
             ins.INSERTMasterItem(strName, strDescription, strPartNo, strBrand, intClusterId, intCommodityId, intCategoryId, strUoM, enroll);
         }

         public DataTable GetDataUoM()
         {
             GetUoMTableAdapter adp = new GetUoMTableAdapter();
             try
             { return adp.GetDataUoM(); }
             catch { return new DataTable(); }
         }


         public DataTable GetItemAutoSearch(string strSearch)
         {
             GetItemAutoSearchTableAdapter ina = new GetItemAutoSearchTableAdapter();
             try
             { return ina.GetItemAutoSearch(strSearch); }
             catch { return new DataTable(); }
         }
        public string GridSubmitMasterSupplier(int part, int masterid, int enroll)
        {
            string msg = "";
            try
            {
                SprInsertMasterSupplierFromGridTableAdapter adp = new SprInsertMasterSupplierFromGridTableAdapter();
                adp.InsertIntoMasterSupplierFinal(part, masterid, enroll, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public void InsertNewSuppliernew(string strSuppMasterName, string strOrgAddress, string strOrgMail, string strOrgContactNo, string strOrgFAXNo, string strBusinessType, string strServiceType, string strBIN, string strTIN, string strVATRegNo, string strTradeLisenceNo, string strReprName, string strReprContactNo, string strPayToName, string strSupplierType, DateTime dteEnlistmentDate, int intRequestBy, string strShortName, string strACNO, string strRoutingNo, string strBank, string strBranch, int intBankID, int intDistrictID, int intBranchID)
        {
            try
            {
                tblMasterSupplierDumpTableAdapter adp = new tblMasterSupplierDumpTableAdapter();

                adp.GetInsertSupplier(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, Convert.ToString(dteEnlistmentDate.ToString()), intRequestBy, strShortName, strACNO, strRoutingNo, strBank, strBranch, intBankID, intDistrictID, intBranchID);
            }
            catch { }
        }

        public string InsertSupplierApprove(int intSuppMasterID, int intApproveBy)
        {
            string msg = "";
            try
            {
                SprInsertMasterSupplierFromUIForApproveTableAdapter adp = new SprInsertMasterSupplierFromUIForApproveTableAdapter();
                adp.InsertSupplierApprove(intSuppMasterID, intApproveBy, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public DataTable Getwarehouselistpermission(int enrol)
        {
            TblWHPermissionListTableAdapter bll = new TblWHPermissionListTableAdapter();
            try
            { return bll.GetDataWHPermissionlist(enrol); }
            catch { return new DataTable(); }
        }

        public DataTable GetClusterList()
        {
            SprItemSearchCategoryTableAdapter bll = new SprItemSearchCategoryTableAdapter();
            try
            { return bll.GetDataItemSearchCategory(); }
            catch { return new DataTable(); }
        }

        public DataTable GetItemSubcategorylist( int unitid)
        {
            TblItemSubCategoryTableAdapter bll = new TblItemSubCategoryTableAdapter();
            try
            { return bll.GetDataUnitbaseItemSubcategory(unitid); }
            catch { return new DataTable(); }
        }


        public DataTable GetItemDetaills(int itemid)
        {
            TblItemMasterListTableAdapter bll = new TblItemMasterListTableAdapter();
            try
            { return bll.GetDataMasteritemDetaills(itemid); }
            catch { return new DataTable(); }
        }

        public DataTable GetSupplierProfileAllBlockList()
        {
            SupplierBlockListTableAdapter bll = new SupplierBlockListTableAdapter();
            try
            { return bll.GetSupplierProfileAllBlockList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetSupplierProfileAllBlockList(string strSearchKey)
        {
            SupplierBlockListTableAdapter bll = new SupplierBlockListTableAdapter();
            try
            { return bll.GetSupplierProfileBlockListBySearchKey(strSearchKey); }
            catch { return new DataTable(); }
        }
        public DataTable UpdateSupplierInBlock(int intBlockBy, string strBlockRemarks, int intSuppMasterID)
        {
            TblSupplierMaster_SupplierBlockTableAdapter bll = new TblSupplierMaster_SupplierBlockTableAdapter();
            try
            { return bll.UpdateSupplierBlock(intBlockBy, strBlockRemarks, intSuppMasterID); }
            catch { return new DataTable(); }
        }

        






















    }

}


