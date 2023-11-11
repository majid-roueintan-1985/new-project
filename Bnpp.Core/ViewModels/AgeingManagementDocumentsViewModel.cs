using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class MethodologyViewModel
    {
        public string MethodologyImage { get; set; }
        public string Code { get; set; }
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }


    public class AgeingDocumentsViewModel
    {
        public string AgeingImage { get; set; }
        public string Code { get; set; }
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }

    public class ManagementReviewsViewModel
    {
        public string Type { get; set; }

        public string Frequency { get; set; }

        public string Prepared { get; set; }

        public string Authorized { get; set; }
        public string Approved { get; set; }

        public DateTime Date { get; set; }
    }
    
}
