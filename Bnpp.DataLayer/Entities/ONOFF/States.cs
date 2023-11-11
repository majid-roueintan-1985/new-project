using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.ONOFF
{
    public class States
    {
        [Key]
        public int StateId { get; set; }

        


        public string StateTitle { get; set; }
        public List<ChangingInState> ChangingInState { get; set; }

        public bool IsDelete { get; set; }
    }
}
