using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Mirc;
using DAL.Accounts.Mirc.MircTDSTableAdapters;
using System.Globalization;

namespace BLL.Accounts.Mirc
{
   public class MircReader
    {
       public MircTDS.SprMircGetReadDataDataTable GetErrorData(int typeID)
       {
           SprMircGetReadDataTableAdapter adp = new SprMircGetReadDataTableAdapter();
           return adp.GetUnRecognizedData(typeID);
       }

       public void UpdateErrorData(int ID,string strDocType,string  strDocNumber,string  strBranchCode,string  strAccountNumber,string  original_intID,string  original_dteDocDate,string  original_monAmount)
       {

       }


       public void UpdateErrorDataManual(string strDocType, string strDocNumber, string strBranchCode, string strAccountNumber, string dteDocDate, string monAmount,string ID)
       {
           SprMircUpdateTableAdapter adp = new SprMircUpdateTableAdapter();
           DateTime? dteDoc=null;
           DateTimeFormatInfo dtf = new DateTimeFormatInfo();
           dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
           dteDoc = Convert.ToDateTime(dteDocDate, dtf);  
           try
           {
               adp.UpdateAllData(strDocType,strDocNumber,strBranchCode,strAccountNumber,dteDoc,decimal.Parse(monAmount),int.Parse(ID));
           }
           catch
           {
           }
       }

       public void UpdateDateAndAmountOfMircDocument(int id, DateTime date, decimal amount)
       {
           SprMircUpdateDateAndAmountTableAdapter adp = new SprMircUpdateDateAndAmountTableAdapter();
           try
           {
               adp.UpdateDateAmountData(id, date, amount);
           }
           catch
           {
           }
       }
    }
}
