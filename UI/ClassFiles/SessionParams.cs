using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionParams
/// </summary>
namespace UI.ClassFiles
{
    public class SessionParams
    {

        #region COMMON
        private static string userID = "sesUserID";
        private static string userCode = "sesUserCode";
        private static string userName = "sesName";

        private static string unitID = "sesUnit";
        private static string unitName = "sesUnitName";

        private static string deptID = "sesDept";
        private static string deptName = "sesDeptName";


        private static string desigID = "sesDesig";
        private static string desigName = "sesDesigName";

        private static string jobStationID = "sesJobStationID";
        private static string jobStationName = "sesJobStationName";

        private static string jobTypeID = "sesJobTypeID";
        private static string jobTypeName = "sesjobTypeName";

        private static string appoinmentDate = "sesAppointDate";
        private static string email = "sesEmail";
        private static string phone = "sesPhone";


        private static string CurrentUnit = "sesCurrentUnit";
        private static string supervisor = "sesSupervisor";

        public static string Supervisor
        {
            get { return SessionParams.supervisor; }
        }



        public static string USER_ID
        {
            get { return userID; }
        }
        public static string USER_CODE
        {
            get { return userCode; }
        }
        public static string USER_NAME
        {
            get { return userName; }
        }


        public static string UNIT_ID
        {
            get { return unitID; }
        }
        public static string UNIT_NAME
        {
            get { return unitName; }
        }

        public static string DEPT_ID
        {
            get { return deptID; }
        }
        public static string DEPT_NAME
        {
            get { return deptName; }
        }

        public static string DESIG_ID
        {
            get { return desigID; }
        }
        public static string DESIG_NAME
        {
            get { return desigName; }
        }


        public static string JOBSTATION_ID
        {
            get { return jobStationID; }
        }
        public static string JOBSTATION_NAME
        {
            get { return jobStationName; }
        }


        public static string JOBTYPE_ID
        {
            get { return jobTypeID; }
        }
        public static string JOBTYPE_NAME
        {
            get { return jobTypeName; }
        }


        public static string APPOINTMENT_DATE
        {
            get { return appoinmentDate; }
        }
        public static string EMAIL
        {
            get { return email; }
        }
        public static string PHONE
        {
            get { return phone; }
        }


        public static string CURRENT_UNIT
        {
            get
            {
                return CurrentUnit;
            }
        }



        #endregion



        #region FOR SAD

        private static string currentSO = "sesCurrentSO";
        private static string currentCusType = "sesCurrentCusType";
        private static string currentShip = "sesCurrentShip";



        public static string CURRENT_CUS_TYPE
        {
            get
            {
                return currentCusType;
            }
        }
        public static string CURRENT_SO
        {
            get
            {
                return currentSO;
            }
        }
        public static string CURRENT_SHIP
        {
            get
            {
                return currentShip;
            }
        }
        #endregion


        #region  FOR HR

        private static string unitID_pf = "sesUnitID_pf";


        public static string UNIT_ID_PF
        {
            get { return unitID_pf; }
        }

        #endregion


    }
}