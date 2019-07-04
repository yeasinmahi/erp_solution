﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Global.AfblDistributionSetupTableAdapters;

namespace SAD_BLL.Global
{
    public class AfblDistributionBll
    {
        
        public DataTable GetAFBLGeoList(int parentID, int part)
        {
            DataTable dt = new DataTable();
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
                dt = obj.GetLineList(null, parentID, null, null, null, null, null, part, null, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        
        public DataTable GetAFBLExistGeoInfo(int lineID, int part)
        {
            DataTable dt = new DataTable();
           // int part = 14;
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
                dt = obj.GetLineList(null, null, null, null, null, lineID, null, part, null, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void SaveAFBLLineInfo(string description, string officePhoneNo)
        {
            DataTable dt = new DataTable();
            int part = 1, parentId = 0, levelId = 1, activeEnroll = 0;
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
                dt = obj.GetLineList(description, parentId, activeEnroll, null, levelId, null, null, part, null, officePhoneNo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public void UpdateAFBLLineInfo(string description, string officePhoneNo, int lineId)
        {
            DataTable dt = new DataTable();
            int part = 9;
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
               dt = obj.GetLineList(description, null, null, null, null, lineId, null, part, null, officePhoneNo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Save For Region(2)        
        public void SaveAFBLGeoInfo(string description, string officePhoneNo, int parentId, int levelId, int part, int activeEnroll)
        {
            DataTable dt = new DataTable();
            //int part = 1, activeEnroll = 0;
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
                dt = obj.GetLineList(description, parentId, activeEnroll, null, levelId, null, null, part, null, officePhoneNo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update For Region(2)
        public void UpdateAFBLGeoInfo(string description, string officePhoneNo, int lineId, int part)
        {
            DataTable dt = new DataTable();
            //int part = 9;
            sprAFBLProductDistrebutionManagerTableAdapter obj = new sprAFBLProductDistrebutionManagerTableAdapter();
            try
            {
                dt = obj.GetLineList(description, null, null, null, null, lineId, null, part, null, officePhoneNo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
