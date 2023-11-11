using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class Strcture
    {
        [Key]
        public int StrctureId { get; set; }

        [MaxLength(200)]
        public string Station1 { get; set; }
        [MaxLength(200)]
        public string Station2 { get; set; }
        [MaxLength(200)]
        public string ConstructionName { get; set; }
        [MaxLength(200)]
        public string Type { get; set; }
        [MaxLength(200)]
        public string Position { get; set; }
        [MaxLength(200)]
        public string Azk { get; set; }
        [MaxLength(200)]
        public string AzkStruct { get; set; }
        [MaxLength(200)]
        public string StrctureImage { get; set; }
        [MaxLength(200)]
        public string BasicImage { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
