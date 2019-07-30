using DAL.Accounts.ChartOfAccount.GLCodeTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.ChartOfAccount
{
    public class GLCodeBLL
    {
        public DataTable GetEmployeeDetails(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                QRYEMPLOYEEPROFILEALLTableAdapter adapter = new QRYEMPLOYEEPROFILEALLTableAdapter();
                dt = adapter.GetEmployeeDetailsData(Enroll);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetGLCodeData(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                sprGLCodeConfitReportTableAdapter adapter = new sprGLCodeConfitReportTableAdapter();
                dt = adapter.GetGLCodeData(Enroll,1,0);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public bool GLCodeBridgeSubmition(int Enroll, string strGLCodeDr, string strGLCodeCr, int ActionBy)
        {
            bool result = false;
            try
            {
                SprGLCodeBridgeTableAdapter adapter = new SprGLCodeBridgeTableAdapter();
                object _obj = adapter.GLCodeSubmition(Enroll, strGLCodeDr, strGLCodeCr, 2, 0, string.Empty, ActionBy);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public DataTable GetUnitData(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                SprGetUnitTableAdapter adapter = new SprGetUnitTableAdapter();
                dt = adapter.GetUnitData(Enroll);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
    }
}
