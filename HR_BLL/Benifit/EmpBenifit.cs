using HR_DAL.Benifit.EmpBenifitEntryTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Benifit
{
    public class EmpBenifit
    {
        public DataTable InsertBenifitInfo(int intpart, int intJobsation, int intEmpID,string xml)
        {
            string msg = "";
            try
            {
                SprBenifit_EntryTableAdapter adp = new SprBenifit_EntryTableAdapter();
                return adp.InsertBenifitData(intpart,intJobsation,intEmpID,xml);
                //return msg = "Submitted Successfully";
            }
            catch (Exception ex)
            {
                //return msg = ex.ToString();
                return new DataTable();
            }
                
            
        }
    }
}
