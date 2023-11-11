using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static Bnpp.Core.Services.ChemistryService;


namespace Bnpp.Core.Services
{
    public class ChemistryService : IChemistryService
    {
        private ChemistryContext _context;
        public ChemistryService(ChemistryContext context)
        {
            _context = context;
        }



        public List<ChemistryTable> GetAllChemistries(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "")
        {
            IQueryable<ChemistryTable> chemistry = _context.ChemistryTable;

            if (!string.IsNullOrEmpty(system))
            {
                system = system.Replace("\r\n", string.Empty);
                //system = system.Split(',').ToString();

                chemistry = chemistry.Where(c => c.System.Contains(system));
            }

            if (!string.IsNullOrEmpty(samplePoint))
            {
                samplePoint = samplePoint.Replace("\r\n", string.Empty);
                chemistry = chemistry.Where(c => c.SamplingPoint.Contains(samplePoint));
            }

            if (!string.IsNullOrEmpty(systemState))
            {
                systemState = systemState.Replace("\r\n", string.Empty);
                chemistry = chemistry.Where(c => c.SystemStateCaption.Contains(systemState));
            }

            if (!string.IsNullOrEmpty(cycle))
            {
                chemistry = chemistry.Where(c => c.CircuitCaption.Contains(cycle));
            }

            if (!string.IsNullOrEmpty(dateAndTime))
            {
                var datefile = DateTime.Parse(dateAndTime);
                chemistry = chemistry.Where(c => c.ExperimentDateTime.Date == datefile.Date);
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var stDate = DateTime.Parse(startDate);
                var edDate = DateTime.Parse(endDate);

                chemistry = chemistry.Where(c => c.ExperimentDateTime.Date >= stDate.Date && c.ExperimentDateTime.Date <= edDate);
            }

            if (!string.IsNullOrEmpty(parameter))
            {
                parameter = parameter.Replace("\r\n", string.Empty);
                //parameter = /*parameter.Replace("\n", string.Empty);*/
                chemistry = chemistry.Where(c => c.ParameterCaption.Contains(parameter));
            }



            //var chem = chemistry;

            return chemistry.Where(r => r.IsDelete == false).ToList();


            //For remove duplicate result
            //return chemistry.Where(r => r.IsDelete == false).Select(c=>new ChemistryTable()
            //{
            //    System=c.System
            //}).Distinct().ToList();
        }

        #region CHART

        public List<string> GetAllDatesForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "")
        {
            //return _context.ChemistryTable.Select(c=>c.ExperimentDateTime.Date.ToString("yyyyMMdd")).ToList();
            return GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parameter, startDate, endDate).Select(c => c.ExperimentDateTime.Date.ToString("yyyyMMdd")).ToList();
        }

        public List<string> GetAllValuesForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "")
        {
            //return _context.ChemistryTable.Select(c=> Convert.ToDecimal(c.Value.Replace("\r\n", string.Empty))).ToList();
            return GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parameter, startDate, endDate).
                Select(c => Convert.ToString(c.Value) ?? "0").ToList();
        }

        public List<string> GetAllNormalValues1ForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "")
        {
            //return _context.ChemistryTable.Select(c => Convert.ToDecimal(c.NormalValue.Replace("\r\n", string.Empty))).ToList();
            return GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parameter, startDate, endDate).
                Select(c => Convert.ToString(c.NormalValue) ?? "0").ToList();
        }

        public List<string> GetAllNormalValues2ForChart(string system = "", string samplePoint = "", string systemState = "", string cycle = "", string dateAndTime = "", string parameter = "", string startDate = "", string endDate = "")
        {
            return GetAllChemistries(system, samplePoint, systemState, cycle, dateAndTime, parameter, startDate, endDate)
                .Select(c => Convert.ToString(c.NormalValue2) ?? "0").ToList();
        }

        #endregion

        public ChemistryTable GetChemistryById(int id)
        {
            return _context.ChemistryTable.Find(id);
        }

        public ChemistryTable GetChemistryTableById(int chemistryId)
        {
            return _context.ChemistryTable.Find(chemistryId);
        }

        public List<Chart1ViewModel> GetDataForUseInChart()
        {
            return _context.ChemistryTable.Select(c => new Chart1ViewModel()
            {

                Value = c.Value.Replace("\r\n", string.Empty),
                //ComparisonWithNormalValueSymbol= Convert.ToInt32(c.ComparisonWithNormalValueSymbol),
                //ComparisonWithNormalValueSymbol2= Convert.ToInt32(c.ComparisonWithNormalValueSymbol2),
                //NormalValue= Convert.ToInt32(c.NormalValue),
                //NormalValue= c.NormalValue.Replace("\r\n", string.Empty),
                //Time=c.ExperimentDateTime
            }).ToList();
        }

        public List<SelectListItem> GetGroupForManageSearch()
        {
            return _context.ChemistryGroups.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageSearch(int groupId)
        {
            return _context.ChemistryGroups.Where(g => g.ParentId == groupId)
                 .Select(g => new SelectListItem()
                 {
                     Text = g.GroupTitle,
                     Value = g.GroupId.ToString()
                 }).ToList();
        }

        public List<ChemistryTable> GetSystems()
        {
            return _context.ChemistryTable.Where(c => c.IsDelete == false).
                Select(s => new ChemistryTable() { System = s.System }).Distinct().ToList();
        }

        public List<ChemistryViewModel> GetAllChemistriesForExcel()
        {
            return _context.ChemistryTable.Where(m => m.IsDelete == false).Select(c => new ChemistryViewModel()
            {
                //ID=c.ID,
                System = c.System,
                SamplingPoint = c.SamplingPoint,
                Building = c.Building,
                SystemStateCaption = c.SystemStateCaption,
                CircuitCaption = c.CircuitCaption,
                ExperimentDateTime = c.ExperimentDateTime,
                ParameterCaption = c.ParameterCaption,
                Value = c.Value,
                UnitCaption = c.UnitCaption,
                ComparisonWithNormalValueSymbol = c.ComparisonWithNormalValueSymbol,
                NormalValue = c.NormalValue,
                ComparisonWithNormalValueSymbol2 = c.ComparisonWithNormalValueSymbol2,
                NormalValue2 = c.NormalValue2,
                ExecutingScheduleCaption = c.ExecutingScheduleCaption,
                NoteCaption = c.NoteCaption
            }).ToList();
        }

        public ChemistryViewModel GetChemistryTableByIdForExcel(int chemistryId)
        {
            var chemistry = GetChemistryTableById(chemistryId);

            ChemistryViewModel chemistryViewModel = new ChemistryViewModel();

            chemistryViewModel.System = chemistry.System;
            chemistryViewModel.SamplingPoint = chemistry.SamplingPoint;
            chemistryViewModel.Building = chemistry.Building;
            chemistryViewModel.SystemStateCaption = chemistry.SystemStateCaption;
            chemistryViewModel.CircuitCaption = chemistry.CircuitCaption;
            chemistryViewModel.ExperimentDateTime = chemistry.ExperimentDateTime;
            chemistryViewModel.ParameterCaption = chemistry.ParameterCaption;
            chemistryViewModel.Value = chemistry.Value;
            chemistryViewModel.UnitCaption = chemistry.UnitCaption;
            chemistryViewModel.ComparisonWithNormalValueSymbol = chemistry.ComparisonWithNormalValueSymbol;
            chemistryViewModel.NormalValue = chemistry.NormalValue;
            chemistryViewModel.ComparisonWithNormalValueSymbol2 = chemistry.ComparisonWithNormalValueSymbol2;
            chemistryViewModel.NormalValue2 = chemistry.NormalValue2;
            chemistryViewModel.ExecutingScheduleCaption = chemistry.ExecutingScheduleCaption;
            chemistryViewModel.NoteCaption = chemistry.NoteCaption;

            return chemistryViewModel;
        }
    }
}
