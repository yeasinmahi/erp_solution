using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.RevenueDLL.RevinueTDSTableAdapters;

namespace SAD_BLL.RevenueBLL
{
    public class RevenueClsBLL
    {
        public DataTable getRevinuewList(int parentid)
        {
            try
            {
                tblRevinueCenterTableAdapter adp = new tblRevinueCenterTableAdapter();
                return   adp.GetMainHead(parentid);
            }
            catch { return new DataTable(); }
        }

        public void getRevinueCenterCreate(int intheadid, string headname, int intUnitid, int intEnroll,int levelid)
        {
            try
            {
                //  tblRevinueCenter1TableAdapter adp = new tblRevinueCenter1TableAdapter();
                sprRevenueCenterCreateTableAdapter adp = new sprRevenueCenterCreateTableAdapter();
                adp.GetData(intheadid, headname, intUnitid, intEnroll, levelid);
            }
            catch { }
        }

        public DataTable getMainHead()
        {
            try
            {
                tblCCSubListTableAdapter adp = new tblCCSubListTableAdapter();
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }

        public DataTable getRevenue(int whid, DateTime fdae, DateTime tdate, int partsearch, string importLocal)
        {
            try
            {
                sprInventoryMaterialGroupSummaryTableAdapter adp = new sprInventoryMaterialGroupSummaryTableAdapter();
                return adp.GetData(whid, fdae, tdate, partsearch, importLocal);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCCSub(int Mainid)
        {
            try
            {
                tblCCListTableAdapter adp = new tblCCListTableAdapter();
                return adp.GetData(Mainid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getPshow(int Fggroupid)
        {
            
            try
            {
                tblProductListTableAdapter adp = new tblProductListTableAdapter();
               return  adp.GetData(Fggroupid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getyearlist()
        {
            
                 try
            {
                yearlistTableAdapter adp = new yearlistTableAdapter();
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }

        public DataTable getRpt(DateTime dtefdate,int year)
        {
            try
            {
                sprRevenueBudgetVSSalesReportTableAdapter adp = new sprRevenueBudgetVSSalesReportTableAdapter();
                return adp.GetData(dtefdate, year);
            }
            catch { return new DataTable(); }
        }

        public string getCreditnoteCreate(int rvid, int intItemid, decimal janA, decimal febA, decimal marchA, decimal aprilA, decimal mayA, decimal juneA, decimal julyA, decimal augA, decimal sepA, decimal octA, decimal nctA, decimal decA, int enroll, int lineid, int unitid )
        {
            string msg = "";
            try
            {
                sprRevenueBudgetEntryTableAdapter adp = new sprRevenueBudgetEntryTableAdapter();
                 adp.GetData(rvid,intItemid,janA,febA,marchA,aprilA,mayA,juneA,julyA,augA,sepA,octA,nctA,decA,enroll,lineid,unitid);
                msg = "Successfully";
            }
            catch(Exception e) { msg = e.ToString(); }
            return msg;
        }

       

        public DataTable GetAreaG(int Regionid)
        {
            
            try
            {
                tblAreaGTableAdapter adp = new tblAreaGTableAdapter();
                return adp.GetData(Regionid);
            }
            catch { return new DataTable(); }

        }

        public DataTable getRegionG(int regionid)
        {
            try
            {
                tblRegionGTableAdapter adp = new tblRegionGTableAdapter();
                return adp.GetRegionG(regionid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getLineG()
        {
            try
            {
                tblItemFGGroupTableAdapter adp = new tblItemFGGroupTableAdapter();
                return adp.GetLineList();
            }
            catch { return new DataTable(); }
        }

        public void getUpdateLine(int lineidg, int RCIdg)
        {
            try
            {
                tblRevinueCenterUpdateBridgeTableAdapter adp = new tblRevinueCenterUpdateBridgeTableAdapter();
                adp.GetData(lineidg, RCIdg);
            }
            catch { }
        }
      

        public void getRegionUpdate(int RegionG, int RCIdg)
        {
            throw new NotImplementedException();
        }
    }
}
