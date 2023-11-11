using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class MechanismViewModel
    {
        public string DegradationMechanism { get; set; }

        public string Component { get; set; }

        public string Region { get; set; }

        public string CriticalPoint { get; set; }

        public string Consequences { get; set; }
    }

    public class MechanismDocumentsViewModel
    {

        public string MechanismDocumentsImage { get; set; }

        public string Code { get; set; }
       
        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }
}
