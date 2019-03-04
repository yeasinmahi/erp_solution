using System;
using System.Data;
using DAL.CurrencyTableAdapters;

namespace BLL.DropDown
{
    public class Currency
    {
        public DataTable GetCurrency()
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
    }
}
