using HR_DAL.Document_Inventory.DocumentUploadTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace HR_BLL.Document_Inventory
{
    public class documentupload
    {




        public DataTable DocumentAtachmentType()
        {
            TblDocumentTypeTableAdapter type = new TblDocumentTypeTableAdapter();
            return type.DocumentTypeGetData();
        }

        //public System.Data.DataTable DocumentAtachmentTypedownload()
        //{
        //    TblDocumenDownloadTableAdapter download = new TblDocumenDownloadTableAdapter();
        //    return download.DocumentDownloadGetData();
        //}

       



        public DataTable Employeeinformation(int enroll)
        {
            DataTable1TableAdapter employeeinfo = new DataTable1TableAdapter();
            return employeeinfo.EnrollEmployeeInformationGetData(enroll);
        }

        public DataTable checkpathdata(string path)
        {
            TblHRDocUploadTableAdapter check = new TblHRDocUploadTableAdapter();
            return check.DataCheckGetData(path);
        }

        public DataTable loadpageInfo(int intenroll)
        {
            DataTable2TableAdapter pageload = new DataTable2TableAdapter();
            return pageload.loadpageEmployeeinfoGetData(intenroll);
        }

        public string  DocumnetUploadInsertData(int enroll, string documenttype, string deptname, string path, int intEnroll, int intUnitId, int depertmentid,int docid)
        {
            TblDocumentUploadTableAdapter upload = new TblDocumentUploadTableAdapter();
            upload.DocumentUploadGetData(enroll, documenttype, deptname, path, intEnroll, intUnitId,depertmentid,docid);
            string msg = "Successfully";
            return msg;
        }

        public DataTable UnitName()
        {
            TblUnitTableAdapter unitname = new TblUnitTableAdapter();
            return unitname.UnitNameGetData();
        }

        public DataTable PolicyTypeName(int intunit)
        {
            TblDocumentTypeTableAdapter policyType = new TblDocumentTypeTableAdapter();
            return policyType.PolicyTypeGetData(intunit);
        }
    }
}
