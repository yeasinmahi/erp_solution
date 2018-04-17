using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;


namespace Purchase_BLL.Commercial
{
    public class PaymentSteps
    {

        public ListItemCollection GetPaymentSteps(string userUnitID)
        {
            ListItemCollection lt = new ListItemCollection();

            lt.Add(new ListItem("Open/Amendment","OpenAmen"));
            lt.Add(new ListItem("FC Payment", "FC"));
            lt.Add(new ListItem("Insurance Premium", "InsPre"));
            lt.Add(new ListItem("Duty", "Duty"));
           // lt.Add(new ListItem("Port Dues", "PD"));
           // lt.Add(new ListItem("Shipping Dues", "SHD"));
           // lt.Add(new ListItem("Transport Dues", "TRD"));
            lt.Add(new ListItem("C&F", "CNF"));

            if (userUnitID == "3")
            {
                lt.Add(new ListItem("BTMA Charge", "BTMA"));
            }

            lt.Add(new ListItem("Other Charge", "Oth"));
            
            return lt;
        }

    }
}
