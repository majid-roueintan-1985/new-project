using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class CableReportViewModel
    {


        public string CableID { get; set; }

        public string CableIDGroup { get; set; }

        public string Owner { get; set; }

        public DateTime Datefrom { get; set; }

        public DateTime DateTo { get; set; }

        public string RemainingDesignLifeTime { get; set; }

        public string ModeofOperation { get; set; }

        public DateTime FailureDetctionDate { get; set; }

        public string FailedParts { get; set; }

        public DateTime StartDateMaintenance { get; set; }

        public DateTime EndDateMaintenance { get; set; }

        public string TypeofMaintenancework { get; set; }

        public string TypeofTests { get; set; }
    }

    public class OperatingDataViewModel
    {
       

        public string CableID { get; set; }

        public string CableIDGroup { get; set; }

        public string Owner { get; set; }

        public string Current { get; set; }

        public string ModeofOperation { get; set; }

        public string AKZofTemperatureSensor { get; set; }

        public string TemperatureSensorLocation { get; set; }

        public string TemperatureSensorValue { get; set; }

        public string AKZofRadiationSensor { get; set; }

        public string RadiationSensorLocation { get; set; }

        public string RadiationSensorValue { get; set; }

        public string AKZofHumiditySensor { get; set; }

        public string LocationHumiditySensor { get; set; }

        public string HumiditySensorValue { get; set; }

        public DateTime FailureDate { get; set; }

        public string MethodofFailure { get; set; }

        public string FailureDescription { get; set; }

        public string ConditionOfFailure { get; set; }

        public string CauseofFailure { get; set; }

        public string FailedParts { get; set; }
    }


    public class MaintenanceCableViewModel
    {
        public string CableID { get; set; }

        public string CableIDGroup { get; set; }

        public string Owner { get; set; }

        public DateTime StartTimeMaintenance { get; set; }

        public DateTime EndTimeMaintenance { get; set; }

        public string VisualResultMaintenance { get; set; }

        public string DescriptionMaintenanceReasons { get; set; }

        public string AttachActNo { get; set; }

        public string TypeofMaintenancework { get; set; }

        public string TypeTests { get; set; }

        public string Value { get; set; }

        public string AttachActFileName { get; set; }

        public string AcceptanceCriteria { get; set; }

        public string Result { get; set; }

        public string AttachActImage { get; set; }
    }

    public class GeneralCablesViewModel
    {
        public string CableID { get; set; }

        public string CableIDGroup { get; set; }

        public string Owner { get; set; }

        public string Current { get; set; }

        public DateTime LogTime { get; set; }

        public string TypeofCable { get; set; }

        public string ClassificationofCable { get; set; }

        public string ListofCable { get; set; }

        public string InsulationMaterial { get; set; }

        public string JacketMaterial { get; set; }

        public string Manufacturer { get; set; }

        public string ManufacturingYear { get; set; }

        public string Location { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string IntermediateLocations { get; set; }

        public string CableLength { get; set; }

        public string NumberofSimilarCables { get; set; }

        public string TotalLengthofSimilarCables { get; set; }

        public string ExpectedDegradationMechanisms { get; set; }

        public DateTime InstallationDate { get; set; }

        public string DesignLife { get; set; }

        public string ServiceLife { get; set; }

        public string RemainingDesignLifeTime { get; set; }

        public string NominalVoltage { get; set; }

        public string NominalCurrent { get; set; }

        public string OperatingAmbientTemperature { get; set; }
        
        public string ResistancetoDBAConditionFilename { get; set; }

        public string ResistanceBDBAConditionFilename { get; set; }

        public string ResultFactoryTestsFilename { get; set; }

        public string ResultTestsEndInstallationFilename { get; set; }

        public string ResistancetoDBAConditionImage { get; set; }
        
        public string ResistanceBDBAConditionImage { get; set; }
        
        public string ResultFactoryTestsImage { get; set; }
        
        public string ResultTestsEndInstallationImage { get; set; }
        
    }
}
