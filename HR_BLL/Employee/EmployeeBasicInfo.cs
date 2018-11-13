using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Employee.EmployeeTableAdapters;

using HR_DAL.Global;
using HR_DAL.Global.EmployeeListTDSTableAdapters;
using HR_DAL.Global.EmployeeIdByUserIdOrEmpCode_TDSTableAdapters;
namespace HR_BLL.Employee
{
   public class EmployeeBasicInfo
    {
        #region Initiate Object
        Spr_GetEmployeeCardInformationByEmpIDTableAdapter objSpr_GetEmployeeCardInformationByEmpIDTableAdapter = new Spr_GetEmployeeCardInformationByEmpIDTableAdapter ();
        SprGetEmployeeBarCodeTableAdapter objSprGetEmployeeBarCodeTableAdapter = new SprGetEmployeeBarCodeTableAdapter();
        Spr_Get_All_Employees_Info_By_UnitID_For_PrintCardTableAdapter objSpr_Get_All_Employees_Info_By_UnitID_For_PrintCardTableAdapter = new Spr_Get_All_Employees_Info_By_UnitID_For_PrintCardTableAdapter();
        //private static EmployeeListTDS.TblEmployeeDataTable objTblEmployeeDataTable = null;
        //private static EmployeeListTDS.TblEmployeeAutoSearchDataTable[] objTblEmployeeDataTable = null;
        private static EmployeeListTDS.SprEmployeeByJobStationDataTable objTblEmployeeDataTable = null;
        private static EmployeeListTDS.SprAutoTextBoxSearchForPicerateEmployeesDataTable objPicerateEmployeDataTable = null;
        //private static EmployeeListTDS.TblEmployeeJobStationOperatorDataTable objTblJobstationDataTable = null;

        SprGetEmpID_By_EmpCodeTableAdapter objSprGetEmpID_By_EmpCodeTableAdapter = new SprGetEmpID_By_EmpCodeTableAdapter();
        Spr_GetEmployeeBasicInformationByEmpCodeOrUserIDTableAdapter objSpr_GetEmployeeBasicInformationByEmpCodeOrUserIDTableAdapter = new Spr_GetEmployeeBasicInformationByEmpCodeOrUserIDTableAdapter();
        #endregion

        #region Method

        public DataTable Get_Employee_Basic_Info_By_EmpCodeOrUserID(int? intUserID,string empCode)
        {
            return objSpr_GetEmployeeBasicInformationByEmpCodeOrUserIDTableAdapter.Spr_GetEmployeeBasicInformationByEmpCodeOrUserID(intUserID, empCode);
        }
        public DataTable Get_Employee_Basic_Info_By(string empID)
        {
            return objSpr_GetEmployeeCardInformationByEmpIDTableAdapter.Spr_GetEmployeeCardInfoByEmpID(empID);
        }
       
        public string Get_Employee_BarCodeString_By_EmpID(string empID)
        {
            string strEmpBarCode = "";
            objSprGetEmployeeBarCodeTableAdapter.SprGetEmployeeBarCode(empID, ref strEmpBarCode);
            return strEmpBarCode;
        }

        public DataTable Get_Employee_BarCodeString_By_EmpID_All_EmployeeInfo_By_UnitID(string strUnit)
        {
            return objSpr_Get_All_Employees_Info_By_UnitID_For_PrintCardTableAdapter.Spr_Get_All_EmployeesInfo_By_UnitID_For_PrintCard(strUnit);
        }

        public static string[] GetAutoFillEmployeeListBySearchKey(string prefix, int intLoginId,int empJobStationID)
        {
            Inatialize(intLoginId);
            //Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable oDT = new DataTable();
            prefix = prefix.ToLower();

            if (prefix == "" || prefix == "*")
            {
                try
                {
                    var rows = from tmp in objTblEmployeeDataTable orderby tmp.strEmployeeName select tmp;
                    if (rows.Count() > 0)
                    {
                        oDT = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    var rows = from tmp in objTblEmployeeDataTable
                               where tmp.strEmployeeName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)||  tmp.strEmployeeCode.ToLower().Contains(prefix)
                               orderby tmp.strEmployeeName
                               select tmp;

                    //List<int> intJobStationOperator = (from tmp123 in objTblJobstationDataTable
                    //                                   where tmp123.intEmployeeId == intLoginId
                    //                                   select tmp123.intJobStationId).ToList();
                    //intJobStationOperator.Add(empJobStationID);

                    //var rows = from tmp in objTblEmployeeDataTable
                    //           where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.strEmployeeCode.ToLower().Contains(prefix)
                    //           && intJobStationOperator.Contains(tmp.intJobStationID)
                    //           orderby tmp.strEmployeeName
                    //           select tmp;


                    if (rows.Count() > 0)
                    {
                        oDT = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (oDT.Rows.Count > 0)
            {
                string[] retStr = new string[oDT.Rows.Count];
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    retStr[i] = oDT.Rows[i]["strEmployeeName"] + "," + oDT.Rows[i]["strEmployeeCode"];
                }

                return retStr;
            }
            else
            {
                return null;
            }

        }
        private static void Inatialize(int intLoginId)
        {
            if (objTblEmployeeDataTable == null)
            {
                SprEmployeeByJobStationTableAdapter objTblEmployeeTableAdapter = new SprEmployeeByJobStationTableAdapter();
                objTblEmployeeDataTable = objTblEmployeeTableAdapter.GetEmployeeListData(intLoginId);
                //TblEmployeeAutoSearchTableAdapter objTblEmployeeTableAdapter = new TblEmployeeAutoSearchTableAdapter();
                //objTblEmployeeDataTable = objTblEmployeeTableAdapter.GetData();
            }

            //if (objTblJobstationDataTable == null)
            //{
            //    TblEmployeeJobStationOperatorTableAdapter adp = new TblEmployeeJobStationOperatorTableAdapter();
            //    objTblJobstationDataTable = adp.GetJobStationOparetorData();
            //}
            
        }
        #endregion



        public string Get_EmpID_By_EmpCode(string empCode)
        {
            int? empID = 0;
            objSprGetEmpID_By_EmpCodeTableAdapter.SprGetEmpID_By_EmpCode(empCode, ref empID);
            return empID.ToString();
        }

        public string GetEmployeeIdByUserIdOrEmpcode(int? intUserID, string empCode)
        {
            //Summary    :   This function will use to get intEmployeeID by uerId or Employee Code
            //Created    :   Md. Yeasir Arafat / Apr-10-2012
            //Modified   :   
            //Parameters :   return intEmployeeID


            int? intEmployeeID = null;
            GetEmployeeIdByUserIdOrEmpcodeTableAdapter tbl = new GetEmployeeIdByUserIdOrEmpcodeTableAdapter();
            tbl.GetData(intUserID, empCode, ref intEmployeeID);
            return intEmployeeID.ToString();
        }

        public static string[] GetAutoFillPiceRateEmployeeListBySearchKey(string prefixText, int intLoginUerId)
        {
            InatializePiceRateEmployees(intLoginUerId);
            prefixText = prefixText.Trim().ToLower();
            DataTable oDT = new DataTable();
            prefixText = prefixText.ToLower();

            if (prefixText == "" || prefixText == "*")
            {
                try
                {
                    var rows = from tmp in objPicerateEmployeDataTable orderby tmp.strEmployeeName select tmp;
                    if (rows.Count() > 0)
                    {
                        oDT = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    var rows = from tmp in objPicerateEmployeDataTable
                               where tmp.strEmployeeName.ToLower().Contains(prefixText) || tmp.strEmployeeCode.ToLower().Contains(prefixText)
                               orderby tmp.strEmployeeName
                               select tmp;


                    if (rows.Count() > 0)
                    {
                        oDT = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (oDT.Rows.Count > 0)
            {
                string[] retStr = new string[oDT.Rows.Count];
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    retStr[i] = oDT.Rows[i]["strEmployeeName"] + "," + oDT.Rows[i]["strEmployeeCode"];
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        private static void InatializePiceRateEmployees(int intLoginUerId)
        {
             
          if (objPicerateEmployeDataTable == null)
             {
                SprAutoTextBoxSearchForPicerateEmployeesTableAdapter objTblEmployeeTableAdapter = new SprAutoTextBoxSearchForPicerateEmployeesTableAdapter();
                objPicerateEmployeDataTable = objTblEmployeeTableAdapter.GetPiceRateEmployeesByLoginUserJobstation(intLoginUerId);
             }
        }

       // add by Himadri das For all Employee report

        public HR_DAL.Employee.Employee.QryEmployeeProfileAllDataTable GetEmployeeProfileData(int jobstationID)
        {
            QryEmployeeProfileAllTableAdapter adp = new QryEmployeeProfileAllTableAdapter();
            return adp.GetData(jobstationID, true);
        }

        public DataTable GetEmpInfoByJobStation(int intJobStationID)
        {
            QryEmployeeProfileAllTableAdapter adp = new QryEmployeeProfileAllTableAdapter();
            return adp.GetEmployeeListByJobStationID(intJobStationID);
        }

    }
}
