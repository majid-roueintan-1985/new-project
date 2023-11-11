using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class TransientDocuments
    {
        [Key]
        public int TransientDocumentsId { get; set; }

        public int TransientsId { get; set; }

        public string TransientDocumentsImage { get; set; }
       
        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }
       
        public string Filename { get; set; }

        public Transients Transients { get; set; }

    }
}
