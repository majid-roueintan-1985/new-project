using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
	public class ExternalEventsViewModel
	{
		public string NPPName { get; set; }

		public string ReactorType { get; set; }

		public string ReportCode { get; set; }

		public string EventName { get; set; }

		public DateTime EventDate { get; set; }

		public DateTime ReportDate { get; set; }

		public string RelatedAgeingMechanism { get; set; }

		public string Description { get; set; }

		public string EventsImage { get; set; }

		public string Filename { get; set; }
	}

	public class InternalEventsViewModel
	{
		public string EventsImage { get; set; }

		public string Filename { get; set; }

		
		public string EventName { get; set; }

		
		public string EventLevel { get; set; }

		
		public string ReportNo { get; set; }

		
		public string ResponsibleUnit { get; set; }

		
		public string EventLocation { get; set; }

		public string RelatedAgeingMechanism { get; set; }

		public string Description { get; set; }

		public string EventConsequences { get; set; }

		//before
		

		public string BeforeOperatingModes { get; set; }

		public string BeforeHeatPower { get; set; }

		public string BeforeElectricalPower { get; set; }

		public string BeforeEffectiveWorkingDays { get; set; }

		public string BeforePressureWater { get; set; }

		public string BeforePressureinFirstCircuit { get; set; }

		public string BeforePressureinSecondCircuit { get; set; }

		public string BeforeVaccuminCondensor { get; set; }

		//after
		

		public string AfterOperatingModes { get; set; }

		public string AfterHeatPower { get; set; }

		public string AfterElectricalPower { get; set; }

		public string AfterEffectiveWorkingDays { get; set; }

		public string AfterPressureWater { get; set; }

		public string AfterPressureinFirstCircuit { get; set; }

		public string AfterPressureinSecondCircuit { get; set; }

		public string AfterVaccuminCondensor { get; set; }


		public DateTime EventDate { get; set; }



		public string EventTime { get; set; }

		public DateTime ReportDate { get; set; }
	}
}
