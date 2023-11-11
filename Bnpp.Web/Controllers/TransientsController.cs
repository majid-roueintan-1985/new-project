using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Bnpp.DataLayer.Entities.BasicData;
using System;
using Bnpp.DataLayer.ViewModels;
using Bnpp.Core.Convertors;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
//using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Bnpp.Core.Services;
using Bnpp.DataLayer.Entities.OperationalDatas;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Bnpp.DataLayer.Context;
using Spire.Presentation;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Win32;
using Bnpp.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Wordprocessing;


namespace Bnpp.Web.Controllers
{
    public class TransientsController : Controller
    {
        private ITransientService _service;
        private IOperationalService _operational;
        private IConfiguration Configuration;

        public TransientsController(ITransientService service, IOperationalService operational, IConfiguration _configuration)
        {
            _service = service;
            _operational = operational;
            Configuration = _configuration;
        }


        
        //public TransientDocuments TransientDocuments { get; set; }

        [Route("Transients")]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CreateTransientGroups()
        {
            return View(_service.GetAllGroups());
        }

        public IActionResult DeleteGroup(string[] groupId)
        {

            foreach (string id in groupId)
            {
                _service.DeleteTarnsientGroup(Convert.ToInt32(id));
            }

            return Json("TransientGroups Successfully Deleted.");
        }

        public IActionResult SaveTransients()
        {
            ViewBag.SavedTransient = _service.GetAllSavedTransient();
            return View();
        }


        [HttpPost]
        public IActionResult ExportSaveTransients(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _service.GetAllSavedTransientForExport().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Transients";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transients.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<SaveTransientsViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _service.GetTransientByIdForExport(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Transients";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transients.xlsx");
                    }
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> ImportSaveTransients(IFormFile FormFile)
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

            dt.Columns.Add("TransientsId", typeof(int));

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
            //conString = @"Data Source=87.236.215.209;Initial Catalog=TransientDB;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("TransientDBConnection");
			using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.Transients";

                    // Map the Excel columns with that of the database table, this is optional but good if you do


                    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    sqlBulkCopy.ColumnMappings.Add("Code", "Code");
                    sqlBulkCopy.ColumnMappings.Add("Description", "Description");
                    sqlBulkCopy.ColumnMappings.Add("AllowableNumber", "AllowableNumber");
                    sqlBulkCopy.ColumnMappings.Add("TransientDate", "TransientDate");
                    sqlBulkCopy.ColumnMappings.Add("TransientTime", "TransientTime");

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

        //public IActionResult Create(int? id)
        //{
        //    TransientGroups grops = new TransientGroups();
        //    grops.ParentId = id;

        //    return View(grops);
        //}


        //[HttpPost]
        //public IActionResult Create(TransientGroups groups)
        //{

        //    if (groups.ParentId == null)
        //    {
        //        var groupName = _service.GetGroupByGroupTitle(groups.GroupTitle);
        //        if (groupName != null)
        //        {
        //            Response.StatusCode = 500;
        //            return Json("The entered Code is duplicated!");
        //        }
        //    }
        //    else
        //    {
        //        var groupTitle = _service.GetTransientGroupsByParentId((int)(int?)groups.ParentId, groups.GroupTitle);
        //        if (groupTitle != null)
        //        {
        //            Response.StatusCode = 500;
        //            return Json("The entered Name is duplicated!");
        //        }
        //    }



        //    if (groups.GroupTitle != null)
        //    {
        //        _service.AddNewTarnsientGroup(groups);
        //    }
        //    return RedirectToAction("Index");
        //    //return Json(" Electormotors Successfully Deleted.");
        //}

        public IActionResult EditTransients(int id)
        {
            return View(_service.GetTransientById(id));
        }

        [HttpPost]
        public IActionResult EditTransients(string TransientDate = "")
        {
            var code = _service.CheckExistCode(MyTransient.Code);
            if (code == null)
            {
                return Json(" Electormotors Successfully Deleted.");
            }

            if (TransientDate != "")
            {
                string[] std = TransientDate.Split('/', ' ', ':');
                MyTransient.TransientDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),

                    new GregorianCalendar()
                );
            }

            //if (TransientTime != "")
            //{
            //    MyTransient.TransientTime = DateTime.Parse(TransientTime);
            //}

            _service.UpdateTransient(MyTransient);
            return Json(" Electormotors Successfully Deleted.");
        }

        //public IActionResult CreateName(int? id)
        //{
        //    TransientGroups grops = new TransientGroups();
        //    grops.ParentId = id;

        //    return View(grops);
        //}

        public IActionResult DeleteTransients(string[] transientsId)
        {
            foreach (string id in transientsId)
            {
                _service.DeleteTransient(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        //public IActionResult CreateNewValue(int? id)
        //{
        //    TransientGroups grops = new TransientGroups();
        //    grops.ParentId = id;

        //    return View(grops);
        //}

        public IActionResult ListGroups()
        {
            return View(_service.GetListOfGroups());
        }


        //public IActionResult Search(string code = "")
        //{

        //    ViewBag.Names = _service.GetAllGroups();

        //    return View(_service.GetCodeForSearch(code));
        //}

        //public IActionResult nameSearch(string transientName = "")
        //{

        //    ViewBag.Codes = _service.GetListOfGroups();

        //    return View(_service.GetNameForSearch(transientName));
        //}

        public IActionResult CreateTransient()
        {
            //var groups = _operational.GetGroupForManageSearch();
            //ViewBag.transientCode = new SelectList(groups, "Value", "Text");

            //var subGrous = _operational.GetSubGroupForManageSearch(int.Parse(groups.First().Value));
            ViewBag.nameOftransient = new SelectList("Value", "Text");
            return View();
        }

        [BindProperty]
        public Transients MyTransient { get; set; }

        [HttpPost]
        public IActionResult CreateTransient(List<IFormFile> fileTransient, string TransientDate = "", string codes = "", string transientnames = "")
        {

            //var code = _service.CheckExistCode(MyTransient.Code);
            var code = MyTransient.Code;
            if (code == null)
            {
                return Json(" Electormotors Successfully Deleted.");
            }

            if (TransientDate != "")
            {
                string[] std = TransientDate.Split('/', ' ', ':');
                MyTransient.TransientDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),

                    new GregorianCalendar()
                );
            }

            //var nameId = _service.GetGroupIdByGroupTitle(MyTransient.Name);
            //var allowNumber = _service.GetTransientGroupByGroupId(nameId);

            var transientGroup = _service.GetGroupedTransientByTitle(MyTransient.Code);

            MyTransient.AllowableNumber = transientGroup.AllowableNumber.ToString();

            //if (allowNumber == null)
            //{
            //    Response.StatusCode = 500;
            //    return Json("You must first specify the Allowable Number!");
            //}
            //else
            //{
            //    MyTransient.AllowableNumber = allowNumber.GroupTitle;
            //}

            //if (TransientTime != "")
            //{
            //    MyTransient.TransientTime = DateTime.Parse(TransientTime);
            //}

            _service.AddTransient(MyTransient);

            #region Add Transient Images


            foreach (var file in fileTransient)
            {
                var TransientDocuments = new TransientDocuments
                {
                    TransientDocumentsImage = Guid.NewGuid() + Path.GetExtension(file.FileName),
                    TransientsId = MyTransient.TransientsId,
                    CreateDate = DateTime.Now,
                    Filename = file.FileName,
                    IsDelete = false,
                    Transients = MyTransient
                };

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/transientFiles", TransientDocuments.TransientDocumentsImage);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                _service.AddTransientDocument(TransientDocuments);

            }


            #endregion

            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult ShowTransientDocument(int id)
        {
            ViewBag.TransientId = id;
            return View(_service.GetTransientDocumentById(id));
        }

        public IActionResult EditDocument(int id)
        {
            ViewBag.TransientId = id;
            return View(_service.GetTransientDocumentById(id));
        }

        public IActionResult Results()
        {
            return View(_service.GetGroupedTransients());
            //return View();
        }



        public IActionResult TransientsList(TransientGroups groups)
        {
            ViewBag.Groups = _service.GetListOfGroups();
            //_service.AddNewTarnsientGroup(groups);
            return View(_service.GetAllGroups());
        }

        [HttpPost]
        public IActionResult GetSubGroups(string title)
        {

            var group = _service.GetTransientGroupsByTitle(title);

            if (group == null)
            {
                Response.StatusCode = 500;
                return Json("This CODE does not exist in the system!");
            }

            var groupId = group.GroupId;



            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Select",Value = ""}
            };
            list.AddRange(_operational.GetSubGroupForManageSearch(groupId));
            return Json(new SelectList(list, "Value", "Text"));
        }

        [HttpPost]
        public IActionResult GetTransientByCode(string title)
        {

            return View(_service.GetGroupedTransientByCode(title));
        }

        public IActionResult EditTransientDocument(List<IFormFile> fileTransient, string transientsId)
        {

            foreach (var file in fileTransient)
            {
                var TransientDocuments = new TransientDocuments
                {
                    TransientDocumentsImage = Guid.NewGuid() + Path.GetExtension(file.FileName),
                    TransientsId = Convert.ToInt32(transientsId),
                    CreateDate = DateTime.Now,
                    Filename = file.FileName,
                    IsDelete = false,
                };

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/transientFiles", TransientDocuments.TransientDocumentsImage);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                _service.AddTransientDocument(TransientDocuments);

            }
            return Json(" Electormotors Successfully Deleted.");
        }

        [HttpPost]
        public IActionResult DeletetransientDocument(int id)
        {
            _service.DeleteDocument(id);

            return new JsonResult("success");
        }


        #region grouped of transient

        [BindProperty]
        public GroupedTransients GetGroupedTransients { get; set; }


        public IActionResult GroupedOfTransient()
        {
            return View(_service.GetAllGroupedOfTransients());
        }

        public IActionResult CreateGroupedOfTransient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroupedOfTransient(GroupedTransients grouped)
        {
            if (_service.IsExistCode(GetGroupedTransients.Code))
            {
                Response.StatusCode = 500;
                return Json("This CODE does exist in the system!");
            }

            _service.AddGroupedTransient(GetGroupedTransients);
            return Json(" Electormotors Successfully Deleted.");
        }



        public IActionResult DeleteGroupedTransients(string[] groupId)
        {
            foreach (string id in groupId)
            {
                _service.DeleteGroupedTransient(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }


        public IActionResult SearchInGroupedOfTransientCode(string code = "")
        {
            return View(_service.SearchInGroupedOfTransient(code));

        }

        public IActionResult SearchInGroupedOfTransientName(string transientName = "")
        {
            return View(_service.SearchInNameGroupedOfTransient(transientName));

        }



        [HttpPost]
        public IActionResult GetSubGroupsInGroupedTransient(string title)
        {

            var code = _service.GetGroupedTransientByTitle(title);

            if (code == null)
            {
                Response.StatusCode = 500;
                return Json("This CODE does not exist in the system!");
            }


            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Select",Value = ""}
            };
            list.AddRange(_service.GetSubGroupForManageSearch(code.Code));
            return Json(new SelectList(list, "Value", "Text"));

           

        }

        #endregion

        #region  Export

        
        //    [HttpPost]
        //public IActionResult ExportTransients(string reportId)
        //{
        //    if (reportId == null)
        //    {
        //        var chemistryDocument = _service.GetAllMaintenanceCableForExcel().ToList();
        //        using (XLWorkbook wb = new XLWorkbook())
        //        {
        //            wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));


        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                wb.SaveAs(stream);
        //                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Data.xlsx");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var res = new List<MaintenanceCableViewModel>();

        //        string[] std = reportId.Split(',');

        //        foreach (string id in std)
        //        {
        //            var chemistryDocument = _service.GetMaintenanceCableByIdForExcel(Convert.ToInt32(id));
        //            res.Add(chemistryDocument);
        //        }

        //        using (XLWorkbook wb = new XLWorkbook())
        //        {
        //            wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                wb.SaveAs(stream);

        //                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Data.xlsx");
        //            }
        //        }
        //    }
        //    //return RedirectToAction("index");
        //}

        #endregion

    }
}
