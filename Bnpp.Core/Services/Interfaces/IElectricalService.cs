using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.Electrical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IElectricalService
    {
        #region Cables

        List<CableListViewModel> GetAllCables();
        int AddCables(Cable cable);
        Cable GetCableById(int cableId);
        void UpdateCables(Cable cable);
        void DeleteCable(int cableId);

        #endregion

        #region General Cables

        List<GeneralCables> GetAllGeneralCables();
        List<GeneralCablesViewModel> GetAllGeneralCablesForExcel();
        int AddGeneralCables(GeneralCables cables, IFormFile imgResistanceDBA, IFormFile imgResistanceBDBA, IFormFile imgResultFactory, IFormFile imgInstallation);

        void DeleteGeneralCables(int cableId);
        GeneralCables GetCablesGeneralById(int cableId);
        GeneralCablesViewModel GetCablesGeneralByIdForExcel(int cableId);
        void UpdateGeneralCables(GeneralCables cables, IFormFile imgResistanceDBA, IFormFile imgResistanceBDBA, IFormFile imgResultFactory, IFormFile imgInstallation);
        List<CableIdentity> GetAllIdCables();


        List<SelectListItem> GetGroupForManageCableGroup();
        List<SelectListItem> GetSubGroupForManageCablId(int groupId);

        GeneralCables GetCablesGeneralByCableIdGroup(string cableIdGroup);

        #endregion

        #region Operating Cables

        int AddOperatingData(OperatingCableData operatingCable);
        List<OperatingCableData> GetAllOperatingCables();
        List<OperatingDataViewModel> GetAllOperatingCablesForExcel();
        void DeleteOperatingCables(int operatingId);
        OperatingCableData GetOperatingCableById(int cableId);
        OperatingDataViewModel GetOperatingCableByIdForExcel(int cableId);
        void UpdateOperatingData(OperatingCableData operating);
        #endregion

        #region Maintenance Cables
        List<MaintenanceCable> GetAllMaintenanceCable();
        List<MaintenanceCableViewModel> GetAllMaintenanceCableForExcel();
        int AddMaintenanceCable(MaintenanceCable maintenanceCable, IFormFile imgmaintenanceCable);
        MaintenanceCable GetMaintenanceCableById(int maintenanceId);
        MaintenanceCableViewModel GetMaintenanceCableByIdForExcel(int maintenanceId);
        void UpdateMaintenanceCable(MaintenanceCable maintenanceCable, IFormFile imgmaintenanceCable);
        void DeleteMaintenanceCables(int maintenanceId);
        #endregion

        #region Report Cables

        List<CableReport> GetAllCableReports();
        List<CableReportViewModel> GetAllCableReportsForExcel();
        int AddReportCable(CableReport report);

        void DeleteCablereport(int reportId);
        CableReport GetCableReportById(int reportId);
        CableReportViewModel GetCableReportByIdForExcel(int reportId);
        void UpdateReportCable(CableReport report);
        #endregion

        #region Electromotors

        List<ElectromotorsListViewModel> GetAllElectromotos();
        List<ElectromotorsExportViewModel> GetAllElectromotosForExport();
        int AddElectromotor(Electromotors electromotor);
        Electromotors GetElectromotorById(int electromotorId);
        ElectromotorsExportViewModel GetElectromotorByIdExport(int electromotorId);
        void UpdateElectromotor(Electromotors electromotor);
        void DeleteElectromotor(int electromotorId);

        #endregion

        #region Generator

        List<GeneratorListViewModel> GetAllGenerators();
        List<GeneratorExportViewModel> GetAllGeneratorsForExport();
        int AddGenerator(Generator generator);
        Generator GetGeneratorById(int generatorId);
        GeneratorExportViewModel GetGeneratorByIdForExport(int generatorId);
        void UpdateGenerator(Generator generator);
        void DeleteGenerator(int generatorId);

        #endregion

        #region Transformer

        List<TransformerListViewModel> GetAllTransformers();
        List<TransformerExportViewModel> GetAllTransformersForExport();
        int AddTransformer(Transformer transformer);
        Transformer GetTransformerById(int transformerId);
        TransformerExportViewModel GetTransformerByIdForExport(int transformerId);
        void UpdateTransformer(Transformer transformer);
        void DeleteTransformer(int transformerId);

        #endregion

        #region Valves

        List<ValvesListViewModel> GetAllValves();
        List<ValvesExportViewModel> GetAllValvesForExport();
        int AddValve(ElectroValve valve);
        ElectroValve GetValveById(int valveId);
        ValvesExportViewModel GetValveByIdForExport(int valveId);
        void UpdateValve(ElectroValve valve);
        void DeleteValve(int valveId);

        #endregion

        #region Diesel

        List<DieselListViewModel> GetAllDiesels();
        List<DieselExportViewModel> GetAllDieselsForExport();
        int AddDiesel(Dieselgenerator diesel);
        Dieselgenerator GetDieselById(int dieselId);
        DieselExportViewModel GetDieselByIdForExport(int dieselId);
        void UpdateDiesel(Dieselgenerator diesel);
        void DeleteDiesel(int dieselId);

        #endregion

        #region OWner

        List<Owner> GetAllOwners();
        int AddOwner(Owner owner);
        Owner GetOwnerById(int ownerId);
        void UpdateOwner(Owner owner);
        void DeleteOwner(int ownerId);
        List<SelectListItem> GetOwners();
        #endregion

        #region type of cable

        List<TypeofCable> GetAllTypeofCable();
        List<SelectListItem> GettypeofCables();
        int AddTypeofCable(TypeofCable typeofCable);
        TypeofCable GetTypeofCableById(int typeId);
        void UpdateTypeofCable(TypeofCable type);
        void DeleteCableType(int typeId);
        #endregion

        #region Classification of cable on the basis of Voltage

        List<ClassificationVoltage> GetAllClassification();

        List<SelectListItem> GetClassificationVoltage();
        int AddVoltage(ClassificationVoltage classification);
        ClassificationVoltage GetVoltageById(int voltageId);
        void UpdateVoltage(ClassificationVoltage classification);
        void deleteVoltage(int  voltageId);
        #endregion

        #region List of Cable

        List<ListofCable> GetAllListofCable();

        List<SelectListItem> GetListofCables();
        int AddListofCable(ListofCable cableList);
        ListofCable GetListofCableById(int cableId);
        void UpdateListofCable(ListofCable cableList);
        void DeleteListofCable(int cableId);

        #endregion

        #region Insulation material

        List<InsulationMaterial> GetAllInsulationMaterial();

        List<SelectListItem> GetInsulationMaterialSelectList();
        int AddInsulationMaterial(InsulationMaterial material);
        InsulationMaterial GetInsulationMaterialById(int materialId);
        void UpdateInsulationMaterial(InsulationMaterial material);
        void DeleteInsulationMaterial(int materialId);

        #endregion

        #region Jacket Material

        List<JacketMaterial> GetAllJacketMaterial();

        List<SelectListItem> GetJacketMaterialSelectList();
        int AddJacketMaterial(JacketMaterial jacket);
        JacketMaterial GetJacketMaterialById(int jacketId);
        void UpdateJacketMaterial(JacketMaterial jacket);
        void DeleteJacketMaterial(int jacketId);

        #endregion

        #region Manufacturer

        List<ManufacturerCable> GetAllManufacturer();

        List<SelectListItem> GetManufacturerSelectList();
        int AddManufacturer(ManufacturerCable manufacturer);
        ManufacturerCable GetManufacturerById(int manufacturerId);
        void UpdateManufacturer(ManufacturerCable manufacturer);
        void DeleteManufacturer(int manufacturerId);

        #endregion

        #region Location

        List<CableLocation> GetAllCableLocation();

        List<SelectListItem> GetCableLocationSelectList();
        int AddCableLocation(CableLocation location);
        CableLocation GetCableLocationById(int locationId);
        void UpdateCableLocation(CableLocation location);
        void DeleteCableLocation(int locationId);

        #endregion

        #region degradation mechanisms


        List<DegradationMechanisms> GetAllDegradationMechanisms();

        List<SelectListItem> GetDegradationMechanismsSelectList();
        int AddDegradationMechanisms(DegradationMechanisms mechanisms);
        DegradationMechanisms GetDegradationMechanismsById(int mechanismsId);
        void UpdateDegradationMechanisms(DegradationMechanisms mechanisms);
        void DeleteDegradationMechanisms(int mechanismsId);

        #endregion

        #region Current

        List<CableCurrent> GetAllCableCurrent();

        List<SelectListItem> GetCableCurrentSelectList();
        int AddCableCurrent(CableCurrent current);
        CableCurrent GetCableCurrentById(int currentId);
        void UpdateCableCurrent(CableCurrent current);
        void DeleteCableCurrent(int currentId);

        #endregion

        #region Cable ID

        List<CableIdentity> GetAllCableIdentity();

        List<SelectListItem> GetCableIdentitySelectList();
        int AddCableIdentity(CableIdentity cable);
        CableIdentity GetCableIdentityById(int cableId);
        void UpdateCableIdentity(CableIdentity cable);
        void DeleteCableIdentity(int cableId);

        #endregion

        #region Cable Group

        List<CableGroup> GetAllCableGroup();

        List<SelectListItem> GetCableGroupSelectList();
        int AddCableGroup(CableGroup group);
        CableGroup GetCableGroupById(int groupId);
        void UpdateCableGroup(CableGroup group);
        void DeleteCableGroup(int groupId);

        #endregion

        #region Operation Mode

        List<OperationMode> GetAllOperationMode();

        List<SelectListItem> GetOperationModeSelectList();
        int AddOperationMode(OperationMode mode);
        OperationMode GetOperationModeById(int modeId);
        void UpdateOperationMode(OperationMode mode);
        void DeleteOperationMode(int modeId);

        #endregion


        #region Method of Failure

        List<FailureDiscovery> GetAllFailureDiscovery();

        List<SelectListItem> GetFailureDiscoverySelectList();
        int AddFailureDiscovery(FailureDiscovery failure);
        FailureDiscovery GetFailureDiscoveryById(int failureId);
        void UpdateFailureDiscovery(FailureDiscovery failure);
        void DeleteFailureDiscovery(int failureId);

        #endregion

        #region  Failure Condition

        List<FailureCondition> GetAllFailureCondition();
        List<SelectListItem> GetFailureConditionSelectList();
        int AddFailureCondition(FailureCondition condition);
        FailureCondition GetFailureConditionById(int conditionId);
        void UpdateFailureCondition(FailureCondition condition);
        void DeleteFailureCondition(int conditionId);

        #endregion


        #region Failed parts

        List<FailedParts> GetAllFailedParts();
        List<SelectListItem> GetFailedPartsSelectList();
        int AddFailedParts(FailedParts parts);
        FailedParts GetFailedPartsById(int partsId);
        void UpdateFailedParts(FailedParts parts);
        void DeleteFailedParts(int partsId);

        #endregion


        #region Type of Maintenance

        List<TypeofMaintenance> GetAllTypeofMaintenance();
        List<SelectListItem> GetTypeofMaintenanceSelectList();
        int AddTypeofMaintenance(TypeofMaintenance maintenance);
        TypeofMaintenance GetTypeofMaintenanceById(int maintenanceId);
        void UpdateTypeofMaintenance(TypeofMaintenance maintenance);
        void DeleteTypeofMaintenance(int maintenanceId);

        #endregion

        #region Type Tests

        List<TestType> GetAllTestType();
        List<SelectListItem> GetTestTypeSelectList();
        int AddTestType(TestType test);
        TestType GetTestTypeById(int testId);
        void UpdateTestType(TestType test);
        void DeleteTestType(int testId);

        #endregion

        #region Result

        List<ResaultCable> GetAllResaultCable();
        List<SelectListItem> GetResaultCableSelectList();
        int AddResaultCable(ResaultCable result);
        ResaultCable GetResaultCableById(int resultId);
        void UpdateResaultCable(ResaultCable result);
        void DeleteResaultCable(int resultId);

        #endregion
    }
}
