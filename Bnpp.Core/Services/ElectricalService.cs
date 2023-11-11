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
using Bnpp.DataLayer.Entities.AgeingDocuments;
using Bnpp.DataLayer.Entities.Electrical;
using Bnpp.DataLayer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Bnpp.Core.Services
{
    public class ElectricalService : IElectricalService
    {
        private BnppContext _context;

        public ElectricalService(BnppContext context)
        {
            _context = context;
        }

        #region Cables

        public List<CableListViewModel> GetAllCables()
        {
            return _context.Cables.Where(e => e.IsDelete == false).
                Select(e => new CableListViewModel()
                {
                    CableId = e.CableId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddCables(Cable cable)
        {
            _context.Add(cable);
            _context.SaveChanges();
            return cable.CableId;
        }

        public Cable GetCableById(int cableId)
        {
            return _context.Cables.Find(cableId);
        }

        public void UpdateCables(Cable cable)
        {
            cable.CreateDate = DateTime.Now;
            _context.Cables.Update(cable);
            _context.SaveChanges();
        }

        public void DeleteCable(int cableId)
        {
            var cable = GetCableById(cableId);
            cable.IsDelete = true;
            UpdateCables(cable);
        }

        #endregion

        #region Electromotors

        public List<ElectromotorsListViewModel> GetAllElectromotos()
        {
            return _context.Electromotors.Where(e => e.IsDelete == false).
                Select(e => new ElectromotorsListViewModel()
                {
                    electromotorId = e.ElectromotorId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddElectromotor(Electromotors electromotor)
        {
            _context.Add(electromotor);
            _context.SaveChanges();
            return electromotor.ElectromotorId;
        }

        public Electromotors GetElectromotorById(int electromotorId)
        {
            return _context.Electromotors.Find(electromotorId);
        }

        public void UpdateElectromotor(Electromotors electromotor)
        {
            electromotor.CreateDate = DateTime.Now;
            _context.Update(electromotor);
            _context.SaveChanges();
        }

        public void DeleteElectromotor(int electromotorId)
        {
            var electromotor = GetElectromotorById(electromotorId);
            electromotor.IsDelete = true;
            UpdateElectromotor(electromotor);
        }

        #endregion

        #region Generators

        public List<GeneratorListViewModel> GetAllGenerators()
        {
            return _context.Generators.Where(e => e.IsDelete == false).
                Select(e => new GeneratorListViewModel()
                {
                    generatorId = e.GeneratorId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddGenerator(Generator generator)
        {
            _context.Add(generator);
            _context.SaveChanges();
            return generator.GeneratorId;
        }

        public Generator GetGeneratorById(int generatorId)
        {
            return _context.Generators.Find(generatorId);
        }

        public void UpdateGenerator(Generator generator)
        {
            generator.CreateDate = DateTime.Now;
            _context.Update(generator);
            _context.SaveChanges();
        }

        public void DeleteGenerator(int generatorId)
        {
            var generator = GetGeneratorById(generatorId);
            generator.IsDelete = true;
            UpdateGenerator(generator);
        }

        #endregion

        #region Transformer

        public List<TransformerListViewModel> GetAllTransformers()
        {
            return _context.Transformers.Where(e => e.IsDelete == false).
                Select(e => new TransformerListViewModel()
                {
                    transformerId = e.TransformerId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddTransformer(Transformer transformer)
        {
            _context.Add(transformer);
            _context.SaveChanges();
            return transformer.TransformerId;
        }

        public Transformer GetTransformerById(int transformerId)
        {
            return _context.Transformers.Find(transformerId);
        }

        public void UpdateTransformer(Transformer transformer)
        {
            transformer.CreateDate = DateTime.Now;
            _context.Update(transformer);
            _context.SaveChanges();
        }

        public void DeleteTransformer(int transformerId)
        {
            var transformer = GetTransformerById(transformerId);
            transformer.IsDelete = true;
            UpdateTransformer(transformer);
        }



        #endregion

        #region Valves

        public List<ValvesListViewModel> GetAllValves()
        {
            return _context.ElectroValves.Where(e => e.IsDelete == false).
                Select(e => new ValvesListViewModel()
                {
                    ValveId = e.ValveId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddValve(ElectroValve valve)
        {
            _context.Add(valve);
            _context.SaveChanges();
            return valve.ValveId;
        }

        public ElectroValve GetValveById(int valveId)
        {
            return _context.ElectroValves.Find(valveId);
        }

        public void UpdateValve(ElectroValve valve)
        {
            valve.CreateDate = DateTime.Now;
            _context.Update(valve);
            _context.SaveChanges();
        }

        public void DeleteValve(int valveId)
        {
            var valve = GetValveById(valveId);
            valve.IsDelete = true;
            UpdateValve(valve);
        }



        #endregion

        #region Diesel

        public List<DieselListViewModel> GetAllDiesels()
        {
            return _context.Dieselgenerators.Where(e => e.IsDelete == false).
                Select(e => new DieselListViewModel()
                {
                    DieselId = e.DieselgeneratorId,
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                    CreateDate = e.CreateDate
                }).ToList();
        }

        public int AddDiesel(Dieselgenerator diesel)
        {
            _context.Add(diesel);
            _context.SaveChanges();
            return diesel.DieselgeneratorId;
        }

        public Dieselgenerator GetDieselById(int dieselId)
        {
            return _context.Dieselgenerators.Find(dieselId);
        }

        public void UpdateDiesel(Dieselgenerator diesel)
        {
            diesel.CreateDate = DateTime.Now;
            _context.Update(diesel);
            _context.SaveChanges();
        }

        public void DeleteDiesel(int dieselId)
        {
            var diesel = GetDieselById(dieselId);
            diesel.IsDelete = true;
            UpdateDiesel(diesel);
        }



        #endregion
        #region Genera cables

        public List<GeneralCables> GetAllGeneralCables()
        {
            return _context.GeneralCables.Where(g => g.IsDelete == false).ToList();
        }

        public int AddGeneralCables(GeneralCables cables, IFormFile imgResistanceDBA, IFormFile imgResistanceBDBA, IFormFile imgResultFactory, IFormFile imgInstallation)
        {
            cables.CreateDate = DateTime.Now;

            if (imgResistanceDBA != null)
            {
                cables.ResistancetoDBAConditionImage = Guid.NewGuid() + Path.GetExtension(imgResistanceDBA.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistancetoDBAConditionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResistanceDBA.CopyTo(stream);
                }
            }
            cables.ResistancetoDBAConditionFilename = imgResistanceDBA.FileName;

            if (imgResistanceBDBA != null)
            {
                cables.ResistanceBDBAConditionImage = Guid.NewGuid() + Path.GetExtension(imgResistanceBDBA.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistanceBDBAConditionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResistanceBDBA.CopyTo(stream);
                }
            }
            cables.ResistanceBDBAConditionFilename = imgResistanceBDBA.FileName;

            if (imgResultFactory != null)
            {
                cables.ResultFactoryTestsImage = Guid.NewGuid() + Path.GetExtension(imgResultFactory.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultFactoryTestsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResultFactory.CopyTo(stream);
                }
            }
            cables.ResultFactoryTestsFilename = imgResultFactory.FileName;

            if (imgInstallation != null)
            {
                cables.ResultTestsEndInstallationImage = Guid.NewGuid() + Path.GetExtension(imgInstallation.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultTestsEndInstallationImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgInstallation.CopyTo(stream);
                }
            }
            cables.ResultTestsEndInstallationFilename = imgInstallation.FileName;


            //Save Remaining design life time
            var f1 = DateTime.Now;
            var f2 = cables.InstallationDate;

            var dif = f1 - f2;
            var ServiceLife = dif.Days / 365;



            var Remainingdesignlifetime = Convert.ToInt32(cables.DesignLife) - Convert.ToInt32(ServiceLife);

            cables.ServiceLife = ServiceLife.ToString();
            cables.RemainingDesignLifeTime = Remainingdesignlifetime.ToString();

            cables.LogTime = DateTime.Now;

            _context.Add(cables);
            _context.SaveChanges();
            return cables.ID;
        }

        public void DeleteGeneralCables(int cableId)
        {
            var general = GetCablesGeneralById(cableId);
            general.IsDelete = true;
            _context.Update(general);
            _context.SaveChanges();
        }

        public GeneralCables GetCablesGeneralById(int cableId)
        {
            return _context.GeneralCables.Find(cableId);
        }

        public void UpdateGeneralCables(GeneralCables cables, IFormFile imgResistanceDBA, IFormFile imgResistanceBDBA, IFormFile imgResultFactory, IFormFile imgInstallation)
        {
            cables.CreateDate = DateTime.Now;
            var f1 = DateTime.Now;
            var f2 = cables.InstallationDate;

            var dif = f1 - f2;
            var ServiceLife = dif.Days / 365;



            var Remainingdesignlifetime = Convert.ToInt32(cables.DesignLife) - Convert.ToInt32(ServiceLife);

            cables.ServiceLife = ServiceLife.ToString();
            cables.RemainingDesignLifeTime = Remainingdesignlifetime.ToString();

            cables.LogTime = DateTime.Now;

            if (imgResistanceDBA != null)
            {
                cables.ResistancetoDBAConditionFilename = imgResistanceDBA.FileName;
                if (cables.ResistancetoDBAConditionImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistancetoDBAConditionImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }

                cables.ResistancetoDBAConditionImage = Guid.NewGuid() + Path.GetExtension(imgResistanceDBA.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistancetoDBAConditionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResistanceDBA.CopyTo(stream);
                }
            }

            if (imgResistanceBDBA != null)
            {
                cables.ResistanceBDBAConditionFilename = imgResistanceBDBA.FileName;
                if (cables.ResistanceBDBAConditionImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistanceBDBAConditionImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }

                cables.ResistanceBDBAConditionImage = Guid.NewGuid() + Path.GetExtension(imgResistanceBDBA.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResistanceBDBAConditionImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResistanceBDBA.CopyTo(stream);
                }
            }

            if (imgResultFactory != null)
            {
                cables.ResultFactoryTestsFilename = imgResultFactory.FileName;
                if (cables.ResultFactoryTestsImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultFactoryTestsImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }

                cables.ResultFactoryTestsImage = Guid.NewGuid() + Path.GetExtension(imgResultFactory.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultFactoryTestsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgResultFactory.CopyTo(stream);
                }
            }

            if (imgInstallation != null)
            {
                cables.ResultTestsEndInstallationFilename = imgInstallation.FileName;
                if (cables.ResultTestsEndInstallationImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultTestsEndInstallationImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }

                cables.ResultTestsEndInstallationImage = Guid.NewGuid() + Path.GetExtension(imgInstallation.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", cables.ResultTestsEndInstallationImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgInstallation.CopyTo(stream);
                }
            }
;

            _context.Update(cables);
            _context.SaveChanges();
        }

        public List<CableIdentity> GetAllIdCables()
        {
            return _context.CableIdentities.ToList();
        }

        public List<SelectListItem> GetGroupForManageCableGroup()
        {
            return _context.CableGroups.Where(g => g.IsDelete == false)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageCablId(int groupId)
        {
            return _context.CableIdentities.Where(g => g.CableId == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.CableTitle,
                    Value = g.CableId.ToString()
                }).ToList();
        }



        #endregion
        #region Operating Cables

        public int AddOperatingData(OperatingCableData operatingCable)
        {
            operatingCable.CreateDate = DateTime.Now;

            _context.Add(operatingCable);
            _context.SaveChanges();
            return operatingCable.ID;
        }

        public List<OperatingCableData> GetAllOperatingCables()
        {
            return _context.OperatingCableDatas.Where(o => o.IsDelete == false).ToList();
        }

        public void DeleteOperatingCables(int operatingId)
        {
            var operate = GetOperatingCableById(operatingId);
            operate.IsDelete = true;
            _context.Update(operate);
            _context.SaveChanges();
        }

        public OperatingCableData GetOperatingCableById(int cableId)
        {
            return _context.OperatingCableDatas.Find(cableId);
        }

        #endregion

        #region Maintenance Cables

        public List<MaintenanceCable> GetAllMaintenanceCable()
        {
            return _context.MaintenanceCables.Where(m => m.IsDelete == false).ToList();
        }

        public int AddMaintenanceCable(MaintenanceCable maintenanceCable, IFormFile imgmaintenanceCable)
        {
            maintenanceCable.CreateDate = DateTime.Now;

            if (imgmaintenanceCable != null)
            {
                maintenanceCable.AttachActImage = Guid.NewGuid() + Path.GetExtension(imgmaintenanceCable.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", maintenanceCable.AttachActImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgmaintenanceCable.CopyTo(stream);
                }
            }

            maintenanceCable.AttachActFileName = imgmaintenanceCable.FileName;

            _context.Add(maintenanceCable);
            _context.SaveChanges();
            return maintenanceCable.ID; ;
        }

        public MaintenanceCable GetMaintenanceCableById(int maintenanceId)
        {
            return _context.MaintenanceCables.Find(maintenanceId);
        }

        public void DeleteMaintenanceCables(int maintenanceId)
        {
            var maintenance = GetMaintenanceCableById(maintenanceId);

            maintenance.IsDelete = true;

            _context.Update(maintenance);
            _context.SaveChanges();
        }

        public void UpdateMaintenanceCable(MaintenanceCable maintenanceCable, IFormFile imgmaintenanceCable)
        {
            maintenanceCable.CreateDate = DateTime.Now;

            if (imgmaintenanceCable != null)
            {
                maintenanceCable.AttachActFileName = imgmaintenanceCable.FileName;
                if (maintenanceCable.AttachActImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", maintenanceCable.AttachActImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }


                maintenanceCable.AttachActImage = Guid.NewGuid() + Path.GetExtension(imgmaintenanceCable.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", maintenanceCable.AttachActImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgmaintenanceCable.CopyTo(stream);
                }
            }



            _context.Update(maintenanceCable);
            _context.SaveChanges();
        }

        #endregion
        #region Report Cables
        public List<CableReport> GetAllCableReports()
        {
            return _context.CableReports.Where(r => r.IsDelete == false).ToList();
        }

        public int AddReportCable(CableReport report)
        {
            report.CreateDate = DateTime.Now;

            var cable = GetCablesGeneralByCableIdGroup(report.CableID);

            report.RemainingDesignLifeTime = cable.RemainingDesignLifeTime;

            _context.Add(report);
            _context.SaveChanges();

            return report.ID;
        }

        public void UpdateOperatingData(OperatingCableData operating)
        {
            operating.CreateDate = DateTime.Now;

            _context.Update(operating);
            _context.SaveChanges();
        }

        public void DeleteCablereport(int reportId)
        {
            var report = GetCableReportById(reportId);

            report.IsDelete = true;

            _context.Update(report);
            _context.SaveChanges();
        }

        public CableReport GetCableReportById(int reportId)
        {
            return _context.CableReports.Find(reportId);
        }

        public void UpdateReportCable(CableReport report)
        {
            report.CreateDate = DateTime.Now;
            _context.Update(report);
            _context.SaveChanges();
        }



        #endregion

        #region Owner

        public List<Owner> GetAllOwners()
        {
            return _context.Owner.Where(o => o.IsDelete == false).ToList();
        }

        public int AddOwner(Owner owner)
        {
            owner.CreateDate = DateTime.Now;

            _context.Add(owner);
            _context.SaveChanges();

            return owner.OwnerId;
        }

        public Owner GetOwnerById(int ownerId)
        {
            return _context.Owner.Find(ownerId);
        }

        public void UpdateOwner(Owner owner)
        {
            owner.CreateDate = DateTime.Now;

            _context.Update(owner);
            _context.SaveChanges();
        }

        public void DeleteOwner(int ownerId)
        {
            var owner = GetOwnerById(ownerId);

            owner.IsDelete = true;

            _context.Update(owner);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetOwners()
        {
            return _context.Owner.Where(g => g.IsDelete == false)
                 .Select(g => new SelectListItem()
                 {
                     Text = g.OwnerTitle,
                     Value = g.OwnerTitle.ToString()
                 }).ToList();
        }



        #endregion
        #region TypeofCable
        public List<TypeofCable> GetAllTypeofCable()
        {
            return _context.TypeofCables.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GettypeofCables()
        {
            return _context.TypeofCables.Where(g => g.IsDelete == false)
                .Select(g => new SelectListItem()
                {
                    Text = g.TypeofCableTitle,
                    Value = g.TypeofCableTitle.ToString()
                }).ToList();
        }

        public int AddTypeofCable(TypeofCable typeofCable)
        {
            typeofCable.CreateDate = DateTime.Now;

            _context.Add(typeofCable);
            _context.SaveChanges();

            return typeofCable.ID;
        }

        public TypeofCable GetTypeofCableById(int typeId)
        {
            return _context.TypeofCables.Find(typeId);
        }

        public void UpdateTypeofCable(TypeofCable type)
        {
            type.CreateDate = DateTime.Now;
            _context.Update(type);
            _context.SaveChanges();
        }

        public void DeleteCableType(int typeId)
        {
            var type = GetTypeofCableById(typeId);
            type.IsDelete = true;
            UpdateTypeofCable(type);
        }



        #endregion

        #region Classification of cable on the basis of Voltage
        public List<ClassificationVoltage> GetAllClassification()
        {
            return _context.ClassificationVoltage.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetClassificationVoltage()
        {
            return _context.ClassificationVoltage.Where(g => g.IsDelete == false)
               .Select(g => new SelectListItem()
               {
                   Text = g.ClassificationVoltageTitle,
                   Value = g.ClassificationVoltageTitle.ToString()
               }).ToList();
        }

        public int AddVoltage(ClassificationVoltage classification)
        {
            classification.CreateDate = DateTime.Now;
            _context.Add(classification);
            _context.SaveChanges();
            return classification.ID;
        }

        public ClassificationVoltage GetVoltageById(int voltageId)
        {
            return _context.ClassificationVoltage.Find(voltageId);
        }

        public void UpdateVoltage(ClassificationVoltage classification)
        {
            classification.CreateDate = DateTime.Now;
            _context.Update(classification);
            _context.SaveChanges();

        }

        public void deleteVoltage(int voltageId)
        {
            var voltage = GetVoltageById(voltageId);
            voltage.IsDelete = true;
            UpdateVoltage(voltage);
        }



        #endregion

        #region List of Cable

        public List<ListofCable> GetAllListofCable()
        {
            return _context.ListofCables.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetListofCables()
        {
            return _context.ListofCables.Where(g => g.IsDelete == false)
              .Select(g => new SelectListItem()
              {
                  Text = g.ListofCableTitle,
                  Value = g.ListofCableTitle.ToString()
              }).ToList();
        }

        public int AddListofCable(ListofCable cableList)
        {
            cableList.CreateDate = DateTime.Now;
            _context.Add(cableList);
            _context.SaveChanges();

            return cableList.ID;
        }

        public ListofCable GetListofCableById(int cableId)
        {
            return _context.ListofCables.Find(cableId);
        }

        public void UpdateListofCable(ListofCable cableList)
        {
            cableList.CreateDate = DateTime.Now;
            _context.Update(cableList);
            _context.SaveChanges();
        }

        public void DeleteListofCable(int cableId)
        {
            var lists = GetListofCableById(cableId);

            lists.IsDelete = true;
            UpdateListofCable(lists);
        }



        #endregion



        #region Insulation material

        public List<InsulationMaterial> GetAllInsulationMaterial()
        {
            return _context.InsulationMaterials.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetInsulationMaterialSelectList()
        {
            return _context.InsulationMaterials.Where(g => g.IsDelete == false)
             .Select(g => new SelectListItem()
             {
                 Text = g.InsulationMaterialTitle,
                 Value = g.InsulationMaterialTitle.ToString()
             }).ToList();
        }

        public int AddInsulationMaterial(InsulationMaterial material)
        {
            material.CreateDate = DateTime.Now;
            _context.Add(material);
            _context.SaveChanges();

            return material.InsulationMaterialId;
        }

        public InsulationMaterial GetInsulationMaterialById(int materialId)
        {
            return _context.InsulationMaterials.Find(materialId);
        }

        public void UpdateInsulationMaterial(InsulationMaterial material)
        {
            material.CreateDate = DateTime.Now;
            _context.Update(material);
            _context.SaveChanges();
        }

        public void DeleteInsulationMaterial(int materialId)
        {
            var material = GetInsulationMaterialById(materialId);
            material.IsDelete = true;
            UpdateInsulationMaterial(material);
        }



        #endregion

        #region Jacket Material

        public List<JacketMaterial> GetAllJacketMaterial()
        {
            return _context.JacketMaterials.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetJacketMaterialSelectList()
        {
            return _context.JacketMaterials.Where(g => g.IsDelete == false)
             .Select(g => new SelectListItem()
             {
                 Text = g.JacketMaterialTitle,
                 Value = g.JacketMaterialTitle.ToString()
             }).ToList();
        }

        public int AddJacketMaterial(JacketMaterial jacket)
        {
            jacket.CreateDate = DateTime.Now;
            _context.Add(jacket);
            _context.SaveChanges();

            return jacket.JacketMaterialId;
        }

        public JacketMaterial GetJacketMaterialById(int jacketId)
        {
            return _context.JacketMaterials.Find(jacketId);
        }

        public void UpdateJacketMaterial(JacketMaterial jacket)
        {
            jacket.CreateDate = DateTime.Now;
            _context.Update(jacket);
            _context.SaveChanges();
        }

        public void DeleteJacketMaterial(int jacketId)
        {
            var jacket = GetJacketMaterialById(jacketId);
            jacket.IsDelete = true;
            UpdateJacketMaterial(jacket);
        }



        #endregion

        #region Manufacturer

        public List<ManufacturerCable> GetAllManufacturer()
        {
            return _context.ManufacturerCable.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetManufacturerSelectList()
        {
            return _context.ManufacturerCable.Where(g => g.IsDelete == false)
            .Select(g => new SelectListItem()
            {
                Text = g.ManufacturerTitle,
                Value = g.ManufacturerTitle.ToString()
            }).ToList();
        }

        public int AddManufacturer(ManufacturerCable manufacturer)
        {
            manufacturer.CreateDate = DateTime.Now;
            _context.Add(manufacturer);
            _context.SaveChanges();

            return manufacturer.ManufacturerId;
        }

        public ManufacturerCable GetManufacturerById(int manufacturerId)
        {
            return _context.ManufacturerCable.Find(manufacturerId);
        }

        public void UpdateManufacturer(ManufacturerCable manufacturer)
        {
            manufacturer.CreateDate = DateTime.Now;
            _context.Update(manufacturer);
            _context.SaveChanges();
        }

        public void DeleteManufacturer(int manufacturerId)
        {
            var manufacturer = GetManufacturerById(manufacturerId);
            manufacturer.IsDelete = true;
            UpdateManufacturer(manufacturer);
        }



        #endregion
        #region Location

        public List<CableLocation> GetAllCableLocation()
        {
            return _context.CableLocation.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetCableLocationSelectList()
        {
            return _context.CableLocation.Where(g => g.IsDelete == false)
           .Select(g => new SelectListItem()
           {
               Text = g.LocationTitle,
               Value = g.LocationTitle.ToString()
           }).ToList();
        }

        public int AddCableLocation(CableLocation location)
        {
            location.CreateDate = DateTime.Now;
            _context.Add(location);
            _context.SaveChanges();
            return location.LocationId;
        }

        public CableLocation GetCableLocationById(int locationId)
        {
            return _context.CableLocation.Find(locationId);
        }

        public void UpdateCableLocation(CableLocation location)
        {
            location.CreateDate = DateTime.Now;
            _context.Update(location);
            _context.SaveChanges();
        }

        public void DeleteCableLocation(int locationId)
        {
            var loc = GetCableLocationById(locationId);
            loc.IsDelete = true;
            UpdateCableLocation(loc);
        }



        #endregion

        #region degradation mechanisms

        public List<DegradationMechanisms> GetAllDegradationMechanisms()
        {
            return _context.DegradationMechanisms.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetDegradationMechanismsSelectList()
        {
            return _context.DegradationMechanisms.Where(g => g.IsDelete == false)
           .Select(g => new SelectListItem()
           {
               Text = g.DegradationMechanismsTitle,
               Value = g.DegradationMechanismsTitle.ToString()
           }).ToList();
        }

        public int AddDegradationMechanisms(DegradationMechanisms mechanisms)
        {
            mechanisms.CreateDate = DateTime.Now;
            _context.Add(mechanisms);
            _context.SaveChanges();

            return mechanisms.ID;
        }

        public DegradationMechanisms GetDegradationMechanismsById(int mechanismsId)
        {
            return _context.DegradationMechanisms.Find(mechanismsId);
        }

        public void UpdateDegradationMechanisms(DegradationMechanisms mechanisms)
        {
            mechanisms.CreateDate = DateTime.Now;
            _context.Update(mechanisms);
            _context.SaveChanges();
        }

        public void DeleteDegradationMechanisms(int mechanismsId)
        {
            var mech = GetDegradationMechanismsById(mechanismsId);
            mech.IsDelete = true;
            UpdateDegradationMechanisms(mech);
        }



        #endregion

        #region Current

        public List<CableCurrent> GetAllCableCurrent()
        {
            return _context.CableCurrent.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetCableCurrentSelectList()
        {
            return _context.CableCurrent.Where(g => g.IsDelete == false)
           .Select(g => new SelectListItem()
           {
               Text = g.CurrentTitle,
               Value = g.CurrentTitle.ToString()
           }).ToList();
        }

        public int AddCableCurrent(CableCurrent current)
        {
            current.CreateDate = DateTime.Now;
            _context.Add(current);
            _context.SaveChanges();

            return current.ID;
        }

        public CableCurrent GetCableCurrentById(int currentId)
        {
            return _context.CableCurrent.Find(currentId);
        }

        public void UpdateCableCurrent(CableCurrent current)
        {
            current.CreateDate = DateTime.Now;
            _context.Update(current);
            _context.SaveChanges();
        }

        public void DeleteCableCurrent(int currentId)
        {
            var curr = GetCableCurrentById(currentId);
            curr.IsDelete = true;
            UpdateCableCurrent(curr);
        }



        #endregion

        #region Cable ID

        public List<CableIdentity> GetAllCableIdentity()
        {
            return _context.CableIdentities.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetCableIdentitySelectList()
        {
            return _context.CableIdentities.Where(g => g.IsDelete == false)
          .Select(g => new SelectListItem()
          {
              Text = g.CableTitle,
              Value = g.CableTitle.ToString()
          }).ToList();
        }

        public int AddCableIdentity(CableIdentity cable)
        {
            cable.CreateDate = DateTime.Now;

            _context.Add(cable);
            _context.SaveChanges();

            return cable.CableId;
        }

        public CableIdentity GetCableIdentityById(int cableId)
        {
            return _context.CableIdentities.Find(cableId);
        }

        public void UpdateCableIdentity(CableIdentity cable)
        {
            cable.CreateDate = DateTime.Now;
            _context.Update(cable);
            _context.SaveChanges();
        }

        public void DeleteCableIdentity(int cableId)
        {
            var cable = GetCableIdentityById(cableId);
            cable.IsDelete = true;
            UpdateCableIdentity(cable);
        }



        #endregion


        #region Cable Group

        public List<CableGroup> GetAllCableGroup()
        {
            return _context.CableGroups.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetCableGroupSelectList()
        {
            return _context.CableGroups.Where(g => g.IsDelete == false)
         .Select(g => new SelectListItem()
         {
             Text = g.GroupTitle,
             Value = g.GroupTitle.ToString()
         }).ToList();
        }

        public int AddCableGroup(CableGroup group)
        {
            group.CreateDate = DateTime.Now;
            _context.Add(group);
            _context.SaveChanges();

            return group.GroupId;
        }

        public CableGroup GetCableGroupById(int groupId)
        {
            return _context.CableGroups.Find(groupId);
        }

        public void UpdateCableGroup(CableGroup group)
        {
            group.CreateDate = DateTime.Now;
            _context.Update(group);
            _context.SaveChanges();
        }

        public void DeleteCableGroup(int groupId)
        {
            var group = GetCableGroupById(groupId);
            group.IsDelete = true;
            UpdateCableGroup(group);
        }



        #endregion



        #region Operation Mode

        public List<OperationMode> GetAllOperationMode()
        {
            return _context.OperationMode.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetOperationModeSelectList()
        {
            return _context.OperationMode.Where(g => g.IsDelete == false)
           .Select(g => new SelectListItem()
           {
               Text = g.OperationModeTitle,
               Value = g.OperationModeTitle.ToString()
           }).ToList();
        }

        public int AddOperationMode(OperationMode mode)
        {
            mode.CreateDate = DateTime.Now;
            _context.Add(mode);
            _context.SaveChanges();

            return mode.ID;
        }

        public OperationMode GetOperationModeById(int modeId)
        {
            return _context.OperationMode.Find(modeId);
        }

        public void UpdateOperationMode(OperationMode mode)
        {
            mode.CreateDate = DateTime.Now;
            _context.Update(mode);
            _context.SaveChanges();
        }

        public void DeleteOperationMode(int modeId)
        {
            var mode = GetOperationModeById(modeId);
            mode.IsDelete = true;
            UpdateOperationMode(mode);
        }



        #endregion

        #region Method of Failure

        public List<FailureDiscovery> GetAllFailureDiscovery()
        {
            return _context.FailureDiscovery.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetFailureDiscoverySelectList()
        {
            return _context.FailureDiscovery.Where(g => g.IsDelete == false)
          .Select(g => new SelectListItem()
          {
              Text = g.FailureDiscoveryTitle,
              Value = g.FailureDiscoveryTitle.ToString()
          }).ToList();
        }

        public int AddFailureDiscovery(FailureDiscovery failure)
        {
            failure.CreateDate = DateTime.Now;
            _context.Add(failure);
            _context.SaveChanges();
            return failure.ID;
        }

        public FailureDiscovery GetFailureDiscoveryById(int failureId)
        {
            return _context.FailureDiscovery.Find(failureId);
        }

        public void UpdateFailureDiscovery(FailureDiscovery failure)
        {
            failure.CreateDate = DateTime.Now;
            _context.Update(failure);
            _context.SaveChanges();
        }

        public void DeleteFailureDiscovery(int failureId)
        {
            var failure = GetFailureDiscoveryById(failureId);
            failure.IsDelete = true;
            UpdateFailureDiscovery(failure);
        }



        #endregion

        #region  Failure Condition

        public List<FailureCondition> GetAllFailureCondition()
        {
            return _context.FailureCondition.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetFailureConditionSelectList()
        {
            return _context.FailureCondition.Where(g => g.IsDelete == false)
         .Select(g => new SelectListItem()
         {
             Text = g.FailureConditionTitle,
             Value = g.FailureConditionTitle.ToString()
         }).ToList();
        }

        public int AddFailureCondition(FailureCondition condition)
        {
            condition.CreateDate = DateTime.Now;
            _context.Add(condition);
            _context.SaveChanges();

            return condition.ID;
        }

        public FailureCondition GetFailureConditionById(int conditionId)
        {
            return _context.FailureCondition.Find(conditionId);
        }

        public void UpdateFailureCondition(FailureCondition condition)
        {
            condition.CreateDate = DateTime.Now;
            _context.Update(condition);
            _context.SaveChanges();
        }

        public void DeleteFailureCondition(int conditionId)
        {
            var condition = GetFailureConditionById(conditionId);
            condition.IsDelete = true;
            UpdateFailureCondition(condition);
        }



        #endregion

        #region Failed parts

        public List<FailedParts> GetAllFailedParts()
        {
            return _context.FailedParts.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetFailedPartsSelectList()
        {
            return _context.FailedParts.Where(g => g.IsDelete == false)
         .Select(g => new SelectListItem()
         {
             Text = g.FailedPartsTitle,
             Value = g.FailedPartsTitle.ToString()
         }).ToList();
        }

        public int AddFailedParts(FailedParts parts)
        {
            parts.CreateDate = DateTime.Now;
            _context.Add(parts);
            _context.SaveChanges();

            return parts.ID;
        }

        public FailedParts GetFailedPartsById(int partsId)
        {
            return _context.FailedParts.Find(partsId);
        }

        public void UpdateFailedParts(FailedParts parts)
        {
            parts.CreateDate = DateTime.Now;
            _context.Update(parts);
            _context.SaveChanges();
        }

        public void DeleteFailedParts(int partsId)
        {
            var parts = GetFailedPartsById(partsId);
            parts.IsDelete = true;
            UpdateFailedParts(parts);
        }



        #endregion

        #region Type of Maintenance

        public List<TypeofMaintenance> GetAllTypeofMaintenance()
        {
            return _context.TypeofMaintenance.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetTypeofMaintenanceSelectList()
        {
            return _context.TypeofMaintenance.Where(g => g.IsDelete == false)
         .Select(g => new SelectListItem()
         {
             Text = g.TypeofMaintenanceTitle,
             Value = g.TypeofMaintenanceTitle.ToString()
         }).ToList();
        }

        public int AddTypeofMaintenance(TypeofMaintenance maintenance)
        {
            maintenance.CreateDate = DateTime.Now;
            _context.Add(maintenance);
            _context.SaveChanges();

            return maintenance.ID;
        }

        public TypeofMaintenance GetTypeofMaintenanceById(int maintenanceId)
        {
            return _context.TypeofMaintenance.Find(maintenanceId);
        }

        public void UpdateTypeofMaintenance(TypeofMaintenance maintenance)
        {
            maintenance.CreateDate = DateTime.Now;
            _context.Update(maintenance);
            _context.SaveChanges();
        }

        public void DeleteTypeofMaintenance(int maintenanceId)
        {
            var maintenance = GetTypeofMaintenanceById(maintenanceId);
            maintenance.IsDelete = true;
            UpdateTypeofMaintenance(maintenance);
        }



        #endregion

        #region Type Tests

        public List<TestType> GetAllTestType()
        {
            return _context.TestType.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetTestTypeSelectList()
        {
            return _context.TestType.Where(g => g.IsDelete == false)
       .Select(g => new SelectListItem()
       {
           Text = g.Title,
           Value = g.Title.ToString()
       }).ToList();
        }

        public int AddTestType(TestType test)
        {
            test.CreateDate = DateTime.Now;
            _context.Add(test);
            _context.SaveChanges();

            return test.ID;
        }

        public TestType GetTestTypeById(int testId)
        {
            return _context.TestType.Find(testId);
        }

        public void UpdateTestType(TestType test)
        {
            test.CreateDate = DateTime.Now;
            _context.Update(test);
            _context.SaveChanges();
        }

        public void DeleteTestType(int testId)
        {
            var type = GetTestTypeById(testId);
            type.IsDelete = true;
            UpdateTestType(type);
        }



        #endregion

        #region Result

        public List<ResaultCable> GetAllResaultCable()
        {
            return _context.ResaultCable.Where(t => t.IsDelete == false).ToList();
        }

        public List<SelectListItem> GetResaultCableSelectList()
        {
            return _context.ResaultCable.Where(g => g.IsDelete == false)
       .Select(g => new SelectListItem()
       {
           Text = g.Title,
           Value = g.Title.ToString()
       }).ToList();
        }

        public int AddResaultCable(ResaultCable result)
        {
            result.CreateDate = DateTime.Now;
            _context.Add(result);
            _context.SaveChanges();

            return result.ID;
        }

        public ResaultCable GetResaultCableById(int resultId)
        {
            return _context.ResaultCable.Find(resultId);
        }

        public void UpdateResaultCable(ResaultCable result)
        {
            result.CreateDate = DateTime.Now;
            _context.Update(result);
            _context.SaveChanges();
        }

        public void DeleteResaultCable(int resultId)
        {
            var res = GetResaultCableById(resultId);
            res.IsDelete = true;
            UpdateResaultCable(res);
        }

        public GeneralCables GetCablesGeneralByCableIdGroup(string cableIdGroup)
        {
            return _context.GeneralCables.SingleOrDefault(g => g.CableID == cableIdGroup && g.IsDelete == false);
        }

        public List<CableReportViewModel> GetAllCableReportsForExcel()
        {
            return _context.CableReports.Where(r => r.IsDelete == false).Select(c => new CableReportViewModel()
            {
                //ID = c.ID,
                CableID = c.CableID,
                CableIDGroup = c.CableIDGroup,
                Datefrom = c.Datefrom,
                DateTo = c.DateTo,
                EndDateMaintenance = c.EndDateMaintenance,
                FailedParts = c.FailedParts,
                FailureDetctionDate = c.FailureDetctionDate,
                ModeofOperation = c.ModeofOperation,
                Owner = c.Owner,
                RemainingDesignLifeTime = c.RemainingDesignLifeTime,
                StartDateMaintenance = c.StartDateMaintenance,
                TypeofMaintenancework = c.TypeofMaintenancework,
                TypeofTests = c.TypeofTests

            }).ToList();
        }

        public CableReportViewModel GetCableReportByIdForExcel(int reportId)
        {
            var report = GetCableReportById(reportId);

            CableReportViewModel cableReport = new CableReportViewModel();

            //cableReport.ID = report.ID;
            cableReport.CableID = report.CableID;
            cableReport.CableIDGroup = report.CableIDGroup;
            cableReport.Datefrom = report.Datefrom;
            cableReport.DateTo = report.DateTo;
            cableReport.EndDateMaintenance = report.EndDateMaintenance;
            cableReport.FailedParts = report.FailedParts;
            cableReport.FailureDetctionDate = report.FailureDetctionDate;
            cableReport.ModeofOperation = report.ModeofOperation;
            cableReport.Owner = report.Owner;
            cableReport.RemainingDesignLifeTime = report.RemainingDesignLifeTime;
            cableReport.StartDateMaintenance = report.StartDateMaintenance;
            cableReport.TypeofMaintenancework = report.TypeofMaintenancework;
            cableReport.TypeofTests = report.TypeofTests;



            return cableReport;


        }
        #endregion
        public List<OperatingDataViewModel> GetAllOperatingCablesForExcel()
        {
            return _context.OperatingCableDatas.Where(o => o.IsDelete == false).Select(c => new OperatingDataViewModel()
            {
                
                CableID = c.CableID,
                CableIDGroup = c.CableIDGroup,
                FailedParts = c.FailedParts,
                ModeofOperation = c.ModeofOperation,
                Owner = c.Owner,
                AKZofHumiditySensor = c.AKZofHumiditySensor,
                AKZofRadiationSensor = c.AKZofRadiationSensor,
                AKZofTemperatureSensor = c.AKZofTemperatureSensor,
                CauseofFailure = c.CauseofFailure,
                ConditionOfFailure = c.ConditionOfFailure,
                Current = c.Current,
                FailureDate = c.FailureDate,
                FailureDescription = c.FailureDescription,
                HumiditySensorValue = c.HumiditySensorValue,
                LocationHumiditySensor = c.LocationHumiditySensor,
                MethodofFailure = c.MethodofFailure,
                RadiationSensorLocation = c.RadiationSensorLocation,
                RadiationSensorValue = c.RadiationSensorValue,
                TemperatureSensorLocation = c.TemperatureSensorLocation,
                TemperatureSensorValue = c.TemperatureSensorValue

            }).ToList();
        }

        public OperatingDataViewModel GetOperatingCableByIdForExcel(int cableId)
        {
            var operato=GetOperatingCableById(cableId);

            OperatingDataViewModel operatingData = new OperatingDataViewModel();
            operatingData.CableID = operato.CableID;
            operatingData.CableIDGroup = operato.CableIDGroup;
            operatingData.FailedParts = operato.FailedParts;
            operatingData.ModeofOperation = operato.ModeofOperation;
            operatingData.Owner = operato.Owner;
            operatingData.AKZofHumiditySensor = operato.AKZofHumiditySensor;
            operatingData.AKZofRadiationSensor = operato.AKZofRadiationSensor;
            operatingData.AKZofTemperatureSensor = operato.AKZofTemperatureSensor;
            operatingData.CauseofFailure = operato.CauseofFailure;
            operatingData.ConditionOfFailure = operato.ConditionOfFailure;
            operatingData.Current = operato.Current;
            operatingData.FailureDate = operato.FailureDate;
            operatingData.FailureDescription = operato.FailureDescription;
            operatingData.HumiditySensorValue = operato.HumiditySensorValue;
            operatingData.LocationHumiditySensor = operato.LocationHumiditySensor;
            operatingData.MethodofFailure = operato.MethodofFailure;
            operatingData.RadiationSensorLocation = operato.RadiationSensorLocation;
            operatingData.RadiationSensorValue = operato.RadiationSensorValue;
            operatingData.TemperatureSensorLocation = operato.TemperatureSensorLocation;
            operatingData.TemperatureSensorValue = operato.TemperatureSensorValue;

            return operatingData;
        }

        public List<MaintenanceCableViewModel> GetAllMaintenanceCableForExcel()
        {
            return _context.MaintenanceCables.Where(m => m.IsDelete == false).Select(c => new MaintenanceCableViewModel()
            {
                //ID=c.ID,
                AcceptanceCriteria = c.AcceptanceCriteria,
                AttachActFileName = c.AttachActFileName,
                AttachActNo = c.AttachActNo,
                CableID = c.CableID,
                CableIDGroup = c.CableIDGroup,
                DescriptionMaintenanceReasons = c.DescriptionMaintenanceReasons,
                EndTimeMaintenance=c.EndTimeMaintenance,
                Owner=c.Owner,
                Result=c.Resault,
                StartTimeMaintenance=c.StartTimeMaintenance,
                TypeofMaintenancework=c.TypeofMaintenancework,
                TypeTests=c.TypeTests,
                Value=c.Value,
                VisualResultMaintenance=c.VisualResultMaintenance,
                AttachActImage=c.AttachActImage
            }).ToList();
        }

        public MaintenanceCableViewModel GetMaintenanceCableByIdForExcel(int maintenanceId)
        {
            var maintenance = GetMaintenanceCableById(maintenanceId);

            MaintenanceCableViewModel maintenanceCable=new MaintenanceCableViewModel();

            //maintenanceCable.ID = maintenance.ID;
            maintenanceCable.AcceptanceCriteria = maintenance.AcceptanceCriteria;
            maintenanceCable.AttachActFileName = maintenance.AttachActFileName;
            maintenanceCable.AttachActNo = maintenance.AttachActNo;
            maintenanceCable.CableID = maintenance.CableID;
            maintenanceCable.CableIDGroup = maintenance.CableIDGroup;
            maintenanceCable.DescriptionMaintenanceReasons = maintenance.DescriptionMaintenanceReasons;
            maintenanceCable.EndTimeMaintenance = maintenance.EndTimeMaintenance;
            maintenanceCable.Owner = maintenance.Owner;
            maintenanceCable.Result = maintenance.Resault;
            maintenanceCable.StartTimeMaintenance = maintenance.StartTimeMaintenance;
            maintenanceCable.TypeofMaintenancework = maintenance.TypeofMaintenancework;
            maintenanceCable.TypeTests = maintenance.TypeTests;
            maintenanceCable.Value = maintenance.Value;
            maintenanceCable.VisualResultMaintenance = maintenance.VisualResultMaintenance;
            maintenanceCable.AttachActImage = maintenance.AttachActImage;

            return maintenanceCable;
        }

        public List<GeneralCablesViewModel> GetAllGeneralCablesForExcel()
        {
            return _context.GeneralCables.Where(g => g.IsDelete == false).Select(c => new GeneralCablesViewModel()
            { 
                Current=c.Current,
                ClassificationofCable=c.ClassificationofCable,
                //ID=c.ID,
                CableID=c.CableID,
                CableIDGroup=c.CableIDGroup,
                CableLength=c.CableLength,
                DesignLife=c.DesignLife,
                ExpectedDegradationMechanisms=c.ExpectedDegradationMechanisms,
                From=c.From,
                InstallationDate=c.InstallationDate,
                InsulationMaterial=c.InsulationMaterial,
                IntermediateLocations=c.IntermediateLocations,
                JacketMaterial=c.JacketMaterial,
                ListofCable=c.ListofCable,
                Location=c.Location,
                LogTime=c.LogTime,  
                Manufacturer = c.Manufacturer,
                ManufacturingYear=c.ManufacturingYear,
                NominalCurrent=c.NominalCurrent,
                NominalVoltage=c.NominalVoltage,
                NumberofSimilarCables=c.NumberofSimilarCables,
                OperatingAmbientTemperature = c.OperatingAmbientTemperature,
                Owner = c.Owner,
                RemainingDesignLifeTime = c.RemainingDesignLifeTime,
                ResistanceBDBAConditionFilename = c.ResistanceBDBAConditionFilename,
                ResistancetoDBAConditionFilename = c.ResistancetoDBAConditionFilename,
                ResultFactoryTestsFilename = c.ResultFactoryTestsFilename,
                ResultTestsEndInstallationFilename = c.ResultTestsEndInstallationFilename,
                ServiceLife = c.ServiceLife,
                To = c.To,
                TotalLengthofSimilarCables = c.TotalLengthofSimilarCables,
                ResistanceBDBAConditionImage=c.ResistanceBDBAConditionImage,
                ResistancetoDBAConditionImage=c.ResistancetoDBAConditionImage,
                ResultFactoryTestsImage=c.ResultFactoryTestsImage,
                ResultTestsEndInstallationImage=c.ResultTestsEndInstallationImage,
                TypeofCable = c.TypeofCable
            }).ToList();
        }

        public GeneralCablesViewModel GetCablesGeneralByIdForExcel(int cableId)
        {
            var general = GetCablesGeneralById(cableId);

            GeneralCablesViewModel generalCables = new GeneralCablesViewModel();

            generalCables.Current = general.Current;
            generalCables.ClassificationofCable = general.ClassificationofCable;
            //generalCables.ID = general.ID;
            generalCables.CableID = general.CableID;
            generalCables.CableIDGroup = general.CableIDGroup;
            generalCables.CableLength = general.CableLength;
            generalCables.DesignLife = general.DesignLife;
            generalCables.ExpectedDegradationMechanisms = general.ExpectedDegradationMechanisms;
            generalCables.From = general.From;
            generalCables.InstallationDate = general.InstallationDate;
            generalCables.InsulationMaterial = general.InsulationMaterial;
            generalCables.IntermediateLocations = general.IntermediateLocations;
            generalCables.JacketMaterial = general.JacketMaterial;
            generalCables.ListofCable = general.ListofCable;
            generalCables.Location = general.Location;
            generalCables.LogTime = general.LogTime;
            generalCables.Manufacturer = general.Manufacturer;
            generalCables.ManufacturingYear = general.ManufacturingYear;
            generalCables.NominalCurrent = general.NominalCurrent;
            generalCables.NominalVoltage = general.NominalVoltage;
            generalCables.NumberofSimilarCables = general.NumberofSimilarCables;
            generalCables.OperatingAmbientTemperature = general.OperatingAmbientTemperature;
            generalCables.Owner = general.Owner;
            generalCables.RemainingDesignLifeTime = general.RemainingDesignLifeTime;
            generalCables.ResistanceBDBAConditionFilename = general.ResistanceBDBAConditionFilename;
            generalCables.ResistancetoDBAConditionFilename = general.ResistancetoDBAConditionFilename;
            generalCables.ResultFactoryTestsFilename = general.ResultFactoryTestsFilename;
            generalCables.ResultTestsEndInstallationFilename = general.ResultTestsEndInstallationFilename;
            generalCables.ServiceLife = general.ServiceLife;
            generalCables.To = general.To;
            generalCables.TotalLengthofSimilarCables = general.TotalLengthofSimilarCables;
            generalCables.TypeofCable = general.TypeofCable;

            generalCables.ResistanceBDBAConditionImage = general.ResistanceBDBAConditionImage;
            generalCables.ResistancetoDBAConditionImage = general.ResistancetoDBAConditionImage;
            generalCables.ResultFactoryTestsImage = general.ResultFactoryTestsImage;
            generalCables.ResultTestsEndInstallationImage = general.ResultTestsEndInstallationImage;

            return generalCables;
        }

        public List<ElectromotorsExportViewModel> GetAllElectromotosForExport()
        {
            return _context.Electromotors.Where(e => e.IsDelete == false).
               Select(e => new ElectromotorsExportViewModel()
               {
                   Name = e.Name,
                   Azk = e.Azk,
                   InstalationPosition = e.Position,
               }).ToList();
        }

        public ElectromotorsExportViewModel GetElectromotorByIdExport(int electromotorId)
        {
            var electro = GetElectromotorById(electromotorId);

            ElectromotorsExportViewModel electromotorsViewModel = new ElectromotorsExportViewModel();
            electromotorsViewModel.Azk = electro.Azk;
            electromotorsViewModel.Name= electro.Name;
            electromotorsViewModel.InstalationPosition = electro.Position;

            return electromotorsViewModel;
        }

        public List<GeneratorExportViewModel> GetAllGeneratorsForExport()
        {
            return _context.Generators.Where(e => e.IsDelete == false).
               Select(e => new GeneratorExportViewModel()
               {
                   Name = e.Name,
                   Azk = e.Azk,
                   InstalationPosition = e.Position,
               }).ToList();
        }

        public GeneratorExportViewModel GetGeneratorByIdForExport(int generatorId)
        {
            var generator = GetGeneratorById(generatorId);

            GeneratorExportViewModel generatorViewModel = new GeneratorExportViewModel();
            generatorViewModel.InstalationPosition= generator.Position;
            generatorViewModel.Name= generator.Name;
            generatorViewModel.Azk= generator.Azk;

            return generatorViewModel;
        }

        public List<TransformerExportViewModel> GetAllTransformersForExport()
        {
            return _context.Transformers.Where(e => e.IsDelete == false).
                Select(e => new TransformerExportViewModel()
                {
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                }).ToList();
        }

        public TransformerExportViewModel GetTransformerByIdForExport(int transformerId)
        {
            var transformer = GetTransformerById(transformerId);

            TransformerExportViewModel transformerViewModel = new TransformerExportViewModel();
            transformerViewModel.Name= transformer.Name;
            transformerViewModel.Azk = transformer.Azk;
            transformerViewModel.InstalationPosition= transformer.Position;

            return transformerViewModel;
        }

        public List<ValvesExportViewModel> GetAllValvesForExport()
        {
            return _context.ElectroValves.Where(e => e.IsDelete == false).
                Select(e => new ValvesExportViewModel()
                {
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                }).ToList();
        }

        public ValvesExportViewModel GetValveByIdForExport(int valveId)
        {
            var valve=GetValveById(valveId);

            ValvesExportViewModel valveViewModel = new ValvesExportViewModel();
            valveViewModel.InstalationPosition = valve.Position;
            valveViewModel.Name = valve.Name;
            valveViewModel.Azk = valve.Azk;

            return valveViewModel;
        }

        public List<DieselExportViewModel> GetAllDieselsForExport()
        {
            return _context.Dieselgenerators.Where(e => e.IsDelete == false).
                Select(e => new DieselExportViewModel()
                {
                    Name = e.Name,
                    Azk = e.Azk,
                    InstalationPosition = e.Position,
                }).ToList();
        }

        public DieselExportViewModel GetDieselByIdForExport(int dieselId)
        {
            var disel = GetDieselById(dieselId);

            DieselExportViewModel dieselViewModel = new DieselExportViewModel();
            dieselViewModel.InstalationPosition=disel.Position;
            dieselViewModel.Name=disel.Name;
            dieselViewModel.Azk=disel.Azk;  

            return dieselViewModel;
        }
    }
}