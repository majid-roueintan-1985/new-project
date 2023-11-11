using Bnpp.DataLayer.Entities.AgeingDocuments;
using Bnpp.DataLayer.Entities.AgeingMechanism;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Entities.Maintenance;
using Bnpp.DataLayer.Entities.ONOFF;
using Bnpp.DataLayer.Entities.OperationalDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
	public class MechanicalEquipment
	{
		[Key]
		public int MechanicalId { get; set; }

		[MaxLength(200)]
		public string Station1 { get; set; }
		[MaxLength(200)]
		public string Station2 { get; set; }
		[MaxLength(200)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string Type { get; set; }
		[MaxLength(200)]
		public string Position { get; set; }
		[MaxLength(200)]
		public string Azk { get; set; }
		[MaxLength(200)]
		public string AzkStruct { get; set; }
		[MaxLength(200)]
		public string MechanicalImage { get; set; }
		[MaxLength(200)]
		public string BasicImage { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsDelete { get; set; }

		//Basic Data
		public List<GeneralData> GeneralData { get; set; }

		public List<DesignData> DesignData { get; set; }

		public List<DesignDocument> DesignDocument { get; set; }


		public List<ChemicalNorms> ChemicalNorms { get; set; }
		public List<InspectionProgram> InspectionProgram { get; set; }

		public List<Sensors> Sensors { get; set; }

		public List<ControlPoints> ControlPoints { get; set; }

		public List<HForms> HForms { get; set; }
		public List<Components> Components { get; set; }
		public List<SeismicCategory> SeismicCategory { get; set; }

		//Documents   
		public List<OperationalDocuments> OperationalDocuments { get; set; }
		public List<Drawing> Drawing { get; set; }
		public List<Standard> Standard { get; set; }
		public List<Manufacturer> Manufacturer { get; set; }
		public List<Installation> Installation { get; set; }
		public List<MaintenanceDocument> MaintenanceDocument { get; set; }
		public List<Ageing> Ageing { get; set; }
		//Ageing Mechanism
		public List<Mechanism> Mechanism { get; set; }
		public List<MechanismDocuments> MechanismDocuments { get; set; }
		//Installation & Commissioning

		public List<Commissioning> Commissioning { get; set; }
		//Operational Data
		public List<Operational> Operational { get; set; }
		//On OFF

		public List<ChangeState> ChangeState { get; set; }

		//Maintenance   

		public List<MaintenancePrograms> MaintenancePrograms { get; set; }
		public List<DefectList> DefectList { get; set; }
		public List<SpareParts> SpareParts { get; set; }
		public List<MaintenanceForm> MaintenanceForm { get; set; }
		public List<Measurements> Measurements { get; set; }
		public List<DefectionReports> DefectionReports { get; set; }

		//InspectionDocument  

		public List<InspectionDocument> InspectionDocument { get; set; }

		public List<TypicalPrograms> TypicalPrograms { get; set; }

		public List<WorkingPrograms> WorkingPrograms { get; set; }

		public List<TestResults> TestResults { get; set; }

		//Events   
		public List<Events> Events { get; set; }
		public List<ExternalEvents> ExternalEvents { get; set; }

	}
}
