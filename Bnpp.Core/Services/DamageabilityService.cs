using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Bnpp.DataLayer.Migrations.Chemistry;

namespace Bnpp.Core.Services
{
    public class DamageabilityService : IDamageabilityService
    {
        private BnppContext _context;
        public DamageabilityService(BnppContext context)
        {
            _context = context;
        }

        public int AddInitialData(InitialData initial)
        {
            initial.CreateDate = DateTime.Now;
            _context.Add(initial);
            _context.SaveChanges();

            return initial.ID;
        }

        public List<InitialData> GetAllInitialData()
        {
            return _context.initialData.ToList();
        }

        public int AddNewDamageabilityReport(DamageabilityReport report)
        {
            report.CreateDate = DateTime.Now;

            _context.Add(report);
            _context.SaveChanges();

            return report.ID;
        }

        public void DeleteDamageabilityReport(int reportId)
        {
            var damageReport = GetDamageabilityReportById(reportId);
            damageReport.IsDelete = true;
            _context.Update(damageReport);
            _context.SaveChanges();
        }



        public List<DamageabilityReport> GetAllReportsSortByReportDate(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

			//if (!string.IsNullOrEmpty(filter))
			//{
			//    result = result.Where(c => c.Akz.Contains(filter));
			//}

			//if (!string.IsNullOrEmpty(date))
			//{
			//    var date1 = DateTime.Parse(date);
			//    result = result.Where(c => c.ReportDate.Date == date1.Date);
			//}

			//if (!string.IsNullOrEmpty(fileDate))
			//{
			//    var datefile = DateTime.Parse(fileDate);
			//    result = result.Where(c => c.CreateDate.Date == datefile.Date);
			//}
			return result.Take(98).OrderBy(r => r.CreateDate).ToList();
            //var cvount = res.Count();
            //return res;

            //return result.Where(r => r.IsDelete == false).Take(98).OrderByDescending(r => r.ReportDate).ToList();
        }

        public List<DamageabilityReport> GetAllReportsForCompare(DateTime date)
        {
            //var date1 = DateTime.Parse(date);

            return _context.DamageabilityReports.Where(r => r.ReportDate.Date == date.Date && r.IsDelete == false).Take(98).ToList();
        }

        public List<ReportListViewModel> GetAllTotalReports()
        {
            //var max = _context.DamageabilityReports.Max(m => m.CreateDate.Date);


            //return _context.DamageabilityReports.Where(b => b.IsDelete == false && b.CreateDate.Date == max).Select(t => new ReportListViewModel()
            //{
            //    ID = t.ID,
            //    Totaldamageabilityofequipment = t.Totaldamageabilityofequipment
            //}).Take(98).ToList();

            var max = _context.DamageabilityReports.Where(r => r.IsDelete == false).Max(m => m.ReportDate.Date);


            return _context.DamageabilityReports.Where(b => b.IsDelete == false && b.ReportDate.Date == max).Select(t => new ReportListViewModel()
            {
                ID = t.ID,
                Totaldamageabilityofequipment = t.Totaldamageabilityofequipment
            }).Take(98).ToList();
        }

        public DamageabilityReport GetDamageabilityReportById(int reportId)
        {
            return _context.DamageabilityReports.Find(reportId);
        }

        public DamageabilityReport GetDamageabilityReportForUseSomeData()
        {
            var min = _context.DamageabilityReports.Where(r => r.IsDelete == false).Min(m => m.ID);
            return _context.DamageabilityReports.FirstOrDefault(d => d.ID == min);
        }

        public void UpdateDamageabilityReport(string allowableCuf, string allowableLifeTime, string allowablechangingratio, int reportId)
        {

            #region Edit AllowableCUF & AllowableLifeTime in all of records

            //var totality = _context.DamageabilityReports.ToList();

            //foreach (var report in totality)
            //{
            //    report.AllowableCUF = allowableCuf;
            //    report.AllowableLifeTime = allowableLifeTime;
            //    _context.Update(report);
            //    _context.SaveChanges();
            //}

            #endregion

            //var report =GetDamageabilityReportById(reportId);
            //var dateOfReport = report.CreateDate.Date;

            //var firstRecord=_context.DamageabilityReports.FirstOrDefault(r=>r.CreateDate.Date==dateOfReport).ID;

            //var numberofRow = reportId - firstRecord;

            var firstId = _context.DamageabilityReports.Where(r => r.IsDelete == false).Min(i => i.ID);

            var difference = reportId - firstId;
            var number = difference % 98;

            var endId = _context.DamageabilityReports.Max(i => i.ID);
            var start = firstId + number;

            for (int i = start; i <= endId; i += 98)
            {
                var editingreport = GetDamageabilityReportById(i);
                editingreport.AllowableCUF = allowableCuf;
                editingreport.AllowableLifeTime = allowableLifeTime;
                editingreport.AllowableChangingRatio = allowablechangingratio;
                _context.Update(editingreport);
                _context.SaveChanges();
            }

        }

        public InitialData GetInitialDataForUseSomeData()
        {
            var min = _context.DamageabilityReports.Where(r => r.IsDelete == false).Min(m => m.CreateDate.Date);
            return _context.initialData.FirstOrDefault(d => d.CreateDate.Date == min);

        }

        #region SORTING

        public List<DamageabilityReport> GetAllReportsSortByActionperiodofequipment(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).Take(98).OrderByDescending(r => r.Actionperiodofequipment).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).Take(98).OrderByDescending(r => r.Locationofthecheckpoint).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.LifetimeofequipmentperRALDS).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.Lifetimeofequipmentindesign).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.Damageabilitypercoiledcycles).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.Damageabilityperuncoiledcycles).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.Totaldamageabilityofequipment).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAllowableCUF(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.AllowableCUF).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.AllowableLifeTime).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByChangingRatio(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.ChangingRatio).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAllowableChangingRatio(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.AllowableChangingRatio).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByFileDate(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.CreateDate).ToList();
        }



        #endregion

        #region Order By Ascending

        public List<DamageabilityReport> GetAllReportsSortByAscendingReportDate(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.ReportDate).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Locationofthecheckpoint).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingActionperiodofequipment(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Actionperiodofequipment).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Lifetimeofequipmentindesign).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.LifetimeofequipmentperRALDS).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Damageabilitypercoiledcycles).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Damageabilityperuncoiledcycles).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.Totaldamageabilityofequipment).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingAllowableCUF(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.AllowableCUF).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.AllowableLifeTime).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingChangingRatio(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.ChangingRatio).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingAllowableChangingRatio(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.AllowableChangingRatio).ToList();
        }

        public List<DamageabilityReport> GetAllReportsSortByAscendingFileDate(string filter = "", string date = "", string fileDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(date))
            {
                var date1 = DateTime.Parse(date);
                result = result.Where(c => c.ReportDate.Date == date1.Date);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderBy(r => r.CreateDate).ToList();
        }



        #endregion



        public int GetNumberOfUploadedList()
        {
            var number = _context.DamageabilityReports.Where(r => r.IsDelete == false).Count();

            var NumberOfUploadedList = number / 98;
            return NumberOfUploadedList;
        }

        public List<DamageabilityReport> GetAllDataForExportToExcel()
        {
            return _context.DamageabilityReports.Where(r => r.IsDelete == false).ToList();
        }

        #region New Sorting

        public List<DamageabilityReport> GetOrderByDescendingDataByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.ReportDate).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.ReportDate).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingLocationofthecheckpointByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Locationofthecheckpoint).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Locationofthecheckpoint).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingActionperiodofequipmentByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Actionperiodofequipment).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Actionperiodofequipment).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Lifetimeofequipmentindesign).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Lifetimeofequipmentindesign).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.LifetimeofequipmentperRALDS).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.LifetimeofequipmentperRALDS).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingDamageabilitypercoiledcyclesByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Damageabilitypercoiledcycles).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Damageabilitypercoiledcycles).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ(string akz, int take, int kind)
        {

            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Damageabilityperuncoiledcycles).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Damageabilityperuncoiledcycles).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingTotaldamageabilityofequipmentByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.Totaldamageabilityofequipment).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.Totaldamageabilityofequipment).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingAllowableCUFByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.AllowableCUF).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.AllowableCUF).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingAllowableRemainingLifeTimeByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.AllowableLifeTime).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.AllowableLifeTime).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingChangingRatioByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.ChangingRatio).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.ChangingRatio).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingAllowableChangingRatioByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.AllowableChangingRatio).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.AllowableChangingRatio).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetOrderByDescendingFileDateByNumberOfAKZ(string akz, int take, int kind)
        {
            if (kind == 1)
            {
                return _context.DamageabilityReports.
                               Where(r => r.IsDelete == false && r.Akz == akz).
                               OrderByDescending(r => r.CreateDate).Take(take).ToList();
            }
            else
            {
                return _context.DamageabilityReports.
                    Where(r => r.IsDelete == false && r.Akz == akz).
                    OrderBy(r => r.CreateDate).Take(take).ToList();
            }
        }

        public List<DamageabilityReport> GetAllReportsForUploadNewReport()
        {
            return _context.DamageabilityReports.Where(r => r.IsDelete == false).OrderByDescending(r => r.ReportDate).ToList();
        }

        public List<DamageabilityReport> GetAllReportsForSearch(string filter = "", string startDate = "", string endDate = "", string fileDate = "", string allowableLifeTime = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Akz.Contains(filter));
            }

            if (!string.IsNullOrEmpty(allowableLifeTime))
            {
                result = result.Where(c => c.AllowableLifeTime.Contains(allowableLifeTime));
            }

            

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var stDate = DateTime.Parse(startDate);
                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.ReportDate.Date >= stDate.Date && c.ReportDate.Date <= edDate);
            }

            else if (!string.IsNullOrEmpty(startDate))
            {
                var stDate = DateTime.Parse(startDate);

                result = result.Where(c => c.ReportDate.Date >= stDate.Date);
            }

            else if (!string.IsNullOrEmpty(endDate))
            {

                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.ReportDate.Date <= edDate);
            }

            if (!string.IsNullOrEmpty(fileDate))
            {
                var datefile = DateTime.Parse(fileDate);
                result = result.Where(c => c.CreateDate.Date == datefile.Date);
            }

            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.ReportDate).ToList();
        }



        #endregion

        public List<DamageabilityReport> GetReportsFromDateToDate(string startDate = "", string endDate = "")
        {
            IQueryable<DamageabilityReport> result = _context.DamageabilityReports;

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var stDate = DateTime.Parse(startDate);
                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.ReportDate.Date >= stDate.Date && c.ReportDate.Date <= edDate);
            }

            else if (!string.IsNullOrEmpty(startDate))
            {
                var stDate = DateTime.Parse(startDate);

                result = result.Where(c => c.ReportDate.Date >= stDate.Date);
            }

            else if(!string.IsNullOrEmpty(endDate))
            {

                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.ReportDate.Date <= edDate);
            }

            return result.Where(r => r.IsDelete == false).ToList();
        }

        public List<DamageabilityReport> GetAllDataOfAkzForExportExcel(string akz)
        {
           return _context.DamageabilityReports.Where(r=>r.IsDelete==false && r.Akz==akz).ToList();
        }
    }
}
