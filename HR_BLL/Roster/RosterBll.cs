using System;
using System.Data;
using HR_DAL.Roster.RosterTDSTableAdapters;

namespace HR_BLL.Roster
{
    public class RosterBll
    {
        public DataTable GetTeamByJobstation(int jobStationId)
        {
            try
            {
                tblEmployeeTeamBuildTableAdapter adp = new tblEmployeeTeamBuildTableAdapter();
                return adp.GetTeamByJobstation(jobStationId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetShiftByTeam(int teamId)
        {
            try
            {
                tblEmployeeTeamShiftTableAdapter adp = new tblEmployeeTeamShiftTableAdapter();
                return adp.GetShiftByTeam(teamId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetShiftByShiftId(int shiftId)
        {
            try
            {
                tblEmployeeTeamShift1TableAdapter adp = new tblEmployeeTeamShift1TableAdapter();
                return adp.GetShiftByShiftId(shiftId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetSequence()
        {
            try
            {
                tblEmployeeTeamShiftSequenceTableAdapter adp = new tblEmployeeTeamShiftSequenceTableAdapter();
                return adp.GetSequence();
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }

        public string RosterEntry(int type, string xmlString, int insertBy)
        {
            string message=string.Empty;
            sprRosterAddManualTableAdapter adp = new sprRosterAddManualTableAdapter();
            adp.RosterInsert(type,xmlString, insertBy,ref message);
            return message;
        }
    }
}
