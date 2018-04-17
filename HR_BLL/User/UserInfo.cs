using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HR_DAL.User;
using HR_DAL.User.UserInfoTDSTableAdapters;

namespace HR_BLL.User
{
    public class UserInfo
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// Updated By Himadri Das
        /// </summary>
        public void GetUserInfoByUserCode(string loginCode, ref int? userID,
                                                            ref string userCode,
                                                            ref string userName,
                                                            ref int? unitID,
                                                            ref string unitName,
                                                            ref int? deptID,
                                                            ref string deptName,
                                                            ref int? desigID,
                                                            ref string desigName,
                                                            ref int? jobStationID,
                                                            ref string jobStationName,
                                                            ref int? jobTypeID,
                                                            ref string jobTypeName,
                                                            ref DateTime? appoinmentDate,
                                                            ref string email,
                                                            ref string phone,
                                                            ref string supervisor,
                                                            ref int? unitID_pf
                                            )
        {
            GetEmployeeInfoForLoginTableAdapter ta = new GetEmployeeInfoForLoginTableAdapter();
             ta.GetData(loginCode, ref  userID,
                                                            ref  userCode,
                                                            ref  userName,
                                                            ref  unitID,
                                                            ref  unitName,
                                                            ref  deptID,
                                                            ref  deptName,
                                                            ref  desigID,
                                                            ref  desigName,
                                                            ref  jobStationID,
                                                            ref  jobStationName,
                                                            ref  jobTypeID,
                                                            ref  jobTypeName,
                                                            ref  appoinmentDate,
                                                            ref  email,
                                                            ref  phone,
                                                            ref supervisor,
                                                            ref  unitID_pf);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public UserInfoTDS.QryUserInfoShortDataTable GetUserShortInfoByID(string userID)
        {
            QryUserInfoShortTableAdapter ta = new QryUserInfoShortTableAdapter();
            return ta.GetDataByID(int.Parse(userID));
        }

        /// <summary>
        /// Developped By Himadri Das
        /// </summary>
        public UserInfoTDS.TblUserInfoDataTable GetUserInfoByUnitID(int intUnitID)
        {
            TblUserInfoTableAdapter ta = new TblUserInfoTableAdapter();
            return ta.GetDataByUnitID(intUnitID);

        }
    }
}
