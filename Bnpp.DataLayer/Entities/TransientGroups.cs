using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bnpp.DataLayer.Entities
{
    public class TransientGroups
    {
        [Key]
        public int GroupId { get; set; }


        [MaxLength(200)]
        public string GroupTitle { get; set; }

        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        [ForeignKey("ParentId")]
        public List<TransientGroups> GetTransientGroups { get; set; }
    }
}
