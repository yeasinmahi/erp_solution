﻿using System;
using System.Data;
using DAL.DropDown.CostCenterTDSTableAdapters;

namespace BLL.DropDown
{
    public class CostCenterBll
    {
        public DataTable GetCostCenter(int whId)
        {
            try
            {
                sprCostCenterTableAdapter adp = new sprCostCenterTableAdapter();
                return adp.GetData(whId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
            
        }
    }
}
