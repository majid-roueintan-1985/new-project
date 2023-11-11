using Bnpp.Core.Convertors;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
	public class ChemistryController : Controller
	{
		private IChemistryService _chemistryService;
		private IConfiguration Configuration;
		public ChemistryController(IChemistryService chemistryService, IConfiguration _configuration)
		{
			Configuration = _configuration;
			_chemistryService = chemistryService;
		}



		[Route("Chemistry")]
		public IActionResult Index(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string dateFrom = "", string dateTo = "")
		{
			//var systems = _chemistryService.GetSystems();
			ViewBag.System = system;
			ViewBag.SampleePoints = samplePoint;
			ViewBag.SystemState = systemState;
			ViewBag.Cycle = cycle;
			ViewBag.DateAndTime = dateAndTime;
			ViewBag.Parameters = parameter;
			ViewBag.DateFrom = dateFrom;
			ViewBag.DateTo = dateTo;


			var groups = _chemistryService.GetGroupForManageSearch();
			ViewBag.SearchSystem = new SelectList(groups, "Value", "Text");

			var subGrous = _chemistryService.GetSubGroupForManageSearch(int.Parse(groups.First().Value));
			ViewBag.SamplePoint = new SelectList(subGrous, "Value", "Text");

			var secondSubGrous = _chemistryService.GetSubGroupForManageSearch(int.Parse(subGrous.First().Value));
			ViewBag.Parameter = new SelectList(secondSubGrous, "Value", "Text");




			#region CHART


			var values = _chemistryService.GetAllValuesForChart(system, samplePoint, systemState, cycle, dateAndTime, parameter, dateFrom, dateTo).ToArray();

			List<string> chartValue = new List<string>();

			foreach (var item in values)
			{
				chartValue.Add(item.Replace("\r\n", string.Empty));
			}

			var valueChart = "[" + String.Join(",", chartValue) + "]";


			var normalValues1 = _chemistryService.GetAllNormalValues1ForChart(system, samplePoint, systemState, cycle, dateAndTime, parameter, dateFrom, dateTo).ToArray();

			List<string> chartNormalValue1 = new List<string>();

			foreach (var item in normalValues1)
			{
				chartNormalValue1.Add(item.Replace("\r\n", string.Empty));
			}

			var normalValue1Chart = "[" + String.Join(",", chartNormalValue1) + "]";



			var normalValues2 = _chemistryService.GetAllNormalValues2ForChart(system, samplePoint, systemState, cycle, dateAndTime, parameter, dateFrom, dateTo).ToArray();

			List<string> chartNormalValue2 = new List<string>();


			foreach (var item in normalValues2)
			{

				chartNormalValue2.Add(item.Replace("\r\n", string.Empty));
			}

			var normalValue2Chart = "[" + String.Join(",", chartNormalValue2) + "]";




			var date = _chemistryService.GetAllDatesForChart(system, samplePoint, systemState, cycle, dateAndTime, parameter, dateFrom, dateTo).ToArray();

			List<string> chartDate = new List<string>();
			foreach (var item in date)
			{
				chartDate.Add(item);
			}

			var dateChart = "[" + String.Join(",", chartDate) + "]";


			ViewBag.Data01 = valueChart;
			ViewBag.Data02 = normalValue1Chart;
			ViewBag.Data03 = normalValue2Chart;
			ViewBag.Data04 = dateChart;
			//ViewBag.Data01 = "[8.60,1.14,1,1,1.070,1.110,1.330,2.210,7.830,2.478]";
			//ViewBag.Data02 = "[1.6,1.7,1.7,1.9,2,2.7,4,5,6,7]";
			//ViewBag.Data03 = "[3,7,2,5,6,4,2,1,2,1]";

			#endregion

			return View(_chemistryService.GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parameter, dateFrom, dateTo));
		}


		public IActionResult GetSubGroups(int id)
		{
			List<SelectListItem> list = new List<SelectListItem>()
			{
				new SelectListItem(){Text = "Select",Value = ""}
			};
			list.AddRange(_chemistryService.GetSubGroupForManageSearch(id));
			return Json(new SelectList(list, "Value", "Text"));
		}



		public IActionResult GetSecondSubGroups(int id)
		{
			List<SelectListItem> list = new List<SelectListItem>()
			{
				new SelectListItem(){Text = "Select",Value = ""}
			};
			list.AddRange(_chemistryService.GetSubGroupForManageSearch(id));
			return Json(new SelectList(list, "Value", "Text"));
		}


		[HttpPost]
		public IActionResult Export(string reportId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _chemistryService.GetAllChemistriesForExcel().ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "Chemistry";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemistry.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ChemistryViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _chemistryService.GetChemistryTableByIdForExcel(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "Chemistry";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemistry.xlsx");
					}
				}
			}
			//return RedirectToAction("index");
		}

		[HttpPost]
		public async Task<IActionResult> ImportChemistryExcelFile(IFormFile FormFile)
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

			dt.Columns.Add("ID", typeof(int));

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

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;
						}

						connExcel.Close();
					}
				}
			}
			//your database connection string
			//conString = @"Data Source=87.236.215.209;Initial Catalog=ChemistryDB;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("ChemistryDBConnection");
			using (SqlConnection con = new SqlConnection(conString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name.
					sqlBulkCopy.DestinationTableName = "dbo.ChemistryTable";

					// Map the Excel columns with that of the database table, this is optional but good if you do



					con.Open();
					sqlBulkCopy.WriteToServer(dt);
					con.Close();
				}
			}
			//if the code reach here means everthing goes fine and excel data is imported into database
			ViewBag.Message = "File Imported and excel data saved into database";

			return RedirectToAction("Index");
			//return Json(" Electormotors Successfully Deleted.");
		}
	}
}
