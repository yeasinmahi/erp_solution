using Flogging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOBAL_BLL
{
    public class SeriLog
    {
        public FlogDetail GetFlogDetail(string message,string location,string Layer, Exception ex)
        {
            return new FlogDetail
            {
                Product = "ERP",
                Location = location,
                Layer = Layer,
                UserName = Environment.UserName,
                Hostname = Environment.MachineName,
                Message = message+"\\"+ Layer,
                Exception = ex
            };
        }
    }
}
