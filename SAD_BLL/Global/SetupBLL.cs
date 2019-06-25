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

        public void saveRegion(Int32 unitID, string region, Int32 regionEnroll, string mobileNo, string department, Int32 userID)
        {
            QueriesTableAdapter objQue = new QueriesTableAdapter();

            // This Hard Coded Parameter Exist in Providing Excel Code

            Int32 regionID =1, areaID=6, territoryID=7, pointID=8, zoneID=9, clasterID=10, custid=300494, areaEnroll=58057;
            Int32 territoryEnroll = 58058, pointEnroll = 58059, zoneEnroll = 58060, clasterEnroll = 58061, part = 1;
            string area = "Jessore", territory = "Nowapara", point = "Keshobpur", zone = "keshobpur", claster = "Magurkhali", officeEmail="";

            try
            {
                objQue.RegionSetupAGCustAdd(unitID,custid,region, regionEnroll, area, areaEnroll, territory, territoryEnroll, point, pointEnroll, zone, zoneEnroll, claster, clasterEnroll, userID,part, regionID, areaID, territoryID, pointID, zoneID, clasterID, mobileNo,department, officeEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
