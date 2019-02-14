using SCM_DAL.IndentTDSTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class StoreIssue_BLL
    {
        public DataTable GetViewData(int part, string xml, int Wh, int reqId, DateTime dteDate, int enroll)
        {
            string message = null;
            try
            {
                SprStoreIssueTableAdapter adp = new SprStoreIssueTableAdapter();
                return adp.GetStoreIssueData(part, xml, Wh, reqId, dteDate, enroll, ref message);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

            
        }

        public DataTable GetDepartment(int intWH)
        {
       
            try
            {
                GetDepartmentTableAdapter adp = new GetDepartmentTableAdapter();
                return adp.GetDepartment(intWH);
            }
            catch (Exception e)
            {
                return new DataTable();
            }


        }




        public DataTable GetIssueItem(int intItemId, int intwh, DateTime dteFrom, DateTime dteTo)
        {
            string strMsg = "";
            try
            {

                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetIssueItem(intItemId,intwh,dteFrom,dteTo);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
        public string StoreIssue(int part, string xml, int Wh, int reqId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprStoreIssueTableAdapter adp = new SprStoreIssueTableAdapter();
                adp.GetStoreIssueData(part, xml, Wh, reqId, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public DataTable GetMasterItem(string strSearchKey)
        {
            TblItemMasterListTableAdapter adpCOA = new TblItemMasterListTableAdapter();
            return adpCOA.GetMasterItemData(strSearchKey);
        }

        public DataTable GetWH(int enroll,int whId)
        {
            try
            {
                TblWearHouseTableAdapter adpCOA = new TblWearHouseTableAdapter();
                return adpCOA.GetWhByUnitForDistribution(enroll, whId);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetDataByWhId(int intWhId)
        {
            try
            {
                TblWearHouseTableAdapter adpCOA = new TblWearHouseTableAdapter();
                return adpCOA.GetDataByWhId(intWhId);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetWhByLocation(int Wh)
        {
            try
            {
                TblWearHouseTableAdapter adpCOA = new TblWearHouseTableAdapter();
                return adpCOA.GetDataByWhLocation(Wh);
            }
            catch { return new DataTable(); }
        }

        public DataTable getMRRList(int mrrid)
        {
            try
            {
                tblFactoryReceiveMRRItemDetailTableAdapter adpCOA = new tblFactoryReceiveMRRItemDetailTableAdapter();
                return adpCOA.GetData(mrrid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetConsumerReport(int part, int whId, DateTime fromDate, DateTime toDate,int id)
        {
            try
            {
                sprConsumptionReportTableAdapter adp = new sprConsumptionReportTableAdapter();
                return adp.GetData(part,whId, fromDate, toDate, id);
            }
            catch
            {
                return new DataTable();
            }
        }
    }
}