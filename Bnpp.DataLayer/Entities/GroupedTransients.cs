using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class GroupedTransients
    {
        [Key]
        public int GroupId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int AllowableNumber { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CrerateDate { get; set; }
    }
}
