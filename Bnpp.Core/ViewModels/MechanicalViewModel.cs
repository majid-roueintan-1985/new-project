using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class MechanicalListViewModel
    {
        public int MechanicalId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class EquipmentsViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

    }
}
