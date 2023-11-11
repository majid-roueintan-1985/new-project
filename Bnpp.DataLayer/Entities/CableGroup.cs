using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class CableGroup
    {
        [Key]
        public int GroupId { get; set; }

        
        public string GroupTitle { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        public List<CableIdentity> CableIdentities { get; set; }
    }
}
