using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities.AgeingMechanism;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;


namespace Bnpp.Core.Services.Interfaces
{
    public interface IMechanismService
    {
        #region Mechanism

        List<Mechanism> GetAllMechanism(int mechanicalId);
        List<MechanismViewModel> GetAllMechanismForExport(int mechanicalId);

        int AddMechanism(Mechanism mechanism);

        void UpdateMechanism(Mechanism mechanism);
        Mechanism GetMechanismById(int mechanismId);
        MechanismViewModel GetMechanismByIdForExport(int mechanismId);

        void DeleteMechanism(int mechanismId);

        #endregion

        #region Ageing Mechanism Document
        List<InspectionDocument> GetAllAgeingMechanismDocument(int mechanicalId);
        int AddAgeingMechanismDocument(InspectionDocument document, IFormFile fileAgeing);
		void DeleteAgeingMechanismDocument(int documentId);
		#endregion  

		#region MechanismDocuments

		List<MechanismDocuments> GetAllMechanismDocuments(int mechanicalId);
        List<MechanismDocumentsViewModel> GetAllMechanismDocumentsForExport(int mechanicalId);
        int AddMechanismDocuments(MechanismDocuments documents, IFormFile imgdocuments);
        MechanismDocuments GetMechanismDocumentsById(int documentsId);
        MechanismDocumentsViewModel GetMechanismDocumentsByIdForExport(int documentsId);
        void UpdateMechanismDocuments(MechanismDocuments documents, IFormFile imgdocuments);
        void DeleteMechanismDocuments(int documentsId);

        #endregion
    }
}
