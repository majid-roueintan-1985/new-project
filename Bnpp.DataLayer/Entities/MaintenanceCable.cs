using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class MaintenanceCable
    {
        [Key]
        public int ID { get; set; }

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

        public string AttachActImage { get; set; }

        public string AttachActFileName { get; set; }

        public string AcceptanceCriteria { get; set; }

        public string Resault { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
