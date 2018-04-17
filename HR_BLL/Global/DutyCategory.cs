using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.DutyCategoryTDSTableAdapters;

namespace HR_BLL.Global
{
    public class DutyCategory
    {
        public DutyCategoryTDS.TblDutyCatagoryDataTable GetAllDutyCategory()
        {
            TblDutyCatagoryTableAdapter ta = new TblDutyCatagoryTableAdapter();
            return ta.GetDutyCategoryData();
        }
    }
}
