using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities.AgeingMechanism;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;

namespace Bnpp.Core.Services
{

    public class MechanismService : IMechanismService
    {
        private BnppContext _context;

        public MechanismService(BnppContext context)
        {
            _context = context;
        }

        #region Mechanism

        public List<Mechanism> GetAllMechanism(int mechanicalId)
        {
            return _context.Mechanism.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).ToList();
        }

        public int AddMechanism(Mechanism mechanism)
        {
            mechanism.CreateDate = DateTime.Now;
            _context.Add(mechanism);
            _context.SaveChanges();
            return mechanism.MechanismId;
        }

        public void UpdateMechanism(Mechanism mechanism)
        {
            mechanism.CreateDate = DateTime.Now;
            _context.Update(mechanism);
            _context.SaveChanges();
        }

        public Mechanism GetMechanismById(int mechanismId)
        {
            return _context.Mechanism.Find(mechanismId);
        }

        public void DeleteMechanism(int mechanismId)
        {
            var meganism = GetMechanismById(mechanismId);
            meganism.IsDelete = true;
            UpdateMechanism(meganism);
        }



        #endregion

        #region MyRegion

        public List<MechanismDocuments> GetAllMechanismDocuments(int mechanicalId)
        {
            return _context.MechanismDocuments.Where(d => d.IsDelete == false && d.MechanicalId == mechanicalId).ToList();
        }

        public int AddMechanismDocuments(MechanismDocuments documents, IFormFile imgdocuments)
        {
            documents.CreateDate = DateTime.Now;

            if (imgdocuments != null)
            {
                documents.MechanismDocumentsImage = Guid.NewGuid() + Path.GetExtension(imgdocuments.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", documents.MechanismDocumentsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgdocuments.CopyTo(stream);
                }
            }

            _context.Add(documents);
            _context.SaveChanges();
            return documents.MechanismDocumentsId;
        }

        public MechanismDocuments GetMechanismDocumentsById(int documentsId)
        {
            return _context.MechanismDocuments.Find(documentsId);
        }

        public void UpdateMechanismDocuments(MechanismDocuments documents, IFormFile imgdocuments)
        {
            documents.CreateDate = DateTime.Now;

            if (imgdocuments != null)
            {
                if (documents.MechanismDocumentsImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", documents.MechanismDocumentsImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }

                documents.MechanismDocumentsImage = Guid.NewGuid() + Path.GetExtension(imgdocuments.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", documents.MechanismDocumentsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgdocuments.CopyTo(stream);
                }
            }

            _context.Update(documents);
            _context.SaveChanges();
        }

        public void DeleteMechanismDocuments(int documentsId)
        {
            var mechdocument = GetMechanismDocumentsById(documentsId);
            mechdocument.IsDelete = true;
            _context.Update(mechdocument);
            _context.SaveChanges();
        }

        public List<MechanismViewModel> GetAllMechanismForExport(int mechanicalId)
        {
            return _context.Mechanism.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new MechanismViewModel()
            {
                Component = c.Component,
                Consequences = c.Consequences,
                CriticalPoint = c.CriticalPoint,
                DegradationMechanism = c.DegradationMechanism,
                Region = c.Region
            }).ToList();
        }

        public MechanismViewModel GetMechanismByIdForExport(int mechanismId)
        {
            var mechanism = GetMechanismById(mechanismId);

            MechanismViewModel mechanismViewModel = new MechanismViewModel();

            mechanismViewModel.Component = mechanism.Component;
            mechanismViewModel.DegradationMechanism = mechanism.DegradationMechanism;
            mechanismViewModel.Region = mechanism.Region;
            mechanismViewModel.Consequences = mechanism.Consequences;
            mechanismViewModel.CriticalPoint = mechanism.CriticalPoint;

            return mechanismViewModel;
        }

        public List<MechanismDocumentsViewModel> GetAllMechanismDocumentsForExport(int mechanicalId)
        {
            return _context.MechanismDocuments.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new MechanismDocumentsViewModel()
            {
                Code = c.Code,
                DocumentName = c.DocumentName,
                Filename = c.Filename,
                MechanismDocumentsImage = c.MechanismDocumentsImage
            }).ToList();
        }

        public MechanismDocumentsViewModel GetMechanismDocumentsByIdForExport(int documentsId)
        {
            var doc = GetMechanismDocumentsById(documentsId);

            MechanismDocumentsViewModel documentViewModel = new MechanismDocumentsViewModel();

            documentViewModel.Filename = doc.Filename;
            documentViewModel.DocumentName = doc.DocumentName;
            documentViewModel.Code = doc.Code;
            documentViewModel.MechanismDocumentsImage = doc.MechanismDocumentsImage;

            return documentViewModel;
        }





        #endregion

        #region AgeingMechanismDocument
        public int AddAgeingMechanismDocument(InspectionDocument document, IFormFile fileAgeing)
        {
            document.InspectionImage = Guid.NewGuid() + Path.GetExtension(fileAgeing.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                fileAgeing.CopyTo(stream);
            }
            _context.Add(document);
            _context.SaveChanges();


            return document.InspectionId;
        }

        public List<InspectionDocument> GetAllAgeingMechanismDocument(int mechanicalId)
        {
            return _context.InspectionDocuments.Where(o => o.TypeId == 19 && o.IsDelete == false && o.MechanicalId == mechanicalId).ToList();
        }

		public void DeleteAgeingMechanismDocument(int documentId)
		{
			var document = _context.InspectionDocuments.Find(documentId);
			document.IsDelete = true;
			_context.Update(document);
			_context.SaveChanges();
		}

		#endregion
	}
}
