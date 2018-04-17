using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.PF_Transfer_TDSTableAdapters;
using System.Data;

namespace HR_BLL.Benifit
{
   public class PF_Transfer_BLL
    {
       
           public string TransferUnitwiseSelectedProvidentFund(int? intUnitId, string strListOfMonthAndYear, string strListOfMonthAndYearShouldBeUnchecked, string strSeparator)
           {
               //Summary    :   This function will use to transfer provident amount to accountds
               //Created    :   Md. Yeasir Arafat / August-13-2012
               //Modified   :   
               //Parameters :   return strTransferStatus

               SprPF_TransferTableAdapter tbl = new SprPF_TransferTableAdapter();
               string strTransferStatus = "";
               tbl.TransferProvidentFund(intUnitId, strListOfMonthAndYear,strListOfMonthAndYearShouldBeUnchecked, strSeparator, ref strTransferStatus);
               return strTransferStatus;
           }
           public DataTable GetTransferAmountByVoucharCode(string strVoucherCode)
           {
               //Summary    :   This function will use to get transferred amount by voucharCode
               //Created    :   Md. Yeasir Arafat / August-14-2012
               //Modified   :   
               //Parameters :   return DataTable

               try
               {
                  SprPF_GetTransferAmountByVoucharCodeTableAdapter objSprPF_GetTransferAmountByVoucharCodeTableAdapter =
                   new SprPF_GetTransferAmountByVoucharCodeTableAdapter();
                  return objSprPF_GetTransferAmountByVoucharCodeTableAdapter.GetTransferAmountByVoucharCode(strVoucherCode);
               }
               catch (Exception)
               {
                   DataTable oDataTable = new DataTable();
                   return oDataTable;
               }
               
           }
           public DataTable GetAllNonTransferredTransactionForDatagrid(int? intSoftwareLoginUserID)
           {
               //Summary    :   This function will use to get non recieved transaction amount by login user id
               //Created    :   Md. Yeasir Arafat / August-25-2012
               //Modified   :   
               //Parameters :   return DataTable

               try
               {
                   SprPF_TransferGetAllNonTransferredTransactionForDatagridTableAdapter objSprPF_TransferGetAllNonTransferredTransactionForDatagridTableAdapter =
                   new SprPF_TransferGetAllNonTransferredTransactionForDatagridTableAdapter();
                   return objSprPF_TransferGetAllNonTransferredTransactionForDatagridTableAdapter.GetAllNonTransferredTransactionForDatagrid(intSoftwareLoginUserID);
               }
               catch (Exception)
               {
                   DataTable oDataTable = new DataTable();
                   return oDataTable;
               }
               
           }
       

    }
}
