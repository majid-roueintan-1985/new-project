using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.AgeingManagementDocuments
{
    public class Methodology
    {
        [Key]
        public int MethodologyId  { get; set; }
        public string MethodologyImage { get; set; }
        public string Code { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public string DocumentName { get; set; }
        public string Filename { get; set; }
    }
}
