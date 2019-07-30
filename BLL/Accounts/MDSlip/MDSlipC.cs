using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL.Accounts.MDSlip;
using DAL.Accounts.MDSlip.MDSlipTDSTableAdapters;

namespace BLL.Accounts.MDSlip
{
    public  class MDSlipC
    {

        public MDSlipTDS.SprAccountsMDSlipGetDataDataTable GetDataForMDSlip(DateTime date,int unitID,int userID,ref string unitName,ref string unitAddress,ref string userName,ref decimal? wcUsed,ref decimal? plUsed,ref decimal? wcLimit,ref decimal? plLimit,ref decimal? cashInHand,ref decimal? cashAtBank)
        {
            SprAccountsMDSlipGetDataTableAdapter adp = new SprAccountsMDSlipGetDataTableAdapter();
            return adp.GetData(date,unitID,userID,ref unitName,ref unitAddress,ref userName,ref wcUsed,ref plUsed,ref wcLimit,ref plLimit,ref cashAtBank,ref cashInHand);
        }

        public MDSlipTDS.SprAccountsMDSlipQueryDataDataTable GetDataForMDAlipQuery(DateTime date, int unitID, string type)
        {
            SprAccountsMDSlipQueryDataTableAdapter adp = new SprAccountsMDSlipQueryDataTableAdapter();
            return adp.GetQueryData(date, type, unitID, 0);
        }

        public DataTable GetUnit(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                sprGetUnitTableAdapter adapter = new sprGetUnitTableAdapter();
                dt = adapter.GetUnitData(Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetMDSlipCGType()
        {
            DataTable dt = new DataTable();
            try
            {
                tblMDSlipCustomGroupTypeTableAdapter adapter = new tblMDSlipCustomGroupTypeTableAdapter();
                dt = adapter.GetCOAGruopTypeData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetMDSlipCustomName(int UnitID, int MDSlipCGTypeID)
        {
            DataTable dt = new DataTable();
            try
            {
                tblMDSlipCustomGroupTableAdapter adapter = new tblMDSlipCustomGroupTableAdapter();
                dt = adapter.GetCustomNameData(UnitID, MDSlipCGTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetMDSlipCustomData(int UnitID)
        {
            DataTable dt = new DataTable();
            try
            {
                tblAccountsChartOfAccTableAdapter adapter = new tblAccountsChartOfAccTableAdapter();
                dt = adapter.GetMDSlipCustomData(UnitID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetChieldMDSlipCustomData(int UnitID, int ParentID)
        {
            DataTable dt = new DataTable();
            try
            {
                tblAccountsChartOfAccTableAdapter adapter = new tblAccountsChartOfAccTableAdapter();
                dt = adapter.GetChieldMDSlipDataData(UnitID, ParentID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public int CheckMDSlipAccount(int AccountID)
        {
            int iii = 0;
            try
            {
                tblAccountsChartOfAccTableAdapter adapter = new tblAccountsChartOfAccTableAdapter();
                object _obj = adapter.CheckExistMDSAccount(AccountID);
                if (_obj != null)
                    iii = Convert.ToInt32(_obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return iii;
        }
        public bool InsertMDSlipCustomData(int UnitID,int intGroupID,int intAccountID, string strCode,string AccountsName, int Enroll)
        {
            bool result = false;
            try
            {
                tblAccountsChartOfAccTableAdapter adapter = new tblAccountsChartOfAccTableAdapter();
                int iii = adapter.InsertMDSlipCustomizeData(UnitID, intGroupID, intAccountID, strCode, AccountsName, Enroll);
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
        public bool DeleteMDSlipAccount(int AccountID)
        {
            int iii = 0;
            bool result = false;
            try
            {
                tblAccountsChartOfAccTableAdapter adapter = new tblAccountsChartOfAccTableAdapter();
                iii = adapter.DeleteMDSlipCustomData(AccountID);
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

    }
}
