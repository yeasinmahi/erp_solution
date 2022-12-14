using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchase_DAL;
using Purchase_DAL.MediaTDSTableAdapters;
using System.Data;

namespace Purchase_BLL
{
    public class Media
    {

        public DataTable GetUnit(int intEnroll)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            {
                return adp.GetUnit(intEnroll);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetProgramType()
        {
            ProgramTypeTableAdapter adp = new ProgramTypeTableAdapter();
            try
            {
                return adp.GetProgramType();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetBrand(int intUnitID)
        {
            BrandTableAdapter adp = new BrandTableAdapter();
            try
            {
                return adp.GetBrand(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetBrandType(int intUnitID)
        {
            ComboBoxTableAdapter adp = new ComboBoxTableAdapter();
            try
            {
                return adp.GetBrandType(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public void InsertProgramType(string strProgramType)
        {
            InsertProgramTypeTableAdapter adp = new InsertProgramTypeTableAdapter();
            try
            {
                adp.InsertProgramType(strProgramType);
            }
            catch { }
        }
        public void InsertBrandType(string strBrandType, int intUnitID)
        {
            InsertBrandTypeTableAdapter adp = new InsertBrandTypeTableAdapter();
            try
            {
                adp.InsertBrandType(strBrandType, intUnitID);
            }
            catch { }
        }
        public void InserBrand(string strBrandName, int intTypeID, int intUnitID)
        {
            InsertBrandTableAdapter adp = new InsertBrandTableAdapter();
            try
            {
                adp.InsertBrand(strBrandName, intTypeID, intUnitID);
            }
            catch { }
        }
        public void InserProgram(string strNewProgramName, int intDuration, int intUnitID, int intProgTypeID, int intBrandID)
        {
            InsertProgramTableAdapter adp = new InsertProgramTableAdapter();
            try
            {
                adp.InsertProgram(strNewProgramName, intDuration, intUnitID, intProgTypeID, intBrandID);
            }
            catch { }
        }
        public void InsertSupplier(int intProgTypeID, string strNewSupplierName, string strNewSupplierShortName, int intSupplierMasterID)
        {
            InsertSupplierTableAdapter adp = new InsertSupplierTableAdapter();
            try
            {
                adp.InsertSupplier(intProgTypeID, strNewSupplierName, strNewSupplierShortName, intSupplierMasterID);
            }
            catch { }
        }
        public DataTable GetMasterSupplier()
        {
            SupplierMasterTableAdapter adp = new SupplierMasterTableAdapter();
            try
            {
                return adp.GetMasterSupplier();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetSupplier(int intProgramType)
        {
            SupplierTableAdapter adp = new SupplierTableAdapter();
            try
            {
                return adp.GetSupplier(intProgramType);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetProgramName(int intUnitID, int intProgramType)
        {
            ProgramDetailsTableAdapter adp = new ProgramDetailsTableAdapter();
            try
            {
                return adp.GetProgramName(intUnitID, intProgramType);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPOlist(int intUnitID, DateTime dteDate, int intCustID)
        {
            POCollectionTableAdapter adp = new POCollectionTableAdapter();
            try
            {
                return adp.GetPOList(intUnitID, dteDate, intCustID);
            }
            catch { return new DataTable(); }
        }
        public void InsertProgramScheduleWithoutPO(int intProgramCustID, int intProgramID, DateTime dteStartDateTime, DateTime dteEndDateTime, int intProgramCount,bool ysnScheduleOwn, int intProgramReportID, int intDuration, string strNarration, string strProgramName, int intProgramType, int intUnitID, int intHeight, int intWidth)
        {
            InsertProgramScheduleWPOTableAdapter adp = new InsertProgramScheduleWPOTableAdapter();
            try
            {
                adp.InsertProgramScheduleWithoutPO(intProgramCustID, intProgramID, dteStartDateTime, dteEndDateTime, intProgramCount, ysnScheduleOwn, intProgramReportID, intDuration, strNarration, strProgramName, intProgramType, intUnitID, intHeight, intWidth);
            }
            catch { }
        }
        public void InsertProgramScheduleWihtPO(int intProgramCustID, int intProgramID, DateTime dteStartDateTime, DateTime dteEndDateTime, int intProgramCount, bool ysnScheduleOwn, int intProgramReportID, int intDuration, string strNarration, string strProgramName, int intProgramType, int intUnitID, int intHeight, int intWidth, int intPOID)
        {
            InsertProgramSchedulePOTableAdapter adp = new InsertProgramSchedulePOTableAdapter();
            try
            {
                adp.InsertProgramScheduleWithPO(intProgramCustID, intProgramID, dteStartDateTime, dteEndDateTime, intProgramCount, ysnScheduleOwn, intProgramReportID, intDuration, strNarration, strProgramName, intProgramType, intUnitID, intHeight, intWidth, intPOID);
            }
            catch { }
        }
        public void InsertRyansReport(int intCustID, int intProgramID, DateTime dteStartDateTime, DateTime dteEndDateTime, int intDuration, int intUnitID)
        {
            InsertRyansReportTableAdapter adp = new InsertRyansReportTableAdapter();
            try
            {
                adp.InsertRyansReport(intCustID, intProgramID, dteStartDateTime, dteEndDateTime, intDuration, intUnitID);
            }
            catch { }
        }
        public void InsertOthersReport(int intCustID, int intProgramID, DateTime dteStartDateTime, DateTime dteEndDateTime, int intDuration, int intUnitID)
        {
            InsertOthersReportTableAdapter adp = new InsertOthersReportTableAdapter();
            try
            {
                adp.InsertOthersReport(intCustID, intProgramID, dteStartDateTime, dteEndDateTime, intDuration, intUnitID);
            }
            catch { }
        }
        public DataTable GetDuration(int intID)
        {
            GetDurationTableAdapter adp = new GetDurationTableAdapter();
            try
            {
                return adp.GetDuration(intID);
            }
            catch { return new DataTable(); }
        }



    }
}
