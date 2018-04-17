using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.CurrencyTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class Currency
    {
        public ListItemCollection GetCurrData()
        {
            ListItemCollection col = new ListItemCollection();
            QryCurrencyTableAdapter adp = new QryCurrencyTableAdapter();

            CurrencyTDS.QryCurrencyDataTable tbl = adp.GetCurrencyData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strCurrency, tbl[i].intID.ToString()));
            }
            return col;
        }
    }
}
