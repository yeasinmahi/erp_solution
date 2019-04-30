using DALOOP.AFBLSMSServer;
using Model;
using System;
#pragma warning disable 168

namespace BLL.AFBLSMSServer
{
    public class ApiSmsBll
    {
        #region INIT

        private readonly ApiSmsDal _apiSmsDal = new ApiSmsDal();
        #endregion

        public bool InsertApiSms(int poId, string chalanNo, string unitName,string customerPhnNumber,int unitId)
        {
            bool result;
            string sms = "Dear Valued Supplier,Your Supplied Mattrials/Service has been Reached Against PO No "+poId+" and Challan No "+chalanNo +"Payment will be made against actual receiving in to Akij Group ("+unitName+")";

            ApiSmsModel model = new ApiSmsModel
            {
                UnitId = unitId,
                UserName = "Akijadmin",
                Password = "AkijFood@786",
                InsertDate = DateTime.Now,
                PhoneNo = customerPhnNumber,
                Message = sms,
                MaskingClient = "AKIJ GROUP",
            };
            try
            {
                if (model.InsertDate == DateTime.MinValue || model.InsertDate == null)
                {
                    model.InsertDate = DateTime.Now;
                }

                result = _apiSmsDal.InsertApIsms(model);
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
    }
}
