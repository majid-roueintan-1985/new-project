using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;
using Bnpp.Core.Convertors;
using System.IO;
using System;
using System.Web;
using Bnpp.Core.Services;
using System.Linq;
using ClosedXML;
using ClosedXML.Excel;
using Bnpp.Core.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Bnpp.Web.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private IDamageabilityService _reportService;

        public ImportController(IDamageabilityService reportService)
        {
            _reportService = reportService;
        }

        //[Route("SACOR-446")]
        //public IActionResult Index()
        //{
        //    return View(_reportService.GetAllReports());
        //}

        //public IActionResult ListOfReports()
        //{

        //    IEnumerable<DamageabilityReport> allReports = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44340/api/ReportApi/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync("https://localhost:44340/api/ReportApi/");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<DamageabilityReport>>();
        //            readTask.Wait();

        //            allReports = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            allReports = Enumerable.Empty<DamageabilityReport>();

        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }

        //    return View(allReports);
        //}

        //public IActionResult ListOfReports(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        //{
        //    return View(_reportService.GetAllReports(filter, date, fileDate));
        //}

        [BindProperty] public DamageabilityReport Report { get; set; }

        [BindProperty] public List<DamageabilityReport> DamageReports { get; set; }



        #region SORTING By Descending


        [Route("SACOR-446")]
        public IActionResult Index(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }


        public IActionResult SortByByLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByActionperiodofequipment(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByAllowableCUF(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByChangingRatio(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByAllowableChangingRatio(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        public IActionResult SortByByByFileDate(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.NumberOfUploadedList = _reportService.GetNumberOfUploadedList();
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByReportDate(filter, date, fileDate));
        }

        #endregion

        #region SORTING By Ascending

        public IActionResult OrderByAscendingReportDate(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingReportDate(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingLocationofthecheckpoint(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingActionperiodofequipment(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingActionperiodofequipment(filter, date, fileDate));
        }


        public IActionResult OrderByAscendingLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingLifetimeofequipmentindesign(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingLifetimeofequipmentperRALDS(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingDamageabilitypercoiledcycles(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingDamageabilityperuncoiledcycles(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingTotaldamageabilityofequipment(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingAllowableCUF(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingAllowableCUF(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingAllowableRemainingLifeTime(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingChangingRatio(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingChangingRatio(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingAllowableChangingRatio(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingAllowableChangingRatio(filter, date, fileDate));
        }

        public IActionResult OrderByAscendingFileDate(string filter = "", string date = "", string fileDate = "", bool IsExistReport = false)
        {
            ViewBag.IsExistReport = IsExistReport;
            return View(_reportService.GetAllReportsSortByAscendingFileDate(filter, date, fileDate));
        }
        #endregion



        public IActionResult CreateDamageabilityReport()
        {
            return View();
        }


        public IActionResult EditDamageabilityReport(int id)
        {
            return View(_reportService.GetDamageabilityReportById(id));
        }



        [HttpPost]
        public IActionResult EditDamageabilityReport(string allowablecuf, string allowablelifetime, string allowablechangingratio, int id)
        {
            //if (!ModelState.IsValid)
            //    return View();


            _reportService.UpdateDamageabilityReport(allowablecuf, allowablelifetime, allowablechangingratio, id);
            return RedirectToAction("index");
        }


        public IActionResult DeleteDamageabilityReport(string[] damagingId)
        {
            foreach (string id in damagingId)
            {
                _reportService.DeleteDamageabilityReport(Convert.ToInt32(id));
            }
            return new JsonResult("success");

        }

        [HttpPost]
        public IActionResult CreateDamageabilityReport(IFormFile fileReport, string reportDates, string reportDate = "", string allowablecuf = "", string allowablelifetime = "", string Changingratio = "", string allowableChangingratio = "")
        {


            var totalReports = _reportService.GetAllReportsForUploadNewReport();

            var daterepo = reportDates.Substring(5, 10).ToString();
            DateTime dateForCompare = DateTime.MinValue;
            if (reportDates != "")
            {
                string[] std = daterepo.Split('_');
                dateForCompare = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new GregorianCalendar()
                );
            }

            if (totalReports.Count == 0)
            {

                //<------Add Initial data to Table----->

                InitialData initial = new InitialData();
                initial.AllowableCUF = allowablecuf;
                initial.AllowableLifeTime = allowablelifetime;
                initial.AllowableChangingRatio = allowableChangingratio;
                _reportService.AddInitialData(initial);

                //<------End Add Initial data to Table----->



                var Date = "";
                var Akz = "";
                var location = "";
                var Totaldamageabilityofequipment = "";
                var Damageabilityperuncoiledcycles = "";
                var Damageabilitypercoiledcycles = "";
                var LifetimeofequipmentperRALDS = "";
                var Lifetimeofequipmentindesign = "";
                var Actionperiodofequipment = "";

                DataTable datatable = new DataTable();

                var stream = fileReport.OpenReadStream();

                StreamReader streamreader = new StreamReader(stream);
                //StreamReader streamreader = new StreamReader(@"G:\New folder\bsh1_2021_10_06_damage.txt");
                char[] delimiter = new char[] { '\t' };
                string[] columnheaders = streamreader.ReadLine().Split(delimiter);

                foreach (string columnheader in columnheaders)
                {
                    datatable.Columns.Add(columnheader); // I've added the column headers here.
                }

                while (streamreader.Peek() > 0)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
                    datatable.Rows.Add(datarow);
                }


                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    //if (i == 2)
                    //{
                    //    var rowSelected = datatable.Rows[i][0].ToString();
                    //    var splitData = rowSelected.Substring(29).Trim().Split(" ");

                    //    Date = splitData[0];
                    //}


                    if (i > 17 && i < 116)
                    {

                        var rowSelected = datatable.Rows[i][0].ToString();
                        var Identifier = rowSelected.Substring(0, 9);
                        var splitData = rowSelected.Substring(9).Trim().Split("   ");


                        Akz = Identifier;
                        location = splitData[0];
                        Totaldamageabilityofequipment = splitData[splitData.Length - 1];
                        Damageabilityperuncoiledcycles = splitData[splitData.Length - 2];
                        Damageabilitypercoiledcycles = splitData[splitData.Length - 3];
                        LifetimeofequipmentperRALDS = splitData[splitData.Length - 4];
                        Lifetimeofequipmentindesign = splitData[splitData.Length - 5];
                        Actionperiodofequipment = splitData[splitData.Length - 6];

                        //اینجا اینزرت کن تو جدول 

                        DamageabilityReport report = new DamageabilityReport();
                        report.Totaldamageabilityofequipment = Totaldamageabilityofequipment;
                        report.Damageabilityperuncoiledcycles = Damageabilityperuncoiledcycles;
                        report.Damageabilitypercoiledcycles = Damageabilitypercoiledcycles;
                        report.LifetimeofequipmentperRALDS = LifetimeofequipmentperRALDS;
                        report.Lifetimeofequipmentindesign = Lifetimeofequipmentindesign;
                        report.Actionperiodofequipment = Actionperiodofequipment;
                        report.Locationofthecheckpoint = location;
                        report.AllowableCUF = allowablecuf;
                        report.AllowableLifeTime = allowablelifetime;
                        report.AllowableChangingRatio = allowableChangingratio;
                        report.Akz = Akz;
                        report.ReportDate = dateForCompare;


                        //report.ChangingRatio = Changingratio;

                        _reportService.AddNewDamageabilityReport(report);

                    }
                }
            }
            else
            {

                var compareforexistReport = _reportService.GetAllReportsForCompare(dateForCompare);

                if (compareforexistReport.Count != 0)
                {
                    return Redirect("/SACOR-446?IsExistReport=true");
                }
                else
                {
                    var beforeTotal = _reportService.GetAllTotalReports();

                    //var btotal = "";
                    //foreach (var p in beforeTotal)
                    //{
                    //    var bt = p.Totaldamageabilityofequipment;
                    //    btotal = bt;
                    //}

                    var Date = "";
                    var Akz = "";
                    var location = "";
                    var Totaldamageabilityofequipment = "";
                    var Damageabilityperuncoiledcycles = "";
                    var Damageabilitypercoiledcycles = "";
                    var LifetimeofequipmentperRALDS = "";
                    var Lifetimeofequipmentindesign = "";
                    var Actionperiodofequipment = "";

                    DataTable datatable = new DataTable();

                    var stream = fileReport.OpenReadStream();

                    StreamReader streamreader = new StreamReader(stream);
                    //StreamReader streamreader = new StreamReader(@"G:\New folder\bsh1_2021_10_06_damage.txt");
                    char[] delimiter = new char[] { '\t' };
                    string[] columnheaders = streamreader.ReadLine().Split(delimiter);

                    foreach (string columnheader in columnheaders)
                    {
                        datatable.Columns.Add(columnheader); // I've added the column headers here.
                    }

                    while (streamreader.Peek() > 0)
                    {
                        DataRow datarow = datatable.NewRow();
                        datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
                        datatable.Rows.Add(datarow);
                    }



                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        //if (i == 2)
                        //{
                        //    var rowSelected = datatable.Rows[i][0].ToString();
                        //    var splitData = rowSelected.Substring(29).Trim().Split(" ");

                        //    Date = splitData[0];
                        //}



                        if (i > 17 && i < 116)
                        {
                            var rowSelected = datatable.Rows[i][0].ToString();
                            var Identifier = rowSelected.Substring(0, 9);
                            var splitData = rowSelected.Substring(9).Trim().Split("   ");

                            Akz = Identifier;
                            location = splitData[0];
                            Totaldamageabilityofequipment = splitData[splitData.Length - 1];
                            Damageabilityperuncoiledcycles = splitData[splitData.Length - 2];
                            Damageabilitypercoiledcycles = splitData[splitData.Length - 3];
                            LifetimeofequipmentperRALDS = splitData[splitData.Length - 4];
                            Lifetimeofequipmentindesign = splitData[splitData.Length - 5];
                            Actionperiodofequipment = splitData[splitData.Length - 6];

                            //اینجا اینزرت کن تو جدول 

                            DamageabilityReport report = new DamageabilityReport();
                            report.Totaldamageabilityofequipment = Totaldamageabilityofequipment;
                            report.Damageabilityperuncoiledcycles = Damageabilityperuncoiledcycles;
                            report.Damageabilitypercoiledcycles = Damageabilitypercoiledcycles;
                            report.LifetimeofequipmentperRALDS = LifetimeofequipmentperRALDS;
                            report.Lifetimeofequipmentindesign = Lifetimeofequipmentindesign;
                            report.Actionperiodofequipment = Actionperiodofequipment;
                            report.Locationofthecheckpoint = location;
                            report.Akz = Akz;
                            report.ReportDate = dateForCompare;

                            //report.ChangingRatio = Changingratio;

                            // ChangingRatio
                            var btotal = "";
                            var j = 18;
                            foreach (var p in beforeTotal)
                            {
                                if (i == j)
                                {
                                    var bt = p.Totaldamageabilityofequipment;
                                    btotal = bt;
                                }
                                j++;
                                //break;
                                //goto endofloop;
                            }
                            //endofloop:
                            if (Convert.ToDecimal(btotal) != 0)
                            {
                                decimal ratio = (Convert.ToDecimal(Totaldamageabilityofequipment) - Convert.ToDecimal(btotal)) / Convert.ToDecimal(btotal);
                                report.ChangingRatio = ratio.ToString();
                            }
                            //else
                            //{
                            //    report.ChangingRatio = Convert.ToDecimal(0);
                            //}

                            //AllowableCUF & AllowableLifeTime & AllowableChangingRatio

                            //var initialReport = _reportService.GetDamageabilityReportForUseSomeData();


                            //report.AllowableCUF = initialReport.AllowableCUF;
                            //report.AllowableLifeTime = initialReport.AllowableLifeTime;
                            //report.AllowableChangingRatio = initialReport.AllowableChangingRatio;

                            var initialReport = _reportService.GetInitialDataForUseSomeData();
                            report.AllowableCUF = initialReport.AllowableCUF;
                            report.AllowableLifeTime = initialReport.AllowableLifeTime;
                            report.AllowableChangingRatio = initialReport.AllowableChangingRatio;




                            _reportService.AddNewDamageabilityReport(report);

                        }
                    }
                }

            }
            //

            //return View();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult ExportSACOR()
        {
            var sacorreport = _reportService.GetAllReportsSortByReportDate().ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(sacorreport.ToList()));


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SACOR Report.xlsx");
                }
            }
            //return View();
        }



        [HttpPost]
        public IActionResult ExportAkz(string akz)
        {
            var sacorreport = _reportService.GetAllDataOfAkzForExportExcel(akz).ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(sacorreport.ToList()));


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SACOR Report.xlsx");
                }
            }
        }

        [HttpPost]
        public IActionResult Export(string reportId)
        {
            if (reportId == null)
            {
                var sacorreport = _reportService.GetAllDataForExportToExcel().ToList();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(Commons.ToDataTable(sacorreport.ToList()));


                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SACOR Report.xlsx");
                    }
                }
            }
            else
            {
                var res = new List<DamageabilityReport>();

                string[] std = reportId.Split(',');

                foreach (string id in std)
                {
                    var excelDocument = _reportService.GetDamageabilityReportById(Convert.ToInt32(id));
                    res.Add(excelDocument);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(Commons.ToDataTable(res.ToList()));
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);

                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SACOR-446.xlsx");
                    }
                }
            }
            //return RedirectToAction("index");
        }

        #region New Sorting
        public IActionResult OrderByDescendingDataByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;

            return View(_reportService.GetOrderByDescendingDataByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingLocationofthecheckpointByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingLocationofthecheckpointByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingActionperiodofequipmentByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingActionperiodofequipmentByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingDamageabilitypercoiledcyclesByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingDamageabilitypercoiledcyclesByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingTotaldamageabilityofequipmentByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingTotaldamageabilityofequipmentByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingAllowableCUFByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingAllowableCUFByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingAllowableRemainingLifeTimeByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingAllowableRemainingLifeTimeByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingChangingRatioByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingChangingRatioByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingAllowableChangingRatioByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingAllowableChangingRatioByNumberOfAKZ(akz, take, kind));
        }

        public IActionResult OrderByDescendingFileDateByNumberOfAKZ(string akz, int take, int kind)
        {
            ViewBag.AKZ = akz;
            return View(_reportService.GetOrderByDescendingFileDateByNumberOfAKZ(akz, take, kind));
        }
        #endregion


        [HttpPost]
        public IActionResult Search(string filter = "", string dateFrom = "", string dateTo = "", string fileDate = "", bool IsExistReport = false, string allowablelifetime = "")
        {
           

            if (fileDate != null)
            {
                string[] std = fileDate.Split('/');
                Report.CreateDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new GregorianCalendar()
                );
            }

            return View(_reportService.GetAllReportsForSearch(filter,dateFrom,dateTo, fileDate, allowablelifetime));
        }

        [HttpPost]
        public IActionResult SearchDatesFromTo(string dateFrom = "", string dateTo = "")
        {

            return View(_reportService.GetReportsFromDateToDate(dateFrom, dateTo));
        }
    }
}
