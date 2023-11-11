using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Bnpp.Core.Convertors;
using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Entities.Maintenance;
using Bnpp.DataLayer.Entities.OperationalDatas;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
	public class InspectionController : Controller
	{
		private IInspectionService _inspectionService;
		private IConfiguration Configuration;
		private IMechanicalService _mechanical;
		public InspectionController(IInspectionService inspectionService, IConfiguration _configuration, IMechanicalService mechanical
)
		{
			_mechanical = mechanical;
			Configuration = _configuration;
			_inspectionService = inspectionService;
		}

		[Route("Inspection/{id}")]
		public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		public IActionResult SubMenu()
		{
			return View();
		}

		#region  InspectionReports

		[BindProperty]
		public InspectionDocument Document { get; set; }


		public IActionResult InspectionReports(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllInspectionReports(id));
		}

		[HttpPost]
		public IActionResult ExportInspectionReports(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllInspectionReportsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Inspection Reports";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inspection Reports.xlsx");
					}
				}
			}
			else
			{
				var res = new List<InspectionReportsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetInspectionReportsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Inspection Reports";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inspection Reports.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportInspectionReports(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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
						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("FormName", typeof(string));
						dt.Columns.Add("FormNo", typeof(string));
						dt.Columns.Add("Description", typeof(string));
						dt.Columns.Add("InspectionImage", typeof(string));
						dt.Columns.Add("InspectionDate", typeof(DateTime));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["MechanicalId"] = mechanicalId;
							row["TypeId"] = 1;
							row["FormName"] = null;
							row["FormNo"] = null;
							row["Description"] = null;
							row["InspectionImage"] = null;
							row["InspectionDate"] = DateTime.Now;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");
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

		public IActionResult CretaeInspectionReports(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CretaeInspectionReports(IFormFile fileReports)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.AddInspectionReports(Document, fileReports);

			return new JsonResult("success");
		}

		public IActionResult EditInspectionReports(int id)
		{
			return View(_inspectionService.GetInspectionReportsById(id));
		}

		[HttpPost]
		public IActionResult EditInspectionReports(IFormFile fileReports)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.UpdateInspectionReports(Document, fileReports);

			return new JsonResult("success");
		}

		public IActionResult DeleteInspectionReports(string[] rportId)
		{
			foreach (string id in rportId)
			{
				_inspectionService.DeleteInspectionReports(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Visual Inspection Form


		public IActionResult VisualForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllVisualInspectionForm(id));
		}


		[HttpPost]
		public IActionResult ExportVisualForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllVisualInspectionFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Visual Inspection Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Visual Inspection Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetVisualInspectionFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Visual Inspection Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Visual Inspection Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportVisualForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 3;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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


		public IActionResult CreateVisualForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateVisualForm(IFormFile fileVisual, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddVisualInspectionForm(Document, fileVisual);

			return new JsonResult("success");
		}

		public IActionResult EditVisualForm(int id)
		{
			return View(_inspectionService.GetVisualInspectionFormById(id));
		}

		[HttpPost]
		public IActionResult EditVisualForm(IFormFile fileVisual, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateVisualInspectionForm(Document, fileVisual);

			return new JsonResult("success");
		}

		public IActionResult DeleteVisualForm(string[] visualformId)
		{
			foreach (string id in visualformId)
			{
				_inspectionService.DeleteVisualInspectionForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}


		#endregion

		#region Leakage Test Form

		public IActionResult LeakageForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllLeakageForm(id));
		}


		[HttpPost]
		public IActionResult ExportLeakageForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllLeakageFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Leakage Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Leakage Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetLeakageFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Leakage Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Leakage Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportLeakageForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 4;
							row["Code"] = null;
							row["DocumentName"] = null;
							row["MechanicalId"] = mechanicalId;
							row["InspectionImage"] = null;

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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CreateLeakageForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateLeakageForm(IFormFile fileLeakage, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddLeakageForm(Document, fileLeakage);

			return new JsonResult("success");
		}

		public IActionResult EditLeakageForm(int id)
		{
			return View(_inspectionService.GetLeakageFormById(id));
		}

		[HttpPost]
		public IActionResult EditLeakageForm(IFormFile fileLeakage, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateLeakageForm(Document, fileLeakage);

			return new JsonResult("success");
		}


		public IActionResult DeleteLeakageForm(string[] lekageId)
		{
			foreach (string id in lekageId)
			{
				_inspectionService.DeleteLeakageForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}
		#endregion

		#region Liquid Penetration Test Form

		public IActionResult PenetrationForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllPenetrationForm(id));
		}


		[HttpPost]
		public IActionResult ExportPenetrationForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllPenetrationFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Liquid Penetration Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liquid Penetration Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetPenetrationFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Liquid Penetration Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liquid Penetration Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportPenetrationForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 5;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CreatePenetrationForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreatePenetrationForm(IFormFile fileLiquid, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddPenetrationForm(Document, fileLiquid);

			return new JsonResult("success");
		}

		public IActionResult EditPenetrationForm(int id)
		{
			return View(_inspectionService.GetPenetrationFormById(id));
		}

		[HttpPost]
		public IActionResult EditPenetrationForm(IFormFile fileLiquid, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdatePenetrationForm(Document, fileLiquid);

			return new JsonResult("success");
		}

		public IActionResult DeletePenetrationForm(string[] liquidId)
		{
			foreach (string id in liquidId)
			{
				_inspectionService.DeletePenetrationForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Magnetic Powder Test Form

		public IActionResult MagneticForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllMagneticForm(id));
		}

		[HttpPost]
		public IActionResult ExportMagneticForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllMagneticFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Magnetic Powder Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Magnetic Powder Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetMagneticFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Magnetic Powder Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Magnetic Powder Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMagneticForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 6;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CreateMagneticForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMagneticForm(IFormFile fileMagnetic, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddMagneticForm(Document, fileMagnetic);

			return new JsonResult("success");
		}

		public IActionResult EditMagneticForm(int id)
		{
			return View(_inspectionService.GetMagneticFormById(id));
		}

		[HttpPost]
		public IActionResult EditMagneticForm(IFormFile fileMagnetic, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateMagneticForm(Document, fileMagnetic);

			return new JsonResult("success");
		}


		public IActionResult DeleteMagneticForm(string[] magnetId)
		{
			foreach (string id in magnetId)
			{
				_inspectionService.DeleteMagneticForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Radiographics Test Form

		public IActionResult RadiographicsForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllRadiographicsForm(id));
		}


		[HttpPost]
		public IActionResult ExportRadiographicsForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllRadiographicsFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Radiographics Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Radiographics Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetRadiographicsFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Radiographics Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Radiographics Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportRadiographicsForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 7;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CreateRadiographicsForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateRadiographicsForm(IFormFile fileRadiograph, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddRadiographicsForm(Document, fileRadiograph);

			return new JsonResult("success");
		}



		public IActionResult EditRadiographicsForm(int id)
		{
			return View(_inspectionService.GetRadiographicsFormById(id));
		}

		[HttpPost]
		public IActionResult EditRadiographicsForm(IFormFile fileRadiograph, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateRadiographicsForm(Document, fileRadiograph);

			return new JsonResult("success");
		}


		public IActionResult DeleteRadiographicsForm(string[] rdioId)
		{
			foreach (string id in rdioId)
			{
				_inspectionService.DeleteRadiographicsForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Ultrasonic Test Form

		public IActionResult UltrasonicForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllUltrasonicForm(id));
		}

		[HttpPost]
		public IActionResult ExportUltrasonicForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllUltrasonicFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Ultrasonic Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ultrasonic Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetUltrasonicFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Ultrasonic Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ultrasonic Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportUltrasonicForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 8;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CraeteUltrasonicForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteUltrasonicForm(IFormFile fileSonic, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddUltrasonicForm(Document, fileSonic);

			return new JsonResult("success");
		}

		public IActionResult EditUltrasonicForm(int id)
		{
			return View(_inspectionService.GetUltrasonicFormById(id));
		}

		[HttpPost]
		public IActionResult EditUltrasonicForm(IFormFile fileSonic, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateUltrasonicForm(Document, fileSonic);

			return new JsonResult("success");
		}

		public IActionResult DeleteUltrasonicForm(string[] sonicId)
		{
			foreach (string id in sonicId)
			{
				_inspectionService.DeleteUltrasonicForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Metal thickness ultrasonic Test Form

		public IActionResult MetalForm(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllMetalForm(id));
		}

		[HttpPost]
		public IActionResult ExportMetalForm(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllMetalFormForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Metal thickness Test Form";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Metal thickness ultrasonic Test Form.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualFormViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetMetalFormByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Metal thickness Test Form";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Metal thickness ultrasonic Test Form.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMetalForm(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DocumentName", typeof(string));

						dt.Columns.Add("InspectionImage", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 9;
							row["Code"] = null;
							row["DocumentName"] = null;

							row["InspectionImage"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");

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

		public IActionResult CreateMetalForm(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMetalForm(IFormFile fileMetal, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddMetalForm(Document, fileMetal);

			return new JsonResult("success");
		}



		public IActionResult EditMetalForm(int id)
		{
			return View(_inspectionService.GetMetalFormById(id));
		}

		[HttpPost]
		public IActionResult EditMetalForm(IFormFile fileMetal, string VisualDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (VisualDate != "")
			{
				string[] std = VisualDate.Split('/');
				Document.InspectionDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateMetalForm(Document, fileMetal);

			return new JsonResult("success");
		}

		public IActionResult DeleteMetalForm(string[] mtalId)
		{
			foreach (string id in mtalId)
			{
				_inspectionService.DeleteMetalForm(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}
		#endregion

		#region Inspection Instructions

		public IActionResult InspectionInstructions(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllInspectionInstructions(id));
		}

		[HttpPost]
		public IActionResult ExportInspectionInstructions(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllInspectionInstructionsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Inspection Instructions";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inspection Instructions.xlsx");
					}
				}
			}
			else
			{
				var res = new List<InspectionInstructionsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetInspectionInstructionsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Inspection Instructions";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inspection Instructions.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportInspectionInstructions(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("InspectionId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("FormName", typeof(string));
						dt.Columns.Add("FormNo", typeof(string));
						dt.Columns.Add("Description", typeof(string));
						dt.Columns.Add("InspectionImage", typeof(string));
						dt.Columns.Add("InspectionDate", typeof(DateTime));
						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
							row["MechanicalId"] = mechanicalId;
							row["TypeId"] = 2;
							row["FormName"] = null;
							row["FormNo"] = null;
							row["Description"] = null;
							row["InspectionImage"] = null;
							row["InspectionDate"] = DateTime.Now;
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
					sqlBulkCopy.DestinationTableName = "dbo.InspectionDocuments";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("FormName", "FormName");
					sqlBulkCopy.ColumnMappings.Add("FormNo", "FormNo");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("InspectionImage", "InspectionImage");
					sqlBulkCopy.ColumnMappings.Add("InspectionDate", "InspectionDate");
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

		public IActionResult CretaeInspectionInstructions(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CretaeInspectionInstructions(IFormFile fileInstructions)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.AddInspectionInstructions(Document, fileInstructions);

			return new JsonResult("success");
		}

		public IActionResult EditInspectionInstructions(int id)
		{
			return View(_inspectionService.GetInspectionInstructionsById(id));
		}

		[HttpPost]
		public IActionResult EditInspectionInstructions(IFormFile fileInstructions)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.UpdateInspectionInstructions(Document, fileInstructions);

			return new JsonResult("success");
		}

		public IActionResult DeleteInspectionInstructions(string[] instructionslId)
		{
			foreach (string id in instructionslId)
			{
				_inspectionService.DeleteInspectionInstructions(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}
		#endregion


		public IActionResult InspectionPrograms(int id)
		{
			ViewBag.MechanicalId = id;
			ViewData["TypicalDocuments"] = _inspectionService.GetAllTypicalDocument();
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAlTypicalPrograms(id));
		}



		[HttpPost]
		public IActionResult ExportInspectionPrograms(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAlTypicalProgramsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Typical Programs";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Typical Programs.xlsx");
					}
				}
			}
			else
			{
				var res = new List<TypicalProgramsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetTypicalProgramsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Typical Programs";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Typical Programs.xlsx");
					}
				}
			}

		}


		[HttpPost]
		public async Task<IActionResult> ImportInspectionPrograms(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TypicalId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.TypicalPrograms";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("TP", "TP");
					sqlBulkCopy.ColumnMappings.Add("EquipCode", "EquipCode");
					sqlBulkCopy.ColumnMappings.Add("EquipName", "EquipName");
					sqlBulkCopy.ColumnMappings.Add("TestMethod", "TestMethod");
					sqlBulkCopy.ColumnMappings.Add("TestStandard", "TestStandard");
					sqlBulkCopy.ColumnMappings.Add("ControlPercent", "ControlPercent");
					sqlBulkCopy.ColumnMappings.Add("Period", "Period");
					sqlBulkCopy.ColumnMappings.Add("WeldType", "WeldType");
					sqlBulkCopy.ColumnMappings.Add("Remarks", "Remarks");
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

		#region Visual Control
		[BindProperty]
		public TestResults Results { get; set; }

		public IActionResult InspectionResults(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllVisualControl(id));
		}


		[HttpPost]
		public IActionResult ExportVisualControl(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllVisualControlForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Visual Control";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Visual Control.xlsx");
					}
				}
			}
			else
			{
				var res = new List<VisualControlViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetVisualControlByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Visual Control";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Visual Control.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportVisualControl(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));

						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("UnitDescription", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));
                        dt.Columns.Add("MechanicalId", typeof(int));

                        foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 1;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;

							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["UnitDescription"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["PointNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;
                            row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");

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

		public IActionResult CraeteVisualControl(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteVisualControl(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddVisualControl(Results);

			return new JsonResult("success");
		}

		public IActionResult EditVisualControl(int id)
		{
			return View(_inspectionService.GetVisualControlById(id));
		}

		[HttpPost]
		public IActionResult EditVisualControl(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateVisualControl(Results);

			return new JsonResult("success");
		}


		public IActionResult DeleteVisualControl(string[] visualId)
		{
			foreach (string id in visualId)
			{
				_inspectionService.DeleteVisualControl(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region  Leakage Test

		public IActionResult LeakageTest(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllLeakageTest(id));
		}

		[HttpPost]
		public IActionResult ExportLeakageTest(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllLeakageTestForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Leakage Test of Weld";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Leakage Test of Weld.xlsx");
					}
				}
			}
			else
			{
				var res = new List<LeakageTestViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetLeakageTestByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Leakage Test of Weld";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Leakage Test of Weld.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportLeakageTest(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("WeldSize", typeof(string));
						//dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));

						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("UnitDescription", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 2;
							row["WeldSize"] = null;
							//row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;

							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["UnitDescription"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["PointNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");

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

		public IActionResult CreateLeakageTest(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateLeakageTest(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddLeakageTest(Results);

			return new JsonResult("success");
		}

		public IActionResult EditLeakageTest(int id)
		{
			return View(_inspectionService.GetLeakageTestById(id));
		}

		[HttpPost]
		public IActionResult EditLeakageTest(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateLeakageTest(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteLeakageTest(string[] leakageId)
		{
			foreach (string id in leakageId)
			{
				_inspectionService.DeleteLeakageTest(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Liquid Penetrated Test

		public IActionResult LiquidPenetrated(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllLiquidPenetrated(id));
		}

		[HttpPost]
		public IActionResult ExportLiquidPenetrated(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllLiquidPenetratedForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Liquid Penetrated Test";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liquid Penetrated Test.xlsx");
					}
				}
			}
			else
			{
				var res = new List<LiquidPenetratedTestViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetLiquidPenetratedByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Liquid Penetrated Test";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liquid Penetrated Test.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportLiquidPenetrated(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));

						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("UnitDescription", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));

						dt.Columns.Add("MechanicalId", typeof(int));
						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 3;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;

							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["UnitDescription"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["PointNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
					con.Open();
					sqlBulkCopy.WriteToServer(dt);
					con.Close();
				}
			}
			//if the code reach here means everthing goes fine and excel data is imported into database
			ViewBag.Message = "File Imported and excel data saved into database";

			////return RedirectToAction("Index", new { id = mechanicalId });
			return NoContent();
		}

		public IActionResult CreateLiquidPenetrated(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateLiquidPenetrated(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddLiquidPenetrated(Results);

			return new JsonResult("success");
		}

		public IActionResult EditLiquidPenetrated(int id)
		{
			return View(_inspectionService.GetLiquidPenetratedById(id));
		}

		[HttpPost]
		public IActionResult EditLiquidPenetrated(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateLiquidPenetrated(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteLiquidPenetrated(string[] liquidId)
		{
			foreach (string id in liquidId)
			{
				_inspectionService.DeleteLiquidPenetrated(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Magnetic Powder test

		public IActionResult MagneticPowder(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllMagneticPowder(id));
		}

		[HttpPost]
		public IActionResult ExportMagneticPowder(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllMagneticPowderForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Magnetic Powder test";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Magnetic Powder test.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MagneticPowderViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetMagneticPowderByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Magnetic Powder test";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Magnetic Powder test.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMagneticPowder(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));

						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("UnitDescription", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 4;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;

							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["UnitDescription"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["PointNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
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

		public IActionResult CreateMagneticPowder(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMagneticPowder(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddMagneticPowder(Results);

			return new JsonResult("success");
		}

		public IActionResult EditMagneticPowder(int id)
		{
			return View(_inspectionService.GetMagneticPowderById(id));
		}

		[HttpPost]
		public IActionResult EditMagneticPowder(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateMagneticPowder(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteMagneticPowder(string[] magneticId)
		{
			foreach (string id in magneticId)
			{
				_inspectionService.DeleteMagneticPowder(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Radiographics Test


		public IActionResult RadiographicsTest(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllRadiographics(id));
		}

		[HttpPost]
		public IActionResult ExportRadiographicsTest(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllRadiographicsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Radiographics Test";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Radiographics Test.xlsx");
					}
				}
			}
			else
			{
				var res = new List<RadiographicsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetRadiographicsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Radiographics Test";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Radiographics Test.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportRadiographicsTest(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("FoundDefectDescription", typeof(string));
						dt.Columns.Add("UnitDescription", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 5;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["FoundDefectDescription"] = null;
							row["UnitDescription"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["PointNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MechanicalId"] = mechanicalId;

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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
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

		public IActionResult CreateRadiographicsTest(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateRadiographicsTest(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddRadiographics(Results);

			return new JsonResult("success");
		}

		public IActionResult EditRadiographicsTest(int id)
		{
			return View(_inspectionService.GetRadiographicsById(id));
		}

		[HttpPost]
		public IActionResult EditRadiographicsTest(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateRadiographics(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteRadiographics(string[] radiograId)
		{
			foreach (string id in radiograId)
			{
				_inspectionService.DeleteRadiographics(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Ultrasonic Tests

		public IActionResult UltrasonicTests(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllUltrasonic(id));
		}

		public IActionResult ExportUltrasonicTests(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllUltrasonicForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Ultrasonic Tests";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ultrasonic Tests.xlsx");
					}
				}
			}
			else
			{
				var res = new List<UltrasonicViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetUltrasonicByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Ultrasonic Tests";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ultrasonic Tests.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportUltrasonicTests(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("WeldSize", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));

						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("PointNo", typeof(string));
						dt.Columns.Add("MeasuredThickness", typeof(string));
						dt.Columns.Add("MinimumAllowedThickness", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 6;
							row["WeldSize"] = null;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;

							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["MinimumAllowedThickness"] = null;
							row["MinimumAllowedThickness"] = null;

							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
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

		public IActionResult CreateUltrasonicTests(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateUltrasonicTests(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddUltrasonic(Results);

			return new JsonResult("success");
		}

		public IActionResult EditUltrasonicTests(int id)
		{
			return View(_inspectionService.GetUltrasonicById(id));
		}

		[HttpPost]
		public IActionResult EditUltrasonicTests(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateUltrasonic(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteUltrasonicTests(string[] sonicId)
		{
			foreach (string id in sonicId)
			{
				_inspectionService.DeleteUltrasonic(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Metal thickness ultrasonic measurement


		public IActionResult MetalThickness(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAllMetalThickness(id));
		}

		public IActionResult ExportMetalThickness(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAllMetalThicknessForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Metal thickness measurement";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Metal thickness ultrasonic measurement.xlsx");
					}
				}
			}
			else
			{
				var res = new List<MetalThicknessViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetMetalThicknessByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Metal thickness measurement";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Metal thickness ultrasonic measurement.xlsx");
					}
				}
			}

		}

		[HttpPost]
		public async Task<IActionResult> ImportMetalThickness(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("TestResultsId", typeof(int));

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

						dt.Columns.Add("TypeId", typeof(string));
						dt.Columns.Add("WeldNo", typeof(string));
						dt.Columns.Add("WeldSize", typeof(string));
						dt.Columns.Add("TestScope", typeof(string));
						dt.Columns.Add("FoundDefectDescription", typeof(string));
						dt.Columns.Add("Code", typeof(string));
						dt.Columns.Add("DimensionofWeld", typeof(string));
						dt.Columns.Add("AreaNo", typeof(string));
						dt.Columns.Add("LengthofSection", typeof(string));
						dt.Columns.Add("Sensitivity", typeof(string));
						dt.Columns.Add("RevealedDefects", typeof(string));
						dt.Columns.Add("RegisterNo", typeof(string));
						dt.Columns.Add("DimensionsofUnit", typeof(string));
						dt.Columns.Add("MaximumAllowed", typeof(string));
						dt.Columns.Add("MechanicalId", typeof(int));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;

							row["TypeId"] = 7;
							row["WeldNo"] = null;
							row["TestScope"] = null;
							row["WeldSize"] = null;
							row["FoundDefectDescription"] = null;
							row["Code"] = null;
							row["DimensionofWeld"] = null;
							row["AreaNo"] = null;
							row["LengthofSection"] = null;
							row["Sensitivity"] = null;
							row["RevealedDefects"] = null;
							row["RegisterNo"] = null;
							row["DimensionsofUnit"] = null;
							row["MaximumAllowed"] = null;
							row["MechanicalId"] = mechanicalId;
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
					sqlBulkCopy.DestinationTableName = "dbo.TestResults";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("TypeId", "TypeId");
					sqlBulkCopy.ColumnMappings.Add("NO", "NO");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("WeldSize", "WeldSize");

					sqlBulkCopy.ColumnMappings.Add("TestScope", "TestScope");
					sqlBulkCopy.ColumnMappings.Add("FoundDefectDescription", "FoundDefectDescription");
					sqlBulkCopy.ColumnMappings.Add("QualityAssessment", "QualityAssessment");
					sqlBulkCopy.ColumnMappings.Add("NooflogBook", "NooflogBook");
					sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
					sqlBulkCopy.ColumnMappings.Add("Code", "Code");
					sqlBulkCopy.ColumnMappings.Add("DimensionofWeld", "DimensionofWeld");
					sqlBulkCopy.ColumnMappings.Add("AreaNo", "AreaNo");
					sqlBulkCopy.ColumnMappings.Add("LengthofSection", "LengthofSection");
					sqlBulkCopy.ColumnMappings.Add("Sensitivity", "Sensitivity");
					sqlBulkCopy.ColumnMappings.Add("RevealedDefects", "RevealedDefects");
					sqlBulkCopy.ColumnMappings.Add("RegisterNo", "RegisterNo");
					sqlBulkCopy.ColumnMappings.Add("UnitDescription", "UnitDescription");
					sqlBulkCopy.ColumnMappings.Add("DimensionsofUnit", "DimensionsofUnit");
					sqlBulkCopy.ColumnMappings.Add("MaximumAllowed", "MaximumAllowed");
					sqlBulkCopy.ColumnMappings.Add("PointNo", "PointNo");
					sqlBulkCopy.ColumnMappings.Add("MeasuredThickness", "MeasuredThickness");
					sqlBulkCopy.ColumnMappings.Add("MinimumAllowedThickness", "MinimumAllowedThickness");
					sqlBulkCopy.ColumnMappings.Add("TestingDate", "TestingDate");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
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

		public IActionResult CreateMetalThickness(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateMetalThickness(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.AddMetalThickness(Results);

			return new JsonResult("success");
		}

		public IActionResult EditMetalThickness(int id)
		{
			return View(_inspectionService.GetMetalThicknessById(id));
		}


		[HttpPost]
		public IActionResult EditMetalThickness(string TestDate = "")
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			if (TestDate != "")
			{
				string[] std = TestDate.Split('/');
				Results.TestingDate = new DateTime(int.Parse(std[2]),
					int.Parse(std[0]),
					int.Parse(std[1]),
					new GregorianCalendar()
				);
			}

			_inspectionService.UpdateMetalThickness(Results);

			return new JsonResult("success");
		}

		public IActionResult DeleteMetalThickness(string[] thicknessId)
		{
			foreach (string id in thicknessId)
			{
				_inspectionService.DeleteMetalThickness(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region TypicalPrograms

		[BindProperty]
		public TypicalPrograms Programs { get; set; }

		public IActionResult TypicalPrograms(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		public IActionResult CreateTypicalPrograms(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateTypicalPrograms(TypicalPrograms typicalPrograms)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			_inspectionService.AddTypicalPrograms(Programs);

			return new JsonResult("success");
		}

		public IActionResult EditTypicalPrograms(int id)
		{
			return View(_inspectionService.GetTypicalProgramsById(id));
		}

		[HttpPost]
		public IActionResult EditTypicalPrograms()
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.UpdateTypicalPrograms(Programs);

			return new JsonResult("success");
		}

		public IActionResult DeletTypicalPrograms(string[] typicalsId)
		{
			foreach (string id in typicalsId)
			{
				_inspectionService.DeleteTypicalPrograms(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Working Programs

		[BindProperty]
		public WorkingPrograms Working { get; set; }


		public IActionResult WorkingPrograms(int id)
		{
			ViewBag.MechanicalId = id;
			ViewData["WorkingDocuments"] = _inspectionService.GetAllWorkingDocument();
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_inspectionService.GetAlWorkingPrograms(id));
		}


		[HttpPost]
		public IActionResult ExportWorkingPrograms(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _inspectionService.GetAlWorkingProgramsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{

					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Working Programs";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Working Programs.xlsx");
					}
				}
			}
			else
			{
				var res = new List<WorkingProgramsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _inspectionService.GetWorkingProgramsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Working Programs";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Working Programs.xlsx");
					}
				}
			}

		}


		[HttpPost]
		public async Task<IActionResult> ImportWorkingPrograms(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("WorkingId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.WorkingPrograms";

					// Map the Excel columns with that of the database table, this is optional but good if you do


					sqlBulkCopy.ColumnMappings.Add("TP", "TP");
					sqlBulkCopy.ColumnMappings.Add("WP", "WP");
					sqlBulkCopy.ColumnMappings.Add("EquipCode", "EquipCode");
					sqlBulkCopy.ColumnMappings.Add("EquipName", "EquipName");
					sqlBulkCopy.ColumnMappings.Add("MeasuringType", "MeasuringType");
					sqlBulkCopy.ColumnMappings.Add("MaterialCompositions", "MaterialCompositions");
					sqlBulkCopy.ColumnMappings.Add("WeldNo", "WeldNo");
					sqlBulkCopy.ColumnMappings.Add("ControlMethod", "ControlMethod");
					sqlBulkCopy.ColumnMappings.Add("ControlPercent", "ControlPercent");
					sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");
					sqlBulkCopy.ColumnMappings.Add("ControlStandard", "ControlStandard");
					sqlBulkCopy.ColumnMappings.Add("QCStandard", "QCStandard");
					sqlBulkCopy.ColumnMappings.Add("ControlResults", "ControlResults");
					sqlBulkCopy.ColumnMappings.Add("Remarks", "Remarks");

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

		public IActionResult CraeteWorkingPrograms(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteWorkingPrograms(WorkingPrograms workingPrograms)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			_inspectionService.AddWorkingPrograms(Working);

			return new JsonResult("success");
		}

		public IActionResult EditWorkingPrograms(int id)
		{
			return View(_inspectionService.GetWorkingProgramsById(id));
		}

		[HttpPost]
		public IActionResult EditWorkingPrograms()
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}
			_inspectionService.UpdateWorkingPrograms(Working);

			return new JsonResult("success");
		}

		public IActionResult DeletWorkingPrograms(string[] workingId)
		{
			foreach (string id in workingId)
			{
				_inspectionService.DeleteWorkingPrograms(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}


		#endregion

		#region Typical Document

		public IActionResult CreateTypicalDocument()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateTypicalDocument(IFormFile typicalyDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.AddTypicalDocument(Document, typicalyDocs);

			return new JsonResult("success");
		}

		public IActionResult EditTypicalDocument(int id)
		{
			return View(_inspectionService.GetTypicalDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditTypicalDocument(IFormFile typicalyDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.UpdateTypicalDocument(Document, typicalyDocs);

			return new JsonResult("success");
		}

		public IActionResult DeletTypicalDocument(string[] typicalsId)
		{
			foreach (string id in typicalsId)
			{
				_inspectionService.DeleteTypicalDocument(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

		#region Working Programs Document

		public IActionResult CreateWorkingDocument()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateWorkingDocument(IFormFile workingyDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.AddWorkingDocument(Document, workingyDocs);

			return new JsonResult("success");
		}

		public IActionResult EditWorkingDocument(int id)
		{
			return View(_inspectionService.GetWorkingDocumentById(id));
		}

		[HttpPost]
		public IActionResult EditWorkingDocument(IFormFile workingyDocs)
		{
			//if (!ModelState.IsValid)
			//{
			//    return View();
			//}


			_inspectionService.UpdateWorkingDocument(Document, workingyDocs);

			return new JsonResult("success");
		}

		public IActionResult DeletWorkingDocument(string[] workingsId)
		{
			foreach (string id in workingsId)
			{
				_inspectionService.DeleteWorkingDocument(Convert.ToInt32(id));
			}

			return Json(" Diesel Generators Successfully Deleted.");
		}

		#endregion

	}
}
