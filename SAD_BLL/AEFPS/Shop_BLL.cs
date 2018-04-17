using SAD_DAL.AEFPS.ShopTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.AEFPS
{
    public class Shop_BLL
    {
        public DataTable ShopOrder()
        {
            ShopOrderTableAdapter shop = new ShopOrderTableAdapter();
            return shop.GetShopOrderViewData();
        }

        public string ShopOrderSubmit(int Part, string xmlString, int enroll)
        {
            

            string msg = "";
            try
            {
                SprShopOrderEntryTableAdapter ShopOrderEntry = new SprShopOrderEntryTableAdapter();
                ShopOrderEntry.GetShopOrderEntryData(Part, xmlString, enroll, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
    }
}
