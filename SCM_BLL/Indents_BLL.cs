using SCM_DAL.IndentTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
   public class Indents_BLL
    {
        public DataTable DataView(int type, string xmlunit, int wh, int ReqId, DateTime dteDate, int enroll)
        {
            try
            {
                string strmsg = "";
                SprIndentTableAdapter adb = new SprIndentTableAdapter();
                return adb.GetIndentData(type, xmlunit, wh, ReqId, dteDate, enroll,ref strmsg);


            }
            catch {return new DataTable(); }
        }

        public DataTable ProjectParent(int intunit)
        {
            throw new NotImplementedException();
        }

        public string IndentEntry(int Type, string xml, int intWh, int @intReqId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {

                SprIndentTableAdapter adp = new SprIndentTableAdapter();
                adp.GetIndentData(Type, xml, intWh, @intReqId, dteDate, enroll, ref strMsg);

            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }
    }
}
