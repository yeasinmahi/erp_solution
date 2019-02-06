using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Purchase_DAL.Asset.AssetCheckInOutTDSTableAdapters;

namespace Purchase_BLL.Asset
{
    public class AssetInOut
    {
        public DataTable ShowassetData(string number)
        {
            AssetDataShowDataTableTableAdapter assetshow = new AssetDataShowDataTableTableAdapter();
            return assetshow.AssetDataShowGetData(Convert.ToInt32(number));
        }

        

      

        public DataTable DgvReprotAllCheckinout()
        {
            ReportCheckInOutDataTableTableAdapter checkreport = new ReportCheckInOutDataTableTableAdapter();
            return checkreport.DataShowFriedViewGetData();
        }

        public string AssetCheckInOutAction(int Part, string stringXml, int intType, int intResEnroll,string assetCode, int intWHiD, string strNaration, int intActionBy)
        {
            try
            {
                string msg = "";
                SprAssetCheckInOutTableAdapter adp = new SprAssetCheckInOutTableAdapter();
                adp.GetAssetCheckInOutData(Part, stringXml, intType, intResEnroll, assetCode,intWHiD, strNaration, intActionBy, ref msg);
                return msg;
            }
            
           
            catch { return ""; }
        }

        public DataTable AssetCheckInOutDataTable(int Part, string stringXml, int intType, int intResEnroll,string assetCode, int intWHiD, string strNaration, int intActionBy)
        {

            try
            {
                string msg = " ";
                SprAssetCheckInOutTableAdapter adp = new SprAssetCheckInOutTableAdapter();
                return adp.GetAssetCheckInOutData(Part, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy, ref msg);
            }
            catch { return new DataTable(); }
           
        }

        public DataTable UnitByUser(int intActionBy)
        {

            try
            {
                string msg = " ";
                UnitByUserTableAdapter adp = new UnitByUserTableAdapter();
                return adp.GetUnitByUserData(intActionBy);
            }
            catch { return new DataTable(); }
            
        }
        public DataTable AssetTransectionType()
        { 
            try
            {
                string msg = " ";
                UnitByUserTableAdapter adp = new UnitByUserTableAdapter();
                return adp.GetAssetTransectionType();
            }
            catch { return new DataTable(); }
            
        }

        public string OperatorSetup(object intPart, object )
        {
            throw new NotImplementedException();
        }
    }
}
