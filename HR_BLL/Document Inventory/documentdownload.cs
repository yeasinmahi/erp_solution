using HR_DAL.Document_Inventory.DocumentUploadTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace HR_BLL.Document_Inventory
{
    public class documentdownload
    {

        public DataTable PolicyView(int data)
        {
            TblHRPolicyUploadTableAdapter plicy = new TblHRPolicyUploadTableAdapter();
            return plicy.PloicyViewGetData(data);
        }    

        public DataTable EmployerInformation(int enroll)
        {
            DataTable1TableAdapter employeeinfo = new DataTable1TableAdapter();
            return employeeinfo.EnrollEmployeeInformationGetData(enroll);
        }

        public DataTable downloadinformation(int Enroll)
        {
            TblDocumenDownloadTableAdapter downloasdata = new TblDocumenDownloadTableAdapter();
            return downloasdata.DocumentDownloadGetData(Enroll);
        }



        public DataTable loadpageInfo(int intenroll)
        {
            DataTable2TableAdapter loadpageinfo = new DataTable2TableAdapter();
            return loadpageinfo.loadpageEmployeeinfoGetData(intenroll);
        }

        public DataTable docviewpageload(int jobstation)
        {
            DocViewPageLoadDataTable3TableAdapter dcoviewdata = new DocViewPageLoadDataTable3TableAdapter();
            return dcoviewdata.DocumentDataGridViewGetData(jobstation);

        }

        public void documentReject(int reject1)
        {
            TblHRDocRejectTableAdapter rejject = new TblHRDocRejectTableAdapter();
            rejject.DocumentRejectGetData(reject1);
        }

        public void documentApprove(int Approve2)
        {
            TblApproveHRDocTableAdapter approve = new TblApproveHRDocTableAdapter();
            approve.DocumentApproveGetData(Approve2);
        }

        public DataTable CorporateViewDataGrid(int unit)
        {
            CorporateViewDataTableTableAdapter corporate = new CorporateViewDataTableTableAdapter();
            return corporate.CorporateViewDataGetData(unit);
        }

        public DataTable ImageView(int data)
        {
            TblImageViewPopUpTableAdapter popup = new TblImageViewPopUpTableAdapter();
            return popup.ImageViewPopUpGetData(data);
        }

        public DataTable CheckCorporate(int intenroll)
        {
            CheckCorporateTableAdapter checkcorp = new CheckCorporateTableAdapter();
            return checkcorp.CheckCorporateGetData(intenroll);

        }
    }
}
