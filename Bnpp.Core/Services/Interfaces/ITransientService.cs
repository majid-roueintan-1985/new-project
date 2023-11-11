using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface ITransientService
    {

        #region Transient Group

        int AddNewTarnsientGroup(TransientGroups groups);
        TransientGroups GetTransientGroupsByParentId(int parentId, string groupTitle);
        TransientGroups GetTransientGroupsByTitle(string groupTitle);
        IEnumerable<TransientGroups> GetListOfGroups();
        IEnumerable<TransientGroups> GetAllGroups();
        List<TransientGroups> GetCodeForSearch(string code = "");
        List<TransientGroups> GetNameForSearch(string transientName = "");
        void DeleteTarnsientGroup(int tarnsientGroupId);
        TransientGroups GetGroupById(int groupId);
        TransientGroups GetGroupByGroupTitle(string groupTitle);
        TransientGroups CheckExistCode(string code);
        int GetGroupIdByGroupTitle(string groupTitle);
        TransientGroups GetTransientGroupByGroupId(int groupId);

        #endregion


        Transients GetTransientById(int transientId);
        SaveTransientsViewModel GetTransientByIdForExport(int transientId);

        void UpdateTransient(Transients transient);
        void DeleteTransient(int transientId);

        //int AddTransient(Transients transient, IFormFile transientFile);
        int AddTransient(Transients transient);
        int AddTransientDocument(TransientDocuments documents);

        IEnumerable<Transients> GetAllSavedTransient();
        IEnumerable<SaveTransientsViewModel> GetAllSavedTransientForExport();
        IEnumerable<TransientsListViewModel> GetGroupedTransients();

        List<Transients> GetAllTransientsForSearch(string startDate = "", string endDate = "");
        List<TransientsForSearchInPeriodViewModel> GetAllTransientsForSearchInPeriod(string startDate = "", string endDate = "");
        //int GetParentIdByName(string name);
        //IEnumerable<TransientGroups> GetAllNames();
        List<TransientDocuments> GetAllTransienDocument();
        List<TransientDocuments> GetTransientDocumentById(int id);

        void DeleteDocument(int documentId);
        TransientDocuments GetDocumentById(int documentId);

        List<Transients> GetTransientsByCode(string code);

        #region Grouped of Transient

        List<GroupedTransients> GetAllGroupedOfTransients();
        int AddGroupedTransient(GroupedTransients groupedTransients);
        void DeleteGroupedTransient(int groupedTransientId);
        GroupedTransients GetGroupedTransientsById(int groupId);
        bool IsExistCode(string code);


        List<GroupedTransients> SearchInGroupedOfTransient(string code = "");
        List<GroupedTransients> SearchInNameGroupedOfTransient(string name = "");

        GroupedTransients GetGroupedTransientByTitle(string groupTitle);
        List<SelectListItem> GetSubGroupForManageSearch(string code);
        List<Transients> GetGroupedTransientByCode(string groupTitle);
		#endregion

	}
}
