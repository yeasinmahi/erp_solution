using DAL.Property.PropertyTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Property
{
    public class PropertyBLL
    {
        public DataTable GetAllUnit()
        {
            DataTable dt = new DataTable();
            try
            {
                UnitTableAdapter adapter = new UnitTableAdapter();
                dt = adapter.GetAllUnitData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllMouza()
        {
            DataTable dt = new DataTable();
            try
            {
                MouzaTableAdapter adapter = new MouzaTableAdapter();
                dt = adapter.GetAllMouzaData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllSubOffice(int MouzaID)
        {
            DataTable dt = new DataTable();
            try
            {
                SubOfficeTableAdapter adapter = new SubOfficeTableAdapter();
                dt = adapter.GetAllSubOfficeData(MouzaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetAllDeedType()
        {
            DataTable dt = new DataTable();
            try
            {
                DeedTypeTableAdapter adapter = new DeedTypeTableAdapter();
                dt = adapter.GetAllDeedTypeData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

        public DataTable GetAllPlotType()
        {
            DataTable dt = new DataTable();
            try
            {
                PlotTypeTableAdapter adapter = new PlotTypeTableAdapter();
                dt = adapter.GetPlotTypeData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

        public DataTable GetAllLDTR()
        {
            DataTable dt = new DataTable();
            try
            {
                LDTRTableAdapter adapter = new LDTRTableAdapter();
                dt = adapter.GetAllLDTRData();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public int CheckPlotArea(int PlotType, string PlotNo)
        {
            int count = 0;
            try
            {
                PlotAreaTableAdapter adapter = new PlotAreaTableAdapter();
                object _obj = adapter.CheckExistingPlotData(PlotNo, PlotType);
                if (_obj != null)
                    count = Convert.ToInt32(_obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return count;
        }
        public decimal GetPlotAreaData(int MouzaId, int PlotType, string PlotNo)
        {
            DataTable dt = new DataTable();
            decimal PlotAreaQty = 0;
            try
            {
                PlotAreaTableAdapter adapter = new PlotAreaTableAdapter();
                dt = adapter.GetPlotAreaData(MouzaId, PlotNo, PlotType);
                if(dt != null && dt.Rows.Count > 0)
                {
                    PlotAreaQty = !string.IsNullOrEmpty(dt.Rows[0]["numPlotArea"].ToString()) ? 
                        Convert.ToDecimal(dt.Rows[0]["numPlotArea"]) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return PlotAreaQty;
        }
        public decimal GetPurchasePlotArea(int PlotType, string PlotNo)
        {
            decimal PurchasePlotAreaQty = 0;
            try
            {
                PlotAreaTableAdapter adapter = new PlotAreaTableAdapter();
                object _obj = adapter.GetPurchasePlotArea(PlotNo, PlotType);
                if (_obj != null)
                    PurchasePlotAreaQty = Convert.ToInt32(_obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return PurchasePlotAreaQty;
        }
        public string InsertAGLandTrxGeneral(string Mainxml, string Docxml, int UnitID, int MouzaID,int subOfficeID, int DeedTypeID, string DeedNo,
            DateTime DeedDate,string sellerName,decimal purchaseArea, string Remark,decimal DeedValue, decimal Vat, decimal ExtendedValue,
            decimal BrokerValue,decimal RegistrationCost,decimal ait,decimal MutationCost,decimal OtherCost, string OtherCostRemark,
            string East,string west,string North,string south)
        {
            string Message = string.Empty;
            try
            {
                AGLandTrxGeneralTableAdapter adapter = new AGLandTrxGeneralTableAdapter();
                adapter.InsertAGLandTrxGeneralData(Mainxml, Docxml, UnitID, MouzaID, subOfficeID, DeedTypeID, DeedNo, DeedDate, sellerName,
                    purchaseArea, Remark, DeedValue, Vat, ExtendedValue, BrokerValue, RegistrationCost, ait, MutationCost, OtherCost,
                    OtherCostRemark, East, west, North, south,ref Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Message;
        }

        public DataTable GetAllGeoDistrict()
        {
            DataTable dt = new DataTable();
            try
            {
                AGBangladeshGeoTableAdapter adapter = new AGBangladeshGeoTableAdapter();
                dt = adapter.GetGeoDistrictData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

        public string CreateNewMouza(string xmlData)
        {
            string Meaasge = string.Empty;
            try
            {
                MouzaSetupTableAdapter adapter = new MouzaSetupTableAdapter();
                adapter.CreateEditMouzaSetup(1, xmlData,null, ref Meaasge);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Meaasge;
        }
        public int EditExistingMouza(int MouzaID, string Mouza, string Details, string District, int ysnActive)
        {
            string Meaasge = string.Empty;
            int iii = 0;
            try
            {
                bool active = false;
                AGLandMouzaTableAdapter adapter = new AGLandMouzaTableAdapter();
                if (ysnActive == 1)
                    active = true;
                iii = adapter.UpdateExistingMouzaData(Mouza, Details, District, active, MouzaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return iii;
        }
        public DataTable GetAllExistingMouza()
        {
            DataTable dt = new DataTable();
            try
            {
                AGLandMouzaTableAdapter adapter = new AGLandMouzaTableAdapter();
                dt = adapter.GetExistingMouzaData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetSingleExistingMouza(int MouzaID)
        {
            DataTable dt = new DataTable();
            try
            {
                AGLandMouzaTableAdapter adapter = new AGLandMouzaTableAdapter();
                dt = adapter.GetExistingMouzaByID(MouzaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetMouzaForPlot()
        {
            DataTable dt = new DataTable();
            try
            {
                tblAGLandMouzaTableAdapter adapter = new tblAGLandMouzaTableAdapter();
                dt = adapter.GetMouzaForPlotData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetPlotType()
        {
            DataTable dt = new DataTable();
            try
            {
                tblAGLandPlotTypeTableAdapter adapter = new tblAGLandPlotTypeTableAdapter();
                dt = adapter.GetPlotTypeData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetPlotByMouzaData()
        {
            DataTable dt = new DataTable();
            try
            {
                PlotByMouzaTableAdapter adapter = new PlotByMouzaTableAdapter();
                dt = adapter.GetExistingPlotByMozaData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetSinglePlotByMouzaData(int PlotID)
        {
            DataTable dt = new DataTable();
            try
            {
                PlotByMouzaTableAdapter adapter = new PlotByMouzaTableAdapter();
                dt = adapter.GetSinglePlotByMouzaData(PlotID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public string InsertPlotByMouza(string xmlData)
        {
            string Meaasge = string.Empty;
            try
            {
                AGLandPlotSetupTableAdapter adapter = new AGLandPlotSetupTableAdapter();
                adapter.InsertPlotByMouza(1, xmlData, ref Meaasge);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Meaasge;
        }
        public int EditExistingPlotByMouza(int MouzaID, int PlotTypeID, string PlotNo, decimal PlotArea, int ysnActive, int PlotID)
        {
            string Meaasge = string.Empty;
            int iii = 0;
            try
            {
                bool active = false;
                AGLandPlotSetupTableAdapter adapter = new AGLandPlotSetupTableAdapter();
                if (ysnActive == 1)
                    active = true;
                iii = adapter.UpdatePlotByMouza(MouzaID, PlotTypeID, PlotNo, PlotArea, active, PlotID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return iii;
        }
        public DataTable GetPlotAreaByMouza(int MouzaID)
        {
            DataTable dt = new DataTable();
            try
            {
                PlotDetailsByMouzaTableAdapter adapter = new PlotDetailsByMouzaTableAdapter();
                dt = adapter.GetPlotDetailsByMouza(MouzaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
    }
}
