using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class GeneralData
    {
        [Key]
        public int  GeneralId { get; set; }

       
        public string DesignationOfParameters { get; set; }

        
        public string Value { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
		//Relations
		[Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
