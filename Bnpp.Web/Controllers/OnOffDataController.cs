using Bnpp.Core.Convertors;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.ONOFF;
using Bnpp.DataLayer.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
    public class OnOffDataController : Controller
    {
		private IMechanicalService _mechanical;
		private IChangeService _changeService;
		private IConfiguration Configuration;
		public OnOffDataController(IChangeService changeService, IConfiguration _configuration, IMechanicalService mechanical
)
		{
            _mechanical = mechanical;
			Configuration = _configuration;
			_changeService = changeService;
        }

        [BindProperty]
        public ChangeState Change { get; set; }

        [Route("OnOffData/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.MechanicalId = id;
            ViewData["States"] = _changeService.GetAllStates();
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;

			return View(_changeService.GetAllChangeState());
        }

        public IActionResult CreateOnOffData(int id)
        {
            ViewBag.MechanicalId = id;
            ViewData["States"] = _changeService.GetAllStates();
            return View();
        }

        [HttpPost]
        public IActionResult CreateOnOffData(List<int> SelectedStates, string Dateofchangestate = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            if (Dateofchangestate != "")
            {
                string[] std = Dateofchangestate.Split('/', ' ', ':');
                Change.ChangeStateDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    int.Parse(std[3]),
                    int.Parse(std[4]),
                    int.Parse(std[5]),
                    new GregorianCalendar()
                );
            }

            int changestateId = _changeService.AddChangeState(Change);

            _changeService.AddStateToStaeChanges(changestateId, SelectedStates);



            return RedirectToAction("Index");
        }

        public IActionResult EditOnOffData(int id)
        {
            ViewData["States"] = _changeService.GetAllStates();
            return View(_changeService.GetChangeStateById(id));
        }

        [HttpPost]
        public IActionResult EditOnOffData(List<int> SelectedStates, string Dateofchangestate = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            if (Dateofchangestate != "")
            {
                string[] std = Dateofchangestate.Split('/', ' ', ':');
                Change.ChangeStateDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    int.Parse(std[3]),
                    int.Parse(std[4]),
                    int.Parse(std[5]),
                    new GregorianCalendar()
                );
            }

            _changeService.UpdateChangeState(Change);

            _changeService.EDitStateToStaeChanges(Change.ChangeStateId, SelectedStates);



            return RedirectToAction("Index");
        }

        public IActionResult DeleteOnOffData(string[] operationalId)
        {
            foreach (string id in operationalId)
            {
                _changeService.DeleteChangeState(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        [HttpPost]
        public IActionResult ExportOnOffData(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _changeService.GetAllChangeStateForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "On-Off data";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "On-Off data.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<OFFViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _changeService.GetChangeStateByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "On-Off data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "On-Off data.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportOnOffData(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("ChangeStateId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.ChangeState";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                    sqlBulkCopy.ColumnMappings.Add("ChangeStateDate", "ChangeStateDate");
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
    }
}
