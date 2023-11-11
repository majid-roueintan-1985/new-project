using System;
using System.Globalization;
using Bnpp.Core.Convertors;
using System.IO;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.Core.Services;
using Bnpp.DataLayer.Entities.Maintenance;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.VisualBasic;




namespace Bnpp.Web.Controllers
{
    public class TransientController : Controller
    {
        private IElectricalService _electrical;
        private IOperationalService _operational;
        private IWebHostEnvironment _env;
        private IConfiguration Configuration;

        public TransientController(IElectricalService electrical, IWebHostEnvironment env, IOperationalService operational, IConfiguration _configuration)
        {
            _electrical = electrical;
            _operational = operational;
            _env = env;
            Configuration = _configuration;
        }

        [Route("Transient")]
        public IActionResult Index()
        {
            return View();
        }

        #region NormalOperations

        public IActionResult NormalOperations()
        {
            ViewData["NormalDocuments"] = _operational.GetAllNormalOperationDocument();
            return View(_operational.GetAllNormalOperations());
        }


        [HttpPost]
        public IActionResult ImportNormalExcel(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //Create a Folder.
                string path = Path.Combine(this._env.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Save the uploaded Excel file.
                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                //Read the connection string for the Excel file.
                string conString = this.Configuration.GetConnectionString("ExcelConString");
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

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
                            connExcel.Close();
                        }
                    }
                }

                //Insert the Data read from the Excel file to Database Table.
                conString = this.Configuration.GetConnectionString("BnppConnection");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.OperationalData";

                        //[OPTIONAL]: Map the Excel columns with that of the database table.


                        foreach (DataColumn column in dt.Columns)
                            sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            //return View();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ExportNormalOperations()
        {
            var normalOperations = _operational.GetAllNormalOperations().ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(normalOperations.ToList()));
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NormalOperations.xlsx");
                }
            }
            return View();
        }


        [BindProperty]
        public OperationalData NormalOperation { get; set; }
        public IActionResult CreateNormalOperations(string code = "", string nameOftransient = "")
        {
            var groups = _operational.GetGroupForManageSearch();
            ViewBag.transientCode = new SelectList(groups, "Value", "Text");

            var subGrous = _operational.GetSubGroupForManageSearch(int.Parse(groups.First().Value));
            ViewBag.nameOftransient = new SelectList(subGrous, "Value", "Text");

            return View();
        }



        [HttpPost]
        public IActionResult CreateNormalOperations(/*string StartDates = "", string code = "", string nameOftransient = ""*/ OperationalData operational)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    NormalOperation.NormalDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}


            _operational.AddNormalOperation(operational);

            return new JsonResult("success");
        }

        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Select",Value = ""}
            };
            list.AddRange(_operational.GetSubGroupForManageSearch(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        public IActionResult EditNormalOperations(int id)
        {
            return View(_operational.GetNormalOperationalById(id));
        }

        [HttpPost]
        public IActionResult EditNormalOperations(string StartDates = "")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(NormalOperation);
            //}

            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    NormalOperation.NormalDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}


            _operational.UpdateNormalOperational(NormalOperation);

            return Json(" Diesel Generators Successfully Deleted.");
        }

        public IActionResult DeleteNormalOperations(string[] operationalId)
        {
            foreach (string id in operationalId)
            {
                _operational.DeleteNormalOperational(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        #endregion

        #region OperationalOccurence

        public IActionResult OperationalOccurence()
        {
            ViewData["OccurenceDocuments"] = _operational.GetAllOccuranceDocument();
            return View(_operational.GetAllOccurances());
        }

        [HttpPost]
        public IActionResult ExportOperationalOccurence()
        {
            var operationalOccurence = _operational.GetAllOccurances().ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(operationalOccurence.ToList()));
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OperationalOccurence.xlsx");
                }
            }
            return View();
        }

        [BindProperty]
        public Occurance Occurance { get; set; }

        public IActionResult CreateOccurence()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOccurence(string StartDates = "")
        {
            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    Occurance.OccuranceDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}

            _operational.AddOccurance(Occurance);

            return new JsonResult("success");
        }

        public IActionResult EditOccurence(int id)
        {
            return View(_operational.GetOccuranceById(id));
        }
        
        [HttpPost]
        public IActionResult EditOccurence(string StartDates = "")
        {
            if (!ModelState.IsValid)
            {
                return View(Occurance);
            }

            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    Occurance.OccuranceDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}
            _operational.UpdateOccurance(Occurance);

            return Json(" Diesel Generators Successfully Deleted.");
        }
        

        public IActionResult DeleteOccurence(string[] occurenceId)
        {
            foreach (string id in occurenceId)
            {
                _operational.DeleteOccurance(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }
        #endregion

        #region DesignBasisAccidents
        [BindProperty]
        public DesignBasis Basis { get; set; }
        public IActionResult DesignBasisAccidents()
        {

            ViewData["BasisDocuments"] = _operational.GetAllBasisDocument();
            return View(_operational.GetAllBasisAccident());
        }

        [HttpPost]
        public IActionResult ExportDesignBasisAccidents()
        {
            var designBasisAccidents = _operational.GetAllBasisAccident().ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(designBasisAccidents.ToList()));
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DesignBasisAccidents.xlsx");
                }
            }
            return View();
        }

        public IActionResult CreateDesignBasisAccidents()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDesignBasisAccidents(string StartDates = "")
        {
            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    Basis.DesignBasisDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}

            _operational.AddBasisAccident(Basis);

            return new JsonResult("success");
        }

        public IActionResult EditDesignBasisAccidents(int id)
        {

            return View(_operational.GetBasisAccidentById(id));
        }

        [HttpPost]
        public IActionResult EditDesignBasisAccidents(string StartDates = "")
        {
            if (!ModelState.IsValid)
            {
                return View(Basis);
            }

            //if (StartDates != "")
            //{
            //    string[] std = StartDates.Split('/');
            //    Basis.DesignBasisDate = new DateTime(int.Parse(std[2]),
            //        int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        new GregorianCalendar()
            //    );
            //}
            _operational.UpdateBasisAccident(Basis);

            return Json(" Diesel Generators Successfully Deleted.");
        }

        public IActionResult DeleteDesignBasisAccidents(string[] basisId)
        {
            foreach (string id in basisId)
            {
                _operational.DeleteBasisAccident(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }





        [BindProperty]
        public InspectionDocument Document { get; set; }
        #endregion

        #region NormalOperations Document

        public IActionResult CreateNormalOperationsDocument()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNormalOperationsDocument(IFormFile normalDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.AddNormalOperationDocument(Document, normalDocs);

            return new JsonResult("success");
        }

        public IActionResult EditNormalOperationsDocument(int id)
        {
            return View(_operational.GetNormalOperationDocumentById(id));
        }

        [HttpPost]
        public IActionResult EditNormalOperationsDocument(IFormFile normalDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.UpdateNormalOperationDocument(Document, normalDocs);

            return new JsonResult("success");
        }

        public IActionResult DeleteNormalOperationsDocuments(string[] normalDocId)
        {
            foreach (string id in normalDocId)
            {
                _operational.DeleteNormalOperationDocument(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        #endregion

        #region Occurences Document

        public IActionResult CreateOccurenceDocument()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOccurenceDocument(IFormFile occurenceDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.AddOccuranceDocument(Document, occurenceDocs);

            return new JsonResult("success");
        }

        public IActionResult EditOccurenceDocument(int id)
        {
            return View(_operational.GetOccuranceDocumentById(id));
        }

        [HttpPost]
        public IActionResult EditOccurenceDocument(IFormFile occurenceDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.UpdateOccuranceDocument(Document, occurenceDocs);

            return new JsonResult("success");
        }

        public IActionResult DeleteOccurenceDocuments(string[] occurenceId)
        {
            foreach (string id in occurenceId)
            {
                _operational.DeleteOccuranceDocument(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        #endregion

        #region DesignBasisAccidents Document

        public IActionResult CreateBasisDocument()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBasisDocument(IFormFile basisDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.AddBasisDocument(Document, basisDocs);

            return new JsonResult("success");
        }


        public IActionResult EditBasisDocument(int id)
        {
            return View(_operational.GetBasisDocumentById(id));
        }

        [HttpPost]
        public IActionResult EditBasisDocument(IFormFile basisDocs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}


            _operational.UpdateBasisDocument(Document, basisDocs);

            return new JsonResult("success");
        }


        public IActionResult DeleteBasisAccidentDocument(string[] basisId)
        {
            foreach (string id in basisId)
            {
                _operational.DeleteBasisDocument(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        #endregion

    }
}
