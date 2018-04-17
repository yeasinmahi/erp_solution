using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HR_DAL.Visitors.MeetingMinutesTDSTableAdapters;



namespace HR_BLL.Visitors
{
    public class MeetingMinutes
    {

        //public void MeetingTitleniqInformation(string mettingtitle, string meetinginfo,DateTime dtemetdate,DateTime time,  string location,DateTime starttime,DateTime endtime, string calledby,string reffno)
        //{
        //    TblMeetingMinutesTableAdapter titleinsert = new TblMeetingMinutesTableAdapter();
        //    titleinsert.MeetingMinutesTitleInsertGetData(mettingtitle, meetinginfo,dtemetdate,time, location,starttime,endtime,  calledby, reffno);

        //}










        public string MeetingMinutesXMLInsert(string mettingtitle, string meetinginfo, DateTime dtemetdate, DateTime time, string location, DateTime starttime, DateTime endtime, string calledby, string reffno, string objective, string xmlStringAttend, string xmlStringAgenda, string xmlStringDecissions, string xmlStringNextMetting, int intenroll, int intunitid)
        {
            SprMeetingMinutesTableAdapter xmlinsert = new SprMeetingMinutesTableAdapter();
        
            xmlinsert.SPMeetingMinutesXmlGetData(mettingtitle, meetinginfo,  dtemetdate, time, location, starttime, endtime, calledby, reffno,objective, xmlStringAttend, xmlStringAgenda, xmlStringDecissions, xmlStringNextMetting, intenroll, intunitid);
            string msg = "Successfully";
            return msg;
        }

    }
}
