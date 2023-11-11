using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.Maintenance;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private BnppContext _context;

        public MaintenanceService(BnppContext context)
        {
            _context = context;
        }



        #region DefectList


        public int AddDefectList(DefectList defect)
        {
            defect.CreateDate = DateTime.Now;
            _context.Add(defect);
            _context.SaveChanges();
            return defect.DefectListId;
        }



        public void DeleteDefectList(int defectId)
        {
            var dlist = GetDefectListById(defectId);
            dlist.IsDelete = true;
            _context.Update(dlist);
            _context.SaveChanges();
        }



        public List<DefectList> GetAllDefectList(int mechanicalId)
        {
            return _context.DefectList.Where(d => d.IsDelete == false && d.MechanicalId == mechanicalId).ToList();
        }



        public DefectList GetDefectListById(int defectId)
        {
            return _context.DefectList.Find(defectId);
        }



        public void UpdateDefectList(DefectList defect)
        {
            defect.CreateDate = DateTime.Now;
            _context.Update(defect);
            _context.SaveChanges();
        }




        #endregion

        #region Spare Parts

        public int AddSpareParts(SpareParts spare)
        {
            spare.CreateDate = DateTime.Now;
            _context.Add(spare);
            _context.SaveChanges();
            return spare.SpareId;
        }

        public SpareParts GetSparePartsById(int spareId)
        {
            return _context.SpareParts.Find(spareId);
        }

        public void UpdateSpareParts(SpareParts spare)
        {
            spare.CreateDate = DateTime.Now;
            _context.Update(spare);
            _context.SaveChanges();
        }

        public List<SpareParts> GetAllSpareParts(int mechanicalId)
        {
            return _context.SpareParts.Where(s => s.IsDelete == false && s.MechanicalId == mechanicalId).ToList();
        }

        public void DeleteSpareParts(int spareId)
        {
            var splist = GetSparePartsById(spareId);
            splist.IsDelete = true;
            UpdateSpareParts(splist);

        }


        #endregion
        #region Measurements

        public List<Measurements> GetAllMeasurements(int mechanicalId)
        {
            return _context.Measurements.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).ToList();
        }

        public int AddMeasurements(Measurements measure)
        {
            measure.CreateDate = DateTime.Now;
            _context.Add(measure);
            _context.SaveChanges();
            return measure.MeasurementId;
        }

        public Measurements GetMeasurementsById(int measureId)
        {
            return _context.Measurements.Find(measureId);
        }

        public void UpdateMeasurements(Measurements measure)
        {
            measure.CreateDate = DateTime.Now;
            _context.Update(measure);
            _context.SaveChanges();
        }

        public void DeleteMeasurements(int measureId)
        {
            var mesure = GetMeasurementsById(measureId);
            mesure.IsDelete = true;
            UpdateMeasurements(mesure);
        }



        #endregion

        #region Maintenance Forms

        public List<MaintenanceForm> GetAllMaintenanceForm(int mechanicalId)
        {
            return _context.MaintenanceForms.Where(f => f.IsDelete == false && f.MechanicalId == mechanicalId).ToList();
        }

        public int AddMaintenanceForm(MaintenanceForm forms, IFormFile imgForms)
        {

            forms.CreateDate = DateTime.Now;

            if (imgForms != null)
            {
                forms.MaintenanceFormImage = Guid.NewGuid() + Path.GetExtension(imgForms.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.MaintenanceFormImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgForms.CopyTo(stream);
                }
            }

            _context.Add(forms);
            _context.SaveChanges();
            return forms.MaintenanceFormId;

        }

        public MaintenanceForm GetMaintenanceFormById(int formsId)
        {
            return _context.MaintenanceForms.Find(formsId);
        }

        public void UpdateMaintenanceForm(MaintenanceForm forms, IFormFile imgForms)
        {
            forms.CreateDate = DateTime.Now;

            if (imgForms != null)
            {
                if (forms.MaintenanceFormImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.MaintenanceFormImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                forms.MaintenanceFormImage = Guid.NewGuid() + Path.GetExtension(imgForms.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", forms.MaintenanceFormImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgForms.CopyTo(stream);
                }
            }

            _context.Update(forms);
            _context.SaveChanges();
        }

        public void DeleteMaintenanceForm(int formsId)
        {
            var form = GetMaintenanceFormById(formsId);
            form.IsDelete = true;
            _context.Update(form);
            _context.SaveChanges();
        }





        #endregion

        #region DefectionReports

        public List<DefectionReports> GetAllDefectionReports(int mechanicalId)
        {
            return _context.DefectionReports.Where(d => d.IsDelete == false&&d.MechanicalId==mechanicalId).ToList();
        }

        public int AddDefectionReports(DefectionReports reports, IFormFile imgReports)
        {
            reports.CreateDate = DateTime.Now;

            if (imgReports != null)
            {
                reports.DefectionReportsImage = Guid.NewGuid() + Path.GetExtension(imgReports.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", reports.DefectionReportsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgReports.CopyTo(stream);
                }
            }

            _context.Add(reports);
            _context.SaveChanges();
            return reports.DefectionReportsId;
        }

        public DefectionReports GetDefectionReportsById(int reportsId)
        {
            return _context.DefectionReports.Find(reportsId);
        }

        public void UpdateDefectionReports(DefectionReports reports, IFormFile imgReports)
        {
            reports.CreateDate = DateTime.Now;

            if (imgReports != null)
            {
                if (reports.DefectionReportsImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", reports.DefectionReportsImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }


                reports.DefectionReportsImage = Guid.NewGuid() + Path.GetExtension(imgReports.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", reports.DefectionReportsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgReports.CopyTo(stream);
                }
            }

            _context.Update(reports);
            _context.SaveChanges();
        }

        public void DeleteDefectionReports(int reportsId)
        {
            var rports = GetDefectionReportsById(reportsId);
            rports.IsDelete = true;
            _context.Update(rports);
            _context.SaveChanges();
        }

        #endregion


        #region Program document

        public List<ProgramsDocument> GetAllProgramsDocument()
        {
            return _context.ProgramsDocuments.Where(d => d.IsDelete == false).ToList();
        }

        public int AddProgramsDocument(ProgramsDocument document, IFormFile imgDocument)
        {
            document.CreateDate = DateTime.Now;

            if (imgDocument != null)
            {
                if (document.ProgramsDocumentImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.ProgramsDocumentImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }

                document.ProgramsDocumentImage = Guid.NewGuid() + Path.GetExtension(imgDocument.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.ProgramsDocumentImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgDocument.CopyTo(stream);
                }
            }

            _context.Add(document);
            _context.SaveChanges();
            return document.ProgramsDocumentId;
        }

        public ProgramsDocument GetProgramsDocumentById(int documentId)
        {
            return _context.ProgramsDocuments.Find(documentId);
        }

        public void UpdateProgramsDocument(ProgramsDocument document, IFormFile imgDocument)
        {
            document.CreateDate = DateTime.Now;

            if (imgDocument != null)
            {
                document.ProgramsDocumentImage = Guid.NewGuid() + Path.GetExtension(imgDocument.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DocumentImage", document.ProgramsDocumentImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgDocument.CopyTo(stream);
                }
            }

            _context.Update(document);
            _context.SaveChanges();

        }

        public void DeleteProgramsDocument(int documentId)
        {
            var pdocument = GetProgramsDocumentById(documentId);
            pdocument.IsDelete = true;
            _context.Update(pdocument);
            _context.SaveChanges();
        }

        #endregion

        #region Maintenance Programs

        public List<MaintenancePrograms> GetAllMaintenancePrograms(int mechanicalId)
        {
            return _context.MaintenancePrograms.Where(m => m.IsDelete == false && m.MechanicalId == mechanicalId).ToList();
        }

        public int AddMaintenancePrograms(MaintenancePrograms programs)
        {
            programs.CreateDate = DateTime.Now;
            _context.Add(programs);
            _context.SaveChanges();
            return programs.ProgramsId;
        }

        public MaintenancePrograms GetMaintenanceProgramsById(int programsId)
        {
            return _context.MaintenancePrograms.Find(programsId);
        }

        public void UpdateMaintenancePrograms(MaintenancePrograms programs)
        {
            programs.CreateDate = DateTime.Now;
            _context.Update(programs);
            _context.SaveChanges(true);
        }

        public void DeleteMaintenancePrograms(int programsId)
        {
            var pogram = GetMaintenanceProgramsById(programsId);
            pogram.IsDelete = true;
            UpdateMaintenancePrograms(pogram);
        }

        public List<MaintenanceProgramsViewModel> GetAllMaintenanceProgramsForExport(int mechanicalId)
        {
            return _context.MaintenancePrograms.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new MaintenanceProgramsViewModel()
            {
                IR = c.IR,
                MaintenanceType = c.MaintenanceType,
                OVH = c.OVH,
                RR = c.RR
            }).ToList();
        }

        public MaintenanceProgramsViewModel GetMaintenanceProgramsByIdForExport(int programsId)
        {
            var prog = GetMaintenanceProgramsById(programsId);

            MaintenanceProgramsViewModel programsViewModel = new MaintenanceProgramsViewModel();

            programsViewModel.IR = prog.IR;
            programsViewModel.MaintenanceType = prog.MaintenanceType;
            programsViewModel.RR = prog.RR;
            programsViewModel.OVH = prog.OVH;

            return programsViewModel;
        }

        public List<MeasurementsViewModel> GetAllMeasurementsForExport(int mechanicalId)
        {
            return _context.Measurements.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new MeasurementsViewModel()
            {
                Dateofmeasurement = c.Dateofmeasurement,
                Description = c.Description,
                Resultmeasurement = c.Resultmeasurement,
                Typeofmeasurement = c.Typeofmeasurement
            }).ToList();
        }

        public MeasurementsViewModel GetMeasurementsByIdForExport(int measureId)
        {
            var measuring = GetMeasurementsById(measureId);

            MeasurementsViewModel measurementsViewModel = new MeasurementsViewModel();
            measurementsViewModel.Dateofmeasurement = measuring.Dateofmeasurement;
            measurementsViewModel.Description = measuring.Description;
            measurementsViewModel.Resultmeasurement = measuring.Resultmeasurement;
            measurementsViewModel.Typeofmeasurement = measuring.Typeofmeasurement;


            return measurementsViewModel;
        }

        public List<DefectListViewModel> GetAllDefectListForExport(int mechanicalId)
        {
            return _context.DefectList.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new DefectListViewModel()
            {
                ControlCorrection = c.ControlCorrection,
                ControlInstructionNo = c.ControlInstructionNo,
                ControlMethod = c.ControlMethod,
                ControlResult = c.ControlResult,
                CorrectionDate = c.CorrectionDate,
                CorrectionMethod = c.CorrectionMethod,
                DetectionDate = c.DetectionDate,
                InstructionCorrection = c.InstructionCorrection,
                JournalNo = c.JournalNo,
                NameofDefect = c.NameofDefect,
                PartorEquipment = c.PartorEquipment
            }).ToList();
        }

        public DefectListViewModel GetDefectListByIdForExport(int defectId)
        {
            var defection = GetDefectListById(defectId);

            DefectListViewModel defectListViewModel = new DefectListViewModel();

            defectListViewModel.ControlCorrection = defection.ControlCorrection;
            defectListViewModel.ControlInstructionNo = defection.ControlInstructionNo;
            defectListViewModel.ControlMethod = defection.ControlMethod;
            defectListViewModel.ControlResult = defection.ControlResult;
            defectListViewModel.CorrectionDate = defection.CorrectionDate;
            defectListViewModel.CorrectionMethod = defection.CorrectionMethod;
            defectListViewModel.DetectionDate = defection.DetectionDate;
            defectListViewModel.InstructionCorrection = defection.InstructionCorrection;
            defectListViewModel.JournalNo = defection.JournalNo;
            defectListViewModel.NameofDefect = defection.NameofDefect;
            defectListViewModel.PartorEquipment = defection.PartorEquipment;

            return defectListViewModel;
        }

        public List<SparePartsViewModel> GetAllSparePartsForExport(int mechanicalId)
        {
            return _context.SpareParts.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new SparePartsViewModel()
            {
                Designation = c.Designation,
                PartName = c.PartName,
                PartUnit = c.PartUnit,
                RealNoofParts = c.RealNoofParts,
                StandardNoofParts = c.StandardNoofParts
            }).ToList();
        }

        public SparePartsViewModel GetSparePartsByIdForExport(int spareId)
        {
            var PARTS = GetSparePartsById(spareId);

            SparePartsViewModel partsViewModel = new SparePartsViewModel();

            partsViewModel.Designation = PARTS.Designation;
            partsViewModel.PartName = PARTS.PartName;
            partsViewModel.PartUnit = PARTS.PartUnit;
            partsViewModel.RealNoofParts = PARTS.RealNoofParts;
            partsViewModel.StandardNoofParts = PARTS.StandardNoofParts;

            return partsViewModel;
        }

        public List<DefectionReportsViewModel> GetAllDefectionReportsForExport(int mechanicalId)
        {
            return _context.DefectionReports.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new DefectionReportsViewModel()
            {
                Code = c.Code,
                DefectionReportsImage = c.DefectionReportsImage,
                DocumentName = c.DocumentName,
                Filename = c.Filename
            }).ToList();
        }

        public DefectionReportsViewModel GetDefectionReportsByIdForExport(int reportsId)
        {
            var report = GetDefectionReportsById(reportsId);

            DefectionReportsViewModel reportsViewModel = new DefectionReportsViewModel();

            reportsViewModel.Code = report.Code;
            reportsViewModel.DefectionReportsImage = report.DefectionReportsImage;
            reportsViewModel.DocumentName = report.DocumentName;
            reportsViewModel.Filename = report.Filename;

            return reportsViewModel;
        }

        public List<MaintenanceFormViewModel> GetAllMaintenanceFormfOReXPORT(int mechanicalId)
        {
            return _context.MaintenanceForms.Where(m => m.IsDelete == false&&m.MechanicalId==mechanicalId).Select(c => new MaintenanceFormViewModel()
            {
                DateofMaintenance = c.DateofMaintenance,
                Description = c.Description,
                //DocumentName=c.DocumentName,
                Filename = c.Filename,
                FormName = c.FormName,
                FormNo = c.FormNo,
                MaintenanceFormImage = c.MaintenanceFormImage

            }).ToList();
        }

        public MaintenanceFormViewModel GetMaintenanceFormByIdfOReXPORT(int formsId)
        {
            var form = GetMaintenanceFormById(formsId);

            MaintenanceFormViewModel formViewModel = new MaintenanceFormViewModel();

            formViewModel.DateofMaintenance = form.DateofMaintenance;
            formViewModel.Description = form.Description;
            //formViewModel.DocumentName = form.DocumentName;
            formViewModel.Filename = form.Filename;
            formViewModel.FormName = form.FormName;
            formViewModel.FormNo = form.FormNo;
            formViewModel.MaintenanceFormImage = form.MaintenanceFormImage;

            return formViewModel;
        }
        #endregion
    }
}
