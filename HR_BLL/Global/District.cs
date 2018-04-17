using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global.DistrictTDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Global;
using System.Data;

namespace HR_BLL.Global
{
  public class District
    {
        #region Object Declare
        SprGetDistrictListTableAdapter objSprGetDistrictListTableAdapter = new SprGetDistrictListTableAdapter();

        #endregion
        #region Method
        public ListItemCollection GetDistrictList()
        {
            //Summary    :   This function will use to Load Get District for districtDropdown load
            //Created    :   Md. Yeasir Arafat / FEB-19-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            DistrictTDS.SprGetDistrictListDataTable tbl = objSprGetDistrictListTableAdapter.SprGetDistrictList();
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strDistrict.ToString(), tbl[index].intDistrictID.ToString()));
            }

            return col;
        }
        #endregion

        public DataTable GetAllBankList()
        {
            TblBankNameTableAdapter ta = new TblBankNameTableAdapter();
            DataTable dt = new DataTable();
            dt=ta.GetBankListData();
            return ta.GetBankListData();
        }
        public DataTable GetAllDistrictList()
        {
            TblGlobalDistrictTableAdapter ta = new TblGlobalDistrictTableAdapter();
            return ta.GetDistrictListData();
        }
        public DataTable GetBankBranchList(int bankid, int distid)
        {
            QryBankInfoTableAdapter ta = new QryBankInfoTableAdapter();
            DataTable dt = new DataTable();
            dt = ta.GetBankBranchData(bankid, distid);
            return ta.GetBankBranchData(bankid, distid);
        }



    }
}
