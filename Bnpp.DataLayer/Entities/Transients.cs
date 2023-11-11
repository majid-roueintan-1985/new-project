using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class Transients
    {
        [Key]
        public int TransientsId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Code { get; set; }

       
        public string Description { get; set; }

        public string AllowableNumber { get; set; }

        public DateTime TransientDate { get; set; }

        public string TransientTime { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


        public List<TransientDocuments> TransientDocuments { get; set; }
    }
}
