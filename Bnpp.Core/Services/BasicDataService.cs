using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Migrations;
using Bnpp.DataLayer.Migrations.Transient;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;

namespace Bnpp.Core.Services
{
	public class BasicDataService : IBasicDataService
    {
        private BnppContext _context;

        public BasicDataService(BnppContext context)
        {
            _context = context;
        }

        #region GeneralData

        public List<GeneralData> GetAllGeneralData(int mechanicalId)
        {
            return _context.GeneralData.Where(g => g.IsDelete == false && g.MechanicalId == mechanicalId).ToList();
        }

        public int AddGeneralData(GeneralData data)
        {
            data.CreateDate = DateTime.Now;
            _context.Add(data);
            _context.SaveChanges();
            return data.GeneralId;
        }

        public void UpdateGeneralData(GeneralData data)
        {
            data.CreateDate = DateTime.Now;
            _context.Update(data);
            _context.SaveChanges();
        }

        public GeneralData GetGeneralDataById(int generalId)
        {
            return _context.GeneralData.Find(generalId);
        }

        public void DeleteGeneralData(int generalId)
        {
            var general = GetGeneralDataById(generalId);
            general.IsDelete = true;
            UpdateGeneralData(general);
        }

        #endregion

        #region DesignData

        public List<DesignData> GetAllDesignData(int mechanicalId)

        {
            return _context.DesignData.Where(g => g.IsDelete == false && g.MechanicalId == mechanicalId).ToList();
        }

        public int AddDesignData(DesignData design)
        {
            design.CreateDate = DateTime.Now;
            _context.DesignData.Add(design);
            _context.SaveChanges();
            return design.DesignId;
        }

        public void UpdateDesignData(DesignData design)
        {
            design.CreateDate = DateTime.Now;
            _context.Update(design);
            _context.SaveChanges();
        }

        public DesignData GetDesignDataById(int designId)
        {
            return _context.DesignData.Find(designId);
        }

        public void DeleteDesignData(int designId)
        {
            var design = GetDesignDataById(designId);
            design.IsDelete = true;
            UpdateDesignData(design);
        }

        #endregion

        #region DesignDocument

        public List<DesignDocument> GetAllDesignDocument(int mechanicalId)
        {
            return _context.DesignDocuments.Where(d => d.IsDelete == false && d.MechanicalId == mechanicalId).ToList();
        }

        public int AddDesignDocument(DesignDocument designDocument, IFormFile imgDesignDocument)
        {
            designDocument.CreateDate = DateTime.Now;

            if (imgDesignDocument != null)
            {
                designDocument.DesignDocumentImage = Guid.NewGuid() + Path.GetExtension(imgDesignDocument.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", designDocument.DesignDocumentImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgDesignDocument.CopyTo(stream);
                }
            }

            _context.Add(designDocument);
            _context.SaveChanges();
            return designDocument.DocumentId;
        }

        public DesignDocument GetDesignDocumentById(int designDocumentId)
        {
            return _context.DesignDocuments.Find(designDocumentId);
        }

        public void UpdateDesignDocument(DesignDocument designDocument, IFormFile imgDesignDocument)
        {
            designDocument.CreateDate = DateTime.Now;

            if (imgDesignDocument != null)
            {
                designDocument.DesignDocumentImage = Guid.NewGuid() + Path.GetExtension(imgDesignDocument.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", designDocument.DesignDocumentImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgDesignDocument.CopyTo(stream);
                }
            }

            _context.Update(designDocument);
            _context.SaveChanges();
        }

        public void DeleteDesignDocument(int designDocumentId)
        {
            var document = GetDesignDocumentById(designDocumentId);
            document.IsDelete = true;
            _context.Update(document);
            _context.SaveChanges();
        }

        #endregion

        #region ChemicalNorms

        public List<ChemicalNorms> GetAllChemicalNorms(int mechanicalId)
        {
            return _context.ChemicalNorms.Where(c => c.IsDelete == false && c.MechanicalId == mechanicalId).ToList();
        }

        public int AddChemicalNorms(ChemicalNorms chemical)
        {
            chemical.CreateDate = DateTime.Now;
            _context.Add(chemical);
            _context.SaveChanges();
            return chemical.ChemicalId;
        }

        public ChemicalNorms GetChemicalNormsById(int chemicalId)
        {
            return _context.ChemicalNorms.Find(chemicalId);
        }

        public void UpdateChemicalNorms(ChemicalNorms chemical)
        {
            chemical.CreateDate = DateTime.Now;
            _context.Update(chemical);
            _context.SaveChanges();
        }

        public void DeleteChemicalNorms(int chemicalId)
        {
            var chemicals = GetChemicalNormsById(chemicalId);
            chemicals.IsDelete = true;
            UpdateChemicalNorms(chemicals);
        }

        #endregion

        #region InspectionProgram

        public List<InspectionProgram> GetAllInspectionProgram(int mechanicalId)
        {
            return _context.InspectionPrograms.Where(p => p.IsDelete == false && p.MechanicalId == mechanicalId).ToList();
        }

        public int AddInspectionProgram(InspectionProgram program)
        {
            program.CreateDate = DateTime.Now;
            _context.Add(program);
            _context.SaveChanges();
            return program.InspectionProgramId;
        }

        public InspectionProgram GetInspectionProgramById(int programId)
        {
            return _context.InspectionPrograms.Find(programId);
        }

        public void UpdateInspectionProgram(InspectionProgram program)
        {
            program.CreateDate = DateTime.Now;
            _context.Update(program);
            _context.SaveChanges();
        }

        public void DeleteInspectionProgram(int programId)
        {
            var inspectionProgram = GetInspectionProgramById(programId);
            inspectionProgram.IsDelete = true;
            _context.Update(inspectionProgram);
            _context.SaveChanges();
        }

        #endregion

        #region Sensors

        public List<Sensors> GetAllSensors(int mechanicalId)
        {
            return _context.Sensors.Where(s => s.IsDelete == false && s.MechanicalId == mechanicalId).ToList();
        }

        public int AddSensors(Sensors sensors)
        {
            sensors.CreateDate = DateTime.Now;
            _context.Add(sensors);
            _context.SaveChanges();
            return sensors.SensorId;
        }

        public Sensors GetSensorsById(int sensorId)
        {
            return _context.Sensors.Find(sensorId);
        }

        public void UpdateSensors(Sensors sensors)
        {
            sensors.CreateDate = DateTime.Now;
            _context.Update(sensors);
            _context.SaveChanges();
        }

        public void DeleteSensors(int sensorId)
        {
            var ssensor = GetSensorsById(sensorId);
            ssensor.IsDelete = true;
            UpdateSensors(ssensor);
        }

        #endregion

        #region ControlPoints

        public List<ControlPoints> GetAllControlPoints(int mechanicalId)
        {
            return _context.ControlPoints.Where(p => p.IsDelete == false && p.MechanicalId == mechanicalId).ToList();
        }

        public int AddControlPoints(ControlPoints points)
        {
            points.CreateDate = DateTime.Now;
            _context.Add(points);
            _context.SaveChanges();
            return points.PointId;
        }

        public ControlPoints GetControlPointsById(int pointId)
        {
            return _context.ControlPoints.Find(pointId);
        }

        public void UpdateControlPoints(ControlPoints points)
        {
            points.CreateDate = DateTime.Now;
            _context.Update(points);
            _context.SaveChanges();
        }

        public void DeleteControlPoints(int pointId)
        {
            var controlPoints = GetControlPointsById(pointId);
            controlPoints.IsDelete = true;

            UpdateControlPoints(controlPoints);
        }

        #endregion

        #region HForms

        public List<HForms> GetAllHForms(int mechanicalId)
        {
            return _context.HForms.Where(f => f.IsDelete == false && f.MechanicalId == mechanicalId).ToList();
        }

        public int AddHForms(HForms forms, IFormFile imgHForms)
        {
            forms.CreateDate = DateTime.Now;

            if (imgHForms != null)
            {
                forms.HFormsImage = Guid.NewGuid() + Path.GetExtension(imgHForms.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.HFormsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgHForms.CopyTo(stream);
                }
            }

            _context.Add(forms);
            _context.SaveChanges();
            return forms.HFormsId;
        }

        public HForms GetHFormsById(int formsId)
        {
            return _context.HForms.Find(formsId);
        }

        public void UpdateHForms(HForms forms, IFormFile imgHForms)
        {
            forms.CreateDate = DateTime.Now;

            if (imgHForms != null)
            {
                if (forms.HFormsImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.HFormsImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }

                forms.HFormsImage = Guid.NewGuid() + Path.GetExtension(imgHForms.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.HFormsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgHForms.CopyTo(stream);
                }
            }

            _context.Update(forms);
            _context.SaveChanges();

        }

        public void DeleteHForms(int formsId)
        {
            var hforms = GetHFormsById(formsId);
            hforms.IsDelete = true;
            _context.Update(hforms);
            _context.SaveChanges();
        }

        #endregion

        #region Components

        public List<Components> GetAllComponents(int mechanicalId)
        {
            return _context.Components.Where(c => c.IsDelete == false && c.MechanicalId == mechanicalId).ToList();
        }

        public int AddComponents(Components components, IFormFile imgComponents)
        {
            components.CreateDate = DateTime.Now;

            if (imgComponents != null)
            {
                components.ComponentsImage = Guid.NewGuid() + Path.GetExtension(imgComponents.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", components.ComponentsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgComponents.CopyTo(stream);
                }
            }

            _context.Add(components);
            _context.SaveChanges();
            return components.ComponentId;
        }

        public Components GetComponentsById(int componentsId)
        {
            return _context.Components.Find(componentsId);
        }

        public void UpdateComponents(Components components, IFormFile imgComponents)
        {
            components.CreateDate = DateTime.Now;

            if (imgComponents != null)
            {
                if (components.ComponentsImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", components.ComponentsImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                components.ComponentsImage = Guid.NewGuid() + Path.GetExtension(imgComponents.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", components.ComponentsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgComponents.CopyTo(stream);
                }
            }

            _context.Update(components);
            _context.SaveChanges();
        }

        public void DeleteComponents(int componentsId)
        {
            var component = GetComponentsById(componentsId);
            component.IsDelete = true;
            _context.Update(component);
            _context.SaveChanges();
        }



        #endregion

        #region 
        public List<MechanicalProperties> GetAllMechanicalProperties(int componentId)
        {
            return _context.MechanicalProperties.Where(p => p.ComponentId == componentId && p.IsDelete == false)
                .ToList();
        }

        public int AddMechanicalProperties(MechanicalProperties mechanical)
        {
            mechanical.CreateDate = DateTime.Now;
            _context.Add(mechanical);
            _context.SaveChanges();
            return mechanical.MechanicalPropertiesId;
        }

        public void UpdateMechanicalProperties(MechanicalProperties properties)
        {
            properties.CreateDate = DateTime.Now;
            _context.Update(properties);
            _context.SaveChanges();
        }

        public MechanicalProperties GetMechanicalPropertiesById(int mechanicalId)
        {
            return _context.MechanicalProperties.Find(mechanicalId);
        }

        public void DeleteMechanicalProperties(int mechanicalId)
        {
            var mekanik = GetMechanicalPropertiesById(mechanicalId);
            mekanik.IsDelete = true;
            _context.Update(mekanik);
            _context.SaveChanges();
        }


        #endregion

        #region
        public List<PhysicalProperties> GetAllPhysicalProperties(int componentId)
        {
            return _context.PhysicalProperties.Where(p => p.ComponentId == componentId && p.IsDelete == false)
               .ToList();
        }

        public int AddPhysicalProperties(PhysicalProperties physical)
        {
            physical.CreateDate = DateTime.Now;
            _context.Add(physical);
            _context.SaveChanges();
            return physical.PhysicalPropertiesId;
        }

        public void UpdatePhysicalProperties(PhysicalProperties physical)
        {
            physical.CreateDate = DateTime.Now;
            _context.Update(physical);
            _context.SaveChanges();
        }

        public PhysicalProperties GetPhysicalPropertiesById(int physicalId)
        {
            return _context.PhysicalProperties.Find(physicalId);
        }

        public void DeletePhysicalProperties(int physicalId)
        {
            var phisik = GetPhysicalPropertiesById(physicalId);
            phisik.IsDelete = true;
            _context.Update(phisik);
            _context.SaveChanges();
        }


        #endregion


        #region  ChemicalComponent
        public List<ChemicalComponent> GetAllChemicalComponent(int componentId)
        {
            return _context.ChemicalComponents.Where(p => p.ComponentId == componentId && p.IsDelete == false)
               .ToList();
        }

        public int AddChemicalComponent(ChemicalComponent chemical)
        {
            chemical.CreateDate = DateTime.Now;
            _context.Add(chemical);
            _context.SaveChanges();
            return chemical.ChemicalComponentId;
        }

        public void UpdateChemicalComponent(ChemicalComponent chemical)
        {
            chemical.CreateDate = DateTime.Now;
            _context.Update(chemical);
            _context.SaveChanges();
        }

        public ChemicalComponent GetChemicalComponentById(int chemicalId)
        {
            return _context.ChemicalComponents.Find(chemicalId);
        }

        public void DeleteChemicalComponent(int chemicalId)
        {
            var chemikal = GetChemicalComponentById(chemicalId);
            chemikal.IsDelete = true;
            _context.Update(chemikal);
            _context.SaveChanges();
        }


        #endregion

        #region Heat Operation

        public List<HeatOperation> GetAllHeatOperation(int componentId)
        {
            return _context.HeatOperation.Where(p => p.ComponentId == componentId && p.IsDelete == false)
              .ToList();
        }

        public int AddHeatOperation(HeatOperation heat, IFormFile imgHeatOperation)
        {
            heat.CreateDate = DateTime.Now;

            if (imgHeatOperation != null)
            {
                heat.HeatOperationImage = Guid.NewGuid() + Path.GetExtension(imgHeatOperation.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", heat.HeatOperationImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgHeatOperation.CopyTo(stream);
                }
            }

            _context.Add(heat);
            _context.SaveChanges();
            return heat.HeatOperationId;
        }

        public void UpdateHeatOperation(HeatOperation heat, IFormFile imgHeatOperation)
        {
            heat.CreateDate = DateTime.Now;

            if (imgHeatOperation != null)
            {
                if (heat.HeatOperationImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", heat.HeatOperationImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                heat.HeatOperationImage = Guid.NewGuid() + Path.GetExtension(imgHeatOperation.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", heat.HeatOperationImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgHeatOperation.CopyTo(stream);
                }
            }

            _context.Update(heat);
            _context.SaveChanges();
        }

        public HeatOperation GetHeatOperationById(int heatId)
        {
            return _context.HeatOperation.Find(heatId);
        }

        public void DeleteHeatOperation(int heatId)
        {
            var heating = GetHeatOperationById(heatId);
            heating.IsDelete = true;
            _context.Update(heating);
            _context.SaveChanges();
        }

        public List<GeneralDataViewModel> GetAllGeneralDataForExport(int mechanicalId)
        {
            return _context.GeneralData.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new GeneralDataViewModel()
            {
                DesignationOfParameters = c.DesignationOfParameters,
                Value = c.Value
            }).ToList();
        }

        public GeneralDataViewModel GetGeneralDataByIdForExport(int generalId)
        {
            var gener = GetGeneralDataById(generalId);

            GeneralDataViewModel generalDataViewModel = new GeneralDataViewModel();
            generalDataViewModel.DesignationOfParameters = gener.DesignationOfParameters;
            generalDataViewModel.Value = gener.Value;

            return generalDataViewModel;
        }

        public List<DesignDataViewModel> GetAllDesignDataForExport(int mechanicalId)
        {
            return _context.DesignData.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new DesignDataViewModel()
            {
                Description = c.Description,
                ParameterName = c.ParameterName,
                unit = c.unit,
                Value = c.Value
            }).ToList();
        }

        public DesignDataViewModel GetDesignDataByIdForExport(int designId)
        {
            var design = GetDesignDataById(designId);

            DesignDataViewModel designDataViewModel = new DesignDataViewModel();
            designDataViewModel.unit = design.unit;
            designDataViewModel.Description = design.Description;
            designDataViewModel.Value = design.Value;
            designDataViewModel.ParameterName = design.ParameterName;

            return designDataViewModel;
        }

        public List<DocumentsViewModel> GetAllDesignDocumentForExport(int mechanicalId)
        {
            return _context.DesignDocuments.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new DocumentsViewModel()
            {
                Code = c.Code,
                DesignDocumentImage = c.DesignDocumentImage,
                DocumentName = c.DocumentName,
                Filename = c.Filename
            }).ToList();
        }

        public DocumentsViewModel GetDesignDocumentByIdForExport(int designDocumentId)
        {
            var doc = GetDesignDocumentById(designDocumentId);

            DocumentsViewModel documentsViewModel = new DocumentsViewModel();
            documentsViewModel.Code = doc.Code;
            documentsViewModel.DesignDocumentImage = doc.DesignDocumentImage;
            documentsViewModel.DocumentName = doc.DocumentName;
            documentsViewModel.Filename = doc.Filename;

            return documentsViewModel;
        }

        public List<ComponentsViewModel> GetAllComponentsForExport(int mechanicalId)
        {
            return _context.Components.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new ComponentsViewModel()
            {
                ClassificationDesignation = c.ClassificationDesignation,
                ClassofSafety = c.ClassofSafety,
                //ComponentsImage = c.ComponentsImage,
                Designation = c.Designation,
                Diameter = c.Diameter,
                Group = c.Group,
                Item = c.Item,
                Length = c.Length,
                MaterialGrade = c.MaterialGrade,
                SeismicCategory = c.SeismicCategory,
                Serial = c.Serial,
                Thickness = c.Thickness,
                Filename = c.Filename,
                //mechanical properties
                Hardness = c.Hardness,
                ImpactToughness = c.ImpactToughness,
                ReductionArea = c.ReductionArea,
                SpecificElongation = c.SpecificElongation,
                MechanicalTemperature = c.MechanicalTemperature,
                UltimateStrength = c.UltimateStrength,
                YieldStrength = c.YieldStrength,
                YoungModule = c.YoungModule,
                //physical properties

                PhysicalTemperature = c.PhysicalTemperature,
                ConductivityFactor = c.ConductivityFactor,
                Density = c.Density,
                HeatCapacity = c.HeatCapacity,
                LinearExpension = c.LinearExpension,
                NormalRadiation = c.NormalRadiation,
                PoissonRatio = c.PoissonRatio,

                //heat opearation

                OperationTemperature = c.TreatmentTemperature,
                CoolingMethod = c.CoolingMethod,
                DocumentNo = c.DocumentNo,
                HeatsOperation = c.HeatsOperation,
                NoOfHeatOperations = c.NoOfHeatOperations,
                TimesOfHeating = c.TimesOfHeating,

                //chemical component
                As = c.As,
                C = c.C,
                Co = c.Co,
                Cu = c.Cu,
                Mn = c.Mn,
                Mo = c.Mo,
                Cr = c.Cr,
                NB = c.NB,
                Ni = c.Ni,
                S = c.S,
                P = c.P,
                Si = c.Si,
                V = c.V,
                Ti = c.Ti

            }).ToList();
        }

        public ComponentsViewModel GetComponentsByIdForExport(int componentsId)
        {
            var compo = GetComponentsById(componentsId);

            ComponentsViewModel componentsViewModel = new ComponentsViewModel();
            componentsViewModel.ClassificationDesignation = compo.ClassificationDesignation;
            componentsViewModel.ClassofSafety = compo.ClassofSafety;
            //componentsViewModel.ComponentsImage = compo.ComponentsImage;
            componentsViewModel.Designation = compo.Designation;
            componentsViewModel.Diameter = compo.Diameter;
            componentsViewModel.Group = compo.Group;
            componentsViewModel.Item = compo.Item;
            componentsViewModel.Length = compo.Length;
            componentsViewModel.MaterialGrade = compo.MaterialGrade;
            componentsViewModel.SeismicCategory = compo.SeismicCategory;
            componentsViewModel.Serial = compo.Serial;
            componentsViewModel.Thickness = compo.Thickness;
            componentsViewModel.Filename = compo.Filename;

            //mechanical properties
            componentsViewModel.Hardness = compo.Hardness;
            componentsViewModel.ImpactToughness = compo.ImpactToughness;
            componentsViewModel.ReductionArea = compo.ReductionArea;
            componentsViewModel.SpecificElongation = compo.SpecificElongation;
            componentsViewModel.MechanicalTemperature = compo.MechanicalTemperature;
            componentsViewModel.UltimateStrength = compo.UltimateStrength;
            componentsViewModel.YieldStrength = compo.YieldStrength;
            componentsViewModel.YoungModule = compo.YoungModule;

            //physical properties

            componentsViewModel.PhysicalTemperature = compo.PhysicalTemperature;
            componentsViewModel.ConductivityFactor = compo.ConductivityFactor;
            componentsViewModel.Density = compo.Density;
            componentsViewModel.HeatCapacity = compo.HeatCapacity;
            componentsViewModel.LinearExpension = compo.LinearExpension;
            componentsViewModel.NormalRadiation = compo.NormalRadiation;
            componentsViewModel.PoissonRatio = compo.PoissonRatio;

            //heat opearation

            componentsViewModel.OperationTemperature = compo.TreatmentTemperature;
            componentsViewModel.CoolingMethod = compo.CoolingMethod;
            componentsViewModel.DocumentNo = compo.DocumentNo;
            componentsViewModel.HeatsOperation = compo.HeatsOperation;
            componentsViewModel.NoOfHeatOperations = compo.NoOfHeatOperations;
            componentsViewModel.TimesOfHeating = compo.TimesOfHeating;

            //chemical component
            componentsViewModel.As = compo.As;
            componentsViewModel.C = compo.C;
            componentsViewModel.Co = compo.Co;
            componentsViewModel.Cu = compo.Cu;
            componentsViewModel.Mn = compo.Mn;
            componentsViewModel.Mo = compo.Mo;
            componentsViewModel.Cr = compo.Cr;
            componentsViewModel.NB = compo.NB;
            componentsViewModel.Ni = compo.Ni;
            componentsViewModel.S = compo.S;
            componentsViewModel.P = compo.P;
            componentsViewModel.Si = compo.Si;
            componentsViewModel.V = compo.V;
            componentsViewModel.Ti = compo.Ti;

            return componentsViewModel;
        }

        public List<ChemicalNormsViewModel> GetAllChemicalNormsForExport(int mechanicalId)
        {
            return _context.ChemicalNorms.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new ChemicalNormsViewModel()
            {
                IndexDescription = c.IndexDescription,
                Limit = c.Limit,
                Unit = c.Unit,
                Value = c.Value
            }).ToList();
        }

        public ChemicalNormsViewModel GetChemicalNormsByIdForExport(int chemicalId)
        {
            var chem = GetChemicalNormsById(chemicalId);
            ChemicalNormsViewModel normsViewModel = new ChemicalNormsViewModel();

            normsViewModel.IndexDescription = chem.IndexDescription;
            normsViewModel.Limit = chem.Limit;
            normsViewModel.Unit = chem.Unit;
            normsViewModel.Value = chem.Value;

            return normsViewModel;
        }

        public List<InspectionProgramViewModel> GetAllInspectionProgramForExport(int mechanicalId)
        {
            return _context.InspectionPrograms.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new InspectionProgramViewModel()
            {
                CategoryofWeldedjoints = c.CategoryofWeldedjoints,
                Code = c.Code,
                EquipmentDocument = c.EquipmentDocument,
                Note = c.Note,
                PeriodofInspection = c.PeriodofInspection,
                ScopeofInspection = c.ScopeofInspection,
                TechnicalDocuments = c.TechnicalDocuments,
                TestMethod = c.TestMethod

            }).ToList();
        }

        public InspectionProgramViewModel GetInspectionProgramByIdForExport(int programId)
        {
            var prog = GetInspectionProgramById(programId);

            InspectionProgramViewModel inspectionProgram = new InspectionProgramViewModel();

            inspectionProgram.CategoryofWeldedjoints = prog.CategoryofWeldedjoints;
            inspectionProgram.Code = prog.Code;
            inspectionProgram.EquipmentDocument = prog.EquipmentDocument;
            inspectionProgram.Note = prog.Note;
            inspectionProgram.PeriodofInspection = prog.PeriodofInspection;
            inspectionProgram.ScopeofInspection = prog.ScopeofInspection;
            inspectionProgram.TechnicalDocuments = prog.TechnicalDocuments;
            inspectionProgram.TestMethod = prog.TestMethod;

            return inspectionProgram;
        }

        public List<SensorsViewModel> GetAllSensorsForExport(int mechanicalId)
        {
            return _context.Sensors.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new SensorsViewModel()
            {
                AKZ = c.AKZ,
                KKS = c.KKS,
                Numberofsignals = c.Numberofsignals,
                Parametertomeasure = c.Parametertomeasure,
                Quantity = c.Quantity
            }).ToList();
        }

        public SensorsViewModel GetSensorsByIdForExport(int sensorId)
        {
            var sensor = GetSensorsById(sensorId);

            SensorsViewModel sensors = new SensorsViewModel();

            sensors.AKZ = sensor.AKZ;
            sensors.KKS = sensor.KKS;
            sensors.Numberofsignals = sensor.Numberofsignals;
            sensors.Parametertomeasure = sensor.Parametertomeasure;
            sensors.Quantity = sensor.Quantity;

            return sensors;
        }

        public List<ControlPointsViewModel> GetAllControlPointsForExport(int mechanicalId)
        {
            return _context.ControlPoints.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new ControlPointsViewModel()
            {
                MeasurementRange = c.MeasurementRange,
                NumberCheckPoints = c.NumberCheckPoints,
                Parameter = c.Parameter,
                Remarks = c.Remarks
            }).ToList();
        }

        public ControlPointsViewModel GetControlPointsByIdForExport(int pointId)
        {
            var point = GetControlPointsById(pointId);

            ControlPointsViewModel pointsViewModel = new ControlPointsViewModel()
;
            pointsViewModel.NumberCheckPoints = point.NumberCheckPoints;
            pointsViewModel.Parameter = point.Parameter;
            pointsViewModel.MeasurementRange = point.MeasurementRange;
            pointsViewModel.Remarks = point.Remarks;

            return pointsViewModel;
        }

        public List<HFormsViewModel> GetAllHFormsForExport(int mechanicalId)
        {
            return _context.HForms.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new HFormsViewModel()
            {
                Code = c.Code,
                DocumentName = c.DocumentName,
                Filename = c.Filename,
                HFormsImage = c.HFormsImage
            }).ToList();
        }

        public HFormsViewModel GetHFormsByIdForExport(int formsId)
        {
            var form = GetHFormsById(formsId);

            HFormsViewModel hForms = new HFormsViewModel();

            hForms.Code = form.Code;
            hForms.DocumentName = form.DocumentName;
            hForms.Filename = form.Filename;
            hForms.HFormsImage = form.HFormsImage;

            return hForms;
        }

        public List<MechanicalPropertiesViewModel> GetAllMechanicalPropertiesForExport(int componentId)
        {
            return _context.Components.Where(p => p.ComponentId == componentId && p.IsDelete == false)
                .Select(c => new MechanicalPropertiesViewModel()
                {
                    Hardness = c.Hardness,
                    ImpactToughness = c.ImpactToughness,
                    ReductionArea = c.ReductionArea,
                    SpecificElongation = c.SpecificElongation,
                    Temperature = c.MechanicalTemperature,
                    UltimateStrength = c.UltimateStrength,
                    YieldStrength = c.YieldStrength,
                    YoungModule = c.YoungModule
                }).ToList();
        }

        public MechanicalPropertiesViewModel GetMechanicalPropertiesByIdForExport(int mechanicalId)
        {
            var mechanic = GetMechanicalPropertiesById(mechanicalId);

            MechanicalPropertiesViewModel propertiesViewModel = new MechanicalPropertiesViewModel();

            propertiesViewModel.Hardness = mechanic.Hardness;
            propertiesViewModel.ImpactToughness = mechanic.ImpactToughness;
            propertiesViewModel.ReductionArea = mechanic.ReductionArea;
            propertiesViewModel.SpecificElongation = mechanic.SpecificElongation;
            propertiesViewModel.Temperature = mechanic.Temperature;
            propertiesViewModel.UltimateStrength = mechanic.UltimateStrength;
            propertiesViewModel.YieldStrength = mechanic.YieldStrength;
            propertiesViewModel.YoungModule = mechanic.YoungModule;

            return propertiesViewModel;
        }

        public List<PhysicalPropertiesViewModel> GetAllPhysicalPropertiesForExport(int componentId)
        {
            return _context.Components.Where(p => p.ComponentId == componentId && p.IsDelete == false).Select(c => new PhysicalPropertiesViewModel()
            {
                Temperature = c.PhysicalTemperature,
                ConductivityFactor = c.ConductivityFactor,
                Density = c.Density,
                HeatCapacity = c.HeatCapacity,
                LinearExpension = c.LinearExpension,
                NormalRadiation = c.NormalRadiation,
                PoissonRatio = c.PoissonRatio
            })
                .ToList();
        }

        public PhysicalPropertiesViewModel GetPhysicalPropertiesByIdForExport(int physicalId)
        {
            var physic = GetPhysicalPropertiesById(physicalId);

            PhysicalPropertiesViewModel propertiesViewModel = new PhysicalPropertiesViewModel();

            propertiesViewModel.Temperature = physic.Temperature;
            propertiesViewModel.ConductivityFactor = physic.ConductivityFactor;
            propertiesViewModel.Density = physic.Density;
            propertiesViewModel.HeatCapacity = physic.HeatCapacity;
            propertiesViewModel.LinearExpension = physic.LinearExpension;
            propertiesViewModel.NormalRadiation = physic.NormalRadiation;
            propertiesViewModel.PoissonRatio = physic.PoissonRatio;

            return propertiesViewModel;
        }

        public List<HeatOperationViewModel> GetAllHeatOperationForExport(int componentId)
        {
            return _context.Components.Where(p => p.ComponentId == componentId && p.IsDelete == false)
             .Select(c => new HeatOperationViewModel()
             {
                 Temperature = c.TreatmentTemperature,
                 CoolingMethod = c.CoolingMethod,
                 DocumentNo = c.DocumentNo,
                 Filename = c.Filename,
                 HeatsOperation = c.HeatsOperation,
                 NoOfHeatOperations = c.NoOfHeatOperations,
                 TimesOfHeating = c.TimesOfHeating
             }).ToList();
        }

        public HeatOperationViewModel GetHeatOperationByIdForExport(int heatId)
        {
            var heat = GetHeatOperationById(heatId);

            HeatOperationViewModel heatOperationViewModel = new HeatOperationViewModel();

            heatOperationViewModel.Temperature = heat.Temperature;
            heatOperationViewModel.CoolingMethod = heat.CoolingMethod;
            heatOperationViewModel.DocumentNo = heat.DocumentNo;
            heatOperationViewModel.Filename = heat.Filename;
            heatOperationViewModel.HeatsOperation = heat.HeatsOperation;
            heatOperationViewModel.NoOfHeatOperations = heat.NoOfHeatOperations;
            heatOperationViewModel.TimesOfHeating = heat.TimesOfHeating;

            return heatOperationViewModel;
        }

        public List<ChemicalComponentViewModel> GetAllChemicalComponentForExport(int componentId)
        {
            return _context.Components.Where(p => p.ComponentId == componentId && p.IsDelete == false)
              .Select(c => new ChemicalComponentViewModel()
              {
                  As = c.As,
                  C = c.C,
                  Co = c.Co,
                  Cu = c.Cu,
                  Mn = c.Mn,
                  Mo = c.Mo,
                  Cr = c.Cr,
                  NB = c.NB,
                  Ni = c.Ni,
                  S = c.S,
                  P = c.P,
                  Si = c.Si,
                  V = c.V,
                  Ti = c.Ti
              }).ToList();
        }

        public ChemicalComponentViewModel GetChemicalComponentByIdForExport(int chemicalId)
        {
            var chemic = GetChemicalComponentById(chemicalId);

            ChemicalComponentViewModel componentViewModel = new ChemicalComponentViewModel();

            componentViewModel.As = chemic.As;
            componentViewModel.C = chemic.C;
            componentViewModel.Co = chemic.Co;
            componentViewModel.Cu = chemic.Cu;
            componentViewModel.Mn = chemic.Mn;
            componentViewModel.Mo = chemic.Mo;
            componentViewModel.Cr = chemic.Cr;
            componentViewModel.NB = chemic.NB;
            componentViewModel.Ni = chemic.Ni;
            componentViewModel.S = chemic.S;
            componentViewModel.P = chemic.P;
            componentViewModel.Si = chemic.Si;
            componentViewModel.V = chemic.V;
            componentViewModel.Ti = chemic.Ti;

            return componentViewModel;
        }



        #endregion
        #region Seismic Category

        public List<SeismicCategory> GetAllSeismicCategory(int mechanicalId)
        {
            return _context.SeismicCategory.Where(c => c.IsDelete == false && c.MechanicalId == mechanicalId).ToList();
        }

        public List<SeismicCategoryViewModel> GetAllSeismicCategoryForExport(int mechanicalId)
        {
            return _context.SeismicCategory.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).Select(c => new SeismicCategoryViewModel()
            {
                NameAndDesignation = c.NameAndDesignation,
                ClassificationDesignation = c.ClassificationDesignation,
                CategoryGroup = c.CategoryGroup,
                CategorySeismic = c.CategorySeismic,
                SafetyClass = c.SafetyClass
            }).ToList();
        }

        public int AddSeismicCategory(SeismicCategory category)
        {
            category.CreateDate = DateTime.Now;
            _context.Add(category);
            _context.SaveChanges();
            return category.CategoryId;
        }

        public SeismicCategory GetSeismicCategoryById(int categoryId)
        {
            return _context.SeismicCategory.Find(categoryId);
        }

        public SeismicCategoryViewModel GetSeismicCategoryByIdForExport(int categoryId)
        {
            var seisemic = GetSeismicCategoryById(categoryId);
            SeismicCategoryViewModel categoryViewModel = new SeismicCategoryViewModel();
            categoryViewModel.NameAndDesignation = seisemic.NameAndDesignation;
            categoryViewModel.SafetyClass = seisemic.SafetyClass;
            categoryViewModel.ClassificationDesignation = seisemic.ClassificationDesignation;
            categoryViewModel.CategoryGroup = seisemic.CategoryGroup;
            categoryViewModel.CategorySeismic = seisemic.CategorySeismic;

            return categoryViewModel;
        }

        public void UpdateSeismicCategory(SeismicCategory category)
        {
            category.CreateDate = DateTime.Now;
            _context.Update(category);
            _context.SaveChanges();
        }

        public void DeleteSeismicCategory(int categoryId)
        {
            var category = GetSeismicCategoryById(categoryId);
            category.IsDelete = true;

            UpdateSeismicCategory(category);
        }



        #endregion

        #region General Document

        public List<InspectionDocument> GetAllGeneralDataDocument(int mechanicalId)
        {
            return _context.InspectionDocuments.Where(o => o.TypeId == 18 && o.IsDelete == false && o.MechanicalId == mechanicalId).ToList();
        }

        public int AddGeneralDataDocument(InspectionDocument document, IFormFile fileGeneral)
        {
           
            //document.CreateDate = DateTime.Now;
            //document.TypeId = 18;
            //document.Filename = fileGeneral.FileName;
            document.InspectionImage = Guid.NewGuid() + Path.GetExtension(fileGeneral.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.InspectionImage);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                fileGeneral.CopyTo(stream);
            }
            _context.Add(document);
            _context.SaveChanges();


            return document.InspectionId;
        }

		public void DeleteGeneralDocumentData(int generalDocumentId)
		{
			

            var document = _context.InspectionDocuments.Find(generalDocumentId);
			document.IsDelete = true;
            _context.Update(document);
            _context.SaveChanges();
		}

		#endregion
	}
}
