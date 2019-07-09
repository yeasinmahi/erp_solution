using DAL.Accounts.Import.ImportAdjustmentTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.Import
{
    public class ImportAdjustmentVoucherBLL
    {
        public DataTable GetAllUnitByEnroll(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                UnitTableAdapter adapter = new UnitTableAdapter();
                dt = adapter.GetUnitData(Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }

        public DataTable GetImportAdjustmentReportForVoucherData(int intUnitID,int intUserID,DateTime dteFromDate,DateTime dteToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                ImportAdjustmentReportForVoucherTableAdapter adapter = new ImportAdjustmentReportForVoucherTableAdapter();
                dt = adapter.GetImportAdjustmentReportForVoucherData(intUnitID, intUserID, dteFromDate, dteToDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }

        public string ImportVoucherAdjustment(int UnitId,int UserID,string xml)
        {
            string output = string.Empty;
            try
            {
                sprImportAdjustmentVoucherTableAdapter adapter = new sprImportAdjustmentVoucherTableAdapter();
                adapter.ImportAdjustmentVoucher(UnitId, UserID, xml, ref output);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return output;
        }

    }
}
