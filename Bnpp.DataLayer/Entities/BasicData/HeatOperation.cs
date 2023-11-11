using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class HeatOperation
    {
        [Key]
        public int HeatOperationId { get; set; }

        [Required]
        public int ComponentId { get; set; }

        public string HeatOperationImage { get; set; }

        [Required]
        public string Temperature { get; set; }
        
        [Required]
        public string HeatsOperation { get; set; }

        [Required]
        public string CoolingMethod { get; set; }

        [Required]
        public string NoOfHeatOperations { get; set; }

        [Required]
        public string DocumentNo { get; set; }
		public string Filename { get; set; }

		public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime TimesOfHeating { get; set; }

        //[Required]
        //public string DocumentName { get; set; }
       
    }
}
