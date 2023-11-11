using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class Units
    {
        [Key]
        public int UnitId { get; set; }


       
        public string UnitTitle { get; set; }

        
        public bool IsDelete { get; set; }

       
        public int? ParentId { get; set; }


        [ForeignKey("ParentId")]
        public List<Units> GetUnits { get; set; }
    }
}
