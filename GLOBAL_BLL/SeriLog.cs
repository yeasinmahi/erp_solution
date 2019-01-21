using Flogging.Core;
using System;

namespace GLOBAL_BLL
{
    public class SeriLog
    {
        public FlogDetail GetFlogDetail(string message,string location,string layer, Exception ex)
        {
            return new FlogDetail
            {
                Product = "ERP",
                Location = location,
                Layer = layer,
                UserName = Environment.UserName,
                Hostname = Environment.MachineName,
                Message = message+"\\"+ layer,
                Exception = ex
            };
        }
    }
}
