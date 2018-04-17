using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.DesignationTDSTableAdapters;

namespace HR_BLL.Global
{
    public class Designation
    {
        public DesignationTDS.TblUserDesignationDataTable GetAllDesignation()
        {
            TblUserDesignationTableAdapter ta = new TblUserDesignationTableAdapter();
            return ta.GetAllDesignationData();
        }
    }
}
