using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Entities.OperationalDatas;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
	public interface ISensorService
	{

		#region Sensor

		List<Operational> GetAllSensors(int mechanicalId);
		List<SensorViewModel> GetAllSensorsForExport(int mechanicalId);
		int AddSensor(Operational sensor);
		Operational GetSensorById(int sensorId);
		SensorViewModel GetSensorByIdForExport(int sensorId);

		void UpdateSensor(Operational sensor);
		void DeleteSensor(int sensorId);

		#endregion

		#region Chemical Water

		List<Operational> GetAllChemicalWater(int mechanicalId);

		List<ChemicalWaterViewModel> GetAllChemicalWaterForExport(int mechanicalId);
		int AddChemicalWater(Operational water);
		Operational GetChemicalWaterById(int waterId);
		ChemicalWaterViewModel GetChemicalWaterByIdForExport(int waterId);

		void UpdateChemicalWater(Operational water);
		void DeleteChemicalWater(int waterId);

		#endregion

		#region Environmental

		List<Operational> GetAllEnvironmental(int mechanicalId);
		List<ChemicalWaterViewModel> GetAllEnvironmentalForExport(int mechanicalId);
		int AddEnvironmental(Operational environmental);
		Operational GetEnvironmentalById(int environmentalId);
		ChemicalWaterViewModel GetEnvironmentalByIdForExport(int environmentalId);
		void UpdateEnvironmental(Operational environmental);
		void DeleteEnvironmental(int environmentalId);

		#endregion

		#region Sensor Document

		List<InspectionDocument> GetAllSensorDocument();
		int AddSensorDocument(InspectionDocument document, IFormFile imgSensor);
		InspectionDocument GetSensorDocumentById(int sensorId);
		void UpdateSensorDocument(InspectionDocument document, IFormFile imgSensor);
		void DeleteSensorDocument(int sensorId);

		#endregion

		#region Chemical Water Document

		List<InspectionDocument> GetAllChemicalWaterDocument();
		int AddChemicalWaterDocument(InspectionDocument document, IFormFile imgWater);
		InspectionDocument GetChemicalWaterDocumentById(int waterId);
		void UpdateChemicalWaterDocument(InspectionDocument document, IFormFile imgWater);
		void DeleteChemicalWaterDocument(int waterId);

		#endregion

		#region Environmental Sensor

		List<InspectionDocument> GetAllEnvironmentalSensor();
		int AddEnvironmentalSensor(InspectionDocument document, IFormFile imgEnvironmental);
		InspectionDocument GetEnvironmentalSensorById(int environmentalId);
		void UpdateEnvironmentalSensor(InspectionDocument document, IFormFile imgEnvironmental);
		void DeleteEnvironmentalSensor(int environmentalId);

		#endregion
	}
}
