using SCM_DAL.ProductionOrderTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class ProductionOrderBLL
    {
        public DataTable GetWareHouse(int TypeID,string xml,int WHID,int BOMID,DateTime Date, int Enroll)
        {
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                ProductionOrderTableAdapter adapter = new ProductionOrderTableAdapter();
                dt = adapter.GetProductionOrderCommonData(TypeID, xml, WHID, BOMID, Date, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetLineOrPlant(int TypeID, string xml, int WHID, int BOMID, DateTime Date, int Enroll)
        {
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                ProductionOrderTableAdapter adapter = new ProductionOrderTableAdapter();
                dt = adapter.GetProductionOrderCommonData(TypeID, xml, WHID, BOMID, Date, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetUnitByWH(int TypeID, string xml, int WHID, int BOMID, DateTime Date, int Enroll)
        {
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                ProductionOrderTableAdapter adapter = new ProductionOrderTableAdapter();
                dt = adapter.GetProductionOrderCommonData(TypeID, xml, WHID, BOMID, Date, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public string InsertProductionOrder(int TypeID, string xml, int WHID, int BOMID, DateTime Date, int Enroll)
        {
            string msg = "";
            try
            {
                SP_ProductionOrderTableAdapter adapter = new SP_ProductionOrderTableAdapter();
                adapter.InsertProductionOrderData(TypeID, xml, WHID, BOMID, Date, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return msg;
        }
        public DataTable ProductionOrderApproveReject(int TypeID, string xml, int WHID, int BOMID, DateTime Date, int Enroll)
        {
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                ProductionOrderApproveRejectTableAdapter adapter = new ProductionOrderApproveRejectTableAdapter();
                dt = adapter.GetProductionOrderDataForApprove(TypeID, xml, WHID, BOMID, Date, Enroll, ref msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

    }
}
