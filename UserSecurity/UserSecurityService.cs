using System;
using System.Collections.Generic;
using System.Text;

using UserSecurity.DAL;
using UserSecurity.DAL.UserLoginInfoTDSTableAdapters; 
using System.Configuration;
using UserSecurity.DAL.UserPasswordTDSTableAdapters; 

/// <summary>
/// Developped By Akramul Haider
/// Copyright © akram
/// </summary>
namespace UserSecurity
{
    public class UserSecurityService
    {
        readonly double sessionTimeout; //120
        readonly string invalidUserMessage; //"Invlid user id or password"
        readonly string onHoldMessage; //"You are on-hold"
        readonly int invalidPasswordAttemptDelay; //100 mili seconds
        
        public UserSecurityService()
        {
            invalidUserMessage = ConfigurationManager.AppSettings["invalidUserMessage"];
            onHoldMessage = ConfigurationManager.AppSettings["onHoldMessage"];
            invalidPasswordAttemptDelay = int.Parse(ConfigurationManager.AppSettings["invalidPasswordAttemptDelay"]);
            sessionTimeout = int.Parse(ConfigurationManager.AppSettings["sessionTimeout"]);
        }

        #region public methods


        public bool ValidatePassword(string userID, string password)
        {
            TblUserSecurityTableAdapter taUserLogin
               = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

            if (tblUserLogin.Rows.Count <= 0) return false;
            if (tblUserLogin[0].strPassword == password)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// if null returned then user is allowed to login
        /// else the error is returned
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>        
        /// <param name="sessionID"></param>
        /// <param name="loginFrom"></param>
        /// <param name="loginIP"></param>
        /// <returns></returns>        
        public String ValidateUser(string userID, string password,
            string sessionID, string loginFrom, string loginIP)
        {

            TblUserSecurityTableAdapter taUserLogin
               = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

            if (tblUserLogin.Count == 0)
            {
                LogInvalidPasswordAttempt(userID, password,
                    loginIP, DateTime.Now, true, false);
                return invalidUserMessage;
            }
            else if (tblUserLogin[0].strPassword == password)//if password properly matched than            
            {

                if (!tblUserLogin[0].IsintLastInactivatedByNull())
                {
                    return onHoldMessage;
                }
                else if (tblUserLogin[0].ysnForceLogout == true)
                {
                    return onHoldMessage;
                }                

                UpdateLogin(tblUserLogin[0], taUserLogin, sessionID, loginFrom, loginIP);
                return null;

            }

            bool isPasswordInvalid = false;
            if (tblUserLogin[0].strPassword != password)
            {
                isPasswordInvalid = true;
            }

            LogInvalidPasswordAttempt(userID, password,
                loginIP, DateTime.Now, false, isPasswordInvalid);
            return invalidUserMessage;

        }



        public void DomainLoginUpdate(string userID,
           string sessionID, string loginFrom, string loginIP)
        {

            TblUserSecurityTableAdapter taUserLogin
               = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

           

                UpdateLogin(tblUserLogin[0], taUserLogin, sessionID, loginFrom, loginIP);

        }

        public void DomainLoginFails(
           string userID,
            string remoteAddress,
           DateTime trialTime
          
           )
        {
            LogInvalidPasswordAttempt(userID, "", remoteAddress, trialTime, true, false);
        }

        /// <summary>
        /// This method should be called periodically to ensure that the user is online
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>

        public bool UpdateUserActivity(string userID, string sessionID)
        {

            TblUserSecurityTableAdapter taUserLogin
                    = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

            if (tblUserLogin.Count == 0)
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            if (
                tblUserLogin[0].IsstrLastLoginSessionIDNull()
                ||
                tblUserLogin[0].strLastLoginSessionID != sessionID
                )
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if (!tblUserLogin[0].IsintLastInactivatedByNull())
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if (tblUserLogin[0].ysnForceLogout == true)
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if
                (
                    tblUserLogin[0].ysnOnline == true &&
          (tblUserLogin[0].dteLastActivity > (DateTime.Now.AddMinutes(-sessionTimeout)))
                )
            {
                tblUserLogin[0].dteLastActivity = DateTime.Now;
                taUserLogin.Update(tblUserLogin[0]);
                //there is no delay(used) while returning true
                return true;
            }

            //delay may be an efficient way...
            //Thread.Sleep(invalidPasswordAttemptDelay);
            return false;

        }

        /// <summary>
        /// This method is used to sign out a user, the session id must match with the current session id.
        /// The valid session id was set while the 
        /// user was logged on.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="sessionID"></param>

        public bool SignOut(string userID, string sessionID)
        {

            TblUserSecurityTableAdapter taUserLogin
                    = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

            if (tblUserLogin.Count == 0)
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if (!tblUserLogin[0].IsstrLastLoginSessionIDNull() &&
                tblUserLogin[0].strLastLoginSessionID == sessionID)
            {
                tblUserLogin[0].ysnOnline = false;
                tblUserLogin[0].dteLastActivity = DateTime.Now;
                tblUserLogin[0].SetstrLastLoginSessionIDNull();
                taUserLogin.Update(tblUserLogin[0]);
                //there is no delay(used) while returning true
                return true;
            }

            //delay may be an efficient way...
            //Thread.Sleep(invalidPasswordAttemptDelay);
            return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>

        public bool ChangePassword(string userID, string oldPassword,
            string newPassword, string sessionID)
        {

            TblUserSecurityTableAdapter taUserLogin
                   = new TblUserSecurityTableAdapter();
            UserLoginInfoTDS.TblUserSecurityDataTable tblUserLogin
                = taUserLogin.GetDataByID(userID);

            if (tblUserLogin.Count == 0)
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if (
                tblUserLogin[0].IsstrLastLoginSessionIDNull()
                ||
                tblUserLogin[0].strLastLoginSessionID != sessionID
                )
            {
                //delay may be an efficient way...
                //Thread.Sleep(invalidPasswordAttemptDelay);
                return false;
            }
            else if (tblUserLogin[0].strPassword == oldPassword)
            {
                tblUserLogin[0].strPassword = newPassword;
                taUserLogin.Update(tblUserLogin[0]);

                TblUserPasswordLogTableAdapter ta = new TblUserPasswordLogTableAdapter();
                ta.Insert(userID, DateTime.Now, newPassword);
                //there is no delay(used) while returning true
                return true;
            }

            //delay may be an efficient way...
            //Thread.Sleep(invalidPasswordAttemptDelay);
            return false;

        }

        #endregion


        #region private methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>        
        /// <param name="remoteAddress"></param>
        /// <param name="trialTime"></param>
        /// <param name="isWrongID"></param>
        /// <param name="isWrongPassword"></param>        
        private void LogInvalidPasswordAttempt(
            string userID,
            string password,
            string remoteAddress,
            DateTime trialTime,
            bool isWrongID,
            bool isWrongPassword
            )
        {

            TblUserInvalidLoginLogTableAdapter taInvalidPasswordLog = new TblUserInvalidLoginLogTableAdapter();
            taInvalidPasswordLog.Insert(userID, trialTime, password,
                remoteAddress, isWrongID, isWrongPassword,
                false);

        }

        private void UpdateLogin(UserLoginInfoTDS.TblUserSecurityRow rowUserSecurity,
            TblUserSecurityTableAdapter taUserSecurity, string sessionID,
            string loginFrom, string loginIP)
        {

            DateTime time = DateTime.Now;
            rowUserSecurity.dteLastActivity = time;
            rowUserSecurity.intFailedPasswordAttemptCount = 0;
            rowUserSecurity.strLastLoginFrom = loginFrom;
            rowUserSecurity.strLastLoginIP = loginIP;
            rowUserSecurity.strLastLoginSessionID = sessionID;
            rowUserSecurity.ysnOnline = true;

            //update
            taUserSecurity.Update(rowUserSecurity);

            //Insert to Log
            TblUserLoginInfoLogTableAdapter ta = new TblUserLoginInfoLogTableAdapter();
            ta.Insert(rowUserSecurity.strAccountName, time, loginIP, loginFrom);

        }

        #endregion
    }
}
