using System;
using System.Collections.Generic;
using System.Linq;
using HR_DAL.Global.AutoSearch_TDSTableAdapters;
using System.Data;
using HR_DAL.Global.InventoryTDSTableAdapters;
using HR_DAL.Global;
using System.Collections;

namespace HR_BLL.Global
{
    public class AutoSearch_BLL
    {
        private static InventoryTDS.SprRequesitionAutosearchDataTable[] tableCusts = null;
        private static AutoSearch_TDS.CorporateCustSearchDataTable[] tableCorporate = null;
        private static AutoSearch_TDS.QryEmployeeProfileAllDataTable[] tableEmpList = null;
        private static AutoSearch_TDS.CorporateProductSearchDataTable[] tableCorporateProduct = null;
        private static InventoryTDS.SprItemSearchingbasedonclusterDataTable[] tableitemlists = null;
        private static InventoryTDS.EmpListDataTable[] tblEmpListForStroreReq = null;
        private static AutoSearch_TDS.TblEmployeeByJobstationDataTable[] tblempbyJob = null;
        private static InventoryTDS.QryItemListDataTable[] qryItemLists = null;
        private static Hashtable ht = new Hashtable();
        int e;
        private static AutoSearch_TDS.TblEmployeeSearchDataTable[] tblEmpListForGlobal = null;

        #region===== Employee List By Job Station ID For Loan Entry =========================
        //TblEmployeeSearchTableAdapter
        public string[] AutoSearchEmpListGlobal(string Enroll, string prefix)
        {
            if (prefix.Trim().Length >= 3)
            {
                if (prefix.Trim().Length >= 4)
                {
                }
                else
                {
                    int intEnroll = int.Parse(Enroll.ToString());
                    tblEmpListForGlobal = new AutoSearch_TDS.TblEmployeeSearchDataTable[intEnroll];
                    TblEmployeeSearchTableAdapter adpCOA = new TblEmployeeSearchTableAdapter();
                    tblEmpListForGlobal[e] = adpCOA.GetEmpListByJobS(intEnroll);
                }
                
                DataTable tbl = new DataTable();

                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblEmpListForGlobal[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tblEmpListForGlobal[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.strEmployeeCode.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strOfficeEmail.ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }

                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                        retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                    }
                    return retStr;
                }
                else { return null; }
            }
            else { return null; }
        }

        #endregion===========================================================================


        // private static Hashtable ht = new Hashtable(); 
        
        public List<string> AutoSearchEmployeesData(int intLoginId, int intJobStationId, string strSearchKey)
        {
           List<string> result = new List<string>();
            SprAutoSearchEmployeeFilterByJobStationTableAdapter adp = new SprAutoSearchEmployeeFilterByJobStationTableAdapter();
            DataTable dt = adp.AutoSearchEmployeeFilterByJobStation(intLoginId, intJobStationId, strSearchKey);
            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    result.Add(dt.Rows[index]["strEmployeeNameWithCode"].ToString());
                }
                
            }
            return result;
        }
        public List<string> AutoSearchEmployeesData(int intJobStationId, string strSearchKey)
        {
            List<string> result = new List<string>();
            sprAutoSearchEmployeeByJobStationTableAdapter adp = new sprAutoSearchEmployeeByJobStationTableAdapter();
            DataTable dt = adp.GetData(intJobStationId, strSearchKey);
            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    result.Add(dt.Rows[index]["strEmployeeNameWithCode"].ToString());
                }

            }
            return result;
        }
        public DataTable AutoSearchEmployees(int userid, int JobStationId, string strSearchKey)
        {
            SprAutoSearchEmployeeFilterByJobStationTableAdapter ta = new SprAutoSearchEmployeeFilterByJobStationTableAdapter();
            try
            { return ta.AutoSearchEmployeeFilterByJobStation(userid, JobStationId, strSearchKey); }
            catch { return new DataTable(); }
        }

        public string[] GetEmployeeLists(Boolean active, string prefix)
        {
            tableEmpList = new AutoSearch_TDS.QryEmployeeProfileAllDataTable[Convert.ToInt32(active)];
            QryEmployeeProfileAllTableAdapter emplists = new QryEmployeeProfileAllTableAdapter();
            tableEmpList[e] = emplists.EmployeeListGetData(Convert.ToBoolean(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >=3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmpList[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strOfficeEmail
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableEmpList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strOfficeEmail.ToLower().Contains(prefix)
                                   orderby tmp.strOfficeEmail
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }

                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strOfficeEmail"] + "," + tbl.Rows[i]["strEmployeeName"] + "," + tbl.Rows[i]["strDesignation"] +","+ tbl.Rows[i]["strDepatrment"] + "," + tbl.Rows[i]["strJobStationName"]   + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string[] GetEmployeeListByJob(Boolean active, string prefix)
        {
            tableEmpList = new AutoSearch_TDS.QryEmployeeProfileAllDataTable[Convert.ToInt32(active)];
            QryEmployeeProfileAllTableAdapter emplists = new QryEmployeeProfileAllTableAdapter();
            tableEmpList[e] = emplists.EmployeeListGetData(Convert.ToBoolean(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmpList[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strOfficeEmail
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableEmpList[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strOfficeEmail.ToLower().Contains(prefix)
                                   orderby tmp.strOfficeEmail
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }

                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strOfficeEmail"] + "," + tbl.Rows[i]["strEmployeeName"] + "," + tbl.Rows[i]["strDesignation"] + "," + tbl.Rows[i]["strDepatrment"] + "," + tbl.Rows[i]["strJobStationName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string[] GetEmployeeByJobstationOperator(int enroll, string prefix)
        {
              
            tblempbyJob = new AutoSearch_TDS.TblEmployeeByJobstationDataTable[enroll];
            TblEmployeeByJobstationTableAdapter emplists = new TblEmployeeByJobstationTableAdapter();
            tblempbyJob[e] = emplists.GetEmpByJobstationData(enroll);

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblempbyJob[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strOfficeEmail
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tblempbyJob[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.intEmployeeID.ToString().ToLower().Contains(prefix)|| tmp.strEmployeeCode.ToString().ToLower().Contains(prefix) || tmp.strOfficeEmail.ToLower().Contains(prefix)
                                   orderby tmp.intEmployeeID
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }

                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                   // retStr[i] = tbl.Rows[i]["strOfficeEmail"] + "," + tbl.Rows[i]["strEmployeeName"] + "," + tbl.Rows[i]["strDesignation"] + "," + tbl.Rows[i]["strDepatrment"] + "," + tbl.Rows[i]["strJobStationName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                   retStr[i] = tbl.Rows[i]["strEmployeeName"] +"[" + "Code:" + " " + tbl.Rows[i]["strEmployeeCode"] + "][" + tbl.Rows[i]["intEmployeeID"] + "]" ;
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public DataTable SearchACLEmployees(string strSearchKey)
        {
            SprAutoSearchEmployeeFilterByJobStationTableAdapter ta = new SprAutoSearchEmployeeFilterByJobStationTableAdapter();
            try
            { return ta.GetACLDataBySearch(strSearchKey); }
            catch { return new DataTable(); }
        }
       
        public DataTable SearchInformation(int intLoginId)
        {
            TblEmployeeTableAdapter adptr = new TblEmployeeTableAdapter();
            return adptr.GetSearchInformationData(intLoginId);
        }
        public DataTable SearchACCLCustomerList(string email)
        {
            AcclRemoteDistributorTableAdapter adp = new AcclRemoteDistributorTableAdapter();
            return adp.GetACCLRemoteDistListData(email);
        }
        public DataTable AutoSearchEmployees(int userid, string searchKey)
        {
            GetEmployeeBySupervisorTableAdapter ta = new GetEmployeeBySupervisorTableAdapter();
            try
            { return ta.GetEmployeeBySupervisorData(searchKey,userid ); }
            catch { return new DataTable(); }
        }
        public DataTable SearchGuestHostList(int type, int bookingby, string searchKey)
        {
            SprGuestHostSearchTableAdapter ta = new SprGuestHostSearchTableAdapter();
            try { return ta.SearchHostGuestData(type, bookingby, searchKey); }
            catch { return new DataTable(); }
        }

        public InventoryTDS.WHDataTableDataTable GetUnits()
        {
            WHDataTableTableAdapter ta = new WHDataTableTableAdapter();
            return ta.WHIDGetData();
        }

        public string[] CorporateCustomerSearch(bool active, string prefix)
        {
            
            tableCorporate = new AutoSearch_TDS.CorporateCustSearchDataTable[Convert.ToInt32(active)];
            CorporateCustSearchTableAdapter corporatecust = new CorporateCustSearchTableAdapter();
            tableCorporate[e] = corporatecust.CorporateCustAutosearchGetData(Convert.ToBoolean(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 2)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCorporate[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strname
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableCorporate[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strname.ToLower().Contains(prefix) || tmp.intcustid.ToString().Contains(prefix)
                                   orderby tmp.strname
                                   select tmp;
                      
                        if (rows.Any())
                        {
                            tbl = rows.CopyToDataTable();

                        }
                       
                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strname"] + "[" + tbl.Rows[i]["intcustid"] + "]" + tbl.Rows[i]["strstatus"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }

        }



        public string[] CorporateProductSearch(bool active, string prefix)
        {

            tableCorporateProduct = new AutoSearch_TDS.CorporateProductSearchDataTable[Convert.ToInt32(active)];
            CorporateProductSearchTableAdapter corporateproduct = new CorporateProductSearchTableAdapter();
            tableCorporateProduct[e] = corporateproduct.CorporateProductList(Convert.ToBoolean(active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 2)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCorporateProduct[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strProductName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableCorporateProduct[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strProductName.ToLower().Contains(prefix) || tmp.intProductId.ToString().Contains(prefix)
                                   orderby tmp.strProductName
                                   select tmp;

                        if (rows.Any())
                        {
                            tbl = rows.CopyToDataTable();

                        }
                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strProductName"] + "[" + tbl.Rows[i]["intProductId"] + "][" + tbl.Rows[i]["strShortCode"] + "]";
                }

                return retStr;

            }
            else
            {
                return null;
            }

        }

        //private static InventoryTDS.EmpListDataTable[] tblEmpListForStroreReq = null;
        public string[] GetItemListsForStoreReq(string prefix)
        {
            int intwh = 1;
            //Inatialize(intwh);
            tblEmpListForStroreReq = new InventoryTDS.EmpListDataTable[Convert.ToInt32(intwh)];
            EmpListTableAdapter adpCOA = new EmpListTableAdapter();
            tblEmpListForStroreReq[e] = adpCOA.GetEmpList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblEmpListForStroreReq[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tblEmpListForStroreReq[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strJobStationName.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
                                   select tmp;

                        if (rows.Any())
                        {
                            tbl = rows.CopyToDataTable();

                        }
                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["strJobStationName"] + "]" + " " + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }


        }
        private void Inatialize(int intwh)
        {

            if (tableCusts == null)
            {
                DataWearHouse unt = new DataWearHouse();
                InventoryTDS.TblWearHouseDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();
                tableCusts = new InventoryTDS.SprRequesitionAutosearchDataTable[tblUnit.Rows.Count];
                SprRequesitionAutosearchTableAdapter adpCOA = new SprRequesitionAutosearchTableAdapter();

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {

                    int untid = tblUnit[i].intWHID;
                    {
                        ht.Add(tblUnit[i].intWHID.ToString(), i);
                        tableCusts[i] = adpCOA.WHAutoSearchGetData(tblUnit[i].intWHID);
                    }
                }
            }
        }


        public string[] GetItemLists(string whid, string prefix)
        {
            //if (tableCusts == null || tableCusts.Length < 1)
            //{
            //    tableCusts = new InventoryTDS.SprRequesitionAutosearchDataTable[Convert.ToInt32(whid)];
            //    SprRequesitionAutosearchTableAdapter adpCOA = new SprRequesitionAutosearchTableAdapter();
            //    tableCusts[e] = adpCOA.WHAutoSearchGetData(Convert.ToInt32(whid));
            //}
            Inatialize(Convert.ToInt32(whid));
            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >=3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[Convert.ToInt32(ht[whid])]                           
                               orderby tmp.strItem
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableCusts[Convert.ToInt32(ht[whid])]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItem.ToLower().Contains(prefix) || tmp.ItemNumber.ToLower().Contains(prefix)
                                   orderby tmp.strItem
                                   select tmp;
                       
                        if (rows.Any())
                        {
                            tbl = rows.CopyToDataTable();

                        }
                      

                    }

                    catch
                    {
                        return null;
                    }
                }

            }
                if (tbl.Rows.Count > 0)
                {
                    string[] retStr = new string[tbl.Rows.Count];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {

                        retStr[i] = tbl.Rows[i]["strItem"] + "[" + tbl.Rows[i]["intItem"] + "]" + "[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]";

                        //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                    }

                    return retStr;

                }


                else
                {
                    return null;
                }
            

            }


        public string[] GetItemBasedoncluster(string WHID, string prefix)
        {
            int intwh = Int32.Parse(WHID.ToString());
            //Inatialize(intwh);
            tableitemlists = new InventoryTDS.SprItemSearchingbasedonclusterDataTable[Convert.ToInt32(WHID)];
            SprItemSearchingbasedonclusterTableAdapter adpCOA = new SprItemSearchingbasedonclusterTableAdapter();
            tableitemlists[e] = adpCOA.GetDataItemSearchingbasedoncluster(Convert.ToInt32(WHID));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableitemlists[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strItem
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableitemlists[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItem.ToLower().Contains(prefix) 
                                   orderby tmp.strItem
                                   select tmp;

                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();

                        }


                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strItem"] + "[" + tbl.Rows[i]["intItem"] + "]";

                  
                }

                return retStr;

            }


            else
            {
                return null;
            }


        }

        //==================== for item search =============

        public string[] GetItemListFromQryItemList(string prefix)
        {
            int intwh = 1;
            //Inatialize(intwh);
            qryItemLists = new InventoryTDS.QryItemListDataTable[Convert.ToInt32(intwh)];
            QryItemListTableAdapter adpCOA = new QryItemListTableAdapter();
            qryItemLists[e] = adpCOA.GetItemList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 2)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in qryItemLists[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strItemName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in qryItemLists[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItemName.ToLower().Contains(prefix) || tmp.intItemID.ToString().ToLower().Contains(prefix) || tmp.strDescription.ToString().ToLower().Contains(prefix)   //strOfficeEmail 
                                   orderby tmp.strItemName
                                   select tmp;

                        if (rows.Any())
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }

                    catch
                    {
                        return null;
                    }
                }

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strItemName"] +" "+ tbl.Rows[i]["strDescription"] + " [" + tbl.Rows[i]["intItemID"] + "]";                    
                }

                return retStr;
            }
            else
            {
                return null;
            }


        }

    }
}
class DataWearHouse
{
    public InventoryTDS.TblWearHouseDataTable GetUnits()
    {
        TblWearHouseTableAdapter ta = new TblWearHouseTableAdapter();
        return ta.GetWHData();
    }
}