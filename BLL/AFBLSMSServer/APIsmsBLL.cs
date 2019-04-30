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

        public bool InsertApiSms(ApiSmsModel model)
        {
            bool result;
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
