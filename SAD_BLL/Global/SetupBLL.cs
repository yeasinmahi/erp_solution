using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Global.setupDALTableAdapters;

namespace SAD_BLL.Global
{
    public class SetupBLL
    {
        public DataTable getRegionlist(int unitid)
        {
            try
            {
                tblItemPriceManagerTableAdapter adp = new tblItemPriceManagerTableAdapter();
                return adp.GetRegionList(unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getAreaList(int unitid, int Regionid)
        {
            try
            {
                tblItemPriceManagerTableAdapter adp = new tblItemPriceManagerTableAdapter();
                return adp.GetAreaList(unitid, Regionid);
            }
            catch { return new DataTable(); }
        }

        public string getEntryforSetup(int Regionid, int Lavelid, string region, int unitid, string Code, string email, int jsoid, string contact)
        {
            string msg = "";
            try
            {
                tblItemPriceManager1TableAdapter adp = new tblItemPriceManager1TableAdapter();
                 adp.InsertSetup(Regionid, Lavelid, region, unitid, Code, email, jsoid, contact);
                msg = "Successfully Save";
            }
            catch (Exception e){ msg = e.ToString(); }
            return msg;
        }

        public string getEmailupdate(string email, string contact, int id)
        {
            string msg = "";
            try
            {
                tblItemPriceManagerUpdateTableAdapter adp = new tblItemPriceManagerUpdateTableAdapter();
                adp.GetEmailUpdate(email,contact,id);
                msg = "Successfully Update";
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public string getContact(string Contact,int lavelid, int geoid,int unitid,int intpart)
        {
            string msg = "";
            try
            {
                if (intpart == 1)
                {
                    tblItemPriceManager2TableAdapter adp = new tblItemPriceManager2TableAdapter();
                    adp.GetContactno(Contact, lavelid, unitid, geoid);
                    msg = "Successfully Update";
                }
                else
                {
                    tblItemPriceManager2TableAdapter adp = new tblItemPriceManager2TableAdapter();
                    adp.GetEmailupdate(Contact, lavelid, unitid, geoid);
                    msg = "Successfully Update";
                }
            }
            catch (Exception e) { msg = e.ToString(); }
            return msg;
        }

        public DataTable getinfoShow( int unitid)
        {
            try
            {
                tblItemPriceManager3TableAdapter adp = new tblItemPriceManager3TableAdapter();
                return adp.Getinfo( unitid);
            }
            catch { return new DataTable(); }
        }
    }
}
