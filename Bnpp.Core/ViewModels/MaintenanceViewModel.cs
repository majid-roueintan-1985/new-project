using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class MaintenanceProgramsViewModel
    {
        public string MaintenanceType { get; set; }

        public string RR { get; set; }

        public string IR { get; set; }

        public string OVH { get; set; }
    }

    public class MeasurementsViewModel
    {
        public string Typeofmeasurement { get; set; }


        public string Resultmeasurement { get; set; }


        public string Description { get; set; }


        public DateTime Dateofmeasurement { get; set; }
    }

    public class DefectListViewModel
    {
        public string InstructionCorrection { get; set; }

        public string ControlCorrection { get; set; }

        public string CorrectionMethod { get; set; }

        public string ControlInstructionNo { get; set; }

        public string ControlResult { get; set; }

        public string ControlMethod { get; set; }

        public string PartorEquipment { get; set; }

        public string JournalNo { get; set; }

        public string NameofDefect { get; set; }

        public DateTime CorrectionDate { get; set; }

        public DateTime DetectionDate { get; set; }
    }

    public class SparePartsViewModel
    {
        public string PartName { get; set; }

        public string StandardNoofParts { get; set; }

        public string PartUnit { get; set; }

        public string RealNoofParts { get; set; }

        public string Designation { get; set; }
    }

    public class DefectionReportsViewModel
    {
        public string DefectionReportsImage { get; set; }

        public string Code { get; set; }

        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }

    public class MaintenanceFormViewModel
    {
        public string FormName { get; set; }

        public string FormNo { get; set; }

        public string Description { get; set; }

        public string MaintenanceFormImage { get; set; }

        public string Filename { get; set; }

        //public string DocumentName { get; set; }

        public DateTime DateofMaintenance { get; set; }
    }
}
