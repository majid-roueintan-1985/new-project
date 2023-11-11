using Bnpp.DataLayer.Entities.OperationalDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.InspectionData
{
    public class TestResults
    {
        [Key]
        public int TestResultsId { get; set; }


        [Required]
        public int TypeId { get; set; }


        public string NO { get; set; }

        
        public string WeldNo { get; set; }

       
        public string WeldSize { get; set; }

        
        public string TestScope { get; set; }

       
        public string FoundDefectDescription { get; set; }

        
        public string QualityAssessment { get; set; }
       
        public string NooflogBook { get; set; }

        
        public string Notes { get; set; }

       
        public string Code { get; set; }

        public string DimensionofWeld { get; set; }

        public string AreaNo { get; set; }

        public string LengthofSection { get; set; }

        public string Sensitivity { get; set; }

        public string RevealedDefects { get; set; }

        public string RegisterNo { get; set; }

        public string UnitDescription { get; set; }

        public string DimensionsofUnit { get; set; }

        public string MaximumAllowed { get; set; }

        public string PointNo { get; set; }

        public string MeasuredThickness { get; set; }

        public string MinimumAllowedThickness { get; set; }


       

        public DateTime TestingDate { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey("TypeId")]
        public virtual TestResultsType TestResultsType { get; set; }

        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}

