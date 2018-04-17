using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.ReligionTDSTableAdapters;

namespace HR_BLL.Global
{
    public class Religion
    {
        public ReligionTDS.TblReligionDataTable GetAllReligion()
        {
            TblReligionTableAdapter ta = new TblReligionTableAdapter();
            return ta.GetAllReligionData();
        }

        //
    }
}
