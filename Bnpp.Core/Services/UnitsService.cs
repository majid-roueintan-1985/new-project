using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bnpp.Core.Services
{
    public class UnitsService: IUnitsService
    {
        private BnppContext _context;

        public UnitsService(BnppContext context)
        {
            _context = context;
        }

        public int AddNewUnit(Units groups)
        {
            _context.Add(groups);
            _context.SaveChanges();
            return groups.UnitId;
        }

        public IEnumerable<Units> GetAllGroups()
        {
            return _context.Units.Where(t => t.IsDelete == false).OrderByDescending(t => t.UnitTitle).ToList();
        }

        public IEnumerable<Units> GetListOfGroups()
        {
            return _context.Units.Where(t => t.IsDelete == false && t.ParentId == null).OrderBy(t => t.UnitTitle).ToList();
        }

        public bool IsExistParameter(string title)
        {
            return _context.Units.Any(t => t.IsDelete == false && t.UnitTitle==title);
        }

        public List<SelectListItem> GetUnitGroupForManageCourse()
        {
            return _context.Units.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.UnitTitle,
                    Value = g.UnitId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetUnitSubGroupForManageCourse(int unitId)
        {
            return _context.Units.Where(g => g.ParentId == unitId)
               .Select(g => new SelectListItem()
               {
                   Text = g.UnitTitle,
                   Value = g.UnitId.ToString()
               }).ToList();
        }

		public void DeleteUnitGroup(int unitGroupId)
		{
            var unitGroup = _context.Units.Find(unitGroupId);
			unitGroup.IsDelete = true;
			_context.Update(unitGroup);
			_context.SaveChanges();
		}
	}
}
