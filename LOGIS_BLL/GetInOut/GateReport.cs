using LOGIS_DAL.GetInOut.GateReportTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LOGIS_BLL.GetInOut
{
    public class GateReport
    {
        public System.Data.DataTable Unitname()
        {
            DataTable1TableAdapter unit = new DataTable1TableAdapter();
            return unit.UnitNameDataGetData();
        }



        public DataTable VehicleInOutReport(DateTime dteFrom, DateTime dteto, int ddljob)
        {
            DataTable2TableAdapter vehiclereport = new DataTable2TableAdapter();
            return vehiclereport.VehicelInOutReportGetData(Convert.ToString(dteFrom), Convert.ToString(dteto), ddljob);
        }


        public DataTable Unitname(int intjobid)
        {
            DataTable1TableAdapter jobstation = new DataTable1TableAdapter();
            return jobstation.EmployerwiseJobstationGetDataBy(intjobid);

        }





        public DataTable PonumberReport(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter pono = new SprGetInOutLoadDataGridViewTableAdapter();

            return pono.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }


        public DataTable GetpassOutDataReport(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter getpassouts = new SprGetInOutLoadDataGridViewTableAdapter();
            return getpassouts.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }

        public DataTable GetpassInDataReport(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter getpassins = new SprGetInOutLoadDataGridViewTableAdapter();
            return getpassins.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }

        public DataTable FinishedProductOut(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter finishedout = new SprGetInOutLoadDataGridViewTableAdapter();
            return finishedout.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }

        public DataTable LocalChallanReport(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter localchalln = new SprGetInOutLoadDataGridViewTableAdapter();
            return localchalln.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }

        public DataTable PonumberReportWithTxtNumber(int intpart,string item, int intjobid, DateTime dteFrom, DateTime dteto, string  number)
        {
            SprGetInOutLoadDataGridViewTableAdapter potxt = new SprGetInOutLoadDataGridViewTableAdapter();
            return potxt.GridviewLoaddataGetData(intpart,item, intjobid, dteFrom, dteto,number);
        }

        public DataTable GetpassOutDataReportWithtxtNumber(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter txtgetpass = new SprGetInOutLoadDataGridViewTableAdapter();
            return txtgetpass.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
        }

        public DataTable GetpassInDataReportwithTxtNumber(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter txtgetpassin = new SprGetInOutLoadDataGridViewTableAdapter();
            return txtgetpassin.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
        }

        public DataTable LocalChallanReportwithTxtNumber(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter finishedp = new SprGetInOutLoadDataGridViewTableAdapter();
            return finishedp.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
        }

        public DataTable FinishedProductOutwithTxtNumber(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter locchallans = new SprGetInOutLoadDataGridViewTableAdapter();
            return locchallans.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
        }

        public DataTable vehiclereport(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter vehiclereport = new SprGetInOutLoadDataGridViewTableAdapter();
            return vehiclereport.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
 
        }

        public DataTable vehiclereportwithtruckno(int intpart, string item, int intjobid, DateTime dteFrom, DateTime dteto, string number)
        {
            SprGetInOutLoadDataGridViewTableAdapter vehiclereportwithdata = new SprGetInOutLoadDataGridViewTableAdapter();
            return vehiclereportwithdata.GridviewLoaddataGetData(intpart, item, intjobid, dteFrom, dteto, number);
 
        }
    }
}
