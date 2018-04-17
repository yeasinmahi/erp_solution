using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.TeamBuild.TeamAndShiftInformationTDSTableAdapters;
using HR_DAL.TeamBuild;
using System.Data;

namespace HR_BLL.TeamBuild
{
    public class TeamAndShiftInformation
    { 

        public string InsertTeamShiftInformation(int unitId, int jobStationId, string teamName, string xmlString, int softwareLoginUserID)
        {
            SprEmployeeTeamShiftCreationTableAdapter adp = new SprEmployeeTeamShiftCreationTableAdapter();
            string msgStatus = "";
            try { adp.InsertTeamShiftInformationData(unitId, jobStationId, teamName, xmlString, softwareLoginUserID, ref msgStatus); }
            catch { msgStatus = "Errors occurs."; }
            return msgStatus;
        }

        public string InsertAssignedShiftInformation(string xmlString, int softwareLoginUserID)
        {
            SprEmployeeTeamShiftAssignTableAdapter adp = new SprEmployeeTeamShiftAssignTableAdapter();
            string msgStatus = "";
            try {  adp.InsertAssignedShiftInformationData(xmlString, softwareLoginUserID, ref msgStatus); }
            catch { msgStatus = "Errors occurs."; }
            return msgStatus;
        }

        public TeamAndShiftInformationTDS.TblEmployeeTeamShiftSequenceDataTable GetAllShiftSequence()
        {
            //Summary    :   This function will use to get Team Shift Sequence Id and Name 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <09/06/2012>
            //Modified   : 
            TblEmployeeTeamShiftSequenceTableAdapter ta = new TblEmployeeTeamShiftSequenceTableAdapter();
            return ta.GetAllShiftSequenceData();
        }

        public TeamAndShiftInformationTDS.SprGetAllTeamByStationIdDataTable GetAllTeamByStationId(int? intJobStationId)
        {
            //Summary    :   This function will use to get Team Id and name by intJobStationId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <09/06/2012>
            //Modified   :   
            //Parameters :   intJobStationId
            SprGetAllTeamByStationIdTableAdapter adp = new SprGetAllTeamByStationIdTableAdapter();
            return adp.GetAllTeamByStationIdData(intJobStationId);
        }

        public TeamAndShiftInformationTDS.SprGetAllTeamByStationIdDataTable GetAllTeamBySessionStationId(string strSessionStationId)
        {
            //Summary    :   This function will use to get Team Id and name by intJobStationId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <09/06/2012>
            //Modified   :   
            //Parameters :   intJobStationId
            SprGetAllTeamByStationIdTableAdapter adp = new SprGetAllTeamByStationIdTableAdapter();
            return adp.GetAllTeamByStationIdData(int.Parse(strSessionStationId));
        }

        public TeamAndShiftInformationTDS.SprGetAllShiftByTeamIdDataTable GetAllShiftByTeamId(int? intTeamId, int? intJobStationId)
        {
            //Summary    :   This function will use to get Shift Id and name by intTeamId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <09/06/2012>
            //Modified   :   
            //Parameters :   intTeamId
            SprGetAllShiftByTeamIdTableAdapter adp = new SprGetAllShiftByTeamIdTableAdapter();
            return adp.GetAllShiftByTeamIdData(intTeamId, intJobStationId);
        }

        public TeamAndShiftInformationTDS.SprEmployeeTeamInformationDataTable GetTeamInformationByTeamId(int? intTeamId)
        {
            //Summary    :   This function will use to get Team Information By TeamId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <12/09/2012>
            //Modified   :   
            //Parameters :   intTeamId
            SprEmployeeTeamInformationTableAdapter adp = new SprEmployeeTeamInformationTableAdapter();
            return adp.GetTeamInformationByTeamIdData(intTeamId);
        }

        public string UpdateTeamInformationByTeamId(int? intTeamId, int? intOnOffId)
        {
            //Summary    :   This Function will Use to Update Team Information By TeamId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <12/09/2012>
            //Modified   :   
            //Parameters :   intTeamId, intOnOffId
            string msgStatus = "";
            SprEmployeeTeamInformationUpdateTableAdapter adp = new SprEmployeeTeamInformationUpdateTableAdapter();
            try { adp.UpdateTeamInformationByTeamIdData(intTeamId, intOnOffId, ref msgStatus); }
            catch { msgStatus = "Errors occurs."; }
            return msgStatus;
        }

        public TeamAndShiftInformationTDS.SprEmployeeTeamShiftInformationDataTable GetShiftInformationByTeamId(int? intTeamId)
        {
            //Summary    :   This function will use to get Team-Shift Information By TeamId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <12/09/2012>
            //Modified   :   
            //Parameters :   intTeamId
            SprEmployeeTeamShiftInformationTableAdapter adp = new SprEmployeeTeamShiftInformationTableAdapter();
            return adp.GetShiftInformationByTeamIdData(intTeamId);
        }

        public DataTable GetTeamShiftByEmployeeCode(string strEmpCode)
        {
            SprEmployeeTeamShiftTableAdapter adp = new SprEmployeeTeamShiftTableAdapter();
            return adp.GetTeamShiftByEmployeeCode(strEmpCode);
        }

        public string UpdateTeamShiftInformationByEmpCode(string empCode, int intTeamId, int intShiftId, DateTime dteFrom, DateTime dteTo, int loginUserID)
        {
            string msgStatus = "";
            SprEmployeeTeamShiftChangeTableAdapter adp = new SprEmployeeTeamShiftChangeTableAdapter();
            //try { adp.UpdateTeamShiftDataByEmpCode(empCode, intTeamId, intShiftId, dteFrom, dteTo, loginUserID, ref msgStatus); }
            //catch { msgStatus = "Errors occurs."; }
            adp.UpdateTeamShiftDataByEmpCode(empCode, intTeamId, intShiftId, dteFrom, dteTo, loginUserID, ref msgStatus);
            return msgStatus;
        }
        
        public string UpdateTeamShiftInformationByShiftId(string strShiftName, string tmShiftStart, string tmShiftEnd, int ysnRoster, int ysnActive, int original_intShiftId)
        {
            //Summary    :   This Function will Use to Update Team-Shift Information By ShiftId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <12/09/2012>
            //Modified   :   
            //Parameters :   intShiftId, strShiftName, startTime, endTime, chkRosterEnable
            string msgStatus = "";
            SprEmployeeTeamShiftInformationUpdateTableAdapter adp = new SprEmployeeTeamShiftInformationUpdateTableAdapter();
            try { adp.UpdateTeamShiftInformationByShiftIdData(original_intShiftId, strShiftName, tmShiftStart, tmShiftEnd, ysnRoster, ysnActive, ref msgStatus); }
            catch { msgStatus = "Errors occurs."; }
            return msgStatus;
        }

        public string DeleteTeamShiftInformationByShiftId(int intShiftId,int?  original_intShiftId)
        {
            //Summary    :  This Function will Use to Delete Team-Shift Information By ShiftId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date:  <12/09/2012>
            //Modified   :   
            //Parameters :  shiftId
            string msgStatus = "";
            SprEmployeeTeamShiftInformationDeleteTableAdapter adp = new SprEmployeeTeamShiftInformationDeleteTableAdapter();
            try { adp.DeleteTeamShiftInformationData(original_intShiftId, ref msgStatus);}
            catch { msgStatus = "Errors occurs."; }
            return msgStatus;
        }
                
    }
}
