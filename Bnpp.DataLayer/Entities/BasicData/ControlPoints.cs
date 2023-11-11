using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class ControlPoints
    {
        [Key]
        public int PointId { get; set; }


       
        public string Parameter { get; set; }

        
        public string NumberCheckPoints { get; set; }

       
        public string MeasurementRange { get; set; }

        
        public string Remarks { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

		//Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
