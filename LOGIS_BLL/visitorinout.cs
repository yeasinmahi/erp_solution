using LOGIS_DAL.VisitorGetInOutTSDTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIS_BLL
{
    public class visitorinout
    {
        public void visitorin(string name, string type, int vienroll, string contact, string where, string objective, string transport, string area, string contactperson, Int32 enroll, Int32 UnitId, string vehicle)
        {
            TblVisitiorGetInOutTableAdapter visitordata = new TblVisitiorGetInOutTableAdapter();
            visitordata.VisitorInGetData(name, type, vienroll, contact, where, objective, transport, area, contactperson, enroll, UnitId, vehicle);
        }

        public DataTable visitoroutinformation(int UnitId)
        {
            TblVisitiorGetInOut1TableAdapter info = new TblVisitiorGetInOut1TableAdapter();
            return info.visitorInInreportGetData(UnitId);
        }

        public void visitorout(int intId)
        {
            TblVisitiorGetInOut2TableAdapter vout = new TblVisitiorGetInOut2TableAdapter();
            vout.visitoroutGetData(intId);
        }





    }
}
