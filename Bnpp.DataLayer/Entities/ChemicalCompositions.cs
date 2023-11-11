using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class ChemicalCompositions
    {
        [Key]
        public int ChemicalId { get; set; }
        public int CID { get; set; }

        public DateTime CreateDate { get; set; }

        [MaxLength(500)]
        public string C { get; set; }
        [MaxLength(500)]
        public string si { get; set; }
        [MaxLength(500)]
        public string Mn { get; set; }
        [MaxLength(500)]
        public string Cr { get; set; }
        [MaxLength(500)]
        public string Ni { get; set; }
        [MaxLength(500)]
        public string Mo { get; set; }
        [MaxLength(500)]
        public string V { get; set; }
        [MaxLength(500)]
        public string Ti { get; set; }
        [MaxLength(500)]
        public string Cu { get; set; }
        [MaxLength(500)]
        public string S { get; set; }
        [MaxLength(500)]
        public string P { get; set; }
        [MaxLength(500)]
        public string AS1 { get; set; }
        [MaxLength(500)]
        public string Co { get; set; }
        [MaxLength(500)]
        public string NB { get; set; }
    }
}
