using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.LetterTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Letter
    {

        public LetterTDS.FunCommercialLetterOpenningDataTable GetLetterOpenningInfo(int lcID)
        {
            FunCommercialLetterOpenningTableAdapter adp=new FunCommercialLetterOpenningTableAdapter();
            try
            {
                return adp.GetOpenningLetterData(lcID);
            }
            catch
            {
                return null;
            }
        }


        public LetterTDS.FumCommercialLetterDuyPortShippingDataTable GetLetterTTPOInfo(int lcID,int shipmentID,bool ysnDuty,bool ysnPort,bool ysnShipping)
        {
            FumCommercialLetterDuyPortShippingTableAdapter adp = new FumCommercialLetterDuyPortShippingTableAdapter();
            try
            {
                return adp.GeDPSLetterData(lcID,shipmentID,ysnDuty,ysnPort,ysnShipping);
            }
            catch
            {
                return null;
            }
        }

        public LetterTDS.FunCommercialLetterFCDataTable GetLetterFCInfo(int lcID, int shipmentID)
        {
            FunCommercialLetterFCTableAdapter adp = new FunCommercialLetterFCTableAdapter();
            try
            {
                return adp.GetFCLetterData(lcID, shipmentID);
            }
            catch
            {
                return null;
            }
        }

        public LetterTDS.FunCommercialLetterCoptDocumentDataTable GetLetterCDInfo(int lcID, int shipmentID)
        {
            FunCommercialLetterCoptDocumentTableAdapter adp = new FunCommercialLetterCoptDocumentTableAdapter();
            try
            {
                return adp.GetCDLetterData(lcID, shipmentID);
            }
            catch
            {
                return null;
            }
        }


        public LetterTDS.FunCommercialLetterCNFDataTable GetLetterCNFInfo(int lcID,int shipmentID,int cnfAgentID)
        {
            FunCommercialLetterCNFTableAdapter adp = new FunCommercialLetterCNFTableAdapter();
            try
            {
                return adp.GetCNFLetterData(lcID, shipmentID, cnfAgentID);
            }
            catch
            {
                return null;
            }
        }

        public LetterTDS.TblCommercialLetterDataTable GetLetterType()
        {
            TblCommercialLetterTableAdapter adp = new TblCommercialLetterTableAdapter();
            return adp.GetLetterTypeData();
        }
    }
}
