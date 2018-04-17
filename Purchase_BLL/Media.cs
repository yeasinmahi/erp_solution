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
        public DataTable GetProgramType()
        {
            ComboBoxTableAdapter adp = new ComboBoxTableAdapter();
            try
            {
                return adp.GetProgramType();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetUnit(int intEnroll)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            {
                return adp.GetUnit(intEnroll);
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
    }
}
