using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Transfer;
using SAD_DAL.Transfer.TransferTDSTableAdapters;

namespace SAD_BLL.Transfer
{
    public class Transfer
    {
        
        public TransferTDS.SprTransferInfoDataTable GetTransferOrder(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , bool isCompleted, string shippingPoint, string shippingPointTo)
        {
            SprTransferInfoTableAdapter adp = new SprTransferInfoTableAdapter();

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }


            return adp.GetData(int.Parse(unitID), fromDate, toDate, isCompleted, code, int.Parse(shippingPoint), int.Parse(shippingPointTo));

        }

        public void AddUpdateTransfer(string xmlStr, string userId, string unitId
            , DateTime date, DateTime reqDOdate
            ,string narration, string address,string logisVarId, bool isLogistic
            , string currencyId, string salesTypeId            
            , string note, string contatcAt, string ContactPhone
            , string shippingPoint, string shippingPointTo, ref string code, ref string entryId
            )
        {
            long? id = null;
            int? vId = null;
            
            try { id = long.Parse(entryId); }
            catch { }  
            try { vId = int.Parse(logisVarId); }
            catch { }  

            SprTransferTableAdapter ta = new SprTransferTableAdapter();

            ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , narration, address, vId
                , isLogistic, int.Parse(currencyId), int.Parse(salesTypeId)
                , note, contatcAt, ContactPhone, int.Parse(shippingPointTo)
                , int.Parse(shippingPoint), ref code);

            entryId = id.ToString();
        }
    }
}
