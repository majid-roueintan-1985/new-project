using Bnpp.DataLayer.Entities.ONOFF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
	public class ChangingInState
	{
        [Key]
        public int SG_Id { get; set; }
        [Required]
        public int ChangeStateId { get; set; }
        [Required]
        public int StateId { get; set; }




        [ForeignKey("StateId")]
        public States States { get; set; }

        [ForeignKey("ChangeStateId")]
        public ChangeState ChangeState { get; set; }
    }
}
