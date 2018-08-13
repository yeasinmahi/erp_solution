using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.PolicyDoc.PolicyTDSTableAdapters;

namespace HR_BLL.PolicyBLL
{
    public class PolicyBLL
    {
        public DataTable getPolicyRpt(int enroll)
        {
            try
            {
                sprPolicyDocTableAdapter adp = new sprPolicyDocTableAdapter();
                return adp.GetData(enroll);
            }
            catch { return new DataTable(); }
        }

        public string  getDocinsertAcno(int docid, int Enroll)
        {
            string msg = "";
            try
            {
                sprPolicyDocAcknowledgementInsertTableAdapter adp = new sprPolicyDocAcknowledgementInsertTableAdapter();
                adp.GetDocInsert(docid, Enroll,ref msg);
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }
    }
}
