using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services
{

    public class MechanicalService : IMechanicalService
    {
        private BnppContext _context;

        public MechanicalService(BnppContext context)
        {
            _context = context;
        }
        public List<MechanicalListViewModel> GetAllMechanicalEquipments()
        {
            return _context.MechanicalEquipments.Where(e => e.IsDelete == false).
                Select(e => new MechanicalListViewModel()
                {
                    MechanicalId = e.MechanicalId,
                    Name = e.Name,
                    Azk = e.Azk,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddMechanicalEquipment(MechanicalEquipment mechanical)
        {
            _context.Add(mechanical);
            _context.SaveChanges();
            return mechanical.MechanicalId;
        }

        public MechanicalEquipment GetEquipmentById(int equipmentId)
        {
            return _context.MechanicalEquipments.Find(equipmentId);
        }

        public void UpdateMechanicalEquipment(MechanicalEquipment mechanical)
        {
            mechanical.CreateDate = DateTime.Now;
            _context.MechanicalEquipments.Update(mechanical);
            _context.SaveChanges();
        }

        public void DeleteMechanicalEquipment(int equipmentId)
        {
            var mechanical = GetEquipmentById(equipmentId);
            mechanical.IsDelete = true;
            UpdateMechanicalEquipment(mechanical);
        }

        public List<EquipmentsViewModel> GetAllMechanicalEquipmentsForExcel()
        {
            return _context.MechanicalEquipments.Where(e => e.IsDelete == false).
                Select(e => new EquipmentsViewModel()
                {
                    Name = e.Name,
                    Azk = e.Azk,
                }).ToList();
        }

        public EquipmentsViewModel GetEquipmentByIdForExcel(int equipmentId)
        {
           var equip=GetEquipmentById(equipmentId);

            EquipmentsViewModel equipmentsViewModel=new EquipmentsViewModel();

            equipmentsViewModel.Name = equip.Name;
            equipmentsViewModel.Azk= equip.Azk;

            return equipmentsViewModel;
        }
    }
}
