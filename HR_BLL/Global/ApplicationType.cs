using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.ApplicationTypeTDSTableAdapters;
using System.Data;

namespace HR_BLL.Global
{
    public class ApplicationType
    {
        public ApplicationTypeTDS.TblApplicationTypeDataTable GetAllApplicationType()
        {
            TblApplicationTypeTableAdapter ta = new TblApplicationTypeTableAdapter();
            return ta.GetApplicationTypeData();
        }
        public DataTable GetDocumentList()
        {
            try
            {
                TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
                return adp.GetDocTypeListData();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetDocumentList(int enroll)
        {
            try
            {
                TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
                return adp.GetDocListData(enroll);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPathList(int enroll, string doctype)
        {
            try
            {
                TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
                return adp.GetPathListData(enroll, doctype);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPolicyDocument(int type, string policyname, string dept, string version, string filenm, int actionby)
        {
            try
            {
                SprHRPolicyUploadTableAdapter adp = new SprHRPolicyUploadTableAdapter();
                return adp.GetSetPolicyDocumentData(type, policyname, dept, version, filenm, actionby,0,0);
            }
            catch { return new DataTable(); }
        }









        public DataTable GetPolicyDocumentView(int type, string p2, string p3, string p4, string p5, int p6, int p7, int intunit)
        {
            try
            {
                SprHRPolicyUploadTableAdapter adpview = new SprHRPolicyUploadTableAdapter();
                return adpview.GetSetPolicyDocumentData(type, p2, p3, p4, p5, 0,0,intunit);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetPolicyDocumentinsert(int type, string policyname, string deptname, string version, string Dfile, int actionby, int typeid, int unitid)
        {
            try
            {
                SprHRPolicyUploadTableAdapter adpinsert = new SprHRPolicyUploadTableAdapter();
                return adpinsert.GetSetPolicyDocumentData(type, policyname, deptname, version, Dfile, actionby, typeid, unitid);
            }
            catch { return new DataTable(); }
        }
    }
}
