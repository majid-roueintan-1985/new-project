using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class InitialData
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(200)]
        public string AllowableCUF { get; set; }

        [MaxLength(200)]
        public string AllowableLifeTime { get; set; }

        [MaxLength(200)]
        public string AllowableChangingRatio { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
