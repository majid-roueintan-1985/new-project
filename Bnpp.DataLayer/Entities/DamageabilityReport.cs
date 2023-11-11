using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class DamageabilityReport
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(200)]
        public string Akz { get; set; }

        [MaxLength(200)]
        public string Totaldamageabilityofequipment { get; set; }

        [MaxLength(200)]
        public string Damageabilityperuncoiledcycles { get; set; }

        [MaxLength(200)]
        public string Damageabilitypercoiledcycles { get; set; }

        [MaxLength(200)]
        public string LifetimeofequipmentperRALDS { get; set; }

        [MaxLength(200)]
        public string Lifetimeofequipmentindesign { get; set; }

        [MaxLength(200)]
        public string Actionperiodofequipment { get; set; }

        [MaxLength(200)]
        public string Locationofthecheckpoint { get; set; }

        [MaxLength(200)]
        public string AllowableCUF { get; set; }

        [MaxLength(200)]
        public string AllowableLifeTime { get; set; }

        [MaxLength(200)]
        public string ChangingRatio { get; set; }

        [MaxLength(200)]
        public string AllowableChangingRatio { get; set; }

        [MaxLength(200)]
        public string DateOfReport { get; set; }


        public DateTime ReportDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
