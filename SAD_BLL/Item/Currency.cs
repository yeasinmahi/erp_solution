using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item.CurrencyTDSTableAdapters;
using SAD_DAL.Item;

namespace SAD_BLL.Item
{
    public class Currency
    {
        public CurrencyTDS.TblCurrencyDataTable GetCurrencyInfo()
        {
            TblCurrencyTableAdapter ta = new TblCurrencyTableAdapter();
            return ta.GetActiveData();
        }  
        public CurrencyTDS.TblCurrencyDataTable GetCurrencyInfoByID(string id)
        {
            TblCurrencyTableAdapter ta = new TblCurrencyTableAdapter();
            return ta.GetDataByID(int.Parse(id));
        }  
     
    }
}
