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
    }
}
