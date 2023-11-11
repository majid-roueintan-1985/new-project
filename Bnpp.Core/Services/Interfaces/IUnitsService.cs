using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IUnitsService
    {
        List<SelectListItem> GetUnitGroupForManageCourse();
        List<SelectListItem> GetUnitSubGroupForManageCourse(int unitId);

        IEnumerable<Units> GetListOfGroups();
        IEnumerable<Units> GetAllGroups();
        int AddNewUnit(Units groups);
        bool IsExistParameter(string title);

		void DeleteUnitGroup(int unitGroupId);

	}
}
