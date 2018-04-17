using HR_DAL.KPI.WorkPlan_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.KPI
{
    public class WorkPlan_BLL
    {
        public DataTable InsertWorkPlandoc(int intType, string xmlDocUpload, string description,string subject, int enroll)
        {
            
            SprWorkPlanTableAdapter adp = new SprWorkPlanTableAdapter();
            
           return  adp.WorkplanGetData(intType, xmlDocUpload, description,subject, enroll);
           
        }

        public DataTable UnitnameGet()
        {
            TblUnitTableAdapter unitname = new TblUnitTableAdapter();
            return unitname.UnitNameGetData();
        }

        public DataTable FineancialYear()
        {
            TblUnitTableAdapter Financial = new TblUnitTableAdapter();
            return Financial.FinencialYearGetDataBy();
        }

        public DataTable CheckAutoID()
        {
            TblUnitTableAdapter checkauto = new TblUnitTableAdapter();
            return checkauto.CheckAutioIDGetData();
        }

        public DataTable workplanViewReport(int unit, string fyear)
        {
            ReportWorkplanTableAdapter viewreport = new ReportWorkplanTableAdapter();
            return viewreport.WorkplanReportGetData(unit, fyear);
        }

        public DataTable workplandetalisdata(int autoid)
        {
            ReportWorkplanTableAdapter docplandes = new ReportWorkplanTableAdapter();
            return docplandes.workdescriptionGetData(autoid);
        }

        public DataTable Workplandetalisdocumnetdata(int autoid)
        {
            TblWorkPlanDocTableAdapter docviewss = new TblWorkPlanDocTableAdapter();
            return docviewss.DocDetalisGetData(autoid);
        }

        public DataTable Workplansummery(int enroll)
        {
            ReportWorkplanTableAdapter userestatus = new ReportWorkplanTableAdapter();
            return userestatus.UserStatusGetData(enroll);
        }
    }
}
