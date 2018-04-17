using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HR_DAL.Global;
using HR_DAL.Global.HolidayTDSTableAdapters;
using System.Data;

namespace HR_BLL.Global
{
   public class Holiday
    {
       
       public ListItemCollection LoadHolidayForDropdown()
       {
           //Summary    :   This function will use to get holiday name and id 
           //Created    :   Md. Yeasir Arafat / May-10-2012
           //Modified   :   
           //Parameters :   

           ListItemCollection col = new ListItemCollection();

           tblEmployeeHolidaysTableAdapter objtblEmployeeHolidaysTableAdapter = new tblEmployeeHolidaysTableAdapter();
           HolidayTDS.tblEmployeeHolidaysDataTable tbl = objtblEmployeeHolidaysTableAdapter.GetData();

           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               col.Add(new ListItem(tbl[i].strHolidayName, tbl[i].intHolidayID.ToString()));
           }


           return col;
       }

       public DataTable GetHolidayList()
       {
           tblEmployeeHolidaysTableAdapter adp = new tblEmployeeHolidaysTableAdapter();
           return adp.GetData();
       }


    }
}
