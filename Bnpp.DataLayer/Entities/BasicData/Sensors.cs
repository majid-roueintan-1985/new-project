using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class Sensors
    {
        [Key]
        public int SensorId { get; set; }


       
        public string Parametertomeasure { get; set; }

       
        public string AKZ { get; set; }

        
        public string Numberofsignals { get; set; }

       
        public string KKS { get; set; }

       
        public string Quantity { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


        //Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
