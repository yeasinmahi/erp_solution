using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Vat.Mushok11TDSTableAdapters;
using SAD_DAL.Vat;

namespace SAD_BLL.Vat
{
    public class Mushok11
    {

        public Mushok11TDS.SprVatM11SalesInfoDataTable GetInfoBySales(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string type)
        {
            if (code == "" || code.Length <= 9){code = null;}            
            
            bool? isCompleted = null;
            if (type == "act") { isCompleted = false;}            
            else if (type == "com") { isCompleted = true;}


            if (!isCompleted.Value)
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-1000); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(1000); }
            }
            else
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-7); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(6); }
            }

            SprVatM11SalesInfoTableAdapter ta = new SprVatM11SalesInfoTableAdapter();
            return ta.GetData(int.Parse(unitID), fromDate, toDate, isCompleted, code);

        }

        public void PrintCompleted(string userId,string id)
        {
            SprVatM11SalesInfoTableAdapter ta = new SprVatM11SalesInfoTableAdapter();
            ta.Printed(int.Parse(userId), int.Parse(id));
        }

        public Mushok11TDS.SprVatChallanInfoDataTable GetVatChallanInfo(string id, string userId, string separator, ref DateTime date, ref string unitName
            , ref string unitAddress, ref string userName, ref string challanNo, ref string customerName
            , ref string customerPhone, ref string delevaryAddress, ref string otherInfo
            , ref string vehicle, ref string extra, ref decimal? extAmount, ref string propitor
            , ref string driver, ref string driverPh, ref string charge, ref string logistic, ref string incentive)
        {
            SprVatChallanInfoTableAdapter ta = new SprVatChallanInfoTableAdapter();
            DateTime? dt = null;
            Mushok11TDS.SprVatChallanInfoDataTable table = ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref extra, ref extAmount, ref propitor, ref driver, ref driverPh, ref charge, ref logistic, ref incentive);
            date = dt.Value;
            return table;
        }
    }
}
