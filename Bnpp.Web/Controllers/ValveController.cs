using System;
using Bnpp.Core.Convertors;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.Electrical;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
	public class ValveController : Controller
	{
		private IElectricalService _electrical;
		private IConfiguration Configuration;
		public ValveController(IElectricalService electrical, IConfiguration _configuration)
		{
			Configuration = _configuration;
			_electrical = electrical;
		}

		[Route("Valves")]
		public IActionResult Index()
		{
			return View(_electrical.GetAllValves());
		}

		public IActionResult CreateNewValve()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateNewValve(ValvesListViewModel valve)
		{
			if (!ModelState.IsValid)
			{
				return View(valve);
			}

			ElectroValve electro = new ElectroValve()
			{
				Name = valve.Name,
				Position = valve.InstalationPosition,
				Azk = valve.Azk,
				CreateDate = DateTime.Now,
			};
			_electrical.AddValve(electro);

			return RedirectToAction("Index");
		}

		public IActionResult EditValve(int id)
		{
			return View(_electrical.GetValveById(id));
		}

		[HttpPost]
		public IActionResult EditValve(ElectroValve valve)
		{
			if (!ModelState.IsValid)
			{
				return View(valve);
			}
			_electrical.UpdateValve(valve);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteValve(string[] valveId)
		{
			foreach (string id in valveId)
			{
				_electrical.DeleteValve(Convert.ToInt32(id));
			}

			return Json(" Valves Successfully Deleted.");
		}

		[HttpPost]
		public IActionResult ExportValve(string reportId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _electrical.GetAllValvesForExport().ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
					ws.Name = "ElectroValves";

					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ElectroValves.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ValvesExportViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _electrical.GetValveByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					ws.Name = "ElectroValves";
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ElectroValves.xlsx");
					}
				}
			}
			//return RedirectToAction("index");
		}

		[HttpPost]
		public async Task<IActionResult> ImportValveExcelFile(IFormFile FormFile)
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

			dt.Columns.Add("ValveId", typeof(int));

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

						dt.Columns.Add("Station1", typeof(string));
						dt.Columns.Add("Station2", typeof(string));
						dt.Columns.Add("Type", typeof(string));
						dt.Columns.Add("Position", typeof(string));
						dt.Columns.Add("AzkStruct", typeof(string));
						dt.Columns.Add("ValveImage", typeof(string));
						dt.Columns.Add("BasicImage", typeof(string));

						foreach (DataRow row in dt.Rows)
						{
							// Where I tried to add new value to the column.

							row["CreateDate"] = DateTime.Now;
							row["IsDelete"] = false;


							row["Station1"] = null;
							row["Station2"] = null;
							row["Type"] = null;
							row["Position"] = null;
							row["AzkStruct"] = null;
							row["ValveImage"] = null;
							row["BasicImage"] = null;

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
					sqlBulkCopy.DestinationTableName = "dbo.ElectroValves";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("Name", "Name");
					sqlBulkCopy.ColumnMappings.Add("Azk", "Azk");
					sqlBulkCopy.ColumnMappings.Add("Station1", "Station1");
					sqlBulkCopy.ColumnMappings.Add("Station2", "Station2");
					sqlBulkCopy.ColumnMappings.Add("Type", "Type");
					sqlBulkCopy.ColumnMappings.Add("InstalationPosition", "Position");
					sqlBulkCopy.ColumnMappings.Add("AzkStruct", "AzkStruct");
					sqlBulkCopy.ColumnMappings.Add("ValveImage", "ValveImage");
					sqlBulkCopy.ColumnMappings.Add("BasicImage", "BasicImage");


					sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
					sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

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
