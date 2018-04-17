using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support_DAL.SupportTDSTableAdapters;
using Support_DAL;
using System.Data;

namespace Support_BLL
{
   public class SupportBLL
   {
        //private static Global_DAL.TblAG_SupplierDataTable[] tableCusts = null;
        int e;
        private static Support_DAL.SupportTDS.TblEmployeeListDataTable[] tableEmplist = null;
        public string[] AutoSearchEmpListForCertificate(string intUnitID, string prefix)
        {
            //intUnitID = "1";
            int unit = Int32.Parse(intUnitID.ToString());
            //Inatialize(intwh);

            tableEmplist = new SupportTDS.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeDataTable[e];
            TblEmployeeListTableAdapter adpCOA = new TblEmployeeListTableAdapter();
            tableEmplist[e] = adpCOA.GetEmpList(unit);
            //tableEmplist[e] = adpCOA.GetEmpList(Convert.ToInt32(intUnitID)); 
            //tableEmplist[e] = adpCOA.GetEmpListByUnit();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmplist[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableEmplist[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strEmployeeCode.ToLower().Contains(prefix) || tmp.strOfficeEmail.ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }

        public DataTable GetEmpInfoByEnroll(int intEnroll)
        {
            QRYEMPLOYEEPROFILEALLTableAdapter adp = new QRYEMPLOYEEPROFILEALLTableAdapter();
            try
            { return adp.GetEmpInfoByEnroll(intEnroll); }
            catch { return new DataTable(); }
        }

        public string InsertUpdateCertificateInfo(int intEnroll, int intCertificateType, string strCerfificate, string strCertificateSerialNo, string strRegNo, string strRollNo, DateTime dteReceivedDate, DateTime dteDeliveryDate, int intInsertBy)
        {
            string msg = "";
            try
            {
                SprCertificateInfoTableAdapter adp = new SprCertificateInfoTableAdapter();
                adp.InsertUpdateCertificateInfo(intEnroll, intCertificateType, strCerfificate, strCertificateSerialNo, strRegNo, strRollNo, dteReceivedDate, dteDeliveryDate, intInsertBy, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetEmpInfo(int intEnroll)
        {
            QRYEMPLOYEEPROFILEALL1TableAdapter adp = new QRYEMPLOYEEPROFILEALL1TableAdapter();
            try
            { return adp.GetEmpInfo(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetReceiveInfo(int intEnroll)
        {
            TblCertificateReceiveAndDeliveryTableAdapter adp = new TblCertificateReceiveAndDeliveryTableAdapter();
            try
            { return adp.GetReceiveInfo(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetReceiveReport()
        {
            GetReceiveReportTableAdapter adp = new GetReceiveReportTableAdapter();
            try
            { return adp.GetReceiveReport(); }
            catch { return new DataTable(); }
        }
        public DataTable GetRecReportAll(int intPart, DateTime fdate, DateTime tdate)
        {
            SprCertificateReceiveAndDeliveryReportTableAdapter adp = new SprCertificateReceiveAndDeliveryReportTableAdapter();
            try
            { return adp.GetRecReportAll(intPart, fdate, tdate); }
            catch { return new DataTable(); }
        }

        
















    }
    
    
}
