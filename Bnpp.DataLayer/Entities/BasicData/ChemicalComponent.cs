using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class ChemicalComponent
    {

        [Key]
        public int ChemicalComponentId { get; set; }


        [Required]
        public string C { get; set; }
        [Required]

        public string Si { get; set; }
        [Required]
        public string Mn { get; set; }
        [Required]
        public string Cr { get; set; }
        [Required]
        public string Ni { get; set; }
        [Required]
        public string Mo { get; set; }
        [Required]
        public string V { get; set; }
        [Required]
        public string Ti { get; set; }
        [Required]
        public string Cu { get; set; }
        [Required]
        public string S { get; set; }
        [Required]
        public string P { get; set; }
        [Required]
        public string As { get; set; }
        [Required]
        public string Co { get; set; }
        [Required]
        public string NB { get; set; }


        [Required]
        public int ComponentId { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
