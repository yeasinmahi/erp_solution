using Purchase_DAL.Importss.Import_DAL_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Purchase_BLL.Imports
{
    public class Import_BLL
    {
        DataSet ds = new DataSet();
        public DataTable ViewData(int number, int type)
        {
            SprQuotationReceivedTableAdapter view = new SprQuotationReceivedTableAdapter();
           
            return view.SPViewGetData(number, type);

         
           
            
        }

       

        public DataTable ViewData2(int number, int type)
        {

            SprQuotationReceivedTableAdapter view2 = new SprQuotationReceivedTableAdapter();

            return view2.SPViewGetData(number, type);
        }

        public DataTable UnitName()
        {
            UnitNameTableAdapter unitnames = new UnitNameTableAdapter();
            return unitnames.UnitNameGetData();
        }

        public DataTable MainIndentView(int unit, int type)
        {
            TblRFQMainTableAdapter statusview = new TblRFQMainTableAdapter();
            return statusview.IndentStatusViewGetData(unit,Convert.ToBoolean(type));
        }

        public void ApproveIndent(int enroll,string remarks,int RQID, int SuppID)
        {
            TblQuotationTableAdapter update1 = new TblQuotationTableAdapter();
            update1.ApprovalUpdate1GetData(enroll, remarks,RQID, SuppID);
        }

        public void ApprovalUpdate2( int SuppID,int RQID)
        {
            TblQuotationTableAdapter update2 = new TblQuotationTableAdapter();
            update2.Update2(SuppID, RQID);
        }
    }
}
