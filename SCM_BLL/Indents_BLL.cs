using SCM_DAL.IndentTDSTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class Indents_BLL
    {
        public DataTable GetIndentApprovalWH(int intEnroll)
        {
            GetIndentApprovalWHTableAdapter adp = new GetIndentApprovalWHTableAdapter();
            try
            { return adp.GetIndentApprovalWH(intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetDataIndentView(int type, string dept, int intReqId, DateTime dteFrom, DateTime dteTo, int intwh)
        {
            SprIndentViewTableAdapter adp = new SprIndentViewTableAdapter();
            try
            { return adp.GetDataIndentView(type, dept, intReqId, dteFrom, dteTo, intwh); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetIndentDetails(int indent)
        {
            GetIndentDataDetailsTableAdapter adp = new GetIndentDataDetailsTableAdapter();
            try
            { return adp.GetIndentDetails(indent); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetDataForIndentApproval(int type, int ReqId, DateTime dteFrom, DateTime dteTo, int intWh)
        {
            SprGetDataForIndentApprovalTableAdapter adp = new SprGetDataForIndentApprovalTableAdapter();
            try
            { return adp.GetDataForIndentApproval(type, ReqId, dteFrom, dteTo, intWh); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetItemStockAndPrice(int type, int ReqId, int wh)
        {
            SprGetItemStockAndPriceTableAdapter adp = new SprGetItemStockAndPriceTableAdapter();
            try
            { return adp.GetItemStockAndPrice(type, ReqId, wh); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable DataView(int type, string xmlunit, int wh, int ReqId, DateTime dteDate, int enroll)
        {
            try
            {
                string strmsg = "";
                SprIndentTableAdapter adb = new SprIndentTableAdapter();
                return adb.GetIndentData(type, xmlunit, wh, ReqId, dteDate, enroll, ref strmsg);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetDepartment()
        {
            try
            {
                string strmsg = "";
                tblDepartmentTableAdapter adb = new tblDepartmentTableAdapter();
                return adb.GetDepartment();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetIndentItemDetails(int indentId, out string message)
        {
            try
            {
                message = "";
                SprIndentItemDetailsTableAdapter adb = new SprIndentItemDetailsTableAdapter();
                return adb.GetData(indentId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return new DataTable();
            }
        }

        public DataTable ProjectParent(int intunit)
        {
            throw new NotImplementedException();
        }

        public string IndentEntry(int Type, string xml, int intWh, int @intReqId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprIndentTableAdapter adp = new SprIndentTableAdapter();
                adp.GetIndentData(Type, xml, intWh, @intReqId, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }
    }
}