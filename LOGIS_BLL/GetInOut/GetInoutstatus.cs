using LOGIS_DAL.GetInOut.GetinOutstatusTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LOGIS_BLL.GetInOut
{
    public class GetInoutstatus
    {
         public DataTable GetpassOutLoad(int intuntid,int intjobid)
        {
             DataTable1TableAdapter dt = new DataTable1TableAdapter();

            return dt.GetpassdOutloadGetData(intuntid,intjobid);
 
        }



        public DataTable gridviewgetpasoutdropdownvechilelist(int intjobid)
        {
            TblGetOutVehicleInformationTableAdapter st = new TblGetOutVehicleInformationTableAdapter();

            return st.GridViewDrodownVehicleListGetData(intjobid);
        }



       
      

        public DataTable getingetpasdatainfo(int intjobid)
        {
            TblGetInGetPassTableAdapter getin = new TblGetInGetPassTableAdapter();
            return getin.GetInGetpassInLoadGetData(intjobid);
        }




        public void getpassINinsertinfo(int Item,int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int  fowardenroll)
        {
            SprGetInOutSystemTableAdapter st = new SprGetInOutSystemTableAdapter();
            try
            {
                st.SpGetInGetPassInsertGetData(Item,intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
            }
            catch (Exception ex) { throw ex; }
            
            }

        public DataTable FinishedProductLoad(int intjobid)
        {
           DataTable3TableAdapter FP = new DataTable3TableAdapter();
           return FP.FinishedProductVehicleLoadGetData(intjobid);
        }

       

      


        



       
        public string Insertorderform(string xmlString,int intenroll,int intunitid,int intjobid)
        {
            SprGetOutFinishedXMLTableAdapter insertgetin = new SprGetOutFinishedXMLTableAdapter();
            insertgetin.xmlGetData(xmlString,intenroll,intunitid,intjobid);
            string message = "Successfully";
            return message;
        }

        public string GetpassOutInsert(string xmlStringGetpassOut, string vehicleno, int intenroll, int intunitid, int intjobid, int vehicleID)
        {
            SprGetOutGetpassXMLTableAdapter getpassout = new SprGetOutGetpassXMLTableAdapter();
            getpassout.GetpassOutInsertDataGetData(xmlStringGetpassOut, vehicleno, intenroll, intunitid, intjobid, vehicleID);
            string message = "Successfully";
            return message;
        }

        public DataTable CorporateGetpassOutLoad()
        {
            DataTable2TableAdapter corporate = new DataTable2TableAdapter();
            return corporate.CorporateGEtpassOutLoadGetData();
        }

        public DataTable CorporeteGetPassInLoad()
        {
            CorporateGetpassINDataTableTableAdapter corporeteget = new CorporateGetpassINDataTableTableAdapter();
            return corporeteget.CorporateGetPassINGetData();
        }

        public DataTable GetpassreceiveConfirmation(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter getpassreceive = new SprGetInOutSystemTableAdapter();
            return getpassreceive.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
           
        }

        public void GetpassreceiveConfirmationConfirmation(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter receive = new SprGetInOutSystemTableAdapter();
           receive.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
          
        }

        public DataTable GetpassreceiveConfirmationUser(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter receive = new SprGetInOutSystemTableAdapter();
            return receive.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
          
        }

        public DataTable GetpassreceiveStatus(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter status = new SprGetInOutSystemTableAdapter();
            return status.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
          
        }

        public DataTable GetMailaddress(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter getmail = new SprGetInOutSystemTableAdapter();
            return getmail.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
         
        }

       

        public DataTable UserendgetpassDetalis(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter detalis = new SprGetInOutSystemTableAdapter();
            return detalis.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
         
        }

        public void SendMail(int Item, int intRID, string code, string vehicleno, int intenroll, int intuntid, int intjobid, string driver, int fowardenroll)
        {
            SprGetInOutSystemTableAdapter sendmails = new SprGetInOutSystemTableAdapter();
           sendmails.SpGetInGetPassInsertGetData(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
     
        }
    }
    }


