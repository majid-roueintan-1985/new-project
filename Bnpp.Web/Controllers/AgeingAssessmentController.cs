using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Migrations.Chemistry;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using System;
using Bnpp.Core.Services;
using Bnpp.Core.Convertors;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Bnpp.Web.Controllers
{
    public class AgeingAssessmentController : Controller
    {
        private ITransientService _service;
        private IDamageabilityService _reportService;
        private IChemistryService _chemistryService;
        public AgeingAssessmentController(ITransientService service, IDamageabilityService reportService, IChemistryService chemistryService)
        {
            _service = service;
            _reportService = reportService;
            _chemistryService = chemistryService;
        }

        [BindProperty] public DamageabilityReport Report { get; set; }


        [Route("Ageing Assessment")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SACORReport()
        {
            return View();
        }
        public IActionResult TransientsReport()
        {
            return View(_service.GetGroupedTransients());
        }


        public IActionResult WaterChemistryReport(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string dateFrom = "", string dateTo = "")
        {
            ViewBag.System = system;
            ViewBag.SampleePoints = samplePoint;
            ViewBag.SystemState = systemState;
            ViewBag.Cycle = cycle;
            ViewBag.DateAndTime = dateAndTime;
            ViewBag.Parameters = parameter;
            ViewBag.DateFrom = dateFrom;
            ViewBag.DateTo = dateTo;


            var groups = _chemistryService.GetGroupForManageSearch();
            ViewBag.SearchSystem = new SelectList(groups, "Value", "Text");

            var subGrous = _chemistryService.GetSubGroupForManageSearch(int.Parse(groups.First().Value));
            ViewBag.SamplePoint = new SelectList(subGrous, "Value", "Text");

            var secondSubGrous = _chemistryService.GetSubGroupForManageSearch(int.Parse(subGrous.First().Value));
            ViewBag.Parameter = new SelectList(secondSubGrous, "Value", "Text");

            return View();
        }


        [HttpPost]
        public IActionResult SearchChemistry(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parametr = "", string dateFrom = "", string dateTo = "")
        {
            if (parametr != null)
            {
                parametr = parametr.Replace("\n", string.Empty);
            }
            if (samplePoint != null)
            {
                samplePoint = samplePoint.Replace("\n", string.Empty);
            }

            if (systemState == " >50% ")
            {
                systemState = ">50%";
            }

            ViewBag.System = system;
            ViewBag.SamplePoint = samplePoint;
            ViewBag.SystemState = systemState; 
            ViewBag.Cycle = cycle;
            ViewBag.DateAndTime = dateAndTime;
            ViewBag.Parametr = parametr;
            ViewBag.DateFrom = dateFrom;
            ViewBag.DateTo = dateTo;

            return View(_chemistryService.GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parametr, dateFrom, dateTo));
        }
        public IActionResult TransientsPeriod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string filter = "", string dateFrom = "", string dateTo = "", string fileDate = "", bool IsExistReport = false, string allowablelifetime = "")
        {
            ViewBag.Filter = filter;
            ViewBag.DateFrom = dateFrom;
            ViewBag.DateTo = dateTo;
            ViewBag.FileDate = fileDate;



            if (fileDate != null)
            {
                string[] std = fileDate.Split('/');
                Report.CreateDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new GregorianCalendar()
                );
            }

            return View(_reportService.GetAllReportsForSearch(filter, dateFrom, dateTo, fileDate, allowablelifetime));
        }

        [HttpPost]
        public IActionResult SearchTramsients(string dateFrom = "", string dateTo = "")
        {


            //if (fileDate != null)
            //{
            //    string[] std = fileDate.Split('/');
            //    Report.CreateDate = new DateTime(int.Parse(std[0]),
            //        int.Parse(std[1]),
            //        int.Parse(std[2]),
            //        new GregorianCalendar()
            //    );
            //}

            return View(_service.GetAllTransientsForSearchInPeriod(dateFrom, dateTo));
        }

        [HttpPost]
        public IActionResult ExportSacorr(string filter = "", string dateFrom = "", string dateTo = "", string fileDate = "", bool IsExistReport = false, string allowablelifetime = "")
        {
            var sacorreport = _reportService.GetAllReportsForSearch(filter, dateFrom, dateTo, fileDate, allowablelifetime);
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
        public IActionResult ExportChemistry(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parametr = "", string dateFrom = "", string dateTo = "")
        {
            var sacorreport = _chemistryService.GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parametr, dateFrom, dateTo);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(sacorreport.ToList()));


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "water chemistry parameters Report.xlsx");
                }
            }
        }

        

        [HttpPost]
        public IActionResult ExportAllTransient(string filter = "", string dateFrom = "", string dateTo = "", string fileDate = "", bool IsExistReport = false, string allowablelifetime = "")
        {
            var sacorreport = _service.GetGroupedTransients();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Commons.ToDataTable(sacorreport.ToList()));


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "All Transient Report.xlsx");
                }
            }
        }

        
    }
}
