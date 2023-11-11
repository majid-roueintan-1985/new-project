using Bnpp.DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Bnpp.DataLayer.Entities
{
    public class CableReport
    {
        [Key]
        public int ID { get; set; }

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
        

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
