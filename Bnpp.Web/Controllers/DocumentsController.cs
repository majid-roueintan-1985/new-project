using System;
using Bnpp.Core.Convertors;
using System.IO;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities.AgeingDocuments;
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
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
	public class DocumentsController : Controller
	{
		private IDocumentService _document;
		private IConfiguration Configuration;
		private IMechanicalService _mechanical;
		public DocumentsController(IDocumentService document, IConfiguration _configuration, IMechanicalService mechanical)
		{
			Configuration = _configuration;
			_document = document;
			_mechanical = mechanical;
		}

		[Route("Documents/{id}")]
		public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		#region Operational Documents

		[BindProperty]
		public OperationalDocuments Documents { get; set; }


		public IActionResult OperationalDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllOperationalDocuments(id));
		}

		[HttpPost]
		public IActionResult ExportOperationalDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllOperationalDocumentsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Operational Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Operational Documents.xlsx");
					}
				}
			}
			else
			{
				var res = new List<OperationalDocumentsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetOperationalDocumentsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Operational Documents";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Operational Documents.xlsx");
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
					sqlBulkCopy.DestinationTableName = "dbo.OperationalDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("OperationalImage", "OperationalImage");
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

			return RedirectToAction("Index", new { id = mechanicalId });
			//return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult CreateOperationalDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateOperationalDocuments(IFormFile fileDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddOperationalDocuments(Documents, fileDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditOperationalDocuments(int id)
		{
			return View(_document.GetOperationalDocumentsById(id));
		}

		[HttpPost]
		public IActionResult EditOperationalDocuments(IFormFile fileDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateOperationalDocuments(Documents, fileDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteOperationalDocument(string[] operationalId)
		{
			foreach (string id in operationalId)
			{
				_document.DeleteOperationalDocuments(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Drawing

		[BindProperty] public Drawing Drawings { get; set; }

		public IActionResult Drawing(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllDrawing(id));
		}


		[HttpPost]
		public IActionResult ExportDrawing(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllDrawingForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Drawing";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Drawing.xlsx");
					}
				}
			}
			else
			{
				var res = new List<DrawingViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetDrawingByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Drawing";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Drawing.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportDrawing(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("DrawingId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Drawing";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("DrawingImage", "DrawingImage");
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

		public IActionResult CraeteDrawing(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}


		[HttpPost]
		public IActionResult CraeteDrawing(IFormFile drawingDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddDrawing(Drawings, drawingDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditDrawings(int id)
		{
			return View(_document.GetDrawingById(id));
		}

		[HttpPost]
		public IActionResult EditDrawings(IFormFile drawingDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateDrawing(Drawings, drawingDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteDrawing(string[] drawingsId)
		{
			foreach (string id in drawingsId)
			{
				_document.DeleteDrawing(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Standards

		[BindProperty]
		public Standard Standard { get; set; }


		public IActionResult Standards(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllStandard(id));
		}



		[HttpPost]
		public IActionResult ExportStandards(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllStandardForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Standards";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Standards.xlsx");
					}
				}
			}
			else
			{
				var res = new List<StandardViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetimgStandardByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Standards";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Standards.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportStandards(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("StandardId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Standard";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("StandardImage", "StandardImage");
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

		public IActionResult CraeteStandards(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteStandards(IFormFile standardDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddStandard(Standard, standardDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditStandard(int id)
		{
			return View(_document.GetimgStandardById(id));
		}

		[HttpPost]
		public IActionResult EditStandard(IFormFile standardDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateimgStandard(Standard, standardDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteStandard(string[] standardId)
		{
			foreach (string id in standardId)
			{
				_document.DeleteimgStandard(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region  Manufacturer

		[BindProperty] public Manufacturer Manufacturer { get; set; }


		public IActionResult ManufacturerDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllManufacturer(id));
		}



		[HttpPost]
		public IActionResult ExportManufacturerDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllManufacturerForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Manufacturer Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Manufacturer Documents.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ManufacturerViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetManufacturerByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Manufacturer Documents";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Manufacturer Documents.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportManufacturerDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("ManufacturerId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Manufacturers";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("ManufacturerImage", "ManufacturerImage");
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

		public IActionResult CreateManufacturerDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}


		[HttpPost]
		public IActionResult CreateManufacturerDocuments(IFormFile ManufacturDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddManufacturer(Manufacturer, ManufacturDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditManufacturer(int id)
		{
			return View(_document.GetManufacturerById(id));
		}

		[HttpPost]
		public IActionResult EditManufacturer(IFormFile ManufacturDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateManufacturer(Manufacturer, ManufacturDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteManufacturers(string[] manufacturerId)
		{
			foreach (string id in manufacturerId)
			{
				_document.DeleteManufacturer(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region InstallationDocuments
		[BindProperty] public Installation Installation { get; set; }


		public IActionResult InstallationDocuments(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllInstallation(id));
		}



		[HttpPost]
		public IActionResult ExportInstallationDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllInstallationForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Installation Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Installation Documents.xlsx");
					}
				}
			}
			else
			{
				var res = new List<InstallationViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetInstallationByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Installation Documents";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Installation Documents.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportInstallationDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InstallationId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Installation";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("InstallationImage", "InstallationImage");
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

		public IActionResult CraeteInstallationDocuments(int id)
        {
            ViewBag.MechanicalId = id;

            return View();
		}

		[HttpPost]
		public IActionResult CraeteInstallationDocuments(IFormFile instalationDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddInstallation(Installation, instalationDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditInstallationDocuments(int id)
		{
			return View(_document.GetInstallationById(id));
		}

		[HttpPost]
		public IActionResult EditInstallationDocuments(IFormFile instalationDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateInstallation(Installation, instalationDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteInstallationDocuments(string[] instalationId)
		{
			foreach (string id in instalationId)
			{
				_document.DeleteInstallation(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion

		#region Maintenance Documents
		[BindProperty] public MaintenanceDocument Maintenance { get; set; }


		public IActionResult MaintenanceDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllMaintenanceDocument(id));
		}


		[HttpPost]
		public IActionResult ExportMaintenanceDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllMaintenanceDocumentForEXport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Maintenance Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Documents.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MaintenanceDocumentViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetMaintenanceDocumentByIdForEXport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Maintenance Documents";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Documents.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMaintenanceDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("MaintenanceId", typeof(int));

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
			////conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.MaintenanceDocument";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("MaintenanceImage", "MaintenanceImage");
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

		public IActionResult CreateMaintenanceDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMaintenanceDocuments(IFormFile maintenanceDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddMaintenanceDocument(Maintenance, maintenanceDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditMaintenanceDocuments(int id)
		{
			return View(_document.GetMaintenanceDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditMaintenanceDocuments(IFormFile maintenanceDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateMaintenanceDocument(Maintenance, maintenanceDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteMaintenanceDocuments(string[] maintenanceId)
		{
			foreach (string id in maintenanceId)
			{
				_document.DeleteMaintenanceDocument(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#endregion

		#region AgeingDocuments
		[BindProperty]
		public Ageing Ageing { get; set; }


		public IActionResult AgeingDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_document.GetAllAgeing(id));
		}




		[HttpPost]
		public IActionResult ExportAgeingDocuments(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _document.GetAllAgeingForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Ageing Documents";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Documents.xlsx");
					}
				}
			}
			else
			{
				var res = new List<AgeingViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _document.GetAgeingByIdForExport(Convert.ToInt32(id));
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
		public async Task<IActionResult> ImportAgeingDocuments(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("AgeingId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Ageing";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("AgeingImage", "AgeingImage");
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

        public IActionResult CreateAgeingDocuments(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateAgeingDocuments(IFormFile ageingDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.AddAgeing(Ageing, ageingDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditAgeingDocuments(int id)
		{
			return View(_document.GetAgeingById(id));
		}

		[HttpPost]
		public IActionResult EditAgeingDocuments(IFormFile ageingDocuments)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}

			_document.UpdateAgeing(Ageing, ageingDocuments);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteAgeingDocuments(string[] ageingId)
		{
			foreach (string id in ageingId)
			{
				_document.DeleteAgeing(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}
		#endregion
	}
}
