using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class OperationalDocumentsViewModel
    {
        public string OperationalImage { get; set; }

        public string Code { get; set; }

        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }
    public class DrawingViewModel
    {
        public string DrawingImage { get; set; }

        public string Code { get; set; }

        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }

    public class StandardViewModel
    {
        public string StandardImage { get; set; }

        public string Code { get; set; }
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }

    public class ManufacturerViewModel
    {
        public string ManufacturerImage { get; set; }

        public string Code { get; set; }
       
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }

    public class InstallationViewModel
    {
        public string InstallationImage { get; set; }

        public string Code { get; set; }
        
        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }

    public class MaintenanceDocumentViewModel
    {

        public string MaintenanceImage { get; set; }

        public string Code { get; set; }
        
        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }

    public class AgeingViewModel
    {
        public string AgeingImage { get; set; }

        public string Code { get; set; }
        
        public string DocumentName { get; set; }

        public string Filename { get; set; }
    }
}
