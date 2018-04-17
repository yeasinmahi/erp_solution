using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Purchase_DAL.Qc_Management.QcItemAttributeTableAdapters;



namespace Purchase_BLL.Qc_Management
{
    public class QcBllManagement
    {

        public List<string> AutoSearchItemData(int whid, string strSearchKey)
        {
            List<string> result = new List<string>();
            ItemAutosearchTableAdapter SpareItemList = new ItemAutosearchTableAdapter();
            DataTable oDT = new DataTable();
            oDT = SpareItemList.GetItemAutoSearch(whid, strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["ItemName"].ToString());
                }
            }
            return result;
        }

        public DataTable getITemReport(int Itemid)
        {
            qryItemListTableAdapter GetReport = new qryItemListTableAdapter();
            return GetReport.GetItemdetails(Itemid);
        }
        
        public DataTable getqctAttribute(string type, int intEnroll)
        {
            tblItemAttributesListTableAdapter GetAttribute = new tblItemAttributesListTableAdapter();
            return GetAttribute.GetAttributetypesData(type,intEnroll);
        }
        public DataTable getqctAttributespcifcation(string type)
        {
            tblItemAttributesListTableAdapter GetAttribute = new tblItemAttributesListTableAdapter();
            return GetAttribute.GetSpicisifacationAttributes(type);
        }

        public string insertAttributeadd(string xmlString, int unitid, int enroll)
        {

            AttributeAddTableAdapter Getattribuinsert = new AttributeAddTableAdapter();
            Getattribuinsert.GetAttributesAdd(xmlString,unitid,enroll);

            string msg = "Successfully";
            return msg;
        }

        public DataTable getAttributesDetailsReport(int Custid)
        {
           
                ItemdeailsAttributesTableAdapter GetItemAttributes = new ItemdeailsAttributesTableAdapter();
                return GetItemAttributes.GetItemIdDetails(Custid);
          

        }

        public DataTable getUnitname(int enroll)
        {

            ItemdeailsAttributesTableAdapter getUnitname = new ItemdeailsAttributesTableAdapter();
            return getUnitname.GetEmployeeUnitName(enroll);
        }

        public DataTable gridviewList(int Categoryid,int unitid)
        {
            AutoSearchItemGridTableAdapter GetGridItemlist = new AutoSearchItemGridTableAdapter();
            return GetGridItemlist.GetItemGrid(Categoryid,unitid);
        }

        public DataTable getWHname(int enroll)
        {

            WHNamelistTableAdapter getwhnamelist = new WHNamelistTableAdapter();
            return getwhnamelist.GetWHNameList(enroll);
           
        }

        public DataTable getPONO(int WHid, string WHName)
        {

            WHNamelistTableAdapter GetPONoLIst = new WHNamelistTableAdapter();
            return GetPONoLIst.GetPONolist(WHid,WHName);

        }

        public DataTable getshippointid(int pono)
        {
            tblImportShipmentTableAdapter getshipmentid = new tblImportShipmentTableAdapter();
            return getshipmentid.GetPoagainstbyShipmentid(pono);

            
        }

        public DataTable getReceiveableProduct(int ponumber, int shipmentnumber, bool ysnpotype)
        {
            sprInventoryMRRGetItemInfoTableAdapter GetPOItemReceivabaleQty = new sprInventoryMRRGetItemInfoTableAdapter();
            return GetPOItemReceivabaleQty.GetItemReceiveableReportQty(ponumber, shipmentnumber, ysnpotype);

        }

        public DataTable getItemAttributes(int itemid)
        {
            QcAttributeAddTableAdapter QCReportEntryAttribute = new QcAttributeAddTableAdapter();
            return QCReportEntryAttribute.GetItemQcAttributeData(itemid);
        }
        public void insertattributesresult(int attributeids, int productids, string Result, int enroll, int pono, string strPathfile, string Resultcurrect)
        {
            tblItemAttributeAddResultTableAdapter getinsertatribute = new tblItemAttributeAddResultTableAdapter();
            getinsertatribute.GetItemAttributesResultAddData(attributeids, productids, Result, enroll, pono, strPathfile, Resultcurrect);
        }
        public DataTable getattributesResults(int itemid, int pono)
        {
            AttributesResultTableAdapter getattributesresultss = new AttributesResultTableAdapter();
            return getattributesresultss.GetAttributesResult(itemid, pono);
        }   
        public DataTable getReportinlabeqpt(int intjobstation)
        {

            AssetLabTableAdapter getReportforLab = new AssetLabTableAdapter();
            return getReportforLab.GetAssetLabData(intjobstation);
        }





        public DataTable getProductionNo(int unitid)
        {
            tblProductionDetailTableAdapter getProductionid = new tblProductionDetailTableAdapter();
            return getProductionid.GetProductionNo(unitid);

        }

        public DataTable getProductionInfoByProduction(int productionid,int qcnum)
        {

            ProductionProductInfoTableAdapter getProductionReports = new ProductionProductInfoTableAdapter();
            return getProductionReports.GetProductionProductInfo(productionid, qcnum);

        }




    }
}
