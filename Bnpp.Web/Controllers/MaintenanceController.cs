using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.Maintenance;
using Bnpp.DataLayer.Entities.OperationalDatas;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;
using Bnpp.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Bnpp.Core.Convertors;
using Bnpp.Core.Services;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;
using static System.Net.WebRequestMethods;
using Bnpp.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
	public class MaintenanceController : Controller
	{
		private IMechanicalService _mechanical;

		private IMaintenanceService _maintenanceService;
		private IConfiguration Configuration;
		public MaintenanceController(IMaintenanceService maintenanceService, IConfiguration _configuration, IMechanicalService mechanical)
		{
			Configuration = _configuration;
			_maintenanceService = maintenanceService;
			_mechanical = mechanical;
		}

		[Route("Maintenance/{id}")]
		public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}


		#region List of Defections

		[BindProperty]
		public DefectList DefectList { get; set; }


		public IActionResult Defections(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllDefectList(id));
		}

		[HttpPost]
		public IActionResult ExportDefections(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllDefectListForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "List of Defections";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "List of Defections.xlsx");
					}
				}
			}
			else
			{
				var res = new List<DefectListViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetDefectListByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "List of Defections";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "List of Defections.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportDefections(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("DefectListId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
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
					sqlBulkCopy.DestinationTableName = "dbo.DefectList";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("InstructionCorrection", "InstructionCorrection");
					sqlBulkCopy.ColumnMappings.Add("ControlCorrection", "ControlCorrection");
					sqlBulkCopy.ColumnMappings.Add("CorrectionMethod", "CorrectionMethod");
					sqlBulkCopy.ColumnMappings.Add("ControlInstructionNo", "ControlInstructionNo");
					sqlBulkCopy.ColumnMappings.Add("ControlResult", "ControlResult");
					sqlBulkCopy.ColumnMappings.Add("ControlMethod", "ControlMethod");
					sqlBulkCopy.ColumnMappings.Add("PartorEquipment", "PartorEquipment");
					sqlBulkCopy.ColumnMappings.Add("JournalNo", "JournalNo");
					sqlBulkCopy.ColumnMappings.Add("NameofDefect", "NameofDefect");
					sqlBulkCopy.ColumnMappings.Add("CorrectionDate", "CorrectionDate");
					sqlBulkCopy.ColumnMappings.Add("DetectionDate", "DetectionDate");
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

		public IActionResult CreateDefections(int id)
        {
            ViewBag.MechanicalId = id;

            return View();
		}

		[HttpPost]
		public IActionResult CreateDefections(string CorrectionDate = "", string DetectionDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (CorrectionDate != "")
			{
				string[] std = CorrectionDate.Split('/');
				DefectList.CorrectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			if (DetectionDate != "")
			{
				string[] std = DetectionDate.Split('/');
				DefectList.DetectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}


			_maintenanceService.AddDefectList(DefectList);

			return new JsonResult("success");
		}

		public IActionResult EditDefections(int id)
		{
			return View(_maintenanceService.GetDefectListById(id));
		}

		[HttpPost]
		public IActionResult EditDefections(string CorrectionDate = "", string DetectionDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (CorrectionDate != "")
			{
				string[] std = CorrectionDate.Split('/');
				DefectList.CorrectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			if (DetectionDate != "")
			{
				string[] std = DetectionDate.Split('/');
				DefectList.DetectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}


			_maintenanceService.UpdateDefectList(DefectList);

			return new JsonResult("success");
		}

		public IActionResult DeleteDefections(string[] defectionId)
		{
			foreach (string id in defectionId)
			{
				_maintenanceService.DeleteDefectList(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}
		#endregion

		#region MaintenanceForms

		[BindProperty]
		public MaintenanceForm Form { get; set; }


		public IActionResult MaintenanceForms(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllMaintenanceForm(id));
		}

		[HttpPost]
		public IActionResult ExportMaintenanceForms(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllMaintenanceFormfOReXPORT(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Maintenance Forms";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Forms.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MaintenanceFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetMaintenanceFormByIdfOReXPORT(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Maintenance Forms";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Forms.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMaintenanceForms(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("MaintenanceFormId", typeof(int));

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
						dt.Columns.Add("DocumentName", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["DocumentName"] = null;
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
					sqlBulkCopy.DestinationTableName = "dbo.MaintenanceForms";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("MaintenanceFormImage", "MaintenanceFormImage");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("DateofMaintenance", "DateofMaintenance");
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

		public IActionResult CreateMaintenanceForms(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMaintenanceForms(IFormFile fileforms, string DateofMaintenance = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (DateofMaintenance != "")
			{
				string[] std = DateofMaintenance.Split('/');
				Form.DateofMaintenance = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_maintenanceService.AddMaintenanceForm(Form, fileforms);

			return new JsonResult("success");
		}

		public IActionResult EditMaintenanceForms(int id)
		{
			return View(_maintenanceService.GetMaintenanceFormById(id));
		}

		[HttpPost]
		public IActionResult EditMaintenanceForms(IFormFile fileforms, string DateofMaintenance = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (DateofMaintenance != "")
			{
				string[] std = DateofMaintenance.Split('/');
				Form.DateofMaintenance = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_maintenanceService.UpdateMaintenanceForm(Form, fileforms);

			return new JsonResult("success");
		}

		public IActionResult DeleteMaintenanceForms(string[] formId)
		{
			foreach (string id in formId)
			{
				_maintenanceService.DeleteMaintenanceForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region  Spare Parts


		[BindProperty]
		public SpareParts Spare { get; set; }


		public IActionResult SpareParts(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllSpareParts(id));
		}



		[HttpPost]
		public IActionResult ExportSpareParts(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllSparePartsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Spare Parts List";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Spare Parts List.xlsx");
					}
				}
			}
			else
			{
				var res = new List<SparePartsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetSparePartsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Spare Parts List";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Spare Parts List.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportSpareParts(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("SpareId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
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
					sqlBulkCopy.DestinationTableName = "dbo.SpareParts";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("PartName", "PartName");
					sqlBulkCopy.ColumnMappings.Add("StandardNoofParts", "StandardNoofParts");
					sqlBulkCopy.ColumnMappings.Add("PartUnit", "PartUnit");
					sqlBulkCopy.ColumnMappings.Add("RealNoofParts", "RealNoofParts");
					sqlBulkCopy.ColumnMappings.Add("Designation", "Designation");
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

		public IActionResult CreateSpareParts(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
		}

		[HttpPost]
		public IActionResult CreateSpareParts(SpareParts parts)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_maintenanceService.AddSpareParts(Spare);

			return new JsonResult("success");
		}

		public IActionResult EditSpareParts(int id)
		{
			return View(_maintenanceService.GetSparePartsById(id));
		}

		[HttpPost]
		public IActionResult EditSpareParts()
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_maintenanceService.UpdateSpareParts(Spare);

			return new JsonResult("success");
		}

		public IActionResult DeleteSpareParts(string[] sprlistId)
		{
			foreach (string id in sprlistId)
			{
				_maintenanceService.DeleteSpareParts(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Maintenance Programs

		[BindProperty]
		public MaintenancePrograms Programs { get; set; }

		public IActionResult MaintenancePrograms(int id)
		{
			ViewBag.MechanicalId = id;
			ViewData["Documents"] = _maintenanceService.GetAllProgramsDocument();
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllMaintenancePrograms(id));
		}



		[HttpPost]
		public IActionResult ExportMaintenancePrograms(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllMaintenanceProgramsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Maintenance Programs";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Programs.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MaintenanceProgramsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetMaintenanceProgramsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Maintenance Programs";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Programs.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMaintenancePrograms(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("ProgramsId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
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
					sqlBulkCopy.DestinationTableName = "dbo.MaintenancePrograms";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("MaintenanceType", "MaintenanceType");
					sqlBulkCopy.ColumnMappings.Add("RR", "RR");
					sqlBulkCopy.ColumnMappings.Add("IR", "IR");
					sqlBulkCopy.ColumnMappings.Add("OVH", "OVH");

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

		public IActionResult CreateMaintenancePrograms(int id)
		{
			ViewBag.MechanicalId = id;

			List<SelectListItem> list = new List<SelectListItem>()
			{
				new SelectListItem { Value = "Oil system", Text = "Oil system"},
				new SelectListItem { Value = "Component cooling circuit system", Text = "Component cooling circuit system" },
				new SelectListItem { Value = "Sealing unit cooling system", Text = "Sealing unit cooling system" },
				new SelectListItem { Value = "RAB cooling system", Text = "RAB cooling system" },
				new SelectListItem { Value = "Isolated circuit system", Text = "Isolated circuit system" },
				new SelectListItem { Value = "Torsion", Text = "Torsion" },
				new SelectListItem { Value = "VACDSM system", Text = "VACDSM system" },
				new SelectListItem { Value = "Removable part", Text = "Removable part" },
				new SelectListItem { Value = "Support structures", Text = "Support structures" },
				new SelectListItem { Value = "Spherical casing", Text = "Spherical casing" }
			};


			ViewData["Types"] = new SelectList(list, "Value", "Text");

			return View();
		}

		[HttpPost]
		public IActionResult CreateMaintenancePrograms(MaintenancePrograms parts)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_maintenanceService.AddMaintenancePrograms(Programs);

			return new JsonResult("success");
		}

		public IActionResult EditMaintenancePrograms(int id)
		{
			List<SelectListItem> list = new List<SelectListItem>()
			{
				new SelectListItem { Value = "Oil system", Text = "Oil system"},
				new SelectListItem { Value = "Component cooling circuit system", Text = "Component cooling circuit system" },
				new SelectListItem { Value = "Sealing unit cooling system", Text = "Sealing unit cooling system" },
				new SelectListItem { Value = "RAB cooling system", Text = "RAB cooling system" },
				new SelectListItem { Value = "Isolated circuit system", Text = "Isolated circuit system" },
				new SelectListItem { Value = "Torsion", Text = "Torsion" },
				new SelectListItem { Value = "VACDSM system", Text = "VACDSM system" },
				new SelectListItem { Value = "Removable part", Text = "Removable part" },
				new SelectListItem { Value = "Support structures", Text = "Support structures" },
				new SelectListItem { Value = "Spherical casing", Text = "Spherical casing" }
			};


			ViewData["Types"] = new SelectList(list, "Value", "Text");

			return View(_maintenanceService.GetMaintenanceProgramsById(id));
		}

		[HttpPost]
		public IActionResult EditMaintenancePrograms()
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_maintenanceService.UpdateMaintenancePrograms(Programs);

			return new JsonResult("success");
		}

		public IActionResult DeleteMaintenancePrograms(string[] programId)
		{
			foreach (string id in programId)
			{
				_maintenanceService.DeleteMaintenancePrograms(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#region Program Documents
		[BindProperty]
		public ProgramsDocument programsDocument { get; set; }

		public IActionResult CreateProgramDocuments()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateProgramDocuments(IFormFile programsdoc)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_maintenanceService.AddProgramsDocument(programsDocument, programsdoc);

			return new JsonResult("success");
		}

		public IActionResult EditProgramDocuments(int id)
		{
			return View(_maintenanceService.GetProgramsDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditProgramDocuments(IFormFile programsdoc)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_maintenanceService.UpdateProgramsDocument(programsDocument, programsdoc);

			return new JsonResult("success");
		}

		public IActionResult DeleteProgramDocuments(string[] documentId)
		{
			foreach (string id in documentId)
			{
				_maintenanceService.DeleteProgramsDocument(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion
		#endregion

		#region  Measurements

		[BindProperty]
		public Measurements Measureing { get; set; }

		public IActionResult Measurements(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllMeasurements(id));
		}



		[HttpPost]
		public IActionResult ExportMeasurements(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllMeasurementsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Result of Measurements";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Result of Measurements Maintenance.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MeasurementsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetMeasurementsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Result of Measurements";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Result of Measurements Maintenance.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportOperationalDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("MeasurementId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
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
					sqlBulkCopy.DestinationTableName = "dbo.Measurements";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("Typeofmeasurement", "Typeofmeasurement");
					sqlBulkCopy.ColumnMappings.Add("Resultmeasurement", "Resultmeasurement");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("Dateofmeasurement", "Dateofmeasurement");
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

		public IActionResult CreateMeasurements(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
		}


		[HttpPost]
		public IActionResult CreateMeasurements(string Dateofmeasurement = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (Dateofmeasurement != "")
			{
				string[] std = Dateofmeasurement.Split('/');
				Measureing.Dateofmeasurement = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_maintenanceService.AddMeasurements(Measureing);

			return new JsonResult("success");
		}

		public IActionResult EditMeasurements(int id)
		{
			return View(_maintenanceService.GetMeasurementsById(id));
		}

		[HttpPost]
		public IActionResult EditMeasurements(string Dateofmeasurement = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (Dateofmeasurement != "")
			{
				string[] std = Dateofmeasurement.Split('/');
				Measureing.Dateofmeasurement = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_maintenanceService.UpdateMeasurements(Measureing);

			return new JsonResult("success");
		}

		public IActionResult DeleteMeasurements(string[] measureId)
		{
			foreach (string id in measureId)
			{
				_maintenanceService.DeleteMeasurements(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region  Defects Report

		[BindProperty]
		public DefectionReports Reports { get; set; }


		public IActionResult DefectsReport(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_maintenanceService.GetAllDefectionReports(id));
		}

		[HttpPost]
		public IActionResult ExportDefectsReport(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _maintenanceService.GetAllDefectionReportsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Defection Reports";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Defection Reports.xlsx");
					}
				}
			}
			else
			{
				var res = new List<DefectionReportsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _maintenanceService.GetDefectionReportsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Defection Reports";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Defection Reports.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportDefectsReport(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("DefectionReportsId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.
							row["MechanicalId"] = mechanicalId;
							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
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
					sqlBulkCopy.DestinationTableName = "dbo.DefectionReports";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("DefectionReportsImage", "DefectionReportsImage");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
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

		public IActionResult CreateDefectsReport(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
		}

		[HttpPost]
		public IActionResult CreateDefectsReport(IFormFile filereports)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_maintenanceService.AddDefectionReports(Reports, filereports);

			return new JsonResult("success");
		}

		public IActionResult EditDefectsReport(int id)
		{
			return View(_maintenanceService.GetDefectionReportsById(id));
		}

		[HttpPost]
		public IActionResult EditDefectsReport(IFormFile filereports)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_maintenanceService.UpdateDefectionReports(Reports, filereports);

			return new JsonResult("success");
		}

		public IActionResult DeleteDefectsReport(string[] reportsId)
		{
			foreach (string id in reportsId)
			{
				_maintenanceService.DeleteDefectionReports(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion
	}
}
