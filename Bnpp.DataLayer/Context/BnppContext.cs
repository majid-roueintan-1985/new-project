using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.AgeingDocuments;
using Bnpp.DataLayer.Entities.AgeingManagementDocuments;
using Bnpp.DataLayer.Entities.AgeingMechanism;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.Electrical;
using Bnpp.DataLayer.Entities.InspectionData;
using Bnpp.DataLayer.Entities.Maintenance;
using Bnpp.DataLayer.Entities.ONOFF;
using Bnpp.DataLayer.Entities.OperationalDatas;
using Microsoft.EntityFrameworkCore;

namespace Bnpp.DataLayer.Context
{
    public class BnppContext:DbContext
    {
        public BnppContext(DbContextOptions<BnppContext> options) : base(options)
        {

        }

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion
        public DbSet<MechanicalEquipment> MechanicalEquipments { get; set; }
        public DbSet<Strcture> Strctures { get; set; }
        public DbSet<Commissioning> Commissioning { get; set; }
        public DbSet<Backup> Backups { get; set; }
        public DbSet<DamageabilityReport> DamageabilityReports { get; set; }
        public DbSet<InitialData> initialData { get; set; }
        #region Electrical

        public DbSet<Cable> Cables { get; set; }
        public DbSet<Electromotors> Electromotors { get; set; }
        public DbSet<Generator> Generators { get; set; }
        public DbSet<Transformer> Transformers { get; set; }
        public DbSet<ElectroValve> ElectroValves { get; set; }
        public DbSet<Dieselgenerator> Dieselgenerators { get; set; }

        #endregion
        
        #region Transient

        public DbSet<OperationalData> OperationalData { get; set; }
        public DbSet<Occurance> Occurances { get; set; }
        public DbSet<DesignBasis> DesignBasis { get; set; }

        #endregion

        #region  Ageing Management

        public DbSet<Methodology> Methodologies { get; set; }
        public DbSet<AgeingDocuments> AgeingDocuments { get; set; }
        public DbSet<ManagementReviews> ManagementReviews { get; set; }

            #endregion
       
        #region Basic Data

        public DbSet<GeneralData> GeneralData { get; set; }
        public DbSet<DesignData> DesignData { get; set; }
        public DbSet<DesignDocument> DesignDocuments { get; set; }
        public DbSet<ChemicalNorms> ChemicalNorms { get; set; }
        public DbSet<InspectionProgram> InspectionPrograms { get; set; }
        public DbSet<Sensors> Sensors { get; set; }
        public DbSet<ControlPoints> ControlPoints { get; set; }
        public DbSet<HForms> HForms { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<MechanicalProperties> MechanicalProperties { get; set; }
        public DbSet<PhysicalProperties> PhysicalProperties { get; set; }
        public DbSet<ChemicalComponent> ChemicalComponents { get; set; }
        public DbSet<HeatOperation> HeatOperation { get; set; }
		public DbSet<SeismicCategory> SeismicCategory { get; set; }
		
		#endregion

		#region Ageing Document

		public DbSet<OperationalDocuments> OperationalDocuments { get; set; }
        public DbSet<Drawing> Drawing { get; set; }
        public DbSet<Standard> Standard { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Installation> Installation { get; set; }
        public DbSet<MaintenanceDocument> MaintenanceDocument { get; set; }
        public DbSet<Ageing> Ageing { get; set; }

        #endregion

        #region Mechanism

        public DbSet<Mechanism> Mechanism { get; set; }
        public DbSet<MechanismDocuments> MechanismDocuments { get; set; }

        #endregion

        public DbSet<Operational> Operationals { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<RelatedAgeingMechanism> RelatedAgeingMechanisms { get; set; }
        public DbSet<ExternalEvents> ExternalEvents { get; set; }
        public DbSet<ResponsibleUnit> ResponsibleUnits { get; set; }
        public DbSet<Units> Units { get; set; }

        #region Maintenance
        public DbSet<DefectList> DefectList { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<Measurements> Measurements { get; set; }
        public DbSet<MaintenanceForm> MaintenanceForms { get; set; }
        public DbSet<DefectionReports> DefectionReports { get; set; }
        public DbSet<MaintenancePrograms> MaintenancePrograms { get; set; }
        public DbSet<ProgramsDocument> ProgramsDocuments { get; set; }
        #endregion

        #region Inspectionresult

        public DbSet<InspectionDocument> InspectionDocuments { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<TypicalPrograms> TypicalPrograms { get; set; }
        public DbSet<WorkingPrograms> WorkingPrograms { get; set; }
        public DbSet<TestResults> TestResults { get; set; }
        public DbSet<TestResultsType> TestResultsType { get; set; }

        #endregion

        #region OnOff

        public DbSet<ChangeState> ChangeState { get; set; }
        public DbSet<States> State { get; set; }
        public DbSet<ChangingInState> ChangingInState { get; set; }

        #endregion

        #region Cables
        public DbSet<GeneralCables> GeneralCables { get; set; }
        public DbSet<OperatingCableData> OperatingCableDatas { get; set; }
        public DbSet<MaintenanceCable> MaintenanceCables { get; set; }
        public DbSet<CableReport> CableReports { get; set; }
        public DbSet<CableGroup> CableGroups { get; set; }
        public DbSet<CableIdentity> CableIdentities { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<TypeofCable> TypeofCables { get; set; }
        public DbSet<ClassificationVoltage> ClassificationVoltage { get; set; }
        public DbSet<ListofCable> ListofCables { get; set; }
        public DbSet<InsulationMaterial> InsulationMaterials { get; set; }
        public DbSet<JacketMaterial> JacketMaterials { get; set; }
        public DbSet<ManufacturerCable> ManufacturerCable { get; set; }
        public DbSet<CableLocation> CableLocation { get; set; }
        public DbSet<DegradationMechanisms> DegradationMechanisms { get; set; }
        public DbSet<CableCurrent> CableCurrent { get; set; }

        #endregion

        #region Operating Data

        public DbSet<OperationMode> OperationMode { get; set; }
        public DbSet<FailureDiscovery> FailureDiscovery { get; set; }
        public DbSet<FailureCondition> FailureCondition { get; set; }
        public DbSet<FailedParts> FailedParts { get; set; }

        #endregion


        #region Maintenance  Data

        public DbSet<TypeofMaintenance> TypeofMaintenance { get; set; }
        public DbSet<TestType> TestType { get; set; }
        public DbSet<ResaultCable> ResaultCable { get; set; }

        #endregion
    }
}
