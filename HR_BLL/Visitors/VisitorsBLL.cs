using HR_DAL.Visitors.VisitorsTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Visitors
{
    public class VisitorsBLL
    {
        public DataTable GetSetVisitorInformation(int type, int row, int host, int guest, string visitor, string vtype, string address, 
        string narration, string contact, DateTime visiting, TimeSpan tmstart, TimeSpan tmend, bool wifi, bool notified, bool response,
        bool gcard, int bookingby, int completeby, int atc, string vcardno)
        {
            SprGuestInformationTableAdapter adp = new SprGuestInformationTableAdapter();
            try
            {
                return adp.GetSetGuestData(type, row, host, guest, visitor, vtype, address, narration, contact, wifi, visiting, bookingby, tmstart, tmend,
                notified, response, gcard, completeby, atc, vcardno);
            }
            catch { return new DataTable(); }

        }


        public DataTable viewjobstation(int enroll)
        {
            JobstationDataTableTableAdapter jobstation = new JobstationDataTableTableAdapter();
            return jobstation.JobStationDropdownGetData(enroll);
        }

        public DataTable VisitorInformationReport(int jobid, DateTime dtefrom, DateTime dteto)
        {
            //VisitorReportDataTableTableAdapter report = new VisitorReportDataTableTableAdapter();
            SprVisitorsReportTableAdapter report = new SprVisitorsReportTableAdapter();
            return report.VisitorReportDateWaiseGetData( jobid, dtefrom, dteto);
        }















    }
}
