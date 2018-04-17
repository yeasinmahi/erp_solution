using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.TFSDAL.TestTableAdapters;

namespace SAD_BLL.TFSBLL
{
    public class test
    {
        public System.Data.DataTable getReportproduct()
        {
            tblItemTableAdapter getitem = new tblItemTableAdapter();
            return getitem.GetItemName();
        }
    }
}
