using HR_DAL.Internal.IntrnalTransferTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.Internal
{
    public class InternalAutoSearch_BLL
    {
        public List<string> AutoSearchEmpData(string strSearchKey)
        {
            List<string> result = new List<string>();
            EmpAutosearchDataTableTableAdapter empList= new EmpAutosearchDataTableTableAdapter();
            DataTable oDT = new DataTable();
            oDT = empList.AutoSearchEmpGetData(strSearchKey);
            //oDT = SpareItemList.SearPartsGetData(whid,strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strEmpName"].ToString());
                }
            }
            return result;
        }

        public List<string> AutoSearchEmpDataCC(string strSearchKeyCC)
        {
            List<string> result = new List<string>();
            EmpAutosearchDataTableTableAdapter empListc = new EmpAutosearchDataTableTableAdapter();
            DataTable oDT = new DataTable();
            oDT = empListc.CCMailGetData(strSearchKeyCC);
            //oDT = SpareItemList.SearPartsGetData(whid,strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strEmpName"].ToString());
                }
            }
            return result;
        }
    }
}
