using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class RelatedAgeingMechanism
    {
        [Key]
        public int AgeingMechanismId { get; set; }

        public string AgeingMechanismTitle { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
