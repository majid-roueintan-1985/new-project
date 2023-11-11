using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities.BasicData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.ViewModels;
using Bnpp.Core.Convertors;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using Bnpp.DataLayer.Migrations.Transient;
using Bnpp.DataLayer.Entities.AgeingDocuments;
using Microsoft.AspNetCore.Mvc.Rendering;
//using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using Bnpp.Core.ViewModels;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Bnpp.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace Bnpp.Web.Controllers
{
	public class EventsController : Controller
	{
		private IEventService _eventService;
		private IConfiguration Configuration;
		private IMechanicalService _mechanical;

		public EventsController(IEventService eventService, IConfiguration _configuration, IMechanicalService mechanical)
		{
			_eventService = eventService;
			Configuration = _configuration;
			_mechanical = mechanical;
		}

		[BindProperty]
		public Events Events { get; set; }

		[Route("Events/{id}")]
		public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View();
		}


		public IActionResult InternalEvents(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_eventService.GetAllEvents(id));
		}

		public IActionResult ExternalEvents(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_eventService.GetAllExternalEvents(id));
		}


		[HttpPost]
		public IActionResult ExportEvents(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _eventService.GetAllEventsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{
					wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));


					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Events.xlsx");
					}
				}
			}
			else
			{
				var res = new List<InternalEventsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _eventService.GetEventsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Events.xlsx");
					}
				}
			}
			//return RedirectToAction("index");
		}

		[HttpPost]
		public async Task<IActionResult> ImportEvents(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("EventsId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.Events";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("EventsImage", "EventsImage");
					sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
					sqlBulkCopy.ColumnMappings.Add("EventName", "EventName");
					sqlBulkCopy.ColumnMappings.Add("EventLevel", "EventLevel");
					sqlBulkCopy.ColumnMappings.Add("ReportNo", "ReportNo");
					sqlBulkCopy.ColumnMappings.Add("ResponsibleUnit", "ResponsibleUnit");
					sqlBulkCopy.ColumnMappings.Add("EventLocation", "EventLocation");
					sqlBulkCopy.ColumnMappings.Add("RelatedAgeingMechanism", "RelatedAgeingMechanism");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("EventDate", "EventDate");
					sqlBulkCopy.ColumnMappings.Add("EventTime", "EventTime");
					sqlBulkCopy.ColumnMappings.Add("ReportDate", "ReportDate");
					//before
					sqlBulkCopy.ColumnMappings.Add("BeforeOperatingModes", "BeforeOperatingModes");
					sqlBulkCopy.ColumnMappings.Add("BeforeHeatPower", "BeforeHeatPower");
					sqlBulkCopy.ColumnMappings.Add("BeforeElectricalPower", "BeforeElectricalPower");
					sqlBulkCopy.ColumnMappings.Add("BeforeEffectiveWorkingDays", "BeforeEffectiveWorkingDays");
					sqlBulkCopy.ColumnMappings.Add("BeforePressureWater", "BeforePressureWater");
					sqlBulkCopy.ColumnMappings.Add("BeforePressureinFirstCircuit", "BeforePressureinFirstCircuit");
					sqlBulkCopy.ColumnMappings.Add("BeforePressureinSecondCircuit", "BeforePressureinSecondCircuit");
					sqlBulkCopy.ColumnMappings.Add("BeforeVaccuminCondensor", "BeforeVaccuminCondensor");

					//After
					sqlBulkCopy.ColumnMappings.Add("AfterOperatingModes", "AfterOperatingModes");
					sqlBulkCopy.ColumnMappings.Add("AfterHeatPower", "AfterHeatPower");
					sqlBulkCopy.ColumnMappings.Add("AfterElectricalPower", "AfterElectricalPower");
					sqlBulkCopy.ColumnMappings.Add("AfterEffectiveWorkingDays", "AfterEffectiveWorkingDays");
					sqlBulkCopy.ColumnMappings.Add("AfterPressureWater", "AfterPressureWater");
					sqlBulkCopy.ColumnMappings.Add("AfterPressureinFirstCircuit", "AfterPressureinFirstCircuit");
					sqlBulkCopy.ColumnMappings.Add("AfterPressureinSecondCircuit", "AfterPressureinSecondCircuit");
					sqlBulkCopy.ColumnMappings.Add("AfterVaccuminCondensor", "AfterVaccuminCondensor");

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

		public IActionResult CraeteEvents(int id)
		{
			ViewBag.MechanicalId = id;

			var groups = _eventService.GetRelatedAgeingMechanism();
			ViewBag.AgeingMechanism = new SelectList(groups, "Value", "Text");

			var responsibleUnit = _eventService.GetResponsibleUnit();
			ViewBag.ResponsibleUnit = new SelectList(responsibleUnit, "Value", "Text");

			return View();
		}

		[HttpPost]
		public IActionResult CraeteEvents(IFormFile fileEvents, string EventDate = "", string ReportDate = "", string EventTime = "")
		{

			if (EventDate != "")
			{
				string[] std = EventDate.Split('/', ' ');
				Events.EventDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])

				);
			}

			if (ReportDate != "")
			{
				string[] std = ReportDate.Split('/', ' ');
				Events.ReportDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])
				);
			}

			//if (EventTime != "")
			//{
			//    Events.EventTime = DateTime.Parse(EventTime);
			//}


			_eventService.AddEvents(Events, fileEvents);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult EditEvents(int id)
		{
			var groups = _eventService.GetRelatedAgeingMechanism();
			ViewBag.AgeingMechanism = new SelectList(groups, "Value", "Text");

			return View(_eventService.GetEventsById(id));
		}

		[HttpPost]
		public IActionResult EditEvents(IFormFile fileEvents, string EventDate = "", string ReportDate = "", string EventTime = "")
		{
			//if (EventDate != "")
			//{
			//    string[] std = EventDate.Split('/', ' ', ':');
			//    Events.EventDate = new DateTime(
			//        int.Parse(std[0]),
			//        int.Parse(std[1]),
			//        int.Parse(std[2]),
			//        int.Parse(std[3]),
			//        int.Parse(std[4]),
			//        int.Parse(std[5]),
			//        new GregorianCalendar()
			//    );
			//}

			if (EventDate != "")
			{
				string[] std = EventDate.Split('/', ' ');
				Events.EventDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])

				);
			}

			if (ReportDate != "")
			{
				string[] std = ReportDate.Split('/', ' ');
				Events.ReportDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])
				);
			}

			_eventService.UpdateEvents(Events, fileEvents);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteEvents(string[] eventId)
		{
			foreach (string id in eventId)
			{
				_eventService.DeleteEvents(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#region After Before

		public IActionResult BeforeStatus(int id, int mechanicalId)
		{
			ViewBag.MechanicalId = mechanicalId;
			ViewData["eventId"] = id;
			return View(_eventService.GetBeforStatusForShow(id));
		}

		[HttpPost]
		public IActionResult BeforeStatus(int id, BeforeStatusViewModel before)
		{
			_eventService.BeforeStatusEvents(before, id);
			return Json(" Electormotors Successfully Deleted.");
		}


		public IActionResult AfterStatus(int id, int mechanicalId)
		{
			ViewBag.MechanicalId = mechanicalId;
			ViewData["eventId"] = id;
			return View(_eventService.GetAfterStatusForShow(id));
		}

		[HttpPost]
		public IActionResult AfterStatus(int id, AfterStatusViewModel after)
		{
			_eventService.AfterStatusEvents(after, id);
			return Json(" Electormotors Successfully Deleted.");
		}
		#endregion

		#region External Events

		[BindProperty]
		public ExternalEvents Externals { get; set; }

		public IActionResult CraeteExternalEvents(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CraeteExternalEvents(IFormFile fileEvents, string EventDate = "", string ReportDate = "")
		{
			if (EventDate != "")
			{
				string[] std = EventDate.Split('/', ' ');
				Events.EventDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])

				);
			}

			if (ReportDate != "")
			{
				string[] std = ReportDate.Split('/', ' ');
				Events.ReportDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[1])
				);
			}


			_eventService.AddExternalEvents(Externals, fileEvents);
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult DeleteExternalEvents(string[] eventId)
		{
			foreach (string id in eventId)
			{
				_eventService.DeleteExternaEvents(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		public IActionResult EditExternalEvents(int id)
		{
			return View(_eventService.GetExternalEventsById(id));
		}

		[HttpPost]
		public IActionResult EditExternalEvents(IFormFile fileEvents, string EventDate = "", string ReportDate = "")
		{
			if (EventDate != "")
			{
				string[] std = EventDate.Split('/', ' ');
				Events.EventDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[2])

				);
			}

			if (ReportDate != "")
			{
				string[] std = ReportDate.Split('/', ' ');
				Events.ReportDate = new DateTime(
					int.Parse(std[0]),
					int.Parse(std[1]),
					int.Parse(std[1])
				);
			}


			_eventService.UpdateExternalEvents(Externals, fileEvents);
			return Json(" Electormotors Successfully Deleted.");
		}



		[HttpPost]
		public IActionResult ExportExternalEvents(string reportId, int mechanicalId)
		{
			if (reportId == null)
			{
				var chemistryDocument = _eventService.GetAllExternalEventsForExport(mechanicalId).ToList();
				using (XLWorkbook wb = new XLWorkbook())
				{
					wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));


					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);
						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "External Events.xlsx");
					}
				}
			}
			else
			{
				var res = new List<ExternalEventsViewModel>();

				string[] std = reportId.Split(',');

				foreach (string id in std)
				{
					var chemistryDocument = _eventService.GetExternalEventsByIdForExport(Convert.ToInt32(id));
					res.Add(chemistryDocument);
				}

				using (XLWorkbook wb = new XLWorkbook())
				{
					wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
					using (MemoryStream stream = new MemoryStream())
					{
						wb.SaveAs(stream);

						return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "External Events.xlsx");
					}
				}
			}
			//return RedirectToAction("index");
		}

		[HttpPost]
		public async Task<IActionResult> ImportExternalEvents(IFormFile FormFile, int mechanicalId)
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

			dt.Columns.Add("ExternalEventsId", typeof(int));

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
					sqlBulkCopy.DestinationTableName = "dbo.ExternalEvents";

					// Map the Excel columns with that of the database table, this is optional but good if you do

					sqlBulkCopy.ColumnMappings.Add("NPPName", "NPPName");
					sqlBulkCopy.ColumnMappings.Add("ReactorType", "ReactorType");
					sqlBulkCopy.ColumnMappings.Add("ReportCode", "ReportCode");
					sqlBulkCopy.ColumnMappings.Add("EventName", "EventName");
					sqlBulkCopy.ColumnMappings.Add("EventDate", "EventDate");
					sqlBulkCopy.ColumnMappings.Add("ReportDate", "ReportDate");
					sqlBulkCopy.ColumnMappings.Add("RelatedAgeingMechanism", "RelatedAgeingMechanism");
					sqlBulkCopy.ColumnMappings.Add("Description", "Description");
					sqlBulkCopy.ColumnMappings.Add("EventsImage", "EventsImage");
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
		#endregion

		#region Related Ageing Mechanism

		[BindProperty]
		public RelatedAgeingMechanism GetAgeingMechanism { get; set; }

		public IActionResult RelatedAgeingMechanism()
		{
			return View(_eventService.GetAllRelatedAgeingMechanism());
		}

		public IActionResult CreateRelatedAgeingMechanism()
		{
			return View();
		}


		[HttpPost]
		public IActionResult CreateRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism)
		{
			_eventService.AddRelatedAgeingMechanism(GetAgeingMechanism);
			return Json(" Electormotors Successfully Deleted.");
		}



		public IActionResult DeleteAgeingMechanism(string[] mechanismId)
		{
			foreach (string id in mechanismId)
			{
				_eventService.DeleteAgeingMechanism(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		public IActionResult EditRelatedAgeingMechanism(int id)
		{
			return View(_eventService.GetRelatedAgeingMechanismById(id));
		}


		[HttpPost]
		public IActionResult EditRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism)
		{
			_eventService.UpdateRelatedAgeingMechanism(GetAgeingMechanism);
			return Json(" Electormotors Successfully Deleted.");
		}
		#endregion


		#region Responsible Unit

		[BindProperty]
		public ResponsibleUnit GetResponsibleUnit { get; set; }

		public IActionResult ResponsibleUnit()
		{
			return View(_eventService.GetAllResponsibleUnit());
		}


		public IActionResult CreateResponsibleUnit()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateResponsibleUnit(ResponsibleUnit unit)
		{
			_eventService.AddResponsibleUnit(GetResponsibleUnit);
			return Json(" Electormotors Successfully Deleted.");
		}


		public IActionResult EditResponsibleUnit(int id)
		{
			return View(_eventService.GetResponsibleUnitById(id));
		}

		[HttpPost]
		public IActionResult EditResponsibleUnit()
		{
			_eventService.UpdateResponsibleUnit(GetResponsibleUnit);
			return Json(" Electormotors Successfully Deleted.");
		}



		public IActionResult DeleteResponsibleUnit(string[] responsibleId)
		{
			foreach (string id in responsibleId)
			{
				_eventService.DeleteResponsibleUnit(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#endregion
	}
}

