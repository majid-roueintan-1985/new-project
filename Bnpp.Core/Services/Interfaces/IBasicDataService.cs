using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.AgeingManagementDocuments;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IBasicDataService
    {
        #region General Data

        List<GeneralData> GetAllGeneralData(int mechanicalId);
        List<GeneralDataViewModel> GetAllGeneralDataForExport(int mechanicalId);
        int AddGeneralData(GeneralData data);
        void UpdateGeneralData(GeneralData data);
        GeneralData GetGeneralDataById(int generalId);
        GeneralDataViewModel GetGeneralDataByIdForExport(int generalId);

        void DeleteGeneralData(int generalId);
		#endregion

		#region General Document

		List<InspectionDocument> GetAllGeneralDataDocument(int mechanicalId);
        int AddGeneralDataDocument(InspectionDocument document, IFormFile fileGeneral);
		void DeleteGeneralDocumentData(int generalDocumentId);

		#endregion   

		#region Design Data
		List<DesignData> GetAllDesignData(int mechanicalId);
        List<DesignDataViewModel> GetAllDesignDataForExport(int mechanicalId);

        int AddDesignData(DesignData design);

        void UpdateDesignData(DesignData design);
        DesignData GetDesignDataById(int designId);
        DesignDataViewModel GetDesignDataByIdForExport(int designId);

        void DeleteDesignData(int designId);
        #endregion

        #region Documents

        List<DesignDocument> GetAllDesignDocument(int mechanicalId);
        List<DocumentsViewModel> GetAllDesignDocumentForExport(int mechanicalId);
        int AddDesignDocument(DesignDocument designDocument, IFormFile imgDesignDocument);
        DesignDocument GetDesignDocumentById(int designDocumentId);
        DocumentsViewModel GetDesignDocumentByIdForExport(int designDocumentId);
        void UpdateDesignDocument(DesignDocument designDocument, IFormFile imgDesignDocument);
        void DeleteDesignDocument(int designDocumentId);

        #endregion

        #region Chemical Norms

        List<ChemicalNorms> GetAllChemicalNorms(int mechanicalId);
        List<ChemicalNormsViewModel> GetAllChemicalNormsForExport(int mechanicalId);
        int AddChemicalNorms(ChemicalNorms chemical);
        ChemicalNorms GetChemicalNormsById(int chemicalId);
        ChemicalNormsViewModel GetChemicalNormsByIdForExport(int chemicalId);
        void UpdateChemicalNorms(ChemicalNorms chemical);
        void DeleteChemicalNorms(int chemicalId);

        #endregion

        #region Technical Inspection Program

        List<InspectionProgram> GetAllInspectionProgram(int mechanicalId);
        List<InspectionProgramViewModel> GetAllInspectionProgramForExport(int mechanicalId);
        int AddInspectionProgram(InspectionProgram program);
        InspectionProgram GetInspectionProgramById(int programId);
        InspectionProgramViewModel GetInspectionProgramByIdForExport(int programId);
        void UpdateInspectionProgram(InspectionProgram program);
        void DeleteInspectionProgram(int programId);

        #endregion

        #region Sensors

        List<Sensors> GetAllSensors(int mechanicalId);
        List<SensorsViewModel> GetAllSensorsForExport(int mechanicalId);
        int AddSensors(Sensors sensors);
        Sensors GetSensorsById(int sensorId);
        SensorsViewModel GetSensorsByIdForExport(int sensorId);
        void UpdateSensors(Sensors sensors);
        void DeleteSensors(int sensorId);

        #endregion

        #region Control Points

        List<ControlPoints> GetAllControlPoints(int mechanicalId);
        List<ControlPointsViewModel> GetAllControlPointsForExport(int mechanicalId);
        int AddControlPoints(ControlPoints points);
        ControlPoints GetControlPointsById(int pointId);
        ControlPointsViewModel GetControlPointsByIdForExport(int pointId);
        void UpdateControlPoints(ControlPoints points);
        void DeleteControlPoints(int pointId);

        #endregion

        #region H-Forms

        List<HForms> GetAllHForms(int mechanicalId);
        List<HFormsViewModel> GetAllHFormsForExport(int mechanicalId);
        int AddHForms(HForms forms, IFormFile imgHForms);
        HForms GetHFormsById(int formsId);
        HFormsViewModel GetHFormsByIdForExport(int formsId);
        void UpdateHForms(HForms forms, IFormFile imgHForms);
        void DeleteHForms(int formsId);

		#endregion

		#region Seismic Category

		List<SeismicCategory> GetAllSeismicCategory(int mechanicalId);
		List<SeismicCategoryViewModel> GetAllSeismicCategoryForExport(int mechanicalId);
		int AddSeismicCategory(SeismicCategory category);
		SeismicCategory GetSeismicCategoryById(int categoryId);
		SeismicCategoryViewModel GetSeismicCategoryByIdForExport(int categoryId);

		void UpdateSeismicCategory(SeismicCategory category);
		void DeleteSeismicCategory(int categoryId);
		#endregion

		#region Components

		List<Components> GetAllComponents(int mechanicalId);
        List<ComponentsViewModel> GetAllComponentsForExport(int mechanicalId);
        int AddComponents(Components components, IFormFile imgComponents);
        Components GetComponentsById(int componentsId);
        ComponentsViewModel GetComponentsByIdForExport(int componentsId);
        void UpdateComponents(Components components, IFormFile imgComponents);
        void DeleteComponents(int componentsId);

        #endregion

        #region Mechanical Properties

        List<MechanicalProperties> GetAllMechanicalProperties(int componentId);
        List<MechanicalPropertiesViewModel> GetAllMechanicalPropertiesForExport(int componentId);
        int AddMechanicalProperties(MechanicalProperties mechanical);
        void UpdateMechanicalProperties(MechanicalProperties properties);
        MechanicalProperties GetMechanicalPropertiesById(int mechanicalId);
        MechanicalPropertiesViewModel GetMechanicalPropertiesByIdForExport(int mechanicalId);
        void DeleteMechanicalProperties(int mechanicalId);

        #endregion

        #region Physical Properties

        List<PhysicalProperties> GetAllPhysicalProperties(int componentId);
        List<PhysicalPropertiesViewModel> GetAllPhysicalPropertiesForExport(int componentId);
        int AddPhysicalProperties(PhysicalProperties physical);
        void UpdatePhysicalProperties(PhysicalProperties physical);
        PhysicalProperties GetPhysicalPropertiesById(int physicalId);
        PhysicalPropertiesViewModel GetPhysicalPropertiesByIdForExport(int physicalId);
        void DeletePhysicalProperties(int physicalId);

        #endregion

        #region Chemical Component

        List<ChemicalComponent> GetAllChemicalComponent(int componentId);
        List<ChemicalComponentViewModel> GetAllChemicalComponentForExport(int componentId);
        int AddChemicalComponent(ChemicalComponent chemical);
        void UpdateChemicalComponent(ChemicalComponent chemical);
        ChemicalComponent GetChemicalComponentById(int chemicalId);
        ChemicalComponentViewModel GetChemicalComponentByIdForExport(int chemicalId);
        void DeleteChemicalComponent(int chemicalId);

        #endregion

        #region Heat Opeartion

        List<HeatOperation> GetAllHeatOperation(int componentId);
        List<HeatOperationViewModel> GetAllHeatOperationForExport(int componentId);
        int AddHeatOperation(HeatOperation heat, IFormFile imgHeatOperation);
        void UpdateHeatOperation(HeatOperation heat, IFormFile imgHeatOperation);
        HeatOperation GetHeatOperationById(int heatId);
        HeatOperationViewModel GetHeatOperationByIdForExport(int heatId);
        void DeleteHeatOperation(int heatId);
        #endregion

    }
}
