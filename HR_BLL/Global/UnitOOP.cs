using HR_DAL.Global;
using HR_DAL.Global.UnitTDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using HR_DAL.Reports;
using System.Data;
using System;
using HR_DAL.Global.UnitOOPTDSTableAdapters;
using System.Linq;

namespace HR_BLL.Global
{
    public class UnitOOP
    {
        string lavel;
        int unitid;
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();
        DataTable dtTemp2 = new DataTable();

        public UnitTDS.TblUnitDataTable GetUnits()
        {
            TblUnitTableAdapter ta = new TblUnitTableAdapter();
            return ta.GetActiveData();
        }
        public DataTable GetUnits(string userID)
        {

            UserInfoOOP userInfo = new UserInfoOOP();
             dt = userInfo.getuserinfo(int.Parse(userID));
            if (dt.Rows.Count > 0)
            {
                 lavel = dt.Rows[0]["intLevel"].ToString();
                 unitid =int.Parse(dt.Rows[0]["intUnitID"].ToString());
                if (lavel=="0")
                {
                     dt = GetUnit();
                     dtTemp =  (from DataRow dr in dt.Rows where (int)dr["intUnitID"] == unitid select dr).CopyToDataTable();
                     dtTemp2 = (from DataRow dr in dt.Rows where (int)dr["intUnitID"] != unitid select dr).CopyToDataTable();
                     dtTemp.Merge(dtTemp2);

                    return dtTemp;

                }
                else if (lavel == "1")
                {
                    dtTemp = (from DataRow dr in dt.Rows where (int)dr["intUnitID"] == unitid select dr).CopyToDataTable();
                    dtTemp.Merge(dtTemp2);

                    return dtTemp;
                }
                else if (lavel == "0")
                {
                    dt = GetUnitbyuser(userID, unitid);
                    if (userID == "1022")
                    {
                       
                        dtTemp2 = (from DataRow dr in dt.Rows select dr).CopyToDataTable();
                        dtTemp.Merge(dtTemp2);
                    }else
                    {
                        dtTemp = (from DataRow dr in dt.Rows where (int)dr["intUnitID"] == unitid select dr).CopyToDataTable();
                        dtTemp2 = (from DataRow dr in dt.Rows select dr).CopyToDataTable();
                        dtTemp.Merge(dtTemp2);
                    }
                    return dtTemp;
                }
                else if (lavel == "0")
                {
                    dtTemp = (from DataRow dr in dt.Rows where (int)dr["intUnitID"] == unitid select dr).CopyToDataTable();
                }
            }
            return new DataTable();
        }

        private DataTable GetUnitbyuser(string userID, int unitid)
        {
            qryUnitByUserTableAdapter adp = new qryUnitByUserTableAdapter();
            return adp.GetData(int.Parse(userID),unitid);
        }

        private DataTable GetUnit()
        {
            tblUnitTableAdapter adp = new tblUnitTableAdapter();
            return adp.GetData();
        }

        public ListItemCollection GetAllUnitIdAndName()
        {
            //Summary    :   This function will use to get all unit Id and name
            //Created    :   Md. Yeasir Arafat / Mar-14-2012
            //Modified   :   
            //Parameters :   

            ListItemCollection col = new ListItemCollection();

            UnitGetAllUnitIdAndNameTableAdapter objUnitGetAllUnitIdAndNameTableAdapter = new UnitGetAllUnitIdAndNameTableAdapter();
            ReportDataTDS.UnitGetAllUnitIdAndNameDataTable tbl = objUnitGetAllUnitIdAndNameTableAdapter.GetAllUnitIdAndNameData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strUnit, tbl[i].intUnitID.ToString()));
            }


            return col;
        }
        
        public ListItemCollection GetAllPfUnitIdAndNameByLoginUserId(int intLoginUserId)
        {
            //Summary    :   This function will use to get all unit Id and name
            //Created    :   Md. Yeasir Arafat / September-26-2012
            //Modified   :   
            //Parameters :   

            ListItemCollection col = new ListItemCollection();

            SprGetPfUnitByLoginUserIdTableAdapter objSprGetPfUnitByLoginUserIdTableAdapter = new SprGetPfUnitByLoginUserIdTableAdapter();
            UnitTDS.SprGetPfUnitByLoginUserIdDataTable tbl = objSprGetPfUnitByLoginUserIdTableAdapter.GetAllPfUnitIdAndName(intLoginUserId);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strUnit, tbl[i].intPfUnitId.ToString()));
            }


            return col;
        }
    }
}
