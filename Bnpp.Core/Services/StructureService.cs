using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services
{
    public class StructureService : IStructureService
    {
        private BnppContext _context;

        public StructureService(BnppContext context)
        {
            _context = context;
        }

        public List<StructureListViewModel> GetAllStructures()
        {
            return _context.Strctures.Where(e => e.IsDelete == false).
                Select(e => new StructureListViewModel()
                {
                    StructureId = e.StrctureId,
                    ConstructionName = e.ConstructionName,
                    Azk = e.Azk,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddStructure(Strcture structure)
        {
            _context.Add(structure);
            _context.SaveChanges();
            return structure.StrctureId;
        }


        public Strcture GetStructureById(int structureId)
        {
            return _context.Strctures.Find(structureId);
        }

        public void UpdateStructure(Strcture structure)
        {
            structure.CreateDate = DateTime.Now;
            _context.Update(structure);
            _context.SaveChanges();
        }

        public void DeleteStructure(int structureId)
        {
            var structure = GetStructureById(structureId);
            structure.IsDelete = true;
            UpdateStructure(structure);
        }

        public List<StructureExportViewModel> GetAllStructuresForExport()
        {
            return _context.Strctures.Where(e => e.IsDelete == false).
               Select(e => new StructureExportViewModel()
               {
                  
                   ConstructionName = e.ConstructionName,
                   Azk = e.Azk,
                   
               }).ToList();
        }

        public StructureExportViewModel GetStructureByIdForExport(int structureId)
        {
            var structure=GetStructureById(structureId);

            StructureExportViewModel structureExport = new StructureExportViewModel();
            structureExport.ConstructionName=structure.ConstructionName;
            structureExport.Azk=structure.Azk;

            return structureExport;
        }
    }
}
