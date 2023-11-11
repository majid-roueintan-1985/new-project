using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.AgeingManagementDocuments;
using Bnpp.DataLayer.Migrations.Transient;
using Bnpp.DataLayer.ViewModels;
using Lms.Core.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;



namespace Bnpp.Core.Services
{
    public class TransientService : ITransientService
    {
        private TransientContext _context;
        public TransientService(TransientContext context)
        {
            _context = context;
        }

        //public int AddTransient(Transients transient, IFormFile transientFile)
        //{


        //    transient.CreateDate = DateTime.Now;
        //    transient.TransientFileName = transientFile.FileName;

        //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/transientFiles", transient.TransientFileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        transientFile.CopyTo(stream);
        //    }

        //    _context.Transients.Add(transient);
        //    _context.SaveChanges();
        //    return transient.TransientsId;
        //}

        public int AddNewTarnsientGroup(TransientGroups groups)
        {
            _context.Add(groups);
            _context.SaveChanges();
            return groups.GroupId;
        }


        public IEnumerable<TransientGroups> GetAllGroups()
        {
            return _context.TransientGroups.Where(t => t.IsDelete == false).OrderByDescending(t => t.GroupTitle).ToList();
        }

        //public IEnumerable<TransientGroups> GetAllNames()
        //{
        //    List<int> codes = _context.TransientGroups.Where(g => g.IsDelete == false && g.ParentId == null).Select(g=>(int?)g.ParentId ).ToList();

        //    return _context.TransientGroups.Where(g=>g.IsDelete==false && !codes).tol
        //}

        public List<TransientGroups> GetCodeForSearch(string code = "")
        {
            IQueryable<TransientGroups> result = _context.TransientGroups;

            if (!string.IsNullOrEmpty(code))
            {
                result = result.Where(c => c.ParentId == null && c.GroupTitle.Contains(code));
            }

            //var codes = _context.TransientGroups.SingleOrDefault(g => g.GroupTitle == code);
            //var groupIds = codes.GroupId;

            //var name = _context.TransientGroups.Where(r => r.ParentId == groupIds).ToList();

            //var myName= _context.TransientGroups.Single(r => r.ParentId == groupIds && r.GroupTitle== "test name 2");

            return result.ToList();
        }

        public IEnumerable<TransientGroups> GetListOfGroups()
        {
            return _context.TransientGroups.Where(t => t.IsDelete == false && t.ParentId == null).OrderBy(t => t.GroupTitle).ToList();
        }

        public List<TransientGroups> GetNameForSearch(string transientName = "")
        {
            IQueryable<TransientGroups> result = _context.TransientGroups;

            if (!string.IsNullOrEmpty(transientName))
            {
                result = result.Where(c => c.ParentId != null && c.GroupTitle.Contains(transientName));
            }


            return result.Where(r => r.IsDelete == false).ToList();
        }

        public IEnumerable<Transients> GetAllSavedTransient()
        {
            return _context.Transients.Where(t => t.IsDelete == false).ToList();
        }

        public IEnumerable<TransientsListViewModel> GetGroupedTransients()
        {

            var data = _context.Transients.Where(g => g.IsDelete == false).OrderBy(g => g.Code).Select(t => new TransientsViewModel()
            {
                Code = t.Code,
                Name = t.Name,
                AllowableNumber = t.AllowableNumber
            }).Distinct().ToList();

            List<TransientsListViewModel> values = new List<TransientsListViewModel>();

            foreach (var d in data)
            {
                var code = d.Code;

                var name = d.Name;

                var value = d.AllowableNumber;

                var count = _context.Transients.Where(t => t.Code == code).Count();

                values.Add(new TransientsListViewModel { Code = code, Name = name, Values = value, Count = count });
            }

            return values;
        }

        public TransientGroups CheckExistCode(string code)
        {
            return _context.TransientGroups.SingleOrDefault(g => g.IsDelete == false && g.GroupTitle == code);
        }

        public List<Transients> GetAllTransientsForSearch(string startDate = "", string endDate = "")
        {
            IQueryable<Transients> result = _context.Transients;


            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var stDate = DateTime.Parse(startDate);
                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.TransientDate.Date >= stDate.Date && c.TransientDate.Date <= edDate);
            }

            else if (!string.IsNullOrEmpty(startDate))
            {
                var stDate = DateTime.Parse(startDate);

                result = result.Where(c => c.TransientDate.Date >= stDate.Date);
            }

            else if (!string.IsNullOrEmpty(endDate))
            {

                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.TransientDate.Date <= edDate);
            }



            return result.Where(r => r.IsDelete == false).OrderByDescending(r => r.TransientDate).ToList();
        }

        public List<TransientsForSearchInPeriodViewModel> GetAllTransientsForSearchInPeriod(string startDate = "", string endDate = "")
        {
            IQueryable<Transients> result = _context.Transients;


            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var stDate = DateTime.Parse(startDate);
                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.TransientDate.Date >= stDate.Date && c.TransientDate.Date <= edDate);
            }

            else if (!string.IsNullOrEmpty(startDate))
            {
                var stDate = DateTime.Parse(startDate);

                result = result.Where(c => c.TransientDate.Date >= stDate.Date);
            }

            else if (!string.IsNullOrEmpty(endDate))
            {

                var edDate = DateTime.Parse(endDate);
                result = result.Where(c => c.TransientDate.Date <= edDate);
            }


            var data = result.Where(g => g.IsDelete == false).Select(t => new TransientsViewModel()
            {
                Code = t.Code,
                Name = t.Name,

            }).Distinct().ToList();

            List<TransientsForSearchInPeriodViewModel> values = new List<TransientsForSearchInPeriodViewModel>();


            foreach (var d in data)
            {
                var code = d.Code;


                var codeGroupid = _context.TransientGroups.FirstOrDefault(g => g.ParentId == null && g.GroupTitle == code).GroupId;
                var name = d.Name;


                var nameGroupid = _context.TransientGroups.First(v => v.ParentId == codeGroupid && v.GroupTitle == name).GroupId;
                var value = _context.TransientGroups.SingleOrDefault(g => g.ParentId == nameGroupid).GroupTitle;

                var number = result.Where(t => t.Code == code).Count();
                var count = _context.Transients.Where(t => t.Code == code).Count();

                values.Add(new TransientsForSearchInPeriodViewModel { Code = code, Name = name, Values = value, Count = count, NumberInPeriod = number });
            }

            return values;
        }

        public void DeleteTarnsientGroup(int tarnsientGroupId)
        {
            var tarnsientGroup = GetGroupById(tarnsientGroupId);
            tarnsientGroup.IsDelete = true;
            _context.Update(tarnsientGroup);
            _context.SaveChanges();
        }

        public TransientGroups GetGroupById(int groupId)
        {
            return _context.TransientGroups.Find(groupId);
        }

        public Transients GetTransientById(int transientId)
        {
            return _context.Transients.Find(transientId);
        }

        public void UpdateTransient(Transients transient)
        {
            transient.CreateDate = DateTime.Now;

            _context.Transients.Update(transient);
            _context.SaveChanges();
        }

        public void DeleteTransient(int transientId)
        {
            var evnt = GetTransientById(transientId);
            evnt.IsDelete = true;
            _context.Update(evnt);
            _context.SaveChanges();
        }

        public TransientGroups GetGroupByGroupTitle(string groupTitle)
        {
            return _context.TransientGroups.SingleOrDefault(g => g.GroupTitle == groupTitle);
        }

        public TransientGroups GetTransientGroupsByParentId(int parentId, string groupTitle)
        {
            return _context.TransientGroups.SingleOrDefault(g => g.GroupTitle == groupTitle && g.ParentId == parentId);
        }

        public int AddTransient(Transients transient)
        {
            transient.CreateDate = DateTime.Now;


            _context.Transients.Add(transient);
            _context.SaveChanges();
            return transient.TransientsId;
        }

        public int AddTransientDocument(TransientDocuments documents)
        {
            _context.TransientDocuments.Add(documents);
            _context.SaveChanges();
            return documents.TransientDocumentsId;
        }

        public List<TransientDocuments> GetAllTransienDocument()
        {
            return _context.TransientDocuments.Where(d => d.IsDelete == false).ToList();
        }

        public List<TransientDocuments> GetTransientDocumentById(int id)
        {
            return _context.TransientDocuments.Where(td => td.TransientsId == id && td.IsDelete == false).ToList();
        }

        public TransientGroups GetTransientGroupsByTitle(string groupTitle)
        {
            return _context.TransientGroups.SingleOrDefault(g => g.GroupTitle == groupTitle && g.IsDelete == false);
        }

        public void DeleteDocument(int documentId)
        {
            var document = GetDocumentById(documentId);
            document.IsDelete = true;


            string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/transientFiles", document.TransientDocumentsImage);
            if (File.Exists(deleteDemoPath))
            {
                File.Delete(deleteDemoPath);
            }

            _context.Update(document);
            _context.SaveChanges();
        }

        public TransientDocuments GetDocumentById(int documentId)
        {
            return _context.TransientDocuments.Find(documentId);
        }

        public List<Transients> GetTransientsByCode(string code)
        {
            return _context.Transients.Where(t => t.Code == code && t.IsDelete == false).ToList();
        }

        public int GetGroupIdByGroupTitle(string groupTitle)
        {
            return _context.TransientGroups.SingleOrDefault(u => u.GroupTitle == groupTitle).GroupId;
        }

        public TransientGroups GetTransientGroupByGroupId(int groupId)
        {
            return _context.TransientGroups.SingleOrDefault(u => u.ParentId == groupId);
        }

        public List<GroupedTransients> GetAllGroupedOfTransients()
        {
            return _context.GroupedTransients.Where(g => g.IsDelete == false).ToList();
        }

        public int AddGroupedTransient(GroupedTransients groupedTransients)
        {
            groupedTransients.CrerateDate = DateTime.Now;


            _context.GroupedTransients.Add(groupedTransients);
            _context.SaveChanges();
            return groupedTransients.GroupId;
        }

        public void DeleteGroupedTransient(int groupedTransientId)
        {
            var group = GetGroupedTransientsById(groupedTransientId);
            group.IsDelete = true;
            _context.Update(group);
            _context.SaveChanges();
        }

        public GroupedTransients GetGroupedTransientsById(int groupId)
        {
            return _context.GroupedTransients.Find(groupId);
        }

        public bool IsExistCode(string code)
        {
            return _context.GroupedTransients.Any(u => u.Code==code);
        }

        public List<GroupedTransients> SearchInGroupedOfTransient(string code = "")
        {
            IQueryable<GroupedTransients> result = _context.GroupedTransients;

            if (!string.IsNullOrEmpty(code))
            {
                result = result.Where(c => c.IsDelete==false && c.Code.Contains(code));
            }

            return result.ToList();
        }

        public List<GroupedTransients> SearchInNameGroupedOfTransient(string name = "")
        {
            IQueryable<GroupedTransients> result = _context.GroupedTransients;

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(c => c.IsDelete == false && c.Name.Contains(name));
            }

            return result.ToList();
        }

        public GroupedTransients GetGroupedTransientByTitle(string groupTitle)
        {
            return _context.GroupedTransients.SingleOrDefault(g => g.Code == groupTitle && g.IsDelete == false);
        }

        public List<SelectListItem> GetSubGroupForManageSearch(string code)
        {
            return _context.GroupedTransients.Where(g => g.Code == code && g.IsDelete == false)
                 .Select(g => new SelectListItem()
                 {
                     Text = g.Name,
                     Value = g.Name.ToString()
                 }).ToList();
        }

        public SaveTransientsViewModel GetTransientByIdForExport(int transientId)
        {
            var transient = GetTransientById(transientId);

            SaveTransientsViewModel transientsViewModel = new SaveTransientsViewModel();

            transientsViewModel.Code = transient.Code;
            transientsViewModel.AllowableNumber = transient.AllowableNumber;
            transientsViewModel.Description = transient.Description;
            transientsViewModel.Name = transient.Name;
            transientsViewModel.TransientDate = transient.TransientDate;
            transientsViewModel.TransientTime = transient.TransientTime;

            return transientsViewModel;
        }

        public IEnumerable<SaveTransientsViewModel> GetAllSavedTransientForExport()
        {
            return _context.Transients.Where(t => t.IsDelete == false).Select(c => new SaveTransientsViewModel()
            {
                Code = c.Code,
                AllowableNumber = c.AllowableNumber,
                Description = c.Description,
                Name = c.Name,
                TransientDate = c.TransientDate,
                TransientTime = c.TransientTime

            }).ToList();
        }

		public List<Transients> GetGroupedTransientByCode(string groupTitle)
		{
			return _context.Transients.Where(g => g.Code == groupTitle && g.IsDelete == false).ToList();
		}



		//public int GetParentIdByName(string name)
		//{
		//  return  _context.TransientGroups.Single(u => u.GroupTitle == name).GroupId;
		//}
	}
}
