using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.Convertors;
using Bnpp.DataLayer.Entities.BasicData;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Bnpp.Core.ViewModels;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Office2010.Excel;
using Bnpp.Core.Services;
using Bnpp.DataLayer.Migrations.Transient;
using Bnpp.DataLayer.Entities.InspectionData;

namespace Bnpp.Web.Controllers
{
    public class TechnicalController : Controller
    {
        private IBasicDataService _dataService;
        private IConfiguration Configuration;
        private IMechanicalService _mechanical;
        public TechnicalController(IBasicDataService dataService, IConfiguration _configuration, IMechanicalService mechanical)
        {
            _mechanical = mechanical;
            Configuration = _configuration;
            _dataService = dataService;
        }

        [Route("Technical/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        #region General Data

        [BindProperty]
        public GeneralData data { get; set; }


        public IActionResult GeneralData(int id)
        {
            ViewBag.MechanicalId = id;
            ViewBag.GeneralDataDocument = _dataService.GetAllGeneralDataDocument(id);
            ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;

            return View(_dataService.GetAllGeneralData(id));
        }

        public IActionResult CreateGeneralData(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateGeneralData(GeneralData generalData)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddGeneralData(data);
            return new JsonResult("success");
        }

        public IActionResult EditGeneralData(int id)
        {
            return View(_dataService.GetGeneralDataById(id));
        }

        [HttpPost]
        public IActionResult EditGeneralData()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateGeneralData(data);
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult DeleteGeneralData(string[] generalId)
        {
            foreach (string id in generalId)
            {
                _dataService.DeleteGeneralData(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportGeneralData(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllGeneralDataForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "General Data";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "General Data.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<GeneralDataViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetGeneralDataByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "General Data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "General Data.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportGeneralData(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("GeneralId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.GeneralData";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("DesignationOfParameters", "DesignationOfParameters");
                    sqlBulkCopy.ColumnMappings.Add("Value", "Value");

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
        #endregion

        #region Design Data

        [BindProperty]
        public DesignData DesignDatas { get; set; }

        public IActionResult DesignData(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllDesignData(id));
        }

        [HttpPost]
        public IActionResult ExportDesignData(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllDesignDataForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Design Data";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Design Data.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<DesignDataViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetDesignDataByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Design Data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Design Data.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportDesignData(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("DesignId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.DesignData";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("ParameterName", "ParameterName");
                    sqlBulkCopy.ColumnMappings.Add("unit", "unit");
                    sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                    sqlBulkCopy.ColumnMappings.Add("Value", "Value");
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

        public IActionResult CreateDesignData(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateDesignData(DesignData design)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddDesignData(DesignDatas);
            return new JsonResult("success");
        }

        public IActionResult EditDesignData(int id)
        {
            return View(_dataService.GetDesignDataById(id));
        }

        [HttpPost]
        public IActionResult EditDesignData()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateDesignData(DesignDatas);
            return new JsonResult("success");
        }

        public IActionResult DleteDesignData(string[] designId)
        {
            foreach (string id in designId)
            {
                _dataService.DeleteDesignData(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }
        #endregion

        #region Documents
        [BindProperty] public DesignDocument Document { get; set; }

        public IActionResult Documents(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllDesignDocument(id));
        }

        public IActionResult CreateDesignDocument(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateDesignDocument(IFormFile fileDocument)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.AddDesignDocument(Document, fileDocument);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditDesignDocument(int id)
        {
            return View(_dataService.GetDesignDocumentById(id));
        }


        [HttpPost]
        public IActionResult EditDesignDocument(IFormFile fileDocument)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.UpdateDesignDocument(Document, fileDocument);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteDesignDocument(string[] documentId)
        {
            foreach (string id in documentId)
            {
                _dataService.DeleteDesignDocument(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportDocument(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllDesignDocumentForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Documents";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Documents.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<DocumentsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetDesignDocumentByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Documents";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Documents.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportDocument(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("GeneralId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.DesignDocuments";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("DesignDocumentImage", "DesignDocumentImage");
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
        #endregion

        #region Safety


        [BindProperty]
        public SeismicCategory Category { get; set; }

        public IActionResult Safety(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllSeismicCategory(id));
        }


        public IActionResult CreateSafety(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSafety()
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.AddSeismicCategory(Category);
            return Json(" Electormotors Successfully Deleted.");
        }

        [HttpPost]
        public IActionResult ExportSafety(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllSeismicCategoryForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Safety class & Seismic";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Safety class & Seismic.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<SeismicCategoryViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetSeismicCategoryByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Safety class & Seismic";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Safety class & Seismic.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportSafety(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("CategoryId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.SeismicCategory";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("NameAndDesignation", "NameAndDesignation");
                    sqlBulkCopy.ColumnMappings.Add("SafetyClass", "SafetyClass");
                    sqlBulkCopy.ColumnMappings.Add("ClassificationDesignation", "ClassificationDesignation");
                    sqlBulkCopy.ColumnMappings.Add("CategoryGroup", "CategoryGroup");
                    sqlBulkCopy.ColumnMappings.Add("CategorySeismic", "CategorySeismic");

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

        public IActionResult EditSafety(int id)
        {
            return View(_dataService.GetSeismicCategoryById(id));
        }

        [HttpPost]
        public IActionResult EditSafety()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateSeismicCategory(Category);
            return new JsonResult("success");
        }

        public IActionResult DeleteSafety(string[] safetyId)
        {
            foreach (string id in safetyId)
            {
                _dataService.DeleteSeismicCategory(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Components

        [BindProperty]
        public Components Component { get; set; }

        public IActionResult Components(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllComponents(id));
        }


        public IActionResult CreateComponents(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateComponents(IFormFile fileComponents, string TimesOfHeating = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            if (TimesOfHeating != null)
            {
                string[] std = TimesOfHeating.Split('/', ' ', ':');
                Component.TimesOfHeating = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    int.Parse(std[3]),
                    int.Parse(std[4]),
                    int.Parse(std[5]),
                    new GregorianCalendar()
                );
            }

            _dataService.AddComponents(Component, fileComponents);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditComponents(int id)
        {
            return View(_dataService.GetComponentsById(id));
        }

        [HttpPost]
        public IActionResult EditComponents(IFormFile fileComponents)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.UpdateComponents(Component, fileComponents);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteComponents(string[] componentsId)
        {
            foreach (string id in componentsId)
            {
                _dataService.DeleteComponents(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportComponents(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllComponentsForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Safety class & Seismic";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Components.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<ComponentsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetComponentsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Safety class & Seismic";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Components.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportComponents(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("ComponentId", typeof(int));

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
                        dt.Columns.Add("ComponentsImage", typeof(string));
                        dt.Columns.Add("MechanicalId", typeof(int));
                        foreach (DataRow row in dt.Rows)
                        {
                            // Where I tried to add new value to the column.
                            row["MechanicalId"] = mechanicalId;
                            row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
                            row["ComponentsImage"] = null;
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
                    sqlBulkCopy.DestinationTableName = "dbo.Components";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Item", "Item");
                    sqlBulkCopy.ColumnMappings.Add("Designation", "Designation");
                    sqlBulkCopy.ColumnMappings.Add("Serial", "Serial");
                    sqlBulkCopy.ColumnMappings.Add("Diameter", "Diameter");
                    sqlBulkCopy.ColumnMappings.Add("Thickness", "Thickness");
                    sqlBulkCopy.ColumnMappings.Add("Length", "Length");
                    sqlBulkCopy.ColumnMappings.Add("MaterialGrade", "MaterialGrade");
                    sqlBulkCopy.ColumnMappings.Add("ClassofSafety", "ClassofSafety");
                    sqlBulkCopy.ColumnMappings.Add("ClassificationDesignation", "ClassificationDesignation");
                    sqlBulkCopy.ColumnMappings.Add("Group", "Group");
                    sqlBulkCopy.ColumnMappings.Add("SeismicCategory", "SeismicCategory");
                    //sqlBulkCopy.ColumnMappings.Add("ComponentsImage", "ComponentsImage");
                    sqlBulkCopy.ColumnMappings.Add("Filename", "Filename");
                    sqlBulkCopy.ColumnMappings.Add("MechanicalId", "MechanicalId");

                    //MechanicalProperties
                    sqlBulkCopy.ColumnMappings.Add("MechanicalTemperature", "MechanicalTemperature");
                    sqlBulkCopy.ColumnMappings.Add("YoungModule", "YoungModule");
                    sqlBulkCopy.ColumnMappings.Add("YieldStrength", "YieldStrength");
                    sqlBulkCopy.ColumnMappings.Add("UltimateStrength", "UltimateStrength");
                    sqlBulkCopy.ColumnMappings.Add("SpecificElongation", "SpecificElongation");
                    sqlBulkCopy.ColumnMappings.Add("ReductionArea", "ReductionArea");
                    sqlBulkCopy.ColumnMappings.Add("ImpactToughness", "ImpactToughness");
                    sqlBulkCopy.ColumnMappings.Add("Hardness", "Hardness");

                    //PhysicalProperties
                    sqlBulkCopy.ColumnMappings.Add("PhysicalTemperature", "PhysicalTemperature");
                    sqlBulkCopy.ColumnMappings.Add("LinearExpension", "LinearExpension");
                    sqlBulkCopy.ColumnMappings.Add("HeatCapacity", "HeatCapacity");
                    sqlBulkCopy.ColumnMappings.Add("ConductivityFactor", "ConductivityFactor");
                    sqlBulkCopy.ColumnMappings.Add("NormalRadiation", "NormalRadiation");
                    sqlBulkCopy.ColumnMappings.Add("PoissonRatio", "PoissonRatio");
                    sqlBulkCopy.ColumnMappings.Add("Density", "Density");

                    //Chemical Component
                    sqlBulkCopy.ColumnMappings.Add("C", "C");
                    sqlBulkCopy.ColumnMappings.Add("Si", "Si");
                    sqlBulkCopy.ColumnMappings.Add("Mn", "Mn");
                    sqlBulkCopy.ColumnMappings.Add("Cr", "Cr");
                    sqlBulkCopy.ColumnMappings.Add("Ni", "Ni");
                    sqlBulkCopy.ColumnMappings.Add("Mo", "Mo");
                    sqlBulkCopy.ColumnMappings.Add("V", "V");
                    sqlBulkCopy.ColumnMappings.Add("Ti", "Ti");
                    sqlBulkCopy.ColumnMappings.Add("Cu", "Cu");
                    sqlBulkCopy.ColumnMappings.Add("S", "S");
                    sqlBulkCopy.ColumnMappings.Add("P", "P");
                    sqlBulkCopy.ColumnMappings.Add("As", "As");
                    sqlBulkCopy.ColumnMappings.Add("Co", "Co");
                    sqlBulkCopy.ColumnMappings.Add("NB", "NB");

                    //HeatOperation
                    //sqlBulkCopy.ColumnMappings.Add("HeatOperationImage", "HeatOperationImage");
                    sqlBulkCopy.ColumnMappings.Add("OperationTemperature", "TreatmentTemperature");
                    sqlBulkCopy.ColumnMappings.Add("HeatsOperation", "HeatsOperation");
                    sqlBulkCopy.ColumnMappings.Add("CoolingMethod", "CoolingMethod");
                    sqlBulkCopy.ColumnMappings.Add("NoOfHeatOperations", "NoOfHeatOperations");
                    sqlBulkCopy.ColumnMappings.Add("DocumentNo", "DocumentNo");
                    sqlBulkCopy.ColumnMappings.Add("TimesOfHeating", "TimesOfHeating");

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

        #region ChemicalNorms

        [BindProperty] public ChemicalNorms Chemical { get; set; }

        public IActionResult ChemicalNorms(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllChemicalNorms(id));
        }

        public IActionResult CreateChemicalNorms(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateChemicalNorms(ChemicalNorms chemicalNorms)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddChemicalNorms(Chemical);
            return new JsonResult("success");
        }


        public IActionResult EditChemicalNorms(int id)
        {
            return View(_dataService.GetChemicalNormsById(id));
        }

        [HttpPost]
        public IActionResult EditChemicalNorms()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateChemicalNorms(Chemical);
            return new JsonResult("success");
        }

        public IActionResult DeleteChemicalNorms(string[] chemicalId)
        {
            foreach (string id in chemicalId)
            {
                _dataService.DeleteChemicalNorms(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportChemicalNorms(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllChemicalNormsForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Chemical Norms";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Norms.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<ChemicalNormsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetChemicalNormsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Chemical Norms";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Norms.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportChemicalNorms(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("ChemicalId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.ChemicalNorms";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("IndexDescription", "IndexDescription");
                    sqlBulkCopy.ColumnMappings.Add("Unit", "Unit");
                    sqlBulkCopy.ColumnMappings.Add("Value", "Value");
                    sqlBulkCopy.ColumnMappings.Add("Limit", "Limit");
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

        #region Technical Inspection Program

        [BindProperty]
        public InspectionProgram Program { get; set; }

        public IActionResult TechnicalPrograms(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllInspectionProgram(id));
        }


        public IActionResult CreateTechnicalInspectionProgram(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]

        public IActionResult CreateTechnicalInspectionProgram(InspectionProgram inspection)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddInspectionProgram(Program);
            return new JsonResult("success");
        }

        public IActionResult EditTechnicalInspectionProgram(int id)
        {
            return View(_dataService.GetInspectionProgramById(id));
        }

        [HttpPost]
        public IActionResult EditTechnicalInspectionProgram()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateInspectionProgram(Program);
            return new JsonResult("success");
        }

        public IActionResult DeleteTechnicalInspectionProgram(string[] inspectionsId)
        {
            foreach (string id in inspectionsId)
            {
                _dataService.DeleteInspectionProgram(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportTechnicalPrograms(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllInspectionProgramForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Technical Programs";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Technical Programs.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<InspectionProgramViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetInspectionProgramByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Technical Programs";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Technical Programs.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportTechnicalPrograms(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("InspectionProgramId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.InspectionPrograms";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Code", "Code");
                    sqlBulkCopy.ColumnMappings.Add("EquipmentDocument", "EquipmentDocument");
                    sqlBulkCopy.ColumnMappings.Add("TestMethod", "TestMethod");
                    sqlBulkCopy.ColumnMappings.Add("TechnicalDocuments", "TechnicalDocuments");
                    sqlBulkCopy.ColumnMappings.Add("ScopeofInspection", "ScopeofInspection");
                    sqlBulkCopy.ColumnMappings.Add("PeriodofInspection", "PeriodofInspection");
                    sqlBulkCopy.ColumnMappings.Add("CategoryofWeldedjoints", "CategoryofWeldedjoints");
                    sqlBulkCopy.ColumnMappings.Add("Note", "Note");
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

        #region Sensors
        [BindProperty] public Sensors Sensor { get; set; }


        public IActionResult Sensors(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllSensors(id));
        }


        public IActionResult CreateSensor(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]

        public IActionResult CreateSensor(Sensors crtSensors)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddSensors(Sensor);
            return new JsonResult("success");
        }

        public IActionResult EditSensor(int id)
        {
            return View(_dataService.GetSensorsById(id));
        }

        [HttpPost]
        public IActionResult EditSensor()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateSensors(Sensor);
            return new JsonResult("success");
        }

        public IActionResult DeleteSensor(string[] sensorId)
        {
            foreach (string id in sensorId)
            {
                _dataService.DeleteSensors(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }


        [HttpPost]
        public IActionResult ExportSensors(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllSensorsForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Sensors";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sensors.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<SensorsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetSensorsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Sensors";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sensors.xlsx");
                    }
                }
            }

        }


        [HttpPost]
        public async Task<IActionResult> ImportSensors(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("SensorId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.Sensors";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Parametertomeasure", "Parametertomeasure");
                    sqlBulkCopy.ColumnMappings.Add("AKZ", "AKZ");
                    sqlBulkCopy.ColumnMappings.Add("Numberofsignals", "Numberofsignals");
                    sqlBulkCopy.ColumnMappings.Add("KKS", "KKS");
                    sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");

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

        #region Control Points
        [BindProperty] public ControlPoints ControlPoint { get; set; }
        public IActionResult ControlPoints(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllControlPoints(id));
        }

        public IActionResult CreateControlPoints(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateControlPoints(ControlPoints points)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddControlPoints(ControlPoint);
            return new JsonResult("success");
        }

        public IActionResult EditControlPoints(int id)
        {
            return View(_dataService.GetControlPointsById(id));
        }

        [HttpPost]
        public IActionResult EditControlPoints()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateControlPoints(ControlPoint);
            return new JsonResult("success");
        }

        public IActionResult DeleteControlPoints(string[] pointId)
        {
            foreach (string id in pointId)
            {
                _dataService.DeleteControlPoints(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }


        [HttpPost]
        public IActionResult ExportControlPoints(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllControlPointsForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Control Points";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Control Points.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<ControlPointsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetControlPointsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Control Points";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Control Points.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportControlPoints(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("PointId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.ControlPoints";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Parameter", "Parameter");
                    sqlBulkCopy.ColumnMappings.Add("NumberCheckPoints", "NumberCheckPoints");
                    sqlBulkCopy.ColumnMappings.Add("MeasurementRange", "MeasurementRange");
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
        #endregion

        #region HForms

        [BindProperty]
        public HForms Forms { get; set; }

        public IActionResult HForms(int id)
        {
            ViewBag.MechanicalId = id;
			ViewBag.EquipName = _mechanical.GetEquipmentById(id).Name;
			return View(_dataService.GetAllHForms(id));
        }

        [HttpPost]
        public IActionResult ExportHForms(string reportId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllHFormsForExport(mechanicalId).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "H-Forms";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "H-Forms.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<HFormsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetHFormsByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "H-Forms";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "H-Forms.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportHForms(IFormFile FormFile, int mechanicalId)
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

            dt.Columns.Add("HFormsId", typeof(int));

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
                    sqlBulkCopy.DestinationTableName = "dbo.HForms";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("HFormsImage", "HFormsImage");
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



        public IActionResult CreateHForms(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateHForms(IFormFile filehforms)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.AddHForms(Forms, filehforms);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditHForms(int id)
        {
            return View(_dataService.GetHFormsById(id));
        }

        [HttpPost]
        public IActionResult EditHForms(IFormFile filehforms)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            _dataService.UpdateHForms(Forms, filehforms);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteHForms(string[] hformId)
        {
            foreach (string id in hformId)
            {
                _dataService.DeleteHForms(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Mechanical Properties

        [BindProperty]
        public MechanicalProperties Mechanical { get; set; }


        public IActionResult MechanicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;

            //Mechanical = new MechanicalProperties();
            //Mechanical.ComponentId = id;

            ViewData["ComponentId"] = id;

            return View(_dataService.GetAllMechanicalPropertiesForExport(id));
        }

        public IActionResult CreateMechanicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;

            return View(new MechanicalProperties() { ComponentId = id });
        }

        [HttpPost]
        public IActionResult CreateMechanicalProperties(MechanicalProperties mechanicalProperties)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddMechanicalProperties(Mechanical);
            return new JsonResult("success");
        }

        public IActionResult EditMechanicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            return View(_dataService.GetMechanicalPropertiesById(id));
        }

        [HttpPost]
        public IActionResult EditMechanicalProperties()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateMechanicalProperties(Mechanical);
            return new JsonResult("success");
        }

        public IActionResult DeleteMechanicalProperties(string[] mechanicalId)
        {
            foreach (string id in mechanicalId)
            {
                _dataService.DeleteMechanicalProperties(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportMechanicalProperties(string reportId, string componentId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllMechanicalPropertiesForExport(Convert.ToInt32(componentId)).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Mechanical Properties";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Mechanical Properties.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<MechanicalPropertiesViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetMechanicalPropertiesByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Mechanical Properties";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Mechanical Properties.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportMechanicalProperties(IFormFile FormFile, int componentId, int mechanicalId)
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

            dt.Columns.Add("MechanicalPropertiesId", typeof(int));

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
                        dt.Columns.Add("ComponentId", typeof(int));

                        foreach (DataRow row in dt.Rows)
                        {
                            // Where I tried to add new value to the column.

                            row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
                            row["ComponentId"] = componentId;
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
                    sqlBulkCopy.DestinationTableName = "dbo.MechanicalProperties";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("ComponentId", "ComponentId");
                    //MechanicalProperties
                    sqlBulkCopy.ColumnMappings.Add("MechanicalTemperature", "MechanicalTemperature");
                    sqlBulkCopy.ColumnMappings.Add("YoungModule", "YoungModule");
                    sqlBulkCopy.ColumnMappings.Add("YieldStrength", "YieldStrength");
                    sqlBulkCopy.ColumnMappings.Add("UltimateStrength", "UltimateStrength");
                    sqlBulkCopy.ColumnMappings.Add("SpecificElongation", "SpecificElongation");
                    sqlBulkCopy.ColumnMappings.Add("ReductionArea", "ReductionArea");
                    sqlBulkCopy.ColumnMappings.Add("ImpactToughness", "ImpactToughness");
                    sqlBulkCopy.ColumnMappings.Add("Hardness", "Hardness");

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

        #region   Physical Properties

        [BindProperty]
        public PhysicalProperties Physical { get; set; }


        public IActionResult PhysicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            //Mechanical = new MechanicalProperties();
            //Mechanical.ComponentId = id;

            ViewData["ComponentId"] = id;

            return View(_dataService.GetAllPhysicalPropertiesForExport(id));
        }

        public IActionResult CreatePhysicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;

            return View(new PhysicalProperties() { ComponentId = id });
        }

        [HttpPost]
        public IActionResult CreatePhysicalProperties(PhysicalProperties physicalProperties)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddPhysicalProperties(Physical);
            return new JsonResult("success");
        }

        public IActionResult EditPhysicalProperties(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            return View(_dataService.GetPhysicalPropertiesById(id));
        }

        [HttpPost]
        public IActionResult EditPhysicalProperties()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdatePhysicalProperties(Physical);
            return new JsonResult("success");
        }

        public IActionResult DeletePhysicalProperties(string[] physicalId)
        {
            foreach (string id in physicalId)
            {
                _dataService.DeletePhysicalProperties(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportPhysicalProperties(string reportId, string componentId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllPhysicalPropertiesForExport(Convert.ToInt32(componentId)).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Physical Properties";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Physical Properties.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<PhysicalPropertiesViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetPhysicalPropertiesByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Physical Properties";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Physical Properties.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportPhysicalProperties(IFormFile FormFile, int componentId, int mechanicalId)
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

            dt.Columns.Add("PhysicalPropertiesId", typeof(int));

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
                        dt.Columns.Add("ComponentId", typeof(int));

                        foreach (DataRow row in dt.Rows)
                        {
                            // Where I tried to add new value to the column.

                            row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
                            row["ComponentId"] = componentId;
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
                    sqlBulkCopy.DestinationTableName = "dbo.PhysicalProperties";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("ComponentId", "ComponentId");
                    //PhysicalProperties
                    sqlBulkCopy.ColumnMappings.Add("PhysicalTemperature", "PhysicalTemperature");
                    sqlBulkCopy.ColumnMappings.Add("LinearExpension", "LinearExpension");
                    sqlBulkCopy.ColumnMappings.Add("HeatCapacity", "HeatCapacity");
                    sqlBulkCopy.ColumnMappings.Add("ConductivityFactor", "ConductivityFactor");
                    sqlBulkCopy.ColumnMappings.Add("NormalRadiation", "NormalRadiation");
                    sqlBulkCopy.ColumnMappings.Add("PoissonRatio", "PoissonRatio");
                    sqlBulkCopy.ColumnMappings.Add("Density", "Density");


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

        #region Chemical Compositions

        [BindProperty]
        public ChemicalComponent chemicalComponent { get; set; }

        public IActionResult ChemicalComponent(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            //Mechanical = new MechanicalProperties();
            //Mechanical.ComponentId = id;

            ViewData["ComponentId"] = id;

            return View(_dataService.GetAllChemicalComponentForExport(id));
        }

        [HttpPost]
        public IActionResult ExportChemicalComponent(string reportId, string componentId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllChemicalComponentForExport(Convert.ToInt32(componentId)).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Chemical Compositions";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Compositions.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<ChemicalComponentViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetChemicalComponentByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Chemical Compositions";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Chemical Compositions.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportChemicalComponent(IFormFile FormFile, int componentId, int mechanicalId)
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

            dt.Columns.Add("ChemicalComponentId", typeof(int));

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
                        dt.Columns.Add("ComponentId", typeof(int));


                        foreach (DataRow row in dt.Rows)
                        {
                            // Where I tried to add new value to the column.

                            row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
                            row["ComponentId"] = componentId;

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
                    sqlBulkCopy.DestinationTableName = "dbo.ChemicalComponents";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("ComponentId", "ComponentId");

                    //ChemicalComponents
                    sqlBulkCopy.ColumnMappings.Add("C", "C");
                    sqlBulkCopy.ColumnMappings.Add("Si", "Si");
                    sqlBulkCopy.ColumnMappings.Add("Mn", "Mn");
                    sqlBulkCopy.ColumnMappings.Add("Cr", "Cr");
                    sqlBulkCopy.ColumnMappings.Add("Ni", "Ni");
                    sqlBulkCopy.ColumnMappings.Add("Mo", "Mo");
                    sqlBulkCopy.ColumnMappings.Add("V", "V");
                    sqlBulkCopy.ColumnMappings.Add("Ti", "Ti");
                    sqlBulkCopy.ColumnMappings.Add("Cu", "Cu");
                    sqlBulkCopy.ColumnMappings.Add("S", "S");
                    sqlBulkCopy.ColumnMappings.Add("P", "P");
                    sqlBulkCopy.ColumnMappings.Add("As", "As");
                    sqlBulkCopy.ColumnMappings.Add("Co", "Co");
                    sqlBulkCopy.ColumnMappings.Add("NB", "NB");
                    //sqlBulkCopy.ColumnMappings.Add("", "");

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

        public IActionResult CreateChemicalComponent(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;

            return View(new ChemicalComponent() { ComponentId = id });
        }

        [HttpPost]
        public IActionResult CreateChemicalComponent(ChemicalComponent chemicals)
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.AddChemicalComponent(chemicalComponent);
            return new JsonResult("success");
        }

        public IActionResult EditChemicalComponent(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            return View(_dataService.GetChemicalComponentById(id));
        }

        [HttpPost]
        public IActionResult EditChemicalComponent()
        {
            //if (!ModelState.IsValid)
            //    return View();

            _dataService.UpdateChemicalComponent(chemicalComponent);
            return new JsonResult("success");
        }

        public IActionResult DeleteChemicalComponent(string[] chemicalId)
        {
            foreach (string id in chemicalId)
            {
                _dataService.DeleteChemicalComponent(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region  Heat Treatment


        [BindProperty]
        public HeatOperation HeatOperation { get; set; }

        public IActionResult HeatTreatment(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            //Mechanical = new MechanicalProperties();
            //Mechanical.ComponentId = id;

            ViewData["ComponentId"] = id;

            return View(_dataService.GetAllHeatOperationForExport(id));
        }

        public IActionResult CreateHeatTreatment(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            return View(new HeatOperation() { ComponentId = id });
        }

        [HttpPost]
        public IActionResult CreateHeatTreatment(IFormFile fileHeating, string StartDates = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            if (StartDates != "")
            {
                string[] std = StartDates.Split('/', ' ', ':');
                HeatOperation.TimesOfHeating = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    int.Parse(std[3]),
                    int.Parse(std[4]),
                    int.Parse(std[5]),
                    new GregorianCalendar()
                );
            }

            _dataService.AddHeatOperation(HeatOperation, fileHeating);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditHeatTreatment(int id, int mechanicalId)
        {
            ViewBag.MechanicalId = mechanicalId;
            return View(_dataService.GetHeatOperationById(id));
        }

        [HttpPost]

        public IActionResult EditHeatTreatment(IFormFile fileHeating, string StartDates = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            if (StartDates != "")
            {
                string[] std = StartDates.Split('/', ' ', ':');
                HeatOperation.TimesOfHeating = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    int.Parse(std[3]),
                    int.Parse(std[4]),
                    int.Parse(std[5]),
                    new GregorianCalendar()
                );
            }

            _dataService.UpdateHeatOperation(HeatOperation, fileHeating);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteHeatTreatment(string[] heataoperId)
        {
            foreach (string id in heataoperId)
            {
                _dataService.DeleteHeatOperation(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportHeatTreatment(string reportId, string componentId, int mechanicalId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _dataService.GetAllHeatOperationForExport(Convert.ToInt32(componentId)).ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Heat Treatment";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Heat Treatment.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<HeatOperationViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _dataService.GetHeatOperationByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Heat Treatment";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Heat Treatment.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportHeatTreatment(IFormFile FormFile, int componentId, int mechanicalId)
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

            dt.Columns.Add("HeatOperationId", typeof(int));

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
                        dt.Columns.Add("ComponentId", typeof(int));
                        dt.Columns.Add("HeatOperationImage", typeof(string));

                        foreach (DataRow row in dt.Rows)
                        {
                            // Where I tried to add new value to the column.

                            row["CreateDate"] = DateTime.Now;
                            row["IsDelete"] = false;
                            row["ComponentId"] = componentId;
                            row["HeatOperationImage"] = null;
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
                    sqlBulkCopy.DestinationTableName = "dbo.HeatOperation";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("ComponentId", "ComponentId");

                    //HeatOperation
                    sqlBulkCopy.ColumnMappings.Add("HeatOperationImage", "HeatOperationImage");
                    sqlBulkCopy.ColumnMappings.Add("Temperature", "Temperature");
                    sqlBulkCopy.ColumnMappings.Add("HeatsOperation", "HeatsOperation");
                    sqlBulkCopy.ColumnMappings.Add("CoolingMethod", "CoolingMethod");
                    sqlBulkCopy.ColumnMappings.Add("NoOfHeatOperations", "NoOfHeatOperations");
                    sqlBulkCopy.ColumnMappings.Add("DocumentNo", "DocumentNo");
                    sqlBulkCopy.ColumnMappings.Add("TimesOfHeating", "TimesOfHeating");
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

            //return RedirectToAction("Index", new { id = mechanicalId });
            return NoContent();
        }

        #endregion

        #region General document  

        [BindProperty]
        public InspectionDocument GeneralDocument { get; set; }

        public IActionResult CreateGeneralDocument(int id)
        {
            ViewBag.MechanicalId = id;
            return View();
        }


        [HttpPost]
        public IActionResult CreateGeneralDocument(List<IFormFile> fileGeneral)
        {
            foreach (var file in fileGeneral)
            {
                var generalDataDocument = new InspectionDocument
                {
                    Code = GeneralDocument.Code,
                    CreateDate = DateTime.Now,
                    Filename = file.FileName,
                    IsDelete = false,
                    TypeId = 18,
                    MechanicalId=GeneralDocument.MechanicalId
                };
                _dataService.AddGeneralDataDocument(generalDataDocument, file);
            }

            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult ShowGeneralDocument(int id)
        {
            ViewBag.TransientId = id;
            return View();
        }

		[HttpPost]
		public IActionResult DeleteGeneralDataDocument(string[] generalDocumentId)
		{
			foreach (string id in generalDocumentId)
			{
				_dataService.DeleteGeneralDocumentData(Convert.ToInt32(id));
			}
			return new JsonResult("success");
		}

		#endregion 
	}
}
