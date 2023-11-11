using Bnpp.DataLayer.Entities.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class OperatingCableData
    {
        [Key]
        public int ID { get; set; }

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

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
