using Database;
using Model;
using System;
using System.Data.SqlClient;
#pragma warning disable 168

namespace DALOOP.AFBLSMSServer
{
    public class ApiSmsDal
    {
        #region INIT
        DBUtility _db = new DBUtility();
        #endregion

        public bool InsertApIsms(ApiSmsModel model)
        {
            bool result;
            string sql = string.Empty;
            try
            {
                sql += @"INSERT INTO [AFBLSMSServer].[dbo].[tblAPIsms] ([strPhoneNo], [strMessage], [strSMS], [dteInsertDate]";
                if (model.UnitId > 0)
                    sql += ", [intUnitID]";
                sql += ")";
                sql += @" VALUES (@strPhoneNo, @strSMS, ([AFBLSMSServer].[dbo].[funGPapi] (@strUserName, @strPassword,@strMaskingCli, @strPhoneNo2, @strSMS2)), @dteInsertDateTime";
                if (model.UnitId > 0)
                    sql += ", @intUnitID";
                sql += ")";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@strPhoneNo", model.PhoneNo);
                cmd.Parameters.AddWithValue("@strSMS", model.Message);
                cmd.Parameters.AddWithValue("@strUserName", model.UserName);
                cmd.Parameters.AddWithValue("@strPassword", model.Password);
                cmd.Parameters.AddWithValue("@strMaskingCli", model.MaskingClient);
                cmd.Parameters.AddWithValue("@strPhoneNo2", model.PhoneNo);
                cmd.Parameters.AddWithValue("@strSMS2", model.Message);
                cmd.Parameters.AddWithValue("@dteInsertDateTime", model.InsertDate);
                if (model.UnitId > 0)
                    cmd.Parameters.AddWithValue("@intUnitID", model.UnitId);

                //string sql1 = @"INSERT INTO [AFBLSMSServer].[dbo].[tblAPIsms] ([strPhoneNo], [strMessage], [strSMS], 
                //                [dteInsertDate], [intUnitID])
                //            VALUES (@strPhoneNo, @strSMS, ([AFBLSMSServer].[dbo].[funGPapi] (@strUserName, @strPassword, 
                //                       @strMaskingCli, @strPhoneNo2, @strSMS2)), @dteInsertDateTime, @intUnitID)";
                //SqlCommand cmd = new SqlCommand();
                //cmd.Parameters.AddWithValue("@strPhoneNo", _model.PhoneNo);
                //cmd.Parameters.AddWithValue("@strSMS", _model.SMS);
                //cmd.Parameters.AddWithValue("@strUserName", _model.UserName);
                //cmd.Parameters.AddWithValue("@strPassword", _model.Password);
                //cmd.Parameters.AddWithValue("@strMaskingCli", _model.MaskingClient);
                //cmd.Parameters.AddWithValue("@strPhoneNo2", _model.PhoneNo);
                //cmd.Parameters.AddWithValue("@strSMS2", _model.SMS);
                //cmd.Parameters.AddWithValue("@dteInsertDateTime", _model.InsertDate);
                //cmd.Parameters.AddWithValue("@intUnitID", _model.UnitID);

                result = _db.ExecuteParamDML(cmd, sql);
                
            }
            catch (Exception ex)
            {
                return false;
                //throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
