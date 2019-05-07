using System;
using System.Data;
using DALOOP.HR;

namespace BLL.HR
{
    public class UnitBll
    {
        private readonly UnitDal _dal = new UnitDal();
        public DataTable GetUnitByWhId(int whId)
        {
            return _dal.GetUnitByWhId(whId);
        }
        public int GetUnitIdByWhId(int whId)
        {
            DataTable dt = _dal.GetUnitByWhId(whId);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["intUnitID"].ToString());
            }
            return 0;
        }
        
        public string GetUnitNameByWhId(int whId)
        {
            DataTable dt = _dal.GetUnitByWhId(whId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strUnit"].ToString();
            }
            return string.Empty;
        }
        public string GetUnitFullNameByWhId(int whId)
        {
            DataTable dt = _dal.GetUnitByWhId(whId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strDescription"].ToString();
            }
            return string.Empty;
        }


    }
}
