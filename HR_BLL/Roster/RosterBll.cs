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
    }
}
