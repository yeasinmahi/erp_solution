﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flogging.Core
{
    public class FlogDetail
    {
		public DateTime TimeStamp { get; set; }
		public string Message { get; set; }

		public FlogDetail()
		{
			TimeStamp = DateTime.Now;
		}

		// WHERE
		public string Product { get; set; }
		public string Layer { get; set; }
		public string Location { get; set; }
		public string Hostname { get; set; }

		// WHO
		public string UserId { get; set; }
		public string UserName { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }

		// EVERTHING ELSE
		public long? ElapsedMilliseconds { get; set; } // only for performance entries
		public Exception Exception { get; set; }
		public string CorrelationId { get; set; } // exception shielding from server to client
		public Dictionary<string, object> AdditionalInfo { get; set; } // catch-all for anything else
	}
}
