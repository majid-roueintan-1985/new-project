using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bnpp.Core.Services.Interfaces
{
	public interface IInspectionService
	{
		#region Inspection Report

		List<InspectionDocument> GetAllInspectionReports(int mechanicalId);
		List<InspectionReportsViewModel> GetAllInspectionReportsForExport(int mechanicalId);
		int AddInspectionReports(InspectionDocument document, IFormFile imgReports);
		InspectionDocument GetInspectionReportsById(int reportId);
		InspectionReportsViewModel GetInspectionReportsByIdForExport(int reportId);
		void UpdateInspectionReports(InspectionDocument document, IFormFile imgReports);
		void DeleteInspectionReports(int reportId);

		#endregion

		#region Visual Inspection Form


		List<InspectionDocument> GetAllVisualInspectionForm(int mechanicalId);
		List<VisualFormViewModel> GetAllVisualInspectionFormForExport(int mechanicalId);
		int AddVisualInspectionForm(InspectionDocument document, IFormFile imgVisual);
		InspectionDocument GetVisualInspectionFormById(int visualId);
		VisualFormViewModel GetVisualInspectionFormByIdForExport(int visualId);
		void UpdateVisualInspectionForm(InspectionDocument document, IFormFile imgVisual);
		void DeleteVisualInspectionForm(int visualId);



		#endregion

		#region Leakage Test Form

		List<InspectionDocument> GetAllLeakageForm(int mechanicalId);
		List<VisualFormViewModel> GetAllLeakageFormForExport(int mechanicalId);
		int AddLeakageForm(InspectionDocument document, IFormFile imgLeakage);
		InspectionDocument GetLeakageFormById(int leakageId);
		VisualFormViewModel GetLeakageFormByIdForExport(int leakageId);
		void UpdateLeakageForm(InspectionDocument document, IFormFile imgLeakage);
		void DeleteLeakageForm(int leakageId);

		#endregion

		#region Liquid Penetration Test Form

		List<InspectionDocument> GetAllPenetrationForm(int mechanicalId);
		List<VisualFormViewModel> GetAllPenetrationFormForExport(int mechanicalId);
		int AddPenetrationForm(InspectionDocument document, IFormFile imgLiquid);
		InspectionDocument GetPenetrationFormById(int liquidId);
		VisualFormViewModel GetPenetrationFormByIdForExport(int liquidId);
		void UpdatePenetrationForm(InspectionDocument document, IFormFile imgLiquid);
		void DeletePenetrationForm(int liquidId);

		#endregion

		#region Magnetic Powder Test Form

		List<InspectionDocument> GetAllMagneticForm(int mechanicalId);
		List<VisualFormViewModel> GetAllMagneticFormForExport(int mechanicalId);
		int AddMagneticForm(InspectionDocument document, IFormFile imgMagnetic);
		InspectionDocument GetMagneticFormById(int magneticId);
		VisualFormViewModel GetMagneticFormByIdForExport(int magneticId);
		void UpdateMagneticForm(InspectionDocument document, IFormFile imgMagnetic);
		void DeleteMagneticForm(int magneticId);

		#endregion

		#region Radiographics Test Form

		List<InspectionDocument> GetAllRadiographicsForm(int mechanicalId);
		List<VisualFormViewModel> GetAllRadiographicsFormForExport(int mechanicalId);
		int AddRadiographicsForm(InspectionDocument document, IFormFile imgRadiographics);
		InspectionDocument GetRadiographicsFormById(int radiographicsId);
		VisualFormViewModel GetRadiographicsFormByIdForExport(int radiographicsId);
		void UpdateRadiographicsForm(InspectionDocument document, IFormFile imgRadiographics);
		void DeleteRadiographicsForm(int radiographicsId);

		#endregion

		#region Ultrasonic Test Form

		List<InspectionDocument> GetAllUltrasonicForm(int mechanicalId);
		List<VisualFormViewModel> GetAllUltrasonicFormForExport(int mechanicalId);
		int AddUltrasonicForm(InspectionDocument document, IFormFile imgUltrasonic);
		InspectionDocument GetUltrasonicFormById(int ultrasonicId);
		VisualFormViewModel GetUltrasonicFormByIdForExport(int ultrasonicId);
		void UpdateUltrasonicForm(InspectionDocument document, IFormFile imgUltrasonic);
		void DeleteUltrasonicForm(int ultrasonicId);


		#endregion

		#region Metal thickness ultrasonic Test Form

		List<InspectionDocument> GetAllMetalForm(int mechanicalId);
		List<VisualFormViewModel> GetAllMetalFormForExport(int mechanicalId);
		int AddMetalForm(InspectionDocument document, IFormFile imgMetal);
		InspectionDocument GetMetalFormById(int metalId);
		VisualFormViewModel GetMetalFormByIdForExport(int metalId);
		void UpdateMetalForm(InspectionDocument document, IFormFile imgMetal);
		void DeleteMetalForm(int metalId);

		#endregion

		#region Inspection Instructions

		List<InspectionDocument> GetAllInspectionInstructions(int mechanicalId);
		List<InspectionInstructionsViewModel> GetAllInspectionInstructionsForExport(int mechanicalId);
		int AddInspectionInstructions(InspectionDocument document, IFormFile imgInstructions);
		InspectionDocument GetInspectionInstructionsById(int instructionsId);
		InspectionInstructionsViewModel GetInspectionInstructionsByIdForExport(int instructionsId);
		void UpdateInspectionInstructions(InspectionDocument document, IFormFile imgInstructions);
		void DeleteInspectionInstructions(int instructionsId);

		#endregion

		#region TypicalPrograms

		List<TypicalPrograms> GetAlTypicalPrograms(int mechanicalId);
		List<TypicalProgramsViewModel> GetAlTypicalProgramsForExport(int mechanicalId);
		int AddTypicalPrograms(TypicalPrograms typical);
		void UpdateTypicalPrograms(TypicalPrograms typical);
		TypicalPrograms GetTypicalProgramsById(int typicalId);
		TypicalProgramsViewModel GetTypicalProgramsByIdForExport(int typicalId);
		void DeleteTypicalPrograms(int typicalId);

		#endregion

		#region Working Programs

		List<WorkingPrograms> GetAlWorkingPrograms(int mechanicalId);
		List<WorkingProgramsViewModel> GetAlWorkingProgramsForExport(int mechanicalId);
		int AddWorkingPrograms(WorkingPrograms programs);
		void UpdateWorkingPrograms(WorkingPrograms programs);
		WorkingPrograms GetWorkingProgramsById(int programsId);
		WorkingProgramsViewModel GetWorkingProgramsByIdForExport(int programsId);
		void DeleteWorkingPrograms(int programsId);

		#endregion

		#region Visual Control

		List<TestResults> GetAllVisualControl(int mechanicalId);
		List<VisualControlViewModel> GetAllVisualControlForExport(int mechanicalId);
		int AddVisualControl(TestResults visual);
		void UpdateVisualControl(TestResults visual);
		TestResults GetVisualControlById(int visualId);
		VisualControlViewModel GetVisualControlByIdForExport(int visualId);
		void DeleteVisualControl(int visualId);

		#endregion

		#region  Leakage Test


		List<TestResults> GetAllLeakageTest(int mechanicalId);
		List<LeakageTestViewModel> GetAllLeakageTestForExport(int mechanicalId);
		int AddLeakageTest(TestResults leakage);
		void UpdateLeakageTest(TestResults leakage);
		TestResults GetLeakageTestById(int leakageId);
		LeakageTestViewModel GetLeakageTestByIdForExport(int leakageId);

		void DeleteLeakageTest(int leakageId);

		#endregion

		#region Liquid Penetrated Test

		List<TestResults> GetAllLiquidPenetrated(int mechanicalId);
		List<LiquidPenetratedTestViewModel> GetAllLiquidPenetratedForExport(int mechanicalId);
		int AddLiquidPenetrated(TestResults penetrated);
		void UpdateLiquidPenetrated(TestResults penetrated);
		TestResults GetLiquidPenetratedById(int penetratedId);
		LiquidPenetratedTestViewModel GetLiquidPenetratedByIdForExport(int penetratedId);
		void DeleteLiquidPenetrated(int penetratedId);

		#endregion

		#region Magnetic Powder test

		List<TestResults> GetAllMagneticPowder(int mechanicalId);
		List<MagneticPowderViewModel> GetAllMagneticPowderForExport(int mechanicalId);
		int AddMagneticPowder(TestResults powder);
		void UpdateMagneticPowder(TestResults powder);
		TestResults GetMagneticPowderById(int powderId);
		MagneticPowderViewModel GetMagneticPowderByIdForExport(int powderId);
		void DeleteMagneticPowder(int powderId);

		#endregion

		#region Radiographics Test

		List<TestResults> GetAllRadiographics(int mechanicalId);
		List<RadiographicsViewModel> GetAllRadiographicsForExport(int mechanicalId);
		int AddRadiographics(TestResults radiographics);
		void UpdateRadiographics(TestResults radiographics);
		TestResults GetRadiographicsById(int radiographicsId);
		RadiographicsViewModel GetRadiographicsByIdForExport(int radiographicsId);
		void DeleteRadiographics(int radiographicsId);

		#endregion

		#region Ultrasonic Tests

		List<TestResults> GetAllUltrasonic(int mechanicalId);
		List<UltrasonicViewModel> GetAllUltrasonicForExport(int mechanicalId);
		int AddUltrasonic(TestResults ultrasonic);
		void UpdateUltrasonic(TestResults ultrasonic);
		TestResults GetUltrasonicById(int ultrasonicId);
		UltrasonicViewModel GetUltrasonicByIdForExport(int ultrasonicId);
		void DeleteUltrasonic(int ultrasonicId);

		#endregion

		#region Metal thickness ultrasonic measurement

		List<TestResults> GetAllMetalThickness(int mechanicalId);
		List<MetalThicknessViewModel> GetAllMetalThicknessForExport(int mechanicalId);
		int AddMetalThickness(TestResults metal);
		void UpdateMetalThickness(TestResults metal);
		TestResults GetMetalThicknessById(int metalId);
		MetalThicknessViewModel GetMetalThicknessByIdForExport(int metalId);
		void DeleteMetalThickness(int metalId);

		#endregion

		#region Typical Programs Document

		List<InspectionDocument> GetAllTypicalDocument();
		int AddTypicalDocument(InspectionDocument document, IFormFile imgTypical);
		InspectionDocument GetTypicalDocumentById(int typicalId);
		void UpdateTypicalDocument(InspectionDocument document, IFormFile imgTypical);
		void DeleteTypicalDocument(int typicalId);

		#endregion

		#region Working Programs Document

		List<InspectionDocument> GetAllWorkingDocument();
		int AddWorkingDocument(InspectionDocument document, IFormFile imgWorking);
		InspectionDocument GetWorkingDocumentById(int workingId);
		void UpdateWorkingDocument(InspectionDocument document, IFormFile imgWorking);
		void DeleteWorkingDocument(int workingId);

		#endregion
	}
}
