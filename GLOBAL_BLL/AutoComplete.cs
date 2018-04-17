using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOBAL_BLL
{
    public class AutoComplete
    {
        public List<string> AutoSearchEmployee(string struserid, string station, string strSearchKey)
        {
            List<string> result = new List<string>();
            //SprAutoSearchEmployeeFilterByJobStationTableAdapter objSprAutoSearchEmployeeFilterByJobStationTableAdapter = new SprAutoSearchEmployeeFilterByJobStationTableAdapter();
            //DataTable oDT = new DataTable();
            //oDT = objSprAutoSearchEmployeeFilterByJobStationTableAdapter.AutoSearchEmployeeFilterByJobStation(intLoginId, intJobStationId, strSearchKey);
            //if (oDT.Rows.Count > 0)
            //{
            //    for (int index = 0; index < oDT.Rows.Count; index++)
            //    {
            //        result.Add(oDT.Rows[index]["strEmployeeNameWithCode"].ToString());
            //    }

            //}
            return result;
        }
    }
}
