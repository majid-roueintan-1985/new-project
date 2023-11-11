using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IChemistryService
    {
       
        List<ChemistryTable> GetAllChemistries(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "");
        List<ChemistryTable> GetSystems();
        List<SelectListItem> GetGroupForManageSearch();
        List<SelectListItem> GetSubGroupForManageSearch(int groupId);

        ChemistryTable GetChemistryById(int id);

        List<ChemistryViewModel> GetAllChemistriesForExcel();

        #region CHART

        List<string> GetAllValuesForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "");

        List<string> GetAllNormalValues1ForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "");

        List<string> GetAllNormalValues2ForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "");
       
        List<string> GetAllDatesForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "");

        #endregion
        List<Chart1ViewModel> GetDataForUseInChart();

        ChemistryTable GetChemistryTableById(int chemistryId);
        ChemistryViewModel GetChemistryTableByIdForExcel(int chemistryId);
    }
}
