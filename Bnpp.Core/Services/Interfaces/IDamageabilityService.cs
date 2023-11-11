using Bnpp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IDamageabilityService
    {
        List<ReportListViewModel> GetAllTotalReports();

        int GetNumberOfUploadedList();

        #region Sort Table OrderBy Descending
        List<DamageabilityReport> GetAllReportsSortByReportDate(string filter = "",string date="",string fileDate="");
        List<DamageabilityReport> GetAllReportsSortByLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByActionperiodofequipment(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByAllowableCUF(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByChangingRatio(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByAllowableChangingRatio(string filter = "", string date = "", string fileDate = "");
        List<DamageabilityReport> GetAllReportsSortByFileDate(string filter = "", string date = "", string fileDate = "");
        #endregion

        #region Order By Ascending

       
        List<DamageabilityReport> GetAllReportsSortByAscendingReportDate(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingLocationofthecheckpoint(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingActionperiodofequipment(string filter = "", string date = "", string fileDate = "");
        
        List<DamageabilityReport> GetAllReportsSortByAscendingLifetimeofequipmentindesign(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingLifetimeofequipmentperRALDS(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingDamageabilitypercoiledcycles(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingDamageabilityperuncoiledcycles(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingTotaldamageabilityofequipment(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingAllowableCUF(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingAllowableRemainingLifeTime(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingChangingRatio(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingAllowableChangingRatio(string filter = "", string date = "", string fileDate = "");

        List<DamageabilityReport> GetAllReportsSortByAscendingFileDate(string filter = "", string date = "", string fileDate = "");

        #endregion

        List<DamageabilityReport> GetAllReportsForCompare(DateTime date);
        int AddNewDamageabilityReport(DamageabilityReport report);
        void UpdateDamageabilityReport(string allowableCuf,string allowableLifeTime,string allowablechangingratio, int reportId);
        DamageabilityReport GetDamageabilityReportById(int reportId);
        DamageabilityReport GetDamageabilityReportForUseSomeData();
        void DeleteDamageabilityReport(int reportId);

        int AddInitialData(InitialData initial);
        List<InitialData> GetAllInitialData();
        InitialData GetInitialDataForUseSomeData();
        List<DamageabilityReport> GetAllDataOfAkzForExportExcel(string akz);
        #region New Sorting
       List<DamageabilityReport> GetOrderByDescendingDataByNumberOfAKZ(string akz, int take ,int kind);
        List<DamageabilityReport> GetOrderByDescendingLocationofthecheckpointByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingActionperiodofequipmentByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingDamageabilitypercoiledcyclesByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingTotaldamageabilityofequipmentByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingAllowableCUFByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingAllowableRemainingLifeTimeByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingChangingRatioByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingAllowableChangingRatioByNumberOfAKZ(string akz, int take, int kind);
        List<DamageabilityReport> GetOrderByDescendingFileDateByNumberOfAKZ(string akz, int take, int kind);
        
        #endregion
        List<DamageabilityReport> GetAllDataForExportToExcel();

        List<DamageabilityReport> GetAllReportsForUploadNewReport();

        List<DamageabilityReport> GetAllReportsForSearch(string filter = "", string startDate = "", string endDate = "", string fileDate = "",string allowableLifeTime="");
        List<DamageabilityReport> GetReportsFromDateToDate(string startDate = "", string endDate = "");
    }
}
