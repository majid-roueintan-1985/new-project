using Bnpp.Core.Convertors;
using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Entities.OperationalDatas;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
	public class OperationalController : Controller
	{
		private ISensorService _sensor;
		private IConfiguration Configuration;
		private IMechanicalService _mechanical;
		public OperationalController(ISensorService sensor, IConfiguration _configuration, IMechanicalService mechanical
)
		{
			Configuration = _configuration;
			_sensor = sensor;
			_mechanical = mechanical;
		}


		[Route("Operational/{id}")]
		public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		#region Sensors

		[BindProperty]
		public Operational Operational { get; set; }

		public IActionResult Sensors(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_sensor.GetAllSensors(id));
		}

		[HttpPost]
		public IActionResult ExportSensors(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _sensor.GetAllSensorsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Sensors Data";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sensors Data.xlsx");
					}
				}
			}
			else
			{
				var res = new List<SensorViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _sensor.GetSensorByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Sensors Data";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sensors Data.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportSensors(IFormFile FormFile, int mechanicalId)
		{
			//get file name
			//var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
			string filename = Path.GetFileName(FormFile.FileName);
			//get path
			var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

			//create directory "Uploads" if it doesn't exists
			if (!Directory.Exists(MainPath))
			{
				Directory.CreateDirectory(MainPath);
			}

			//get file path 
			var filePath = Path.Combine(MainPath, FormFile.FileName);
			using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
			{
				await FormFile.CopyToAsync(stream);
			}

			//get extension
			string extension = Path.GetExtension(filename);


			string conString = string.Empty;

			switch (extension)
			{
				case ".xls": //Excel 97-03.
					conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
				case ".xlsx": //Excel 07 and above.
					conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
			}

			DataTable dt = new DataTable();
			conString = string.Format(conString, filePath);

			dt.Columns.Add("OperationalId", typeof(int));

			using (OleDbConnection connExcel = new OleDbConnection(conString))
			{
				using (OleDbCommand cmdExcel = new OleDbCommand())
				{
					using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
					{
						cmdExcel.Connection = connExcel;

						//Get the name of First Sheet.
						connExcel.Open();
						DataTable dtExcelSchema;
						dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
						string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
						connExcel.Close();

						//Read Data from First Sheet.
						connExcel.Open();
						cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
						odaExcel.SelectCommand = cmdExcel;
						odaExcel.Fill(dt);

						// Add new column to table  

						dt.Columns.Add("CreateDate", typeof(DateTime));
						dt.Columns.Add("IsDelete", typeof(bool));
						dt.Columns.Add("ParameterName", typeof(string));
						dt.Columns.Add("TypeId", typeof(int));
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["ParameterName"] = null;
							row["TypeId"] = 1;
						}

						connExcel.Close();
					}
				}
			}
			//your database connection string
			//conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.Operationals";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("ParameterName", "ParameterName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("SensorName", "SensorName");
					sqlBulkCopy.ColumnMappings.Add("AKZ", "AKZ");
					sqlBulkCopy.ColumnMappings.Add("MinimumValue", "MinimumValue");
					sqlBulkCopy.ColumnMappings.Add("MaximumValue", "MaximumValue");
					sqlBulkCopy.ColumnMappings.Add("NormalValue", "NormalValue");
					sqlBulkCopy.ColumnMappings.Add("TransientEvents", "TransientEvents");
					sqlBulkCopy.ColumnMappings.Add("Unit", "Unit");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");

					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

					con.Open();
					sqlBulkCopy.WriteToServer(dt);
					con.Close();
				}
			}
			//if the code reach here means everthing goes fine and excel data is imported into database
			ViewBag.Message = "File Imported and excel data saved into database";

			return RedirectToAction("Index", new { id = mechanicalId });
			//return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult CraeteSensors(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteSensors(Operational sensor)
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.AddSensor(Operational);
			return new JsonResult("success");
		}

		public IActionResult EditSensors(int id)
		{
			return View(_sensor.GetSensorById(id));
		}

		[HttpPost]
		public IActionResult EditSensors()
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.UpdateSensor(Operational);
			return new JsonResult("success");
		}

		public IActionResult DeleteSensors(string[] sensorId)
		{
			foreach (string id in sensorId)
			{
				_sensor.DeleteSensor(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Chemical Water


		public IActionResult ChemicalWater(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_sensor.GetAllChemicalWater(id));
		}



		[HttpPost]
		public IActionResult ExportChemicalWater(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _sensor.GetAllChemicalWaterForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Chemical Water Data";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Water Data.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ChemicalWaterViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _sensor.GetChemicalWaterByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Chemical Water Data";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Water Data.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportChemicalWater(IFormFile FormFile, int mechanicalId)
		{
			//get file name
			//var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
			string filename = Path.GetFileName(FormFile.FileName);
			//get path
			var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

			//create directory "Uploads" if it doesn't exists
			if (!Directory.Exists(MainPath))
			{
				Directory.CreateDirectory(MainPath);
			}

			//get file path 
			var filePath = Path.Combine(MainPath, FormFile.FileName);
			using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
			{
				await FormFile.CopyToAsync(stream);
			}

			//get extension
			string extension = Path.GetExtension(filename);


			string conString = string.Empty;

			switch (extension)
			{
				case ".xls": //Excel 97-03.
					conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
				case ".xlsx": //Excel 07 and above.
					conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
			}

			DataTable dt = new DataTable();
			conString = string.Format(conString, filePath);

			dt.Columns.Add("OperationalId", typeof(int));

			using (OleDbConnection connExcel = new OleDbConnection(conString))
			{
				using (OleDbCommand cmdExcel = new OleDbCommand())
				{
					using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
					{
						cmdExcel.Connection = connExcel;

						//Get the name of First Sheet.
						connExcel.Open();
						DataTable dtExcelSchema;
						dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
						string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
						connExcel.Close();

						//Read Data from First Sheet.
						connExcel.Open();
						cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
						odaExcel.SelectCommand = cmdExcel;
						odaExcel.Fill(dt);

						// Add new column to table  

						dt.Columns.Add("CreateDate", typeof(DateTime));
						dt.Columns.Add("IsDelete", typeof(bool));
						dt.Columns.Add("SensorName", typeof(string));
						dt.Columns.Add("TypeId", typeof(int));
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["SensorName"] = null;
							row["TypeId"] = 2;
						}

						connExcel.Close();
					}
				}
			}
			//your database connection string
			//conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.Operationals";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("ParameterName", "ParameterName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("SensorName", "SensorName");
					sqlBulkCopy.ColumnMappings.Add("AKZ", "AKZ");
					sqlBulkCopy.ColumnMappings.Add("MinimumValue", "MinimumValue");
					sqlBulkCopy.ColumnMappings.Add("MaximumValue", "MaximumValue");
					sqlBulkCopy.ColumnMappings.Add("NormalValue", "NormalValue");
					sqlBulkCopy.ColumnMappings.Add("TransientEvents", "TransientEvents");
					sqlBulkCopy.ColumnMappings.Add("Unit", "Unit");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");

					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

					con.Open();
					sqlBulkCopy.WriteToServer(dt);
					con.Close();
				}
			}
			//if the code reach here means everthing goes fine and excel data is imported into database
			ViewBag.Message = "File Imported and excel data saved into database";

			//return RedirectToAction("Index", new { id = mechanicalId });
			return NoContent();
		}

		public IActionResult CraeteChemicalWater(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
		}

		[HttpPost]
		public IActionResult CraeteChemicalWater(Operational sensor)
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.AddChemicalWater(Operational);
			return new JsonResult("success");
		}

		public IActionResult EditChemicalWater(int id)
		{
			return View(_sensor.GetChemicalWaterById(id));
		}

		[HttpPost]
		public IActionResult EditChemicalWater()
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.UpdateChemicalWater(Operational);
			return new JsonResult("success");
		}

		public IActionResult DeleteChemicalWater(string[] chemicalId)
		{
			foreach (string id in chemicalId)
			{
				_sensor.DeleteChemicalWater(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Environmental

		public IActionResult Environmental(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_sensor.GetAllEnvironmental(id));
		}

		[HttpPost]
		public IActionResult ExportEnvironmental(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _sensor.GetAllEnvironmentalForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Environmental Data";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Environmental Data.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ChemicalWaterViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _sensor.GetEnvironmentalByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Environmental Data";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Environmental Data.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportEnvironmental(IFormFile FormFile, int mechanicalId)
		{
			//get file name
			//var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
			string filename = Path.GetFileName(FormFile.FileName);
			//get path
			var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

			//create directory "Uploads" if it doesn't exists
			if (!Directory.Exists(MainPath))
			{
				Directory.CreateDirectory(MainPath);
			}

			//get file path 
			var filePath = Path.Combine(MainPath, FormFile.FileName);
			using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
			{
				await FormFile.CopyToAsync(stream);
			}

			//get extension
			string extension = Path.GetExtension(filename);


			string conString = string.Empty;

			switch (extension)
			{
				case ".xls": //Excel 97-03.
					conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
				case ".xlsx": //Excel 07 and above.
					conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
					break;
			}

			DataTable dt = new DataTable();
			conString = string.Format(conString, filePath);

			dt.Columns.Add("OperationalId", typeof(int));

			using (OleDbConnection connExcel = new OleDbConnection(conString))
			{
				using (OleDbCommand cmdExcel = new OleDbCommand())
				{
					using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
					{
						cmdExcel.Connection = connExcel;

						//Get the name of First Sheet.
						connExcel.Open();
						DataTable dtExcelSchema;
						dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
						string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
						connExcel.Close();

						//Read Data from First Sheet.
						connExcel.Open();
						cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
						odaExcel.SelectCommand = cmdExcel;
						odaExcel.Fill(dt);

						// Add new column to table  

						dt.Columns.Add("CreateDate", typeof(DateTime));
						dt.Columns.Add("IsDelete", typeof(bool));
						dt.Columns.Add("SensorName", typeof(string));
						dt.Columns.Add("TypeId", typeof(int));
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["SensorName"] = null;
							row["TypeId"] = 3;
						}

						connExcel.Close();
					}
				}
			}
			//your database connection string
			//conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.Operationals";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("ParameterName", "ParameterName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("SensorName", "SensorName");
					sqlBulkCopy.ColumnMappings.Add("AKZ", "AKZ");
					sqlBulkCopy.ColumnMappings.Add("MinimumValue", "MinimumValue");
					sqlBulkCopy.ColumnMappings.Add("MaximumValue", "MaximumValue");
					sqlBulkCopy.ColumnMappings.Add("NormalValue", "NormalValue");
					sqlBulkCopy.ColumnMappings.Add("TransientEvents", "TransientEvents");
					sqlBulkCopy.ColumnMappings.Add("Unit", "Unit");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");

					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

					con.Open();
					sqlBulkCopy.WriteToServer(dt);
					con.Close();
				}
			}
			//if the code reach here means everthing goes fine and excel data is imported into database
			ViewBag.Message = "File Imported and excel data saved into database";

			//return RedirectToAction("Index", new { id = mechanicalId });
			return NoContent();
		}

		public IActionResult CraeteEnvironmental(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
		}

		[HttpPost]
		public IActionResult CraeteEnvironmental(Operational sensor)
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.AddEnvironmental(Operational);
			return new JsonResult("success");
		}

		public IActionResult EditEnvironmental(int id)
		{
			return View(_sensor.GetEnvironmentalById(id));
		}

		[HttpPost]
		public IActionResult EditEnvironmental()
		{
			//if (!ModelState.IsValid)
			//    return View();

			_sensor.UpdateEnvironmental(Operational);
			return new JsonResult("success");
		}

		public IActionResult DeleteEnvironmental(string[] environmentalId)
		{
			foreach (string id in environmentalId)
			{
				_sensor.DeleteEnvironmental(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#endregion


		[BindProperty]
		public InspectionDocument Document { get; set; }

		#region Sensor Document

		public IActionResult SensorDocument()
		{
			return View(_sensor.GetAllSensorDocument());
		}

		public IActionResult CreateSensorDocument()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateSensorDocument(IFormFile sensorDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.AddSensorDocument(Document, sensorDocs);

			return new JsonResult("success");
		}

		public IActionResult EditSensorDocument(int id)
		{
			return View(_sensor.GetSensorDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditSensorDocument(IFormFile sensorDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.UpdateSensorDocument(Document, sensorDocs);

			return new JsonResult("success");
		}

		public IActionResult DeleteSensorDocument(string[] sensorId)
		{
			foreach (string id in sensorId)
			{
				_sensor.DeleteSensorDocument(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Water Sensor Document

		public IActionResult WaterSensorDocument()
		{
			return View(_sensor.GetAllChemicalWaterDocument());
		}

		public IActionResult CreateWaterSensorDocument()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateWaterSensorDocument(IFormFile waterDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.AddChemicalWaterDocument(Document, waterDocs);

			return new JsonResult("success");
		}

		public IActionResult EditWaterSensorDocument(int id)
		{
			return View(_sensor.GetChemicalWaterDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditWaterSensorDocument(IFormFile waterDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.UpdateChemicalWaterDocument(Document, waterDocs);

			return new JsonResult("success");
		}


		public IActionResult DeleteWaterSensorDocument(string[] watersensorId)
		{
			foreach (string id in watersensorId)
			{
				_sensor.DeleteChemicalWaterDocument(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Environmental Sensor

		public IActionResult EnvironmentalSensor()
		{
			return View(_sensor.GetAllEnvironmentalSensor());
		}


		public IActionResult CreateEnvironmentalSensor()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateEnvironmentalSensor(IFormFile environmentalDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.AddEnvironmentalSensor(Document, environmentalDocs);

			return new JsonResult("success");
		}


		public IActionResult EditEnvironmentalSensor(int id)
		{
			return View(_sensor.GetEnvironmentalSensorById(id));
		}

		[HttpPost]
		public IActionResult EditEnvironmentalSensor(IFormFile environmentalDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_sensor.UpdateEnvironmentalSensor(Document, environmentalDocs);

			return new JsonResult("success");
		}


		public IActionResult DeleteEnvironmentalSensor(string[] environsensorId)
		{
			foreach (string id in environsensorId)
			{
				_sensor.DeleteEnvironmentalSensor(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion
	}
}
