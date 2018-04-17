using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global.ApplicationTypeTDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Global;
using HR_DAL.Global.CountryTDSTableAdapters;
using System.Data;

namespace HR_BLL.Global
{
    public class Country
    {
        #region Object Declare
        SprGetCountryListTableAdapter objSprGetCountryListTableAdapter = new SprGetCountryListTableAdapter();

        #endregion
        #region Method
        public ListItemCollection GetCountryList()
        {
            //Summary    :   This function will use to Load Get CountryList for countryDropdown load
            //Created    :   Md. Yeasir Arafat / FEB-19-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            SprGetCountryListTableAdapter objSprGetCountryListTableAdapter = new SprGetCountryListTableAdapter();
            CountryTDS.SprGetCountryListDataTable tbl = objSprGetCountryListTableAdapter.GetData();
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                //col.Add(new ListItem(tbl[index].strCountry.ToString(), tbl[index].strCountryCode.ToString() + "#" + tbl[index].intCountryID.ToString()));
                col.Add(new ListItem(tbl[index].strCountry.ToString(), tbl[index].strCountryCode.ToString()));
            }

            return col;
        }

        public DataTable GetAllCountry()
        {
            return objSprGetCountryListTableAdapter.GetData();
        }


        #endregion
    }
}
