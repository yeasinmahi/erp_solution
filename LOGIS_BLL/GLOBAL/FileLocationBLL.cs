using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.GLOBAL.LocationFileTDSTableAdapters;

namespace LOGIS_BLL.GLOBAL
{
    public class FileLocationBLL
    {
        public string getinsertLocationofFile(string locationName, int locationid, int enroll)
        {
           
            string msg = "";
            try
            {
                tblFileLocationTableAdapter adp = new tblFileLocationTableAdapter();
                adp.GetLocationDataEntry(locationName, locationid, enroll);
                msg = "Successfully";
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public string getinsertLocationofFileName(string locationName, int locationid, int enroll)
        {
            string msg = "";
            try
            {
                tblFileNameTableAdapter adp = new tblFileNameTableAdapter();
                adp.GetFileNameEntry(locationName, locationid, enroll);
                msg = "Successfully";
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
    }
}