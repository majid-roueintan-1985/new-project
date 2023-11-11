using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.InspectionData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IOperationalService
    {
        #region Normal Operation

        List<OperationalData> GetAllNormalOperations();
        int AddNormalOperation(OperationalData normalOperational);
        OperationalData GetNormalOperationalById(int normalId);

        void UpdateNormalOperational(OperationalData normalOperational);
        void DeleteNormalOperational(int normalId);


        List<SelectListItem> GetGroupForManageSearch();
        List<SelectListItem> GetSubGroupForManageSearch(int groupId);

        #endregion

        #region Occurance
        List<OccuranceListViewModel> GetAllOccurances();
        Occurance GetOccuranceById(int occuranceId);
        int AddOccurance(Occurance occurance);
        void UpdateOccurance(Occurance occurance);
        void DeleteOccurance(int occuranceId);


        #endregion

        #region Design Basis accidents

        List<DesignBasisListViewModel> GetAllBasisAccident();
        DesignBasis GetBasisAccidentById(int basisId);
        int AddBasisAccident(DesignBasis designBasis);
        void UpdateBasisAccident(DesignBasis designBasis);
        void DeleteBasisAccident(int basisId);

        #endregion

        #region Normal Operation Document

        List<InspectionDocument> GetAllNormalOperationDocument();
        int AddNormalOperationDocument(InspectionDocument document, IFormFile imgnormal);
        InspectionDocument GetNormalOperationDocumentById(int normalId);
        void UpdateNormalOperationDocument(InspectionDocument document, IFormFile imgnormal);
        void DeleteNormalOperationDocument(int normalId);

        #endregion

        #region Occurance Document

        List<InspectionDocument> GetAllOccuranceDocument();
        int AddOccuranceDocument(InspectionDocument document, IFormFile imgOccurance);
        InspectionDocument GetOccuranceDocumentById(int occuranceId);
        void UpdateOccuranceDocument(InspectionDocument document, IFormFile imgOccurance);
        void DeleteOccuranceDocument(int occuranceId);


        #endregion

        #region  Basis accidents Document

        List<InspectionDocument> GetAllBasisDocument();
        int AddBasisDocument(InspectionDocument document, IFormFile imgBasis);
        InspectionDocument GetBasisDocumentById(int basisId);
        void UpdateBasisDocument(InspectionDocument document, IFormFile imgBasis);
        void DeleteBasisDocument(int basisId);

        #endregion
    }
}
