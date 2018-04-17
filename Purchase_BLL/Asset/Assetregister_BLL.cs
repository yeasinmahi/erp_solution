using Purchase_DAL.Asset.AssetRegisterTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Purchase_BLL.Asset
{
    public class Assetregister_BLL
    {

       public DataTable assetType()
        {
            DataTable2TableAdapter assettype = new DataTable2TableAdapter();
            return assettype.AssetTypeGetData();
        }







    
        public DataTable Assetdetalis(DateTime fromdate, DateTime todate, int intunitid, int assetitem, string HAssetType)
        {
            DataTable3TableAdapter detalis= new DataTable3TableAdapter();
     return detalis.AssetDetalisGetData(fromdate,todate,intunitid,assetitem,HAssetType);
        }

      

        public DataTable AssetTypeName()
        {
            DataTable2TableAdapter type = new DataTable2TableAdapter();
            return type.AssetTypeGetData();
           
        }

      

        public DataTable AssetViewdata(int assetid)
        {
            tblShowDataFixedAssetRegisterTableAdapter show = new tblShowDataFixedAssetRegisterTableAdapter();
            return show.AssetDataViewShowGetData(assetid);
        }

        public DataTable autoIdshow()
        {
            TblAutoFixedAssetRegisterTableAdapter auto = new TblAutoFixedAssetRegisterTableAdapter();
            return auto.MessageLastAutoiddataGetData();
        }

      
        public DataTable DepertmentName(int jobstation)
        {
            DataTable5TableAdapter name = new DataTable5TableAdapter();
            return name.DepartmentNameGetData(jobstation);
        }

        public DataTable DropdownCategoryView(int jobstation)
        {
            TblAssetCategoryTableAdapter category = new TblAssetCategoryTableAdapter();
            return category.AssetCategoryDropdownLoadGetData(jobstation);
        }

        public DataTable RegistrationDataInsert(int unit, int jobstation, int assettype, string assetname, string hscode, string description, string manufacture, string countryorigin, string countrymanufacture, string supplier, int category, string lcno, DateTime? dtelc, string pono, DateTime? dtepo, DateTime? WarrintyPreoid, decimal invoicevalue, string incortms, string location, string ManuProSL, string function, string capacity, DateTime? dteinstalation, decimal erectioncost, int department, DateTime? dteacusition, string life, decimal salvage, decimal landedC, decimal TAccumulatedC, decimal RateDepriciation, decimal AccumulatedDepriciation, string MethodDep, decimal ValueAfterDep, decimal writedownv, string remarks, int intjobid, int intenrollid, int intunitid, string currency, string maintType, int Plantname, int Costcenterid, string fmodel)
        {
            SprAssetRegisterTableAdapter register = new SprAssetRegisterTableAdapter();
            return register.SpAssetRegisterGetData(unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono,  dtepo, WarrintyPreoid, invoicevalue, incortms, location, ManuProSL, function, capacity,  dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, maintType, Plantname, Costcenterid, fmodel);
           
        }



        public DataTable assetDataView(string assetcode, int intjobid)
        {
            TblShowFixedAssetRegisterTableAdapter assetshow = new TblShowFixedAssetRegisterTableAdapter();
            return assetshow.AssetDataShowGetData(assetcode);

        }

        public DataTable ChecklSerialNumber(int jobstation, string ManuProSL)
        {
            TblCheckFixedAssetRegisterTableAdapter checkserial = new TblCheckFixedAssetRegisterTableAdapter();
            return checkserial.CheckManuSerialNoGetData(jobstation, ManuProSL);
        }

       
       

        public DataTable ChecklVechicleSerialNumber( string check)
        {
            TblCheckFixedAssetRegisterTableAdapter vcheck = new TblCheckFixedAssetRegisterTableAdapter();
            return vcheck.CheckVechileGetDataBy(check);
        }



        public DataTable LandRegistration(int intpart, int UnitLand, int Jobland, int AssetTypeLand, string AssetLand, string descriptionL, string landpo, string landbayername, string nameseller, string landclass, int district, int Thana, string mouja, string CSKatian, string SaKatian, string RSKathin, string DSKathian, string DpKatian, string CSDagNo, string SADagNo, string RSDagNo, string DSDagNo, string DPDagNo, string DeedReceoiptNo, string DeedNo, DateTime DeedDate, DateTime DeedCertifyreceivedate, DateTime OrginalDeedReceiveDate, decimal TotalArea, decimal TotalArealandinDecimal, decimal PricePerKatha, decimal PriceperDecimal, decimal TotalValuelandTk, decimal RegistryBainaAmount, decimal BalancelandValue, decimal RegistrationExpance, decimal DeedValueLand, decimal LandofficevolumeCheckingexp, decimal Nfees, decimal LocalgovtTax, decimal Stamp, decimal IncomeTax, decimal GainTax, decimal PayOrderExpense, decimal SubRegisterCommission, decimal DeedCertifiescopyExpance, decimal MutionExpanse, decimal OtherExpanse, decimal TotalArealandMuted, string Jlno, string HoldingNoJotNo, decimal LandDevlopmentTaxExpance, decimal BrokrCommission, Decimal TotalLandAccusitionCost, int   intenrollid,int intunitid,int intjobid)
        {
            SprAssetLandRegisterTableAdapter landregister = new SprAssetLandRegisterTableAdapter();
            return landregister.AssetLandRegisterGetData(intpart, UnitLand, Jobland, AssetTypeLand, AssetLand, descriptionL, landpo, landbayername, nameseller, landclass, district, Thana, mouja, CSKatian, SaKatian, RSKathin, DSKathian, DpKatian, CSDagNo, SADagNo, RSDagNo, DSDagNo, DPDagNo, DeedReceoiptNo, DeedNo, DeedDate, DeedCertifyreceivedate, OrginalDeedReceiveDate, TotalArea, TotalArealandinDecimal, PricePerKatha, PriceperDecimal, TotalValuelandTk, RegistryBainaAmount, BalancelandValue, RegistrationExpance, DeedValueLand, LandofficevolumeCheckingexp, Nfees, LocalgovtTax, Stamp, IncomeTax, GainTax, PayOrderExpense, SubRegisterCommission, DeedCertifiescopyExpance, MutionExpanse, OtherExpanse, TotalArealandMuted, Jlno, HoldingNoJotNo, LandDevlopmentTaxExpance, BrokrCommission, TotalLandAccusitionCost, intenrollid, intunitid, intjobid);
        }

        public DataTable Lunitname()
        {
            DataTable1TableAdapter lunitname = new DataTable1TableAdapter();
            return lunitname.LandUnitNameGetData();
        }

        public DataTable Ljobstation(int Unitland)
        {
            DataTable4TableAdapter LandJobstation = new DataTable4TableAdapter();
           return LandJobstation.LandJobStationNameGetDataBy(Unitland);
        }

        public DataTable Districviewdropdown()
        {
            DistricDataTableTableAdapter districts = new DistricDataTableTableAdapter();
            return districts.DistrictsNameGetData();
        }

        public DataTable Thanadrodownview(int  districtss)
        {
            DistricDataTableTableAdapter thana = new DistricDataTableTableAdapter();
            return thana.ThanaNameGetDataBy(districtss);
        }

        public DataTable LandType()
        {
            DataTable2TableAdapter landtypes = new DataTable2TableAdapter();
            return landtypes.AsetLandTypeGetDataBy();
        }

        public DataTable MotorVehicleTypes()
        {
            DataTable2TableAdapter vehicetypes = new DataTable2TableAdapter();
            return vehicetypes.MotorVehicleTypeGetData();
        }



        public DataTable BuildingRegistration(int intpart, int unit, int jobstation, int assettype, string assetname, string BDescription, string supplyby, int category, string BPoNO, DateTime PoDate, string Blocation, string Estimatedlife, string Bremarks, string Requestby, string RequestApproved, DateTime porjectstardtDate, DateTime deliverydate, string Length, string Breadth, string height, string totalarea, decimal estimaticost, decimal estmateconstriuction, decimal actualconstruction, string year, string Dept, string funndingsouece, string consultant, string contractorname, string renovationwork, string approximiatly, string renomateralis, int intenroll, int intjobid, string projectnumber, decimal totalAccumulatedCost)
        {
           SprAssetBuildingRegisterTableAdapter buildingreg = new SprAssetBuildingRegisterTableAdapter();
           return buildingreg.AssetBuildingRegisterGetdata(intpart, unit, jobstation, assettype, assetname, BDescription, supplyby, category, BPoNO, PoDate, Blocation, Estimatedlife, Bremarks, Requestby, RequestApproved, porjectstardtDate, deliverydate, Length, Breadth, height, totalarea, estimaticost, estmateconstriuction, actualconstruction, year, Dept, funndingsouece, consultant, contractorname, renovationwork, approximiatly, renomateralis, intenroll, intjobid, projectnumber, totalAccumulatedCost);
       
        }

        public DataTable BuildingCataegoryList(int buildcategorys)
        {
            TblAssetCategoryTableAdapter buildingcategoryss=new TblAssetCategoryTableAdapter();
            return buildingcategoryss.BuildingCategoryGetDataBy(buildcategorys);
        }

        public DataTable BuildingType()
        {
            DataTable2TableAdapter buildingType = new DataTable2TableAdapter();
            return buildingType.BuildingTypeGetDataBy();
        }

        public DataTable TabPermission(int intItem, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            SprAssetPermissionTableAdapter tabpermission = new SprAssetPermissionTableAdapter();
            return tabpermission.PermissionGetData(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);

        }

        public DataTable AssetVehicleView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            SprAssetPermissionTableAdapter VehicleView = new SprAssetPermissionTableAdapter();
            return VehicleView.PermissionGetData(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);

        }

        public DataTable AssetLandView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            SprAssetPermissionTableAdapter LandView = new SprAssetPermissionTableAdapter();
            return LandView.PermissionGetData(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);

        }

        public DataTable AssetDevlopment(int intItem, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            SprAssetPermissionTableAdapter devlopmentview = new SprAssetPermissionTableAdapter();
            return devlopmentview.PermissionGetData(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);

        }

        public void VehicleUpdate(int intpart, int unit, int jobstation, int assettype, string assetname, string hscode, string description, string manufacture, string countryorigin, string countrymanufacture, string supplier, int category, string lcno, DateTime dtelc, string pono, DateTime dtepo, DateTime WarrintyPreoid, decimal invoicevalue, string incortms, string location, string ManuProSL, string capacity, DateTime dteinstalation, decimal erectioncost, int department, DateTime dteacusition, string life, decimal salvage, decimal landedC, decimal TAccumulatedC, decimal RateDepriciation, decimal AccumulatedDepriciation, string MethodDep, decimal ValueAfterDep, decimal writedownv, string remarks, int intjobid, int intenrollid, int intunitid, string currency, string servicetype, string brand, string model, string cc, string color, string Engine, string chasis, string inetialMilege, string fuelstats, int txtUsername, string policyT, DateTime DteRegistration, DateTime DteTaxToken, DateTime dtefitness, DateTime dteInsurance, string insuranceName, string poliNmae, DateTime RootPermit, int exixtingV, string city, string indenty, string beginno, string unloadin, string loaden)
        {
            SprAssetVehicleRegisterTableAdapter vehicleRegupdate = new SprAssetVehicleRegisterTableAdapter();

            vehicleRegupdate.AssetVechileRegistrationGetData(intpart, unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, WarrintyPreoid, invoicevalue, incortms, location, ManuProSL, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, servicetype, brand, model, cc, color, Engine, chasis, inetialMilege, fuelstats, txtUsername, policyT, DteRegistration, DteTaxToken, dtefitness, dteInsurance, insuranceName, poliNmae, RootPermit, exixtingV, city, indenty, beginno, unloadin, loaden);


        }

        public void AssetLandUpdate(int intpart, int UnitLand, int Jobland, int AssetTypeLand, string AssetLand, string descriptionL, string landpo, string landbayername, string nameseller, string landclass, int district, int Thana, string mouja, string CSKatian, string SaKatian, string RSKathin, string DSKathian, string DpKatian, string CSDagNo, string SADagNo, string RSDagNo, string DSDagNo, string DPDagNo, string DeedReceoiptNo, string DeedNo, DateTime DeedDate, DateTime DeedCertifyreceivedate, DateTime OrginalDeedReceiveDate, decimal TotalArea, decimal TotalArealandinDecimal, decimal PricePerKatha, decimal PriceperDecimal, decimal TotalValuelandTk, decimal RegistryBainaAmount, decimal BalancelandValue, decimal RegistrationExpance, decimal DeedValueLand, decimal LandofficevolumeCheckingexp, decimal Nfees, decimal LocalgovtTax, decimal Stamp, decimal IncomeTax, decimal GainTax, decimal PayOrderExpense, decimal SubRegisterCommission, decimal DeedCertifiescopyExpance, decimal MutionExpanse, decimal OtherExpanse, decimal TotalArealandMuted, string Jlno, string HoldingNoJotNo, decimal LandDevlopmentTaxExpance, decimal BrokrCommission, decimal TotalLandAccusitionCost, int intenrollid, int intunitid, int intjobid)
        {
            SprAssetLandRegisterTableAdapter landupdate = new SprAssetLandRegisterTableAdapter();
            landupdate.AssetLandRegisterGetData(intpart, UnitLand, Jobland, AssetTypeLand, AssetLand, descriptionL, landpo, landbayername, nameseller, landclass, district, Thana, mouja, CSKatian, SaKatian, RSKathin, DSKathian, DpKatian, CSDagNo, SADagNo, RSDagNo, DSDagNo, DPDagNo, DeedReceoiptNo, DeedNo, DeedDate, DeedCertifyreceivedate, OrginalDeedReceiveDate, TotalArea, TotalArealandinDecimal, PricePerKatha, PriceperDecimal, TotalValuelandTk, RegistryBainaAmount, BalancelandValue, RegistrationExpance, DeedValueLand, LandofficevolumeCheckingexp, Nfees, LocalgovtTax, Stamp, IncomeTax, GainTax, PayOrderExpense, SubRegisterCommission, DeedCertifiescopyExpance, MutionExpanse, OtherExpanse, TotalArealandMuted, Jlno, HoldingNoJotNo, LandDevlopmentTaxExpance, BrokrCommission, TotalLandAccusitionCost, intenrollid, intunitid, intjobid);
        }

        public void BuildingUpdate(int intpart, int unit, int jobstation, int assettype, string assetname, string BDescription, string supplyby, int category, string BPoNO, DateTime PoDate, string Blocation, string Estimatedlife, string Bremarks, string Requestby, string RequestApproved, DateTime porjectstardtDate, DateTime deliverydate, string Length, string Breadth, string height, string totalarea, decimal estimaticost, decimal estmateconstriuction, decimal actualconstruction, string year, string Dept, string funndingsouece, string consultant, string contractorname, string renovationwork, string approximiatly, string renomateralis, int intenroll, int intjobid, string projectnumber, decimal totalAccumulatedCost)
        {
            SprAssetBuildingRegisterTableAdapter buildingupdate = new SprAssetBuildingRegisterTableAdapter();
            buildingupdate.AssetBuildingRegisterGetdata(intpart, unit, jobstation, assettype, assetname, BDescription, supplyby, category, BPoNO, PoDate, Blocation, Estimatedlife, Bremarks, Requestby, RequestApproved, porjectstardtDate, deliverydate, Length, Breadth, height, totalarea, estimaticost, estmateconstriuction, actualconstruction, year, Dept, funndingsouece, consultant, contractorname, renovationwork, approximiatly, renomateralis, intenroll, intjobid, projectnumber, totalAccumulatedCost);
        }





        public DataTable Unitname(int p, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            try
            {
                SprAssetPermissionTableAdapter loadUnit = new SprAssetPermissionTableAdapter();
                return loadUnit.PermissionGetData(p, Mnumber, intenroll, intjobid, intdept, assetcode);
            }
            catch { return new DataTable(); }
            
        }

        public DataTable JobstationName(int p, int Mnumber, int intenroll, int intjobid, int intdept, string assetcode)
        {
            try
            {
                SprAssetPermissionTableAdapter JobStation = new SprAssetPermissionTableAdapter();
                return JobStation.PermissionGetData(p, Mnumber, intenroll, intjobid, intdept, assetcode);
            }
            catch { return new DataTable(); }
        }

        public DataTable ExistingVehicleshow(int Unitid)
        {
            ExixtingvehicleTableAdapter existingV = new ExixtingvehicleTableAdapter();
            return existingV.ExixtingVehicleviewGetData(Unitid);
        }

        public DataTable VehicleRegisterArea()
        {
            TblVehicleAreaTableAdapter area = new TblVehicleAreaTableAdapter();
            return area.VehicleAreaTypeGetData();
        }

        public DataTable IndendityfiactionNumber()
        {
            TblVehicleAreaTableAdapter indentity = new TblVehicleAreaTableAdapter();
            return indentity.VehicleIndentityFicationNoGetDataBy();
        }



        public DataTable VehicleRegistrationDataInsert(int intpart, int unit, int jobstation, int assettype, string assetname, string hscode, string description, string manufacture, string countryorigin, string countrymanufacture, string supplier, int category, string lcno, DateTime dtelc, string pono, DateTime dtepo, DateTime WarrintyPreoid, decimal invoicevalue, string incortms, string location, string ManuProSL, string capacity, DateTime dteinstalation, decimal erectioncost, int department, DateTime dteacusition, string life, decimal salvage, decimal landedC, decimal TAccumulatedC, decimal RateDepriciation, decimal AccumulatedDepriciation, string MethodDep, decimal ValueAfterDep, decimal writedownv, string remarks, int intjobid, int intenrollid, int intunitid, string currency, string servicetype, string brand, string model, string cc, string color, string Engine, string chasis, string inetialMilege, string fuelstats, int txtUsername, string policyT, DateTime DteRegistration, DateTime DteTaxToken, DateTime dtefitness, DateTime dteInsurance, string insuranceName, string poliNmae, DateTime RootPermit, int exixtingV, string city, string indenty, string beginno, string unloadin, string loaden)
        {
            SprAssetVehicleRegisterTableAdapter vehicleReg = new SprAssetVehicleRegisterTableAdapter();
            try
            {
                return vehicleReg.AssetVechileRegistrationGetData(intpart, unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, Convert.ToDateTime(dtelc), pono, Convert.ToDateTime(dtepo), Convert.ToDateTime(WarrintyPreoid), invoicevalue, incortms, location, ManuProSL, capacity, dteinstalation, erectioncost, department, Convert.ToDateTime(dteacusition), life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, servicetype, brand, model, cc, color, Engine, chasis, inetialMilege, fuelstats, txtUsername, policyT, Convert.ToDateTime(DteRegistration), Convert.ToDateTime(DteTaxToken), Convert.ToDateTime(dtefitness), Convert.ToDateTime(dteInsurance), insuranceName, poliNmae, RootPermit, exixtingV, city, indenty, beginno, unloadin, loaden);
            }
            catch { return new DataTable(); };
        }

        public DataTable VehicleBrand()
        {
            TblVehicleAreaTableAdapter brand=new TblVehicleAreaTableAdapter();
            return brand.VehicleBrandNameGetDataBy();
        }

        public DataTable PlantName(int intjobid)
        {
            CostCenterDataTableAdapter FplantName = new CostCenterDataTableAdapter();
            return FplantName.PlantNameGetData(intjobid);
        }

        public DataTable RegCostCenter(int intUnitID)
        {
            CostCenterDataTableAdapter namecost = new CostCenterDataTableAdapter();
            return namecost.CostCenterGetData(intUnitID);
        }

        public void UpdateAssetRegistration(int Active, string assetname, int assettype, string hscode, string description, string manufacture, string countryorigin, string countrymanufacture, string supplier, int category, string lcno, DateTime dtelc, string pono, DateTime dtepo, decimal invoicevalue, string incortms, string location, string ManuProSL, string function, string capacity, DateTime dteinstalation, decimal erectioncost, int department, DateTime dteacusition, string life, decimal salvage, decimal landedC, decimal TAccumulatedC, decimal RateDepriciation, decimal AccumulatedDepriciation, string MethodDep, decimal ValueAfterDep, decimal writedownv, string remarks, DateTime WarrintyPreoid, int Costcenterid, int Plantname, string maintType,string fmodel,int intenrollid, int intjobid, string assetcode)
        {
           TblUpdateFixedAssetRegisterTableAdapter assetupdate=new TblUpdateFixedAssetRegisterTableAdapter();
           assetupdate.UpdateAssetGetData(Convert.ToBoolean(Active), assetname, assettype, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, invoicevalue, incortms, location, ManuProSL, function, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, WarrintyPreoid,Costcenterid, Plantname, maintType,fmodel,intenrollid, intjobid, assetcode);
            
        }

        public void VehicleRegisInformationUpdate(int unitid,int billjobnid, string driverName, string driverMobaile, string locations, string username, int userenroll, int intenroll, string asetcode)
        {
            TblVehicleNormalAssetRegisterTableAdapter normalVehicleprofile = new TblVehicleNormalAssetRegisterTableAdapter();
            normalVehicleprofile.UpdateNormalVehicleInfoGetData(unitid,billjobnid, driverName, driverMobaile, locations, username, userenroll, intenroll, asetcode);
        }



        public DataTable VehicleBillingUnitName()
        {
            DataTable1TableAdapter vehicleunitBill = new DataTable1TableAdapter();
            return vehicleunitBill.vehicleUnitName();
        }

        public DataTable VehicleBillingJobstation(int unitid)
        {
            TblJobstationNameTableAdapter billingjobstation = new TblJobstationNameTableAdapter();
            return billingjobstation.JobstationGetData(unitid);
           
        }
    }
}
