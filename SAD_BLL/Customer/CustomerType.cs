using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer.CustomerTypeTDSTableAdapters;
using SAD_DAL.Customer;

namespace SAD_BLL.Customer
{
    public class CustomerType
    {        
        public CustomerTypeTDS.QrySalesOfficeCusTypeDataTable GetCustomerTypeBySO(string soId)
        {
            if (soId == null || soId == "") return new CustomerTypeTDS.QrySalesOfficeCusTypeDataTable();
            QrySalesOfficeCusTypeTableAdapter adp = new QrySalesOfficeCusTypeTableAdapter();
            return adp.GetDataBySO(int.Parse(soId));
        }

        public CustomerTypeTDS.QrySalesOfficeCusTypeDataTable GetCustomerTypeBySOForDOWithAll(string soId,string unitId)
        {
            QrySalesOfficeCusTypeTableAdapter adp = new QrySalesOfficeCusTypeTableAdapter();

            if (soId == null || soId == "" || soId == "0") return adp.GetDataForDOByUint(int.Parse(unitId));          
            return adp.GetDataForDO(int.Parse(soId));
        }

        public CustomerTypeTDS.QrySalesOfficeCusTypeDataTable GetCustomerTypeBySOForDO(string soId)
        {
            if (soId == null || soId == "") return new CustomerTypeTDS.QrySalesOfficeCusTypeDataTable();
            QrySalesOfficeCusTypeTableAdapter adp = new QrySalesOfficeCusTypeTableAdapter();
            return adp.GetDataForDO(int.Parse(soId));
        }

        public CustomerTypeTDS.QrySalesOfficeCusTypeDataTable GetCustomerTypeBySOForDO2(string soId)
        {
            if (soId == null || soId == "") return new CustomerTypeTDS.QrySalesOfficeCusTypeDataTable();
            QrySalesOfficeCusTypeTableAdapter adp = new QrySalesOfficeCusTypeTableAdapter();
            return adp.GetDataForDO2(int.Parse(soId));
        }
        /// <summary>
        /// Remove after complete
        /// </summary>
        /// <returns></returns>
        public CustomerTypeTDS.TblCustomerTypeDataTable GetCustomerType()
        {
            TblCustomerTypeTableAdapter adp = new TblCustomerTypeTableAdapter();
            return adp.GetCustomerTypeData();
        }

        public CustomerTypeTDS.TblCustomerTypeDataTable GetCustomerTypeDO()
        {
            TblCustomerTypeTableAdapter adp = new TblCustomerTypeTableAdapter();
            return adp.GetDataForDO();
        }

        public CustomerTypeTDS.TblCustomerTypeDataTable GetCustomerTypeDO2()
        {
            TblCustomerTypeTableAdapter adp = new TblCustomerTypeTableAdapter();
            return adp.GetDataForDO2();
        }

    }
}
