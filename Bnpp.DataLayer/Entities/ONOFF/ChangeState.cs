using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.ONOFF
{
    public class ChangeState
    {
        [Key]
        public int ChangeStateId { get; set; }

        public string Description { get; set; }

        public DateTime ChangeStateDate { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

        public List<ChangingInState> ChangingInState { get; set; }


        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
