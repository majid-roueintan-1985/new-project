using Bnpp.DataLayer.Entities.InspectionData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class InspectionReportsViewModel
    {
        public string Code { get; set; }

        public string Filename { get; set; }

        public string DocumentName { get; set; }
    }

    public class InspectionInstructionsViewModel
    {
        public string Code { get; set; }

        public string Filename { get; set; }

        public string DocumentName { get; set; }
    }

    public class VisualFormViewModel
    {
        public string FormName { get; set; }

        public string FormNo { get; set; }

        public string Description { get; set; }

        public string Filename { get; set; }

        public DateTime InspectionDate { get; set; }
    }

    public class TypicalProgramsViewModel
    {
        public string TP { get; set; }


        public string EquipCode { get; set; }


        public string EquipName { get; set; }


        public string TestMethod { get; set; }


        public string TestStandard { get; set; }


        public string ControlPercent { get; set; }

        public string Period { get; set; }


        public string WeldType { get; set; }


        public string Remarks { get; set; }
    }

    public class WorkingProgramsViewModel
    {
        public string WP { get; set; }

        public string TP { get; set; }

        public string EquipCode { get; set; }

        public string EquipName { get; set; }

        public string MeasuringType { get; set; }

        public string MaterialCompositions { get; set; }

        public string WeldNo { get; set; }

        public string ControlMethod { get; set; }

        public string ControlPercent { get; set; }

        public string ControlStandard { get; set; }

        public string QCStandard { get; set; }

        public string ControlResults { get; set; }

        public string Remarks { get; set; }
    }


    #region
    public class VisualControlViewModel
    {

        public string NO { get; set; }

        public string WeldNo { get; set; }

        public string WeldSize { get; set; }

        public string TestScope { get; set; }

        public string FoundDefectDescription { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public DateTime TestingDate { get; set; }
    }

    public class LeakageTestViewModel
    {

        public string NO { get; set; }

        public DateTime TestingDate { get; set; }

        public string Code { get; set; }

        public string DimensionofWeld { get; set; }

        public string WeldNo { get; set; }



        public string TestScope { get; set; }

        public string FoundDefectDescription { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

    }

    public class LiquidPenetratedTestViewModel
    {

        public string NO { get; set; }

        public string WeldNo { get; set; }

        public string WeldSize { get; set; }

        public string TestScope { get; set; }

        public string FoundDefectDescription { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public DateTime TestingDate { get; set; }
    }

    public class MagneticPowderViewModel
    {

        public string NO { get; set; }

        public string WeldNo { get; set; }

        public string WeldSize { get; set; }

        public string TestScope { get; set; }

        public string FoundDefectDescription { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public DateTime TestingDate { get; set; }
    }

    public class RadiographicsViewModel
    {

        public string NO { get; set; }

        public string WeldNo { get; set; }

        public string WeldSize { get; set; }

        public string TestScope { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public string AreaNo { get; set; }

        public string LengthofSection { get; set; }

        public string Sensitivity { get; set; }

        public string RevealedDefects { get; set; }

        public string RegisterNo { get; set; }

        public DateTime TestingDate { get; set; }
    }

    public class UltrasonicViewModel
    {
        public string NO { get; set; }

        public string WeldNo { get; set; }

        public string TestScope { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public string UnitDescription { get; set; }

        public string DimensionsofUnit { get; set; }

        public string MaximumAllowed { get; set; }
        public string FoundDefectDescription { get; set; }

        public DateTime TestingDate { get; set; }
    }

    public class MetalThicknessViewModel
    {
        public string NO { get; set; }

        public string QualityAssessment { get; set; }

        public string NooflogBook { get; set; }

        public string Notes { get; set; }

        public string UnitDescription { get; set; }

        public string PointNo { get; set; }

        public string MeasuredThickness { get; set; }

        public string MinimumAllowedThickness { get; set; }

        public DateTime TestingDate { get; set; }
    }

    #endregion
}
