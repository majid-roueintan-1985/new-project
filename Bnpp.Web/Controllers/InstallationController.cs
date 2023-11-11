using Microsoft.AspNetCore.Hosting;
using System;
using Bnpp.Core.Convertors;
using Bnpp.Core.Services;
using System.IO;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;
using System.Data;
//using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;

namespace Bnpp.Web.Controllers
{
    public class InstallationController : Controller
    {
        private ICommissioningService _commissioning;
        private IWebHostEnvironment _env;
        private IConfiguration Configuration;
        private IHostingEnvironment _hostingEnv;
		private IMechanicalService _mechanical;

		public InstallationController(ICommissioningService commissioning, IWebHostEnvironment env, IConfiguration _configuration, IHostingEnvironment hostingEnv,
IMechanicalService mechanical
)
		{
            _commissioning = commissioning;
            _env = env;
            Configuration = _configuration;
            _hostingEnv = hostingEnv;
			_mechanical = mechanical;
		}


        [BindProperty] public Commissioning Commission { get; set; }

        [Route("Installation/{id}")]
        public IActionResult Index(int id)
		{
			ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_commissioning.GetAllCommissioning(id));
        }

        public IActionResult CreateCommissioning(int id)
		{
			ViewBag.MechanicalId = id;
			return View();
        }

        [HttpPost]
        public IActionResult CreateCommissioning(Commissioning comm)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _commissioning.AddCommissioning(Commission);
            return new JsonResult("success");
        }

        public IActionResult EditCommissioning(int id)
        {
            return View(_commissioning.GetCommissioningById(id));
        }

        [HttpPost]
        public IActionResult EditCommissioning()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _commissioning.UpdateCommissioning(Commission);
            return new JsonResult("success");
        }

        public IActionResult DeleteCommissioning(string[] commissioningId)
        {
            foreach (string id in commissioningId)
            {
                _commissioning.DeleteCommissioning(Convert.ToInt32(id));
            }
            return new JsonResult("success");

        }


        #region Import Export Excel

       
        [HttpPost]
        public IActionResult ExportInstallation(string reportId,int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _commissioning.GetAllCommissioningForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Installation & Commissioning";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Installation & Commissioning.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<CommissioningViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _commissioning.GetCommissioningByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Installation & Commissioning";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Installation & Commissioning.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportInstallation(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("CommissioningId", typeof(int));

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

							row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
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
                    sqlBulkCopy.DestinationTableName = "dbo.Commissioning";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Parameter1", "Parameter1");
                    sqlBulkCopy.ColumnMappings.Add("Parameter2", "Parameter2");
                    sqlBulkCopy.ColumnMappings.Add("Parameter3", "Parameter3");
                    sqlBulkCopy.ColumnMappings.Add("Parameter4", "Parameter4");
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

			//return RedirectToAction("Index");
			return RedirectToAction("Index", new { id = mechanicalId });
			
		}

        #endregion
    }
}

