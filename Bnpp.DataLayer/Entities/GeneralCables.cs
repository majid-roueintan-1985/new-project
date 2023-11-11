using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class GeneralCables
    {
        [Key]
        public int ID { get; set; }

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


        public string ResistancetoDBAConditionImage { get; set; }
        public string ResistancetoDBAConditionFilename { get; set; }


        public string ResistanceBDBAConditionImage { get; set; }
        public string ResistanceBDBAConditionFilename { get; set; }

        public string ResultFactoryTestsImage { get; set; }
        public string ResultFactoryTestsFilename { get; set; }

        public string ResultTestsEndInstallationImage { get; set; }
        public string ResultTestsEndInstallationFilename { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
