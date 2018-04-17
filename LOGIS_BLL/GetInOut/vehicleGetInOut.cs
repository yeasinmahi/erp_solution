using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using LOGIS_DAL.GetInOut.VehicleGetInOutTableAdapters;

namespace LOGIS_BLL.GetInOut
{
    public class vehicleGetInOut
    {
        public DataTable getinformation(int UnitId,int intjobid)
        {
            DataTable3TableAdapter Ininformation = new DataTable3TableAdapter();
            return Ininformation.VehicleInInformationGetData(UnitId, intjobid);
        }
        public void Vehicleoutinformation(string vehicle, int intjobid)
        {
            TblGetInOutVehicleInformationTableAdapter vechileoutactive = new TblGetInOutVehicleInformationTableAdapter();
            vechileoutactive.vechileOutGetData(vehicle,intjobid);
        }
        public string GetInOutxmlinsert(string xmlString, int intenroll, int intunitid,int intjobid)
        {

            SprVehicleGetInOutTableAdapter insertgetin = new SprVehicleGetInOutTableAdapter();
            insertgetin.VehiclegetinoutGetData(xmlString, intenroll, intunitid, intjobid);
            string msg = "Successfully";
            return msg;
        }
        public void updateWeight(string scaleid, decimal grossweight, decimal netweight, string vehiclno)
        {
           DataTable2TableAdapter scaleidupdate = new DataTable2TableAdapter();
            scaleidupdate.ScaleIDUpdateGetData(scaleid, grossweight,netweight,vehiclno);
        }
        public DataTable UnitOgMesurement(int intunitid)
        {
          DataTable1TableAdapter uom = new DataTable1TableAdapter();

          return uom.UOMGetData(intunitid);
        }


        public DataTable showPONumber(int PO)
        {
            DataTable4TableAdapter et = new DataTable4TableAdapter();
            return et.ShowPONumberGetData(PO);
        }

        //public string XmlinsertPOnumber(string xmlStringPo, string ponumber, string challn, string vehicleno, int intenroll, int intunitid)
        //{
        //    SprPOGetInTableAdapter poinsert = new SprPOGetInTableAdapter();
        //    poinsert.XmlPoInsertGetData(xmlStringPo, ponumber, challn,vehicleno,intenroll, intunitid);
        //    string message = "Successfully";
        //    return message;
        //}

      
        

        public DataTable vehiclenumberTxtInformation(string vehiclenumber)
        {
            TblVehicleTableAdapter vehicledriverinfo = new TblVehicleTableAdapter();
            return vehicledriverinfo.VehiclenumberTxtinformationGetData(vehiclenumber);
        }

        public void GetItemVSLogisticCharge(string itemid , string unitid , ref string SupplierVheiclecharge  ,ref string CustomerVheiclecharge , ref string CompanyVheiclecharge)
        {
            decimal? supplvh = null;
            decimal? custvh = null;
            decimal? cmompvh = null;
            SprItemVSLogisticChargeTableAdapter bll = new SprItemVSLogisticChargeTableAdapter();
            bll.GetDataitemvslogisticcharge(int.Parse(itemid), int.Parse(unitid), ref supplvh, ref custvh, ref cmompvh);
            SupplierVheiclecharge = supplvh.ToString();
            CustomerVheiclecharge = custvh.ToString();
            CompanyVheiclecharge = cmompvh.ToString();
        }

    }
}
    
