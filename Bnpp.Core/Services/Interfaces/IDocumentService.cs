using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.AgeingDocuments;
using Bnpp.DataLayer.Entities.BasicData;
using Microsoft.AspNetCore.Http;

namespace Bnpp.Core.Services.Interfaces
{
	public interface IDocumentService
	{
		#region  Ageing Document

		List<OperationalDocuments> GetAllOperationalDocuments(int mechanicalId);
		List<OperationalDocumentsViewModel> GetAllOperationalDocumentsForExport(int mechanicalId);
		int AddOperationalDocuments(OperationalDocuments operational, IFormFile imgoperational);
		OperationalDocuments GetOperationalDocumentsById(int operationalId);
		OperationalDocumentsViewModel GetOperationalDocumentsByIdForExport(int operationalId);
		void UpdateOperationalDocuments(OperationalDocuments operational, IFormFile imgoperational);
		void DeleteOperationalDocuments(int operationalId);

		#endregion

		#region Drawing

		List<Drawing> GetAllDrawing(int mechanicalId);
		List<DrawingViewModel> GetAllDrawingForExport(int mechanicalId);
		int AddDrawing(Drawing drawing, IFormFile imgDrawing);
		Drawing GetDrawingById(int drawingId);
		DrawingViewModel GetDrawingByIdForExport(int drawingId);
		void UpdateDrawing(Drawing drawing, IFormFile imgDrawing);
		void DeleteDrawing(int drawingId);

		#endregion

		#region Standard

		List<Standard> GetAllStandard(int mechanicalId);
		List<StandardViewModel> GetAllStandardForExport(int mechanicalId);


		int AddStandard(Standard standard, IFormFile imgStandard);
		Standard GetimgStandardById(int standardId);
		StandardViewModel GetimgStandardByIdForExport(int standardId);
		void UpdateimgStandard(Standard standard, IFormFile imgStandard);
		void DeleteimgStandard(int standardId);

		#endregion

		#region Manufacturer

		List<Manufacturer> GetAllManufacturer(int mechanicalId);
		List<ManufacturerViewModel> GetAllManufacturerForExport(int mechanicalId);
		int AddManufacturer(Manufacturer manufacturer, IFormFile imgManufacturer);
		Manufacturer GetManufacturerById(int manufacturerId);
		ManufacturerViewModel GetManufacturerByIdForExport(int manufacturerId);
		void UpdateManufacturer(Manufacturer manufacturer, IFormFile imgManufacturer);
		void DeleteManufacturer(int manufacturerId);

		#endregion

		#region Installation

		List<Installation> GetAllInstallation(int mechanicalId);
		List<InstallationViewModel> GetAllInstallationForExport(int mechanicalId);
		int AddInstallation(Installation installation, IFormFile imgInstallation);
		Installation GetInstallationById(int installationId);
		InstallationViewModel GetInstallationByIdForExport(int installationId);
		void UpdateInstallation(Installation installation, IFormFile imgInstallation);
		void DeleteInstallation(int installationId);

		#endregion

		#region Maintenance Document

		List<MaintenanceDocument> GetAllMaintenanceDocument(int mechanicalId);
		List<MaintenanceDocumentViewModel> GetAllMaintenanceDocumentForEXport(int mechanicalId);
		int AddMaintenanceDocument(MaintenanceDocument maintenance, IFormFile imgMaintenance);
		MaintenanceDocument GetMaintenanceDocumentById(int maintenanceId);
		MaintenanceDocumentViewModel GetMaintenanceDocumentByIdForEXport(int maintenanceId);
		void UpdateMaintenanceDocument(MaintenanceDocument maintenance, IFormFile imgMaintenance);
		void DeleteMaintenanceDocument(int maintenanceId);

		#endregion

		#region Ageing

		List<Ageing> GetAllAgeing(int mechanicalId);
		List<AgeingViewModel> GetAllAgeingForExport(int mechanicalId);
		int AddAgeing(Ageing ageing, IFormFile imgAgeing);
		Ageing GetAgeingById(int ageingId);
		AgeingViewModel GetAgeingByIdForExport(int ageingId);
		void UpdateAgeing(Ageing ageing, IFormFile imgAgeing);
		void DeleteAgeing(int ageingId);

		#endregion
	}
}
