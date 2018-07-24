﻿using System;
using System.Data;
using SAD_DAL.IHB.DistributorWithIhbTableAdapters;

namespace SAD_BLL.IHB
{
    public class DistributorWithIhbBll
    {
        public DataTable GetRegion()
        {
            tblItemPriceManagerTableAdapter adapter = new tblItemPriceManagerTableAdapter();
            return adapter.GetRegion();
        }
        public DataTable GetArea(int regionId)
        {
            tblItemPriceManager1TableAdapter adapter = new tblItemPriceManager1TableAdapter();
            return adapter.GetArea(regionId);
        }
        public DataTable GetTerritory(int areaId)
        {
            tblItemPriceManager2TableAdapter adapter = new tblItemPriceManager2TableAdapter();
            return adapter.GetTerritory(areaId);
        }
        public DataTable GetDistributor(int territoryId)
        {
            tblCustomerTableAdapter adapter = new tblCustomerTableAdapter();
            return adapter.GetDistributor(territoryId);
        }
        public DataTable GetAcrd(int territoryId)
        {
            tblCustomer1TableAdapter adapter = new tblCustomer1TableAdapter();
            return adapter.GetAcrd(territoryId);
        }
        
        public string InsertEnterpriseCustomerNihbCustmBridge(string xml,DateTime fromDate,DateTime toDate, int enrol,int unitId, int insertby)
        {
            string message = String.Empty;
            sprEnterprisecustomerNIHBCustmBridgeTableAdapter adapter = new sprEnterprisecustomerNIHBCustmBridgeTableAdapter();
            adapter.InsertEnterpriseCustomerNihbCustmBridge(xml, fromDate, toDate, enrol, unitId, insertby,
                ref message);
            return message;
        }
        public DataTable GetCustomerInfo(int customerId)
        {
            DataTable1TableAdapter adapter = new DataTable1TableAdapter();
            return adapter.GetCustomerInfo(customerId);
        }
    }
}
