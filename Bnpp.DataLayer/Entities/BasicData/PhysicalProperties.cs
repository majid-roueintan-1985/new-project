using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class PhysicalProperties
    {
        [Key]
        public int PhysicalPropertiesId { get; set; }

        [Required]
        public string Temperature { get; set; }

        [Required]
        public string LinearExpension { get; set; }

        [Required]
        public string HeatCapacity { get; set; }

        [Required]
        public string ConductivityFactor { get; set; }

        [Required]
        public string NormalRadiation { get; set; }

        [Required]
        public string PoissonRatio { get; set; }

        [Required]
        public string Density { get; set; }

        [Required]
        public int ComponentId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
