using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HR_DAL.Visitors.MeetingReportTDSTableAdapters;

namespace HR_BLL.Visitors
{
    public class MeetingMiniutesReport
    {
       


        public DataTable MeetingReport(int data)
        {
            TblMeetingMinutesTableAdapter dc = new TblMeetingMinutesTableAdapter();
            return dc.reportGetData(data);
        }

        public DataTable nextmeetingschedule(int data)
        {
            DataTable1TableAdapter next = new DataTable1TableAdapter();
            return next.ReportNextMeetingScheduleGetData(data);
        }

        public DataTable decissiondatareportget(int data)
        {
            DataTable2TableAdapter decission = new DataTable2TableAdapter();
            return decission.ReportDecissionsGetData(data);
        }

        public DataTable agendadreport(int data)
        {
            TblMeetingAgendaTableAdapter agendadata = new TblMeetingAgendaTableAdapter();
            return agendadata.AgendatReportGetData(data);
        }





        public DataTable metinformation(DateTime dtefo, DateTime dteto,int intunitid)
        {
            TblMeetingTitleReportTableAdapter met = new TblMeetingTitleReportTableAdapter();
            return met.MeetingTitleReportGetData(dtefo,dteto,intunitid);
        }

        public DataTable personattenddata(int data)
        {
            TblMeetinMinutesPersonAttenNameTableAdapter attend = new TblMeetinMinutesPersonAttenNameTableAdapter();
            return attend.PersonattendGetData(data);
        }
    }
}
