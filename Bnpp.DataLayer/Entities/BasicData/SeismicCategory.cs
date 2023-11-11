using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bnpp.DataLayer.Entities.BasicData
{
	public class SeismicCategory
	{
		[Key]
		public int CategoryId { get; set; }

		
		public string NameAndDesignation { get; set; }

		
		public string SafetyClass { get; set; }

		
		public string ClassificationDesignation { get; set; }

		public string CategoryGroup { get; set; }

		
		public string CategorySeismic { get; set; }


		public DateTime CreateDate { get; set; }

		public bool IsDelete { get; set; }

		//Relation
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
