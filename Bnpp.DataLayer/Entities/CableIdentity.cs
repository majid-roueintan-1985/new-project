using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class CableIdentity
    {
        [Key]
        public int CableId { get; set; }

        public string CableTitle { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }


        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public CableGroup CableGroup { get; set; }

    }
}
