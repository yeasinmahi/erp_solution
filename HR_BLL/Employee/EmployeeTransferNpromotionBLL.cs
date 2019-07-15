using HR_DAL.Employee.EmployeeTransferNpromotionTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Employee
{
    public class EmployeeTransferNpromotionBLL
    {
        public DataTable GetAllSalesDesignation()
        {
            DataTable dt = new DataTable();
            try
            {
                ChannelToRouteTableAdapter adapter = new ChannelToRouteTableAdapter();
                dt = adapter.GetRtoRddlListData(9, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllSalesDesignationWithoutNSM()
        {
            DataTable dt = new DataTable();
            try
            {
                ChannelToRouteTableAdapter adapter = new ChannelToRouteTableAdapter();
                dt = adapter.GetRtoRddlListData(10, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllChannel()
        {
            DataTable dt = new DataTable();
            try
            {
                ChannelToRouteTableAdapter adapter = new ChannelToRouteTableAdapter();
                dt = adapter.GetRtoRddlListData(8, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllRegion()
        {
            DataTable dt = new DataTable();
            try
            {
                ChannelToRouteTableAdapter adapter = new ChannelToRouteTableAdapter();
                dt = adapter.GetRtoRddlListData(2, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllAreaByRID(int RegionID)
        {
            DataTable dt = new DataTable();
            try
            {
                StateToRouteTableAdapter adapter = new StateToRouteTableAdapter();
                dt = adapter.GetRtoRDataByID(2, null,RegionID,null,null,null,null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllTSMByAID(int AreaID)
        {
            DataTable dt = new DataTable();
            try
            {
                StateToRouteTableAdapter adapter = new StateToRouteTableAdapter();
                dt = adapter.GetRtoRDataByID(3, null, null, AreaID, null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllPointByTID(int TSMID)
        {
            DataTable dt = new DataTable();
            try
            {
                StateToRouteTableAdapter adapter = new StateToRouteTableAdapter();
                dt = adapter.GetRtoRDataByID(4, null, null, null, TSMID, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public string GetEmpNameByEnroll(int EmpID)
        {
            DataTable dt = new DataTable();
            string emp = string.Empty;
            try
            {
                EmployeeTableAdapter adapter = new EmployeeTableAdapter();
                dt = adapter.GetEmployeeNameByEnroll(EmpID);
                if(dt != null && dt.Rows.Count > 0)
                {
                    emp = dt.Rows[0]["strEmployeeName"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return emp;
        }
        public DataTable GetEmployeeDetailsByEnroll(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                tblEmployeeTableAdapter adapter = new tblEmployeeTableAdapter();
                dt = adapter.GetEmployeeDataByEnroll(Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public bool InsertNewEmployeeTransfer(int NewEnroll,DateTime TransferDate, int JobStation, int Department, int GeoID,
            int Channel, int oldDesignation,int userID, int NewDesignation)
        {
            bool result = false;
            try
            {
                UpdateNewEmployeeTransferTableAdapter adapter = new UpdateNewEmployeeTransferTableAdapter();
                int iii =  adapter.InsertNewEmployeeTransfer(NewEnroll, TransferDate, JobStation, Department, GeoID, Channel,
                    oldDesignation, userID, NewDesignation);
                if (iii > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
        public int CheckNewEmployeeTransfer(int EmpID)
        {
            int count = 0;
            try
            {
                UpdateNewEmployeeTransferTableAdapter adapter = new UpdateNewEmployeeTransferTableAdapter();
                object _obj = adapter.CheckNewEmployeeTransfer(EmpID);
                if (_obj != null)
                    count = Convert.ToInt32(_obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return count;
        }

        public string EmployeePromotionAction(int NewEnroll, DateTime PromotionDate, int NewDesignation, int NewChannel, int OldChannel,
            int NewGeoID, int OldGeoId, int UserId)
        {
            string result = string.Empty;
            try
            {
                EmployeeTransferNpromotionActionTableAdapter adapter = new EmployeeTransferNpromotionActionTableAdapter();
                adapter.EmployeeTransferNpromotionUpdate(2, NewEnroll, PromotionDate, NewDesignation, NewChannel, OldChannel,
                    NewGeoID, OldGeoId, UserId,ref result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public string OldEmployeeTransferAction(int NewEnroll, DateTime TransferDate, int NewDesignation, int NewChannel, int OldChannel,
            int NewGeoID, int OldGeoId, int UserId)
        {
            string result = string.Empty;
            try
            {
                EmployeeTransferNpromotionActionTableAdapter adapter = new EmployeeTransferNpromotionActionTableAdapter();
                adapter.EmployeeTransferNpromotionUpdate(3, NewEnroll, TransferDate, NewDesignation, NewChannel, OldChannel,
                    NewGeoID, OldGeoId, UserId, ref result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
        public string OldEmployeeResignAction(int Enroll, DateTime ResignDate, int Designation, int Channel,
            int GeoID, int UserId)
        {
            string result = string.Empty;
            try
            {
                EmployeeTransferNpromotionActionTableAdapter adapter = new EmployeeTransferNpromotionActionTableAdapter();
                adapter.EmployeeTransferNpromotionUpdate(4, Enroll, ResignDate, Designation, Channel, null,
                    GeoID, null, UserId, ref result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
