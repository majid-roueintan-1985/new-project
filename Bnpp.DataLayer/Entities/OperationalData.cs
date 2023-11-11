using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class OperationalData
    {
        [Key]
        public int OperationalId { get; set; }

        [MaxLength(200)]

        public string NameofConditions { get; set; }

        [MaxLength(200)]
        public string AllowableNumber { get; set; }

        [MaxLength(200)]
        public string Occurrance { get; set; }

        [MaxLength(200)]
        public string Dates { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
