using HR_DAL.Document_Inventory.docFileLocationTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Document_Inventory
{
    public class docLocationConfig_BLL
    {
        public string DocConfigSubmit(int Part,int locationId, int fileId, int docId, string naration, int enroll)
        {
            string rtnMessage = "";
            try
            {

                SprDocFileLocationConfigureTableAdapter doc = new SprDocFileLocationConfigureTableAdapter();
                doc.GetDocLocationConfigData(Part, locationId, fileId, docId, naration, enroll, ref rtnMessage);

            }
            catch { rtnMessage = "0"; }
            return rtnMessage;
        }

        public DataTable DocQrCodeDetalis(int Part, int locationId, int fileId, int docId, string naration, int enroll)
        {
            try
            {
                string rtnMessage = "";

                SprDocFileLocationConfigureTableAdapter doc = new SprDocFileLocationConfigureTableAdapter();
               return doc.GetDocLocationConfigData(Part, locationId, fileId, docId, naration, enroll, ref rtnMessage);


            }
            catch { return new DataTable(); }
        }
    }
}
