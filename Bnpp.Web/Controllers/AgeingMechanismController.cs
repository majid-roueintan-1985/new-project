using System;
using Bnpp.Core.Convertors;
using System.IO;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities.AgeingMechanism;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Bnpp.Core.ViewModels;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Bnpp.DataLayer.Entities.InspectionData;

namespace Bnpp.Web.Controllers
{
	public class AgeingMechanismController : Controller
	{
		private IMechanismService _mechanismService;
		private IConfiguration Configuration;
		private IMechanicalService _mechanical;
		public AgeingMechanismController(IMechanismService mechanismService, IConfiguration _configuration, IMechanicalService mechanical)
		{
			Configuration = _configuration;
			_mechanismService = mechanismService;
			_mechanical = mechanical;
		}
		[Route("AgeingMechanism/{id}")]
		public IActionResult Index(int id)
		{
			//ViewBag.ImportType = importType;
			ViewBag.MechanicalId = id;
			return View();
		}

		#region Mechanism
		[BindProperty] public Mechanism Mechanisms { get; set; }


		public IActionResult Mechanism(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
            ViewBag.AgeingMechanismDocument = _mechanismService.GetAllAgeingMechanismDocument(id);
            return View(_mechanismService.GetAllMechanism(id));
		}



		[HttpPost]
		public IActionResult ExportMechanism(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _mechanismService.GetAllMechanismForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Ageing Mechanism";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Mechanism.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MechanismViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _mechanismService.GetMechanismByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Ageing Mechanism";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Mechanism.xlsx");
					}
				}
			}

		}


		[HttpPost]
		public async Task<IActionResult> ImportMechanism(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("MechanismId", typeof(int));

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
						dt.Columns.Add("MechanicalId", typeof(int));
						dt.Columns.Add("CreateDate", typeof(DateTime));
						dt.Columns.Add("IsDelete", typeof(bool));

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
					sqlBulkCopy.DestinationTableName = "dbo.Mechanism";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("DegradationMechanism", "DegradationMechanism");
					sqlBulkCopy.ColumnMappings.Add("Component", "Component");
					sqlBulkCopy.ColumnMappings.Add("Region", "Region");
					sqlBulkCopy.ColumnMappings.Add("CriticalPoint", "CriticalPoint");
					sqlBulkCopy.ColumnMappings.Add("Consequences", "Consequences");

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
			//return NoContent();
		}

		public IActionResult CreateMechanism(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMechanism(Mechanism design)
		{
			//if (!ModelState.IsValid)
			//    return View();

			_mechanismService.AddMechanism(Mechanisms);
			return new JsonResult("success");
		}

		public IActionResult EditMechanism(int id)
		{
			return View(_mechanismService.GetMechanismById(id));
		}

		[HttpPost]
		public IActionResult EditMechanism()
		{
			//if (!ModelState.IsValid)
			//    return View();

			_mechanismService.UpdateMechanism(Mechanisms);
			return new JsonResult("success");
		}

		public IActionResult DleteMechanism(string[] mechanismId)
		{
			foreach (string id in mechanismId)
			{
				_mechanismService.DeleteMechanism(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Documents

		[BindProperty]
		public MechanismDocuments MechanismDocument { get; set; }

		public IActionResult Documents(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_mechanismService.GetAllMechanismDocuments(id));
		}



		[HttpPost]
		public IActionResult ExportDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _mechanismService.GetAllMechanismDocumentsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Ageing Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Mechanism.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MechanismDocumentsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _mechanismService.GetMechanismDocumentsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Ageing Documents";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Documents.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("MechanismDocumentsId", typeof(int));

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

			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.MechanismDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("MechanismDocumentsImage", "MechanismDocumentsImage");
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

			//return RedirectToAction("Index", new { id = mechanicalId ,importType=1});
			return NoContent();
		}

		public IActionResult CreateMechanismDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMechanismDocuments(IFormFile mechanismDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_mechanismService.AddMechanismDocuments(MechanismDocument, mechanismDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditMechanismDocuments(int id)
		{
			return View(_mechanismService.GetMechanismDocumentsById(id));
		}

		[HttpPost]
		public IActionResult EditMechanismDocuments(IFormFile mechanismDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_mechanismService.UpdateMechanismDocuments(MechanismDocument, mechanismDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}


		public IActionResult DeleteMechanismDocuments(string[] mechanismDocumentsId)
		{
			foreach (string id in mechanismDocumentsId)
			{
				_mechanismService.DeleteMechanismDocuments(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Gallery 


		[BindProperty]
		public InspectionDocument AgeingMechanismDocument { get; set; }

		public IActionResult CreateAgeingMechanismDocument(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}


		[HttpPost]
		public IActionResult CreateAgeingMechanismDocument(List<IFormFile> fileAgeing)
		{
			foreach (var file in fileAgeing)
			{
				var ageingMechanismDocument = new InspectionDocument
				{
					Code = AgeingMechanismDocument.Code,
					CreateDate = DateTime.Now,
					Filename = file.FileName,
					IsDelete = false,
					TypeId = 19,
					MechanicalId = AgeingMechanismDocument.MechanicalId
				};
				_mechanismService.AddAgeingMechanismDocument(ageingMechanismDocument, file);
			}

			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult ShowGeneralDocument(int id)
		{
			ViewBag.TransientId = id;
			return View();
		}

		[HttpPost]
		public IActionResult DeleteAgeingMechanismDocument(string[] generalDocumentId)
		{
			foreach (string id in generalDocumentId)
			{
				_mechanismService.DeleteAgeingMechanismDocument(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#endregion
	}
}
