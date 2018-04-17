using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales.Report;
using SAD_DAL.Sales.Report.ChallanTDSTableAdapters;

namespace SAD_BLL.Sales.Report
{
    public class Challan
    {

        public void Remove(string challanId, string user)
        {
            SprSalesChallanRemoveTableAdapter ta = new SprSalesChallanRemoveTableAdapter();
            ta.GetData(long.Parse(challanId), int.Parse(user));
        }
        public ChallanTDS.SprSalesChallanInfoDataTable GetData(string id, string userId, string separator, ref DateTime date, ref string unitName
            , ref string unitAddress, ref string userName, ref string challanNo, ref string customerName
            , ref string customerPhone, ref string delevaryAddress, ref string otherInfo
            , ref string vehicle, ref string extra, ref decimal? extAmount, ref string propitor
            , ref string driver, ref string driverPh, ref string charge, ref string logistic, ref string incentive
            , ref bool isLogBasedOnUOM, ref bool isCharBasedOnUOM, ref bool isIncenBasedOnUOM)
        {
            SprSalesChallanInfoTableAdapter ta = new SprSalesChallanInfoTableAdapter();
            DateTime? dt = null;
            bool? isLogBasedOnUOM_ = null, isCharBasedOnUOM_ = null, isIncenBasedOnUOM_ = null;

            ChallanTDS.SprSalesChallanInfoDataTable table = ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref extra, ref extAmount, ref propitor, ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM_, ref isCharBasedOnUOM_, ref isIncenBasedOnUOM_);

            date = dt.Value;
            isLogBasedOnUOM = isLogBasedOnUOM_.Value;
            isCharBasedOnUOM = isCharBasedOnUOM_.Value;
            isIncenBasedOnUOM = isIncenBasedOnUOM_.Value;

            return table;
        }
        
       

        public ChallanTDS.SprTripChallanInfoDataTable GetTripData(string id, string userId, string separator, ref DateTime date, ref string unitName
            , ref string unitAddress, ref string userName, ref string challanNo,ref string doNo, ref string customerName
            , ref string customerPhone,ref string distributionPoint,ref string contactAt,ref string contactPhone, ref string delevaryAddress, ref string otherInfo
            , ref string vehicle, ref string extra, ref decimal? extAmount
            , ref string driver, ref string driverPh, ref string charge, ref string logistic, ref string incentive
            , ref bool isLogBasedOnUOM, ref bool isCharBasedOnUOM, ref bool isIncenBasedOnUOM)
        {
            SprTripChallanInfoTableAdapter ta = new SprTripChallanInfoTableAdapter();
            DateTime? dt = null;
            bool? isLogBasedOnUOM_ = null, isCharBasedOnUOM_ = null, isIncenBasedOnUOM_ = null;

            ChallanTDS.SprTripChallanInfoDataTable table = ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo,ref doNo
                , ref customerName, ref customerPhone, ref distributionPoint, ref contactAt, ref contactPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref extra, ref extAmount, ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM_, ref isCharBasedOnUOM_, ref isIncenBasedOnUOM_);

            date = dt.Value;
            isLogBasedOnUOM = isLogBasedOnUOM_.Value;
            isCharBasedOnUOM = isCharBasedOnUOM_.Value;
            isIncenBasedOnUOM = isIncenBasedOnUOM_.Value;

            return table;
        }




        public ChallanTDS.SprTripChallanInfoCustomizeDataTable GetTripDataCustomize(string id, string userId, string separator, ref DateTime date, ref string unitName
           , ref string unitAddress, ref string userName, ref string challanNo, ref string doNo, ref string customerName
           , ref string customerPhone, ref string distributionPoint, ref string contactAt, ref string contactPhone, ref string delevaryAddress, ref string otherInfo
           , ref string vehicle, ref string extra, ref decimal? extAmount
           , ref string driver, ref string driverPh, ref string charge, ref string logistic, ref string incentive
           , ref bool isLogBasedOnUOM, ref bool isCharBasedOnUOM, ref bool isIncenBasedOnUOM)
        {
            SprTripChallanInfoCustomizeTableAdapter ta = new SprTripChallanInfoCustomizeTableAdapter();
            DateTime? dt = null;
            bool? isLogBasedOnUOM_ = null, isCharBasedOnUOM_ = null, isIncenBasedOnUOM_ = null;

            ChallanTDS.SprTripChallanInfoCustomizeDataTable table = ta.GetDataTripChallanInfoCustomize(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo, ref doNo
                , ref customerName, ref customerPhone, ref distributionPoint, ref contactAt, ref contactPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref extra, ref extAmount, ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM_, ref isCharBasedOnUOM_, ref isIncenBasedOnUOM_);

            date = dt.Value;
            isLogBasedOnUOM = isLogBasedOnUOM_.Value;
            isCharBasedOnUOM = isCharBasedOnUOM_.Value;
            isIncenBasedOnUOM = isIncenBasedOnUOM_.Value;

            return table;
        }

    }
}
