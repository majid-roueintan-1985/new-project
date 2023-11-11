using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bnpp.Core.Services
{
    public class OperationalService : IOperationalService
    {
        private BnppContext _context;
        private TransientContext _transientcontext;

        public OperationalService(BnppContext context, TransientContext transientcontext)
        {
            _context = context;
            _transientcontext = transientcontext;
        }
        public List<OperationalData> GetAllNormalOperations()
        {
            //return _context.OperationalData.Where(e => e.IsDelete == false).
            //    Select(e => new NormalOperationListViewModel()
            //    {
            //        OperationalId = e.OperationalId,
            //        AllowableNumber = e.AllowableNumber,
            //        NameOfCondition = e.NameofConditions,
            //        Occurrances = e.Occurrance,
            //        Dates=e.Dates,
            //        CreateDate = e.CreateDate,
            //        IsDelete=e.IsDelete
            //    }).ToList();

            return _context.OperationalData.Where(c => c.IsDelete == false).ToList();
        }

        public int AddNormalOperation(OperationalData normalOperational)
        {
            normalOperational.CreateDate = DateTime.Now;
            _context.Add(normalOperational);
            _context.SaveChanges();
            return normalOperational.OperationalId;
        }



        public List<SelectListItem> GetGroupForManageSearch()
        {
            return _transientcontext.TransientGroups.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageSearch(int groupId)
        {
            return _transientcontext.TransientGroups.Where(g => g.ParentId == groupId &&g.IsDelete == false)
                 .Select(g => new SelectListItem()
                 {
                     Text = g.GroupTitle,
                     Value = g.GroupId.ToString()
                 }).ToList();
        }



        public OperationalData GetNormalOperationalById(int normalId)
        {
            return _context.OperationalData.Find(normalId);
        }

        public void UpdateNormalOperational(OperationalData normalOperational)
        {
            normalOperational.CreateDate = DateTime.Now;
            _context.OperationalData.Update(normalOperational);
            _context.SaveChanges();
        }

        public void DeleteNormalOperational(int normalId)
        {
            var normalOperation = GetNormalOperationalById(normalId);
            normalOperation.IsDelete = true;
            UpdateNormalOperational(normalOperation);
        }

        public List<OccuranceListViewModel> GetAllOccurances()
        {
            return _context.Occurances.Where(e => e.IsDelete == false).
                Select(e => new OccuranceListViewModel()
                {
                    OccuranceId = e.OccuranceId,
                    AllowableNumber = e.AllowableNumber,
                    NameOfCondition = e.NameofConditions,
                    Occurrances = e.Occurrances,
                    Date = e.Dates,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public Occurance GetOccuranceById(int occuranceId)
        {
            return _context.Occurances.Find(occuranceId);
        }

        public int AddOccurance(Occurance occurance)
        {
            occurance.CreateDate = DateTime.Now;
            _context.Add(occurance);
            _context.SaveChanges();
            return occurance.OccuranceId;
        }

        public void UpdateOccurance(Occurance occurance)
        {
            occurance.CreateDate = DateTime.Now;
            _context.Occurances.Update(occurance);
            _context.SaveChanges();
        }

        public void DeleteOccurance(int occuranceId)
        {
            var occurance = GetOccuranceById(occuranceId);
            occurance.IsDelete = true;
            UpdateOccurance(occurance);
        }

        public List<DesignBasisListViewModel> GetAllBasisAccident()
        {
            return _context.DesignBasis.Where(e => e.IsDelete == false).
                Select(e => new DesignBasisListViewModel()
                {
                    DesigneId = e.BasislId,
                    AllowableNumber = e.AllowableNumber,
                    NameOfCondition = e.NameofConditions,
                    Occurrances = e.Occurrance,
                    Date = e.Dates,
                    CreateDate = e.CreateDate
                }).ToList();
        }
        public DesignBasis GetBasisAccidentById(int basisId)
        {
            return _context.DesignBasis.Find(basisId);
        }

        public int AddBasisAccident(DesignBasis designBasis)
        {
            designBasis.CreateDate = DateTime.Now;
            _context.Add(designBasis);
            _context.SaveChanges();
            return designBasis.BasislId;
        }

        public void UpdateBasisAccident(DesignBasis designBasis)
        {
            designBasis.CreateDate = DateTime.Now;
            _context.DesignBasis.Update(designBasis);
            _context.SaveChanges();
        }

        public void DeleteBasisAccident(int basisId)
        {
            var accident = GetBasisAccidentById(basisId);
            accident.IsDelete = true;
            UpdateBasisAccident(accident);
        }

       

       

      

        #region Normal Operation Document

        public void DeleteNormalOperationDocument(int normalId)
        {
            var normaldoc = GetNormalOperationDocumentById(normalId);
            normaldoc.IsDelete = true;
            _context.Update(normaldoc);
            _context.SaveChanges();
        }
        public void UpdateNormalOperationDocument(InspectionDocument document, IFormFile imgnormal)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 10;

            if (imgnormal != null)
            {
                if (document.InspectionImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgnormal.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgnormal.CopyTo(stream);
                }
            }

            _context.Update(document);
            _context.SaveChanges();
        }
        public int AddNormalOperationDocument(InspectionDocument document, IFormFile imgnormal)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 10;

            if (imgnormal != null)
            {
                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgnormal.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgnormal.CopyTo(stream);
                }
            }

            _context.Add(document);
            _context.SaveChanges();
            return document.InspectionId;
        }

        public InspectionDocument GetNormalOperationDocumentById(int normalId)
        {
            return _context.InspectionDocuments.SingleOrDefault(s => s.InspectionId == normalId && s.TypeId == 10);
        }
        public List<InspectionDocument> GetAllNormalOperationDocument()
        {
            return _context.InspectionDocuments.Where(o => o.TypeId == 10 && o.IsDelete == false).ToList();
        }


        #endregion

        #region Occurance Document

        public List<InspectionDocument> GetAllOccuranceDocument()
        {
            return _context.InspectionDocuments.Where(o => o.TypeId == 11 && o.IsDelete == false).ToList();
        }

        public int AddOccuranceDocument(InspectionDocument document, IFormFile imgOccurance)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 11;

            if (imgOccurance != null)
            {
                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgOccurance.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgOccurance.CopyTo(stream);
                }
            }

            _context.Add(document);
            _context.SaveChanges();
            return document.InspectionId;
        }

        public InspectionDocument GetOccuranceDocumentById(int occuranceId)
        {
            return _context.InspectionDocuments.SingleOrDefault(s => s.InspectionId == occuranceId && s.TypeId == 11);
        }

        public void UpdateOccuranceDocument(InspectionDocument document, IFormFile imgOccurance)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 11;

            if (imgOccurance != null)
            {
                if (document.InspectionImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgOccurance.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgOccurance.CopyTo(stream);
                }
            }

            _context.Update(document);
            _context.SaveChanges();
        }

        public void DeleteOccuranceDocument(int occuranceId)
        {
            var occurancedoc = GetOccuranceDocumentById(occuranceId);
            occurancedoc.IsDelete = true;
            _context.Update(occurancedoc);
            _context.SaveChanges();
        }



        #endregion


        #region  Basis accidents Document

        public List<InspectionDocument> GetAllBasisDocument()
        {
            return _context.InspectionDocuments.Where(o => o.TypeId == 12 && o.IsDelete == false).ToList();
        }

        public int AddBasisDocument(InspectionDocument document, IFormFile imgBasis)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 12;

            if (imgBasis != null)
            {
                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgBasis.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBasis.CopyTo(stream);
                }
            }

            _context.Add(document);
            _context.SaveChanges();
            return document.InspectionId;
        }

        public InspectionDocument GetBasisDocumentById(int basisId)
        {
            return _context.InspectionDocuments.SingleOrDefault(s => s.InspectionId == basisId && s.TypeId == 12);
        }

        public void UpdateBasisDocument(InspectionDocument document, IFormFile imgBasis)
        {
            document.CreateDate = DateTime.Now;
            document.TypeId = 12;

            if (imgBasis != null)
            {
                if (document.InspectionImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                document.InspectionImage = Guid.NewGuid() + Path.GetExtension(imgBasis.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBasis.CopyTo(stream);
                }
            }

            _context.Update(document);
            _context.SaveChanges();
        }

        public void DeleteBasisDocument(int basisId)
        {
            var basisdoc = GetBasisDocumentById(basisId);
            basisdoc.IsDelete = true;
            _context.Update(basisdoc);
            _context.SaveChanges();
        }

       



        #endregion



    }


}

