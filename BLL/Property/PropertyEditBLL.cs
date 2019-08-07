using DAL.Property.PropertyEditTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Property
{
    public class PropertyEditBLL
    {
        public DataTable GetAGLandMasterData(int UnitID, int MouzaID, string DeedNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                AGLandTrxGeneralTableAdapter adapter = new AGLandTrxGeneralTableAdapter();
                dt = adapter.GetAGLandMasterData(UnitID, MouzaID, DeedNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public DataTable GetAGLandDetailsData(int intGeneralPK)
        {
            DataTable dt = new DataTable();
            try
            {
                AGLandTrxDetailsTableAdapter adapter = new AGLandTrxDetailsTableAdapter();
                dt = adapter.GetAGLandDetailsData(intGeneralPK);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public DataTable GetAGLandDocumentData(int intGeneralPK)
        {
            DataTable dt = new DataTable();
            try
            {
                AGLandTrxDocumentFileTableAdapter adapter = new AGLandTrxDocumentFileTableAdapter();
                dt = adapter.GetAGLandDocumentData(intGeneralPK);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public string UpdateAGLandGeneranData(int Type, string xmlDetail, string xmlDocFile,int LGFkID,int UnitID,int MouzaID, string DeedNo)
        {
            string Message = string.Empty;
            try
            {
                AGLandTrxGeneralDataUpdateTableAdapter adapter = new AGLandTrxGeneralDataUpdateTableAdapter();
                adapter.UpdateAGLandGeneralData(Type, xmlDetail, xmlDocFile, LGFkID, UnitID, MouzaID, DeedNo, ref Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Message;
        }
        public bool UpdateAGLandGeneralMasterData(int UnitID, int MouzaID,int SubOfficeID,int DeedTypeID,string DeedNo,DateTime DeedDate,
            string SellerName,decimal PurchaseLandArea,string Remark,decimal DeedValue,decimal Vat,decimal ExtendValue,decimal Broker,
            decimal RegistrationCost,decimal AIT,decimal MutationFee,decimal OtherCost,string RemarkOtherCost, string East, string West, 
            string North, string south,bool isComplete,int Enroll,int LandPK)
        {
            bool result = false;
            try
            {
                AGLandMasterTableAdapter adapter = new AGLandMasterTableAdapter();
                int iii = adapter.UpdateAGLandGeneralMasterData(UnitID, MouzaID, SubOfficeID, DeedTypeID, DeedNo, DeedDate, SellerName, 
                    PurchaseLandArea, Remark, DeedValue, Vat, ExtendValue, Broker, RegistrationCost, AIT, MutationFee, OtherCost, 
                    RemarkOtherCost, East, West, North, south, isComplete, Enroll,LandPK);
                if (iii > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
