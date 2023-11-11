using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
	public class GeneralDataViewModel
	{
		public string DesignationOfParameters { get; set; }
		public string Value { get; set; }
	}

	public class SeismicCategoryViewModel
	{

		public string NameAndDesignation { get; set; }


		public string SafetyClass { get; set; }


		public string ClassificationDesignation { get; set; }


		public string CategoryGroup { get; set; }


		public string CategorySeismic { get; set; }
	}

	public class DesignDataViewModel
	{
		public string ParameterName { get; set; }

		public string unit { get; set; }

		public string Value { get; set; }

		public string Description { get; set; }
	}

	public class DocumentsViewModel
	{
		public string DesignDocumentImage { get; set; }
		public string Code { get; set; }
		public string DocumentName { get; set; }
		public string Filename { get; set; }
	}

	public class ComponentsViewModel
	{
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

		//public string ComponentsImage { get; set; }

		public string Filename { get; set; }


		//mechanical properties
		public string MechanicalTemperature { get; set; }

		public string YoungModule { get; set; }

		public string YieldStrength { get; set; }

		public string UltimateStrength { get; set; }

		public string SpecificElongation { get; set; }

		public string ReductionArea { get; set; }

		public string ImpactToughness { get; set; }

		public string Hardness { get; set; }

		// PhysicalProperties
		public string PhysicalTemperature { get; set; }


		public string LinearExpension { get; set; }


		public string HeatCapacity { get; set; }


		public string ConductivityFactor { get; set; }


		public string NormalRadiation { get; set; }


		public string PoissonRatio { get; set; }


		public string Density { get; set; }
		//HeatOperation
		public string OperationTemperature { get; set; }

		public string HeatsOperation { get; set; }

		public string CoolingMethod { get; set; }

		public string NoOfHeatOperations { get; set; }

		public string DocumentNo { get; set; }

		public DateTime TimesOfHeating { get; set; }

		//ChemicalComponent
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
	}

	public class ChemicalNormsViewModel
	{
		public string IndexDescription { get; set; }

		public string Unit { get; set; }

		public string Value { get; set; }

		public string Limit { get; set; }
	}

	public class InspectionProgramViewModel
	{
		public string Code { get; set; }

		public string EquipmentDocument { get; set; }

		public string TestMethod { get; set; }

		public string TechnicalDocuments { get; set; }

		public string ScopeofInspection { get; set; }

		public string PeriodofInspection { get; set; }

		public string CategoryofWeldedjoints { get; set; }

		public string Note { get; set; }
	}

	public class SensorsViewModel
	{
		public string Parametertomeasure { get; set; }

		public string AKZ { get; set; }

		public string Numberofsignals { get; set; }

		public string KKS { get; set; }

		public string Quantity { get; set; }
	}

	public class ControlPointsViewModel
	{
		public string Parameter { get; set; }

		public string NumberCheckPoints { get; set; }

		public string MeasurementRange { get; set; }

		public string Remarks { get; set; }
	}

	public class HFormsViewModel
	{
		public string HFormsImage { get; set; }

		public string Code { get; set; }

		public string DocumentName { get; set; }

		public string Filename { get; set; }
	}

	public class MechanicalPropertiesViewModel
	{
		public string Temperature { get; set; }

		public string YoungModule { get; set; }

		public string YieldStrength { get; set; }

		public string UltimateStrength { get; set; }

		public string SpecificElongation { get; set; }

		public string ReductionArea { get; set; }

		public string ImpactToughness { get; set; }

		public string Hardness { get; set; }
	}

	public class PhysicalPropertiesViewModel
	{
		public string Temperature { get; set; }


		public string LinearExpension { get; set; }


		public string HeatCapacity { get; set; }


		public string ConductivityFactor { get; set; }


		public string NormalRadiation { get; set; }


		public string PoissonRatio { get; set; }


		public string Density { get; set; }
	}

	public class HeatOperationViewModel
	{
		public string Temperature { get; set; }

		public string HeatsOperation { get; set; }

		public string CoolingMethod { get; set; }

		public string NoOfHeatOperations { get; set; }

		public string DocumentNo { get; set; }

		public DateTime TimesOfHeating { get; set; }

		public string Filename { get; set; }
	}

	public class ChemicalComponentViewModel
	{
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
	}
}
