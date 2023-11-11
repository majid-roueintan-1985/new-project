using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IMechanicalService
    {
        List<MechanicalListViewModel> GetAllMechanicalEquipments();
        List<EquipmentsViewModel> GetAllMechanicalEquipmentsForExcel();
        int AddMechanicalEquipment(MechanicalEquipment mechanical);
        MechanicalEquipment GetEquipmentById(int equipmentId);
        EquipmentsViewModel GetEquipmentByIdForExcel(int equipmentId);

        void UpdateMechanicalEquipment(MechanicalEquipment mechanical);
        void DeleteMechanicalEquipment(int equipmentId);
    }
}
