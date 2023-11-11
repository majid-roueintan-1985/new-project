using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class Components
    {
        [Key]
        public int ComponentId { get; set; }


       
        public string Item { get; set; }

       
        public string Designation { get; set; }

       
        public string Serial { get; set; }

       
        public string Diameter { get; set; }

       
        public string Thickness { get; set; }

       
        public string Length { get; set; }
       
        public string MaterialGrade { get; set; }

       
        public string ClassofSafety { get; set; }

       
        public string ClassificationDesignation { get; set; }

       
        public string Group { get; set; }

      
        public string SeismicCategory { get; set; }

        public string ComponentsImage { get; set; }

        public string Filename { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


		//Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }



		// Mechanical Properties
		
		public string MechanicalTemperature { get; set; }

		
		public string YoungModule { get; set; }

		
		public string YieldStrength { get; set; }

		
		public string UltimateStrength { get; set; }

		
		public string SpecificElongation { get; set; }
		
		public string ReductionArea { get; set; }
		
		public string ImpactToughness { get; set; }
		public string Hardness { get; set; }


		//Physical Properties

		
		public string PhysicalTemperature { get; set; }

		
		public string LinearExpension { get; set; }

		
		public string HeatCapacity { get; set; }

		public string ConductivityFactor { get; set; }

		
		public string NormalRadiation { get; set; }

		
		public string PoissonRatio { get; set; }

		
		public string Density { get; set; }


		//Chemical Components
		
		public string C { get; set; }
		

		public string Si { get; set; }
		
		public string Mn { get; set; }
		
		public string Cr { get; set; }
		
		public string Ni { get; set; }
		
		public string Mo { get; set; }
		
		public string V { get; set; }
		
		public string Ti { get; set; }
		
		public string Cu { get; set; }
		
		public string S { get; set; }
		
		public string P { get; set; }
		
		public string As { get; set; }
		
		public string Co { get; set; }
		
		public string NB { get; set; }


		//Heat Treatment

		//public string HeatOperationImage { get; set; }

		
		public string TreatmentTemperature { get; set; }

		
		public string HeatsOperation { get; set; }

		
		public string CoolingMethod { get; set; }

		
		public string NoOfHeatOperations { get; set; }

		
		public string DocumentNo { get; set; }

		public DateTime TimesOfHeating { get; set; }
	}
}
