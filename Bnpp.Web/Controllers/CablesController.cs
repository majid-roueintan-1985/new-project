using System;
using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Bnpp.Core.Convertors;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;




using System.Collections.Specialized;


using Newtonsoft.Json;


using Microsoft.Net.Http.Headers;
using Spire.Xls;

namespace Bnpp.Web.Controllers
{
    public class CablesController : Controller
    {
        private IElectricalService _electrical;
        private IHostingEnvironment _hostingEnv;
        private IConfiguration Configuration;
        private IWebHostEnvironment _env;
        public CablesController(IElectricalService electrical, IHostingEnvironment hostingEnv, IConfiguration _configuration, IWebHostEnvironment env)
        {
            _electrical = electrical;
            _hostingEnv = hostingEnv;
            Configuration = _configuration;
            _env = env;
        }

        #region cables.
        [Route("Cables")]
        public IActionResult Index()
        {
            return View(_electrical.GetAllCables());
        }

        public IActionResult CreateNewCables()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewCables(CableListViewModel cable)
        {
            if (!ModelState.IsValid)
            {
                return View(cable);
            }

            Cable cables = new Cable()
            {
                Name = cable.Name,
                Azk = cable.Azk,
                Position = cable.InstalationPosition,
                CreateDate = DateTime.Now,
            };

            _electrical.AddCables(cables);

            return RedirectToAction("Index");
        }

        public IActionResult EditCables(int id)
        {
            return View(_electrical.GetCableById(id));
        }

        [HttpPost]
        public IActionResult EditCables(Cable cable)
        {
            if (!ModelState.IsValid)
            {
                return View(cable);
            }
            _electrical.UpdateCables(cable);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCable(string[] cableId)
        {
            foreach (string id in cableId)
            {
                _electrical.DeleteCable(Convert.ToInt32(id));
            }

            return Json(" Equipments Successfully Deleted.");
        }
        #endregion

        #region General Cables

        [BindProperty]
        public GeneralCables GetGeneralCables { get; set; }

        public IActionResult GeneralData()
        {
            
            return View(_electrical.GetAllGeneralCables());
        }

        public IActionResult CreateGeneralCables()
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var current = _electrical.GetCableCurrentSelectList();
            ViewBag.Current = new SelectList(current, "Value", "Text");

            var typeofCables = _electrical.GettypeofCables();
            ViewBag.TypeofCables = new SelectList(typeofCables, "Value", "Text");

            var voltage = _electrical.GetClassificationVoltage();
            ViewBag.ClassificationVoltage = new SelectList(voltage, "Value", "Text");

            var listofCable = _electrical.GetListofCables();
            ViewBag.ListofCable = new SelectList(listofCable, "Value", "Text");

            var InsulationMaterial = _electrical.GetInsulationMaterialSelectList();
            ViewBag.InsulationMaterial = new SelectList(InsulationMaterial, "Value", "Text");

            var jacketMaterial = _electrical.GetJacketMaterialSelectList();
            ViewBag.JacketMaterial = new SelectList(jacketMaterial, "Value", "Text");

            var cableManufacturer = _electrical.GetManufacturerSelectList();
            ViewBag.CableManufacturer = new SelectList(cableManufacturer, "Value", "Text");

            var cableLocation = _electrical.GetCableLocationSelectList();
            ViewBag.Location = new SelectList(cableLocation, "Value", "Text");

            var degradationMechanisms = _electrical.GetCableLocationSelectList();
            ViewBag.DegradationMechanisms = new SelectList(degradationMechanisms, "Value", "Text");

           

            return View();
        }

        [HttpPost]
        public IActionResult CreateGeneralCables(IFormFile fileResistanceDBA, IFormFile fileResistanceBDBA, IFormFile fileResultFactory, IFormFile fileInstallation, string installationDate = "")
        {
            if (installationDate != "")
            {
                string[] std = installationDate.Split('/', ' ');
                GetGeneralCables.InstallationDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.AddGeneralCables(GetGeneralCables, fileResistanceDBA, fileResistanceBDBA, fileResultFactory, fileInstallation);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult DeleteGeneralCable(string[] generalId)
        {
            foreach (string id in generalId)
            {
                _electrical.DeleteGeneralCables(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        public IActionResult EditGeneralCables(int id)
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var typeofCables = _electrical.GettypeofCables();
            ViewBag.TypeofCables = new SelectList(typeofCables, "Value", "Text");

            var voltage = _electrical.GetClassificationVoltage();
            ViewBag.ClassificationVoltage = new SelectList(voltage, "Value", "Text");

            var listofCable = _electrical.GetListofCables();
            ViewBag.ListofCable = new SelectList(listofCable, "Value", "Text");

            var InsulationMaterial = _electrical.GetInsulationMaterialSelectList();
            ViewBag.InsulationMaterial = new SelectList(InsulationMaterial, "Value", "Text");

            var jacketMaterial = _electrical.GetJacketMaterialSelectList();
            ViewBag.JacketMaterial = new SelectList(jacketMaterial, "Value", "Text");

            var cableManufacturer = _electrical.GetManufacturerSelectList();
            ViewBag.CableManufacturer = new SelectList(cableManufacturer, "Value", "Text");

            var cableLocation = _electrical.GetCableLocationSelectList();
            ViewBag.Location = new SelectList(cableLocation, "Value", "Text");

            var degradationMechanisms = _electrical.GetCableLocationSelectList();
            ViewBag.DegradationMechanisms = new SelectList(degradationMechanisms, "Value", "Text");

            var current = _electrical.GetCableCurrentSelectList();
            ViewBag.Current = new SelectList(current, "Value", "Text");

            return View(_electrical.GetCablesGeneralById(id));
        }

        [HttpPost]
        public IActionResult EditGeneralCables(IFormFile fileResistanceDBA, IFormFile fileResistanceBDBA, IFormFile fileResultFactory, IFormFile fileInstallation, string installationDate = "")
        {
            if (installationDate != "")
            {
                string[] std = installationDate.Split('/', ' ');
                GetGeneralCables.InstallationDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.UpdateGeneralCables(GetGeneralCables, fileResistanceDBA, fileResistanceBDBA, fileResultFactory, fileInstallation);
            return Json(" Electormotors Successfully Deleted.");
        }


        [HttpPost]
        public IActionResult ExportGeneralData(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _electrical.GetAllGeneralCablesForExcel().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {
                   var ws= wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
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
                var res = new List<GeneralCablesViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _electrical.GetCablesGeneralByIdForExcel(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "General Data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "General Data.xlsx");
                    }
                }
            }
            //return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> ImportGeneralDataExcelFile(IFormFile FormFile)
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
			//conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";
			conString = this.Configuration.GetConnectionString("BnppConnection");
			using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.GeneralCables";

                    // Map the Excel columns with that of the database table, this is optional but good if you do

                    sqlBulkCopy.ColumnMappings.Add("Current", "Current");
                    sqlBulkCopy.ColumnMappings.Add("ClassificationofCable", "ClassificationofCable");
                    sqlBulkCopy.ColumnMappings.Add("CableID", "CableID");
                    sqlBulkCopy.ColumnMappings.Add("CableIDGroup", "CableIDGroup");
                    sqlBulkCopy.ColumnMappings.Add("CableLength", "CableLength");
                    sqlBulkCopy.ColumnMappings.Add("DesignLife", "DesignLife");
                    sqlBulkCopy.ColumnMappings.Add("ExpectedDegradationMechanisms", "ExpectedDegradationMechanisms");
                    sqlBulkCopy.ColumnMappings.Add("From", "From");
                    sqlBulkCopy.ColumnMappings.Add("InstallationDate", "InstallationDate");
                    sqlBulkCopy.ColumnMappings.Add("InsulationMaterial", "InsulationMaterial");
                    sqlBulkCopy.ColumnMappings.Add("IntermediateLocations", "IntermediateLocations");
                    sqlBulkCopy.ColumnMappings.Add("JacketMaterial", "JacketMaterial");
                    sqlBulkCopy.ColumnMappings.Add("ListofCable", "ListofCable");
                    sqlBulkCopy.ColumnMappings.Add("Location", "Location");
                    sqlBulkCopy.ColumnMappings.Add("LogTime", "LogTime");
                    sqlBulkCopy.ColumnMappings.Add("Manufacturer", "Manufacturer");
                    sqlBulkCopy.ColumnMappings.Add("ManufacturingYear", "ManufacturingYear");
                    sqlBulkCopy.ColumnMappings.Add("NominalCurrent", "NominalCurrent");
                    sqlBulkCopy.ColumnMappings.Add("NominalVoltage", "NominalVoltage");
                    sqlBulkCopy.ColumnMappings.Add("NumberofSimilarCables", "NumberofSimilarCables");
                    sqlBulkCopy.ColumnMappings.Add("OperatingAmbientTemperature", "OperatingAmbientTemperature");
                    sqlBulkCopy.ColumnMappings.Add("Owner", "Owner");
                    sqlBulkCopy.ColumnMappings.Add("RemainingDesignLifeTime", "RemainingDesignLifeTime");
                    sqlBulkCopy.ColumnMappings.Add("ResistanceBDBAConditionFilename", "ResistanceBDBAConditionFilename");
                    sqlBulkCopy.ColumnMappings.Add("ResistancetoDBAConditionFilename", "ResistancetoDBAConditionFilename");
                    sqlBulkCopy.ColumnMappings.Add("ResultFactoryTestsFilename", "ResultFactoryTestsFilename");
                    sqlBulkCopy.ColumnMappings.Add("ResultTestsEndInstallationFilename", "ResultTestsEndInstallationFilename");
                    sqlBulkCopy.ColumnMappings.Add("ServiceLife", "ServiceLife");
                    sqlBulkCopy.ColumnMappings.Add("To", "To");
                    sqlBulkCopy.ColumnMappings.Add("TotalLengthofSimilarCables", "TotalLengthofSimilarCables");
                    sqlBulkCopy.ColumnMappings.Add("ResistanceBDBAConditionImage", "ResistanceBDBAConditionImage");
                    sqlBulkCopy.ColumnMappings.Add("ResistancetoDBAConditionImage", "ResistancetoDBAConditionImage");
                    sqlBulkCopy.ColumnMappings.Add("ResultFactoryTestsImage", "ResultFactoryTestsImage");
                    sqlBulkCopy.ColumnMappings.Add("ResultTestsEndInstallationImage", "ResultTestsEndInstallationImage");
                    sqlBulkCopy.ColumnMappings.Add("TypeofCable", "TypeofCable");

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
        #endregion

        #region Operating  Data

        [BindProperty]
        public OperatingCableData GetOperatingCable { get; set; }


        public IActionResult OperatingData()
        {
            
            return View(_electrical.GetAllOperatingCables());
        }


        public IActionResult CreateOperatingData()
        {
           
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var current = _electrical.GetCableCurrentSelectList();
            ViewBag.Current = new SelectList(current, "Value", "Text");

            var operating = _electrical.GetOperationModeSelectList();
            ViewBag.OperationMode = new SelectList(operating, "Value", "Text");

            var failureDiscovery = _electrical.GetFailureDiscoverySelectList();
            ViewBag.FailureDiscovery = new SelectList(failureDiscovery, "Value", "Text");

            var failureCondition = _electrical.GetFailureConditionSelectList();
            ViewBag.FailureCondition = new SelectList(failureCondition, "Value", "Text");

            var failedParts = _electrical.GetFailedPartsSelectList();
            ViewBag.FailedParts = new SelectList(failedParts, "Value", "Text");

            return View();
        }


        [HttpPost]
        public IActionResult CreateOperatingData(string FailureDate = "")
        {
            if (FailureDate != "")
            {
                string[] std = FailureDate.Split('/', ' ');
                GetOperatingCable.FailureDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.AddOperatingData(GetOperatingCable);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult EditOperatingData(int id)
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var current = _electrical.GetCableCurrentSelectList();
            ViewBag.Current = new SelectList(current, "Value", "Text");

            var operating = _electrical.GetOperationModeSelectList();
            ViewBag.OperationMode = new SelectList(operating, "Value", "Text");

            var failureDiscovery = _electrical.GetFailureDiscoverySelectList();
            ViewBag.FailureDiscovery = new SelectList(failureDiscovery, "Value", "Text");

            var failureCondition = _electrical.GetFailureConditionSelectList();
            ViewBag.FailureCondition = new SelectList(failureCondition, "Value", "Text");

            var failedParts = _electrical.GetFailedPartsSelectList();
            ViewBag.FailedParts = new SelectList(failedParts, "Value", "Text");

            return View(_electrical.GetOperatingCableById(id));
        }

        [HttpPost]
        public IActionResult EditOperatingData(string FailureDate = "")
        {
            if (FailureDate != "")
            {
                string[] std = FailureDate.Split('/', ' ');
                GetOperatingCable.FailureDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.UpdateOperatingData(GetOperatingCable);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteOperatingData(string[] operatinglId)
        {
            foreach (string id in operatinglId)
            {
                _electrical.DeleteOperatingCables(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportOperatingData(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _electrical.GetAllOperatingCablesForExcel().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Operating Data";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Operating Data.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<OperatingDataViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _electrical.GetOperatingCableByIdForExcel(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Operating Data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Operating Data.xlsx");
                    }
                }
            }
            //return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> ImportOperatingDataExcelFile(IFormFile FormFile)
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
            conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.OperatingCableDatas";

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
        #endregion

        #region Maintenance  Data

        [BindProperty]
        public MaintenanceCable GetMaintenanceCable { get; set; }


        public IActionResult MaintenanceData()
        {
            return View(_electrical.GetAllMaintenanceCable());
        }

        public IActionResult CreateMaintenanceData()
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var typeofMaintenance = _electrical.GetTypeofMaintenanceSelectList();
            ViewBag.TypeofMaintenance = new SelectList(typeofMaintenance, "Value", "Text");

            var testType = _electrical.GetTestTypeSelectList();
            ViewBag.TestType = new SelectList(testType, "Value", "Text");

            var resaultCable = _electrical.GetResaultCableSelectList();
            ViewBag.ResaultCable = new SelectList(resaultCable, "Value", "Text");

            return View();
        }

        [HttpPost]
        public IActionResult CreateMaintenanceData(IFormFile fileAttachAct, string StartTimeMaintenance = "", string EndTimeMaintenance = "")
        {
            if (StartTimeMaintenance != "")
            {
                string[] std = StartTimeMaintenance.Split('/', ' ');
                GetMaintenanceCable.StartTimeMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (EndTimeMaintenance != "")
            {
                string[] std = EndTimeMaintenance.Split('/', ' ');
                GetMaintenanceCable.EndTimeMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.AddMaintenanceCable(GetMaintenanceCable, fileAttachAct);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult EditMaintenanceData(int id)
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var typeofMaintenance = _electrical.GetTypeofMaintenanceSelectList();
            ViewBag.TypeofMaintenance = new SelectList(typeofMaintenance, "Value", "Text");

            var testType = _electrical.GetTestTypeSelectList();
            ViewBag.TestType = new SelectList(testType, "Value", "Text");

            var resaultCable = _electrical.GetResaultCableSelectList();
            ViewBag.ResaultCable = new SelectList(resaultCable, "Value", "Text");

            return View(_electrical.GetMaintenanceCableById(id));
        }

        [HttpPost]
        public IActionResult EditMaintenanceData(IFormFile fileAttachAct, string StartTimeMaintenance = "", string EndTimeMaintenance = "")
        {
            if (StartTimeMaintenance != "")
            {
                string[] std = StartTimeMaintenance.Split('/', ' ');
                GetMaintenanceCable.StartTimeMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (EndTimeMaintenance != "")
            {
                string[] std = EndTimeMaintenance.Split('/', ' ');
                GetMaintenanceCable.EndTimeMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.UpdateMaintenanceCable(GetMaintenanceCable, fileAttachAct);
            return Json(" Electormotors Successfully Deleted.");
        }
        public IActionResult DeleteMaintenanceData(string[] maintenanceId)
        {
            foreach (string id in maintenanceId)
            {
                _electrical.DeleteMaintenanceCables(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        [HttpPost]
        public IActionResult ExportMaintenanceData(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _electrical.GetAllMaintenanceCableForExcel().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Maintenance Data";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Data.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<MaintenanceCableViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _electrical.GetMaintenanceCableByIdForExcel(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Maintenance Data";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Maintenance Data.xlsx");
                    }
                }
            }
            //return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> ImportMaintenanceDataExcelFile(IFormFile FormFile)
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
            conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.MaintenanceCables";

                    // Map the Excel columns with that of the database table, this is optional but good if you do

                    sqlBulkCopy.ColumnMappings.Add("AcceptanceCriteria", "AcceptanceCriteria");
                    sqlBulkCopy.ColumnMappings.Add("AttachActFileName", "AttachActFileName");
                    sqlBulkCopy.ColumnMappings.Add("AttachActNo", "AttachActNo");
                    sqlBulkCopy.ColumnMappings.Add("CableID", "CableID");
                    sqlBulkCopy.ColumnMappings.Add("CableIDGroup", "CableIDGroup");
                    sqlBulkCopy.ColumnMappings.Add("DescriptionMaintenanceReasons", "DescriptionMaintenanceReasons");
                    sqlBulkCopy.ColumnMappings.Add("EndTimeMaintenance", "EndTimeMaintenance");
                    sqlBulkCopy.ColumnMappings.Add("Owner", "Owner");
                    sqlBulkCopy.ColumnMappings.Add("Result", "Resault");
                    sqlBulkCopy.ColumnMappings.Add("StartTimeMaintenance", "StartTimeMaintenance");
                    sqlBulkCopy.ColumnMappings.Add("TypeofMaintenancework", "TypeofMaintenancework");
                    sqlBulkCopy.ColumnMappings.Add("TypeTests", "TypeTests"); 
                    sqlBulkCopy.ColumnMappings.Add("Value", "Value");
                    sqlBulkCopy.ColumnMappings.Add("VisualResultMaintenance", "VisualResultMaintenance");
                    sqlBulkCopy.ColumnMappings.Add("AttachActImage", "AttachActImage");

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

        #endregion

        #region Cable Report

        [BindProperty]
        public CableReport GetCableReport { get; set; }


        public IActionResult CableReport()
        {
            return View(_electrical.GetAllCableReports());
        }


        public IActionResult CreateCablereport()
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var operating = _electrical.GetOperationModeSelectList();
            ViewBag.OperationMode = new SelectList(operating, "Value", "Text");

            var failedParts = _electrical.GetFailedPartsSelectList();
            ViewBag.FailedParts = new SelectList(failedParts, "Value", "Text");

            var typeofMaintenance = _electrical.GetTypeofMaintenanceSelectList();
            ViewBag.TypeofMaintenance = new SelectList(typeofMaintenance, "Value", "Text");

            var testType = _electrical.GetTestTypeSelectList();
            ViewBag.TestType = new SelectList(testType, "Value", "Text");

            return View();
        }


        [HttpPost]
        public IActionResult CreateCablereport(string Datefrom = "", string DateTo = "", string FailureDetctionDate = "", string StartDateMaintenance = "", string EndDateMaintenance = "")
        {
            if (Datefrom != "")
            {
                string[] std = Datefrom.Split('/', ' ');
                GetCableReport.Datefrom = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (DateTo != "")
            {
                string[] std = DateTo.Split('/', ' ');
                GetCableReport.DateTo = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (FailureDetctionDate != "")
            {
                string[] std = FailureDetctionDate.Split('/', ' ');
                GetCableReport.FailureDetctionDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (StartDateMaintenance != "")
            {
                string[] std = StartDateMaintenance.Split('/', ' ');
                GetCableReport.StartDateMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (EndDateMaintenance != "")
            {
                string[] std = EndDateMaintenance.Split('/', ' ');
                GetCableReport.EndDateMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.AddReportCable(GetCableReport);
            return Json(" Electormotors Successfully Deleted.");

        }



        public IActionResult DeleteCablereport(string[] reportId)
        {
            foreach (string id in reportId)
            {
                _electrical.DeleteCablereport(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }


        public IActionResult EditCableReport(int id)
        {
            var groups = _electrical.GetGroupForManageCableGroup();
            ViewBag.CableGroup = new SelectList(groups, "Value", "Text");

            var subGrous = _electrical.GetCableIdentitySelectList();
            ViewBag.CableID = new SelectList(subGrous, "Value", "Text");

            var owners = _electrical.GetOwners();
            ViewBag.Owner = new SelectList(owners, "Value", "Text");

            var operating = _electrical.GetOperationModeSelectList();
            ViewBag.OperationMode = new SelectList(operating, "Value", "Text");

            var failedParts = _electrical.GetFailedPartsSelectList();
            ViewBag.FailedParts = new SelectList(failedParts, "Value", "Text");

            var typeofMaintenance = _electrical.GetTypeofMaintenanceSelectList();
            ViewBag.TypeofMaintenance = new SelectList(typeofMaintenance, "Value", "Text");

            var testType = _electrical.GetTestTypeSelectList();
            ViewBag.TestType = new SelectList(testType, "Value", "Text");

            return View(_electrical.GetCableReportById(id));
        }

        [HttpPost]
        public IActionResult EditCableReport(string Datefrom = "", string DateTo = "", string FailureDetctionDate = "", string StartDateMaintenance = "", string EndDateMaintenance = "")
        {
            if (Datefrom != "")
            {
                string[] std = Datefrom.Split('/', ' ');
                GetCableReport.Datefrom = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (DateTo != "")
            {
                string[] std = DateTo.Split('/', ' ');
                GetCableReport.DateTo = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (FailureDetctionDate != "")
            {
                string[] std = FailureDetctionDate.Split('/', ' ');
                GetCableReport.FailureDetctionDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (StartDateMaintenance != "")
            {
                string[] std = StartDateMaintenance.Split('/', ' ');
                GetCableReport.StartDateMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            if (EndDateMaintenance != "")
            {
                string[] std = EndDateMaintenance.Split('/', ' ');
                GetCableReport.EndDateMaintenance = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2])
                );
            }

            _electrical.UpdateReportCable(GetCableReport);
            return Json(" Electormotors Successfully Deleted.");
        }

        [HttpPost]
        public IActionResult ExportCableReport(string reportId)
        {
            if (reportId == null)
            {
                var chemistryDocument = _electrical.GetAllCableReportsForExcel().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws=wb.Worksheets.Add(Commons.ToDataTable(chemistryDocument.ToList()));
                    ws.Name = "Cable Report";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cable Report.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<CableReportViewModel>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var chemistryDocument = _electrical.GetCableReportByIdForExcel(Convert.ToInt32(id));
                    res.Add(chemistryDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                   var ws= wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    ws.Name = "Cable Report";
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cable Report.xlsx");
                    }
                }
            }
            //return RedirectToAction("index");
        }




        [HttpPost]
        public async Task<IActionResult> ImportCableReportExcelFile(IFormFile FormFile)
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
            conString = @"Data Source=87.236.215.209;Initial Catalog=bnppDBNew;Integrated Security=False;Persist Security Info=False;User ID=bnppuser;Password=1234@qweR1234@qweR";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name.
                    sqlBulkCopy.DestinationTableName = "dbo.CableReports";

                    // Map the Excel columns with that of the database table, this is optional but good if you do

                    //sqlBulkCopy.ColumnMappings.Add("ID", "ID");

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

        #endregion

        //public IActionResult GetSubGroups(int id)
        //{
        //    List<SelectListItem> list = new List<SelectListItem>()
        //    {
        //        new SelectListItem(){Text = "Select",Value = ""}
        //    };
        //    list.AddRange(_electrical.GetSubGroupForManageCablId(id));
        //    return Json(new SelectList(list, "Value", "Text"));
        //}

        #region Owner

        [BindProperty]
        public Owner GetOwner { get; set; }


        
        public IActionResult Owner(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllOwners());
        }


        //public IActionResult CreateOwner(int code)
        //{
        //    ViewBag.Code = code;
        //    return View();
        //}

        public IActionResult CreateOwner()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateOwner(Owner owner)
        {
            _electrical.AddOwner(GetOwner);
            return Json(" Electormotors Successfully Deleted.");
        }

        //public IActionResult EditOwner(int id,int code)
        //{
        //    ViewBag.Code = code;
        //    return View(_electrical.GetOwnerById(id));
        //}

        public IActionResult EditOwner(int id)
        {
            return View(_electrical.GetOwnerById(id));
        }

        [HttpPost]
        public IActionResult EditOwner()
        {
            _electrical.UpdateOwner(GetOwner);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteOwner(string[] ownerId)
        {
            foreach (string id in ownerId)
            {
                _electrical.DeleteOwner(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region TypeofCable


        [BindProperty]
        public TypeofCable GetTypeofCable { get; set; }

        public IActionResult TypeofCable()
        {
            return View(_electrical.GetAllTypeofCable());
        }

        public IActionResult CreateTypeofCable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTypeofCable(TypeofCable cable)
        {
            _electrical.AddTypeofCable(GetTypeofCable);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditTypeofCable(int id)
        {
            return View(_electrical.GetTypeofCableById(id));
        }

        [HttpPost]
        public IActionResult EditTypeofCable()
        {
            _electrical.UpdateTypeofCable(GetTypeofCable);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteTypeofCable(string[] typeId)
        {
            foreach (string id in typeId)
            {
                _electrical.DeleteCableType(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }
        #endregion

        #region Classification of cable on the basis of Voltage

        [BindProperty]
        public ClassificationVoltage GetVoltage { get; set; }

        public IActionResult ClassificationVoltage()
        {
            return View(_electrical.GetAllClassification());
        }



        public IActionResult CreateVoltage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVoltage(ClassificationVoltage classification)
        {
            _electrical.AddVoltage(GetVoltage);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditVoltage(int id)
        {
            return View(_electrical.GetVoltageById(id));
        }

        [HttpPost]
        public IActionResult EditVoltage()
        {
            _electrical.UpdateVoltage(GetVoltage);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteClassificationVoltage(string[] voltageId)
        {
            foreach (string id in voltageId)
            {
                _electrical.deleteVoltage(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }
        #endregion

        #region List of Cable

        [BindProperty]
        public ListofCable GetCableList { get; set; }

        public IActionResult ListofCable()
        {
            return View(_electrical.GetAllListofCable());
        }



        public IActionResult CreateListofCable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateListofCable(ListofCable list)
        {
            _electrical.AddListofCable(GetCableList);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditListofCable(int id)
        {
            return View(_electrical.GetListofCableById(id));
        }

        [HttpPost]
        public IActionResult EditListofCable()
        {
            _electrical.UpdateListofCable(GetCableList);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteListofCable(string[] listId)
        {
            foreach (string id in listId)
            {
                _electrical.DeleteListofCable(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }
        #endregion

        #region Insulation material

        [BindProperty]
        public InsulationMaterial GetInsulationMaterial { get; set; }

        public IActionResult InsulationMaterial()
        {
            return View(_electrical.GetAllInsulationMaterial());
        }

        public IActionResult CreateInsulationMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInsulationMaterial(InsulationMaterial material)
        {
            _electrical.AddInsulationMaterial(GetInsulationMaterial);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditInsulationMaterial(int id)
        {
            return View(_electrical.GetInsulationMaterialById(id));
        }

        [HttpPost]
        public IActionResult EditInsulationMaterial()
        {
            _electrical.UpdateInsulationMaterial(GetInsulationMaterial);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteInsulationMaterial(string[] materialId)
        {
            foreach (string id in materialId)
            {
                _electrical.DeleteInsulationMaterial(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Jacket Material

        [BindProperty]
        public JacketMaterial GetJacketMaterial { get; set; }

        public IActionResult JacketMaterial()
        {
            return View(_electrical.GetAllJacketMaterial());
        }


        public IActionResult CreateJacketMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateJacketMaterial(JacketMaterial material)
        {
            _electrical.AddJacketMaterial(GetJacketMaterial);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditJacketMaterial(int id)
        {
            return View(_electrical.GetJacketMaterialById(id));
        }

        [HttpPost]
        public IActionResult EditJacketMaterial()
        {
            _electrical.UpdateJacketMaterial(GetJacketMaterial);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteJacketMaterial(string[] jacketId)
        {
            foreach (string id in jacketId)
            {
                _electrical.DeleteJacketMaterial(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Manufacturer

        [BindProperty]
        public ManufacturerCable Manufacturer { get; set; }

        public IActionResult CableManufacturer()
        {
            return View(_electrical.GetAllManufacturer());
        }


        public IActionResult CreateManufacturer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateManufacturer(ManufacturerCable material)
        {
            _electrical.AddManufacturer(Manufacturer);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditManufacturer(int id)
        {
            return View(_electrical.GetManufacturerById(id));
        }

        [HttpPost]
        public IActionResult EditManufacturer()
        {
            _electrical.UpdateManufacturer(Manufacturer);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteManufacturer(string[] manufacturerId)
        {
            foreach (string id in manufacturerId)
            {
                _electrical.DeleteManufacturer(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Location

        [BindProperty]
        public CableLocation GetLocation { get; set; }

        public IActionResult Location()
        {
            return View(_electrical.GetAllCableLocation());
        }




        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLocation(CableLocation material)
        {
            _electrical.AddCableLocation(GetLocation);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditLocation(int id)
        {
            return View(_electrical.GetCableLocationById(id));
        }

        [HttpPost]
        public IActionResult EditLocation()
        {
            _electrical.UpdateCableLocation(GetLocation);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteLocation(string[] locationId)
        {
            foreach (string id in locationId)
            {
                _electrical.DeleteCableLocation(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }
        #endregion

        #region degradation mechanisms



        [BindProperty]
        public DegradationMechanisms GetMechanisms { get; set; }

        public IActionResult DegradationMechanisms()
        {
            return View(_electrical.GetAllDegradationMechanisms());
        }


        public IActionResult CreateDegradationMechanisms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDegradationMechanisms(DegradationMechanisms mechanisms)
        {
            _electrical.AddDegradationMechanisms(GetMechanisms);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditDegradationMechanisms(int id)
        {
            return View(_electrical.GetDegradationMechanismsById(id));
        }

        [HttpPost]
        public IActionResult EditDegradationMechanisms()
        {
            _electrical.UpdateDegradationMechanisms(GetMechanisms);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteDegradationMechanisms(string[] mechanismId)
        {
            foreach (string id in mechanismId)
            {
                _electrical.DeleteDegradationMechanisms(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Current

        [BindProperty]
        public CableCurrent GetCableCurrent { get; set; }

        public IActionResult Current(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllCableCurrent());
        }


        public IActionResult CreateCurrent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCurrent(DegradationMechanisms mechanisms)
        {
            _electrical.AddCableCurrent(GetCableCurrent);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditCurrent(int id)
        {
            return View(_electrical.GetCableCurrentById(id));
        }

        [HttpPost]
        public IActionResult EditCurrent()
        {
            _electrical.UpdateCableCurrent(GetCableCurrent);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteCurrent(string[] currentId)
        {
            foreach (string id in currentId)
            {
                _electrical.DeleteCableCurrent(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Cable ID


        [BindProperty]
        public CableIdentity GetIdentity { get; set; }

        public IActionResult CableID(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllCableIdentity());
        }


        public IActionResult CreateCableID()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCableID(DegradationMechanisms mechanisms)
        {
            _electrical.AddCableIdentity(GetIdentity);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditCableID(int id)
        {
            return View(_electrical.GetCableIdentityById(id));
        }

        [HttpPost]
        public IActionResult EditCableID()
        {
            _electrical.UpdateCableIdentity(GetIdentity);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteCableID(string[] cableId)
        {
            foreach (string id in cableId)
            {
                _electrical.DeleteCableIdentity(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Cable Group

        [BindProperty]
        public CableGroup GetGroup { get; set; }

        public IActionResult CableGroup(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllCableGroup());
        }


        public IActionResult CreateCableGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCableGroup(CableGroup cable)
        {
            _electrical.AddCableGroup(GetGroup);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditCableGroup(int id)
        {
            return View(_electrical.GetCableGroupById(id));
        }

        [HttpPost]
        public IActionResult EditCableGroup()
        {
            _electrical.UpdateCableGroup(GetGroup);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteCableGroup(string[] groupId)
        {
            foreach (string id in groupId)
            {
                _electrical.DeleteCableGroup(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Operation Mode

        [BindProperty]
        public OperationMode GetOperation { get; set; }

        public IActionResult OperationMode(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllOperationMode());
        }

        public IActionResult CreateOperationMode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOperationMode(OperationMode mode)
        {
            _electrical.AddOperationMode(GetOperation);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditOperationMode(int id)
        {
            return View(_electrical.GetOperationModeById(id));
        }

        [HttpPost]
        public IActionResult EditOperationMode()
        {
            _electrical.UpdateOperationMode(GetOperation);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteOperationMode(string[] modeId)
        {
            foreach (string id in modeId)
            {
                _electrical.DeleteOperationMode(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Method of Failure


        [BindProperty]
        public FailureDiscovery GetFailure { get; set; }


        public IActionResult MethodofFailure()
        {
            return View(_electrical.GetAllFailureDiscovery());
        }

        public IActionResult CreateMethodofFailure()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMethodofFailure(FailureDiscovery discovery)
        {
            _electrical.AddFailureDiscovery(GetFailure);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditMethodofFailure(int id)
        {
            return View(_electrical.GetFailureDiscoveryById(id));
        }

        [HttpPost]
        public IActionResult EditMethodofFailure()
        {
            _electrical.UpdateFailureDiscovery(GetFailure);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteMethodofFailure(string[] failureId)
        {
            foreach (string id in failureId)
            {
                _electrical.DeleteFailureDiscovery(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region  Failure Condition

        [BindProperty]
        public FailureCondition GetCondition { get; set; }


        public IActionResult FailureCondition()
        {
            return View(_electrical.GetAllFailureCondition());
        }

        public IActionResult CreateFailureCondition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFailureCondition(FailureCondition failure)
        {
            _electrical.AddFailureCondition(GetCondition);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditFailureCondition(int id)
        {
            return View(_electrical.GetFailureConditionById(id));
        }

        [HttpPost]
        public IActionResult EditFailureCondition()
        {
            _electrical.UpdateFailureCondition(GetCondition);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteFailureCondition(string[] conditionId)
        {
            foreach (string id in conditionId)
            {
                _electrical.DeleteFailureCondition(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Failed Parts

        [BindProperty]
        public FailedParts GetParts { get; set; }


        public IActionResult FailedParts(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllFailedParts());
        }

        public IActionResult CreateFailedParts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFailedParts(FailedParts failure)
        {
            _electrical.AddFailedParts(GetParts);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditFailedParts(int id)
        {
            return View(_electrical.GetFailedPartsById(id));
        }

        [HttpPost]
        public IActionResult EditFailedParts()
        {
            _electrical.UpdateFailedParts(GetParts);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteFailedParts(string[] partsId)
        {
            foreach (string id in partsId)
            {
                _electrical.DeleteFailedParts(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Type of Maintenance

        [BindProperty]
        public TypeofMaintenance GetMaintenance { get; set; }


        public IActionResult TypeofMaintenance(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllTypeofMaintenance());
        }

        public IActionResult CreateTypeofMaintenance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTypeofMaintenance(TypeofMaintenance maintenance)
        {
            _electrical.AddTypeofMaintenance(GetMaintenance);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditTypeofMaintenance(int id)
        {
            return View(_electrical.GetTypeofMaintenanceById(id));
        }

        [HttpPost]
        public IActionResult EditTypeofMaintenance()
        {
            _electrical.UpdateTypeofMaintenance(GetMaintenance);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteTypeofMaintenance(string[] maintenanceId)
        {
            foreach (string id in maintenanceId)
            {
                _electrical.DeleteTypeofMaintenance(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Type Tests

        [BindProperty]
        public TestType GetTest { get; set; }


        public IActionResult TestType(int codes)
        {
            ViewBag.Code = codes;
            return View(_electrical.GetAllTestType());
        }

        public IActionResult CreateTestType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestType(TestType type)
        {
            _electrical.AddTestType(GetTest);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditTestType(int id)
        {
            return View(_electrical.GetTestTypeById(id));
        }

        [HttpPost]
        public IActionResult EditTestType()
        {
            _electrical.UpdateTestType(GetTest);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteTestType(string[] typeId)
        {
            foreach (string id in typeId)
            {
                _electrical.DeleteTestType(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion

        #region Result

        [BindProperty]
        public ResaultCable GetResault { get; set; }


        public IActionResult Result()
        {
            return View(_electrical.GetAllResaultCable());
        }

        public IActionResult CreateResult()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateResult(TestType type)
        {
            _electrical.AddResaultCable(GetResault);
            return Json(" Electormotors Successfully Deleted.");
        }

        public IActionResult EditResult(int id)
        {
            return View(_electrical.GetResaultCableById(id));
        }

        [HttpPost]
        public IActionResult EditResult()
        {
            _electrical.UpdateResaultCable(GetResault);
            return Json(" Electormotors Successfully Deleted.");
        }


        public IActionResult DeleteResult(string[] resaultId)
        {
            foreach (string id in resaultId)
            {
                _electrical.DeleteResaultCable(Convert.ToInt32(id));
            }
            return new JsonResult("success");
        }

        #endregion


        #region importing code

        //public void CopyFiles(string sourcePath, string destinationPath)
        //{
        //    string[] files = System.IO.Directory.GetFiles(sourcePath);
        //    Parallel.ForEach(files, file =>
        //    {
        //        System.IO.File.Copy(file, System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(file)));

        //    });
        //}


        //[HttpPost]
        //public IActionResult UploadExcels(IFormFile FormFile)
        //{

        //    if (FormFile != null)
        //    {

        //        //Create a Folder.
        //        var UploadsRootFolder = Path.Combine(this._env.WebRootPath, "UploadsHekmatBathesFile");
        //        var UploadsRootFolderMain = Path.Combine(this._env.WebRootPath, "UploadsHekmatBathesFileMain");
        //        if (!Directory.Exists(UploadsRootFolder))
        //        {
        //            Directory.CreateDirectory(UploadsRootFolder);
        //        }
        //        if (!Directory.Exists(UploadsRootFolderMain))
        //        {
        //            Directory.CreateDirectory(UploadsRootFolderMain);
        //        }
        //        string FileExtension = Path.GetExtension(FormFile.FileName);
        //        string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension);
        //        var filePath = Path.Combine(UploadsRootFolder, NewFileName);
        //        var filePath2 = Path.Combine(UploadsRootFolderMain, NewFileName);

        //        using FileStream stream = new FileStream(filePath, FileMode.Create);

        //        FormFile.CopyTo(stream);

        //        System.IO.File.Copy(filePath, filePath2);

        //        string conString = string.Empty;
        //        switch (FileExtension)
        //        {
        //            case ".xls": //Excel 97-03.
        //                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath2 +
        //                            ";Extended Properties='Excel 8.0;HDR=YES'";
        //                break;
        //            case ".xlsx": //Excel 07 and above.
        //                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath2 +
        //                            ";Extended Properties='Excel 8.0;HDR=YES'";

        //                break;
        //        }
        //        //  string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\shatel\Lising.Web\wwwroot\UploadsHekmatExcel\SampleHekmatBatch.xlsx;Extended Properties='Excel 8.0;HDR=YES'";
        //        DataTable dt = new DataTable();
        //        conString = string.Format(conString, filePath);

        //        using (OleDbConnection connExcel = new OleDbConnection(conString))
        //        {
        //            using (OleDbCommand cmdExcel = new OleDbCommand())
        //            {
        //                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
        //                {
        //                    cmdExcel.Connection = connExcel;
        //                    connExcel.Open();
        //                    DataTable dtExcelSchema;
        //                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        //                    connExcel.Close();
        //                    connExcel.Open();
        //                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
        //                    odaExcel.SelectCommand = cmdExcel;
        //                    odaExcel.Fill(dt);
        //                    connExcel.Close();
        //                }
        //            }
        //        }


        //        List<ExcelInterior> excellist = new List<ExcelSample>();
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string errorMessage = "";
        //                ExcelSample objExcelSample = new ExcelSample();
        //                objExcelSample.Radif = dt.Rows[i]["ردیف"].ToString();
        //                objExcelSample.OrderID = dt.Rows[i]["شماره سفارش"].ToString();
        //                objExcelSample.FirstName = dt.Rows[i]["نام"].ToString();
        //                objExcelSample.LastName = dt.Rows[i]["نام خانوادگی"].ToString();
        //                objExcelSample.Mobile = dt.Rows[i]["موبایل"].ToString();
        //                objExcelSample.NationalCode = dt.Rows[i]["کد ملی"].ToString();
        //                objExcelSample.HekmatCardNo = dt.Rows[i]["شماره حکمت کارت"].ToString();
        //                objExcelSample.Product = dt.Rows[i]["نام محصول"].ToString();
        //                objExcelSample.Address = dt.Rows[i]["آدرس"].ToString();
        //                objExcelSample.PostalCode = dt.Rows[i]["کد پستی"].ToString();
        //                objExcelSample.Price = dt.Rows[i]["مبلغ"].ToString();
        //                objExcelSample.InstallmentCount = dt.Rows[i]["تعداد قسط"].ToString();
        //                if (objExcelSample.NationalCode == "" || objExcelSample.NationalCode.Length != 10)
        //                {
        //                    errorMessage += "کد ملی اشتباه" + "--";
        //                }
        //                if (objExcelSample.HekmatCardNo == "" || objExcelSample.HekmatCardNo.Length != 16 || objExcelSample.HekmatCardNo == null)
        //                {
        //                    errorMessage += "شماره حکمت کارت اشتباه می باشد" + "--";
        //                }
        //                if (objExcelSample.InstallmentCount == "")
        //                {
        //                    errorMessage += "تعداد اقساط اشتباه می باشد" + "--";
        //                }
        //                if (objExcelSample.Price == "")
        //                {
        //                    errorMessage += "مبلغ تراکنش" + "--";
        //                }
        //                if (objExcelSample.OrderID == "")
        //                {
        //                    errorMessage += "شماره تراکنش اشتباه می باشد" + "--";
        //                }
        //                objExcelSample.Message = errorMessage;
        //                objExcelSample.Status = 0;
        //                if (objExcelSample.Message != "")
        //                {
        //                    objExcelSample.Status = 1;
        //                }
        //                excellist.Add(objExcelSample);
        //            }
        //        }



        //        ViewBag.HekmatResult = excellist;
        //        ViewBag.HekmatOrders = JsonConvert.SerializeObject(excellist);
        //        ViewBag.HasError = "0";
        //        if (excellist.Any(p => p.Status == 1))
        //        {
        //            ViewBag.HasError = "1";
        //        }
        //        ViewBag.Message = "";
        //        //return View();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.HekmatOrders = null;
        //    ViewBag.HasError = "1";
        //    ViewBag.Message = "لطفا فایل  اکسل انتخابی را آپلود نمایید.";
        //    //return View();
        //    return RedirectToAction("Index");
        //}


        
        //public IActionResult AddBulkTransactionTodatabase(List<ExcelSample> model)
        //{


        //    ViewBag.HekmatOrders = model;
        //    ViewBag.BulkTransaction = JsonConvert.DeserializeObject<List<ExcelSample>>(HekmatOrders);
        //    ViewBag.ShowOrderResult = false;
        //    return View();
        //}


        #endregion
    }
}
