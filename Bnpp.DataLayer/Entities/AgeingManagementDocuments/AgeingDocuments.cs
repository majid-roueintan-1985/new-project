using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.AgeingManagementDocuments
{
    public class AgeingDocuments
    {
        [Key]
        public int AgeingDocumentsId { get; set; }
        public string AgeingImage { get; set; }
        public string Code { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }
}
