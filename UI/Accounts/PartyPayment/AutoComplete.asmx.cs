using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]

    public class AutoComplete : WebService
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();

        public AutoComplete()
        {
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetWithoutExpenceList(string strSearchKey, string struserid)
        {
            //struserid = "1019";
            DataTable dt = objPartyBill.GetWithoutExpenceHeadList(int.Parse(struserid), strSearchKey);
            List<string> items = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["AccountName"].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetExpenceList(string strSearchKey, string struserid)
        {
            //struserid = "1019";
            DataTable dt = objPartyBill.GetExpenceHeadList(int.Parse(struserid), strSearchKey);
            List<string> items = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["AccountName"].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
    
    }
}
