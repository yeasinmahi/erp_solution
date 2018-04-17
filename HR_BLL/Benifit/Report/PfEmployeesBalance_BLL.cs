using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.Report.PfEmployeeBalance_TDSTableAdapters;
using System.Data;

namespace HR_BLL.Benifit.Report
{
   public class PfEmployeesBalance_BLL
    {

       public DataTable PfEmployeesBalance(string strEmployeeCode)
       {
           //Summary    :   This function will be used to show report about employee's pf details
           //Created    :   Md. Yeasir Arafat / September-17-2012
           //Modified   :   
           //Parameters :   pf details as data table by employee code

           try
           {
               SprReport_PfEmployeesBalanceTableAdapter tbl = new SprReport_PfEmployeesBalanceTableAdapter();
               return tbl.PfEmployeesBalance(strEmployeeCode);
           }
           catch
           {
               DataTable odt = new DataTable ();
               return odt;
           }
       }
    }
}
