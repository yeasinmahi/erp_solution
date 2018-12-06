using HR_DAL.Global;
using HR_DAL.Global.UnitTDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using HR_DAL.Reports;

namespace HR_BLL.Global
{
    public class Unit
    {
        
        public UnitTDS.TblUnitDataTable GetUnits()
        {
            TblUnitTableAdapter ta = new TblUnitTableAdapter();
            return ta.GetActiveData();
        }
        public UnitTDS.SprGetUnitDataTable GetUnits(string userID)
        {
            SprGetUnitTableAdapter ta = new SprGetUnitTableAdapter();
            return ta.GetData(int.Parse(userID));
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
