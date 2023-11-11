using System;
using System.Globalization;
using Bnpp.Core.Convertors;
using System.IO;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities.AgeingManagementDocuments;
using Bnpp.DataLayer.Entities.OperationalDatas;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Bnpp.Core.Services;
using Bnpp.Core.ViewModels;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bnpp.Web.Controllers
{
    public class ManagementDocumentsController : Controller
    {
        private IManagementServise _management;
		private IConfiguration Configuration;
		public ManagementDocumentsController(IManagementServise management, IConfiguration _configuration)
        {
			Configuration = _configuration;
			_management = management;
        }


        [Route("ManagementDocuments")]
        public IActionResult Index(int SuccessImport)
        {
            ViewBag.SuccessImport = SuccessImport;
            return View();
        }


        #region Methodology
        [BindProperty]
        public Methodology Methodologies { get; set; }

        public IActionResult Methodology()
        {
            return View(_management.GetAllMethodolgies());
        }



        [HttpPost]
        public IActionResult ExportMethodology(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _management.GetAllMethodolgiesForExport().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Methodology (TLAA)";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Methodology.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<MethodologyViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _management.GetMethodolgyByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Methodology (TLAA)";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Methodology.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportMethodology(IFormFile FormFile)
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

            dt.Columns.Add("MethodologyId", typeof(int));

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
            //conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.Methodologies";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("MethodologyImage", "MethodologyImage");
                    sqlBulkCopy.ColumnMappings.Add("Code", "Code");
                    sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
                    sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");





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
           
        }

        public IActionResult CreateMethodology()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMethodology(IFormFile filemetholody)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _management.AddMethodology(Methodologies, filemetholody);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditMethodology(int id)
        {
            return View(_management.GetMethodolgyById(id));
        }

        [HttpPost]
        public IActionResult EditMethodology(IFormFile filemetholody)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _management.UpdateMethodolgy(Methodologies, filemetholody);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteMethodology(string[] methodolgyId)
        {
            foreach (string id in methodolgyId)
            {
                _management.DeleteMethodolgy(Convert.ToInt32(id));
            }

            return Json(" Equipments Successfully Deleted.");
        }

        #endregion



        #region Documents

        [BindProperty]
        public AgeingDocuments Documents { get; set; }

        public IActionResult OtherDocuments()
        {
            return View(_management.GetAllAgeingDocuments());
        }

       

        [HttpPost]
        public IActionResult ExportOtherDocuments(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _management.GetAllAgeingDocumentsForExport().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Other Documents";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Other Documents.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<AgeingDocumentsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _management.GetAgeingDocumentsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Methodology (TLAA)";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Other Documents.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportOtherDocuments(IFormFile FormFile)
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

            dt.Columns.Add("AgeingDocumentsId", typeof(int));

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
            //conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.AgeingDocuments";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("AgeingImage", "AgeingImage");
                    sqlBulkCopy.ColumnMappings.Add("Code", "Code");
                    sqlBulkCopy.ColumnMappings.Add("DocumentName", "DocumentName");
                    sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");

                    sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
                    sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
            //if the code reach here means everthing goes fine and excel data is imported into database
            ViewBag.Message = "File Imported and excel data saved into database";

            //ViewBag.Majid = "showPage2()";

            //return null;
            //return RedirectToAction("OtherDocuments");
            //return Redirect("/ManagementDocuments?SuccessImport=2");
            //return new EmptyResult();
            //return new JsonResult("success");
            return RedirectToAction("Index");
        }


        public IActionResult CreateAgeingDocuments()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateAgeingDocuments(IFormFile filedocument)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _management.AddAgeingDocuments(Documents, filedocument);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditAgeingDocuments(int id)
        {
            return View(_management.GetAgeingDocumentsById(id));
        }


        [HttpPost]
        public IActionResult EditAgeingDocuments(IFormFile filedocument)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _management.UpdateAgeingDocuments(Documents, filedocument);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteDocuments(string[] documentId)
        {
            foreach (string id in documentId)
            {
                _management.DeleteimgAgeingDocuments(Convert.ToInt32(id));
            }

            return Json(" Equipments Successfully Deleted.");
        }

        #endregion


        #region ManagementReviews
        [BindProperty]
        public ManagementReviews Reviews { get; set; }

        public IActionResult ManagementReviews()
        {
            return View(_management.GetAllManagementReviews());
        }

       

        [HttpPost]
        public IActionResult ExportManagementReviews(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _management.GetAllManagementReviewsForExport().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Ageing Management Reviews (AMR)";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Management Reviews (AMR).xlsx");
                    }
                }
            }
            else
            {
                var res = new List<ManagementReviewsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _management.GetManagementReviewsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Ageing Management Reviews (AMR)";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ageing Management Reviews (AMR).xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportManagementReviews(IFormFile FormFile)
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

            dt.Columns.Add("ReviewsId", typeof(int));

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
            //conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.ManagementReviews";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Type", "Type");
                    sqlBulkCopy.ColumnMappings.Add("Frequency", "Frequency");
                    sqlBulkCopy.ColumnMappings.Add("Prepared", "Prepared");
                    sqlBulkCopy.ColumnMappings.Add("Authorized", "Authorized");
                    sqlBulkCopy.ColumnMappings.Add("Approved", "Approved");
                    sqlBulkCopy.ColumnMappings.Add("Date", "Date");

                    sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
                    sqlBulkCopy.ColumnMappings.Add("IsDelete", "IsDelete");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
            //if the code reach here means everthing goes fine and excel data is imported into database
            ViewBag.Message = "File Imported and excel data saved into database";

            return NoContent();
            //return RedirectToAction("Index");
            //return Redirect("/ManagementDocuments?SuccessImport=3");
        }
        public IActionResult CreateManagementReviews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateManagementReviews(string StartDates = "")
        {
            if (StartDates != "")
            {
                string[] std = StartDates.Split('/');
                Reviews.Date = new DateTime(int.Parse(std[2]),
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    new GregorianCalendar()
                );
            }


            _management.AddManagementReviews(Reviews);

            return new JsonResult("success");
        }

        public IActionResult EditManagementReviews(int id)
        {
            return View(_management.GetManagementReviewsById(id));
        }

        [HttpPost]
        public IActionResult EditManagementReviews(string StartDates = "")
        {
            if (StartDates != "")
            {
                string[] std = StartDates.Split('/');
                Reviews.Date = new DateTime(int.Parse(std[2]),
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    new GregorianCalendar()
                );
            }

            _management.UpdateManagementReviews(Reviews);
            return new JsonResult("success");
        }

        public IActionResult DeleteManagementReviews(string[] reviewsId)
        {
            foreach (string id in reviewsId)
            {
                _management.DeleteManagementReviews(Convert.ToInt32(id));
            }

            return Json(" Equipments Successfully Deleted.");
        }
        #endregion
    }
}
